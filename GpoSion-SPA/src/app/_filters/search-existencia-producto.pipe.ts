import { Pipe, PipeTransform } from "@angular/core";
import { ExistenciaProducto } from "../_models/existencia-producto";

@Pipe({
  name: "searchExistenciaProducto"
})
export class SearchExistenciaProductoPipe implements PipeTransform {
  transform(
    existencias: ExistenciaProducto[],
    searchText: string
  ): ExistenciaProducto[] {
    return existencias.filter(
      e =>
        e.noParte
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
