import { Component, OnInit, Input } from "@angular/core";
import { ChartOptions, ChartType } from "chart.js";
import { Label } from "ng2-charts";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute, Router, Params } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";

@Component({
  selector: "app-grafica-embarques-np-full",
  templateUrl: "./grafica-embarques-np-full.component.html",
  styleUrls: ["./grafica-embarques-np-full.component.css"]
})
export class GraficaEmbarquesNpFullComponent implements OnInit {
  reporteParams: Params;
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();

  public pieChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: "bottom"
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
  public pieChartLegend = true;

  public pieChartData: number[] = [
    300,
    300,
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
    private route: ActivatedRoute,
    private localeService: BsLocaleService,
    private router: Router
  ) {}

  ngOnInit() {
    this.localeService.use("es");
    this.route.queryParams.subscribe(params => {
      this.reporteParams = params;
      this.minDate = new Date(this.reporteParams.fechaInicio);
      this.bsValue = new Date(this.reporteParams.fechaFin);
      this.bsRangeValue = [this.minDate, this.bsValue];
      this.loadData();
    });
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

  onValueChange(value: Date) {
    if (value) {
      this.reporteParams = {
        fechaInicio: value[0].toDateString(),
        fechaFin: value[1].toDateString()
      };
      this.loadData();
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.reporteParams,
        queryParamsHandling: "merge"
      });
    }
  }
}
