import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Recibo } from "../_models/recibo";
import { Observable } from "rxjs";
import { DetalleRecibo } from "../_models/detalleRecibo";

@Injectable()
export class ReciboService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getRecibos(): Observable<Recibo[]> {
    return this.http.get<Recibo[]>(this.baseUrl + "recibos");
  }

  getRecibo(id): Observable<Recibo> {
    return this.http.get<Recibo>(this.baseUrl + "recibos/" + id);
  }

  addRecibo(recibo: Recibo) {
    return this.http.post(this.baseUrl + "recibos", recibo);
  }
  addDetallesRecibo(detalles: DetalleRecibo[]) {
    return this.http.post(this.baseUrl + "detalleRecibo", detalles);
  }
}
