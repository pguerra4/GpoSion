import { Component, OnInit } from "@angular/core";
import { Molde } from "../_models/molde";
import { MoldeService } from "../_services/molde.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-molde-detail",
  templateUrl: "./molde-detail.component.html",
  styleUrls: ["./molde-detail.component.css"]
})
export class MoldeDetailComponent implements OnInit {
  molde: Molde;

  constructor(
    private moldeService: MoldeService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.molde = data["molde"];
    });
  }
}
