export interface MovimientoMaterial {
  movimientoMaterialId: number;
  fecha: Date;
  material: string;
  cantidad: number;
  origen: string;
  destino: string;
  motivoMovimiento?: string;
  modificadoPor: string;
  creadoPor: string;
}
