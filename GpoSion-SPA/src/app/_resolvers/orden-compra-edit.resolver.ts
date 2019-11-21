import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { OrdenCompra } from "../_models/orden-compra";
import { OrdenCompraService } from "../_services/orden-compra.service";

@Injectable()
export class OrdenCompraEditResolver implements Resolve<OrdenCompra> {
  constructor(
    private ordenCompraService: OrdenCompraService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<OrdenCompra> {
    return this.ordenCompraService.getOrdenCompra(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo Orden de Compra");
        this.router.navigate(["/ordenescompra"]);
        return of(null);
      })
    );
  }
}
