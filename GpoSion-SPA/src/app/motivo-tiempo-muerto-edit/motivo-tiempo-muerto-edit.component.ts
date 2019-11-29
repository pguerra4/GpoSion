import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { MotivoTiempoMuerto } from "../_models/motivo-tiempo-muerto";
import { MoldeadoraService } from "../_services/moldeadora.service";

@Component({
  selector: "app-motivo-tiempo-muerto-edit",
  templateUrl: "./motivo-tiempo-muerto-edit.component.html",
  styleUrls: ["./motivo-tiempo-muerto-edit.component.css"]
})
export class MotivoTiempoMuertoEditComponent implements OnInit {
  motivo: MotivoTiempoMuerto;
  motivoForm: FormGroup;

  constructor(
    private moldeadoraService: MoldeadoraService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  createMotivoTiempoMuertoForm() {
    this.motivoForm = this.fb.group({
      motivoTiempoMuertoId: [
        this.motivo.motivoTiempoMuertoId,
        Validators.required
      ],
      motivo: [this.motivo.motivo, Validators.required]
    });
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.motivo = data["motivoTiempoMuerto"];
      this.createMotivoTiempoMuertoForm();
    });
  }

  editMotivoTiempoMuerto() {
    this.motivo = Object.assign({}, this.motivoForm.value);
    this.moldeadoraService
      .editMotivoTiempoMuerto(+this.route.snapshot.params["id"], this.motivo)
      .subscribe(
        (res: MotivoTiempoMuerto) => {
          this.alertify.success("Guardado");
          this.router.navigate(["motivostiempomuerto"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
