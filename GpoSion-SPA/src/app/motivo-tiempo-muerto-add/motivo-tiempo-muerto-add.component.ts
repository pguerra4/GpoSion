import { Component, OnInit } from "@angular/core";
import { MotivoTiempoMuerto } from "../_models/motivo-tiempo-muerto";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-motivo-tiempo-muerto-add",
  templateUrl: "./motivo-tiempo-muerto-add.component.html",
  styleUrls: ["./motivo-tiempo-muerto-add.component.css"]
})
export class MotivoTiempoMuertoAddComponent implements OnInit {
  motivo: MotivoTiempoMuerto;
  motivoForm: FormGroup;

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  createMotivoTiempoMuertoForm() {
    this.motivoForm = this.fb.group({
      motivo: ["", Validators.required]
    });
  }

  ngOnInit() {
    this.createMotivoTiempoMuertoForm();
  }

  addMotivoTiempoMuerto() {
    this.motivo = Object.assign({}, this.motivoForm.value);
    this.moldeadoraService.addMotivoTiempoMuerto(this.motivo).subscribe(
      (res: MotivoTiempoMuerto) => {
        this.alertify.success("Guardado");
        this.router.navigate(["motivostiempomuerto"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
