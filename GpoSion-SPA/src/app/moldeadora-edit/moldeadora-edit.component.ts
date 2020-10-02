import { Component, OnInit } from "@angular/core";
import { Moldeadora } from "../_models/moldeadora";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-moldeadora-edit",
  templateUrl: "./moldeadora-edit.component.html",
  styleUrls: ["./moldeadora-edit.component.css"],
})
export class MoldeadoraEditComponent implements OnInit {
  moldeadora: Moldeadora;
  moldeadoraForm: FormGroup;

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  createMoldeadoraForm() {
    this.moldeadoraForm = this.fb.group({
      moldeadoraId: [this.moldeadora.moldeadoraId, Validators.required],
      moldeadora: [this.moldeadora.moldeadora, Validators.required],
      disparosPorHora: [this.moldeadora.disparosPorHora],
    });
  }

  ngOnInit() {
    this.route.data.subscribe((data) => {
      // tslint:disable-next-line: no-string-literal
      this.moldeadora = data["moldeadora"];
      this.createMoldeadoraForm();
    });
  }

  editMoldeadora() {
    this.moldeadora = Object.assign({}, this.moldeadoraForm.value);
    this.moldeadoraService
      .editNombreMoldeadora(+this.route.snapshot.params["id"], this.moldeadora)
      .subscribe(
        (res: Moldeadora) => {
          this.alertify.success("Guardado");
          this.router.navigate(["moldeadoraslist"]);
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }
}
