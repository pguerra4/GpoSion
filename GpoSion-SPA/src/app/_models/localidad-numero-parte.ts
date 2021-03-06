export interface LocalidadNumeroParte {
  localidadId: number;
  localidad: string;
  noParte: string;
  existencia: number;
  rechazadas?: number;
  fechaCreacion?: Date;
  ultimaModificacion?: Date;
  creadoPor?: string;
  modificadoPor?: string;
  motivo?: string;
}
