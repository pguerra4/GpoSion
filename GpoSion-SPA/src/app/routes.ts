import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { MaterialListComponent } from "./material-list/material-list.component";
import { MaterialAddComponent } from "./material-add/material-add.component";
import { ExistenciasAddComponent } from "./existencias-add/existencias-add.component";
import { ProduccionListComponent } from "./produccion-list/produccion-list.component";
import { MaterialProdComponent } from "./material-prod/material-prod.component";
import { ReciboListComponent } from "./recibo-list/recibo-list.component";
import { ReciboAddComponent } from "./recibo-add/recibo-add.component";
import { ReciboDetailComponent } from "./recibo-detail/recibo-detail.component";
import { ExistenciasMaterialListComponent } from "./existenciasMaterial-list/existenciasMaterial-list.component";
import { ViajeroDetailComponent } from "./viajero-detail/viajero-detail.component";
import { MaterialViajerosListComponent } from "./material-viajeros-list/material-viajeros-list.component";
import { RequerimientoMaterialComponent } from "./requerimiento-material/requerimiento-material.component";
import { RequerimientoMaterialListComponent } from "./requerimientoMaterial-list/requerimientoMaterial-list.component";
import { RequerimientoProdListComponent } from "./requerimiento-prod-list/requerimiento-prod-list.component";
import { RequerimientoMaterialProdComponent } from "./requerimiento-material-prod/requerimiento-material-prod.component";
import { RequerimientoMaterialProdResolver } from "./_resolvers/requerimiento-material-prod.resolver";
import { DetalleReciboEditComponent } from "./detalle-recibo-edit/detalle-recibo-edit.component";
import { DetalleReciboEditResolver } from "./_resolvers/detalle-recibo-edit.resolver";
import { ViajeroListComponent } from "./viajero-list/viajero-list.component";
import { ViajeroEditComponent } from "./viajero-edit/viajero-edit.component";
import { ViajeroEditResolver } from "./_resolvers/viajero-edit.resolver";
import { MoldeListComponent } from "./molde-list/molde-list.component";
import { MoldeAddComponent } from "./molde-add/molde-add.component";
import { MoldeEditResolver } from "./_resolvers/molde-edit.resolver";
import { MoldeEditComponent } from "./molde-edit/molde-edit.component";
import { NumerosParteListComponent } from "./numeros-parte-list/numeros-parte-list.component";
import { NumeroParteAddComponent } from "./numero-parte-add/numero-parte-add.component";
import { NumeroParteEditComponent } from "./numero-parte-edit/numero-parte-edit.component";
import { NumeroParteEditResolver } from "./_resolvers/numero-parte-edit.resolver";
import { MoldeadoraListComponent } from "./moldeadora-list/moldeadora-list.component";
import { MoldeadoraSetupComponent } from "./moldeadora-setup/moldeadora-setup.component";
import { MoldeadoraEditResolver } from "./_resolvers/moldeadora-edit.resolver";
import { TipoMaterialListComponent } from "./tipo-material-list/tipo-material-list.component";
import { TipoMaterialAddComponent } from "./tipo-material-add/tipo-material-add.component";
import { TipoMaterialEditComponent } from "./tipo-material-edit/tipo-material-edit.component";
import { TipoMaterialEditResolver } from "./_resolvers/tipo-material-edit.resolver";
import { MaterialEditComponent } from "./material-edit/material-edit.component";
import { MaterialEditResolver } from "./_resolvers/material-edit.resolver";
import { ProduccionAddComponent } from "./produccion-add/produccion-add.component";
import { OrdenCompraListComponent } from "./orden-compra-list/orden-compra-list.component";
import { OrdenCompraAddComponent } from "./orden-compra-add/orden-compra-add.component";
import { OrdenCompraEditComponent } from "./orden-compra-edit/orden-compra-edit.component";
import { OrdenCompraEditResolver } from "./_resolvers/orden-compra-edit.resolver";
import { DetalleOrdenCompraEditComponent } from "./detalle-orden-compra-edit/detalle-orden-compra-edit.component";
import { DetalleOrdenCompraEditResolver } from "./_resolvers/detalle-orden-compra-edit.resolver";
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
import { ProveedorEditResolver } from "./_resolvers/proveedor-edit.resolver";
import { ProveedorAddComponent } from "./proveedor-add/proveedor-add.component";
import { ProveedorEditComponent } from "./proveedor-edit/proveedor-edit.component";
import { MovimientoProductoListComponent } from "./movimiento-producto-list/movimiento-producto-list.component";
import { MovimientoProductoAddComponent } from "./movimiento-producto-add/movimiento-producto-add.component";
import { MovimientoProductoEditComponent } from "./movimiento-producto-edit/movimiento-producto-edit.component";
import { MovimientoProductoEditResolver } from "./_resolvers/movimiento-producto-edit.resolver";
import { EmbarqueListComponent } from "./embarque-list/embarque-list.component";
import { EmbarqueAddComponent } from "./embarque-add/embarque-add.component";
import { ExistenciaProductoListComponent } from "./existencia-producto-list/existencia-producto-list.component";
import { OrdenCompraProveedorListComponent } from "./orden-compra-proveedor-list/orden-compra-proveedor-list.component";
import { OrdenCompraProveedorAddComponent } from "./orden-compra-proveedor-add/orden-compra-proveedor-add.component";
import { PreventUnsavedChanges } from "./_guards/prevent-unsaved-changes.guard";
import { LocalidadListComponent } from "./localidad-list/localidad-list.component";
import { LocalidadAddComponent } from "./localidad-add/localidad-add.component";
import { LocalidadEditComponent } from "./localidad-edit/localidad-edit.component";
import { LocalidadEditResolver } from "./_resolvers/localidad-edit.resolver";
import { AdminPanelComponent } from "./admin/admin-panel/admin-panel.component";
import { AuthGuard } from "./_guards/auth.guard";
import { UserEditComponent } from "./admin/admin-panel/user-edit/user-edit.component";
import { UserEditResolver } from "./_resolvers/user-edit.resolver";
import { UserRegisterComponent } from "./admin/admin-panel/user-register/user-register.component";
import { UserProfileEditComponent } from "./user-profile-edit/user-profile-edit.component";
import { ChangePasswordComponent } from "./change-password/change-password.component";
import { MoldeadoraSimpleListComponent } from "./moldeadora-simple-list/moldeadora-simple-list.component";
import { MoldeadoraEditComponent } from "./moldeadora-edit/moldeadora-edit.component";
import { EmbarqueEditResolver } from "./_resolvers/embarque-edit.resolver";
import { EmbarqueEditComponent } from "./embarque-edit/embarque-edit.component";
import { DetalleEmbarqueEditComponent } from "./detalle-embarque-edit/detalle-embarque-edit.component";
import { DetalleEmbarqueEditResolver } from "./_resolvers/detalle-embarque-edit.resolver";
import { RetornoMaterialListComponent } from "./retorno-material-list/retorno-material-list.component";
import { RetornoMaterialAddComponent } from "./retorno-material-add/retorno-material-add.component";
import { MovimientoProductoListResolver } from "./_resolvers/movimiento-producto-list.resolver";
import { RetornoMaterialEditComponent } from "./retorno-material-edit/retorno-material-edit.component";
import { RetornoMaterialEditResolver } from "./_resolvers/retorno-material-edit.resolver";
import { ExistenciaProductoDetailComponent } from "./existencia-producto-detail/existencia-producto-detail.component";
import { ExistenciaProductoDetailResolver } from "./_resolvers/existencia-producto-detail.resolver";
import { MoldeDetailComponent } from "./molde-detail/molde-detail.component";
import { EstatusMoldeListComponent } from "./estatus-molde-list/estatus-molde-list.component";
import { EstatusMoldeAddComponent } from "./estatus-molde-add/estatus-molde-add.component";
import { EstatusMoldeEditComponent } from "./estatus-molde-edit/estatus-molde-edit.component";
import { EstatusMoldeEditResolver } from "./_resolvers/estatus-molde-edit.resolver";
import { EasyqueryComponent } from "./easyquery/easyquery.component";
import { ExistenciaProductoEditComponent } from "./existencia-producto-edit/existencia-producto-edit.component";
import { LocalidadNumeroParteEditComponent } from "./localidad-numero-parte-edit/localidad-numero-parte-edit.component";
import { LocalidadNumeroParteEditResolver } from "./_resolvers/localidad-numero-parte-edit.resolver";
import { PlaneacionProduccionListComponent } from "./planeacion-produccion-list/planeacion-produccion-list.component";
import { PlaneacionProduccionAddComponent } from "./planeacion-produccion-add/planeacion-produccion-add.component";
import { PlaneacionProduccionEditResolver } from "./_resolvers/planeacion-produccion-edit.resolver";
import { PlaneacionProduccionEditComponent } from "./planeacion-produccion-edit/planeacion-produccion-edit.component";
import { GraficaEmbarquesComponent } from "./grafica-embarques/grafica-embarques.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { GraficaEmbarquesFullComponent } from "./grafica-embarques-full/grafica-embarques-full.component";
import { GraficaEmbarquesNpFullComponent } from "./grafica-embarques-np-full/grafica-embarques-np-full.component";
import { UserProfileEditResolver } from "./_resolvers/user-profile-edit.resolver";
import { ChangePasswordAdminComponent } from "./change-password-admin/change-password-admin.component";
import { DashboardRecibosComponent } from "./dashboard-recibos/dashboard-recibos.component";
import { GraficaRecibosFullComponent } from "./grafica-recibos-full/grafica-recibos-full.component";
import { GraficaRecibosMaterialFullComponent } from "./grafica-recibos-material-full/grafica-recibos-material-full.component";

export const appRoutes: Routes = [
  { path: "", component: HomeComponent },
  {
    path: "",
    runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [
      {
        path: "materiales",
        component: MaterialListComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "addMaterial",
        component: MaterialAddComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "materiales/:id",
        component: MaterialEditComponent,
        resolve: { material: MaterialEditResolver },
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "materiales/:id/viajeros",
        component: MaterialViajerosListComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "recibos",
        component: ReciboListComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "recibos/:id",
        component: ReciboDetailComponent,
        canDeactivate: [PreventUnsavedChanges],
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "detalleRecibo/:id",
        component: DetalleReciboEditComponent,
        resolve: { detalleRecibo: DetalleReciboEditResolver },
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "viajeros/:id",
        component: ViajeroDetailComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "viajeroedit/:id",
        component: ViajeroEditComponent,
        resolve: { viajero: ViajeroEditResolver },
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "viajeros",
        component: ViajeroListComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "addRecibo",
        component: ReciboAddComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "existencias",
        component: ExistenciasMaterialListComponent,
        data: {
          roles: [
            "Admin",
            "Almacen",
            "Produccion",
            "Compras",
            "Ventas",
            "AlmacenMateriaPrima",
          ],
        },
      },
      {
        path: "addAlmacen",
        component: ExistenciasAddComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "produccion",
        component: ProduccionListComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "requerimientoMaterial",
        component: RequerimientoMaterialComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "requerimientos",
        component: RequerimientoMaterialListComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "requerimientosprod",
        component: RequerimientoProdListComponent,
        data: { roles: ["Admin", "Almacen"] },
      },
      {
        path: "requerimientos/:id",
        component: RequerimientoMaterialProdComponent,
        resolve: { req: RequerimientoMaterialProdResolver },
        data: { roles: ["Admin", "Almacen"] },
      },
      {
        path: "solicitarMaterial/:id",
        component: MaterialProdComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "moldes",
        component: MoldeListComponent,
        data: { roles: ["Admin", "Almacen", "Produccion"] },
      },
      {
        path: "moldes/:id",
        component: MoldeEditComponent,
        resolve: { molde: MoldeEditResolver },
        data: { roles: ["Admin", "Almacen", "Produccion"] },
      },
      {
        path: "moldeDetail/:id",
        component: MoldeDetailComponent,
        resolve: { molde: MoldeEditResolver },
        data: { roles: ["Admin", "Almacen", "Produccion"] },
      },
      {
        path: "addMolde",
        component: MoldeAddComponent,
        data: { roles: ["Admin", "Almacen", "Produccion"] },
      },
      {
        path: "estatusmoldes",
        component: EstatusMoldeListComponent,
        data: { roles: ["Admin", "Almacen", "Produccion"] },
      },
      {
        path: "addEstatusMolde",
        component: EstatusMoldeAddComponent,
        data: { roles: ["Admin", "Almacen", "Produccion"] },
      },
      {
        path: "estatusmoldes/:id",
        component: EstatusMoldeEditComponent,
        resolve: { estatusMolde: EstatusMoldeEditResolver },
        data: { roles: ["Admin", "Almacen", "Produccion"] },
      },
      {
        path: "numerosParte",
        component: NumerosParteListComponent,
        data: { roles: ["Admin", "Almacen", "Ventas"] },
      },
      {
        path: "numerosParte/:id",
        component: NumeroParteEditComponent,
        resolve: { numeroParte: NumeroParteEditResolver },
        data: { roles: ["Admin", "Almacen", "Ventas"] },
      },
      {
        path: "addNumeroParte",
        component: NumeroParteAddComponent,
        data: { roles: ["Admin", "Almacen", "Ventas"] },
      },
      {
        path: "moldeadoras",
        component: MoldeadoraListComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "moldeadoraslist",
        component: MoldeadoraSimpleListComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "moldeadoras/:id",
        component: MoldeadoraSetupComponent,
        resolve: { moldeadora: MoldeadoraEditResolver },
        runGuardsAndResolvers: "always",
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "moldeadorasedit/:id",
        component: MoldeadoraEditComponent,
        resolve: { moldeadora: MoldeadoraEditResolver },
        runGuardsAndResolvers: "always",
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "addMoldeadora",
        component: MoldeadoraAddComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "tiposmaterial",
        component: TipoMaterialListComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "addTipoMaterial",
        component: TipoMaterialAddComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "tiposmaterial/:id",
        component: TipoMaterialEditComponent,
        resolve: { tipoMaterial: TipoMaterialEditResolver },
        data: { roles: ["Admin", "Almacen", "AlmacenMateriaPrima"] },
      },
      {
        path: "ordenescompra",
        component: OrdenCompraListComponent,
        data: { roles: ["Admin", "Ventas"] },
      },
      {
        path: "addOrdenCompra",
        component: OrdenCompraAddComponent,
        data: { roles: ["Admin", "Ventas"] },
      },
      {
        path: "ordenescompra/:id",
        component: OrdenCompraEditComponent,
        resolve: { ordenCompra: OrdenCompraEditResolver },
        data: { roles: ["Admin", "Ventas"] },
      },
      {
        path: "detallesordencompra/:id",
        component: DetalleOrdenCompraEditComponent,
        resolve: { detalleOrdenCompra: DetalleOrdenCompraEditResolver },
        data: { roles: ["Admin", "Ventas"] },
      },
      {
        path: "addProduccion",
        component: ProduccionAddComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "planeacionproduccion",
        component: PlaneacionProduccionListComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "addPlaneacion",
        component: PlaneacionProduccionAddComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "planeacionproduccion/:año/:semana/:noParte",
        component: PlaneacionProduccionEditComponent,
        resolve: { planeacion: PlaneacionProduccionEditResolver },
        data: { roles: ["Admin", "Produccion"] },
      },
      { path: "lists", component: MaterialAddComponent },
      {
        path: "motivostiempomuerto",
        component: MotivoTiempoMuertoListComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "addMotivoTiempoMuerto",
        component: MotivoTiempoMuertoAddComponent,
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "motivostiempomuerto/:id",
        component: MotivoTiempoMuertoEditComponent,
        resolve: { motivoTiempoMuerto: MotivoTiempoMuertoEditResolver },
        data: { roles: ["Admin", "Produccion"] },
      },
      {
        path: "clientes",
        component: ClienteListComponent,
        data: { roles: ["Admin", "Ventas"] },
      },
      {
        path: "addCliente",
        component: ClienteAddComponent,
        data: { roles: ["Admin", "Ventas"] },
      },
      {
        path: "clientes/:id",
        component: ClienteEditComponent,
        resolve: { cliente: ClienteEditResolver },
        data: { roles: ["Admin", "Ventas"] },
      },
      {
        path: "proveedores",
        component: ProveedorListComponent,
        data: { roles: ["Admin", "Compras"] },
      },
      {
        path: "addProveedor",
        component: ProveedorAddComponent,
        data: { roles: ["Admin", "Compras"] },
      },
      {
        path: "proveedores/:id",
        component: ProveedorEditComponent,
        resolve: { proveedor: ProveedorEditResolver },
        data: { roles: ["Admin", "Compras"] },
      },
      {
        path: "movimientosproducto",
        component: MovimientoProductoListComponent,
        data: { roles: ["Admin", "Almacen", "Produccion", "AlmacenProducto"] },
      },
      {
        path: "addMovimientoProducto",
        component: MovimientoProductoAddComponent,
        resolve: { movimientosProducto: MovimientoProductoListResolver },
        data: { roles: ["Admin", "Almacen", "Produccion", "AlmacenProducto"] },
      },
      {
        path: "movimientosproducto/:id",
        component: MovimientoProductoEditComponent,
        resolve: { movimientoProducto: MovimientoProductoEditResolver },
        data: { roles: ["Admin", "Almacen", "Produccion", "AlmacenProducto"] },
      },
      {
        path: "embarques",
        component: EmbarqueListComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenProducto"] },
      },
      {
        path: "addEmbarque",
        component: EmbarqueAddComponent,
        data: { roles: ["Admin", "Almacen", "AlmacenProducto"] },
      },
      {
        path: "embarques/:id",
        component: EmbarqueEditComponent,
        resolve: { embarque: EmbarqueEditResolver },
        data: { roles: ["Admin", "Almacen", "AlmacenProducto"] },
      },
      {
        path: "detallesEmbarque/:id",
        component: DetalleEmbarqueEditComponent,
        resolve: { detalleEmbarque: DetalleEmbarqueEditResolver },
        data: { roles: ["Admin", "Almacen", "AlmacenProducto"] },
      },
      {
        path: "existenciasproducto",
        component: ExistenciaProductoListComponent,
        data: {
          roles: [
            "Admin",
            "Almacen",
            "Produccion",
            "Compras",
            "Ventas",
            "AlmacenProducto",
          ],
        },
      },
      {
        path: "existenciasproducto/:id",
        component: ExistenciaProductoDetailComponent,
        resolve: { existenciaProducto: ExistenciaProductoDetailResolver },
        data: {
          roles: [
            "Admin",
            "Almacen",
            "Produccion",
            "Compras",
            "Ventas",
            "AlmacenProducto",
          ],
        },
      },
      {
        path: "editExistenciaProducto/:id",
        component: ExistenciaProductoEditComponent,
        resolve: { existenciaProducto: ExistenciaProductoDetailResolver },
        data: { roles: ["Admin", "Almacen", "Produccion", "AlmacenProducto"] },
      },
      {
        path: "localidadesnumeroparte/:localidadId/:noParte",
        component: LocalidadNumeroParteEditComponent,
        resolve: { localidadNumeroParte: LocalidadNumeroParteEditResolver },
        data: { roles: ["Admin", "Almacen", "Produccion", "AlmacenProducto"] },
      },
      {
        path: "ordenescompraproveedores",
        component: OrdenCompraProveedorListComponent,
        data: { roles: ["Admin", "Compras"] },
      },
      {
        path: "addOrdenCompraProveedor",
        component: OrdenCompraProveedorAddComponent,
        data: { roles: ["Admin", "Compras"] },
      },
      {
        path: "localidades",
        component: LocalidadListComponent,
        data: {
          roles: ["Admin", "Almacen", "AlmacenMateriaPrima", "AlmacenProducto"],
        },
      },
      {
        path: "addLocalidad",
        component: LocalidadAddComponent,
        data: {
          roles: ["Admin", "Almacen", "AlmacenMateriaPrima", "AlmacenProducto"],
        },
      },
      {
        path: "localidades/:id",
        component: LocalidadEditComponent,
        resolve: { localidad: LocalidadEditResolver },
        data: {
          roles: ["Admin", "Almacen", "AlmacenMateriaPrima", "AlmacenProducto"],
        },
      },
      {
        path: "retornosmaterial",
        component: RetornoMaterialListComponent,
        data: { roles: ["Admin", "Almacen", "Produccion"] },
      },
      {
        path: "addRetorno",
        component: RetornoMaterialAddComponent,
        data: { roles: ["Admin", "Almacen"] },
      },
      {
        path: "retornosmaterial/:id",
        component: RetornoMaterialEditComponent,
        resolve: { retornoMaterial: RetornoMaterialEditResolver },
        data: { roles: ["Admin", "Almacen"] },
      },
      {
        path: "admin",
        component: AdminPanelComponent,
        data: { roles: ["Admin"] },
      },
      {
        path: "admin/users/:id",
        component: UserEditComponent,
        resolve: { user: UserEditResolver },
        data: { roles: ["Admin"] },
      },
      {
        path: "admin/changepassword/:id",
        component: ChangePasswordAdminComponent,
        data: { roles: ["Admin"] },
      },
      {
        path: "addUser",
        component: UserRegisterComponent,
        data: { roles: ["Admin"] },
      },
      {
        path: "users/:id",
        component: UserProfileEditComponent,
        resolve: { user: UserProfileEditResolver },
      },
      {
        path: "users/changepassword/:id",
        component: ChangePasswordComponent,
      },
      {
        path: "easy-query",
        component: EasyqueryComponent,
      },
      {
        path: "dashboard",
        component: DashboardComponent,
      },
      {
        path: "graficaembarquesfull",
        component: GraficaEmbarquesFullComponent,
      },
      {
        path: "graficaembarquesnpfull",
        component: GraficaEmbarquesNpFullComponent,
      },
      {
        path: "dashboardrecibos",
        component: DashboardRecibosComponent,
        data: { roles: ["Admin", "Almacen"] },
      },
      {
        path: "graficarecibosfull",
        component: GraficaRecibosFullComponent,
        data: { roles: ["Admin", "Almacen"] },
      },
      {
        path: "graficarecibosmaterialfull",
        component: GraficaRecibosMaterialFullComponent,
        data: { roles: ["Admin", "Almacen"] },
      },
    ],
  },
  { path: "**", redirectTo: "", pathMatch: "full" },
];
