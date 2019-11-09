import { UnidadMedida } from "./unidadMedida";
import { Cliente } from "./cliente";
export interface Material {
  materialId: number;
  material: string;
  descripcion?: string;
  unidadMedidaId: number;
  unidadMedida: string;
  tipoMaterialId: number;
  tipoMaterial: string;
}
