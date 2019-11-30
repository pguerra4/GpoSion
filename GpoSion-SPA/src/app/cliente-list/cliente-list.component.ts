import { Component, OnInit } from "@angular/core";
import { Cliente } from "../_models/cliente";
import { ClienteService } from "../_services/cliente.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-cliente-list",
  templateUrl: "./cliente-list.component.html",
  styleUrls: ["./cliente-list.component.css"]
})
export class ClienteListComponent implements OnInit {
  clientes: Cliente[];

  constructor(
    private clienteService: ClienteService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadClientes();
  }

  loadClientes() {
    this.clienteService.getClientes().subscribe(
      res => {
        this.clientes = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
