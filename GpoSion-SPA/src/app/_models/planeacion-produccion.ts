export interface PlaneacionProduccion {
  year: number;
  semana: number;
  noParte: string;
  cantidad: number;
  existenciaAlmacen?: number;
  existenciaProduccion?: number;
  moldeadoras?: string[];
}
