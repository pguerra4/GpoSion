import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { LocalidadNumeroParte } from "../_models/localidad-numero-parte";
import { NumeroParteService } from "../_services/numeroParte.service";
import { catchError } from "rxjs/operators";

@Injectable()
export class LocalidadNumeroParteEditResolver
  implements Resolve<LocalidadNumeroParte> {
  constructor(
    private numeroParteService: NumeroParteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<LocalidadNumeroParte> {
    return this.numeroParteService
      .getLocalidadNumeroParte(
        route.params["localidadId"],
        route.params["noParte"]
      )
      .pipe(
        catchError(error => {
          this.alertify.error("Problema obteniendo localidad numero de parte");
          this.router.navigate(["/existenciasproducto"]);
          return of(null);
        })
      );
  }
}
