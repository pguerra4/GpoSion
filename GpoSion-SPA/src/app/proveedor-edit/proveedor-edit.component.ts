import { Component, OnInit } from "@angular/core";
import { Proveedor } from "../_models/proveedor";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ProveedorService } from "../_services/proveedor.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-proveedor-edit",
  templateUrl: "./proveedor-edit.component.html",
  styleUrls: ["./proveedor-edit.component.css"]
})
export class ProveedorEditComponent implements OnInit {
  proveedor: Proveedor;
  proveedorForm: FormGroup;

  constructor(
    private proveedorService: ProveedorService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.proveedor = data["proveedor"];
      this.createProveedorForm();
    });
  }

  createProveedorForm() {
    this.proveedorForm = this.fb.group({
      proveedorId: [this.proveedor.proveedorId, Validators.required],
      nombre: [this.proveedor.nombre, Validators.required],
      direccion: [this.proveedor.direccion],
      telefono: [this.proveedor.telefono]
    });
  }

  editProveedor() {
    this.proveedor = Object.assign({}, this.proveedorForm.value);
    this.proveedorService
      .editProveedor(+this.route.snapshot.params["id"], this.proveedor)
      .subscribe(
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
