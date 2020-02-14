import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { RetornoMaterial } from "../_models/retorno-material";
import { Localidad } from "../_models/localidad";
import { Material } from "../_models/material";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { ReciboService } from "../_services/recibo.service";

@Component({
  selector: "app-retorno-material-edit",
  templateUrl: "./retorno-material-edit.component.html",
  styleUrls: ["./retorno-material-edit.component.css"]
})
export class RetornoMaterialEditComponent implements OnInit {
  retornoForm: FormGroup;
  retorno: RetornoMaterial;
  localidades: Localidad[];
  materialesCat: Material[];

  constructor(
    private fb: FormBuilder,
    private alertify: AlertifyService,
    private router: Router,
    private existenciasService: ExistenciasMaterialService,
    private reciboService: ReciboService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadLocalidades();
    this.loadMateriales();
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.retorno = data["retornoMaterial"];
      this.createRetornoForm();
    });
  }

  createRetornoForm() {
    this.retornoForm = this.fb.group(
      {
        movimientoMaterialId: [
          this.retorno.movimientoMaterialId,
          Validators.required
        ],
        material: [this.retorno.material],
        materialId: [this.retorno.materialId, Validators.required],
        localidadId: [this.retorno.localidadId, Validators.required],
        cantidad: [this.retorno.cantidad, Validators.required]
      },
      { updateOn: "blur" }
    );
  }

  loadLocalidades() {
    this.reciboService.getLocalidades().subscribe(res => {
      this.localidades = res;
    });
  }

  loadMateriales() {
    this.existenciasService.getMateriales().subscribe(
      (res: Material[]) => {
        this.materialesCat = res;
        console.log(this.materialesCat);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  onSelectMaterial(item: any) {
    this.retornoForm.get("materialId").setValue(item.item.materialId);
  }

  editRetornoMaterial() {
    this.retorno = Object.assign({}, this.retornoForm.value);
    this.existenciasService
      .editRetornoMaterial(+this.route.snapshot.params["id"], this.retorno)
      .subscribe(
        (res: RetornoMaterial) => {
          this.alertify.success("Guardado");
          this.router.navigate(["retornosmaterial"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
