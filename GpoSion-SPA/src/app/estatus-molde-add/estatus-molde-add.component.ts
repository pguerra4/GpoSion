import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { EstatusMolde } from "../_models/estatus-molde";
import { MoldeService } from "../_services/molde.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-estatus-molde-add",
  templateUrl: "./estatus-molde-add.component.html",
  styleUrls: ["./estatus-molde-add.component.css"]
})
export class EstatusMoldeAddComponent implements OnInit {
  estatusMoldeForm: FormGroup;
  estatusMolde: EstatusMolde;

  constructor(
    private moldeService: MoldeService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.createEstatusMoldeForm();
  }

  createEstatusMoldeForm() {
    this.estatusMoldeForm = this.fb.group(
      {
        estatus: ["", Validators.required]
      },
      { updateOn: "blur" }
    );
  }

  addEstatusMolde() {
    this.estatusMolde = Object.assign({}, this.estatusMoldeForm.value);
    this.moldeService.addEstatusMolde(this.estatusMolde).subscribe(
      (res: EstatusMolde) => {
        this.alertify.success("Guardado");
        this.router.navigate(["estatusmoldes"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
