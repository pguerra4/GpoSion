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
import { ActivatedRoute, Router } from "@angular/router";

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
  molde: Molde;
  numerosParte: NumeroParte[];
  numerosParteSolicitados: string[] = new Array();
  selectedNumeroParte: NumeroParte;
  materialParams: any = {};

  constructor(
    private moldeadoraService: MoldeadoraService,
    private existenciasMaterialService: ExistenciasMaterialService,
    private moldeService: MoldeService,
    private numeroParteService: NumeroParteService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.moldeadora = data["moldeadora"];
      this.numerosParteSolicitados = this.moldeadora.numerosParte;
    });

    this.loadMoldes();
    this.materialParams.tipo = 1;
    this.loadMateriales();
    // this.loadNumerosParte();
    this.createMoldeadoraForm();
  }

  createMoldeadoraForm() {
    this.moldeadoraForm = this.fb.group({
      moldeadoraId: [this.moldeadora.moldeadoraId, Validators.required],
      materialId: [this.moldeadora.materialId, Validators.required],
      material: [this.moldeadora.material],
      moldeId: [this.moldeadora.moldeId, Validators.required],
      molde: [this.moldeadora.molde],
      estatus: [
        this.moldeadora.estatus === "" ? "Operando" : this.moldeadora.estatus
      ]
    });
  }
  addNumeroParte() {
    this.numerosParteSolicitados.push(this.selectedNumeroParte.noParte);
  }

  loadMateriales() {
    this.existenciasMaterialService
      .getMateriales(this.materialParams)
      .subscribe(res => {
        this.materiales = res;
      });
  }

  loadMoldes() {
    this.moldeService.getMoldes().subscribe(res => {
      this.moldes = res;
    });
  }

  // loadNumerosParte() {
  //   this.numeroParteService.getNumerosParte().subscribe(res => {
  //     this.numerosParte = res;
  //   });
  // }

  onSelectMaterial(item: any) {
    this.moldeadoraForm.get("materialId").setValue(item.item.materialId);
  }

  onSelectMolde(item: any) {
    this.moldeadoraForm.get("moldeId").setValue(item.item.id);
    this.moldeService.getMolde(item.item.id).subscribe(res => {
      this.molde = res;
      this.numerosParteSolicitados = this.molde.numerosParte;
      this.filterMateriales();
    });
  }

  filterMateriales() {
    this.materiales.length = 0;
    this.numerosParteSolicitados.forEach(np => {
      this.numeroParteService.getNumeroParte(np).subscribe(
        res => {
          res.materiales.forEach(mat => {
            if (
              this.materiales.find(
                m => m.materialId === mat.material.materialId
              ) === undefined
            ) {
              if (mat.material.tipoMaterialId === 1) {
                this.materiales.push(mat.material);
              }
            }
          });
        },
        error => {
          this.alertify.error(error);
        },
        () => {
          if (this.materiales.length === 1) {
            this.moldeadoraForm
              .get("materialId")
              .setValue(this.materiales[0].materialId);
            this.moldeadoraForm
              .get("material")
              .setValue(this.materiales[0].material);
          }
        }
      );
    });
  }

  onSelectNumeroParte(item: any) {
    this.selectedNumeroParte = item.item;
  }

  editMoldeadora() {
    this.moldeadora = Object.assign({}, this.moldeadoraForm.value);
    this.moldeadora.numerosParte = this.numerosParteSolicitados;
    this.moldeadoraService
      .editMoldeadora(+this.route.snapshot.params["id"], this.moldeadora)
      .subscribe(
        (res: Moldeadora) => {
          this.alertify.success("Guardado");
          this.router.navigate(["moldeadoras"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  deleteNumeroParte(id: string) {
    this.numerosParteSolicitados.splice(
      this.numerosParteSolicitados.indexOf(id),
      1
    );
    this.filterMateriales();
  }
}
