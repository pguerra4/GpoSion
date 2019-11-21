import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  TemplateRef
} from "@angular/core";
import { Moldeadora } from "../_models/moldeadora";
import { environment } from "src/environments/environment";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";
import { BsModalService, BsModalRef } from "ngx-bootstrap";

@Component({
  selector: "app-moldeadora-card",
  templateUrl: "./moldeadora-card.component.html",
  styleUrls: ["./moldeadora-card.component.css"]
})
export class MoldeadoraCardComponent implements OnInit {
  @Input() moldeadora: Moldeadora;
  @Output("update") update = new EventEmitter();
  modalRef: BsModalRef;
  numerosParte: string[];
  baseUrl = environment.apiUrl;

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService,
    private modalService: BsModalService
  ) {}

  ngOnInit() {
    this.baseUrl = environment.apiUrl;
  }

  detenerMoldeadora() {
    this.moldeadoraService
      .detenerMoldeadora(this.moldeadora.moldeadoraId)
      .subscribe(
        (res: any) => {
          this.alertify.success("Detenida");
          this.update.emit();
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
  arrancarMoldeadora() {
    this.moldeadoraService
      .arrancarMoldeadora(this.moldeadora.moldeadoraId)
      .subscribe(
        (res: any) => {
          this.alertify.success("Operando");
          this.update.emit();
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: "modal-md" });
  }

  confirm(): void {
    this.detenerMoldeadora();
    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }
}
