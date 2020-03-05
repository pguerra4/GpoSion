import { Component, OnInit, Input } from "@angular/core";
import { ReportesService } from "../_services/reportes.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-embarques-top10",
  templateUrl: "./embarques-top10.component.html",
  styleUrls: ["./embarques-top10.component.css"]
})
export class EmbarquesTop10Component implements OnInit {
  @Input() reporteParams: any;
  numerosParte: any;

  constructor(
    private reportesService: ReportesService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.reportesService.getReporteEmbarquesTop10(this.reporteParams).subscribe(
      (res: any) => {
        this.numerosParte = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
