import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";

@Injectable({
  providedIn: "root"
})
export class RequerimientoMaterialService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getRequerimientos(requerimientoParams?): Observable<RequerimientoMaterial[]> {
    let params = new HttpParams();
    if (requerimientoParams != null) {
      if (requerimientoParams.fechaInicio != null) {
        params = params.append("FechaInicio", requerimientoParams.fechaInicio);
      }
      if (requerimientoParams.fechaFin != null) {
        params = params.append("FechaFin", requerimientoParams.fechaFin);
      }
      if (requerimientoParams.mostrarSurtidos != null) {
        params = params.append(
          "MostrarSurtidos",
          requerimientoParams.mostrarSurtidos
        );
      }
    }
    return this.http.get<RequerimientoMaterial[]>(
      this.baseUrl + "requerimientosmaterial",
      { params }
    );
  }

  getRequerimiento(id): Observable<RequerimientoMaterial> {
    return this.http.get<RequerimientoMaterial>(
      this.baseUrl + "requerimientosmaterial/" + id
    );
  }

  addRequerimiento(requerimiento: RequerimientoMaterial) {
    return this.http.post(
      this.baseUrl + "requerimientosmaterial",
      requerimiento
    );
  }

  surtirRequerimiento(id: number, req: any) {
    return this.http.put(this.baseUrl + "requerimientosmaterial/" + id, req);
  }
}
