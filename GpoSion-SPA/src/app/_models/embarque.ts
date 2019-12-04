import { DetalleEmbarque } from "./detalle-embarque";
export interface Embarque {
  embarqueId: number;
  folio: number;
  fecha: Date;
  clienteId: number;
  cliente: string;
  leNo: string;
  elaboro: string;
  recibio: string;
  rechazadas: boolean;
  detallesEmbarque: DetalleEmbarque[];
}
