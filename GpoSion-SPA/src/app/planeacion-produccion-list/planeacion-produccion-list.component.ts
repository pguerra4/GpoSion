import { Component, OnInit } from "@angular/core";
import { PlaneacionProduccion } from "../_models/planeacion-produccion";
import { ProduccionService } from "../_services/produccion.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsLocaleService } from "ngx-bootstrap";
import { DatePipe } from "@angular/common";

@Component({
  selector: "app-planeacion-produccion-list",
  templateUrl: "./planeacion-produccion-list.component.html",
  styleUrls: ["./planeacion-produccion-list.component.css"]
})
export class PlaneacionProduccionListComponent implements OnInit {
  planeaciones: PlaneacionProduccion[];
  searchText = "";
  planeacionesParams: any = {};
  bsValue = new Date();

  constructor(
    private produccionService: ProduccionService,
    private alertify: AlertifyService,
    private datePipe: DatePipe,
    private localeService: BsLocaleService
  ) {
    this.bsValue.setDate(this.bsValue.getDate());
  }

  ngOnInit() {
    this.localeService.use("es");
    this.planeacionesParams.año = new Date().getFullYear();
    // this.planeacionesParams.semana = new Date().getWeek();
  }

  loadPlaneaciones() {
    this.produccionService.getPlaneaciones(this.planeacionesParams).subscribe(
      res => {
        this.planeaciones = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
  onValueChange(value: Date) {
    if (value) {
      this.planeacionesParams.semana = this.datePipe.transform(value, "w");
      this.planeacionesParams.año = value.getFullYear();

      this.loadPlaneaciones();
    }
  }
}
