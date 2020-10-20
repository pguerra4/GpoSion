import { Component, OnInit } from "@angular/core";
import { Params, ActivatedRoute } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { ReportesService } from "../_services/reportes.service";

@Component({
  selector: "app-recibos-totales",
  templateUrl: "./recibos-totales.component.html",
  styleUrls: ["./recibos-totales.component.scss"],
})
export class RecibosTotalesComponent implements OnInit {
  reporteParams: Params;
  totales: any = { recibos: 0, materiales: 0, totalRecibido: 0.0 };

  constructor(
    private reportesService: ReportesService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.reporteParams = params;
      this.loadData();
    });
  }

  loadData() {
    if (this.reporteParams.hasOwnProperty("fechaInicio")) {
      this.reportesService.getReporteRecibos(this.reporteParams).subscribe(
        (res: any) => {
          this.totales = res;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
    }
  }
}
