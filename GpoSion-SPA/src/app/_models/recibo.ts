import { DetalleRecibo } from "./detalleRecibo";
import { Cliente } from "./cliente";

export interface Recibo {
  reciboId: number;
  noRecibo: number;
  fechaEntrada: Date;
  horaEntrada?: Date;
  transportista?: string;
  facturaAduanal?: string;
  pedimentoImportacion?: string;
  clienteId: number;
  cliente: Cliente;
  recibio?: string;
  detalle: DetalleRecibo[];
}
