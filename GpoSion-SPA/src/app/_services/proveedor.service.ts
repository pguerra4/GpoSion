import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Proveedor } from "../_models/proveedor";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class ProveedorService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProveedores(): Observable<Proveedor[]> {
    return this.http.get<Proveedor[]>(this.baseUrl + "proveedores");
  }

  getProveedor(id: number): Observable<Proveedor> {
    return this.http.get<Proveedor>(this.baseUrl + "proveedores/" + id);
  }

  addProveedor(proveedor: Proveedor) {
    return this.http.post(this.baseUrl + "proveedores", proveedor);
  }
  editProveedor(id: number, proveedor: Proveedor) {
    return this.http.put(this.baseUrl + "proveedores/" + id, proveedor);
  }
}
