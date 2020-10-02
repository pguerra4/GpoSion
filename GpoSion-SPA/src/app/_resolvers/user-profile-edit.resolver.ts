import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { User } from "../_models/user";
import { UserProfileService } from "../_services/user-profile.service";

@Injectable()
export class UserProfileEditResolver implements Resolve<User> {
  constructor(
    private userService: UserProfileService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.userService.getUser(route.params["id"]).pipe(
      catchError((error) => {
        this.alertify.error("Problema obteniendo usuario");
        this.router.navigate(["/home"]);
        return of(null);
      })
    );
  }
}
