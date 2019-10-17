import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Molde } from "../_models/molde";

@Injectable({
  providedIn: "root"
})
export class MoldeService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMoldes(): Observable<Molde[]> {
    return this.http.get<Molde[]>(this.baseUrl + "moldes");
  }

  getMolde(id: number): Observable<Molde> {
    return this.http.get<Molde>(this.baseUrl + "moldes/" + id);
  }

  addMolde(molde: Molde) {
    return this.http.post(this.baseUrl + "moldes", molde);
  }

  editMolde(id: number, molde: Molde) {
    return this.http.put(this.baseUrl + "moldes/" + id, molde);
  }
}
