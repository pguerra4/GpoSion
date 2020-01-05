import { AbstractControl } from "@angular/forms";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { map } from "rxjs/operators";
import { promise } from "protractor";

export class ValidateExistingViajero {
  static createValidator(
    existenciasMaterialService: ExistenciasMaterialService,
    viajeroOriginal?: number
  ) {
    return (control: AbstractControl) => {
      console.log(viajeroOriginal + " " + control.value);
      if (control.value == viajeroOriginal) {
        return Promise.resolve(null);
      }
      let v = control.value;
      if (v === "") {
        v = 0;
      }
      return existenciasMaterialService.getViajero(v).pipe(
        map(res => {
          return res ? { viajeroExistente: true } : null;
        })
      );
    };
  }
}
