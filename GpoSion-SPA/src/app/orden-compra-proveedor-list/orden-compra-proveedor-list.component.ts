import { Component, OnInit } from "@angular/core";
import { OrdenCompraProveedor } from "../_models/orden-compra-proveedor";
import { OrdenCompraProveedorService } from "../_services/orden-compra-proveedor.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-orden-compra-proveedor-list",
  templateUrl: "./orden-compra-proveedor-list.component.html",
  styleUrls: ["./orden-compra-proveedor-list.component.css"]
})
export class OrdenCompraProveedorListComponent implements OnInit {
  ordenes: OrdenCompraProveedor[];
  searchText = "";

  constructor(
    private ordenCompraProveedorService: OrdenCompraProveedorService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadOrdenes();
  }

  loadOrdenes() {
    this.ordenCompraProveedorService.getOrdenesCompraProveedores().subscribe(
      res => {
        this.ordenes = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
