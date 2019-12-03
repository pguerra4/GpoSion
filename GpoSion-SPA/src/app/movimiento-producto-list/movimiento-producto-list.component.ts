import { Component, OnInit } from "@angular/core";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-movimiento-producto-list",
  templateUrl: "./movimiento-producto-list.component.html",
  styleUrls: ["./movimiento-producto-list.component.css"]
})
export class MovimientoProductoListComponent implements OnInit {
  movimientos: MovimientoProducto[];
  searchText = "";

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadMovimientos();
  }

  loadMovimientos() {
    this.numeroParteService.getMovimientosProducto().subscribe(
      res => {
        this.movimientos = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
