import { Pipe, PipeTransform } from "@angular/core";
import { Embarque } from "../_models/embarque";

@Pipe({
  name: "searchEmbarque"
})
export class SearchEmbarquePipe implements PipeTransform {
  transform(embarques: Embarque[], searchText: string): Embarque[] {
    return embarques.filter(
      e =>
        e.detallesEmbarque.filter(
          de =>
            de.noParte
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1
        ).length > 0 ||
        e.folio
          .toString()
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        e.cliente
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        (e.rechazadas ? "rechazadas" : "certificadas").indexOf(
          searchText.toLocaleLowerCase()
        ) !== -1
    );
  }
}
