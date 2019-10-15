import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ExistenciaMaterial } from "../_models/existenciaMaterial";
import { Viajero } from "../_models/viajero";
import { ExistenciaMaterialGroup } from "../_models/existencia-material-group";

@Injectable({
  providedIn: "root"
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

  getViajerosPorMaterial(materialId: number): Observable<Viajero[]> {
    return this.http.get<Viajero[]>(
      this.baseUrl + "materiales/" + materialId + "/viajeros"
    );
  }
}
