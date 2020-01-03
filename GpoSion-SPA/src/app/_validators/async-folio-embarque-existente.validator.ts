import { AbstractControl } from "@angular/forms";
import { map } from "rxjs/operators";
import { NumeroParteService } from "../_services/numeroParte.service";

export class ValidateExistingFolioEmbarque {
  static createValidator(numeroParteService: NumeroParteService) {
    return (control: AbstractControl) => {
      return numeroParteService.existeFolioEmbarque(control.value).pipe(
        map(res => {
          return res ? { folioEmbarqueExistente: true } : null;
        })
      );
    };
  }
}
