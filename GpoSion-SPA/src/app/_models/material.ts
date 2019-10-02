import { UnidadMedida } from "./unidadMedida";
import { Cliente } from "./cliente";
export interface Material {
  materialId: number;
  claveMaterial: string;
  descripcion?: string;
  unidadMedidaId: number;
  UnidadMedida: UnidadMedida;
  clienteId: number;
  cliente: Cliente;
}
