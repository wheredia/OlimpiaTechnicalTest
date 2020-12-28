import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AforoComponent } from './aforo/aforo.component';
import { AforoHabilitadoComponent } from './aforo-habilitado/aforo-habilitado.component';
import { AforoOcupacionComponent } from './aforo-ocupacion/aforo-ocupacion.component';
import { IngresarComponent } from './ingresar/ingresar.component';
import { SalirComponent } from './salir/salir.component';
import { ChartsModule, ThemeService } from 'ng2-charts';
//import { Aforo } from '../obj/aforo';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    AforoComponent,
    AforoHabilitadoComponent,
    AforoOcupacionComponent,
    IngresarComponent,
    SalirComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AforoComponent, pathMatch: 'full' },
      { path: 'ingresar', component: IngresarComponent },
      { path: 'salir', component: SalirComponent },
      { path: 'aforo', component: AforoComponent }
    ]), ChartsModule
  ],
  providers: [ThemeService/*, Aforo*/],
  bootstrap: [AppComponent]
})
export class AppModule { }
