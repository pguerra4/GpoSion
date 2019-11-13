import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { NumeroParte } from "../_models/numeroParte";
import { Cliente } from "../_models/cliente";
import { ClienteService } from "../_services/cliente.service";
import { NumeroParteService } from "../_services/numeroParte.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { environment } from "src/environments/environment";
import { FileUploader } from "ng2-file-upload";
import { DomSanitizer } from "@angular/platform-browser";
import { Material } from "../_models/material";
import { Molde } from "../_models/molde";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";
import { MoldeService } from "../_services/molde.service";

@Component({
  selector: "app-numero-parte-edit",
  templateUrl: "./numero-parte-edit.component.html",
  styleUrls: ["./numero-parte-edit.component.css"]
})
export class NumeroParteEditComponent implements OnInit {
  numeroParteForm: FormGroup;
  numeroParte: NumeroParte;
  clientes: Cliente[];
  urlImagenPieza: any;
  baseUrl = environment.apiUrl;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  materialesCat: Material[];
  materiales: Material[] = new Array();
  moldesCat: Molde[];
  moldes: Molde[] = new Array();

  constructor(
    private clienteService: ClienteService,
    private numeroParteService: NumeroParteService,
    private existenciaMaterialesService: ExistenciasMaterialService,
    private moldeService: MoldeService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.numeroParte = data["numeroParte"];
      this.moldes = this.numeroParte.moldes;
      this.materiales = this.numeroParte.materiales;

      if (this.numeroParte.urlImagenPieza) {
        this.urlImagenPieza =
          this.baseUrl + "numerosParte/" + this.numeroParte.noParte + "/Photo";
      } else {
        this.urlImagenPieza = "../../assets/noImagen.jpg";
      }
    });
    this.loadClientes();
    this.loadMateriales();
    this.loadMoldes();
    this.createNumeroParteForm();
    this.initializeUploader();
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  createNumeroParteForm() {
    this.numeroParteForm = this.fb.group({
      noParte: [this.numeroParte.noParte, Validators.required],
      clienteId: [this.numeroParte.clienteId, Validators.required],
      descripcion: [this.numeroParte.descripcion],
      leyendaPieza: [this.numeroParte.leyendaPieza],
      peso: [this.numeroParte.peso, Validators.required],
      costo: [this.numeroParte.costo, Validators.required],
      material: [null],
      molde: [null]
    });
  }

  loadClientes() {
    this.clienteService.getClientes().subscribe(
      (res: Cliente[]) => {
        this.clientes = res;
      },
      error => {
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
      error => {
        this.alertify.error(error);
      }
    );
  }

  loadMoldes() {
    this.moldeService.getMoldes().subscribe(
      (res: Molde[]) => {
        this.moldesCat = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  onSelectMaterial(item: any) {
    if (
      this.materiales.find(m => m.materialId === item.item.materialId) ===
      undefined
    ) {
      this.materiales.push(item.item);
    }
    this.numeroParteForm.get("material").setValue(null);
  }

  onSelectMolde(item: any) {
    if (this.moldes.find(m => m.id === item.item.id) === undefined) {
      this.moldes.push(item.item);
    }

    this.numeroParteForm.get("molde").setValue(null);
  }

  deleteMaterial(materialId: number) {
    this.materiales.splice(
      this.materiales.findIndex(m => m.materialId === materialId),
      1
    );
  }

  deleteMolde(id: number) {
    this.moldes.splice(
      this.moldes.findIndex(m => m.id === id),
      1
    );
  }

  editNumeroParte() {
    this.numeroParte = Object.assign({}, this.numeroParteForm.value);
    this.numeroParte.moldes = this.moldes;
    this.numeroParte.materiales = this.materiales;

    console.log(this.numeroParte);
    this.numeroParteService
      .editNumeroParte(this.route.snapshot.params["id"], this.numeroParte)
      .subscribe(
        (res: NumeroParte) => {
          this.alertify.success("Guardado");
          this.router.navigate(["numerosParte"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url:
        this.baseUrl +
        "numerosParte/" +
        this.route.snapshot.params["id"] +
        "/Photo",
      // authToken: "Bearer " + localStorage.getItem("token"),
      isHTML5: true,
      allowedFileType: ["image"],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = file => {
      file.withCredentials = false;
      if (this.uploader.queue.length > 1) {
        this.uploader.queue.splice(0, 1);
      }
      this.urlImagenPieza = this.sanitizer.bypassSecurityTrustUrl(
        window.URL.createObjectURL(file._file)
      );
    };

    this.uploader.onErrorItem = (item, response, status, headers) => {
      this.alertify.error(status + " " + response);
    };
  }

  removerImagen() {
    this.uploader.clearQueue();
    if (this.numeroParte.urlImagenPieza) {
      this.urlImagenPieza =
        this.baseUrl + "numerosParte/" + this.numeroParte.noParte + "/Photo";
    } else {
      this.urlImagenPieza = "../../assets/noImagen.jpg";
    }
  }
}
