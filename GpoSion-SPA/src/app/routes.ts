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
  { path: "recibos", component: ReciboListComponent },
  { path: "recibos/:id", component: ReciboDetailComponent },
  { path: "addRecibo", component: ReciboAddComponent },
  { path: "existencias", component: ExistenciasMaterialListComponent },
  { path: "addAlmacen", component: ExistenciasAddComponent },
  { path: "produccion", component: ProduccionListComponent },
  { path: "solicitarMaterial/:id", component: MaterialProdComponent },
  { path: "lists", component: MaterialAddComponent },
  { path: "**", redirectTo: "", pathMatch: "full" }
];
