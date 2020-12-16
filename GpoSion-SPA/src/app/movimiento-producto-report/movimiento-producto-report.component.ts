import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { NumeroParte } from "../_models/numeroParte";
import { AlertifyService } from "../_services/alertify.service";
import { NumeroParteService } from "../_services/numeroParte.service";

@Component({
  selector: "app-movimiento-producto-report",
  templateUrl: "./movimiento-producto-report.component.html",
  styleUrls: ["./movimiento-producto-report.component.css"],
})
export class MovimientoProductoReportComponent implements OnInit {
  movimientos: MovimientoProducto[];
  movimientoParams: any = {};
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();
  fechaInicio: any;
  fechaFin: any;
  noParte: string;
  numerosParte: NumeroParte[];

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private localeService: BsLocaleService,
    private router: Router
  ) {
    this.minDate.setDate(this.minDate.getDate() - 7);
    this.bsValue.setDate(this.bsValue.getDate() + 1);
    this.bsRangeValue = [this.minDate, this.bsValue];
  }

  ngOnInit() {
    this.localeService.use("es");
    this.loadNumerosParte();
    this.route.queryParams.subscribe((params) => {
      if (params.hasOwnProperty("fechaInicio")) {
        this.movimientoParams = params;
        this.minDate = new Date(this.movimientoParams.fechaInicio);
        this.bsValue = new Date(this.movimientoParams.fechaFin);
        this.bsRangeValue = [this.minDate, this.bsValue];
        this.noParte = this.movimientoParams.noParte;
      }

      this.loadMovimientos();
    });
  }
  loadNumerosParte() {
    this.numeroParteService.getNumerosParte().subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  onValueChange(value: Date) {
    if (value) {
      this.fechaInicio = value[0].toDateString();
      this.fechaFin = value[1].toDateString();
      this.movimientoParams = {
        fechaInicio: value[0].toDateString(),
        fechaFin: value[1].toDateString(),
        noParte: this.noParte,
      };
      this.loadMovimientos();
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.movimientoParams,
        queryParamsHandling: "merge",
      });
    }
  }

  onSelectNumeroParte($event) {
    if ($event) {
      this.noParte = $event.value;
      this.movimientoParams = {
        fechaInicio: this.fechaInicio,
        fechaFin: this.fechaFin,
        noParte: this.noParte,
      };
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.movimientoParams,
      });
    }
  }

  noParteChange() {
    this.noParte = null;
    this.movimientoParams = {
      fechaInicio: this.fechaInicio,
      fechaFin: this.fechaFin,
    };
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: this.movimientoParams,
    });
  }

  loadMovimientos() {
    this.numeroParteService
      .getMovimientosProducto(this.movimientoParams)
      .subscribe(
        (res) => {
          this.movimientos = res;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }
}
