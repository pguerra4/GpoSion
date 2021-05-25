import { AbstractControl } from "@angular/forms";
import { ReciboService } from "../_services/recibo.service";
import { map } from "rxjs/operators";
import { Injectable } from "@angular/core";

@Injectable()
export class ValidateExistingRecibo {
  static createValidator(reciboService: ReciboService) {
    return (control: AbstractControl) => {
      return reciboService.existeRecibo(control.value).pipe(
        map(res => {
          return res ? { reciboExistente: true } : null;
        })
      );
    };
  }
}
