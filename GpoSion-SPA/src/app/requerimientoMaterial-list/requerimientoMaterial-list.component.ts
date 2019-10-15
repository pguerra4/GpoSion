import { Component, OnInit } from "@angular/core";
import { RequerimientoMaterialService } from "../_services/requerimientoMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";

@Component({
  selector: "app-requerimientoMaterial-list",
  templateUrl: "./requerimientoMaterial-list.component.html",
  styleUrls: ["./requerimientoMaterial-list.component.css"]
})
export class RequerimientoMaterialListComponent implements OnInit {
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
