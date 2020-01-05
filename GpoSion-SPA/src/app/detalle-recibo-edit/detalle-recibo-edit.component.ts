import { Component, OnInit } from "@angular/core";
import { ReciboService } from "../_services/recibo.service";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute, Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { DetalleRecibo } from "../_models/detalleRecibo";
import { UnidadMedida } from "../_models/unidadMedida";
import { ValidateExistingViajero } from "../_validators/async-viajero-existente.validator";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";

@Component({
  selector: "app-detalle-recibo-edit",
  templateUrl: "./detalle-recibo-edit.component.html",
  styleUrls: ["./detalle-recibo-edit.component.css"]
})
export class DetalleReciboEditComponent implements OnInit {
  detalleRecibo: DetalleRecibo;
  reciboDetalleForm: FormGroup;
  unidadesMedida: UnidadMedida[];

  constructor(
    private reciboService: ReciboService,
    private unidadMedidaService: UnidadMedidaService,
    private existenciasService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.detalleRecibo = data["detalleRecibo"];
      this.loadUnidadesMedida();
      this.createReciboDetalleForm();
    });
  }

  createReciboDetalleForm() {
    this.reciboDetalleForm = this.fb.group(
      {
        detalleReciboId: [this.detalleRecibo.detalleReciboId],
        materialId: [this.detalleRecibo.materialId],
        totalCajas: [this.detalleRecibo.totalCajas],
        cantidadPorCaja: [this.detalleRecibo.cantidadPorCaja],
        total: [this.detalleRecibo.total, Validators.required],
        viajero: [
          this.detalleRecibo.viajero,
          [],
          [
            ValidateExistingViajero.createValidator(
              this.existenciasService,
              this.detalleRecibo.viajero
            )
          ]
        ],
        unidadMedidaId: [this.detalleRecibo.unidadMedidaId],
        referencia2: [this.detalleRecibo.referencia2],
        referenciaCliente: [this.detalleRecibo.referenciaCliente],
        localidad: [this.detalleRecibo.localidad]
      },
      { updateOn: "blur" }
    );
  }

  // loadDetalleRecibo() {
  //   this.reciboService
  //     .getDetalleRecibo(+this.route.snapshot.params["id"])
  //     .subscribe(
  //       (detalleRecibo: DetalleRecibo) => {
  //         this.detalleRecibo = detalleRecibo;
  //       },
  //       error => {
  //         this.alertify.error(error);
  //       }
  //     );
  // }

  loadUnidadesMedida() {
    this.unidadMedidaService.getUnidadesMedida().subscribe(
      (res: UnidadMedida[]) => {
        this.unidadesMedida = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  editDetalleRecibo() {
    let detalle: any;
    detalle = Object.assign({}, this.reciboDetalleForm.value);
    if (detalle.viajero === "" || detalle.viajero === null) {
      detalle.viajero = 0;
    }
    detalle.reciboId = this.detalleRecibo.reciboId;
    this.reciboService
      .editDetallesRecibo(+this.route.snapshot.params["id"], detalle)
      .subscribe(
        (detalleRecibo: DetalleRecibo) => {
          this.alertify.success("Guardado");
          this.router.navigate(["recibos"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  calculaTotal() {
    const tc = +this.reciboDetalleForm.get("totalCajas").value;
    const cpc = +this.reciboDetalleForm.get("cantidadPorCaja").value;

    if (this.isNumber(tc) && this.isNumber(cpc)) {
      this.reciboDetalleForm.get("total").setValue(tc * cpc);
    } else {
      this.reciboDetalleForm.get("total").setValue(0);
    }
  }

  isNumber(value: string | number): boolean {
    return value != null && !isNaN(Number(value.toString()));
  }
}
