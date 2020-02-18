import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { EstatusMolde } from "../_models/estatus-molde";
import { MoldeService } from "../_services/molde.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-estatus-molde-edit",
  templateUrl: "./estatus-molde-edit.component.html",
  styleUrls: ["./estatus-molde-edit.component.css"]
})
export class EstatusMoldeEditComponent implements OnInit {
  estatusMoldeForm: FormGroup;
  estatusMolde: EstatusMolde;

  constructor(
    private moldeService: MoldeService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.estatusMolde = data["estatusMolde"];
      this.createEstatusMoldeForm();
    });
  }

  createEstatusMoldeForm() {
    this.estatusMoldeForm = this.fb.group(
      {
        estatusMoldeId: [this.estatusMolde.estatusMoldeId, Validators.required],
        estatus: [this.estatusMolde.estatus, Validators.required]
      },
      { updateOn: "blur" }
    );
  }

  editEstatusMolde() {
    this.estatusMolde = Object.assign({}, this.estatusMoldeForm.value);

    this.moldeService
      .editEstatusMolde(+this.route.snapshot.params["id"], this.estatusMolde)
      .subscribe(
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
