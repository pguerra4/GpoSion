import { Component, OnInit } from "@angular/core";
import { RequerimientoMaterialService } from "../_services/requerimientoMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-requerimiento-material-prod",
  templateUrl: "./requerimiento-material-prod.component.html",
  styleUrls: ["./requerimiento-material-prod.component.css"]
})
export class RequerimientoMaterialProdComponent implements OnInit {
  requerimiento: RequerimientoMaterial;

  constructor(
    private requerimientoMaterialService: RequerimientoMaterialService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.requerimiento = data["req"];
    });
    // this.loadRequerimiento();
  }

  // loadRequerimiento() {
  //   this.requerimientoMaterialService
  //     .getRequerimiento(+this.route.snapshot.params["id"])
  //     .subscribe(
  //       (req: RequerimientoMaterial) => {
  //         this.requerimiento = req;
  //       },
  //       error => {
  //         this.alertify.error(error);
  //       }
  //     );
  // }
}
