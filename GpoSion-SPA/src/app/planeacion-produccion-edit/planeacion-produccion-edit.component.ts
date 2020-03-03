import { Component, OnInit } from "@angular/core";
import { PlaneacionProduccion } from "../_models/planeacion-produccion";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { NumeroParte } from "../_models/numeroParte";
import { ProduccionService } from "../_services/produccion.service";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { DatePipe } from "@angular/common";
import { BsLocaleService } from "ngx-bootstrap";

@Component({
  selector: "app-planeacion-produccion-edit",
  templateUrl: "./planeacion-produccion-edit.component.html",
  styleUrls: ["./planeacion-produccion-edit.component.css"]
})
export class PlaneacionProduccionEditComponent implements OnInit {
  planeacion: PlaneacionProduccion;
  planeacionForm: FormGroup;
  numerosParte: NumeroParte[];

  constructor(
    private produccionService: ProduccionService,
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.planeacion = data["planeacion"];
      this.createPlaneacionForm();
    });
  }

  createPlaneacionForm() {
    this.planeacionForm = this.fb.group(
      {
        year: [this.planeacion.year, Validators.required],
        semana: [this.planeacion.semana, Validators.required],
        noParte: [this.planeacion.noParte, Validators.required],
        cantidad: [this.planeacion.cantidad, Validators.required]
      },
      { updateOn: "blur" }
    );
  }

  editPlaneacion() {
    this.planeacion = Object.assign({}, this.planeacionForm.value);
    this.produccionService
      .editPlaneacion(
        +this.route.snapshot.params["año"],
        +this.route.snapshot.params["semana"],
        this.route.snapshot.params["noParte"],
        this.planeacion
      )
      .subscribe(
        (res: PlaneacionProduccion) => {
          this.alertify.success("Guardado");
          this.router.navigate(["planeacionproduccion"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  // getDateOfISOWeek(w, y) {
  //   const simple = new Date(y, 0, 1 + (w - 1) * 7);
  //   const dow = simple.getDay();
  //   const ISOweekStart = simple;
  //   if (dow <= 4) {
  //     ISOweekStart.setDate(simple.getDate() - simple.getDay() + 1);
  //   } else {
  //     ISOweekStart.setDate(simple.getDate() + 8 - simple.getDay());
  //   }
  //   return ISOweekStart;
  // }
}
