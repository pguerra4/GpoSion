import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { ReciboService } from "../_services/recibo.service";
import { AlertifyService } from "../_services/alertify.service";
import { Recibo } from "../_models/recibo";
import { ActivatedRoute, Router } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { UnidadMedida } from "../_models/unidadMedida";
import { DetalleRecibo } from "../_models/detalleRecibo";
import { ValidateExistingViajero } from "../_validators/async-viajero-existente.validator";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";

@Component({
  selector: "app-recibo-detail",
  templateUrl: "./recibo-detail.component.html",
  styleUrls: ["./recibo-detail.component.css"]
})
export class ReciboDetailComponent implements OnInit {
  @ViewChild("material", { static: true }) materialRef: ElementRef;
  reciboDetalleForm: FormGroup;
  recibo: Recibo;
  unidadesMedida: UnidadMedida[];
  detallesRecibo: DetalleRecibo[];

  constructor(
    private reciboService: ReciboService,
    private unidadMedidaService: UnidadMedidaService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private existenciasMaterialService: ExistenciasMaterialService
  ) {}

  ngOnInit() {
    this.createReciboDetalleForm();
    this.loadUnidadesMedida();
    this.loadRecibo();
  }

  createReciboDetalleForm() {
    this.reciboDetalleForm = this.fb.group(
      {
        material: ["", Validators.required],
        totalCajas: [1.0],
        cantidadPorCaja: [0.0],
        total: [0.0, Validators.required],
        viajero: [
          "",
          [Validators.required],
          [
            ValidateExistingViajero.createValidator(
              this.existenciasMaterialService
            )
          ]
        ],
        unidadMedidaId: [1],
        referencia2: [null],
        referenciaCliente: [null],
        localidad: [""]
      },
      { updateOn: "blur" }
    );
  }

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

  loadRecibo() {
    this.reciboService.getRecibo(+this.route.snapshot.params["id"]).subscribe(
      (recibo: Recibo) => {
        this.recibo = recibo;
        this.detallesRecibo = recibo.detalle;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  addDetalleRecibo() {
    let detalle: DetalleRecibo;
    detalle = Object.assign({}, this.reciboDetalleForm.value);
    detalle.reciboId = this.recibo.reciboId;
    this.detallesRecibo.push(detalle);
    this.reciboDetalleForm.reset(this.recibo);
    this.createReciboDetalleForm();
    this.materialRef.nativeElement.focus();
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

  deleteMaterial(material: any) {
    this.detallesRecibo.splice(
      this.detallesRecibo.findIndex(d => d.material === material),
      1
    );
    this.alertify.success("Material borrado");
  }

  isNumber(value: string | number): boolean {
    return value != null && !isNaN(Number(value.toString()));
  }

  addDetalles() {
    this.reciboService.addDetallesRecibo(this.detallesRecibo).subscribe(
      (res: Recibo) => {
        this.alertify.success("Guardado");
        this.router.navigate(["recibos"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
