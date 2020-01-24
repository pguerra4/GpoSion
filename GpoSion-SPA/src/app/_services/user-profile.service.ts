import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "../_models/user";
import { ChangePassword } from "../_models/change-password";

@Injectable({
  providedIn: "root"
})
export class UserProfileService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUser(id: string): Observable<User> {
    return this.http.get<User>(this.baseUrl + "users/" + id);
  }

  editUser(id: string, user: User) {
    return this.http.put(this.baseUrl + "users/" + id, user);
  }

  changePassword(id: string, user: ChangePassword) {
    return this.http.put(this.baseUrl + "users/changepassword/" + id, user);
  }
}
