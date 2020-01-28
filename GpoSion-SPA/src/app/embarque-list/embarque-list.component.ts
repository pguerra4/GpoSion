import { Component, OnInit } from "@angular/core";
import { Embarque } from "../_models/embarque";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsLocaleService } from "ngx-bootstrap";

@Component({
  selector: "app-embarque-list",
  templateUrl: "./embarque-list.component.html",
  styleUrls: ["./embarque-list.component.css"]
})
export class EmbarqueListComponent implements OnInit {
  embarques: Embarque[];
  searchText = "";
  embarqueParams: any = {};
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private localeService: BsLocaleService
  ) {
    this.minDate.setDate(this.minDate.getDate() - 7);
    this.bsValue.setDate(this.bsValue.getDate() + 1);
    this.bsRangeValue = [this.minDate, this.bsValue];
  }

  ngOnInit() {
    this.localeService.use("es");
    this.embarqueParams.fechaInicio = new Date().toDateString();
    this.embarqueParams.fechaFin = new Date().toDateString();
    this.loadEmbarques();
  }

  loadEmbarques() {
    this.numeroParteService.getEmbarques(this.embarqueParams).subscribe(
      res => {
        this.embarques = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
  onValueChange(value: Date) {
    this.embarqueParams.fechaInicio = value[0].toDateString();
    this.embarqueParams.fechaFin = value[1].toDateString();
    this.loadEmbarques();
  }
}
