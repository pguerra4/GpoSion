import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Recibo } from "../_models/recibo";
import { Observable } from "rxjs";

@Injectable()
export class ReciboService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getRecibos(): Observable<Recibo[]> {
    return this.http.get<Recibo[]>(this.baseUrl + "recibos");
  }

  addRecibo(recibo: Recibo) {
    return this.http.post(this.baseUrl + "recibos", recibo);
  }
}
