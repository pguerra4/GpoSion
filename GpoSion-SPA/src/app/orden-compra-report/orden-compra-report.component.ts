import { Component, OnInit } from "@angular/core";
import { OrdenCompra } from "../_models/orden-compra";
import { AlertifyService } from "../_services/alertify.service";
import { OrdenCompraService } from "../_services/orden-compra.service";

@Component({
  selector: "app-orden-compra-report",
  templateUrl: "./orden-compra-report.component.html",
  styleUrls: ["./orden-compra-report.component.css"],
})
export class OrdenCompraReportComponent implements OnInit {
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
      (res) => {
        this.ordenes = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
