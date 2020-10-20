import { Component, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";
import { GraficaRecibosMaterialComponent } from "../grafica-recibos-material/grafica-recibos-material.component";
import { GraficaRecibosComponent } from "../grafica-recibos/grafica-recibos.component";
import { RecibosTop10Component } from "../recibos-top10/recibos-top10.component";
import { RecibosTotalesComponent } from "../recibos-totales/recibos-totales.component";
import { Material } from "../_models/material";
import { AlertifyService } from "../_services/alertify.service";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";

@Component({
  selector: "app-dashboard-recibos",
  templateUrl: "./dashboard-recibos.component.html",
  styleUrls: ["./dashboard-recibos.component.scss"],
})
export class DashboardRecibosComponent implements OnInit {
  @ViewChild("graficaRecibos", { static: true })
  graficaRecibos: GraficaRecibosComponent;
  @ViewChild("graficaRecibosMaterial", { static: true })
  graficaEmbarquesNP: GraficaRecibosMaterialComponent;
  @ViewChild("RecibosT", { static: true })
  recibosT: RecibosTotalesComponent;
  @ViewChild("RecibosTop10", { static: true })
  recibosTop10: RecibosTop10Component;

  reporteParams: Params;
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();
  fechaInicio: any;
  fechaFin: any;
  materialId: number;
  material: string;
  materiales: Material[];

  constructor(
    private materialService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private localeService: BsLocaleService,
    private router: Router
  ) {
    this.minDate.setDate(this.minDate.getDate() - 7);
    this.bsValue.setDate(this.bsValue.getDate());
    this.bsRangeValue = [this.minDate, this.bsValue];
  }

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
    });

    // this.reporteParams.fechaInicio = new Date().toDateString();
    // this.reporteParams.fechaFin = new Date().toDateString();
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
