import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {
  BsDropdownModule,
  TabsModule,
  BsDatepickerModule
} from "ngx-bootstrap";

import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { HomeComponent } from "./home/home.component";
import { RouterModule } from "@angular/router";
import { appRoutes } from "./routes";
import { MaterialAddComponent } from "./material-add/material-add.component";
import { MaterialListComponent } from "./material-list/material-list.component";
import { ExistenciasAddComponent } from "./existencias-add/existencias-add.component";
import { ProduccionListComponent } from "./produccion-list/produccion-list.component";
import { MaterialProdComponent } from "./material-prod/material-prod.component";
import { ReciboListComponent } from "./recibo-list/recibo-list.component";
import { ReciboService } from "./_services/recibo.service";
import { ReciboAddComponent } from "./recibo-add/recibo-add.component";
import { ClienteService } from "./_services/cliente.service";
import { AlertifyService } from "./_services/alertify.service";
import { ReciboDetailComponent } from "./recibo-detail/recibo-detail.component";
import { ExistenciasMaterialListComponent } from "./existenciasMaterial-list/existenciasMaterial-list.component";
import { ViajeroDetailComponent } from "./viajero-detail/viajero-detail.component";
import { MaterialViajerosListComponent } from "./material-viajeros-list/material-viajeros-list.component";
import { RequerimientoMaterialComponent } from "./requerimiento-material/requerimiento-material.component";
import { RequerimientoMaterialListComponent } from "./requerimientoMaterial-list/requerimientoMaterial-list.component";
import { RequerimientoProdListComponent } from "./requerimiento-prod-list/requerimiento-prod-list.component";
import { RequerimientoMaterialProdComponent } from "./requerimiento-material-prod/requerimiento-material-prod.component";
import { RequerimientoMaterialViajerosComponent } from "./requerimiento-material-viajeros/requerimiento-material-viajeros.component";
import { RequerimientoMaterialProdResolver } from "./_resolvers/requerimiento-material-prod.resolver";
import { ValidateExistingViajero } from "./_validators/async-viajero-existente.validator";
import { ValidateExistingRecibo } from "./_validators/async-recibo-existente.validator";
import { DetalleReciboEditComponent } from "./detalle-recibo-edit/detalle-recibo-edit.component";
import { DetalleReciboEditResolver } from "./_resolvers/detalle-recibo-edit.resolver";
import { SearchByMaterialExistenciasGroupPipe } from "./_filters/search-by-material-existencias-group.pipe";
import { SearchRecibosPipe } from "./_filters/search-recibos.pipe";
import { SearchRequerimientosProdPipe } from "./_filters/search-requerimientos-prod.pipe";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    MaterialAddComponent,
    MaterialListComponent,
    ExistenciasAddComponent,
    ProduccionListComponent,
    MaterialProdComponent,
    ReciboListComponent,
    ReciboAddComponent,
    ReciboDetailComponent,
    ExistenciasMaterialListComponent,
    ViajeroDetailComponent,
    MaterialViajerosListComponent,
    RequerimientoMaterialComponent,
    RequerimientoMaterialListComponent,
    RequerimientoProdListComponent,
    RequerimientoMaterialProdComponent,
    RequerimientoMaterialViajerosComponent,
    DetalleReciboEditComponent,
    SearchByMaterialExistenciasGroupPipe,
    SearchRecibosPipe,
    SearchRequerimientosProdPipe
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    ReciboService,
    ClienteService,
    AlertifyService,
    RequerimientoMaterialProdResolver,
    ValidateExistingViajero,
    ValidateExistingRecibo,
    DetalleReciboEditResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
