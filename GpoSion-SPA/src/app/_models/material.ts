export interface Material {
  materialId: number;
  material: string;
  descripcion?: string;
  unidadMedidaId: number;
  unidadMedida: string;
  tipoMaterialId: number;
  tipoMaterial: string;
  stockMinimo: number;
}
