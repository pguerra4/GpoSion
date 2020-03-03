import { Pipe, PipeTransform } from "@angular/core";
import { PlaneacionProduccion } from "../_models/planeacion-produccion";

@Pipe({
  name: "searchPlaneacion"
})
export class SearchPlaneacionProduccionPipe implements PipeTransform {
  transform(
    planeaciones: PlaneacionProduccion[],
    searchText?: string
  ): PlaneacionProduccion[] {
    if (planeaciones == null) {
      return null;
    }
    return planeaciones.filter(
      p =>
        p.noParte
          .toLocaleLowerCase()
          .indexOf(searchText.toLocaleLowerCase()) !== -1
    );
  }
}
