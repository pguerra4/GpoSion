import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor() {}

  ngOnInit() {}
  login() {
    // this.authService.login(this.model).subscribe(
    //   next => {
    //     this.alertify.success("Logged in sucessfully");
    //     this.model = {};
    //   },
    //   error => {
    //     this.alertify.error(error);
    //   },
    //   () => {
    //     this.router.navigate(["/members"]);
    //   }
    // );
  }

  loggedIn() {
    return true;
    // return this.authService.loggedIn();
  }

  logout() {
    // localStorage.removeItem("token");
    // this.alertify.message("logged out");
    // this.router.navigate(["/home"]);
  }
}
