import { AbstractControl } from "@angular/forms";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { map } from "rxjs/operators";
import { Injectable } from "@angular/core";

@Injectable()
export class ValidateExistingMaterial {
  static createValidator(
    existenciasMaterialService: ExistenciasMaterialService,
    id: number
  ) {
    return (control: AbstractControl) => {
      return existenciasMaterialService.existeMaterial(id, control.value).pipe(
        map(res => {
          return res ? { materialExistente: true } : null;
        })
      );
    };
  }
}
