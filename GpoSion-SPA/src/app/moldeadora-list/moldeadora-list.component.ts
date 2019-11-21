import { Component, OnInit, TemplateRef } from "@angular/core";
import { Moldeadora } from "../_models/moldeadora";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-moldeadora-list",
  templateUrl: "./moldeadora-list.component.html",
  styleUrls: ["./moldeadora-list.component.css"]
})
export class MoldeadoraListComponent implements OnInit {
  moldeadoras: Moldeadora[];

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadMoldeadoras();
  }

  loadMoldeadoras() {
    this.moldeadoraService.getMoldeadoras().subscribe(
      (res: Moldeadora[]) => {
        this.moldeadoras = res;
      },
      error => this.alertify.error(error)
    );
  }
}
