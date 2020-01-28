import { Component, OnInit } from "@angular/core";
import { Moldeadora } from "../_models/moldeadora";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-moldeadora-simple-list",
  templateUrl: "./moldeadora-simple-list.component.html",
  styleUrls: ["./moldeadora-simple-list.component.css"]
})
export class MoldeadoraSimpleListComponent implements OnInit {
  moldeadoras: Moldeadora[];

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadMoldes();
  }

  loadMoldes() {
    this.moldeadoraService.getMoldeadoras().subscribe(
      (res: Moldeadora[]) => {
        this.moldeadoras = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
