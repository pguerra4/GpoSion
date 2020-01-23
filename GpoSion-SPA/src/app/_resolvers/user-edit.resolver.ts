import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { User } from "../_models/user";
import { AdminService } from "../_services/admin.service";

@Injectable()
export class UserEditResolver implements Resolve<User> {
  constructor(
    private adminService: AdminService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.adminService.getUserWithRoles(route.params["id"]).pipe(
      catchError(error => {
        this.alertify.error("Problema obteniendo usuario");
        this.router.navigate(["/admin"]);
        return of(null);
      })
    );
  }
}
