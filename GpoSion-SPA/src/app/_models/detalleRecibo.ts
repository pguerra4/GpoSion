import { Recibo } from "./recibo";
import { UnidadMedida } from "./unidadMedida";

export interface DetalleRecibo {
  detalleReciboId: number;
  totalCajas: number;
  cantidadPorCaja: number;
  total: number;
  referencia2?: string;
  Viajero: number;
  referenciaCliente?: string;
  reciboId: number;
  recibo: Recibo;
  materialId: number;
  unidadMedidaId: number;
  unidadMedida: UnidadMedida;
}
