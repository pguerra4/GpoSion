import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { BsDatepickerConfig, BsLocaleService } from "ngx-bootstrap";
import { OrdenCompraProveedor } from "../_models/orden-compra-proveedor";
import { OrdenCompraProveedorDetalle } from "../_models/orden-compra-proveedor-detalle";
import { Material } from "../_models/material";
import { Proveedor } from "../_models/proveedor";
import { Comprador } from "../_models/comprador";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";
import { OrdenCompraProveedorService } from "../_services/orden-compra-proveedor.service";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { ProveedorService } from "../_services/proveedor.service";

@Component({
  selector: "app-orden-compra-proveedor-add",
  templateUrl: "./orden-compra-proveedor-add.component.html",
  styleUrls: ["./orden-compra-proveedor-add.component.css"]
})
export class OrdenCompraProveedorAddComponent implements OnInit {
  ordenCompraForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  detalles: OrdenCompraProveedorDetalle[] = new Array();
  ordenCompra: OrdenCompraProveedor;
  materialesCat: Material[];
  proveedores: Proveedor[];
  compradores: Comprador[];

  constructor(
    private ordenesService: OrdenCompraProveedorService,
    private existenciasService: ExistenciasMaterialService,
    private proveedorService: ProveedorService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private localeService: BsLocaleService
  ) {}

  ngOnInit() {
    (this.bsConfig = {
      dateInputFormat: "DD/MM/YYYY"
    }),
      this.localeService.use("es");
    this.loadProveedores();
    this.loadCompradores();
    this.loadMateriales();
    this.createOrdenCompraForm();
  }

  createOrdenCompraForm() {
    const now = new Date();
    this.ordenCompraForm = this.fb.group(
      {
        noOrden: [null, Validators.required],
        compradorId: [null, Validators.required],
        proveedorId: [null, Validators.required],
        condicionesCredito: [null],
        fecha: [now, Validators.required],
        fechaEntrega: [null],
        personaSolicita: [null],
        departamento: [null],
        areaProyecto: [null],
        razonCompra: [null],
        compra: [null, Validators.required],
        materialId: [null],
        material: [null],
        precio: [0],
        cantidad: [0],
        unidadMedida: [null],
        observaciones: [null]
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

  loadCompradores() {
    this.ordenesService.getCompradores().subscribe(
      (res: Comprador[]) => {
        this.compradores = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  loadMateriales() {
    this.existenciasService.getMateriales().subscribe(
      (res: Material[]) => {
        this.materialesCat = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  proveedorChange(id: number) {
    const p = this.proveedores.filter(pr => pr.proveedorId == id);
    this.ordenCompraForm
      .get("condicionesCredito")
      .setValue(p[0].condicionesCredito);
  }

  addDetalle() {
    const now = new Date();
    const detalle: OrdenCompraProveedorDetalle = {
      id: 0,
      noOrden: null,
      materialId: this.ordenCompraForm.get("materialId").value,
      material: this.ordenCompraForm.get("material").value,
      cantidad: +this.ordenCompraForm.get("cantidad").value,
      unidadMedida: this.ordenCompraForm.get("unidadMedida").value,
      precioUnitario: +this.ordenCompraForm.get("precio").value,
      precioTotal:
        +this.ordenCompraForm.get("precio").value *
        +this.ordenCompraForm.get("cantidad").value,
      observaciones: this.ordenCompraForm.get("observaciones").value,
      ultimaModificacion: now
    };

    if (this.detalles.indexOf(detalle) < 0) {
      this.detalles.push(detalle);
    }

    this.ordenCompraForm.get("materialId").setValue(null);
    this.ordenCompraForm.get("material").setValue(null);
    this.ordenCompraForm.get("cantidad").setValue(0);
    this.ordenCompraForm.get("unidadMedida").setValue(null);
    this.ordenCompraForm.get("precio").setValue(null);
    this.ordenCompraForm.get("observaciones").setValue(null);
  }

  deleteDetalle(index: number) {
    this.detalles.splice(index, 1);
  }

  addOrdenCompra() {
    this.ordenCompra = Object.assign({}, this.ordenCompraForm.value);
    this.ordenCompra.materiales = new Array();
    this.detalles.forEach(detalle => {
      this.ordenCompra.materiales.push(detalle);
    });

    // console.log(this.ordenCompra);

    this.ordenesService.addOrdenCompraProveedor(this.ordenCompra).subscribe(
      (res: OrdenCompraProveedor) => {
        this.alertify.success("Guardado");
        this.router.navigate(["ordenescompraproveedores"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  onSelectMaterial(item: any) {
    this.ordenCompraForm.get("materialId").setValue(item.item.materialId);
  }
}
