import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { NumeroParteService } from "../_services/numeroParte.service";

@Injectable()
export class MovimientoProductoEditResolver
  implements Resolve<MovimientoProducto> {
  constructor(
    private numeroParteService: NumeroParteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<MovimientoProducto> {
    return this.numeroParteService
      .getMovimientoProducto(route.params["id"])
      .pipe(
        catchError(error => {
          this.alertify.error("Problema obteniendo movimiento producto");
          this.router.navigate(["/movimientosproducto"]);
          return of(null);
        })
      );
  }
}
