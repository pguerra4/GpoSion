import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { MoldeService } from "../_services/molde.service";
import { EstatusMolde } from "../_models/estatus-molde";

@Injectable()
export class EstatusMoldeEditResolver implements Resolve<EstatusMolde> {
  constructor(
    private moldeService: MoldeService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<EstatusMolde> {
    return this.moldeService.getEstatusMolde(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo estatus de molde");
        this.router.navigate(["/estatusmoldes"]);
        return of(null);
      })
    );
  }
}
