import { Component, OnInit } from "@angular/core";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { Material } from "../_models/material";

@Component({
  selector: "app-material-list",
  templateUrl: "./material-list.component.html",
  styleUrls: ["./material-list.component.css"]
})
export class MaterialListComponent implements OnInit {
  materiales: Material[];
  searchText = "";

  constructor(
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadMateriales();
  }

  loadMateriales() {
    this.existenciasService.getMateriales().subscribe(
      res => {
        this.materiales = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  deleteMaterial(id: number) {
    this.alertify.confirm("¿Desea borrar el material?", () => {
      this.existenciasService.deleteMaterial(id).subscribe(
        () => {
          this.materiales.splice(
            this.materiales.findIndex(m => m.materialId === id),
            1
          );
          this.loadMateriales();
          this.alertify.success("Material borrado");
        },
        error => {
          this.alertify.error("Fallo al borrar el material:" + error);
        }
      );
    });
  }
}
