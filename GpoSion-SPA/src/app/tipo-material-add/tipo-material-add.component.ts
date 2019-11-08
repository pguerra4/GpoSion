import { Component, OnInit } from "@angular/core";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { TipoMaterial } from "../_models/tipo-material";
import { Router } from "@angular/router";

@Component({
  selector: "app-tipo-material-add",
  templateUrl: "./tipo-material-add.component.html",
  styleUrls: ["./tipo-material-add.component.css"]
})
export class TipoMaterialAddComponent implements OnInit {
  tipoMaterial: TipoMaterial;
  tipoMaterialForm: FormGroup;

  constructor(
    private existenciasMaterialService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  createTipoMaterialForm() {
    this.tipoMaterialForm = this.fb.group({
      tipo: ["", Validators.required]
    });
  }

  ngOnInit() {
    this.createTipoMaterialForm();
  }

  addTipoMaterial() {
    this.tipoMaterial = Object.assign({}, this.tipoMaterialForm.value);
    this.existenciasMaterialService
      .addTipoMaterial(this.tipoMaterial)
      .subscribe(
        (res: TipoMaterial) => {
          this.alertify.success("Guardado");
          this.router.navigate(["tiposmaterial"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
