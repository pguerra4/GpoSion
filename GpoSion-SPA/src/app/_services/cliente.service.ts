import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Cliente } from "../_models/cliente";
import { Observable } from "rxjs";

@Injectable()
export class ClienteService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getClienttes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl + "clientes");
  }
}
