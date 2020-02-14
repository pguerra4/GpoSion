import { AbstractControl } from "@angular/forms";
import { map } from "rxjs/operators";
import { OrdenCompraService } from "../_services/orden-compra.service";

export class ValidateExistingNumeroOrden {
  static createValidator(
    ordenCompraService: OrdenCompraService,
    noOrden?: number
  ) {
    return (control: AbstractControl) => {
      if (control.value == noOrden) {
        return Promise.resolve(null);
      }
      return ordenCompraService.existeNoOrden(control.value).pipe(
        map(res => {
          return res ? { numeroOrdenExistente: true } : null;
        })
      );
    };
  }
}
