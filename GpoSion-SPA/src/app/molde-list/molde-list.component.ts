import { Component, OnInit } from "@angular/core";
import { Molde } from "../_models/molde";
import { MoldeService } from "../_services/molde.service";
import { AlertifyService } from "../_services/alertify.service";
import { EstatusMolde } from "../_models/estatus-molde";

@Component({
  selector: "app-molde-list",
  templateUrl: "./molde-list.component.html",
  styleUrls: ["./molde-list.component.css"],
})
export class MoldeListComponent implements OnInit {
  moldes: Molde[];
  estatusMoldes: EstatusMolde[];
  moldesParams: any = {};

  constructor(
    private moldeService: MoldeService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.moldesParams.estatus = 0;
    this.loadEstatusMoldes();
    this.loadMoldes();
  }

  loadMoldes() {
    this.moldeService.getMoldes(this.moldesParams).subscribe(
      (res: Molde[]) => {
        this.moldes = res;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadEstatusMoldes() {
    this.moldeService.getEstatusMoldes().subscribe(
      (res: EstatusMolde[]) => {
        this.estatusMoldes = res;
        const estatusTodos: EstatusMolde = {
          estatusMoldeId: 0,
          estatus: "Todos",
        };
        this.estatusMoldes.unshift(estatusTodos);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  onChange(e) {
    this.moldesParams.estatus = e.target.value;
    this.loadMoldes();
  }

  deleteMolde(id: number) {
    this.alertify.confirm("¿Desea borrar el molde?", () => {
      this.moldeService.deleteMolde(id).subscribe(
        () => {
          this.moldes.splice(
            this.moldes.findIndex((m) => m.id === id),
            1
          );
          this.loadMoldes();
          this.alertify.success("Molde borrado");
        },
        (error) => {
          this.alertify.error("Fallo al borrar el molde:" + error);
        }
      );
    });
  }
}
