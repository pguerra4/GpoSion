import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class ProveedorService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProveedores() {
    return this.http.get(this.baseUrl + "proveedores");
  }
}
