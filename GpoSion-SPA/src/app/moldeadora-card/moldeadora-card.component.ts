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
import { timer, Subscription } from "rxjs";

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
  ticks = 0;
  minutesDisplay = 0;
  hoursDisplay = 0;
  secondsDisplay = 0;
  private sub: Subscription;

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService,
    private modalService: BsModalService
  ) {}

  ngOnInit() {
    this.baseUrl = environment.apiUrl;
    if (
      this.moldeadora.estatus === "Detenida" &&
      this.moldeadora.numerosParte.length > 0
    ) {
      const timer1 = timer(1, 1000);
      this.sub = timer1.subscribe(t => {
        this.ticks = t;
        this.secondsDisplay = this.getSeconds(this.ticks);
        this.minutesDisplay = this.getMinutes(this.ticks);
        this.hoursDisplay = this.getHours(this.ticks);
        console.log(this.ticks);
      });
    }
  }

  detenerMoldeadora() {
    this.moldeadoraService
      .detenerMoldeadora(this.moldeadora.moldeadoraId)
      .subscribe(
        res => {
          this.alertify.success("Detenida");
          this.update.emit();
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
  arrancarMoldeadora() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
    this.moldeadoraService
      .arrancarMoldeadora(this.moldeadora.moldeadoraId)
      .subscribe(
        res => {
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

  private getSeconds(ticks: number) {
    return this.pad(ticks % 60);
  }

  private getMinutes(ticks: number) {
    return this.pad(Math.floor(ticks / 60) % 60);
  }

  private getHours(ticks: number) {
    return this.pad(Math.floor(ticks / 60 / 60));
  }

  private pad(digit: any) {
    return digit <= 9 ? "0" + digit : digit;
  }
}
