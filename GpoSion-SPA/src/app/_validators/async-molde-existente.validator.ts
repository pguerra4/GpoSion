import { AbstractControl } from "@angular/forms";
import { map } from "rxjs/operators";
import { MoldeService } from "../_services/molde.service";

export class ValidateExistingMolde {
  static createValidator(moldeService: MoldeService, moldeOriginal?: string) {
    return (control: AbstractControl) => {
      if (control.value == moldeOriginal) {
        return Promise.resolve(null);
      }
      return moldeService.existeMolde(control.value).pipe(
        map(res => {
          return res ? { moldeExistente: true } : null;
        })
      );
    };
  }
}
