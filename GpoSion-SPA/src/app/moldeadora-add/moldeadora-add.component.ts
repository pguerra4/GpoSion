import { Component, OnInit } from "@angular/core";
import { Moldeadora } from "../_models/moldeadora";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-moldeadora-add",
  templateUrl: "./moldeadora-add.component.html",
  styleUrls: ["./moldeadora-add.component.css"]
})
export class MoldeadoraAddComponent implements OnInit {
  moldeadora: Moldeadora;
  moldeadoraForm: FormGroup;

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  createMoldeadoraForm() {
    this.moldeadoraForm = this.fb.group({
      moldeadora: ["", Validators.required]
    });
  }

  ngOnInit() {
    this.createMoldeadoraForm();
  }

  addMoldeadora() {
    this.moldeadora = Object.assign({}, this.moldeadoraForm.value);
    this.moldeadoraService.addMoldeadora(this.moldeadora).subscribe(
      (res: Moldeadora) => {
        this.alertify.success("Guardado");
        this.router.navigate(["moldeadoras"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
