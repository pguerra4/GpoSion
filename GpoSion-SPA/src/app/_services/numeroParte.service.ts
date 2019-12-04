import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { NumeroParte } from "../_models/numeroParte";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { Embarque } from "../_models/embarque";

@Injectable({
  providedIn: "root"
})
export class NumeroParteService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getNumerosParte(npParams?): Observable<NumeroParte[]> {
    let params = new HttpParams();
    if (npParams != null) {
      if (npParams.clienteId != null) {
        params = params.append("ClienteId", npParams.clienteId);
      }
    }
    return this.http.get<NumeroParte[]>(this.baseUrl + "numerosParte", {
      params
    });
  }

  getNumeroParte(id: string): Observable<NumeroParte> {
    return this.http.get<NumeroParte>(this.baseUrl + "numerosParte/" + id);
  }

  addNumeroParte(numeroParte: NumeroParte) {
    return this.http.post(this.baseUrl + "numerosParte", numeroParte);
  }

  editNumeroParte(id: string, numeroParte: NumeroParte) {
    return this.http.put(this.baseUrl + "numerosParte/" + id, numeroParte);
  }

  existeNumeroParte(id: string): Observable<boolean> {
    return this.http.get<boolean>(
      this.baseUrl + "numerosParte/" + id + "/existe"
    );
  }

  getMovimientosProducto(movimientoParams?): Observable<MovimientoProducto[]> {
    let params = new HttpParams();
    if (movimientoParams != null) {
      params = params.append("TipoMovimiento", movimientoParams.tipoMovimiento);
      params = params.append("Fecha", movimientoParams.fecha);
    }
    return this.http.get<MovimientoProducto[]>(
      this.baseUrl + "movimientosproducto",
      { params }
    );
  }

  getMovimientoProducto(id: number): Observable<MovimientoProducto> {
    return this.http.get<MovimientoProducto>(
      this.baseUrl + "movimientosproducto/" + id
    );
  }

  addMovimientoProducto(movimientoProducto: MovimientoProducto) {
    return this.http.post(
      this.baseUrl + "movimientosproducto",
      movimientoProducto
    );
  }

  editMovimientoProducto(id: number, movimientoProducto: MovimientoProducto) {
    return this.http.put(
      this.baseUrl + "movimientosproducto/" + id,
      movimientoProducto
    );
  }

  getEmbarques(embarqueParams?): Observable<Embarque[]> {
    let params = new HttpParams();
    if (embarqueParams != null) {
      if (embarqueParams.clienteId != null) {
        params = params.append("ClienteId", embarqueParams.clienteId);
      }
      if (embarqueParams.fecha != null) {
        params = params.append("Fecha", embarqueParams.fecha);
      }
    }
    return this.http.get<Embarque[]>(this.baseUrl + "embarques", { params });
  }

  getEmbarque(id: number): Observable<Embarque> {
    return this.http.get<Embarque>(this.baseUrl + "embarques/" + id);
  }

  addEmbarque(embarque: Embarque) {
    return this.http.post(this.baseUrl + "embarques", embarque);
  }

  editEmbarque(id: number, embarque: Embarque) {
    return this.http.put(this.baseUrl + "embarques/" + id, embarque);
  }
}
