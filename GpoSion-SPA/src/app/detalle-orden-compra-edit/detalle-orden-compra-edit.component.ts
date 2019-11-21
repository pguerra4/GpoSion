import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { BsDatepickerConfig } from "ngx-bootstrap";
import { OrdenCompraDetalle } from "../_models/orden-compra-detalle";
import { OrdenCompraService } from "../_services/orden-compra.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-detalle-orden-compra-edit",
  templateUrl: "./detalle-orden-compra-edit.component.html",
  styleUrls: ["./detalle-orden-compra-edit.component.css"]
})
export class DetalleOrdenCompraEditComponent implements OnInit {
  detalleOrdenCompraForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  detalle: OrdenCompraDetalle;

  constructor(
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
        this.detalle = data["detalleOrdenCompra"];
        this.createDetalleOrdenCompraForm();
      });
  }

  createDetalleOrdenCompraForm() {
    this.detalleOrdenCompraForm = this.fb.group(
      {
        id: [this.detalle.id, Validators.required],
        noOrden: [this.detalle.noOrden, Validators.required],
        noParte: [this.detalle.noParte],
        precio: [this.detalle.precio],
        piezasAutorizadas: [this.detalle.piezasAutorizadas],
        fechaInicio: [new Date(this.detalle.fechaInicio)],
        fechaFin: [
          this.detalle.fechaFin ? new Date(this.detalle.fechaFin) : null
        ]
      },
      { updateOn: "blur" }
    );
  }

  editDetalleOrdenCompra() {
    this.detalle = Object.assign({}, this.detalleOrdenCompraForm.value);

    this.ordenesService
      .editOrdenCompraDetalle(+this.route.snapshot.params["id"], this.detalle)
      .subscribe(
        (res: OrdenCompraDetalle) => {
          this.alertify.success("Guardado");
          this.router.navigate(["ordenescompra/" + this.detalle.noOrden]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
