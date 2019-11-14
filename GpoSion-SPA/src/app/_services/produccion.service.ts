import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Produccion } from "../_models/produccion";

@Injectable({
  providedIn: "root"
})
export class ProduccionService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addProduccion(produccion: Produccion) {
    return this.http.post(this.baseUrl + "produccion", produccion);
  }
}
