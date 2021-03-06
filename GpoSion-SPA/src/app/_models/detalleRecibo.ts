import { Recibo } from "./recibo";
import { UnidadMedida } from "./unidadMedida";
import { Material } from "./material";

export interface DetalleRecibo {
  detalleReciboId: number;
  totalCajas: number;
  cantidadPorCaja: number;
  total: number;
  referencia2?: string;
  viajero: number;
  referenciaCliente?: string;
  noLote?: string;
  reciboId: number;
  noRecibo: string;
  materialId: number;
  material: string;
  unidadMedidaId: number;
  unidad: string;
  localidadId: number;
  localidad: string;
  motivoMovimiento?: string;
}
