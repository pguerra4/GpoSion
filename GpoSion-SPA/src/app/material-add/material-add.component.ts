import { Component, OnInit } from "@angular/core";
import { Material } from "../_models/material";
import { UnidadMedida } from "../_models/unidadMedida";
import { TipoMaterial } from "../_models/tipo-material";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { Router } from "@angular/router";
import { ValidateExistingMaterial } from "../_validators/async-material-existente.validator";

@Component({
  selector: "app-material-add",
  templateUrl: "./material-add.component.html",
  styleUrls: ["./material-add.component.css"]
})
export class MaterialAddComponent implements OnInit {
  materialForm: FormGroup;
  material: Material;
  unidadesMedida: UnidadMedida[];
  tiposMaterial: TipoMaterial[];

  constructor(
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private unidadMedidaService: UnidadMedidaService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadUnidadesMedida();
    this.loadTiposMaterial();
    this.createMateriaForm();
  }

  createMateriaForm() {
    this.materialForm = this.fb.group(
      {
        material: [
          "",
          Validators.required,
          ValidateExistingMaterial.createValidator(this.existenciasService, 0)
        ],
        descripcion: [""],
        stockMinimo: [0],
        unidadMedidaId: [1, Validators.required],
        tipoMaterialId: [1, Validators.required]
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
  addMaterial() {
    this.material = Object.assign({}, this.materialForm.value);
    this.existenciasService.addMaterial(this.material).subscribe(
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
