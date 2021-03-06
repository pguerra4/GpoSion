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
    if (existenciasMaterialGroup == null) {
      return null;
    }
    return existenciasMaterialGroup.filter(
      existencia =>
        existencia.material
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
