import { Component, OnInit, Input } from "@angular/core";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-embarques-totales",
  templateUrl: "./embarques-totales.component.html",
  styleUrls: ["./embarques-totales.component.css"]
})
export class EmbarquesTotalesComponent implements OnInit {
  @Input() reporteParams: any;
  totales: any;

  constructor(
    private reportesService: ReportesService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.reportesService.getReporteEmbarques(this.reporteParams).subscribe(
      (res: any) => {
        this.totales = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
