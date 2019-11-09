import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Material } from "../_models/material";
import { UnidadMedida } from "../_models/unidadMedida";
import { TipoMaterial } from "../_models/tipo-material";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { Router, ActivatedRoute } from "@angular/router";
import { ValidateExistingMaterial } from "../_validators/async-material-existente.validator";

@Component({
  selector: "app-material-edit",
  templateUrl: "./material-edit.component.html",
  styleUrls: ["./material-edit.component.css"]
})
export class MaterialEditComponent implements OnInit {
  materialForm: FormGroup;
  material: Material;
  unidadesMedida: UnidadMedida[];
  tiposMaterial: TipoMaterial[];

  constructor(
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private unidadMedidaService: UnidadMedidaService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.material = data["material"];
    });
    this.loadUnidadesMedida();
    this.loadTiposMaterial();
    this.createMateriaForm();
  }

  createMateriaForm() {
    this.materialForm = this.fb.group(
      {
        materialId: [this.material.materialId, Validators.required],
        material: [
          this.material.material,
          Validators.required,
          ValidateExistingMaterial.createValidator(
            this.existenciasService,
            this.material.materialId
          )
        ],
        descripcion: [this.material.descripcion],
        unidadMedidaId: [this.material.unidadMedidaId, Validators.required],
        tipoMaterialId: [this.material.tipoMaterialId, Validators.required]
      },
      { updateOn: "blur" }
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

  loadTiposMaterial() {
    this.existenciasService.getTiposMaterial().subscribe(
      (res: TipoMaterial[]) => {
        this.tiposMaterial = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
  editMaterial() {
    this.material = Object.assign({}, this.materialForm.value);
    this.existenciasService
      .editMaterial(+this.route.snapshot.params["id"], this.material)
      .subscribe(
        (res: Material) => {
          this.alertify.success("Guardado");
          this.router.navigate(["materiales"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
