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
}
