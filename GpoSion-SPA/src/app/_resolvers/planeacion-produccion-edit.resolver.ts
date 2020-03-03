import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { PlaneacionProduccion } from "../_models/planeacion-produccion";
import { ProduccionService } from "../_services/produccion.service";

@Injectable()
export class PlaneacionProduccionEditResolver
  implements Resolve<PlaneacionProduccion> {
  constructor(
    private produccionService: ProduccionService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<PlaneacionProduccion> {
    return this.produccionService
      .getPlaneacion(
        +route.params["año"],
        +route.params["semana"],
        route.params["noParte"]
      )
      .pipe(
        catchError(error => {
          this.alertify.error("Problema obteniendo planeación");
          this.router.navigate(["/planeacionproduccion"]);
          return of(null);
        })
      );
  }
}
