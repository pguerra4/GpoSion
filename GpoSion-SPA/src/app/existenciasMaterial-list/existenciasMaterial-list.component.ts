import { Component, OnInit } from "@angular/core";
import { ExistenciaMaterial } from "../_models/existenciaMaterial";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import * as alertify from "alertifyjs";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-existenciasmaterial-list",
  templateUrl: "./existenciasMaterial-list.component.html",
  styleUrls: ["./existenciasMaterial-list.component.css"]
})
export class ExistenciasMaterialListComponent implements OnInit {
  existencias: ExistenciaMaterial[];

  constructor(
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadExistencias();
  }

  loadExistencias() {
    this.existenciasService.getExistenciasMaterial().subscribe(
      (res: ExistenciaMaterial[]) => {
        this.existencias = res;
      },
      error => {
        alertify.error(error);
      }
    );
  }
}
