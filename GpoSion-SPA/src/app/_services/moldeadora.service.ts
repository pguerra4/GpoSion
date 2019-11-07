import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Moldeadora } from "../_models/moldeadora";

@Injectable({
  providedIn: "root"
})
export class MoldeadoraService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMoldeadoras(): Observable<Moldeadora[]> {
    return this.http.get<Moldeadora[]>(this.baseUrl + "moldeadoras");
  }

  getMoldeadora(id: number): Observable<Moldeadora> {
    return this.http.get<Moldeadora>(this.baseUrl + "moldeadoras/" + id);
  }

  addMoldeadora(moldeadora: Moldeadora) {
    return this.http.post(this.baseUrl + "moldeadoras", moldeadora);
  }

  editMoldeadora(id: number, moldeadora: Moldeadora) {
    return this.http.put(this.baseUrl + "moldeadoras/" + id, moldeadora);
  }

  arrancarMoldeadora(id: number) {
    return this.http.post(this.baseUrl + "moldeadoras/" + id, null);
  }
  detenerMoldeadora(id: number) {
    return this.http.post(this.baseUrl + "moldeadoras/" + id + "/stop", null);
  }
}
