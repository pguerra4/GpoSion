export interface OrdenCompraProveedorDetalle {
  id: number;
  noOrden: string;
  materialId: number;
  material: string;
  cantidad: number;
  precioUnitario: number;
  precioTotal: number;
  observaciones: string;
  ultimaModificacion: Date;
}
