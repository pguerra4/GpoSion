import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { User } from "../_models/user";

@Injectable({
  providedIn: "root"
})
export class AdminService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUsersWithRoles() {
    return this.http.get(this.baseUrl + "admin/usersWithRoles");
  }

  getUserWithRoles(id: string) {
    return this.http.get(this.baseUrl + "admin/userWithRoles/" + id);
  }

  getRoles() {
    return this.http.get(this.baseUrl + "admin/roles");
  }

  editUser(id: string, user: User) {
    return this.http.put(this.baseUrl + "admin/users/" + id, user);
  }

  registerUser(user: User) {
    return this.http.post(this.baseUrl + "admin/users/", user);
  }
}
