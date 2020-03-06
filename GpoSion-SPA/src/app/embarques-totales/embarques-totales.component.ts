import { Component, OnInit, Input } from "@angular/core";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";
import { Params, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-embarques-totales",
  templateUrl: "./embarques-totales.component.html",
  styleUrls: ["./embarques-totales.component.css"]
})
export class EmbarquesTotalesComponent implements OnInit {
  reporteParams: Params;
  totales: any = { embarques: 0, numerosParte: 0, piezasentregadas: 0 };

  constructor(
    private reportesService: ReportesService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.reporteParams = params;
      this.loadData();
    });
  }

  loadData() {
    if (this.reporteParams.hasOwnProperty("fechaInicio")) {
      this.reportesService.getReporteEmbarques(this.reporteParams).subscribe(
        (res: any) => {
          this.totales = res;
        },
        error => {
          this.alertify.error(error);
        }
      );
    }
  }
}
