import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UnidadMedida } from "../_models/unidadMedida";

@Injectable({
  providedIn: "root"
})
export class UnidadMedidaService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUnidadesMedida(): Observable<UnidadMedida[]> {
    return this.http.get<UnidadMedida[]>(this.baseUrl + "unidadesMedida");
  }
}
