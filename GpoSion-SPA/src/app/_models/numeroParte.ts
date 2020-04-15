import { MaterialNumeroParte } from "./materialNumeroParte";
import { MoldeNumeroParte } from "./molde-numero-parte";

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
  moldes: MoldeNumeroParte[];
}
