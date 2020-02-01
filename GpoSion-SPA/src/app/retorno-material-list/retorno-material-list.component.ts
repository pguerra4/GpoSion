import { Component, OnInit } from "@angular/core";
import { MovimientoMaterial } from "../_models/movimientoMaterial";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsLocaleService } from "ngx-bootstrap";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";

@Component({
  selector: "app-retorno-material-list",
  templateUrl: "./retorno-material-list.component.html",
  styleUrls: ["./retorno-material-list.component.css"]
})
export class RetornoMaterialListComponent implements OnInit {
  retornos: MovimientoMaterial[];
  searchText = "";
  retornoParams: any = {};
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();

  constructor(
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private localeService: BsLocaleService
  ) {
    this.minDate.setDate(this.minDate.getDate() - 7);
    this.bsValue.setDate(this.bsValue.getDate() + 1);
    this.bsRangeValue = [this.minDate, this.bsValue];
  }

  ngOnInit() {
    this.localeService.use("es");
    this.retornoParams.fechaInicio = new Date().toDateString();
    this.retornoParams.fechaFin = new Date().toDateString();
    this.loadRetornos();
  }

  loadRetornos() {
    this.existenciasService.getRetornosMaterial(this.retornoParams).subscribe(
      (res: MovimientoMaterial[]) => {
        this.retornos = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  onValueChange(value: Date[]) {
    this.retornoParams.fechaInicio = value[0].toDateString();
    this.retornoParams.fechaFin = value[1].toDateString();
    this.loadRetornos();
  }
}
