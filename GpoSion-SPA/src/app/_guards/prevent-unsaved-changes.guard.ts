import { Injectable } from "@angular/core";
import { CanDeactivate } from "@angular/router";
import { ReciboDetailComponent } from "../recibo-detail/recibo-detail.component";

@Injectable()
export class PreventUnsavedChanges
  implements CanDeactivate<ReciboDetailComponent> {
  canDeactivate(component: ReciboDetailComponent) {
    if (component.agregados) {
      return confirm(
        "¿Seguro que desea salir de la forma? No se ha guardado aún el recibo."
      );
    }
    return true;
  }
}
