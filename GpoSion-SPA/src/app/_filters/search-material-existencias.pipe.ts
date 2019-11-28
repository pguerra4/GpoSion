import { Pipe, PipeTransform } from "@angular/core";
import { ExistenciaMaterial } from "../_models/existenciaMaterial";

@Pipe({
  name: "searchMaterialExistencias"
})
export class SearchMaterialExistenciasPipe implements PipeTransform {
  transform(
    existenaciasMaterial: ExistenciaMaterial[],
    searchText: string
  ): ExistenciaMaterial[] {
    return existenaciasMaterial.filter(
      existencia =>
        existencia.material
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        existencia.numerosParte.filter(
          np =>
            np.toLocaleLowerCase().indexOf(searchText.toLocaleLowerCase()) !==
            -1
        ).length > 0
    );
  }
}
