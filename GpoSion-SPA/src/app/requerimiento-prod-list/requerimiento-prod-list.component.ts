import { Component, OnInit } from "@angular/core";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";
import { RequerimientoMaterialService } from "../_services/requerimientoMaterial.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-requerimiento-prod-list",
  templateUrl: "./requerimiento-prod-list.component.html",
  styleUrls: ["./requerimiento-prod-list.component.css"]
})
export class RequerimientoProdListComponent implements OnInit {
  requerimientos: RequerimientoMaterial[];
  searchText = "";

  constructor(
    private requerimientoMaterialService: RequerimientoMaterialService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadRequerimientos();
  }

  loadRequerimientos() {
    this.requerimientoMaterialService.getRequerimientos().subscribe(
      (res: RequerimientoMaterial[]) => {
        this.requerimientos = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
