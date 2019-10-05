import { Component, OnInit } from "@angular/core";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { AlertifyService } from "../_services/alertify.service";
import { TurnosService } from "../_services/turnos.service";
import { Turno } from "../_models/turno";
import { ExistenciaMaterial } from "../_models/existenciaMaterial";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { UnidadMedidaService } from "../_services/unidadMedida.service";
import { UnidadMedida } from "../_models/unidadMedida";

@Component({
  selector: "app-requerimiento-material",
  templateUrl: "./requerimiento-material.component.html",
  styleUrls: ["./requerimiento-material.component.css"]
})
export class RequerimientoMaterialComponent implements OnInit {
  requerimientoForm: FormGroup;
  turnos: Turno[];
  unidadesMedida: UnidadMedida[];
  existencias: ExistenciaMaterial[];

  constructor(
    private existenciasMaterialService: ExistenciasMaterialService,
    private turnosService: TurnosService,
    private unidadMedidaService: UnidadMedidaService,
    private alertify: AlertifyService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadTurnos();
    this.loadUnidadesMedida();
    this.loadExistencias();
    this.createRequerimientoForm();
  }

  createRequerimientoForm() {
    this.requerimientoForm = this.fb.group({
      jefaLinea: ["", Validators.required],
      turnoId: [1, Validators.required],
      unidadMedidaId: [1],
      material: ["", Validators.required],
      materialId: [null, Validators.required],
      cantidad: [0]
    });
  }

  loadTurnos() {
    this.turnosService.getTurnos().subscribe(
      (res: Turno[]) => {
        this.turnos = res;
      },
      error => {
        this.alertify.error(error);
      }
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

  loadExistencias() {
    this.existenciasMaterialService.getExistenciasMaterial().subscribe(
      (res: ExistenciaMaterial[]) => {
        this.existencias = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  addRequerimiento() {}

  seleccionarMaterial(id: number, material: string) {
    this.requerimientoForm.get("material").setValue(material);
    this.requerimientoForm.get("materialId").setValue(id);
    console.log(this.requerimientoForm.get("materialId").value);
  }
}
