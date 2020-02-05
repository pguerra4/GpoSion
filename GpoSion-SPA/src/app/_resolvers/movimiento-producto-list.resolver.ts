import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { NumeroParteService } from "../_services/numeroParte.service";

@Injectable()
export class MovimientoProductoListResolver
  implements Resolve<MovimientoProducto[]> {
  movimientoParams;

  constructor(
    private numeroParteService: NumeroParteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<MovimientoProducto[]> {
    return this.numeroParteService
      .getMovimientosProducto(this.movimientoParams)
      .pipe(
        catchError(error => {
          this.alertify.error("Problema obteniendo movimientos producto");
          this.router.navigate(["/home"]);
          return of(null);
        })
      );
  }
}
