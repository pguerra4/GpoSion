export interface DetalleEmbarque {
  detalleEmbarqueId: number;
  embarqueId: number;
  noParte: string;
  noOrden?: number;
  cajas: number;
  piezasXCaja: number;
  entregadas: number;
}
