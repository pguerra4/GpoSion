import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { Cliente } from "../_models/cliente";
import { ClienteService } from "../_services/cliente.service";

@Injectable()
export class ClienteEditResolver implements Resolve<Cliente> {
  constructor(
    private clienteService: ClienteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Cliente> {
    return this.clienteService.getCliente(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo cliente");
        this.router.navigate(["/clientes"]);
        return of(null);
      })
    );
  }
}
