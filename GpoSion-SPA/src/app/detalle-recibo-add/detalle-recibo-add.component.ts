import {
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild,
} from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { DetalleRecibo } from "../_models/detalleRecibo";
import { Localidad } from "../_models/localidad";
import { Material } from "../_models/material";
import { Recibo } from "../_models/recibo";
import { UnidadMedida } from "../_models/unidadMedida";
import { AlertifyService } from "../_services/alertify.service";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { ReciboService } from "../_services/recibo.service";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { ValidateExistingViajero } from "../_validators/async-viajero-existente.validator";

@Component({
  selector: "app-detalle-recibo-add",
  templateUrl: "./detalle-recibo-add.component.html",
  styleUrls: ["./detalle-recibo-add.component.css"],
})
export class DetalleReciboAddComponent implements OnInit {
  @ViewChild("material", { static: false }) materialRef: ElementRef;
  reciboDetalleForm: FormGroup;
  recibo: Recibo;
  unidadesMedida: UnidadMedida[];
  detallesRecibo: DetalleRecibo[];
  materiales: Material[];
  localidades: Localidad[];
  agregados = false;

  @HostListener("window:beforeunload", ["$event"])
  unloadNotification($event: any) {
    if (this.agregados) {
      $event.returnValue = true;
    }
  }

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
    this.loadMateriales();
    this.loadLocalidades();
    this.createReciboDetalleForm();
    this.loadUnidadesMedida();
    this.loadRecibo();
  }

  createReciboDetalleForm() {
    this.reciboDetalleForm = this.fb.group(
      {
        material: [""],
        materialId: [null, Validators.required],
        totalCajas: [1.0],
        cantidadPorCaja: [0.0],
        total: [0.0, Validators.required],
        viajero: [
          "",
          [Validators.required],
          [
            ValidateExistingViajero.createValidator(
              this.existenciasMaterialService
            ),
          ],
        ],
        unidadMedidaId: [1],
        referencia2: [null],
        noLote: [null],
        localidadId: [1],
      },
      { updateOn: "blur" }
    );
  }

  loadUnidadesMedida() {
    this.unidadMedidaService.getUnidadesMedida().subscribe(
      (res: UnidadMedida[]) => {
        this.unidadesMedida = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadMateriales() {
    this.existenciasMaterialService.getMateriales().subscribe((res) => {
      this.materiales = res;
    });
  }

  loadLocalidades() {
    this.reciboService.getLocalidades().subscribe((res) => {
      this.localidades = res;
    });
  }

  loadRecibo() {
    this.reciboService.getRecibo(+this.route.snapshot.params["id"]).subscribe(
      (recibo: Recibo) => {
        this.recibo = recibo;
        this.detallesRecibo = [];
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  onSelectMaterial(item: any) {
    this.reciboDetalleForm.get("materialId").setValue(item.item.materialId);
  }

  addDetalleRecibo() {
    let detalle: DetalleRecibo;
    detalle = Object.assign({}, this.reciboDetalleForm.value);
    detalle.reciboId = this.recibo.reciboId;
    const localidad = this.localidades.find(
      (l) => l.localidadId == detalle.localidadId
    );
    detalle.localidad = localidad.localidad;

    const detalleViajero = this.detallesRecibo.find(
      (d) => d.viajero === detalle.viajero
    );
    if (detalleViajero) {
      if (detalleViajero.localidadId !== detalle.localidadId) {
        this.alertify.warning(
          "Esta agregando al mismo viajero una localidad distinta"
        );
        return;
      } else {
        this.detallesRecibo.push(detalle);
        this.reciboDetalleForm.reset(this.recibo);
        this.createReciboDetalleForm();
        this.agregados = true;

        // this.materialRef.nativeElement.focus();
      }
    } else {
      this.detallesRecibo.push(detalle);
      this.reciboDetalleForm.reset(this.recibo);
      this.createReciboDetalleForm();
      this.agregados = true;

      // this.materialRef.nativeElement.focus();
    }
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
      this.detallesRecibo.findIndex((d) => d.material === material),
      1
    );
    if (this.detallesRecibo.length === 0) {
      this.agregados = false;
    }
    this.alertify.success("Material borrado");
  }

  isNumber(value: string | number): boolean {
    return value != null && !isNaN(Number(value.toString()));
  }

  addDetalles() {
    this.reciboService.addDetallesRecibo(this.detallesRecibo).subscribe(
      (res: Recibo) => {
        this.agregados = false;
        this.alertify.success("Guardado");
        this.router.navigate(["recibos"]);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
