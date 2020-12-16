import { Component, OnInit } from "@angular/core";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsLocaleService } from "ngx-bootstrap";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-movimiento-producto-list",
  templateUrl: "./movimiento-producto-list.component.html",
  styleUrls: ["./movimiento-producto-list.component.css"],
})
export class MovimientoProductoListComponent implements OnInit {
  movimientos: MovimientoProducto[];
  searchText = "";
  movimientoParams: any = {};
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private localeService: BsLocaleService
  ) {
    this.minDate.setDate(this.minDate.getDate() - 7);
    this.bsValue.setDate(this.bsValue.getDate() + 1);
    this.bsRangeValue = [this.minDate, this.bsValue];
  }

  ngOnInit() {
    this.localeService.use("es");

    this.route.data.subscribe((data) => {
      // tslint:disable-next-line: no-string-literal
      this.movimientos = data["movimientosProducto"];
    });
    this.movimientoParams.tipoMovimiento = "Entrada Almacen";
    this.movimientoParams.fechaInicio = new Date().toDateString();
    this.movimientoParams.fechaFin = new Date().toDateString();
    // this.loadMovimientos();
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

  onValueChange(value: Date) {
    if (value) {
      this.movimientoParams.tipoMovimiento = "Entrada Almacen";
      this.movimientoParams.fechaInicio = value[0].toDateString();
      this.movimientoParams.fechaFin = value[1].toDateString();
      this.loadMovimientos();
    }
  }
}
