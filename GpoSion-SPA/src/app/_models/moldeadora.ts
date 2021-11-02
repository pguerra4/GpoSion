export interface Moldeadora {
  moldeadoraId: number;
  moldeadora: string;
  estatus: string;
  disparosPorHora?: number;
  moldeId?: number;
  molde: string;
  materialId?: number;
  material: string;
  numerosParte: string[];
  ultimaModificacion: Date;
  ultimoMotivoParo?: number;
}
