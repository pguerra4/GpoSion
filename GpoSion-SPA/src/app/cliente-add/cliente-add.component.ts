import { Component, OnInit } from "@angular/core";
import { Cliente } from "../_models/cliente";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ClienteService } from "../_services/cliente.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-cliente-add",
  templateUrl: "./cliente-add.component.html",
  styleUrls: ["./cliente-add.component.css"]
})
export class ClienteAddComponent implements OnInit {
  cliente: Cliente;
  clienteForm: FormGroup;

  constructor(
    private clienteService: ClienteService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.createClienteForm();
  }

  createClienteForm() {
    this.clienteForm = this.fb.group({
      cliente: ["", Validators.required],
      clave: [""],
      direccion: [""],
      telefono: [""]
    });
  }

  addCliente() {
    this.cliente = Object.assign({}, this.clienteForm.value);
    this.clienteService.addCliente(this.cliente).subscribe(
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
