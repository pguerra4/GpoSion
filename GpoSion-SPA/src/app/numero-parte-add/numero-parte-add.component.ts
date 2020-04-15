import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { NumeroParte } from "../_models/numeroParte";
import { Cliente } from "../_models/cliente";
import { ClienteService } from "../_services/cliente.service";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";
import { Material } from "../_models/material";
import { Molde } from "../_models/molde";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { MoldeService } from "../_services/molde.service";
import { ValidateExistingNumeroParte } from "../_validators/async-numero-parte-existente.validator";
import { MaterialNumeroParte } from "../_models/materialNumeroParte";
import { MoldeNumeroParte } from "../_models/molde-numero-parte";

@Component({
  selector: "app-numero-parte-add",
  templateUrl: "./numero-parte-add.component.html",
  styleUrls: ["./numero-parte-add.component.css"],
})
export class NumeroParteAddComponent implements OnInit {
  numeroParteForm: FormGroup;
  numeroParte: NumeroParte;
  clientes: Cliente[];
  materialesCat: Material[];
  materiales: MaterialNumeroParte[] = new Array();
  moldesCat: Molde[];
  moldes: MoldeNumeroParte[] = new Array();

  constructor(
    private clienteService: ClienteService,
    private numeroParteService: NumeroParteService,
    private existenciaMaterialesService: ExistenciasMaterialService,
    private moldeService: MoldeService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadClientes();
    this.loadMateriales();
    this.loadMoldes();
    this.createNumeroParteForm();
  }

  createNumeroParteForm() {
    this.numeroParteForm = this.fb.group(
      {
        noParte: [
          "",
          Validators.required,
          ValidateExistingNumeroParte.createValidator(this.numeroParteService),
        ],
        clienteId: [null, Validators.required],
        descripcion: [null],
        leyendaPieza: [null],
        peso: [0.0, Validators.required],
        costo: [0.0, Validators.required],
        material: [null],
        materialId: [null],
        cantidad: [null],
        molde: [null],
        moldeId: [null],
        cavidades: [1],
      },
      { updateOn: "blur" }
    );
  }

  loadClientes() {
    this.clienteService.getClientes().subscribe(
      (res: Cliente[]) => {
        this.clientes = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadMateriales() {
    this.existenciaMaterialesService.getMateriales().subscribe(
      (res: Material[]) => {
        this.materialesCat = res;
        console.log(this.materialesCat);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadMoldes() {
    this.moldeService.getMoldes().subscribe(
      (res: Molde[]) => {
        this.moldesCat = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  onSelectMaterial(item: any) {
    this.numeroParteForm.get("materialId").setValue(item.item.materialId);
  }

  addMaterial() {
    const mat = this.materialesCat.find(
      (m) => m.materialId === this.numeroParteForm.get("materialId").value
    );
    const matnp: MaterialNumeroParte = {
      material: mat,
      cantidad: +this.numeroParteForm.get("cantidad").value,
    };

    if (this.materiales.indexOf(matnp) < 0) {
      this.materiales.push(matnp);
    }
    this.numeroParteForm.get("material").setValue(null);
    this.numeroParteForm.get("materialId").setValue(null);
    this.numeroParteForm.get("cantidad").setValue(null);
  }

  onSelectMolde(item: any) {
    // console.log(item);
    this.numeroParteForm.get("moldeId").setValue(item.item.id);
  }

  addMolde() {
    const mol = this.moldesCat.find(
      (m) => m.id === this.numeroParteForm.get("moldeId").value
    );
    const molnp: MoldeNumeroParte = {
      molde: mol,
      cavidades: +this.numeroParteForm.get("cavidades").value,
    };
    if (this.moldes.indexOf(molnp) < 0) {
      this.moldes.push(molnp);
    }

    this.numeroParteForm.get("molde").setValue(null);
    this.numeroParteForm.get("moldeId").setValue(null);
    this.numeroParteForm.get("cavidades").setValue(1);
  }

  deleteMaterial(materialId: number) {
    this.materiales.splice(
      this.materiales.findIndex((m) => m.material.materialId === materialId),
      1
    );
  }

  deleteMolde(id: number) {
    this.moldes.splice(
      this.moldes.findIndex((m) => m.molde.id === id),
      1
    );
  }

  addNumeroParte() {
    this.numeroParte = Object.assign({}, this.numeroParteForm.value);
    this.numeroParte.materiales = new Array();
    this.materiales.forEach((material) => {
      this.numeroParte.materiales.push(material);
    });
    this.numeroParte.moldes = new Array();
    this.moldes.forEach((molde) => {
      this.numeroParte.moldes.push(molde);
    });

    this.numeroParteService.addNumeroParte(this.numeroParte).subscribe(
      (res: NumeroParte) => {
        this.alertify.success("Guardado");
        this.router.navigate(["numerosParte"]);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
