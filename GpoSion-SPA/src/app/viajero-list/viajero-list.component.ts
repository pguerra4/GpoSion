import { Component, OnInit } from "@angular/core";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { Viajero } from "../_models/viajero";

@Component({
  selector: "app-viajero-list",
  templateUrl: "./viajero-list.component.html",
  styleUrls: ["./viajero-list.component.css"]
})
export class ViajeroListComponent implements OnInit {
  viajeros: Viajero[];
  searchText = "";
  viajeroParams: any = {};
  historico = false;

  constructor(
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.viajeroParams.mostrarHistorico = this.historico;
    this.loadViajeros();
  }

  loadViajeros() {
    this.existenciasService.getViajeros(this.viajeroParams).subscribe(
      (res: Viajero[]) => {
        this.viajeros = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  historicoChange() {
    this.viajeroParams.mostrarHistorico = this.historico;
    this.loadViajeros();
  }
}
