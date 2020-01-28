export interface OrdenCompraDetalle {
  id: number;
  noParte: string;
  noOrden: number;
  precio: number;
  piezasAutorizadas: number;
  piezasSurtidas: number;
  fechaInicio?: Date;
  fechaFin?: Date;
  ultimaModificacion: Date;
  observaciones?: string;
}
