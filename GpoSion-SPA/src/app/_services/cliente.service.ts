import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Cliente } from "../_models/cliente";
import { Observable } from "rxjs";

@Injectable()
export class ClienteService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl + "clientes");
  }

  getCliente(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(this.baseUrl + "clientes/" + id);
  }

  addCliente(cliente: Cliente) {
    return this.http.post(this.baseUrl + "clientes", cliente);
  }
  editCliente(id: number, cliente: Cliente) {
    return this.http.put(this.baseUrl + "clientes/" + id, cliente);
  }
}
