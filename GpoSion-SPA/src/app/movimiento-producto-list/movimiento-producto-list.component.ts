import { Component, OnInit } from "@angular/core";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsLocaleService } from "ngx-bootstrap";

@Component({
  selector: "app-movimiento-producto-list",
  templateUrl: "./movimiento-producto-list.component.html",
  styleUrls: ["./movimiento-producto-list.component.css"]
})
export class MovimientoProductoListComponent implements OnInit {
  movimientos: MovimientoProducto[];
  searchText = "";
  movimientoParams: any = {};
  bsValue = new Date();

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private localeService: BsLocaleService
  ) {}

  ngOnInit() {
    this.localeService.use("es");
    this.movimientoParams.tipoMovimiento = "Entrada Almacen";
    this.movimientoParams.fecha = new Date().toDateString();
    this.loadMovimientos();
  }

  loadMovimientos() {
    this.numeroParteService
      .getMovimientosProducto(this.movimientoParams)
      .subscribe(
        res => {
          this.movimientos = res;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
  onValueChange(value: Date) {
    this.movimientoParams.fecha = value.toDateString();
    this.loadMovimientos();
  }
}
