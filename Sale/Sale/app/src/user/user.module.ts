import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AuthorizationComponent} from "./components/authorization/authorization.component";
import {NavbarComponent} from "./components/navbar/navbar.component";
import {OrderPageComponent} from "./components/order-page/order-page.component";
import {BookListComponent} from "./components/order-page/book-list/book-list.component";
import {OrderSectionComponent} from "./components/order-page/order-section/order-section.component";
import {ApiService} from "./services/api.service";
import {AuthorizationInfoService} from "./services/authorization-info.service";
import {BooksListService} from "./services/books-list.service";
import {OrderBooksService} from "./services/order-books.service";
import {CounterHub} from "./hubs/counter-hub";
import {CookieService} from "ngx-cookie-service";
import {BrowserModule} from "@angular/platform-browser";
import {AppRoutingModule} from "../app/app-routing.module";
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";



@NgModule({
  declarations: [AuthorizationComponent, NavbarComponent, OrderPageComponent, BookListComponent, OrderSectionComponent],
  exports: [
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule
  ],
  providers:[
    CookieService, ApiService, AuthorizationInfoService, BooksListService, OrderBooksService, CounterHub
  ]
})
export class UserModule { }
