import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { Moldeadora } from "../_models/moldeadora";

@Injectable()
export class MoldeadoraEditResolver implements Resolve<Moldeadora> {
  constructor(
    private moldeadoraService: MoldeadoraService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Moldeadora> {
    return this.moldeadoraService.getMoldeadora(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo Moldeadora");
        this.router.navigate(["/moldeadoras"]);
        return of(null);
      })
    );
  }
}
