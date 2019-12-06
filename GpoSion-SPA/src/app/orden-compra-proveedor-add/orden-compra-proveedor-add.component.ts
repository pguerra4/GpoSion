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
import pdfMake from "pdfmake/build/pdfmake";
import pdfFonts from "pdfmake/build/vfs_fonts";
pdfMake.vfs = pdfFonts.pdfMake.vfs;

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
        this.generatePdf();
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

  generatePdf() {
    const documentDefinition = this.getDocumentDefinition();
    pdfMake.createPdf(documentDefinition).open();
  }

  getDocumentDefinition() {
    sessionStorage.setItem("ordenCompra", JSON.stringify(this.ordenCompra));
    return {
      content: [
        {
          columns: [
            [
              {
                text: this.compradores.filter(
                  c => c.compradorId == this.ordenCompra.compradorId
                )[0].nombre,
                style: "name"
              },
              {
                text: this.compradores.filter(
                  c => c.compradorId == this.ordenCompra.compradorId
                )[0].direccion
              }
            ],
            []
          ]
        },
        {
          text: "Purchase Order",
          style: "header"
        },
        this.getDetallesObject(this.ordenCompra.materiales)
      ],
      info: {
        title: this.ordenCompra.noOrden,
        author: "Yo",
        subject: "Purchase Order",
        keywords: "PO, PURCHASE ORDER, ORDEN DE COMPRA"
      },
      styles: {
        header: {
          fontSize: 18,
          bold: true,
          margin: [0, 20, 0, 10],
          decoration: "underline"
        },
        name: {
          fontSize: 16,
          bold: true
        },
        jobTitle: {
          fontSize: 14,
          bold: true,
          italics: true
        },
        sign: {
          margin: [0, 50, 0, 10],
          alignment: "right",
          italics: true
        },
        tableHeader: {
          bold: true
        }
      }
    };
  }

  getDetallesObject(detalles: OrdenCompraProveedorDetalle[]) {
    return {
      table: {
        widths: ["*", "*", "*", "*", "*"],
        body: [
          [
            {
              text: "QUANTITY",
              style: "tableHeader"
            },
            {
              text: "UOM",
              style: "tableHeader"
            },
            {
              text: "DESCRIPTION",
              style: "tableHeader"
            },
            {
              text: "UNIT PRICE",
              style: "tableHeader"
            },
            {
              text: "TOTAL Price",
              style: "tableHeader"
            }
          ],
          ...detalles.map(ed => {
            return [
              ed.cantidad,
              ed.unidadMedida,
              ed.material,
              ed.precioUnitario,
              ed.precioTotal
            ];
          })
        ]
      }
    };
  }
}
