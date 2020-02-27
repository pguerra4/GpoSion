import { Component, OnInit } from "@angular/core";
import { ExistenciaProducto } from "../_models/existencia-producto";
import { LocalidadNumeroParte } from "../_models/localidad-numero-parte";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { ActivatedRoute, Router } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Localidad } from "../_models/localidad";
import { ReciboService } from "../_services/recibo.service";

@Component({
  selector: "app-existencia-producto-edit",
  templateUrl: "./existencia-producto-edit.component.html",
  styleUrls: ["./existencia-producto-edit.component.css"]
})
export class ExistenciaProductoEditComponent implements OnInit {
  existenciaForm: FormGroup;
  existencia: ExistenciaProducto;
  localidadesNumeroParte: LocalidadNumeroParte[];
  localidades: Localidad[];

  constructor(
    private numeroParteService: NumeroParteService,
    private reciboService: ReciboService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.existencia = data["existenciaProducto"];
      this.loadLocalidadesNumeroParte();
    });
  }

  createExistenciaForm() {
    this.existenciaForm = this.fb.group(
      {
        existenciaProductoId: [
          this.existencia.existenciaProductoId,
          Validators.required
        ],
        noParte: [this.existencia.noParte, Validators.required],
        piezasCertificadas: [
          this.existencia.piezasCertificadas,
          Validators.required
        ],
        piezasRechazadas: [
          this.existencia.piezasRechazadas,
          Validators.required
        ],
        motivo: [null, Validators.required],
        localidadId: [null],
        existencia: [0]
      },
      { updateOn: "blur" }
    );
  }

  loadLocalidadesNumeroParte() {
    this.numeroParteService
      .getLocalidadesNumeroParte(this.existencia.noParte)
      .subscribe(
        (res: LocalidadNumeroParte[]) => {
          this.localidadesNumeroParte = res;
          this.loadLocalidades();
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  loadLocalidades() {
    this.reciboService.getLocalidades().subscribe(
      (res: Localidad[]) => {
        this.localidades = res;
        this.localidades = this.localidades.filter(
          l =>
            this.localidadesNumeroParte.findIndex(
              lnp => lnp.localidadId === l.localidadId
            ) === -1
        );
        this.createExistenciaForm();
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  editExistencia() {
    this.existencia = Object.assign({}, this.existenciaForm.value);

    this.numeroParteService
      .editExistencia(this.existencia.existenciaProductoId, this.existencia)
      .subscribe(
        (res: ExistenciaProducto) => {
          this.alertify.success("Guardado");
          this.router.navigate(["existenciasproducto"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  addLocalidad() {
    const lnp: LocalidadNumeroParte = {
      localidad: "",
      noParte: this.existenciaForm.get("noParte").value,
      existencia: +this.existenciaForm.get("existencia").value,
      localidadId: +this.existenciaForm.get("localidadId").value,
      motivo: this.existenciaForm.get("motivo").value
    };
    this.numeroParteService.addLocalidadNumeroParte(lnp).subscribe(
      (res: LocalidadNumeroParte) => {
        this.loadLocalidadesNumeroParte();
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
