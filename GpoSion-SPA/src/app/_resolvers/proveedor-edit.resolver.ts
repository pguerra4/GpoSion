import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { Proveedor } from "../_models/proveedor";
import { ProveedorService } from "../_services/proveedor.service";

@Injectable()
export class ProveedorEditResolver implements Resolve<Proveedor> {
  constructor(
    private proveedorService: ProveedorService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Proveedor> {
    return this.proveedorService.getProveedor(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo proveedor");
        this.router.navigate(["/proveedores"]);
        return of(null);
      })
    );
  }
}
