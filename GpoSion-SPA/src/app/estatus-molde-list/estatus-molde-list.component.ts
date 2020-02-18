import { Component, OnInit } from "@angular/core";
import { EstatusMolde } from "../_models/estatus-molde";
import { MoldeService } from "../_services/molde.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-estatus-molde-list",
  templateUrl: "./estatus-molde-list.component.html",
  styleUrls: ["./estatus-molde-list.component.css"]
})
export class EstatusMoldeListComponent implements OnInit {
  estatusMoldes: EstatusMolde[];

  constructor(
    private moldeService: MoldeService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadEstatusMoldes();
  }

  loadEstatusMoldes() {
    this.moldeService.getEstatusMoldes().subscribe(
      (res: EstatusMolde[]) => {
        this.estatusMoldes = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  deleteEstatusMolde(id: number) {
    this.alertify.confirm("¿Desea borrar el estatus de molde?", () => {
      this.moldeService.deleteEstatusMolde(id).subscribe(
        () => {
          this.estatusMoldes.splice(
            this.estatusMoldes.findIndex(m => m.estatusMoldeId === id),
            1
          );
          this.loadEstatusMoldes();
          this.alertify.success("Estatus de molde borrado");
        },
        error => {
          this.alertify.error("Fallo al borrar el estatus de molde:" + error);
        }
      );
    });
  }
}
