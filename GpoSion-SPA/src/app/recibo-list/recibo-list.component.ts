import { Component, OnInit } from "@angular/core";
import { ReciboService } from "../_services/recibo.service";
import { Recibo } from "../_models/recibo";

@Component({
  selector: "app-recibo-list",
  templateUrl: "./recibo-list.component.html",
  styleUrls: ["./recibo-list.component.css"]
})
export class ReciboListComponent implements OnInit {
  recibos: Recibo[];

  constructor(private reciboService: ReciboService) {}

  ngOnInit() {
    this.loadRecibos();
  }

  loadRecibos() {
    this.reciboService.getRecibos().subscribe(
      (res: Recibo[]) => {
        this.recibos = res;
        console.log("Cargados");
      },
      error => {
        console.log(error);
      }
    );
  }
}
