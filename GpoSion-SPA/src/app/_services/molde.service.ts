import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { Molde } from "../_models/molde";
import { EstatusMolde } from "../_models/estatus-molde";

@Injectable({
  providedIn: "root",
})
export class MoldeService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMoldes(moldesParams?): Observable<Molde[]> {
    let params = new HttpParams();
    if (moldesParams != null) {
      params = params.append("Estatus", moldesParams.estatus);
    }
    return this.http.get<Molde[]>(this.baseUrl + "moldes", { params });
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

  existeMolde(id: string): Observable<boolean> {
    return this.http.get<boolean>(this.baseUrl + "moldes/" + id + "/existe");
  }

  deleteMolde(id: number) {
    return this.http.delete(this.baseUrl + "moldes/" + id);
  }

  getEstatusMolde(id: number): Observable<EstatusMolde> {
    return this.http.get<EstatusMolde>(this.baseUrl + "estatusmoldes/" + id);
  }

  getEstatusMoldes(): Observable<EstatusMolde[]> {
    return this.http.get<EstatusMolde[]>(this.baseUrl + "estatusmoldes");
  }

  addEstatusMolde(estatusMolde: EstatusMolde) {
    return this.http.post(this.baseUrl + "estatusmoldes", estatusMolde);
  }

  editEstatusMolde(id: number, estatusMolde: EstatusMolde) {
    return this.http.put(this.baseUrl + "estatusmoldes/" + id, estatusMolde);
  }

  deleteEstatusMolde(id: number) {
    return this.http.delete(this.baseUrl + "estatusmoldes/" + id);
  }
}
