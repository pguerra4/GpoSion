import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Turno } from "../_models/turno";

@Injectable({
  providedIn: "root"
})
export class TurnosService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getTurnos(): Observable<Turno[]> {
    return this.http.get<Turno[]>(this.baseUrl + "turnos");
  }
}
