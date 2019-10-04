import { Component, OnInit } from "@angular/core";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute } from "@angular/router";
import { Viajero } from "../_models/viajero";

@Component({
  selector: "app-viajero-detail",
  templateUrl: "./viajero-detail.component.html",
  styleUrls: ["./viajero-detail.component.css"]
})
export class ViajeroDetailComponent implements OnInit {
  viajero: Viajero;

  constructor(
    private existenciasMaterialService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadViajero();
  }

  loadViajero() {
    this.existenciasMaterialService
      .getViajero(+this.route.snapshot.params["id"])
      .subscribe(
        (viajero: Viajero) => {
          this.viajero = viajero;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
