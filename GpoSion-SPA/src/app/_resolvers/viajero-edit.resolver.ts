import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { Viajero } from "../_models/viajero";

@Injectable()
export class ViajeroEditResolver implements Resolve<Viajero> {
  constructor(
    private existenciasService: ExistenciasMaterialService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Viajero> {
    return this.existenciasService.getViajero(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo viajero");
        this.router.navigate(["/existencias"]);
        return of(null);
      })
    );
  }
}
