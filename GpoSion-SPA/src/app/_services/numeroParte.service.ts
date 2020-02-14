import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { NumeroParte } from "../_models/numeroParte";
import { MovimientoProducto } from "../_models/movimiento-producto";
import { Embarque } from "../_models/embarque";
import { ExistenciaProducto } from "../_models/existencia-producto";
import { DetalleEmbarque } from "../_models/detalle-embarque";
import { LocalidadNumeroParte } from "../_models/localidad-numero-parte";

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
      params = params.append("FechaInicio", movimientoParams.fechaInicio);
      params = params.append("FechaFin", movimientoParams.fechaFin);
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
      if (embarqueParams.fechaInicio != null) {
        params = params.append("FechaInicio", embarqueParams.fechaInicio);
      }
      if (embarqueParams.fechaFin != null) {
        params = params.append("FechaFin", embarqueParams.fechaFin);
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

  getDetalleEmbarque(id: number): Observable<DetalleEmbarque> {
    return this.http.get<DetalleEmbarque>(
      this.baseUrl + "detallesembarque/" + id
    );
  }

  addDetalleEmbarque(detalleEmbarque: DetalleEmbarque) {
    return this.http.post(this.baseUrl + "detallesembarque", detalleEmbarque);
  }

  editDetalleEmbarque(id: number, detalleEmbarque: DetalleEmbarque) {
    return this.http.put(
      this.baseUrl + "detallesEmbarque/" + id,
      detalleEmbarque
    );
  }

  deleteDetalleEmbarque(id: number) {
    return this.http.delete(this.baseUrl + "detallesembarque/" + id);
  }

  getExistenciasProducto(): Observable<ExistenciaProducto[]> {
    return this.http.get<ExistenciaProducto[]>(
      this.baseUrl + "existenciasproducto"
    );
  }

  existeFolioEmbarque(id: number): Observable<boolean> {
    return this.http.get<boolean>(this.baseUrl + "embarques/" + id + "/existe");
  }

  existenciasAlmacen(id: string, certificadas: boolean): Observable<number> {
    return this.http.get<number>(
      this.baseUrl +
        "numerosparte/" +
        id +
        "/existenciaAlmacen?certificadas=" +
        certificadas
    );
  }

  getExistenciaProducto(noParte: string): Observable<ExistenciaProducto> {
    return this.http.get<ExistenciaProducto>(
      this.baseUrl + "existenciasproducto/" + noParte
    );
  }

  getLocalidadesNumeroParte(
    noParte: string
  ): Observable<LocalidadNumeroParte[]> {
    return this.http.get<LocalidadNumeroParte[]>(
      this.baseUrl + "localidadesnumeroparte/" + noParte
    );
  }
}
