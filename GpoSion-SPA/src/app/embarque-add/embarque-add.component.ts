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
import { Router } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";
import { ValidateExistingFolioEmbarque } from "../_validators/async-folio-embarque-existente.validator";
import { LocalidadNumeroParte } from "../_models/localidad-numero-parte";

@Component({
  selector: "app-embarque-add",
  templateUrl: "./embarque-add.component.html",
  styleUrls: ["./embarque-add.component.css"],
})
export class EmbarqueAddComponent implements OnInit {
  embarqueForm: FormGroup;
  embarque: Embarque;
  detallesEmbarque: DetalleEmbarque[] = new Array();
  localidadesNumeroParte: LocalidadNumeroParte[];
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
    private localeService: BsLocaleService
  ) {}

  ngOnInit() {
    this.localeService.use("es");
    this.loadClientes();
    this.createEmbarqueForm();
  }

  createEmbarqueForm() {
    const now = new Date();
    this.embarqueForm = this.fb.group(
      {
        clienteId: [null, Validators.required],
        folio: [
          null,
          Validators.required,
          ValidateExistingFolioEmbarque.createValidator(
            this.numeroParteService
          ),
        ],
        fecha: [now],
        leNo: [""],
        rechazadas: [false],
        noParte: [""],
        noOrden: [""],
        noOrden2: [""],
        localidadId: [null],
        cajas: [0],
        piezasXCaja: [0],
        entregadas: [0],
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

  clienteChange(clienteId: number) {
    this.embarqueForm.get("noParte").setValue("");
    this.npParams.clienteId = clienteId;
    this.numeroParteService.getNumerosParte(this.npParams).subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  onSelectNumeroParte(np: any) {
    if (np) {
      this.loadOrdenesCompra(np.value);
      this.loadLocalidades(np.value);
    }
  }

  onSelectNoOrden(po: any) {
    if (po) {
      this.embarqueForm.get("noOrden2").setValue(po.value);
    }
  }

  loadOrdenesCompra(noParte: string) {
    this.embarqueForm.get("noOrden").setValue(null);
    this.embarqueForm.get("noOrden2").setValue(null);
    this.ordenesCompra = null;
    this.ordenCompraService
      .getOrdenesCompraAbiertasXNumroParte(noParte)
      .subscribe(
        (res: OrdenCompra[]) => {
          this.ordenesCompra = res;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }

  loadLocalidades(noParte: string) {
    this.localidadesNumeroParte = null;
    this.numeroParteService.getLocalidadesNumeroParte(noParte).subscribe(
      (res: LocalidadNumeroParte[]) => {
        this.localidadesNumeroParte = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  addEmbarque() {
    this.embarque = Object.assign({}, this.embarqueForm.value);
    this.embarque.detallesEmbarque = new Array();
    this.detallesEmbarque.forEach((detalle) => {
      this.embarque.detallesEmbarque.push(detalle);
    });

    this.numeroParteService.addEmbarque(this.embarque).subscribe(
      (res: Embarque) => {
        this.alertify.success("Guardado");
        this.router.navigate(["embarques"]);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  addDetalle() {
    const localidad = this.localidadesNumeroParte.find(
      (l) => l.localidadId === +this.embarqueForm.get("localidadId").value
    );

    console.log();

    if (
      !this.embarqueForm.get("rechazadas").value &&
      localidad.existencia < +this.embarqueForm.get("entregadas").value
    ) {
      this.alertify.error(
        "La canidad solicitada excede las existencias en la localidad (" +
          localidad.existencia +
          ")"
      );
    } else if (
      this.embarqueForm.get("rechazadas").value &&
      localidad.rechazadas < +this.embarqueForm.get("entregadas").value
    ) {
      this.alertify.error(
        "La canidad solicitada excede las rechazadas en la localidad (" +
          localidad.rechazadas +
          ")"
      );
    } else {
      const detalle: DetalleEmbarque = {
        detalleEmbarqueId: 0,
        embarqueId: 0,
        noParte: this.embarqueForm.get("noParte").value,
        cajas: +this.embarqueForm.get("cajas").value,
        piezasXCaja: +this.embarqueForm.get("piezasXCaja").value,
        entregadas: +this.embarqueForm.get("entregadas").value,
        noOrden: +this.embarqueForm.get("noOrden").value,
        localidadId: +this.embarqueForm.get("localidadId").value,
        localidad: localidad.localidad,
      };

      const cert =
        this.embarqueForm.get("rechazadas").value === "false" ? true : false;

      this.numeroParteService
        .existenciasAlmacen(detalle.noParte, cert)
        .subscribe(
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
              this.embarqueForm.get("localidadId").setValue(null);
            } else {
              this.alertify.error(
                "La canidad solicitada excede las existencias en almacen (" +
                  res +
                  ")"
              );
            }
          },
          (error) => {
            this.alertify.error(error);
          }
        );
    }
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
