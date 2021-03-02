import { MovimientoMaterial } from "./movimientoMaterial";
export interface Viajero {
  viajero: number;
  materialId: number;
  material: string;
  existencia: number;
  existenciaProduccion: number;
  fecha: Date;
  movimientosMaterial: MovimientoMaterial[];
  localidadId: number;
  localidad: string;
  motivoMovimiento?: string;
}
