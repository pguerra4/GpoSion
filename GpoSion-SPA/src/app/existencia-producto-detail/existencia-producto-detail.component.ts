import { Component, OnInit } from "@angular/core";
import { ExistenciaProducto } from "../_models/existencia-producto";
import { LocalidadNumeroParte } from "../_models/localidad-numero-parte";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-existencia-producto-detail",
  templateUrl: "./existencia-producto-detail.component.html",
  styleUrls: ["./existencia-producto-detail.component.css"]
})
export class ExistenciaProductoDetailComponent implements OnInit {
  existencia: ExistenciaProducto;
  localidadesNumeroParte: LocalidadNumeroParte[];

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.existencia = data["existenciaProducto"];
      this.loadLocalidadesNumeroParte();
    });
  }

  loadLocalidadesNumeroParte() {
    this.numeroParteService
      .getLocalidadesNumeroParte(this.existencia.noParte)
      .subscribe(
        (res: LocalidadNumeroParte[]) => {
          this.localidadesNumeroParte = res;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
