import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { DetalleRecibo } from "../_models/detalleRecibo";
import { ReciboService } from "../_services/recibo.service";

@Injectable()
export class DetalleReciboEditResolver implements Resolve<DetalleRecibo> {
  constructor(
    private reciboService: ReciboService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<DetalleRecibo> {
    return this.reciboService.getDetalleRecibo(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo información");
        this.router.navigate(["/existencias"]);
        return of(null);
      })
    );
  }
}
