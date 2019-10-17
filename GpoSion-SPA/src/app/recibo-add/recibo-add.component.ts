import { Component, OnInit } from "@angular/core";
import { ReciboService } from "../_services/recibo.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Cliente } from "../_models/cliente";
import { ClienteService } from "../_services/cliente.service";
import { BsDatepickerConfig } from "ngx-bootstrap";
import { Recibo } from "../_models/recibo";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";
import { ValidateExistingRecibo } from "../_validators/async-recibo-existente.validator";

@Component({
  selector: "app-recibo-add",
  templateUrl: "./recibo-add.component.html",
  styleUrls: ["./recibo-add.component.css"]
})
export class ReciboAddComponent implements OnInit {
  reciboForm: FormGroup;
  clientes: Cliente[];
  bsConfig: Partial<BsDatepickerConfig>;
  recibo: Recibo;

  constructor(
    private reciboService: ReciboService,
    private clienteService: ClienteService,
    private alertify: AlertifyService,
    private router: Router,
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
    const now = new Date();
    this.reciboForm = this.fb.group(
      {
        noRecibo: [
          "",
          Validators.required,
          ValidateExistingRecibo.createValidator(this.reciboService)
        ],
        clienteId: [null, Validators.required],
        fechaEntrada: [now],
        transportista: [null],
        facturaAduanal: [null],
        pedimentoImportacion: [null],
        recibio: [null]
      },
      { updateOn: "blur" }
    );
  }

  loadClientes() {
    this.clienteService.getClientes().subscribe(
      (res: Cliente[]) => {
        this.clientes = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  addRecibo() {
    this.recibo = Object.assign({}, this.reciboForm.value);
    this.reciboService.addRecibo(this.recibo).subscribe(
      (res: Recibo) => {
        this.alertify.success("Guardado");
        this.router.navigate(["recibos/" + res.reciboId]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
