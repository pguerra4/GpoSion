import { Molde } from "./molde";
import { MaterialNumeroParte } from "./materialNumeroParte";

export interface NumeroParte {
  noParte: string;
  clienteId: number;
  cliente: string;
  peso: number;
  costo: number;
  descripcion: string;
  leyendaPieza: string;
  urlImagenPieza: string;
  materiales: MaterialNumeroParte[];
  moldes: Molde[];
}
