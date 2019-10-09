import { Component, OnInit, Input } from "@angular/core";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { TurnosService } from "../_services/turnos.service";
import { Turno } from "../_models/turno";
import { ExistenciaMaterial } from "../_models/existenciaMaterial";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { UnidadMedida } from "../_models/unidadMedida";
import { RequerimientoMaterialMaterial } from "../_models/requerimientoMaterialMaterial";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";
import { RequerimientoMaterialService } from "../_services/requerimientoMaterial.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-requerimiento-material",
  templateUrl: "./requerimiento-material.component.html",
  styleUrls: ["./requerimiento-material.component.css"]
})
export class RequerimientoMaterialComponent implements OnInit {
  @Input() rmm: RequerimientoMaterialMaterial;
  requerimientoForm: FormGroup;
  turnos: Turno[];
  unidadesMedida: UnidadMedida[];
  existencias: ExistenciaMaterial[];
  requerimiento: RequerimientoMaterial;
  materialesSolicitados: RequerimientoMaterialMaterial[] = new Array();

  constructor(
    private existenciasMaterialService: ExistenciasMaterialService,
    private requerimientosMaterialService: RequerimientoMaterialService,
    private turnosService: TurnosService,
    private unidadMedidaService: UnidadMedidaService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadTurnos();
    this.loadUnidadesMedida();
    this.loadExistencias();
    this.createRequerimientoForm();
    this.rmm = {} as RequerimientoMaterialMaterial;
    this.rmm.unidadMedidaId = 1;
    this.rmm.cantidad = 0;
  }

  createRequerimientoForm() {
    this.requerimientoForm = this.fb.group({
      jefaLinea: [""],
      turnoId: [1, Validators.required],
      materiales: [new Array(), Validators.required]
    });
  }

  loadTurnos() {
    this.turnosService.getTurnos().subscribe(
      (res: Turno[]) => {
        this.turnos = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  loadUnidadesMedida() {
    this.unidadMedidaService.getUnidadesMedida().subscribe(
      (res: UnidadMedida[]) => {
        this.unidadesMedida = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  loadExistencias() {
    this.existenciasMaterialService.getExistenciasMaterial().subscribe(
      (res: ExistenciaMaterial[]) => {
        this.existencias = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  addRequerimientoMaterial() {
    if (this.isNumber(this.rmm.cantidad) && this.rmm.cantidad > 0) {
      const existencia: ExistenciaMaterial = this.existencias.find(
        e => e.materialId === this.rmm.materialId
      );

      if (existencia) {
        let total = +this.rmm.cantidad;
        const yaSolicitado = this.materialesSolicitados.find(
          ms => ms.materialId === this.rmm.materialId
        );
        if (yaSolicitado != null) {
          total += +yaSolicitado.cantidad;
        }

        if (total <= existencia.existencia) {
          // const material = {} as RequerimientoMaterialMaterial;
          if (yaSolicitado != null) {
            yaSolicitado.cantidad = total;
          } else {
            const material: RequerimientoMaterialMaterial = Object.assign(
              {},
              this.rmm
            );

            this.materialesSolicitados.push(material);
            this.requerimientoForm
              .get("materiales")
              .setValue(this.materialesSolicitados);
          }

          this.rmm.material = null;
          this.rmm.materialId = null;
          this.rmm.cantidad = 0;
          this.rmm.unidadMedidaId = 1;
        } else {
          this.alertify.error("La cantidad no puede ser mayor a la existencia");
        }
      } else {
        this.alertify.error("Material no válido.");
      }
    } else {
      this.alertify.error("La cantidad debe ser mayor a 0.");
    }
  }

  addRequerimiento() {
    this.requerimiento = Object.assign({}, this.requerimientoForm.value);
    this.requerimientosMaterialService
      .addRequerimiento(this.requerimiento)
      .subscribe(
        (res: RequerimientoMaterial) => {
          this.alertify.success("Guardado");
          this.router.navigate(["requerimientos"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  seleccionarMaterial(id: number, material: string) {
    this.rmm.material = material;
    this.rmm.materialId = id;
  }

  isNumber(value: string | number): boolean {
    return value != null && !isNaN(Number(value.toString()));
  }

  deleteMaterial(id: number) {
    this.materialesSolicitados.splice(
      this.materialesSolicitados.findIndex(d => d.materialId === id),
      1
    );
    this.requerimientoForm
      .get("materiales")
      .setValue(this.materialesSolicitados);

    this.alertify.success("Material borrado");
  }

  updateCantidad(cantidad) {
    this.rmm.cantidad = cantidad;
  }

  updateUnidadMedida(value) {
    this.rmm.unidadMedidaId = value;
  }
}
