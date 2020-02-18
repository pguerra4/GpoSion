export interface MovimientoMolde {
  movimientoMoldeId: number;
  moldeId: number;
  molde: string;
  fecha: Date;
  estatusMoldeId: number;
  estatusMolde: string;
  observaciones: string;
  fechaCreacion: Date;
  creadoPor: string;
}
