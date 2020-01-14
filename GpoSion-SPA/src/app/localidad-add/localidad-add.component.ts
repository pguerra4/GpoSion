import { Component, OnInit } from "@angular/core";
import { Localidad } from "../_models/localidad";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ReciboService } from "../_services/recibo.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";
import { TipoMaterial } from "../_models/tipo-material";

@Component({
  selector: "app-localidad-add",
  templateUrl: "./localidad-add.component.html",
  styleUrls: ["./localidad-add.component.css"]
})
export class LocalidadAddComponent implements OnInit {
  localidad: Localidad;
  localidadForm: FormGroup;

  constructor(
    private reciboService: ReciboService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  createLocalidadForm() {
    this.localidadForm = this.fb.group({
      localidad: ["", Validators.required]
    });
  }

  ngOnInit() {
    this.createLocalidadForm();
  }

  addLocalidad() {
    this.localidad = Object.assign({}, this.localidadForm.value);
    this.reciboService.addLocalidad(this.localidad).subscribe(
      (res: Localidad) => {
        this.alertify.success("Guardado");
        this.router.navigate(["localidades"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
