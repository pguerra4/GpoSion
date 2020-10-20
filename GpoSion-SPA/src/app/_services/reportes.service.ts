import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ReportesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getReporteEmbarques(reporteParams?): Observable<any[]> {
    let params = new HttpParams();
    if (reporteParams != null) {
      if (reporteParams.noParte != null) {
        params = params.append("NoParte", reporteParams.noParte);
      }
      if (reporteParams.fechaInicio != null) {
        params = params.append("FechaInicio", reporteParams.fechaInicio);
      }
      if (reporteParams.fechaFin != null) {
        params = params.append("FechaFin", reporteParams.fechaFin);
      }
    }
    return this.http.get<any[]>(this.baseUrl + "reportes/embarques", {
      params,
    });
  }

  getReporteEmbarquesNumeroParte(reporteParams?): Observable<any[]> {
    let params = new HttpParams();
    if (reporteParams != null) {
      if (reporteParams.noParte != null) {
        params = params.append("NoParte", reporteParams.noParte);
      }
      if (reporteParams.fechaInicio != null) {
        params = params.append("FechaInicio", reporteParams.fechaInicio);
      }
      if (reporteParams.fechaFin != null) {
        params = params.append("FechaFin", reporteParams.fechaFin);
      }
    }
    return this.http.get<any[]>(
      this.baseUrl + "reportes/embarquesnumeroparte",
      {
        params,
      }
    );
  }

  getReporteEmbarquesPorFecha(reporteParams?): Observable<any[]> {
    let params = new HttpParams();
    if (reporteParams != null) {
      if (reporteParams.noParte != null) {
        params = params.append("NoParte", reporteParams.noParte);
      }
      if (reporteParams.fechaInicio != null) {
        params = params.append("FechaInicio", reporteParams.fechaInicio);
      }
      if (reporteParams.fechaFin != null) {
        params = params.append("FechaFin", reporteParams.fechaFin);
      }
    }
    return this.http.get<any[]>(this.baseUrl + "reportes/embarquesporfecha", {
      params,
    });
  }

  getReporteEmbarquesTop10(reporteParams?): Observable<any[]> {
    let params = new HttpParams();
    if (reporteParams != null) {
      if (reporteParams.noParte != null) {
        params = params.append("NoParte", reporteParams.noParte);
      }
      if (reporteParams.fechaInicio != null) {
        params = params.append("FechaInicio", reporteParams.fechaInicio);
      }
      if (reporteParams.fechaFin != null) {
        params = params.append("FechaFin", reporteParams.fechaFin);
      }
    }
    return this.http.get<any[]>(this.baseUrl + "reportes/embarquestop10", {
      params,
    });
  }

  getReporteRecibosPorFecha(reporteParams?): Observable<any[]> {
    let params = new HttpParams();
    if (reporteParams != null) {
      if (reporteParams.materialId != null) {
        params = params.append("MaterialId", reporteParams.materialId);
      }
      if (reporteParams.fechaInicio != null) {
        params = params.append("FechaInicio", reporteParams.fechaInicio);
      }
      if (reporteParams.fechaFin != null) {
        params = params.append("FechaFin", reporteParams.fechaFin);
      }
    }
    return this.http.get<any[]>(this.baseUrl + "reportes/recibosporfecha", {
      params,
    });
  }

  getReporteRecibosMaterial(reporteParams?): Observable<any[]> {
    let params = new HttpParams();
    if (reporteParams != null) {
      if (reporteParams.materialId != null) {
        params = params.append("MaterialId", reporteParams.materialId);
      }
      if (reporteParams.fechaInicio != null) {
        params = params.append("FechaInicio", reporteParams.fechaInicio);
      }
      if (reporteParams.fechaFin != null) {
        params = params.append("FechaFin", reporteParams.fechaFin);
      }
    }
    return this.http.get<any[]>(this.baseUrl + "reportes/recibosmaterial", {
      params,
    });
  }

  getReporteRecibos(reporteParams?): Observable<any[]> {
    let params = new HttpParams();
    if (reporteParams != null) {
      if (reporteParams.materialId != null) {
        params = params.append("MaterialId", reporteParams.materialId);
      }
      if (reporteParams.fechaInicio != null) {
        params = params.append("FechaInicio", reporteParams.fechaInicio);
      }
      if (reporteParams.fechaFin != null) {
        params = params.append("FechaFin", reporteParams.fechaFin);
      }
    }
    return this.http.get<any[]>(this.baseUrl + "reportes/recibos", {
      params,
    });
  }

  getReporteRecibosTop10(reporteParams?): Observable<any[]> {
    let params = new HttpParams();
    if (reporteParams != null) {
      if (reporteParams.materialId != null) {
        params = params.append("MaterialId", reporteParams.materialId);
      }
      if (reporteParams.fechaInicio != null) {
        params = params.append("FechaInicio", reporteParams.fechaInicio);
      }
      if (reporteParams.fechaFin != null) {
        params = params.append("FechaFin", reporteParams.fechaFin);
      }
    }
    return this.http.get<any[]>(this.baseUrl + "reportes/recibostop10", {
      params,
    });
  }
}
