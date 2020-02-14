import { Pipe, PipeTransform } from "@angular/core";
import { OrdenCompra } from "../_models/orden-compra";

@Pipe({
  name: "searchOrdenesCompra"
})
export class SearchOrdenesCompraPipe implements PipeTransform {
  transform(ordenes: OrdenCompra[], searchText: string): OrdenCompra[] {
    if (ordenes == null) {
      return null;
    }
    return ordenes.filter(
      ord =>
        ord.numerosParte.filter(
          np =>
            np.noParte
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1
        ).length > 0 ||
        ord.cliente
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        ord.noOrden.toString().indexOf(searchText) !== -1
    );
  }
}
