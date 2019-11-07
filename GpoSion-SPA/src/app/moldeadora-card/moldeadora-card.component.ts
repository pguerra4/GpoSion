import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Moldeadora } from "../_models/moldeadora";
import { environment } from "src/environments/environment";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-moldeadora-card",
  templateUrl: "./moldeadora-card.component.html",
  styleUrls: ["./moldeadora-card.component.css"]
})
export class MoldeadoraCardComponent implements OnInit {
  @Input() moldeadora: Moldeadora;
  @Output("update") update = new EventEmitter();
  numerosParte: string[];
  baseUrl = environment.apiUrl;

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.baseUrl = environment.apiUrl;
  }

  detenerMoldeadora() {
    console.log("naa");
    this.moldeadoraService
      .detenerMoldeadora(this.moldeadora.moldeadoraId)
      .subscribe(
        (res: any) => {
          this.alertify.success("Detenida");
          this.update.emit();
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
  arrancarMoldeadora() {
    this.moldeadoraService
      .arrancarMoldeadora(this.moldeadora.moldeadoraId)
      .subscribe(
        (res: any) => {
          this.alertify.success("Operando");
          this.update.emit();
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
