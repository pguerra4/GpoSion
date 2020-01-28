import { Component, OnInit } from "@angular/core";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";
import { RequerimientoMaterialService } from "../_services/requerimientoMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsLocaleService } from "ngx-bootstrap";

@Component({
  selector: "app-requerimiento-prod-list",
  templateUrl: "./requerimiento-prod-list.component.html",
  styleUrls: ["./requerimiento-prod-list.component.css"]
})
export class RequerimientoProdListComponent implements OnInit {
  requerimientos: RequerimientoMaterial[];
  searchText = "";
  requerimientosParams: any = {};
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();
  surtidos = false;

  constructor(
    private requerimientoMaterialService: RequerimientoMaterialService,
    private alertify: AlertifyService,
    private localeService: BsLocaleService
  ) {
    this.minDate.setDate(this.minDate.getDate() - 7);
    this.bsValue.setDate(this.bsValue.getDate() + 1);
    this.bsRangeValue = [this.minDate, this.bsValue];
  }

  ngOnInit() {
    this.localeService.use("es");
    this.requerimientosParams.fechaInicio = new Date().toDateString();
    this.requerimientosParams.fechaFin = new Date().toDateString();
    this.requerimientosParams.mostrarSurtidos = this.surtidos;
    this.loadRequerimientos();
  }

  loadRequerimientos() {
    this.requerimientoMaterialService
      .getRequerimientos(this.requerimientosParams)
      .subscribe(
        (res: RequerimientoMaterial[]) => {
          this.requerimientos = res;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  onValueChange(value: Date[]) {
    this.requerimientosParams.fechaInicio = value[0].toDateString();
    this.requerimientosParams.fechaFin = value[1].toDateString();
    this.loadRequerimientos();
  }

  surtidosChange() {
    this.requerimientosParams.mostrarSurtidos = this.surtidos;
    this.loadRequerimientos();
  }
}
