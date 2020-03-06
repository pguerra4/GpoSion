import { Component, OnInit, Input } from "@angular/core";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";
import { Params, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-embarques-top10",
  templateUrl: "./embarques-top10.component.html",
  styleUrls: ["./embarques-top10.component.css"]
})
export class EmbarquesTop10Component implements OnInit {
  reporteParams: Params;
  numerosParte: any;

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
      this.reportesService
        .getReporteEmbarquesTop10(this.reporteParams)
        .subscribe(
          (res: any) => {
            this.numerosParte = res;
          },
          error => {
            this.alertify.error(error);
          }
        );
    }
  }
}
