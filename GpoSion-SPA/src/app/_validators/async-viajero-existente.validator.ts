import { AbstractControl } from "@angular/forms";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { map } from "rxjs/operators";

export class ValidateExistingViajero {
  static createValidator(
    existenciasMaterialService: ExistenciasMaterialService
  ) {
    return (control: AbstractControl) => {
      return existenciasMaterialService.getViajero(control.value).pipe(
        map(res => {
          return res ? { viajeroExistente: true } : null;
        })
      );
    };
  }
}
