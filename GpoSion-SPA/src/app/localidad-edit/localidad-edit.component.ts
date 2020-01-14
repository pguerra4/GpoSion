import { Component, OnInit } from "@angular/core";
import { Localidad } from "../_models/localidad";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ReciboService } from "../_services/recibo.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-localidad-edit",
  templateUrl: "./localidad-edit.component.html",
  styleUrls: ["./localidad-edit.component.css"]
})
export class LocalidadEditComponent implements OnInit {
  localidad: Localidad;
  localidadForm: FormGroup;

  constructor(
    private reciboService: ReciboService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  createLocalidadForm() {
    this.localidadForm = this.fb.group({
      localidadId: [this.localidad.localidadId, Validators.required],
      localidad: [this.localidad.localidad, Validators.required]
    });
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.localidad = data["localidad"];
    });
    this.createLocalidadForm();
  }

  editLocalidad() {
    this.localidad = Object.assign({}, this.localidadForm.value);
    this.reciboService
      .editLocalidad(+this.route.snapshot.params["id"], this.localidad)
      .subscribe(
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
