import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { NumeroParte } from "../_models/numeroParte";
import { NumeroParteService } from "../_services/numeroParte.service";

@Injectable()
export class NumeroParteEditResolver implements Resolve<NumeroParte> {
  constructor(
    private numeroParteService: NumeroParteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<NumeroParte> {
    return this.numeroParteService.getNumeroParte(route.params["id"]).pipe(
      catchError((error) => {
        this.alertify.error("Problema obteniendo Numero de Parte");
        this.router.navigate(["/numerosParte"]);
        return of(null);
      })
    );
  }
}
