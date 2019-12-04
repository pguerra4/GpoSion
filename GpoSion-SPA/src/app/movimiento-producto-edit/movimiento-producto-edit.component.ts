import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { UnidadMedida } from "../_models/unidadMedida";
import { NumeroParte } from "../_models/numeroParte";
import { NumeroParteService } from "../_services/numeroParte.service";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";

@Component({
  selector: "app-movimiento-producto-edit",
  templateUrl: "./movimiento-producto-edit.component.html",
  styleUrls: ["./movimiento-producto-edit.component.css"]
})
export class MovimientoProductoEditComponent implements OnInit {
  movimientoForm: FormGroup;
  movimiento: MovimientoProducto;
  unidadesMedida: UnidadMedida[];
  numerosParte: NumeroParte[];

  constructor(
    private numeroParteService: NumeroParteService,
    private unidadMedidaService: UnidadMedidaService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private localeService: BsLocaleService
  ) {}

  ngOnInit() {
    this.localeService.use("es");
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.movimiento = data["movimientoProducto"];
      this.loadUnidadesMedida();
      this.createMovimientoForm();
      this.loadNumerosParte();
    });
  }
  createMovimientoForm() {
    const now = new Date();
    this.movimientoForm = this.fb.group(
      {
        movimientoProductoId: [
          this.movimiento.movimientoProductoId,
          Validators.required
        ],
        noParte: [this.movimiento.noParte, Validators.required],
        fecha: [new Date(this.movimiento.fecha)],
        cajas: [this.movimiento.cajas],
        piezasXCaja: [this.movimiento.piezasXCaja],
        piezasCertificadas: [this.movimiento.piezasCertificadas],
        piezasRechazadas: [this.movimiento.piezasRechazadas],
        unidadMedidaIdRechazadas: [3],
        purga: [this.movimiento.purga],
        colada: [this.movimiento.colada],
        localidad: [this.movimiento.localidad]
      },
      { updateOn: "blur" }
    );
  }

  loadUnidadesMedida() {
    this.unidadMedidaService.getUnidadesMedida().subscribe(
      (res: UnidadMedida[]) => {
        this.unidadesMedida = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  loadNumerosParte() {
    this.numeroParteService.getNumerosParte().subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  editMovimiento() {
    this.movimiento = Object.assign({}, this.movimientoForm.value);
    this.movimiento.fecha = this.movimientoForm
      .get("fecha")
      .value.toDateString();
    this.numeroParteService
      .editMovimientoProducto(
        +this.route.snapshot.params["id"],
        this.movimiento
      )
      .subscribe(
        (res: MovimientoProducto) => {
          this.alertify.success("Guardado");
          this.router.navigate(["movimientosproducto/"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  calculaTotal() {
    const tc = +this.movimientoForm.get("cajas").value;
    const cpc = +this.movimientoForm.get("piezasXCaja").value;

    if (this.isNumber(tc) && this.isNumber(cpc)) {
      this.movimientoForm.get("piezasCertificadas").setValue(tc * cpc);
    } else {
      this.movimientoForm.get("piezasCertificadas").setValue(0);
    }
  }

  isNumber(value: string | number): boolean {
    return value != null && !isNaN(Number(value.toString()));
  }
}
