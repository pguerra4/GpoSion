export interface MovimientoProducto {
  movimientoProductoId: number;
  noParte: string;
  fecha: Date;
  cajas: number;
  piezasXCaja: number;
  piezasCertificadas: number;
  piezasRechazadas: number;
  purga: number;
  colada: number;
  localidad: string;
  unidadMedidaIdRechazadas: number;
}
