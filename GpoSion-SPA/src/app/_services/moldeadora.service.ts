import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Moldeadora } from "../_models/moldeadora";
import { MotivoTiempoMuerto } from "../_models/motivo-tiempo-muerto";
import { MoldeadoraForStop } from "../_models/moldeadora-for-stop";

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

  editNombreMoldeadora(id: number, moldeadora: Moldeadora) {
    return this.http.put(this.baseUrl + "moldeadoras/edit/" + id, moldeadora);
  }

  arrancarMoldeadora(id: number) {
    return this.http.post(this.baseUrl + "moldeadoras/" + id, null);
  }
  detenerMoldeadora(id: number, moldeadora: MoldeadoraForStop) {
    return this.http.post(
      this.baseUrl + "moldeadoras/" + id + "/stop",
      moldeadora
    );
  }

  getMotivosTiempoMuerto(): Observable<MotivoTiempoMuerto[]> {
    return this.http.get<MotivoTiempoMuerto[]>(
      this.baseUrl + "motivostiempomuerto"
    );
  }

  getMotivoTiempoMuerto(id: number): Observable<MotivoTiempoMuerto> {
    return this.http.get<MotivoTiempoMuerto>(
      this.baseUrl + "motivostiempomuerto/" + id
    );
  }

  addMotivoTiempoMuerto(motivo: MotivoTiempoMuerto) {
    return this.http.post(this.baseUrl + "motivostiempomuerto", motivo);
  }

  editMotivoTiempoMuerto(id: number, motivo: MotivoTiempoMuerto) {
    return this.http.put(this.baseUrl + "motivostiempomuerto/" + id, motivo);
  }

  resetMoldeadora(id: number) {
    return this.http.post(this.baseUrl + "moldeadoras/" + id + "/reset", null);
  }
}
