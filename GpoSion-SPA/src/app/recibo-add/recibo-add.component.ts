import { Component, OnInit } from "@angular/core";
import { ReciboService } from "../_services/recibo.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { BsDatepickerConfig, BsLocaleService } from "ngx-bootstrap";
import { Recibo } from "../_models/recibo";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";
import { ValidateExistingRecibo } from "../_validators/async-recibo-existente.validator";
import { Proveedor } from "../_models/proveedor";
import { ProveedorService } from "../_services/proveedor.service";

@Component({
  selector: "app-recibo-add",
  templateUrl: "./recibo-add.component.html",
  styleUrls: ["./recibo-add.component.css"]
})
export class ReciboAddComponent implements OnInit {
  reciboForm: FormGroup;
  proveedores: Proveedor[];
  bsConfig: Partial<BsDatepickerConfig>;
  recibo: Recibo;

  constructor(
    private reciboService: ReciboService,
    private proveedorService: ProveedorService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private localeService: BsLocaleService
  ) {}

  ngOnInit() {
    (this.bsConfig = {
      containerClass: "theme-orange"
    }),
      this.localeService.use("es");
    this.createReciboForm();
    this.loadProveedores();
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
        proveedorId: [null, Validators.required],
        fechaEntrada: [now],
        transportista: [null],
        facturaAduanal: [null],
        pedimentoImportacion: [null],
        recibio: [null]
      },
      { updateOn: "blur" }
    );
  }

  loadProveedores() {
    this.proveedorService.getProveedores().subscribe(
      (res: Proveedor[]) => {
        this.proveedores = res;
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
