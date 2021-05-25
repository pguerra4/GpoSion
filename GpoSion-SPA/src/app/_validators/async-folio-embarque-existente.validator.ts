import { AbstractControl } from "@angular/forms";
import { map } from "rxjs/operators";
import { NumeroParteService } from "../_services/numeroParte.service";
import { Injectable } from "@angular/core";

@Injectable()
export class ValidateExistingFolioEmbarque {
  static createValidator(
    numeroParteService: NumeroParteService,
    folioOriginal?: number
  ) {
    return (control: AbstractControl) => {
      if (control.value == folioOriginal) {
        return Promise.resolve(null);
      }
      return numeroParteService.existeFolioEmbarque(control.value).pipe(
        map(res => {
          return res ? { folioEmbarqueExistente: true } : null;
        })
      );
    };
  }
}
