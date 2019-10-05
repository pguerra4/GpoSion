import { Component, OnInit } from "@angular/core";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute } from "@angular/router";
import { Viajero } from "../_models/viajero";

@Component({
  selector: "app-material-viajeros-list",
  templateUrl: "./material-viajeros-list.component.html",
  styleUrls: ["./material-viajeros-list.component.css"]
})
export class MaterialViajerosListComponent implements OnInit {
  viajeros: Viajero[];

  constructor(
    private existenciasMaterialService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadViajeros();
  }

  loadViajeros() {
    this.existenciasMaterialService
      .getViajerosPorMaterial(+this.route.snapshot.params["id"])
      .subscribe(
        (viajeros: Viajero[]) => {
          this.viajeros = viajeros;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
