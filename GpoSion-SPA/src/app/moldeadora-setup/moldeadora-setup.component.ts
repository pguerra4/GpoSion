import { Component, OnInit } from "@angular/core";
import { Material } from "../_models/material";
import { Molde } from "../_models/molde";
import { NumeroParte } from "../_models/numeroParte";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { AlertifyService } from "../_services/alertify.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { MoldeService } from "../_services/molde.service";
import { NumeroParteService } from "../_services/numeroParte.service";
import { Moldeadora } from "../_models/moldeadora";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-moldeadora-setup",
  templateUrl: "./moldeadora-setup.component.html",
  styleUrls: ["./moldeadora-setup.component.css"]
})
export class MoldeadoraSetupComponent implements OnInit {
  moldeadoraForm: FormGroup;
  moldeadora: Moldeadora;
  materiales: Material[];
  moldes: Molde[];
  numerosParte: NumeroParte[];
  numerosParteSolicitados: string[] = new Array();
  selectedNumeroParte: NumeroParte;

  constructor(
    private moldeadoraservice: MoldeadoraService,
    private existenciasMaterialService: ExistenciasMaterialService,
    private moldeService: MoldeService,
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.moldeadora = data["moldeadora"];
      this.numerosParteSolicitados = this.moldeadora.numerosParte;
    });
    this.loadMateriales();
    this.loadMoldes();
    this.loadNumerosParte();
    this.createMoldeadoraForm();
  }

  createMoldeadoraForm() {
    this.moldeadoraForm = this.fb.group({
      moldeadoraId: [this.moldeadora.moldeadoraId, Validators.required],
      materialId: [this.moldeadora.materialId, Validators.required],
      material: [this.moldeadora.material],
      moldeId: [this.moldeadora.moldeId],
      molde: [this.moldeadora.molde],
      numeroParte: [null],
      estatus: [
        this.moldeadora.estatus === "" ? "Operando" : this.moldeadora.estatus
      ]
    });
  }
  addNumeroParte() {
    this.numerosParteSolicitados.push(this.selectedNumeroParte.noParte);
    console.log(this.numerosParteSolicitados);
  }

  loadMateriales() {
    this.existenciasMaterialService.getMateriales().subscribe(res => {
      this.materiales = res;
    });
  }

  loadMoldes() {
    this.moldeService.getMoldes().subscribe(res => {
      this.moldes = res;
    });
  }

  loadNumerosParte() {
    this.numeroParteService.getNumerosParte().subscribe(res => {
      this.numerosParte = res;
    });
  }

  onSelectMaterial(item: any) {
    this.moldeadoraForm.get("materialId").setValue(item.item.materialId);
    console.log(this.moldeadoraForm.value);
  }

  onSelectMolde(item: any) {
    console.log(item);
    this.moldeadoraForm.get("moldeId").setValue(item.item.id);
    console.log(this.moldeadoraForm.value);
  }

  onSelectNumeroParte(item: any) {
    this.selectedNumeroParte = item.item;
    console.log(this.selectedNumeroParte);
  }

  editMoldeadora() {}

  deleteNumeroParte(id: string) {
    this.numerosParteSolicitados.splice(
      this.numerosParteSolicitados.indexOf(id),
      1
    );
  }
}
