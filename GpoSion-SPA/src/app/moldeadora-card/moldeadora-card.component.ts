import { Component, OnInit, Input } from "@angular/core";
import { Moldeadora } from "../_models/moldeadora";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-moldeadora-card",
  templateUrl: "./moldeadora-card.component.html",
  styleUrls: ["./moldeadora-card.component.css"]
})
export class MoldeadoraCardComponent implements OnInit {
  @Input() moldeadora: Moldeadora;
  numerosParte: string[];
  baseUrl = environment.apiUrl;

  constructor() {}

  ngOnInit() {
    this.baseUrl = environment.apiUrl;
  }
}
