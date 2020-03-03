import { Component, OnInit } from "@angular/core";
import { PlaneacionProduccion } from "../_models/planeacion-produccion";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ProduccionService } from "../_services/produccion.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";
import { DatePipe } from "@angular/common";
import { BsLocaleService } from "ngx-bootstrap";
import { NumeroParte } from "../_models/numeroParte";
import { NumeroParteService } from "../_services/numeroParte.service";

@Component({
  selector: "app-planeacion-produccion-add",
  templateUrl: "./planeacion-produccion-add.component.html",
  styleUrls: ["./planeacion-produccion-add.component.css"]
})
export class PlaneacionProduccionAddComponent implements OnInit {
  planeacion: PlaneacionProduccion;
  planeacionForm: FormGroup;
  numerosParte: NumeroParte[];
  bsValue = new Date();

  constructor(
    private produccionService: ProduccionService,
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private datePipe: DatePipe,
    private localeService: BsLocaleService
  ) {
    this.bsValue.setDate(this.bsValue.getDate());
  }

  ngOnInit() {
    this.localeService.use("es");
    this.loadNumerosParte();
    this.createPlaneacionForm();
  }

  createPlaneacionForm() {
    this.planeacionForm = this.fb.group(
      {
        fecha: [this.bsValue],
        year: [this.bsValue.getFullYear(), Validators.required],
        semana: [
          this.datePipe.transform(this.bsValue, "w"),
          Validators.required
        ],
        noParte: [null, Validators.required],
        cantidad: [null, Validators.required]
      },
      { updateOn: "blur" }
    );
  }

  onValueChange(value: Date) {
    if (value) {
      this.planeacionForm
        .get("semana")
        .setValue(this.datePipe.transform(value, "w"));
      this.planeacionForm.get("year").setValue(value.getFullYear());
    }
  }

  loadNumerosParte() {
    this.numeroParteService.getNumerosParte().subscribe(
      (res: NumeroParte[]) => {
        this.numerosParte = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  addPlaneacion() {
    this.planeacion = Object.assign({}, this.planeacionForm.value);
    this.produccionService.addPlaneacion(this.planeacion).subscribe(
      (res: PlaneacionProduccion) => {
        this.alertify.success("Guardado");
        this.router.navigate(["planeacionproduccion"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
