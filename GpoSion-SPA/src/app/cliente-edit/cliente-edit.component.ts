import { Component, OnInit } from "@angular/core";
import { Cliente } from "../_models/cliente";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ClienteService } from "../_services/cliente.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-cliente-edit",
  templateUrl: "./cliente-edit.component.html",
  styleUrls: ["./cliente-edit.component.css"]
})
export class ClienteEditComponent implements OnInit {
  cliente: Cliente;
  clienteForm: FormGroup;

  constructor(
    private clienteService: ClienteService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.cliente = data["cliente"];
      this.createClienteForm();
    });
  }

  createClienteForm() {
    this.clienteForm = this.fb.group({
      clienteId: [this.cliente.clienteId, Validators.required],
      cliente: [this.cliente.cliente, Validators.required],
      clave: [this.cliente.clave],
      direccion: [this.cliente.direccion],
      telefono: [this.cliente.telefono]
    });
  }

  editCliente() {
    this.cliente = Object.assign({}, this.clienteForm.value);
    this.clienteService
      .editCliente(+this.route.snapshot.params["id"], this.cliente)
      .subscribe(
        (res: Cliente) => {
          this.alertify.success("Guardado");
          this.router.navigate(["clientes"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
