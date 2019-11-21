import { Component, OnInit } from "@angular/core";
import { OrdenCompraService } from "../_services/orden-compra.service";
import { AlertifyService } from "../_services/alertify.service";
import { OrdenCompra } from "../_models/orden-compra";

@Component({
  selector: "app-orden-compra-list",
  templateUrl: "./orden-compra-list.component.html",
  styleUrls: ["./orden-compra-list.component.css"]
})
export class OrdenCompraListComponent implements OnInit {
  ordenes: OrdenCompra[];
  searchText = "";

  constructor(
    private ordenService: OrdenCompraService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadOrdenes();
  }

  loadOrdenes() {
    this.ordenService.getOrdenesCompra().subscribe(
      res => {
        this.ordenes = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
