import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Produccion } from "../_models/produccion";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class ProduccionService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducciones(produccionParams?): Observable<Produccion[]> {
    let params = new HttpParams();
    if (produccionParams != null) {
      if (produccionParams.fechaInicio != null) {
        params = params.append("FechaInicio", produccionParams.fechaInicio);
      }
      if (produccionParams.fechaFin != null) {
        params = params.append("FechaFin", produccionParams.fechaFin);
      }
    }
    return this.http.get<Produccion[]>(this.baseUrl + "produccion", { params });
  }

  addProduccion(produccion: Produccion) {
    return this.http.post(this.baseUrl + "produccion", produccion);
  }
}
