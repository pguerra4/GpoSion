import { ProduccionNumeroParte } from "./produccion-numero-parte";
export interface Produccion {
  produccionId: number;
  fecha: Date;
  moldeadoraId: number;
  moldeadora: string;
  purga: number;
  colada: number;
  produccionNumerosParte: ProduccionNumeroParte[];
}
