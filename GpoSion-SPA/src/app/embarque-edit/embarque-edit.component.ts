import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Embarque } from "../_models/embarque";
import { DetalleEmbarque } from "../_models/detalle-embarque";
import { Cliente } from "../_models/cliente";
import { NumeroParte } from "../_models/numeroParte";
import { OrdenCompra } from "../_models/orden-compra";
import { ClienteService } from "../_services/cliente.service";
import { NumeroParteService } from "../_services/numeroParte.service";
import { OrdenCompraService } from "../_services/orden-compra.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";
import { ValidateExistingFolioEmbarque } from "../_validators/async-folio-embarque-existente.validator";

@Component({
  selector: "app-embarque-edit",
  templateUrl: "./embarque-edit.component.html",
  styleUrls: ["./embarque-edit.component.css"]
})
export class EmbarqueEditComponent implements OnInit {
  embarqueForm: FormGroup;
  embarque: Embarque;
  detallesEmbarque: DetalleEmbarque[] = new Array();
  clientes: Cliente[];
  numerosParte: NumeroParte[];
  ordenesCompra: OrdenCompra[];
  npParams: any = {};

  constructor(
    private clienteService: ClienteService,
    private numeroParteService: NumeroParteService,
    private ordenCompraService: OrdenCompraService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.localeService.use("es");
    this.loadClientes();
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.embarque = data["embarque"];
      this.detallesEmbarque = this.embarque.detallesEmbarque;
      this.createEmbarqueForm();
    });
  }

  createEmbarqueForm() {
    const now = new Date();
    this.embarqueForm = this.fb.group(
      {
        embarqueId: [this.embarque.embarqueId, Validators.required],
        clienteId: [this.embarque.clienteId, Validators.required],
        folio: [
          this.embarque.folio,
          Validators.required,
          ValidateExistingFolioEmbarque.createValidator(this.numeroParteService)
        ],
        fecha: [new Date(this.embarque.fecha)],
        rechazadas: [this.embarque.rechazadas],
        noParte: [""],
        noOrden: [""],
        noOrden2: [""],
        cajas: [0],
        piezasXCaja: [0],
        entregadas: [0]
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

  clienteChange(clienteId: number) {
    this.embarqueForm.get("noParte").setValue("");
    this.npParams.clienteId = clienteId;
    this.numeroParteService.getNumerosParte(this.npParams).subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  onSelectNumeroParte(np: any) {
    if (np) {
      this.loadOrdenesCompra(np.value);
    }
  }

  onSelectNoOrden(po: any) {
    if (po) {
      this.embarqueForm.get("noOrden2").setValue(po.value);
    }
  }

  loadOrdenesCompra(noParte: string) {
    this.ordenCompraService
      .getOrdenesCompraAbiertasXNumroParte(noParte)
      .subscribe(
        (res: OrdenCompra[]) => {
          this.ordenesCompra = res;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  editEmbarque() {
    this.embarque = Object.assign({}, this.embarqueForm.value);
    this.embarque.detallesEmbarque = new Array();
    this.detallesEmbarque.forEach(detalle => {
      this.embarque.detallesEmbarque.push(detalle);
    });

    this.numeroParteService
      .editEmbarque(+this.route.snapshot.params["id"], this.embarque)
      .subscribe(
        (res: Embarque) => {
          this.alertify.success("Guardado");
          this.router.navigate(["embarques"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  addDetalle() {
    const detalle: DetalleEmbarque = {
      detalleEmbarqueId: 0,
      embarqueId: 0,
      noParte: this.embarqueForm.get("noParte").value,
      cajas: +this.embarqueForm.get("cajas").value,
      piezasXCaja: +this.embarqueForm.get("piezasXCaja").value,
      entregadas: +this.embarqueForm.get("entregadas").value,
      noOrden: +this.embarqueForm.get("noOrden").value
    };

    const cert =
      this.embarqueForm.get("rechazadas").value === "false" ? true : false;

    this.numeroParteService.existenciasAlmacen(detalle.noParte, cert).subscribe(
      (res: number) => {
        if (res >= detalle.entregadas) {
          if (this.detallesEmbarque.indexOf(detalle) < 0) {
            this.detallesEmbarque.push(detalle);
          }

          this.embarqueForm.get("noParte").setValue(null);
          this.embarqueForm.get("cajas").setValue(0);
          this.embarqueForm.get("piezasXCaja").setValue(0);
          this.embarqueForm.get("entregadas").setValue(0);
          this.embarqueForm.get("noOrden").setValue(null);
          this.embarqueForm.get("noOrden2").setValue(null);
        } else {
          this.alertify.error(
            "La canidad solicitada excede las existencias en almacen (" +
              res +
              ")"
          );
        }
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  deleteDetalle(index: number) {
    this.detallesEmbarque.splice(index, 1);
  }

  calculaTotal() {
    const tc = +this.embarqueForm.get("cajas").value;
    const cpc = +this.embarqueForm.get("piezasXCaja").value;

    if (this.isNumber(tc) && this.isNumber(cpc)) {
      this.embarqueForm.get("entregadas").setValue(tc * cpc);
    } else {
      this.embarqueForm.get("entregadas").setValue(0);
    }
  }

  isNumber(value: string | number): boolean {
    return value != null && !isNaN(Number(value.toString()));
  }
}
