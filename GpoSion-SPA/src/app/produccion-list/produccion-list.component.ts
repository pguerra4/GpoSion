import { Component, OnInit } from "@angular/core";
import { Produccion } from "../_models/produccion";
import { ProduccionService } from "../_services/produccion.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsLocaleService } from "ngx-bootstrap";

@Component({
  selector: "app-produccion-list",
  templateUrl: "./produccion-list.component.html",
  styleUrls: ["./produccion-list.component.css"]
})
export class ProduccionListComponent implements OnInit {
  producciones: Produccion[];
  searchText = "";
  produccionParams: any = {};
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();

  constructor(
    private produccionService: ProduccionService,
    private alertify: AlertifyService,
    private localeService: BsLocaleService
  ) {
    this.minDate.setDate(this.minDate.getDate() - 7);
    this.bsValue.setDate(this.bsValue.getDate() + 1);
    this.bsRangeValue = [this.minDate, this.bsValue];
  }

  ngOnInit() {
    this.localeService.use("es");
    this.produccionParams.fechaInicio = new Date().toDateString();
    this.produccionParams.fechaFin = new Date().toDateString();
    this.loadEmbarques();
  }

  loadEmbarques() {
    this.produccionService.getProducciones(this.produccionParams).subscribe(
      res => {
        this.producciones = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
  onValueChange(value: Date) {
    if (value) {
      this.produccionParams.fechaInicio = value[0].toDateString();
      this.produccionParams.fechaFin = value[1].toDateString();
      this.loadEmbarques();
    }
  }
}
