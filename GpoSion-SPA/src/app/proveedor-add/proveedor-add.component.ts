import { Component, OnInit } from "@angular/core";
import { Proveedor } from "../_models/proveedor";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { ProveedorService } from "../_services/proveedor.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-proveedor-add",
  templateUrl: "./proveedor-add.component.html",
  styleUrls: ["./proveedor-add.component.css"]
})
export class ProveedorAddComponent implements OnInit {
  proveedor: Proveedor;
  proveedorForm: FormGroup;

  constructor(
    private proveedorService: ProveedorService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.createProveedorForm();
  }

  createProveedorForm() {
    this.proveedorForm = this.fb.group({
      nombre: ["", Validators.required],
      direccion: [""],
      telefono: [""]
    });
  }

  addProveedor() {
    this.proveedor = Object.assign({}, this.proveedorForm.value);
    this.proveedorService.addProveedor(this.proveedor).subscribe(
      (res: Proveedor) => {
        this.alertify.success("Guardado");
        this.router.navigate(["proveedores"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
