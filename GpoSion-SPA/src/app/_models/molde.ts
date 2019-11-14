export interface Molde {
  id: number;
  molde: string;
  clienteId: number;
  cliente: string;
  ubicacionId: number;
  ubicacion: string;
  moldeadoraId?: number;
  moldeadora?: string;
  fechaCreacion: Date;
  ultimaModificacion: Date;
  numerosParte: string[];
}
