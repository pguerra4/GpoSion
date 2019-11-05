import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { NumeroParte } from "../_models/numeroParte";
import { Cliente } from "../_models/cliente";
import { ClienteService } from "../_services/cliente.service";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-numero-parte-add",
  templateUrl: "./numero-parte-add.component.html",
  styleUrls: ["./numero-parte-add.component.css"]
})
export class NumeroParteAddComponent implements OnInit {
  numeroParteForm: FormGroup;
  numeroParte: NumeroParte;
  clientes: Cliente[];

  constructor(
    private clienteService: ClienteService,
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadClientes();
    this.createNumeroParteForm();
  }

  createNumeroParteForm() {
    this.numeroParteForm = this.fb.group({
      noParte: ["", Validators.required],
      clienteId: [null, Validators.required],
      descripcion: [null],
      leyendaPieza: [null],
      peso: [0.0, Validators.required],
      costo: [0.0, Validators.required]
    });
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

  addNumeroParte() {
    this.numeroParte = Object.assign({}, this.numeroParteForm.value);
    this.numeroParteService.addNumeroParte(this.numeroParte).subscribe(
      (res: NumeroParte) => {
        this.alertify.success("Guardado");
        this.router.navigate(["numerosParte"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
