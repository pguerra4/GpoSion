import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { OrdenCompraProveedor } from "../_models/orden-compra-proveedor";
import { Comprador } from "../_models/comprador";

@Injectable({
  providedIn: "root"
})
export class OrdenCompraProveedorService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getOrdenesCompraProveedores(): Observable<OrdenCompraProveedor[]> {
    return this.http.get<OrdenCompraProveedor[]>(
      this.baseUrl + "ordenescompraproveedores"
    );
  }

  getOrdenCompraProveedor(noOrden: string): Observable<OrdenCompraProveedor> {
    return this.http.get<OrdenCompraProveedor>(
      this.baseUrl + "ordenescompraproveedores/" + noOrden
    );
  }

  addOrdenCompraProveedor(ordenCompraProveedor: OrdenCompraProveedor) {
    return this.http.post(
      this.baseUrl + "ordenescompraproveedores",
      ordenCompraProveedor
    );
  }

  editOrdenCompraProveedor(
    noOrden: string,
    ordenCompraProveedor: OrdenCompraProveedor
  ) {
    return this.http.put(
      this.baseUrl + "ordenescompraproveedores/" + noOrden,
      ordenCompraProveedor
    );
  }

  getCompradores(): Observable<Comprador[]> {
    return this.http.get<Comprador[]>(this.baseUrl + "compradores");
  }
}
