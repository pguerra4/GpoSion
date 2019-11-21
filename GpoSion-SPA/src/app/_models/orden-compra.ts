import { OrdenCompraDetalle } from "./orden-compra-detalle";
export interface OrdenCompra {
  noOrden: number;
  fecha: Date;
  clienteId: number;
  cliente: string;
  numerosParte: OrdenCompraDetalle[];
}
