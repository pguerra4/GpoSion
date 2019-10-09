export interface RequerimientoMaterialMaterial {
  id: number;
  requerimientoMaterialId: number;
  materialId: number;
  material: string;
  viajeroId: number;
  cantidad: number;
  cantidadEntregada: number;
  unidadMedidaId: number;
  fechaEntrega?: Date;
  estatus: string;
}
