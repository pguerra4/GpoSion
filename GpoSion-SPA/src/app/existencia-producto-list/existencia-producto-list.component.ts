import { Component, OnInit } from "@angular/core";
import { ExistenciaProducto } from "../_models/existencia-producto";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { LocalidadNumeroParte } from "../_models/localidad-numero-parte";

@Component({
  selector: "app-existencia-producto-list",
  templateUrl: "./existencia-producto-list.component.html",
  styleUrls: ["./existencia-producto-list.component.css"]
})
export class ExistenciaProductoListComponent implements OnInit {
  existencias: ExistenciaProducto[];
  searchText = "";

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadExistenciasProducto();
  }

  loadExistenciasProducto() {
    this.numeroParteService.getExistenciasProducto().subscribe(
      (res: ExistenciaProducto[]) => {
        this.existencias = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  comparaExistencias(em: ExistenciaProducto): boolean {
    let suma = 0;
    if (em.localidades.length > 0) {
      suma = em.localidades.map(lnp => lnp.existencia).reduce((a, b) => a + b);
    }

    return suma !== em.piezasCertificadas;
  }
}
