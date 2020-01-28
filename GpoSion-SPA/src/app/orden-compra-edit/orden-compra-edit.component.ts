import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { BsDatepickerConfig } from "ngx-bootstrap";
import { Cliente } from "../_models/cliente";
import { NumeroParte } from "../_models/numeroParte";
import { OrdenCompraDetalle } from "../_models/orden-compra-detalle";
import { OrdenCompra } from "../_models/orden-compra";
import { NumeroParteService } from "../_services/numeroParte.service";
import { OrdenCompraService } from "../_services/orden-compra.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-orden-compra-edit",
  templateUrl: "./orden-compra-edit.component.html",
  styleUrls: ["./orden-compra-edit.component.css"]
})
export class OrdenCompraEditComponent implements OnInit {
  ordenCompraForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  clientes: Cliente[];
  numerosParteCat: NumeroParte[];
  numerosParte: NumeroParte[];
  detalles: OrdenCompraDetalle[] = new Array();
  ordenCompra: OrdenCompra;

  constructor(
    private numeroParteService: NumeroParteService,
    private ordenesService: OrdenCompraService,
    private alertify: AlertifyService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    (this.bsConfig = {
      containerClass: "theme-orange",
      dateInputFormat: "DD/MM/YYYY"
    }),
      this.route.data.subscribe(data => {
        // tslint:disable-next-line: no-string-literal
        this.ordenCompra = data["ordenCompra"];
        this.detalles = this.ordenCompra.numerosParte;
      });
    this.loadNumerosParte();
    this.createOrdenCompraForm();
  }

  createOrdenCompraForm() {
    const now = new Date();
    this.ordenCompraForm = this.fb.group(
      {
        noOrden: [this.ordenCompra.noOrden, Validators.required],
        noParte: [null],
        precio: [null],
        cantidad: [0],
        fechaInicio: [now],
        fechaFin: [null],
        observaciones: [null, Validators.required]
      },
      { updateOn: "blur" }
    );
  }

  loadNumerosParte() {
    this.numeroParteService.getNumerosParte().subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
        this.filterNumerosParte(this.ordenCompra.clienteId);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  filterNumerosParte(clienteId: number) {
    this.numerosParteCat = this.numerosParte.filter(
      np => np.clienteId == clienteId
    );
  }

  addNumeroParte() {
    const now = new Date();
    const detalle: OrdenCompraDetalle = {
      noParte: this.ordenCompraForm.get("noParte").value,
      piezasAutorizadas: +this.ordenCompraForm.get("cantidad").value,
      precio: +this.ordenCompraForm.get("precio").value,
      fechaInicio: this.ordenCompraForm.get("fechaInicio").value,
      fechaFin: this.ordenCompraForm.get("fechaFin").value,
      id: 0,
      noOrden: +this.ordenCompraForm.get("noOrden").value,
      piezasSurtidas: 0,
      ultimaModificacion: now,
      observaciones: this.ordenCompraForm.get("observaciones").value
    };

    if (this.detalles.find(d => d.noParte == detalle.noParte) === undefined) {
      this.ordenesService.addOrdenCompraDetalle(detalle).subscribe(
        (res: OrdenCompraDetalle) => {
          this.detalles.push(res);
          this.ordenCompraForm.get("noParte").setValue(null);
          this.ordenCompraForm.get("cantidad").setValue(0);
          this.ordenCompraForm.get("precio").setValue(null);
          this.ordenCompraForm.get("fechaInicio").setValue(now);
          this.ordenCompraForm.get("fechaFin").setValue(null);
          this.ordenCompraForm.get("observaciones").setValue(null);
        },
        error => {
          this.alertify.error(error);
        }
      );
    } else {
      this.alertify.error("Numero de parte ya agregado.");
    }
  }

  deleteNumeroParte(id: number) {
    this.ordenesService.deleteOrdenCompraDetalle(id).subscribe(
      () => {
        this.detalles.splice(
          this.detalles.findIndex(d => d.id === id),
          1
        );
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  editOrdenCompra() {
    this.ordenCompra = Object.assign({}, this.ordenCompraForm.value);
    this.ordenCompra.numerosParte = new Array();
    this.detalles.forEach(detalle => {
      this.ordenCompra.numerosParte.push(detalle);
    });

    this.ordenesService
      .editOrdenCompra(+this.route.snapshot.params["id"], this.ordenCompra)
      .subscribe(
        (res: OrdenCompra) => {
          this.alertify.success("Guardado");
          this.router.navigate(["ordenescompra"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
