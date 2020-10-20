import { Component, OnInit } from "@angular/core";
import { Params, ActivatedRoute, Router } from "@angular/router";
import { ChartOptions, ChartType, ChartDataSets } from "chart.js";
import { Label } from "ng2-charts";
import { BsLocaleService } from "ngx-bootstrap";
import { Material } from "../_models/material";
import { AlertifyService } from "../_services/alertify.service";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { ReportesService } from "../_services/reportes.service";

@Component({
  selector: "app-grafica-recibos-full",
  templateUrl: "./grafica-recibos-full.component.html",
  styleUrls: ["./grafica-recibos-full.component.scss"],
})
export class GraficaRecibosFullComponent implements OnInit {
  reporteParams: Params;
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();
  fechaInicio: any;
  fechaFin: any;
  materialId: number;
  material: string;
  materiales: Material[];

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
    private materialService: ExistenciasMaterialService,
    private reportesService: ReportesService,
    private alertify: AlertifyService,
    private localeService: BsLocaleService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.localeService.use("es");
    this.loadMateriales();
    this.route.queryParams.subscribe((params) => {
      if (params.hasOwnProperty("fechaInicio")) {
        this.reporteParams = params;
        this.minDate = new Date(this.reporteParams.fechaInicio);
        this.bsValue = new Date(this.reporteParams.fechaFin);
        this.bsRangeValue = [this.minDate, this.bsValue];
        this.materialId = this.reporteParams.materialId;
      }
      this.loadData();
    });
  }

  loadData() {
    if (this.reporteParams.hasOwnProperty("fechaInicio")) {
      this.reportesService
        .getReporteRecibosPorFecha(this.reporteParams)
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

  onValueChange(value: Date) {
    if (value) {
      this.fechaInicio = value[0].toDateString();
      this.fechaFin = value[1].toDateString();
      this.reporteParams = {
        fechaInicio: value[0].toDateString(),
        fechaFin: value[1].toDateString(),
        materialId: this.materialId,
      };
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.reporteParams,
      });
      // this.graficaEmbarques.loadData();
      // this.graficaEmbarquesNP.loadData();
      // this.embarquesT.loadData();
      // this.embarquesTop10.loadData();
    }
  }

  onSelectMaterial($event) {
    if ($event) {
      this.material = $event.value;
      this.materialId = $event.item.materialId;
      this.reporteParams = {
        fechaInicio: this.fechaInicio,
        fechaFin: this.fechaFin,
        materialId: this.materialId,
      };
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.reporteParams,
      });
    }
  }

  materialChange() {
    this.material = null;
    this.reporteParams = {
      fechaInicio: this.fechaInicio,
      fechaFin: this.fechaFin,
    };
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: this.reporteParams,
    });
  }

  loadMateriales() {
    this.materialService.getMateriales().subscribe(
      (res: Material[]) => {
        this.materiales = res;
        this.material = this.materiales.find(
          (m) => m.materialId == this.materialId
        ).material;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
