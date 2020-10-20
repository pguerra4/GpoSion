import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { ChartOptions, ChartType } from "chart.js";
import { Label } from "ng2-charts";
import { AlertifyService } from "../_services/alertify.service";
import { ReportesService } from "../_services/reportes.service";

@Component({
  selector: "app-grafica-recibos-material",
  templateUrl: "./grafica-recibos-material.component.html",
  styleUrls: ["./grafica-recibos-material.component.scss"],
})
export class GraficaRecibosMaterialComponent implements OnInit {
  reporteParams: Params;

  public pieChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: "top",
    },
    plugins: {
      datalabels: {
        formatter: (value, ctx) => {
          const label = ctx.chart.data.labels[ctx.dataIndex];
          return label;
        },
      },
    },
  };

  public pieChartLabels: Label[];
  public pieChartType: ChartType = "pie";
  public pieChartLegend = false;

  public pieChartData: number[] = [
    300,
    300,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    300,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    300,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    300,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    300,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    300,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
    500,
    100,
  ];

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
      this.reportesService
        .getReporteRecibosMaterial(this.reporteParams)
        .subscribe(
          (res: any) => {
            this.pieChartLabels = res.leyendas;
            this.pieChartData = res.datos[0].data;
            // this.barChartData = res;
          },
          (error) => {
            this.alertify.error(error);
          }
        );
    }
  }
}
