import { Component, OnInit } from "@angular/core";
import { MotivoTiempoMuerto } from "../_models/motivo-tiempo-muerto";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-motivo-tiempo-muerto-list",
  templateUrl: "./motivo-tiempo-muerto-list.component.html",
  styleUrls: ["./motivo-tiempo-muerto-list.component.css"]
})
export class MotivoTiempoMuertoListComponent implements OnInit {
  motivos: MotivoTiempoMuerto[];

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadMotivos();
  }

  loadMotivos() {
    this.moldeadoraService.getMotivosTiempoMuerto().subscribe(
      res => {
        this.motivos = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
