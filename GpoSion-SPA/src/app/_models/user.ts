export interface User {
  id: string;
  userName: string;
  password: string;
  nombre: string;
  paterno: string;
  materno: string;
  roles?: string[];
}
