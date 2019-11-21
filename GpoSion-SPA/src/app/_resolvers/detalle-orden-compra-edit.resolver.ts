import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { OrdenCompraService } from "../_services/orden-compra.service";
import { OrdenCompraDetalle } from "../_models/orden-compra-detalle";

@Injectable()
export class DetalleOrdenCompraEditResolver
  implements Resolve<OrdenCompraDetalle> {
  constructor(
    private ordenCompraService: OrdenCompraService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<OrdenCompraDetalle> {
    return this.ordenCompraService
      .getOrdenCompraDetalle(route.params["id"])
      .pipe(
        catchError(error => {
          this.alertify.error("Problema obteniendo Detalle Orden de Compra");
          this.router.navigate(["/ordenescompra"]);
          return of(null);
        })
      );
  }
}
