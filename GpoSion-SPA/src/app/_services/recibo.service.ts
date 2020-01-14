import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Recibo } from "../_models/recibo";
import { Observable } from "rxjs";
import { DetalleRecibo } from "../_models/detalleRecibo";
import { Localidad } from "../_models/localidad";

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

  existeRecibo(id): Observable<boolean> {
    return this.http.get<boolean>(this.baseUrl + "recibos/" + id + "/existe");
  }

  addRecibo(recibo: Recibo) {
    return this.http.post(this.baseUrl + "recibos", recibo);
  }
  addDetallesRecibo(detalles: DetalleRecibo[]) {
    return this.http.post(this.baseUrl + "detalleRecibo", detalles);
  }

  editDetallesRecibo(id: number, detalle: DetalleRecibo) {
    return this.http.put(this.baseUrl + "detalleRecibo/" + id, detalle);
  }

  getDetalleRecibo(id): Observable<DetalleRecibo> {
    return this.http.get<DetalleRecibo>(this.baseUrl + "detalleRecibo/" + id);
  }

  getLocalidades(): Observable<Localidad[]> {
    return this.http.get<Localidad[]>(this.baseUrl + "localidades");
  }

  getLocalidad(id): Observable<Localidad> {
    return this.http.get<Localidad>(this.baseUrl + "localidades/" + id);
  }

  addLocalidad(localidad: Localidad) {
    return this.http.post(this.baseUrl + "localidades", localidad);
  }

  editLocalidad(id: number, localidad: Localidad) {
    return this.http.put(this.baseUrl + "localidades/" + id, localidad);
  }
}
