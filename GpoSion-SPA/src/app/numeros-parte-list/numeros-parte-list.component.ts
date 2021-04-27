import { Component, OnInit } from "@angular/core";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { NumeroParte } from "../_models/numeroParte";

@Component({
  selector: "app-numeros-parte-list",
  templateUrl: "./numeros-parte-list.component.html",
  styleUrls: ["./numeros-parte-list.component.css"],
})
export class NumerosParteListComponent implements OnInit {
  numerosParte: NumeroParte[];
  searchText = "";

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadNumerosParte();
  }

  loadNumerosParte() {
    this.numeroParteService.getNumerosParte().subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  deleteNumeroParte(id: string) {
    this.alertify.confirm("¿Desea borrar el número de parte?", () => {
      this.numeroParteService.deleteNumeroParte(id).subscribe(
        () => {
          this.numerosParte.splice(
            this.numerosParte.findIndex((m) => m.noParte === id),
            1
          );
          this.loadNumerosParte();
          this.alertify.success("Número de parte borrado");
        },
        (error) => {
          this.alertify.error("Fallo al borrar el número de parte:" + error);
        }
      );
    });
  }
}
