import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { Material } from "../_models/material";

@Injectable()
export class MaterialEditResolver implements Resolve<Material> {
  constructor(
    private existenciasService: ExistenciasMaterialService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Material> {
    return this.existenciasService.getMaterial(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo material");
        this.router.navigate(["/materiales"]);
        return of(null);
      })
    );
  }
}
