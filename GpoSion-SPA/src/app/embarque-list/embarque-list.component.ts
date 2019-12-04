import { Component, OnInit } from "@angular/core";
import { Embarque } from "../_models/embarque";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsLocaleService } from "ngx-bootstrap";

@Component({
  selector: "app-embarque-list",
  templateUrl: "./embarque-list.component.html",
  styleUrls: ["./embarque-list.component.css"]
})
export class EmbarqueListComponent implements OnInit {
  embarques: Embarque[];
  searchText = "";
  embarqueParams: any = {};
  bsValue = new Date();

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private localeService: BsLocaleService
  ) {}

  ngOnInit() {
    this.localeService.use("es");
    this.embarqueParams.fecha = new Date().toDateString();
    this.loadEmbarques();
  }

  loadEmbarques() {
    this.numeroParteService.getEmbarques(this.embarqueParams).subscribe(
      res => {
        this.embarques = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
  onValueChange(value: Date) {
    this.embarqueParams.fecha = value.toDateString();
    this.loadEmbarques();
  }
}
