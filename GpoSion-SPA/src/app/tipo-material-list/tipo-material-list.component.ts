import { Component, OnInit } from "@angular/core";
import { TipoMaterial } from "../_models/tipo-material";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-tipo-material-list",
  templateUrl: "./tipo-material-list.component.html",
  styleUrls: ["./tipo-material-list.component.css"]
})
export class TipoMaterialListComponent implements OnInit {
  tiposMaterial: TipoMaterial[];

  constructor(
    private existenciasMaterialService: ExistenciasMaterialService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadTiposMaterial();
  }

  loadTiposMaterial() {
    this.existenciasMaterialService.getTiposMaterial().subscribe(
      res => {
        this.tiposMaterial = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
