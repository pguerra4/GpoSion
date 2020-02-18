import { MovimientoMolde } from "./movimiento-molde";
export interface Molde {
  id: number;
  molde: string;
  clienteId: number;
  cliente: string;
  ubicacionId: number;
  ubicacion: string;
  estatusMoldeId?: number;
  estatusMolde: string;
  moldeadoraId?: number;
  moldeadora?: string;
  fechaCreacion: Date;
  ultimaModificacion: Date;
  numerosParte: string[];
  fecha?: Date;
  observaciones?: string;
  movimientos: MovimientoMolde[];
}
