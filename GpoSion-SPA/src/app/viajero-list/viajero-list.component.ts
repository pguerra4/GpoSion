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

  constructor(
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadViajeros();
  }

  loadViajeros() {
    this.existenciasService.getViajeros().subscribe(
      (res: Viajero[]) => {
        this.viajeros = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
