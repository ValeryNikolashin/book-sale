import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FormsModule} from "@angular/forms";
import { HttpClientModule }   from '@angular/common/http';
import {RouterModule, Routes} from "@angular/router";
import {AuthorizationComponent} from "../user/components/authorization/authorization.component";
import {OrderPageComponent} from "../user/components/order-page/order-page.component";
import {AdministratorAuthorizationComponent} from "../administration/components/administrator-authorization/administrator-authorization.component";
import {BookEditorComponent} from "../administration/components/book-editor/book-editor.component";
import {AdministrationComponent} from "../administration/components/administration/administration.component";
import {ExitBookEditorGuard} from "../administration/guards/exit-book-editor.guard";
import {UserModule} from "../user/user.module";
import {AdministrationModule} from "../administration/administration.module";

// определение маршрутов
const appRoutes: Routes =[
  { path: '', component: AuthorizationComponent},
  { path: 'sale', component: OrderPageComponent},
  { path: 'adminLogIn', component: AdministratorAuthorizationComponent},
  { path: 'administration', component: AdministrationComponent },
  { path: 'bookEditor/:id', component: BookEditorComponent, canDeactivate:[ExitBookEditorGuard]},
  { path: 'bookEditor', component: BookEditorComponent, canDeactivate:[ExitBookEditorGuard]},
  { path: '**', component: AuthorizationComponent }
];

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    UserModule,
    AdministrationModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
