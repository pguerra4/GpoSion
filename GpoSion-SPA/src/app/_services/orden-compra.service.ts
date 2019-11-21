import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { OrdenCompra } from "../_models/orden-compra";
import { OrdenCompraDetalle } from "../_models/orden-compra-detalle";

@Injectable({
  providedIn: "root"
})
export class OrdenCompraService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getOrdenesCompra(): Observable<OrdenCompra[]> {
    return this.http.get<OrdenCompra[]>(this.baseUrl + "ordenescompra");
  }

  getOrdenCompra(id: number): Observable<OrdenCompra> {
    return this.http.get<OrdenCompra>(this.baseUrl + "ordenescompra/" + id);
  }

  addOrdenCompra(ordenCompra: OrdenCompra) {
    return this.http.post(this.baseUrl + "ordenescompra", ordenCompra);
  }

  editOrdenCompra(id: number, ordenCompra: OrdenCompra) {
    return this.http.put(this.baseUrl + "ordenescompra/" + id, ordenCompra);
  }

  getOrdenCompraDetalle(id: number): Observable<OrdenCompraDetalle> {
    return this.http.get<OrdenCompraDetalle>(
      this.baseUrl + "detallesordencompra/" + id
    );
  }

  addOrdenCompraDetalle(ordenCompraDetalle: OrdenCompraDetalle) {
    return this.http.post(
      this.baseUrl + "detallesordencompra",
      ordenCompraDetalle
    );
  }

  editOrdenCompraDetalle(id: number, ordenCompraDetalle: OrdenCompraDetalle) {
    return this.http.put(
      this.baseUrl + "detallesordencompra/" + id,
      ordenCompraDetalle
    );
  }
  deleteOrdenCompraDetalle(id: number) {
    return this.http.delete(this.baseUrl + "detallesordencompra/" + id);
  }
}
