import { Pipe, PipeTransform } from "@angular/core";
import { NumeroParte } from "../_models/numeroParte";

@Pipe({
  name: "searchNumeroParte"
})
export class SearchByNumeroPartePipe implements PipeTransform {
  transform(numerosParte: NumeroParte[], searchText: string): NumeroParte[] {
    return numerosParte.filter(
      np =>
        np.noParte
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        np.cliente
          .toString()
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        (np.descripcion == null
          ? false
          : np.descripcion
              .toString()
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1) ||
        (np.leyendaPieza == null
          ? false
          : np.leyendaPieza
              .toString()
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1)
    );
  }
}
