import { RequerimientoMaterialMaterial } from "./requerimientoMaterialMaterial";
export interface RequerimientoMaterial {
  requerimientoMaterialId: number;
  fechaSolicitud: Date;
  turnoId?: number;
  turnoDescripcion: string;
  fechaentrega?: Date;

  jefaLinea: string;

  almacenista: string;

  recibio: string;

  estatus: string;

  isRead: boolean;

  materiales: RequerimientoMaterialMaterial[];
}
