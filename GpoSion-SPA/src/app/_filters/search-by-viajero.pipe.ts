import { Pipe, PipeTransform } from "@angular/core";
import { Viajero } from "../_models/viajero";

@Pipe({
  name: "searchViajero"
})
export class SearchByViajeroPipe implements PipeTransform {
  transform(viajeros: Viajero[], searchText: string): Viajero[] {
    if (viajeros == null) {
      return null;
    }
    return viajeros.filter(
      v =>
        v.material
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        (v.localidad == null
          ? false
          : v.localidad
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1) ||
        v.viajero
          .toString()
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
