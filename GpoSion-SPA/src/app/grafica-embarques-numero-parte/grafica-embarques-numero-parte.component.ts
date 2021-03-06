import { Component, OnInit, Input } from "@angular/core";
import { ChartOptions, ChartType, ChartDataSets } from "chart.js";
import { Label } from "ng2-charts";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";
import { Params, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-grafica-embarques-numero-parte",
  templateUrl: "./grafica-embarques-numero-parte.component.html",
  styleUrls: ["./grafica-embarques-numero-parte.component.css"]
})
export class GraficaEmbarquesNumeroParteComponent implements OnInit {
  reporteParams: Params;

  public pieChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: "top"
    },
    plugins: {
      datalabels: {
        formatter: (value, ctx) => {
          const label = ctx.chart.data.labels[ctx.dataIndex];
          return label;
        }
      }
    }
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
    100
  ];

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
        .getReporteEmbarquesNumeroParte(this.reporteParams)
        .subscribe(
          (res: any) => {
            this.pieChartLabels = res.leyendas;
            this.pieChartData = res.datos[0].data;
            // this.barChartData = res;
          },
          error => {
            this.alertify.error(error);
          }
        );
    }
  }
}
