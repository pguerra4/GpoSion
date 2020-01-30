import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { FileUploadModule } from "ng2-file-upload";
import { TypeaheadModule } from "ngx-bootstrap/typeahead";
import {
  OwlDateTimeModule,
  OwlNativeDateTimeModule,
  OWL_DATE_TIME_LOCALE
} from "ng-pick-datetime";
import {
  BsDropdownModule,
  ModalModule,
  BsDatepickerModule,
  defineLocale
} from "ngx-bootstrap";
import * as locales from "ngx-bootstrap/locale";
import { JwtModule } from "@auth0/angular-jwt";

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
import { ViajeroListComponent } from "./viajero-list/viajero-list.component";
import { SearchByViajeroPipe } from "./_filters/search-by-viajero.pipe";
import { ViajeroEditComponent } from "./viajero-edit/viajero-edit.component";
import { ViajeroEditResolver } from "./_resolvers/viajero-edit.resolver";
import { MoldeListComponent } from "./molde-list/molde-list.component";
import { MoldeService } from "./_services/molde.service";
import { MoldeAddComponent } from "./molde-add/molde-add.component";
import { AreaService } from "./_services/area.service";
import { MoldeEditComponent } from "./molde-edit/molde-edit.component";
import { MoldeEditResolver } from "./_resolvers/molde-edit.resolver";
import { NumerosParteListComponent } from "./numeros-parte-list/numeros-parte-list.component";
import { NumeroParteService } from "./_services/numeroParte.service";
import { SearchByNumeroPartePipe } from "./_filters/search-by-numero-parte.pipe";
import { NumeroParteAddComponent } from "./numero-parte-add/numero-parte-add.component";
import { NumeroParteEditComponent } from "./numero-parte-edit/numero-parte-edit.component";
import { NumeroParteEditResolver } from "./_resolvers/numero-parte-edit.resolver";
import { MoldeadoraCardComponent } from "./moldeadora-card/moldeadora-card.component";
import { MoldeadoraListComponent } from "./moldeadora-list/moldeadora-list.component";
import { MoldeadoraService } from "./_services/moldeadora.service";
import { MoldeadoraSetupComponent } from "./moldeadora-setup/moldeadora-setup.component";
import { MoldeadoraEditResolver } from "./_resolvers/moldeadora-edit.resolver";
import { TipoMaterialListComponent } from "./tipo-material-list/tipo-material-list.component";
import { TipoMaterialAddComponent } from "./tipo-material-add/tipo-material-add.component";
import { TipoMaterialEditComponent } from "./tipo-material-edit/tipo-material-edit.component";
import { TipoMaterialEditResolver } from "./_resolvers/tipo-material-edit.resolver";
import { SearchByMaterialPipe } from "./_filters/search-by-material.pipe";
import { ValidateExistingMaterial } from "./_validators/async-material-existente.validator";
import { MaterialEditComponent } from "./material-edit/material-edit.component";
import { MaterialEditResolver } from "./_resolvers/material-edit.resolver";
import { ProduccionAddComponent } from "./produccion-add/produccion-add.component";
import { ProveedorService } from "./_services/proveedor.service";
import { OrdenCompraService } from "./_services/orden-compra.service";
import { OrdenCompraListComponent } from "./orden-compra-list/orden-compra-list.component";
import { SearchOrdenesCompraPipe } from "./_filters/search-ordenes-compra.pipe";
import { OrdenCompraAddComponent } from "./orden-compra-add/orden-compra-add.component";
import { OrdenCompraEditComponent } from "./orden-compra-edit/orden-compra-edit.component";
import { OrdenCompraEditResolver } from "./_resolvers/orden-compra-edit.resolver";
import { DetalleOrdenCompraEditComponent } from "./detalle-orden-compra-edit/detalle-orden-compra-edit.component";
import { DetalleOrdenCompraEditResolver } from "./_resolvers/detalle-orden-compra-edit.resolver";
import { ErrorInterceptorProvider } from "./_services/error.interceptor";
import { SearchMaterialExistenciasPipe } from "./_filters/search-material-existencias.pipe";
import { MoldeadoraAddComponent } from "./moldeadora-add/moldeadora-add.component";
import { MotivoTiempoMuertoListComponent } from "./motivo-tiempo-muerto-list/motivo-tiempo-muerto-list.component";
import { MotivoTiempoMuertoAddComponent } from "./motivo-tiempo-muerto-add/motivo-tiempo-muerto-add.component";
import { MotivoTiempoMuertoEditComponent } from "./motivo-tiempo-muerto-edit/motivo-tiempo-muerto-edit.component";
import { MotivoTiempoMuertoEditResolver } from "./_resolvers/motivo-tiempo-muerto-edit.resolver";
import { ClienteListComponent } from "./cliente-list/cliente-list.component";
import { ClienteAddComponent } from "./cliente-add/cliente-add.component";
import { ClienteEditComponent } from "./cliente-edit/cliente-edit.component";
import { ClienteEditResolver } from "./_resolvers/cliente-edit.resolver";
import { ProveedorListComponent } from "./proveedor-list/proveedor-list.component";
import { ProveedorAddComponent } from "./proveedor-add/proveedor-add.component";
import { ProveedorEditComponent } from "./proveedor-edit/proveedor-edit.component";
import { ProveedorEditResolver } from "./_resolvers/proveedor-edit.resolver";
import { MovimientoProductoListComponent } from "./movimiento-producto-list/movimiento-producto-list.component";
import { SearchMovimientoProductoPipe } from "./_filters/search-movimiento-producto.pipe";
import { MovimientoProductoAddComponent } from "./movimiento-producto-add/movimiento-producto-add.component";
import { MovimientoProductoEditComponent } from "./movimiento-producto-edit/movimiento-producto-edit.component";
import { MovimientoProductoEditResolver } from "./_resolvers/movimiento-producto-edit.resolver";
import { EmbarqueListComponent } from "./embarque-list/embarque-list.component";
import { SearchEmbarquePipe } from "./_filters/search-embarque.pipe";
import { EmbarqueAddComponent } from "./embarque-add/embarque-add.component";
import { ExistenciaProductoListComponent } from "./existencia-producto-list/existencia-producto-list.component";
import { SearchExistenciaProductoPipe } from "./_filters/search-existencia-producto.pipe";
import { OrdenCompraProveedorListComponent } from "./orden-compra-proveedor-list/orden-compra-proveedor-list.component";
import { SearchOrdenCompraProveedorPipe } from "./_filters/search-orden-compra-proveedor.pipe";
import { OrdenCompraProveedorAddComponent } from "./orden-compra-proveedor-add/orden-compra-proveedor-add.component";
import { PreventUnsavedChanges } from "./_guards/prevent-unsaved-changes.guard";
import { ValidateExistingFolioEmbarque } from "./_validators/async-folio-embarque-existente.validator";
import { LocalidadListComponent } from "./localidad-list/localidad-list.component";
import { LocalidadAddComponent } from "./localidad-add/localidad-add.component";
import { LocalidadEditComponent } from "./localidad-edit/localidad-edit.component";
import { LocalidadEditResolver } from "./_resolvers/localidad-edit.resolver";
import { AdminPanelComponent } from "./admin/admin-panel/admin-panel.component";
import { AuthService } from "./_services/auth.service";
import { HasRoleDirective } from "./_directives/has-role.directive";
import { UserEditComponent } from "./admin/admin-panel/user-edit/user-edit.component";
import { UserEditResolver } from "./_resolvers/user-edit.resolver";
import { UserRegisterComponent } from "./admin/admin-panel/user-register/user-register.component";
import { UserProfileEditComponent } from "./user-profile-edit/user-profile-edit.component";
import { ChangePasswordComponent } from "./change-password/change-password.component";
import { MoldeadoraSimpleListComponent } from "./moldeadora-simple-list/moldeadora-simple-list.component";
import { MoldeadoraEditComponent } from "./moldeadora-edit/moldeadora-edit.component";
import { EmbarqueEditComponent } from "./embarque-edit/embarque-edit.component";
import { EmbarqueEditResolver } from "./_resolvers/embarque-edit.resolver";
import { DetalleEmbarqueEditComponent } from "./detalle-embarque-edit/detalle-embarque-edit.component";
import { DetalleEmbarqueEditResolver } from "./_resolvers/detalle-embarque-edit.resolver";

export function tokenGetter() {
  return localStorage.getItem("token");
}

function defineLocales() {
  for (const locale in locales) {
    defineLocale(locales[locale].abbr, locales[locale]);
  }
}
defineLocales();
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
    SearchRequerimientosProdPipe,
    ViajeroListComponent,
    SearchByViajeroPipe,
    ViajeroEditComponent,
    MoldeListComponent,
    MoldeAddComponent,
    MoldeEditComponent,
    NumerosParteListComponent,
    SearchByNumeroPartePipe,
    NumeroParteAddComponent,
    NumeroParteEditComponent,
    MoldeadoraCardComponent,
    MoldeadoraListComponent,
    MoldeadoraSetupComponent,
    TipoMaterialListComponent,
    TipoMaterialAddComponent,
    TipoMaterialEditComponent,
    SearchByMaterialPipe,
    MaterialEditComponent,
    ProduccionAddComponent,
    OrdenCompraListComponent,
    SearchOrdenesCompraPipe,
    OrdenCompraAddComponent,
    OrdenCompraEditComponent,
    DetalleOrdenCompraEditComponent,
    SearchMaterialExistenciasPipe,
    MoldeadoraAddComponent,
    MotivoTiempoMuertoListComponent,
    MotivoTiempoMuertoAddComponent,
    MotivoTiempoMuertoEditComponent,
    ClienteListComponent,
    ClienteAddComponent,
    ClienteEditComponent,
    ProveedorListComponent,
    ProveedorAddComponent,
    ProveedorEditComponent,
    MovimientoProductoListComponent,
    SearchMovimientoProductoPipe,
    MovimientoProductoAddComponent,
    MovimientoProductoEditComponent,
    EmbarqueListComponent,
    SearchEmbarquePipe,
    EmbarqueAddComponent,
    ExistenciaProductoListComponent,
    SearchExistenciaProductoPipe,
    OrdenCompraProveedorListComponent,
    SearchOrdenCompraProveedorPipe,
    OrdenCompraProveedorAddComponent,
    LocalidadListComponent,
    LocalidadAddComponent,
    LocalidadEditComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserEditComponent,
    UserRegisterComponent,
    UserProfileEditComponent,
    ChangePasswordComponent,
    MoldeadoraSimpleListComponent,
    MoldeadoraEditComponent,
    EmbarqueEditComponent,
    DetalleEmbarqueEditComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    FileUploadModule,
    TypeaheadModule.forRoot(),
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5005"],
        blacklistedRoutes: ["localhost:5005/api/auth"]
      }
    }),
    RouterModule.forRoot(appRoutes, { onSameUrlNavigation: "reload" })
  ],
  providers: [
    ErrorInterceptorProvider,
    AuthService,
    ReciboService,
    ClienteService,
    AlertifyService,
    RequerimientoMaterialProdResolver,
    ValidateExistingViajero,
    ValidateExistingRecibo,
    DetalleReciboEditResolver,
    ViajeroEditResolver,
    MoldeService,
    AreaService,
    MoldeEditResolver,
    NumeroParteService,
    NumeroParteEditResolver,
    MoldeadoraService,
    MoldeadoraEditResolver,
    TipoMaterialEditResolver,
    ValidateExistingMaterial,
    MaterialEditResolver,
    ProveedorService,
    OrdenCompraService,
    OrdenCompraEditResolver,
    DetalleOrdenCompraEditResolver,
    MotivoTiempoMuertoEditResolver,
    ClienteEditResolver,
    ProveedorEditResolver,
    MovimientoProductoEditResolver,
    ValidateExistingFolioEmbarque,
    PreventUnsavedChanges,
    LocalidadEditResolver,
    UserEditResolver,
    EmbarqueEditResolver,
    DetalleEmbarqueEditResolver,
    { provide: OWL_DATE_TIME_LOCALE, useValue: "mx" }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
