import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { RetornoMaterial } from "../_models/retorno-material";

@Injectable()
export class RetornoMaterialEditResolver implements Resolve<RetornoMaterial> {
  constructor(
    private existenciasService: ExistenciasMaterialService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<RetornoMaterial> {
    return this.existenciasService.getRetornoMaterial(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo RetornoMaterial");
        this.router.navigate(["/existencias"]);
        return of(null);
      })
    );
  }
}
