import { Component, OnInit, Input } from "@angular/core";
import { Viajero } from "../_models/viajero";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute, Router } from "@angular/router";
import { RequerimientoMaterialMaterial } from "../_models/requerimientoMaterialMaterial";
import { FormGroup, FormBuilder, Validators, FormArray } from "@angular/forms";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";
import { RequerimientoMaterialService } from "../_services/requerimientoMaterial.service";

@Component({
  selector: "app-requerimiento-material-viajeros",
  templateUrl: "./requerimiento-material-viajeros.component.html",
  styleUrls: ["./requerimiento-material-viajeros.component.css"]
})
export class RequerimientoMaterialViajerosComponent implements OnInit {
  @Input() material: RequerimientoMaterialMaterial;
  surtirMaterialForm: FormGroup;
  items: FormArray;
  viajeros: Viajero[];
  porSurtir: number;

  constructor(
    private existenciasMaterialService: ExistenciasMaterialService,
    private requerimientoMaterialService: RequerimientoMaterialService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.porSurtir = this.material.cantidad - this.material.cantidadEntregada;
    this.loadViajeros();
  }

  createReciboForm() {
    this.surtirMaterialForm = this.fb.group({
      almacenista: [""],
      recibio: [""],
      items: this.fb.array([])
    });
  }

  createItem(viajero: Viajero, acumulado: number): FormGroup {
    const maximo: number = this.porSurtir;
    const resto = this.porSurtir - acumulado;
    return this.fb.group({
      viajero: [viajero.viajero],
      localidad: [viajero.localidad],
      localidadId: [viajero.localidadId],
      existencia: [viajero.existencia],
      materialId: [viajero.materialId],
      id: [this.material.id],
      asurtir: [
        resto > viajero.existencia ? viajero.existencia : resto,
        [Validators.required, Validators.max(viajero.existencia)]
      ]
    });
  }

  // checkExcedido(g: FormGroup) {
  //   return g.get("asurtir").value <= this.porSurtir ? null : { excedido: true };
  // }

  createItems() {
    this.items = this.surtirMaterialForm.get("items") as FormArray;
    let total = 0;
    for (const viajero of this.viajeros) {
      if (this.material.cantidad >= total) {
        this.items.push(this.createItem(viajero, total));
      }
      total += +viajero.existencia;
    }
    this.surtirMaterialForm.get("items").setValue(this.items);
  }

  loadViajeros() {
    this.existenciasMaterialService
      .getViajerosPorMaterial(this.material.materialId)
      .subscribe(
        (viajeros: Viajero[]) => {
          this.viajeros = viajeros;
          this.createReciboForm();
          this.createItems();
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  surtirMaterial() {
    const rm: RequerimientoMaterial = Object.assign(
      {},
      this.surtirMaterialForm.value
    );
    rm.requerimientoMaterialId = this.material.requerimientoMaterialId;

    // console.log(rm);
    this.requerimientoMaterialService
      .surtirRequerimiento(this.material.requerimientoMaterialId, rm)
      .subscribe(
        () => {
          this.alertify.success("Guardado");
          this.router.navigate(["requerimientosprod"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
  trackByFn(index: any, item: any) {
    return index;
  }
}
