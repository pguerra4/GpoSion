import { Component, OnInit } from "@angular/core";
import { LocalidadNumeroParte } from "../_models/localidad-numero-parte";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-localidad-numero-parte-edit",
  templateUrl: "./localidad-numero-parte-edit.component.html",
  styleUrls: ["./localidad-numero-parte-edit.component.css"],
})
export class LocalidadNumeroParteEditComponent implements OnInit {
  localidadExistenciaForm: FormGroup;
  localidadExistencia: LocalidadNumeroParte;

  constructor(
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      // tslint:disable-next-line: no-string-literal
      this.localidadExistencia = data["localidadNumeroParte"];
      this.createLocalidadExistenciaForm();
    });
  }

  createLocalidadExistenciaForm() {
    this.localidadExistenciaForm = this.fb.group(
      {
        localidadId: [this.localidadExistencia.localidadId],
        noParte: [this.localidadExistencia.noParte, Validators.required],
        existencia: [this.localidadExistencia.existencia, Validators.required],
        rechazadas: [this.localidadExistencia.rechazadas, Validators.required],
        motivo: [null, Validators.required],
      },
      { updateOn: "blur" }
    );
  }

  editLocalidadExistencia() {
    this.localidadExistencia = Object.assign(
      {},
      this.localidadExistenciaForm.value
    );

    this.numeroParteService
      .editLocalidadNumeroParte(
        +this.route.snapshot.params["localidadId"],
        this.route.snapshot.params["noParte"],
        this.localidadExistencia
      )
      .subscribe(
        (res: LocalidadNumeroParte) => {
          this.alertify.success("Guardado");
          this.router.navigate([
            "editExistenciaProducto/" + this.localidadExistencia.noParte,
          ]);
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }
}
