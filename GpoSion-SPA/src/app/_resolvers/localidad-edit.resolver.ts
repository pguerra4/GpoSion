import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { Localidad } from "../_models/localidad";
import { ReciboService } from "../_services/recibo.service";

@Injectable()
export class LocalidadEditResolver implements Resolve<Localidad> {
  constructor(
    private reciboService: ReciboService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Localidad> {
    return this.reciboService.getLocalidad(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo localidad");
        this.router.navigate(["/localidades"]);
        return of(null);
      })
    );
  }
}
