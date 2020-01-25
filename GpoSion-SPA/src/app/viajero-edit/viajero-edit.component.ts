import { Component, OnInit } from "@angular/core";
import { Viajero } from "../_models/viajero";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Localidad } from "../_models/localidad";
import { ReciboService } from "../_services/recibo.service";

@Component({
  selector: "app-viajero-edit",
  templateUrl: "./viajero-edit.component.html",
  styleUrls: ["./viajero-edit.component.css"]
})
export class ViajeroEditComponent implements OnInit {
  viajero: Viajero;
  viajeroForm: FormGroup;
  localidades: Localidad[];

  constructor(
    private fb: FormBuilder,
    private alertify: AlertifyService,
    private router: Router,
    private existenciasService: ExistenciasMaterialService,
    private reciboService: ReciboService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadLocalidades();
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.viajero = data["viajero"];
      this.createViajeroForm();
    });
  }

  createViajeroForm() {
    this.viajeroForm = this.fb.group({
      existencia: [this.viajero.existencia, Validators.required],
      localidadId: [this.viajero.localidadId],
      motivoMovimiento: ["", Validators.required]
    });
  }

  loadLocalidades() {
    this.reciboService.getLocalidades().subscribe(res => {
      this.localidades = res;
    });
  }

  editViajero() {
    const v: Viajero = Object.assign({}, this.viajeroForm.value);
    this.viajero.existencia = v.existencia;
    this.viajero.localidadId = v.localidadId;
    this.viajero.motivoMovimiento = v.motivoMovimiento;
    this.existenciasService
      .editViajero(+this.route.snapshot.params["id"], this.viajero)
      .subscribe(
        (res: any) => {
          this.alertify.success("Guardado");
          this.router.navigate(["viajeros"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
