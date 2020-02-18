import { Component, OnInit } from "@angular/core";
import { Cliente } from "../_models/cliente";
import { Area } from "../_models/area";
import { ClienteService } from "../_services/cliente.service";
import { AreaService } from "../_services/area.service";
import { MoldeService } from "../_services/molde.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Molde } from "../_models/molde";
import { ValidateExistingMolde } from "../_validators/async-molde-existente.validator";

@Component({
  selector: "app-molde-add",
  templateUrl: "./molde-add.component.html",
  styleUrls: ["./molde-add.component.css"]
})
export class MoldeAddComponent implements OnInit {
  moldeForm: FormGroup;
  molde: Molde;
  clientes: Cliente[];
  areas: Area[];

  constructor(
    private clienteService: ClienteService,
    private areaService: AreaService,
    private moldeService: MoldeService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadClientes();
    this.loadAreas();
    this.createMoldeForm();
  }

  createMoldeForm() {
    this.moldeForm = this.fb.group(
      {
        molde: [
          "",
          Validators.required,
          ValidateExistingMolde.createValidator(this.moldeService)
        ],
        clienteId: [null, Validators.required],
        ubicacionId: [1, Validators.required]
      },
      { updateOn: "blur" }
    );
  }

  loadClientes() {
    this.clienteService.getClientes().subscribe(
      (res: Cliente[]) => {
        this.clientes = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  loadAreas() {
    this.areaService.getAreas().subscribe(
      (res: Area[]) => {
        this.areas = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  addMolde() {
    this.molde = Object.assign({}, this.moldeForm.value);
    this.moldeService.addMolde(this.molde).subscribe(
      (res: Molde) => {
        this.alertify.success("Guardado");
        this.router.navigate(["moldes"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
