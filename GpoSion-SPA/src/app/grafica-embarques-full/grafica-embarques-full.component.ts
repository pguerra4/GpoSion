import { Component, OnInit } from "@angular/core";
import { ChartOptions, ChartType, ChartDataSets } from "chart.js";
import { Label } from "ng2-charts";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";
import { NumeroParte } from "../_models/numeroParte";
import { NumeroParteService } from "../_services/numeroParte.service";

@Component({
  selector: "app-grafica-embarques-full",
  templateUrl: "./grafica-embarques-full.component.html",
  styleUrls: ["./grafica-embarques-full.component.css"],
})
export class GraficaEmbarquesFullComponent implements OnInit {
  reporteParams: Params;
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();
  fechaInicio: any;
  fechaFin: any;
  noParte: string;
  numerosParte: NumeroParte[];
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
    legend: {
      position: "bottom",
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
  public barChartLegend = true;

  public barChartData: ChartDataSets[] = [
    { data: [65, 59, 80, 0, 56, 55, 40], label: "Series A" },
    { data: [28, 48, 40, 19, 86, 27, 90], label: "Series B" },
  ];

  constructor(
    private numeroParteService: NumeroParteService,
    private reportesService: ReportesService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private localeService: BsLocaleService,
    private router: Router
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
    this.localeService.use("es");
    this.loadNumerosParte();
    this.route.queryParams.subscribe((params) => {
      this.reporteParams = params;
      this.minDate = new Date(this.reporteParams.fechaInicio);
      this.bsValue = new Date(this.reporteParams.fechaFin);
      this.bsRangeValue = [this.minDate, this.bsValue];
      this.noParte = this.reporteParams.noParte;
      this.loadData();
    });
  }

  loadData() {
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
  }

  onValueChange(value: Date) {
    if (value) {
      this.fechaInicio = value[0].toDateString();
      this.fechaFin = value[1].toDateString();
      this.reporteParams = {
        fechaInicio: value[0].toDateString(),
        fechaFin: value[1].toDateString(),
        noParte: this.noParte,
      };
      this.loadData();
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.reporteParams,
        queryParamsHandling: "merge",
      });
    }
  }

  onSelectNumeroParte($event) {
    if ($event) {
      this.noParte = $event.value;
      this.reporteParams = {
        fechaInicio: this.fechaInicio,
        fechaFin: this.fechaFin,
        noParte: this.noParte,
      };
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.reporteParams,
      });
    }
  }

  noParteChange() {
    this.noParte = null;
    this.reporteParams = {
      fechaInicio: this.fechaInicio,
      fechaFin: this.fechaFin,
    };
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: this.reporteParams,
    });
  }

  loadNumerosParte() {
    this.numeroParteService.getNumerosParte().subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
