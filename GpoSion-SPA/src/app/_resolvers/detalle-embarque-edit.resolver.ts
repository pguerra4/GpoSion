import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { NumeroParteService } from "../_services/numeroParte.service";
import { DetalleEmbarque } from "../_models/detalle-embarque";

@Injectable()
export class DetalleEmbarqueEditResolver implements Resolve<DetalleEmbarque> {
  constructor(
    private noParteService: NumeroParteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<DetalleEmbarque> {
    return this.noParteService.getDetalleEmbarque(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo detalle del embarque");
        this.router.navigate(["/embarques"]);
        return of(null);
      })
    );
  }
}
