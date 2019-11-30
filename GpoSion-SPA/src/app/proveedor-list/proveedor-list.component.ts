import { Component, OnInit } from "@angular/core";
import { Proveedor } from "../_models/proveedor";
import { ProveedorService } from "../_services/proveedor.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-proveedor-list",
  templateUrl: "./proveedor-list.component.html",
  styleUrls: ["./proveedor-list.component.css"]
})
export class ProveedorListComponent implements OnInit {
  proveedores: Proveedor[];

  constructor(
    private proveedorService: ProveedorService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadProveedores();
  }

  loadProveedores() {
    this.proveedorService.getProveedores().subscribe(
      res => {
        this.proveedores = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
