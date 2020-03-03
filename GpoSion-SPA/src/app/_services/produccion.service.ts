import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Produccion } from "../_models/produccion";
import { Observable } from "rxjs";
import { PlaneacionProduccion } from "../_models/planeacion-produccion";

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

  getPlaneaciones(planeacionParams?): Observable<PlaneacionProduccion[]> {
    let params = new HttpParams();
    if (planeacionParams != null) {
      if (planeacionParams.año != null) {
        params = params.append("Año", planeacionParams.año);
      }
      if (planeacionParams.semana != null) {
        params = params.append("Semana", planeacionParams.semana);
      }
    }
    return this.http.get<PlaneacionProduccion[]>(
      this.baseUrl + "planeacionproduccion",
      { params }
    );
  }

  getPlaneacion(año: number, semana: number, noParte: string) {
    return this.http.get<PlaneacionProduccion>(
      this.baseUrl +
        "planeacionproduccion/" +
        año +
        "/" +
        semana +
        "/" +
        noParte
    );
  }

  addPlaneacion(planeacion: PlaneacionProduccion) {
    return this.http.post(this.baseUrl + "planeacionproduccion", planeacion);
  }

  editPlaneacion(
    año: number,
    semana: number,
    noParte: string,
    pp: PlaneacionProduccion
  ) {
    return this.http.put(
      this.baseUrl +
        "planeacionproduccion/" +
        año +
        "/" +
        semana +
        "/" +
        noParte,
      pp
    );
  }
}
