export interface ExistenciaProducto {
  existenciaProductoId: number;
  noParte: string;
  piezasCertificadas: number;
  piezasRechazadas: number;
  ultimaModificacion: Date;
  localidades?: string[];
}
