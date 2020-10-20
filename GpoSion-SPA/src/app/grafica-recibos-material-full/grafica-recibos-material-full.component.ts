import { Component, OnInit } from "@angular/core";
import { Params, ActivatedRoute, Router } from "@angular/router";
import { ChartOptions, ChartType } from "chart.js";
import { Label } from "ng2-charts";
import { BsLocaleService } from "ngx-bootstrap";
import { Material } from "../_models/material";
import { AlertifyService } from "../_services/alertify.service";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { ReportesService } from "../_services/reportes.service";

@Component({
  selector: "app-grafica-recibos-material-full",
  templateUrl: "./grafica-recibos-material-full.component.html",
  styleUrls: ["./grafica-recibos-material-full.component.scss"],
})
export class GraficaRecibosMaterialFullComponent implements OnInit {
  reporteParams: Params;
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();
  fechaInicio: any;
  fechaFin: any;
  materialId: number;
  material: string;
  materiales: Material[];

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
    private materialService: ExistenciasMaterialService,
    private reportesService: ReportesService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private localeService: BsLocaleService,
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

        if (this.materialId != null) {
          this.material = this.materiales.find(
            (m) => m.materialId == this.materialId
          ).material;
        }
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
