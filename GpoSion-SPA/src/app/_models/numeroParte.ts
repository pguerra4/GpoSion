import { Material } from "./material";
import { Molde } from "./molde";

export interface NumeroParte {
  noParte: string;
  clienteId: number;
  cliente: string;
  peso: number;
  costo: number;
  descripcion: string;
  leyendaPieza: string;
  urlImagenPieza: string;
  materiales: Material[];
  moldes: Molde[];
}
