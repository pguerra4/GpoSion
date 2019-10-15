import { Component, OnInit } from "@angular/core";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { ExistenciaMaterialGroup } from "../_models/existencia-material-group";

@Component({
  selector: "app-existenciasmaterial-list",
  templateUrl: "./existenciasMaterial-list.component.html",
  styleUrls: ["./existenciasMaterial-list.component.css"]
})
export class ExistenciasMaterialListComponent implements OnInit {
  existencias: ExistenciaMaterialGroup[];
  searchText = "";

  constructor(
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadExistencias();
  }

  loadExistencias() {
    this.existenciasService.getExistenciasMaterial().subscribe(
      (res: ExistenciaMaterialGroup[]) => {
        this.existencias = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
