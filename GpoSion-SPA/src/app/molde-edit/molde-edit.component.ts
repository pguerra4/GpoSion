import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Molde } from "../_models/molde";
import { Cliente } from "../_models/cliente";
import { Area } from "../_models/area";
import { ClienteService } from "../_services/cliente.service";
import { AreaService } from "../_services/area.service";
import { MoldeService } from "../_services/molde.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { ValidateExistingMolde } from "../_validators/async-molde-existente.validator";
import { EstatusMolde } from "../_models/estatus-molde";
import {
  BsDatepickerConfig,
  BsLocaleService,
  defineLocale,
  deLocale
} from "ngx-bootstrap";

@Component({
  selector: "app-molde-edit",
  templateUrl: "./molde-edit.component.html",
  styleUrls: ["./molde-edit.component.css"]
})
export class MoldeEditComponent implements OnInit {
  moldeForm: FormGroup;
  molde: Molde;
  clientes: Cliente[];
  areas: Area[];
  moldeadoras: any[];
  estatusMoldes: EstatusMolde[];
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private clienteService: ClienteService,
    private areaService: AreaService,
    private moldeService: MoldeService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private localeService: BsLocaleService
  ) {}

  ngOnInit() {
    this.localeService.use("es");
    defineLocale("es-us", deLocale);
    this.loadClientes();
    this.loadEstatusMoldes();
    this.loadAreas();
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.molde = data["molde"];
      this.createMoldeForm();
    });
  }

  createMoldeForm() {
    const now = new Date();
    this.moldeForm = this.fb.group(
      {
        id: [this.molde.id, Validators.required],
        molde: [
          this.molde.molde,
          Validators.required,
          ValidateExistingMolde.createValidator(
            this.moldeService,
            this.molde.molde
          )
        ],
        clienteId: [this.molde.clienteId, Validators.required],
        ubicacionId: [this.molde.ubicacionId, Validators.required],
        moldeadoraId: [this.molde.moldeadoraId],
        estatusMoldeId: [this.molde.estatusMoldeId],
        observaciones: [null],
        fecha: [now]
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

  loadEstatusMoldes() {
    this.moldeService.getEstatusMoldes().subscribe(
      (res: EstatusMolde[]) => {
        this.estatusMoldes = res;
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

  editMolde() {
    this.molde = Object.assign({}, this.moldeForm.value);

    this.moldeService
      .editMolde(+this.route.snapshot.params["id"], this.molde)
      .subscribe(
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
