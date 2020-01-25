import { MovimientoMaterial } from "./movimientoMaterial";
export interface Viajero {
  viajero: number;
  materialId: number;
  material: string;
  existencia: number;
  fecha: Date;
  movimientosMaterial: MovimientoMaterial[];
  localidadId: number;
  localidad: string;
  motivoMovimiento?: string;
}
