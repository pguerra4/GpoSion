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

  constructor(
    private clienteService: ClienteService,
    private areaService: AreaService,
    private moldeService: MoldeService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.molde = data["molde"];
    });
    this.loadClientes();
    this.loadAreas();
    this.createMoldeForm();
  }

  createMoldeForm() {
    this.moldeForm = this.fb.group({
      id: [this.molde.id, Validators.required],
      molde: [this.molde.molde, Validators.required],
      clienteId: [this.molde.clienteId, Validators.required],
      ubicacionId: [this.molde.ubicacionId, Validators.required],
      moldeadoraId: [this.molde.moldeadoraId]
    });
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

  editMolde() {
    this.molde = Object.assign({}, this.moldeForm.value);
    console.log(this.molde);
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
