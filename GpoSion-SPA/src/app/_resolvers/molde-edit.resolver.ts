import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { Molde } from "../_models/Molde";
import { MoldeService } from "../_services/molde.service";

@Injectable()
export class MoldeEditResolver implements Resolve<Molde> {
  constructor(
    private moldeService: MoldeService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Molde> {
    return this.moldeService.getMolde(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo Molde");
        this.router.navigate(["/existencias"]);
        return of(null);
      })
    );
  }
}
