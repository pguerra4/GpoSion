import { Component, OnInit } from "@angular/core";
import { Localidad } from "../_models/localidad";
import { ReciboService } from "../_services/recibo.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-localidad-list",
  templateUrl: "./localidad-list.component.html",
  styleUrls: ["./localidad-list.component.css"]
})
export class LocalidadListComponent implements OnInit {
  localidades: Localidad[];

  constructor(
    private reciboService: ReciboService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadLocalidades();
  }

  loadLocalidades() {
    this.reciboService.getLocalidades().subscribe(
      res => {
        this.localidades = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  deleteLocalidad(id: number) {
    this.alertify.confirm("¿Desea borrar la localidad?", () => {
      this.reciboService.deleteLocalidad(id).subscribe(
        () => {
          this.localidades.splice(
            this.localidades.findIndex(m => m.localidadId === id),
            1
          );
          this.loadLocalidades();
          this.alertify.success("Localidad borrada");
        },
        error => {
          this.alertify.error("Fallo al borrar la localidad:" + error);
        }
      );
    });
  }
}
