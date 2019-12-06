import { OrdenCompraProveedorDetalle } from "./orden-compra-proveedor-detalle";

export interface OrdenCompraProveedor {
  noOrden: string;
  fecha: Date;
  fechaEntrega?: Date;
  compradorId: number;
  comprador: string;
  proveedorId: number;
  proveedor: string;
  personaSolicita: string;
  departamento: string;
  areaProyecto: string;
  razonCompra: string;
  compra: string;

  materiales: OrdenCompraProveedorDetalle[];
}
