import { Component, OnInit } from "@angular/core";
import { TipoMaterial } from "../_models/tipo-material";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-tipo-material-edit",
  templateUrl: "./tipo-material-edit.component.html",
  styleUrls: ["./tipo-material-edit.component.css"]
})
export class TipoMaterialEditComponent implements OnInit {
  tipoMaterial: TipoMaterial;
  tipoMaterialForm: FormGroup;

  constructor(
    private existenciasMaterialService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  createTipoMaterialForm() {
    this.tipoMaterialForm = this.fb.group({
      tipoMaterialId: [this.tipoMaterial.tipoMaterialId, Validators.required],
      tipo: [this.tipoMaterial.tipo, Validators.required]
    });
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.tipoMaterial = data["tipoMaterial"];
    });
    this.createTipoMaterialForm();
  }

  editTipoMaterial() {
    this.tipoMaterial = Object.assign({}, this.tipoMaterialForm.value);
    this.existenciasMaterialService
      .editTipoMaterial(+this.route.snapshot.params["id"], this.tipoMaterial)
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
