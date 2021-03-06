import { Component, OnInit, ViewChild } from "@angular/core";
import { BsLocaleService } from "ngx-bootstrap";
import { GraficaEmbarquesComponent } from "../grafica-embarques/grafica-embarques.component";
import { GraficaEmbarquesNumeroParteComponent } from "../grafica-embarques-numero-parte/grafica-embarques-numero-parte.component";
import { EmbarquesTotalesComponent } from "../embarques-totales/embarques-totales.component";
import { EmbarquesTop10Component } from "../embarques-top10/embarques-top10.component";
import { Params, ActivatedRoute, Router } from "@angular/router";
import { NumeroParte } from "../_models/numeroParte";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { compileNgModule } from "@angular/compiler";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.css"],
})
export class DashboardComponent implements OnInit {
  @ViewChild("graficaEmbarques", { static: true })
  graficaEmbarques: GraficaEmbarquesComponent;
  @ViewChild("graficaEmbarquesNP", { static: true })
  graficaEmbarquesNP: GraficaEmbarquesNumeroParteComponent;
  @ViewChild("EmbarquesT", { static: true })
  embarquesT: EmbarquesTotalesComponent;
  @ViewChild("EmbarquesTop10", { static: true })
  embarquesTop10: EmbarquesTop10Component;

  reporteParams: Params;
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();
  fechaInicio: any;
  fechaFin: any;
  noParte: string;
  numerosParte: NumeroParte[];

  constructor(
    private numeroParteService: NumeroParteService,
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
    this.loadNumerosParte();
    this.route.queryParams.subscribe((params) => {
      if (params.hasOwnProperty("fechaInicio")) {
        this.reporteParams = params;
        this.minDate = new Date(this.reporteParams.fechaInicio);
        this.bsValue = new Date(this.reporteParams.fechaFin);
        this.bsRangeValue = [this.minDate, this.bsValue];
        this.noParte = this.reporteParams.noParte;
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
        noParte: this.noParte,
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
