import { Pipe, PipeTransform } from "@angular/core";
import { OrdenCompraProveedor } from "../_models/orden-compra-proveedor";

@Pipe({
  name: "searchOrdenCompraProveedor"
})
export class SearchOrdenCompraProveedorPipe implements PipeTransform {
  transform(
    ordenes: OrdenCompraProveedor[],
    searchText: string
  ): OrdenCompraProveedor[] {
    return ordenes.filter(
      ord =>
        ord.materiales.filter(
          np =>
            np.material
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1
        ).length > 0 ||
        ord.proveedor
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        ord.comprador
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        ord.noOrden.indexOf(searchText) !== -1
    );
  }
}
