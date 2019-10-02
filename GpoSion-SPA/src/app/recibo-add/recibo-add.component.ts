import { Component, OnInit } from "@angular/core";
import { ReciboService } from "../_services/recibo.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Cliente } from "../_models/cliente";
import { ClienteService } from "../_services/cliente.service";
import { BsDatepickerConfig } from "ngx-bootstrap";

@Component({
  selector: "app-recibo-add",
  templateUrl: "./recibo-add.component.html",
  styleUrls: ["./recibo-add.component.css"]
})
export class ReciboAddComponent implements OnInit {
  reciboForm: FormGroup;
  clientes: Cliente[];
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private reciboService: ReciboService,
    private clienteService: ClienteService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    (this.bsConfig = {
      containerClass: "theme-orange"
    }),
      this.createReciboForm();
    this.loadClientes();
  }

  createReciboForm() {
    this.reciboForm = this.fb.group({
      noRecibo: ["", Validators.required],
      clienteId: [null, Validators.required],
      fechaEntrada: [""],
      transportista: [null],
      facturaAduanal: [null],
      pedimentoImportacion: [null]
    });
  }

  loadClientes() {
    this.clienteService.getClienttes().subscribe(
      (res: Cliente[]) => {
        this.clientes = res;
      },
      error => {
        console.log(error);
      }
    );
  }

  addRecibo() {
    console.log(this.reciboForm.value);
  }
}
