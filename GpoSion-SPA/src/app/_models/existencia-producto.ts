import { LocalidadNumeroParte } from "./localidad-numero-parte";
export interface ExistenciaProducto {
  existenciaProductoId: number;
  noParte: string;
  piezasCertificadas: number;
  piezasRechazadas: number;
  ultimaModificacion: Date;
  localidades?: LocalidadNumeroParte[];
  motivo?: string;
}
