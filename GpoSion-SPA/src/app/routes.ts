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

export const appRoutes: Routes = [
  { path: "", component: HomeComponent },
  // {
  //   path: "",
  //   runGuardsAndResolvers: "always",
  //   canActivate: [AuthGuard],
  //   children: [
  //     {
  //       path: "members",
  //       component: MemberListComponent,
  //       resolve: { users: MemberListResolver }
  //     },
  //     {
  //       path: "members/:id",
  //       component: MemberDetailComponent,
  //       resolve: { user: MemberDetailResolver }
  //     },
  //     { path: "messages", component: MessagesComponent },
  //     { path: "lists", component: ListsComponent }
  //   ]
  // },
  { path: "materiales", component: MaterialListComponent },
  { path: "addMaterial", component: MaterialAddComponent },
  {
    path: "materiales/:id",
    component: MaterialEditComponent,
    resolve: { material: MaterialEditResolver }
  },
  { path: "materiales/:id/viajeros", component: MaterialViajerosListComponent },
  { path: "recibos", component: ReciboListComponent },
  { path: "recibos/:id", component: ReciboDetailComponent },
  {
    path: "detalleRecibo/:id",
    component: DetalleReciboEditComponent,
    resolve: { detalleRecibo: DetalleReciboEditResolver }
  },
  { path: "viajeros/:id", component: ViajeroDetailComponent },
  {
    path: "viajeroedit/:id",
    component: ViajeroEditComponent,
    resolve: { viajero: ViajeroEditResolver }
  },
  { path: "viajeros", component: ViajeroListComponent },
  { path: "addRecibo", component: ReciboAddComponent },
  { path: "existencias", component: ExistenciasMaterialListComponent },
  { path: "addAlmacen", component: ExistenciasAddComponent },
  { path: "produccion", component: ProduccionListComponent },
  { path: "requerimientoMaterial", component: RequerimientoMaterialComponent },
  { path: "requerimientos", component: RequerimientoMaterialListComponent },
  { path: "requerimientosprod", component: RequerimientoProdListComponent },
  {
    path: "requerimientos/:id",
    component: RequerimientoMaterialProdComponent,
    resolve: { req: RequerimientoMaterialProdResolver }
  },
  { path: "solicitarMaterial/:id", component: MaterialProdComponent },
  { path: "moldes", component: MoldeListComponent },
  {
    path: "moldes/:id",
    component: MoldeEditComponent,
    resolve: { molde: MoldeEditResolver }
  },
  { path: "addMolde", component: MoldeAddComponent },
  { path: "numerosParte", component: NumerosParteListComponent },
  {
    path: "numerosParte/:id",
    component: NumeroParteEditComponent,
    resolve: { numeroParte: NumeroParteEditResolver }
  },
  { path: "addNumeroParte", component: NumeroParteAddComponent },
  { path: "moldeadoras", component: MoldeadoraListComponent },
  {
    path: "moldeadoras/:id",
    component: MoldeadoraSetupComponent,
    resolve: { moldeadora: MoldeadoraEditResolver },
    runGuardsAndResolvers: "always"
  },
  { path: "addMoldeadora", component: MoldeadoraAddComponent },
  { path: "tiposmaterial", component: TipoMaterialListComponent },
  { path: "addTipoMaterial", component: TipoMaterialAddComponent },
  {
    path: "tiposmaterial/:id",
    component: TipoMaterialEditComponent,
    resolve: { tipoMaterial: TipoMaterialEditResolver }
  },
  { path: "ordenescompra", component: OrdenCompraListComponent },
  { path: "addOrdenCompra", component: OrdenCompraAddComponent },
  {
    path: "ordenescompra/:id",
    component: OrdenCompraEditComponent,
    resolve: { ordenCompra: OrdenCompraEditResolver }
  },
  {
    path: "detallesordencompra/:id",
    component: DetalleOrdenCompraEditComponent,
    resolve: { detalleOrdenCompra: DetalleOrdenCompraEditResolver }
  },
  { path: "addProduccion", component: ProduccionAddComponent },
  { path: "lists", component: MaterialAddComponent },
  { path: "motivostiempomuerto", component: MotivoTiempoMuertoListComponent },
  { path: "addMotivoTiempoMuerto", component: MotivoTiempoMuertoAddComponent },
  {
    path: "motivostiempomuerto/:id",
    component: MotivoTiempoMuertoEditComponent,
    resolve: { motivoTiempoMuerto: MotivoTiempoMuertoEditResolver }
  },
  { path: "clientes", component: ClienteListComponent },
  { path: "addCliente", component: ClienteAddComponent },
  {
    path: "clientes/:id",
    component: ClienteEditComponent,
    resolve: { cliente: ClienteEditResolver }
  },
  { path: "proveedores", component: ProveedorListComponent },
  { path: "addProveedor", component: ProveedorAddComponent },
  {
    path: "proveedores/:id",
    component: ProveedorEditComponent,
    resolve: { proveedor: ProveedorEditResolver }
  },
  { path: "**", redirectTo: "", pathMatch: "full" }
];
