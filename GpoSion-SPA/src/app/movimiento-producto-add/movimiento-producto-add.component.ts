import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { BsDatepickerConfig } from "ngx-bootstrap";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { UnidadMedida } from "../_models/unidadMedida";
import { NumeroParteService } from "../_services/numeroParte.service";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";
import { NumeroParte } from "../_models/numeroParte";

@Component({
  selector: "app-movimiento-producto-add",
  templateUrl: "./movimiento-producto-add.component.html",
  styleUrls: ["./movimiento-producto-add.component.css"]
})
export class MovimientoProductoAddComponent implements OnInit {
  movimientoForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  movimiento: MovimientoProducto;
  unidadesMedida: UnidadMedida[];
  numerosParte: NumeroParte[];

  constructor(
    private numeroParteService: NumeroParteService,
    private unidadMedidaService: UnidadMedidaService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    (this.bsConfig = {
      containerClass: "theme-orange"
    }),
      this.loadUnidadesMedida();
    this.createMovimientoForm();
    this.loadNumerosParte();
  }

  createMovimientoForm() {
    const now = new Date();
    this.movimientoForm = this.fb.group(
      {
        noParte: ["", Validators.required],
        fecha: [now],
        cajas: [0],
        piezasXCaja: [0],
        piezasCertificadas: [0],
        piezasRechazadas: [0],
        unidadMedidaIdRechazadas: [3],
        purga: [0],
        colada: [0],
        localidad: [""]
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
  addMovimiento() {
    this.movimiento = Object.assign({}, this.movimientoForm.value);
    this.numeroParteService.addMovimientoProducto(this.movimiento).subscribe(
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
