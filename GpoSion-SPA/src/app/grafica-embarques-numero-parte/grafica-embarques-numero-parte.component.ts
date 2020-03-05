import { Component, OnInit, Input } from "@angular/core";
import { ChartOptions, ChartType, ChartDataSets } from "chart.js";
import { Label } from "ng2-charts";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-grafica-embarques-numero-parte",
  templateUrl: "./grafica-embarques-numero-parte.component.html",
  styleUrls: ["./grafica-embarques-numero-parte.component.css"]
})
export class GraficaEmbarquesNumeroParteComponent implements OnInit {
  @Input() reporteParams: any;

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
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
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
