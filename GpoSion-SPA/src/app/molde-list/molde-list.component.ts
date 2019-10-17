import { Component, OnInit } from "@angular/core";
import { Molde } from "../_models/molde";
import { MoldeService } from "../_services/molde.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-molde-list",
  templateUrl: "./molde-list.component.html",
  styleUrls: ["./molde-list.component.css"]
})
export class MoldeListComponent implements OnInit {
  moldes: Molde[];

  constructor(
    private moldeService: MoldeService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadMoldes();
  }

  loadMoldes() {
    this.moldeService.getMoldes().subscribe(
      (res: Molde[]) => {
        this.moldes = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
