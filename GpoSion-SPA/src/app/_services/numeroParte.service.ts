import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { NumeroParte } from "../_models/numeroParte";
import { MovimientoProducto } from "../_models/movimiento-producto";

@Injectable({
  providedIn: "root"
})
export class NumeroParteService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getNumerosParte(): Observable<NumeroParte[]> {
    return this.http.get<NumeroParte[]>(this.baseUrl + "numerosParte");
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

  getMovimientosProducto(): Observable<MovimientoProducto[]> {
    return this.http.get<MovimientoProducto[]>(
      this.baseUrl + "movimientosproducto"
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
}
