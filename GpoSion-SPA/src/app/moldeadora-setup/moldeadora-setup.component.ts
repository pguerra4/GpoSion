import { Component, OnInit } from "@angular/core";
import { Material } from "../_models/material";
import { Molde } from "../_models/molde";
import { NumeroParte } from "../_models/numeroParte";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";
import { FormBuilder, FormGroup, Validators  } from "@angular/forms";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";


@Component({
  selector: "app-moldeadora-setup",
  templateUrl: "./moldeadora-setup.component.html",
  styleUrls: ["./moldeadora-setup.component.css"]
})
export class MoldeadoraSetupComponent implements OnInit {
  moldeadoraForm: FormGroup;
  materiales: Material[];
  moldes: Molde[];
  numerosParte: string[];
  numerosParteSolicitados: string[];

  constructor(
    private moldeadoraservice: MoldeadoraService,
    private existenciasMaterialService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadMateriales();
    this.createMoldeadoraForm();
  }

  createMoldeadoraForm() {
    this.moldeadoraForm = this.fb.group({
      moldeadoraId: [1],
      materialId: [null, Validators.required],
      moldeId: [null],
      numeroParte: [null]
    });
  }
  addMaterial() {
    alert("material!!");
  }

  loadMateriales() {
    this.existenciasMaterialService.getMateriales().subscribe(res => {
      this.materiales = res;
    });
  }

  onSelect(item: any) {
    console.log(item);
    this.moldeadoraForm.get('materialId').setValue(item.item.materialId);
    console.log(this.moldeadoraForm.value);
  }

  editMoldeadora() {}

  deleteNumeroParte(id: string) {}


}
