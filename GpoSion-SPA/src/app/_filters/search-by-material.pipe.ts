import { Pipe, PipeTransform } from "@angular/core";
import { Material } from "../_models/material";

@Pipe({
  name: "searchByMaterial"
})
export class SearchByMaterialPipe implements PipeTransform {
  transform(materiales: Material[], searchText: string): Material[] {
    return materiales.filter(
      material =>
        material.material
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        material.descripcion
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1 ||
        material.tipoMaterial
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
