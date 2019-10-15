import { Injectable } from "@angular/core";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { RequerimientoMaterialService } from "../_services/requerimientoMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()
export class RequerimientoMaterialProdResolver
  implements Resolve<RequerimientoMaterial> {
  constructor(
    private requerimientoMaterialService: RequerimientoMaterialService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<RequerimientoMaterial> {
    return this.requerimientoMaterialService
      .getRequerimiento(route.params["id"])
      .pipe(
        catchError(error => {
          this.alertify.error("Problema obteniendo información");
          this.router.navigate(["/existencias"]);
          return of(null);
        })
      );
  }
}
