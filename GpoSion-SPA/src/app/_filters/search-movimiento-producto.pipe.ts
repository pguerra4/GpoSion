import { Pipe, PipeTransform } from "@angular/core";
import { MovimientoProducto } from "../_models/movimiento-producto";

@Pipe({
  name: "searchMovimientoProducto"
})
export class SearchMovimientoProductoPipe implements PipeTransform {
  transform(
    movimientos: MovimientoProducto[],
    searchText: string
  ): MovimientoProducto[] {
    if (movimientos == null) {
      return null;
    }
    return movimientos.filter(
      m =>
        m.noParte
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        m.localidad
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
