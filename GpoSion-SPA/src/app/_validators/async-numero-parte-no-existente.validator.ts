import { AbstractControl } from "@angular/forms";
import { map } from "rxjs/operators";
import { NumeroParteService } from "../_services/numeroParte.service";

export class ValidateNotExistingNumeroParte {
  static createValidator(numeroParteService: NumeroParteService) {
    return (control: AbstractControl) => {
      return numeroParteService.existeNumeroParte(control.value).pipe(
        map((res) => {
          return res ? null : { numeroParteNoExistente: true };
        })
      );
    };
  }
}
