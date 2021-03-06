import { Component, OnInit, Input } from "@angular/core";
import { ChartOptions, ChartType, ChartDataSets } from "chart.js";
import { Label } from "ng2-charts";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";
import { Params, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-grafica-embarques",
  templateUrl: "./grafica-embarques.component.html",
  styleUrls: ["./grafica-embarques.component.css"],
})
export class GraficaEmbarquesComponent implements OnInit {
  reporteParams: Params;
  public barChartOptions: ChartOptions = {
    responsive: true,
    // We use these empty structures as placeholders for dynamic theming.
    scales: {
      xAxes: [{}],
      yAxes: [
        {
          ticks: {
            beginAtZero: true,
          },
        },
      ],
    },
    plugins: {
      datalabels: {
        anchor: "end",
        align: "end",
      },
    },
  };
  public barChartLabels: Label[] = [
    "2006",
    "2007",
    "2008",
    "2009",
    "2010",
    "2011",
    "2012",
  ];
  public barChartType: ChartType = "bar";
  public barChartLegend = false;

  public barChartData: ChartDataSets[] = [
    { data: [65, 59, 80, 81, 56, 55, 40], label: "Series A" },
    { data: [28, 48, 40, 19, 86, 27, 90], label: "Series B" },
  ];

  constructor(
    private reportesService: ReportesService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    // this.reporteParams.fechaInicio = new Date(
    //   new Date().getFullYear(),
    //   new Date().getMonth() - 1,
    //   new Date().getDate() + 2
    // ).toDateString();
    // this.reporteParams.fechaFin = new Date(
    //   new Date().getFullYear(),
    //   new Date().getMonth() - 1,
    //   new Date().getDate() + 3
    // ).toDateString();
    this.route.queryParams.subscribe((params) => {
      this.reporteParams = params;
      this.loadData();
    });
  }

  loadData() {
    if (this.reporteParams.hasOwnProperty("fechaInicio")) {
      this.reportesService
        .getReporteEmbarquesPorFecha(this.reporteParams)
        .subscribe(
          (res: any) => {
            this.barChartLabels = res.leyendas;
            this.barChartData = res.datos;
            // this.barChartData = res;
          },
          (error) => {
            this.alertify.error(error);
          }
        );
    } else {
      this.barChartLabels = [];
      this.barChartData = [{ data: [] }];
    }
  }
}
