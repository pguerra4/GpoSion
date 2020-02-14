import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { NumeroParteService } from "../_services/numeroParte.service";
import { ExistenciaProducto } from "../_models/existencia-producto";

@Injectable()
export class ExistenciaProductoDetailResolver
  implements Resolve<ExistenciaProducto> {
  constructor(
    private numeroParteService: NumeroParteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<ExistenciaProducto> {
    return this.numeroParteService
      .getExistenciaProducto(route.params["id"])
      .pipe(
        catchError(error => {
          this.alertify.error("Problema obteniendo existencia del producto");
          this.router.navigate(["/existenciasproducto"]);
          return of(null);
        })
      );
  }
}
