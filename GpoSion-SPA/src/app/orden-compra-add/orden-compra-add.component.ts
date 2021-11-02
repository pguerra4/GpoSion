import { Component, OnInit } from "@angular/core";
import { OrdenCompraService } from "../_services/orden-compra.service";
import { AlertifyService } from "../_services/alertify.service";
import { ClienteService } from "../_services/cliente.service";
import { NumeroParteService } from "../_services/numeroParte.service";
import { Cliente } from "../_models/cliente";
import { NumeroParte } from "../_models/numeroParte";
import { OrdenCompra } from "../_models/orden-compra";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { OrdenCompraDetalle } from "../_models/orden-compra-detalle";
import { BsDatepickerConfig } from "ngx-bootstrap";
import { Router } from "@angular/router";
import { ValidateExistingNumeroOrden } from "../_validators/async-numero-orden-existente.validator";
import { ValidateNotExistingNumeroParte } from "../_validators/async-numero-parte-no-existente.validator";

@Component({
  selector: "app-orden-compra-add",
  templateUrl: "./orden-compra-add.component.html",
  styleUrls: ["./orden-compra-add.component.css"],
})
export class OrdenCompraAddComponent implements OnInit {
  ordenCompraForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  clientes: Cliente[];
  numerosParteCat: NumeroParte[];
  numerosParte: NumeroParte[];
  detalles: OrdenCompraDetalle[] = new Array();
  ordenCompra: OrdenCompra;

  constructor(
    private clienteService: ClienteService,
    private numeroParteService: NumeroParteService,
    private ordenesService: OrdenCompraService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    (this.bsConfig = {
      containerClass: "theme-orange",
      dateInputFormat: "DD/MM/YYYY",
    }),
      this.loadClientes();
    this.loadNumerosParte();
    this.createOrdenCompraForm();
  }

  createOrdenCompraForm() {
    const now = new Date();
    this.ordenCompraForm = this.fb.group(
      {
        noOrden: [
          null,
          [Validators.required, Validators.pattern("^[0-9]*$")],
          [ValidateExistingNumeroOrden.createValidator(this.ordenesService)],
        ],
        clienteId: [null, Validators.required],
        fecha: [now],
        noParte: [
          null,
          Validators.required,
          ValidateNotExistingNumeroParte.createValidator(
            this.numeroParteService
          ),
        ],
        precio: [null],
        cantidad: [0],
        fechaInicio: [now],
        fechaFin: [null],
      },
      { updateOn: "blur" }
    );
  }

  loadClientes() {
    this.clienteService.getClientes().subscribe(
      (res: Cliente[]) => {
        this.clientes = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadNumerosParte() {
    this.numeroParteService.getNumerosParte().subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
        this.numerosParteCat = this.numerosParte;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  filterNumerosParte(clienteId: number) {
    console.log(this.numerosParte);
    this.numerosParteCat = this.numerosParte.filter(
      (np) => np.clienteId == clienteId
    );
    console.log(this.numerosParteCat);
  }

  addNumeroParte() {
    const now = new Date();
    const detalle: OrdenCompraDetalle = {
      noParte: this.ordenCompraForm.get("noParte").value,
      piezasAutorizadas: +this.ordenCompraForm.get("cantidad").value,
      precio: +this.ordenCompraForm.get("precio").value,
      fechaInicio: this.ordenCompraForm.get("fechaInicio").value,
      fechaFin: this.ordenCompraForm.get("fechaFin").value,
      id: 0,
      noOrden: +this.ordenCompraForm.get("noOrden").value,
      piezasSurtidas: 0,
      ultimaModificacion: now,
    };

    if (this.detalles.indexOf(detalle) < 0) {
      this.detalles.push(detalle);
    }

    this.ordenCompraForm.get("noParte").setValue(null);
    this.ordenCompraForm.get("cantidad").setValue(0);
    this.ordenCompraForm.get("precio").setValue(null);
    this.ordenCompraForm.get("fechaInicio").setValue(now);
    this.ordenCompraForm.get("fechaFin").setValue(null);
  }

  deleteNumeroParte(noParte: string) {
    this.detalles.splice(
      this.detalles.findIndex((d) => d.noParte === noParte),
      1
    );
  }

  addOrdenCompra() {
    this.ordenCompra = Object.assign({}, this.ordenCompraForm.value);
    this.ordenCompra.numerosParte = new Array();
    this.detalles.forEach((detalle) => {
      this.ordenCompra.numerosParte.push(detalle);
    });

    this.ordenesService.addOrdenCompra(this.ordenCompra).subscribe(
      (res: OrdenCompra) => {
        this.alertify.success("Guardado");
        this.router.navigate(["ordenescompra"]);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
