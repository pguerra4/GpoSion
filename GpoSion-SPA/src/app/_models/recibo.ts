import { DetalleRecibo } from "./detalleRecibo";
import { Proveedor } from "./proveedor";

export interface Recibo {
  reciboId: number;
  noRecibo: number;
  fechaEntrada: Date;
  horaEntrada?: Date;
  transportista?: string;
  facturaAduanal?: string;
  pedimentoImportacion?: string;
  proveedorId: number;
  proveedorNombre: string;
  proveedor: Proveedor;
  recibio?: string;
  detalle: DetalleRecibo[];
  isComplete: boolean;
}
