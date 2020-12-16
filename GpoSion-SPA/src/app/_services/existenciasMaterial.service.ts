import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { ExistenciaMaterial } from "../_models/existenciaMaterial";
import { Viajero } from "../_models/viajero";
import { ExistenciaMaterialGroup } from "../_models/existencia-material-group";
import { Material } from "../_models/material";
import { TipoMaterial } from "../_models/tipo-material";
import { MovimientoMaterial } from "../_models/movimientoMaterial";
import { RetornoMaterial } from "../_models/retorno-material";

@Injectable({
  providedIn: "root",
})
export class ExistenciasMaterialService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getExistenciasMaterial(): Observable<ExistenciaMaterialGroup[]> {
    return this.http.get<ExistenciaMaterialGroup[]>(
      this.baseUrl + "existencias"
    );
  }

  getExistenciasMaterialAlmacen(): Observable<ExistenciaMaterial[]> {
    return this.http.get<ExistenciaMaterial[]>(
      this.baseUrl + "existenciasalmacen"
    );
  }

  getViajero(id: number): Observable<Viajero> {
    return this.http.get<Viajero>(this.baseUrl + "viajeros/" + id);
  }

  getViajeros(viajeroParams?): Observable<Viajero[]> {
    let params = new HttpParams();
    if (viajeroParams != null) {
      params = params.append(
        "MostrarHistorico",
        viajeroParams.mostrarHistorico
      );
    }
    return this.http.get<Viajero[]>(this.baseUrl + "viajeros/", { params });
  }

  getViajerosPorMaterial(materialId: number): Observable<Viajero[]> {
    return this.http.get<Viajero[]>(
      this.baseUrl + "materiales/" + materialId + "/viajeros"
    );
  }

  editViajero(id: number, viajero: Viajero) {
    return this.http.put(this.baseUrl + "viajeros/" + id, viajero);
  }

  getMateriales(materialParams?) {
    let params = new HttpParams();
    if (materialParams != null) {
      params = params.append("Tipo", materialParams.tipo);
    }
    return this.http.get<Material[]>(this.baseUrl + "materiales", { params });
  }

  getMaterial(id: number) {
    return this.http.get<Material>(this.baseUrl + "materiales/" + id);
  }

  getTiposMaterial() {
    return this.http.get<TipoMaterial[]>(this.baseUrl + "tiposmaterial");
  }

  getTipoMaterial(id: number) {
    return this.http.get<TipoMaterial>(this.baseUrl + "tiposmaterial/" + id);
  }

  addTipoMaterial(tipoMaterial: TipoMaterial) {
    return this.http.post(this.baseUrl + "tiposmaterial", tipoMaterial);
  }

  editTipoMaterial(id: number, tipoMaterial: TipoMaterial) {
    return this.http.put(this.baseUrl + "tiposmaterial/" + id, tipoMaterial);
  }

  addMaterial(material: Material) {
    return this.http.post(this.baseUrl + "materiales", material);
  }

  editMaterial(id: number, material: Material) {
    return this.http.put(this.baseUrl + "materiales/" + id, material);
  }

  existeMaterial(id: number, material: string) {
    return this.http.get(
      this.baseUrl + "materiales/" + material + "/existe/" + id
    );
  }

  deleteMaterial(id: number) {
    return this.http.delete(this.baseUrl + "materiales/" + id);
  }

  getRetornosMaterial(retornoParams?) {
    let params = new HttpParams();
    if (retornoParams != null) {
      if (retornoParams.fechaInicio != null) {
        params = params.append("FechaInicio", retornoParams.fechaInicio);
      }
      if (retornoParams.fechaFin != null) {
        params = params.append("FechaFin", retornoParams.fechaFin);
      }
    }

    return this.http.get<MovimientoMaterial[]>(
      this.baseUrl + "retornomaterial",
      { params }
    );
  }

  getRetornoMaterial(id: number) {
    return this.http.get<RetornoMaterial>(
      this.baseUrl + "retornomaterial/" + id
    );
  }

  addRetornoMaterial(retorno: RetornoMaterial) {
    return this.http.post(this.baseUrl + "retornomaterial", retorno);
  }

  editRetornoMaterial(id: number, retorno: RetornoMaterial) {
    return this.http.put(this.baseUrl + "retornomaterial/" + id, retorno);
  }

  getMovimientosMaterial(movimientoParams?) {
    let params = new HttpParams();
    if (movimientoParams != null) {
      if (movimientoParams.fechaInicio != null) {
        params = params.append("FechaInicio", movimientoParams.fechaInicio);
      }
      if (movimientoParams.fechaFin != null) {
        params = params.append("FechaFin", movimientoParams.fechaFin);
      }
      if (movimientoParams.materialId != null) {
        params = params.append("MaterialId", movimientoParams.materialId);
      }
    }

    return this.http.get<MovimientoMaterial[]>(
      this.baseUrl + "movimientomaterial",
      { params }
    );
  }
}
