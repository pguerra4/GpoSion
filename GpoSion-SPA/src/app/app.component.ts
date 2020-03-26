import { Component, OnInit } from "@angular/core";
import { AuthService } from "./_services/auth.service";
import { JwtHelperService } from "@auth0/angular-jwt";
import * as signalR from "@aspnet/signalr";
// import { User } from "./_models/user";
import { AlertifyService } from "./_services/alertify.service";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  baseUrl = environment.apiUrl;

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    const token = localStorage.getItem("token");
    // const user: User = JSON.parse(localStorage.getItem("user"));

    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
    // if (user) {
    //   this.authService.currentUser = user;
    //   this.authService.changeMemberPhoto(user.photoUrl);
    // }

    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl(this.baseUrl + "notify")
      .build();

    connection
      .start()
      .then(() => {
        console.log("Connected!");
      })
      .catch(err => {
        return console.error(err.toString());
      });

    connection.on("BroadcastMessage", (type: string, payload: string) => {
      if (type === "Warning") {
        this.alertify.warning(payload);
      } else {
        this.alertify.message(payload);
      }
    });
  }
}
