import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { BsDropdownModule, TabsModule } from "ngx-bootstrap";

import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { HomeComponent } from "./home/home.component";
import { RouterModule } from "@angular/router";
import { appRoutes } from "./routes";
import { MaterialAddComponent } from './material-add/material-add.component';
import { MaterialListComponent } from './material-list/material-list.component';
import { ExistenciasAddComponent } from './existencias-add/existencias-add.component';
import { ProduccionListComponent } from './produccion-list/produccion-list.component';
import { MaterialProdComponent } from './material-prod/material-prod.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      MaterialAddComponent,
      MaterialListComponent,
      ExistenciasAddComponent,
      ProduccionListComponent,
      MaterialProdComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {}
