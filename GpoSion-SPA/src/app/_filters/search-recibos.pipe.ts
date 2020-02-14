import { Pipe, PipeTransform } from "@angular/core";
import { Recibo } from "../_models/recibo";

@Pipe({
  name: "searchRecibos"
})
export class SearchRecibosPipe implements PipeTransform {
  transform(recibos: Recibo[], searchText: string): Recibo[] {
    if (recibos == null) {
      return null;
    }
    return recibos.filter(
      recibo =>
        recibo.noRecibo
          .toString()
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        recibo.proveedorNombre
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        (recibo.recibio == null
          ? false
          : recibo.recibio
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1) ||
        (recibo.transportista == null
          ? false
          : recibo.transportista
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1)
    );
  }
}
