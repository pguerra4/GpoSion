import { Pipe, PipeTransform } from "@angular/core";
import { MovimientoMaterial } from "../_models/movimientoMaterial";

@Pipe({
  name: "searchRetornosMaterial"
})
export class SearchRetornosMaterialPipe implements PipeTransform {
  transform(
    retornos: MovimientoMaterial[],
    searchText?: string
  ): MovimientoMaterial[] {
    if (retornos == null) {
      return null;
    }
    return retornos.filter(
      ret =>
        ret.material
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        ret.localidad
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
