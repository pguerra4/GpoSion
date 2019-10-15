import { Pipe, PipeTransform } from "@angular/core";
import { ExistenciaMaterialGroup } from "../_models/existencia-material-group";

@Pipe({
  name: "searchByMaterialeg"
})
export class SearchByMaterialExistenciasGroupPipe implements PipeTransform {
  transform(
    existenciasMaterialGroup: ExistenciaMaterialGroup[],
    searchText: string
  ): ExistenciaMaterialGroup[] {
    return existenciasMaterialGroup.filter(
      existencia =>
        existencia.material
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        existencia.cliente
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
