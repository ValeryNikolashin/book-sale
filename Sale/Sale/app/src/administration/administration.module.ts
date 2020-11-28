import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdministrationComponent } from './components/administration/administration.component';
import {AdministratorAuthorizationComponent} from "./components/administrator-authorization/administrator-authorization.component";
import {BookEditorComponent} from "./components/book-editor/book-editor.component";
import {UserModule} from "../user/user.module";
import {AdministrationApiService} from "./services/administration-api.service";
import {AdministrationAuthorizationInfoService} from "./services/administration-authorization-info.service";
import {ExitBookEditorGuard} from "./guards/exit-book-editor.guard";
import {BrowserModule} from "@angular/platform-browser";
import {AppRoutingModule} from "../app/app-routing.module";
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";



@NgModule({
  declarations: [AdministrationComponent, AdministratorAuthorizationComponent, BookEditorComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    UserModule
  ],
  providers:[AdministrationApiService, AdministrationAuthorizationInfoService, ExitBookEditorGuard]
})
export class AdministrationModule { }
