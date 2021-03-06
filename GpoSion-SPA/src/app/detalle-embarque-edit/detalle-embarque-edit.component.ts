import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { DetalleEmbarque } from "../_models/detalle-embarque";
import { NumeroParte } from "../_models/numeroParte";
import { OrdenCompra } from "../_models/orden-compra";
import { NumeroParteService } from "../_services/numeroParte.service";
import { OrdenCompraService } from "../_services/orden-compra.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";
import { Embarque } from "../_models/embarque";
import { LocalidadNumeroParte } from "../_models/localidad-numero-parte";

@Component({
  selector: "app-detalle-embarque-edit",
  templateUrl: "./detalle-embarque-edit.component.html",
  styleUrls: ["./detalle-embarque-edit.component.css"],
})
export class DetalleEmbarqueEditComponent implements OnInit {
  detalleEmbarqueForm: FormGroup;
  detalleEmbarque: DetalleEmbarque;
  localidadesNumeroParte: LocalidadNumeroParte[];
  embarque: Embarque;
  numerosParte: NumeroParte[];
  ordenesCompra: OrdenCompra[];
  npParams: any = {};

  constructor(
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
    this.route.data.subscribe((data) => {
      // tslint:disable-next-line: no-string-literal
      this.detalleEmbarque = data["detalleEmbarque"];

      this.loadEmbarque();
      this.loadOrdenesCompra(this.detalleEmbarque.noParte);
      this.loadLocalidades(this.detalleEmbarque.noParte);
      this.createDetalleEmbarqueForm();
    });
  }

  createDetalleEmbarqueForm() {
    this.detalleEmbarqueForm = this.fb.group(
      {
        detalleEmbarqueId: [
          this.detalleEmbarque.detalleEmbarqueId,
          Validators.required,
        ],
        embarqueId: [this.detalleEmbarque.embarqueId, Validators.required],
        noParte: [this.detalleEmbarque.noParte, Validators.required],
        noOrden: [
          this.detalleEmbarque.noOrden == undefined
            ? ""
            : this.detalleEmbarque.noOrden.toString(),
        ],
        noOrden2: [this.detalleEmbarque.noOrden],
        localidadId: [this.detalleEmbarque.localidadId],
        cajas: [this.detalleEmbarque.cajas],
        piezasXCaja: [this.detalleEmbarque.piezasXCaja],
        entregadas: [this.detalleEmbarque.entregadas, Validators.required],
      },
      { updateOn: "blur" }
    );
  }

  loadEmbarque() {
    this.numeroParteService
      .getEmbarque(this.detalleEmbarque.embarqueId)
      .subscribe(
        (res: Embarque) => {
          this.embarque = res;
          this.npParams.clienteId = this.embarque.clienteId;
          this.numeroParteService.getNumerosParte(this.npParams).subscribe(
            (res2: NumeroParte[]) => {
              this.numerosParte = res2;
            },
            (error) => {
              this.alertify.error(error);
            }
          );
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }

  onSelectNumeroParte(np: any) {
    if (np) {
      this.detalleEmbarqueForm.get("noOrden").setValue("");
      this.detalleEmbarqueForm.get("noOrden2").setValue(null);
      this.ordenesCompra = null;
      this.loadOrdenesCompra(np.value);
      this.loadLocalidades(np.value);
    }
  }

  onSelectNoOrden(po: any) {
    if (po) {
      this.detalleEmbarqueForm.get("noOrden2").setValue(po.value);
    }
  }

  loadOrdenesCompra(noParte: string) {
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
        const localidad = this.localidadesNumeroParte.find(
          (l) => l.localidadId === +this.detalleEmbarque.localidadId
        );
        if (localidad == undefined) {
          this.localidadesNumeroParte.push({
            localidadId: +this.detalleEmbarque.localidadId,
            localidad: this.detalleEmbarque.localidad,
            noParte: this.detalleEmbarque.noParte,
            existencia: 0,
            rechazadas: 0,
          });
        }
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  editDetalleEmbarque() {
    this.detalleEmbarque = Object.assign({}, this.detalleEmbarqueForm.value);

    this.numeroParteService
      .editDetalleEmbarque(
        +this.route.snapshot.params["id"],
        this.detalleEmbarque
      )
      .subscribe(
        (res: DetalleEmbarque) => {
          this.alertify.success("Guardado");
          this.router.navigate([
            "embarques/" + this.detalleEmbarque.embarqueId,
          ]);
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }

  calculaTotal() {
    const tc = +this.detalleEmbarqueForm.get("cajas").value;
    const cpc = +this.detalleEmbarqueForm.get("piezasXCaja").value;

    if (this.isNumber(tc) && this.isNumber(cpc)) {
      this.detalleEmbarqueForm.get("entregadas").setValue(tc * cpc);
    } else {
      this.detalleEmbarqueForm.get("entregadas").setValue(0);
    }
  }

  isNumber(value: string | number): boolean {
    return value != null && !isNaN(Number(value.toString()));
  }
}
