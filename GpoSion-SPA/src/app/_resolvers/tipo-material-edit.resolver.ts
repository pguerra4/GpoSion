import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { TipoMaterial } from "../_models/tipo-material";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";

@Injectable()
export class TipoMaterialEditResolver implements Resolve<TipoMaterial> {
  constructor(
    private existenciasService: ExistenciasMaterialService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<TipoMaterial> {
    return this.existenciasService.getTipoMaterial(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo tipo material");
        this.router.navigate(["/existencias"]);
        return of(null);
      })
    );
  }
}
