import { Pipe, PipeTransform } from "@angular/core";
import { Produccion } from "../_models/produccion";

@Pipe({
  name: "searchProduccion"
})
export class SearchProduccionPipe implements PipeTransform {
  transform(producciones: Produccion[], searchText?: string): Produccion[] {
    if (producciones == null) {
      return null;
    }
    return producciones.filter(
      prod =>
        prod.produccionNumerosParte.filter(
          np =>
            np.noParte
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1
        ).length > 0 ||
        prod.moldeadora
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
