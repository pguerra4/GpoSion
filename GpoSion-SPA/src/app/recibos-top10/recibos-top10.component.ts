import { Component, OnInit } from "@angular/core";
import { Params, ActivatedRoute } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { ReportesService } from "../_services/reportes.service";

@Component({
  selector: "app-recibos-top10",
  templateUrl: "./recibos-top10.component.html",
  styleUrls: ["./recibos-top10.component.scss"],
})
export class RecibosTop10Component implements OnInit {
  reporteParams: Params;
  materiales: any;

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
      this.reportesService.getReporteRecibosTop10(this.reporteParams).subscribe(
        (res: any) => {
          this.materiales = res;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
    }
  }
}
