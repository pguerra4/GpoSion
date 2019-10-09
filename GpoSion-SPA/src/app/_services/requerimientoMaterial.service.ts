import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";

@Injectable({
  providedIn: "root"
})
export class RequerimientoMaterialService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getRequerimientos(): Observable<RequerimientoMaterial[]> {
    return this.http.get<RequerimientoMaterial[]>(
      this.baseUrl + "requerimientosmaterial"
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
