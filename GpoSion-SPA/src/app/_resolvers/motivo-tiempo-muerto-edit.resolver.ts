import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { MotivoTiempoMuerto } from "../_models/motivo-tiempo-muerto";
import { MoldeadoraService } from "../_services/moldeadora.service";

@Injectable()
export class MotivoTiempoMuertoEditResolver
  implements Resolve<MotivoTiempoMuerto> {
  constructor(
    private moldeadoraService: MoldeadoraService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<MotivoTiempoMuerto> {
    return this.moldeadoraService
      .getMotivoTiempoMuerto(route.params["id"])
      .pipe(
        catchError(error => {
          this.alertify.error("Problema obteniendo motivo tiempo muerto");
          this.router.navigate(["/motivostiempomuerto"]);
          return of(null);
        })
      );
  }
}
