import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { Embarque } from "../_models/embarque";
import { NumeroParteService } from "../_services/numeroParte.service";

@Injectable()
export class EmbarqueEditResolver implements Resolve<Embarque> {
  constructor(
    private noParteService: NumeroParteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Embarque> {
    return this.noParteService.getEmbarque(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo embarque");
        this.router.navigate(["/embarques"]);
        return of(null);
      })
    );
  }
}
