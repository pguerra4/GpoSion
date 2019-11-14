import { Component, OnInit } from "@angular/core";
import { ProduccionService } from "../_services/produccion.service";
import { AlertifyService } from "../_services/alertify.service";
import { MoldeadoraService } from "../_services/moldeadora.service";
import { Moldeadora } from "../_models/moldeadora";
import { FormGroup, FormBuilder, Validators, FormArray } from "@angular/forms";
import { Produccion } from "../_models/produccion";
import { Router } from "@angular/router";

@Component({
  selector: "app-produccion-add",
  templateUrl: "./produccion-add.component.html",
  styleUrls: ["./produccion-add.component.css"]
})
export class ProduccionAddComponent implements OnInit {
  produccionForm: FormGroup;
  moldeadoras: Moldeadora[];
  moldeadora: Moldeadora;
  items: FormArray = new FormArray([]);
  now = new Date();
  max: Date = new Date(
    this.now.getFullYear(),
    this.now.getMonth(),
    this.now.getDate() + 1,
    0,
    0,
    0
  );

  constructor(
    private produccionService: ProduccionService,
    private alertify: AlertifyService,
    private moldeadoraService: MoldeadoraService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadMoldeadoras();
    this.createProduccionForm();
  }

  createProduccionForm() {
    this.produccionForm = this.fb.group({
      fecha: [this.now, Validators.required],
      moldeadoraId: [null, Validators.required],
      purga: [0],
      colada: [0],
      produccionNumerosParte: this.fb.array([])
    });
  }

  createItem(noParte: string) {
    return this.fb.group({
      noParte: [noParte],
      piezas: [0],
      scrap: [0]
    });
  }

  loadMoldeadoras() {
    this.moldeadoraService.getMoldeadoras().subscribe(
      res => {
        this.moldeadoras = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  loadNumerosParte() {
    const moldeadoraId = this.produccionForm.get("moldeadoraId").value;
    if (moldeadoraId) {
      this.moldeadoraService.getMoldeadora(moldeadoraId).subscribe(res => {
        this.moldeadora = res;
        this.items = this.produccionForm.get(
          "produccionNumerosParte"
        ) as FormArray;
        this.items.clear();
        this.moldeadora.numerosParte.forEach(np => {
          this.items.push(this.createItem(np));
        });
        this.produccionForm.get("produccionNumerosParte").setValue(this.items);
      });
    } else {
      this.items = this.produccionForm.get(
        "produccionNumerosParte"
      ) as FormArray;
      this.items.clear();
      this.produccionForm.get("produccionNumerosParte").setValue(this.items);
    }
  }

  addProduccion() {
    const prod: Produccion = Object.assign({}, this.produccionForm.value);
    this.produccionService.addProduccion(prod).subscribe(
      () => {
        this.alertify.success("Guardado");
        this.router.navigate(["moldeadoras"]);
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  trackByFn(index: any, item: any) {
    return index;
  }
}
