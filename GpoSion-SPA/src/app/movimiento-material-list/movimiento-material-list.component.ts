import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { BsLocaleService } from "ngx-bootstrap";
import { Material } from "../_models/material";
import { MovimientoMaterial } from "../_models/movimientoMaterial";
import { AlertifyService } from "../_services/alertify.service";
import { ExistenciasMaterialService } from "../_services/existenciasMaterial.service";

@Component({
  selector: "app-movimiento-material-list",
  templateUrl: "./movimiento-material-list.component.html",
  styleUrls: ["./movimiento-material-list.component.css"],
})
export class MovimientoMaterialListComponent implements OnInit {
  movimientos: MovimientoMaterial[];
  searchText = "";
  movimientoParams: any = {};
  bsValue = new Date();
  bsRangeValue: Date[];
  minDate = new Date();
  fechaInicio: any;
  fechaFin: any;
  materialId: number;
  material: string;
  materiales: Material[];

  constructor(
    private materialService: ExistenciasMaterialService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private localeService: BsLocaleService,
    private router: Router
  ) {
    this.minDate.setDate(this.minDate.getDate() - 7);
    this.bsValue.setDate(this.bsValue.getDate() + 1);
    this.bsRangeValue = [this.minDate, this.bsValue];
  }

  ngOnInit() {
    this.localeService.use("es");

    this.loadMateriales();
    this.route.queryParams.subscribe((params) => {
      if (params.hasOwnProperty("fechaInicio")) {
        this.movimientoParams = params;
        this.minDate = new Date(this.movimientoParams.fechaInicio);
        this.bsValue = new Date(this.movimientoParams.fechaFin);
        this.bsRangeValue = [this.minDate, this.bsValue];
        this.materialId = this.movimientoParams.materialId;
      }
      this.loadMovimientos();
    });
  }

  loadMovimientos() {
    if (this.movimientoParams.hasOwnProperty("fechaInicio")) {
      this.materialService
        .getMovimientosMaterial(this.movimientoParams)
        .subscribe(
          (res) => {
            this.movimientos = res;
          },
          (error) => {
            this.alertify.error(error);
          }
        );
    }
  }

  onValueChange(value: Date) {
    if (value) {
      this.fechaInicio = value[0].toDateString();
      this.fechaFin = value[1].toDateString();
      this.movimientoParams = {
        fechaInicio: value[0].toDateString(),
        fechaFin: value[1].toDateString(),
        materialId: this.materialId,
      };
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.movimientoParams,
      });
    }
  }

  onSelectMaterial($event) {
    if ($event) {
      this.material = $event.value;
      this.materialId = $event.item.materialId;
      this.movimientoParams = {
        fechaInicio: this.fechaInicio,
        fechaFin: this.fechaFin,
        materialId: this.materialId,
      };
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.movimientoParams,
      });
    }
  }

  materialChange() {
    this.material = null;
    this.movimientoParams = {
      fechaInicio: this.fechaInicio,
      fechaFin: this.fechaFin,
    };
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: this.movimientoParams,
    });
  }

  loadMateriales() {
    this.materialService.getMateriales().subscribe(
      (res: Material[]) => {
        this.materiales = res;
        if (this.materialId) {
          this.material = this.materiales.find(
            (m) => m.materialId == this.materialId
          ).material;
        }
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
