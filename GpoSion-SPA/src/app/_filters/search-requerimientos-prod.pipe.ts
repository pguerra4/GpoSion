import { Pipe, PipeTransform } from "@angular/core";
import { RequerimientoMaterial } from "../_models/requerimientoMaterial";

@Pipe({
  name: "searchRequerimientosProd"
})
export class SearchRequerimientosProdPipe implements PipeTransform {
  transform(
    reqs: RequerimientoMaterial[],
    searchText: string
  ): RequerimientoMaterial[] {
    return reqs.filter(
      req =>
        req.materiales.filter(
          mat =>
            mat.material
              .toLocaleLowerCase()
              .indexOf(searchText.toLocaleLowerCase()) !== -1
        ).length > 0 ||
        req.turnoDescripcion
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
