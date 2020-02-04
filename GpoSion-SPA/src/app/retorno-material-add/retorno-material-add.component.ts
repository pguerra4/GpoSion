import { Component, OnInit } from "@angular/core";
import { Localidad } from "../_models/localidad";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { ReciboService } from "../_services/recibo.service";
import { Material } from "../_models/material";
import { RetornoMaterial } from "../_models/retorno-material";

@Component({
  selector: "app-retorno-material-add",
  templateUrl: "./retorno-material-add.component.html",
  styleUrls: ["./retorno-material-add.component.css"]
})
export class RetornoMaterialAddComponent implements OnInit {
  retornoForm: FormGroup;
  retorno: RetornoMaterial;
  localidades: Localidad[];
  materialesCat: Material[];

  constructor(
    private fb: FormBuilder,
    private alertify: AlertifyService,
    private router: Router,
    private existenciasService: ExistenciasMaterialService,
    private reciboService: ReciboService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadLocalidades();
    this.loadMateriales();
    this.createRetornoForm();
  }

  createRetornoForm() {
    this.retornoForm = this.fb.group(
      {
        material: [null],
        materialId: [null, Validators.required],
        localidadId: [null, Validators.required],
        cantidad: [null, Validators.required]
      },
      { updateOn: "blur" }
    );
  }

  loadLocalidades() {
    this.reciboService.getLocalidades().subscribe(res => {
      this.localidades = res;
    });
  }

  loadMateriales() {
    this.existenciasService.getMateriales().subscribe(
      (res: Material[]) => {
        this.materialesCat = res;
        console.log(this.materialesCat);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  onSelectMaterial(item: any) {
    this.retornoForm.get("materialId").setValue(item.item.materialId);
  }

  addRetornoMaterial() {
    this.retorno = Object.assign({}, this.retornoForm.value);
    this.existenciasService.addRetornoMaterial(this.retorno).subscribe(
      (res: RetornoMaterial) => {
        this.alertify.success("Guardado");
        this.router.navigate(["retornosmaterial"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
