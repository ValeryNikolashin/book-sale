import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {CookieService} from "ngx-cookie-service";
import {AuthorizationInfoService} from "../../services/authorization-info.service";
import {ApiService} from "../../services/api.service";
import {Router} from "@angular/router";

@Component({
  selector: 'user-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.scss']
})
export class AuthorizationComponent implements OnInit {

  //наименование страницы распродажи (с книгами)
  private readonly SalePageName:string = 'sale';

  //наименование страницы администратора (с книгами)
  private readonly AdministrationPageName:string = 'administration';

  promoCode:string;

  constructor(private http: HttpClient, private cookieService:CookieService, private authorizationInfoService:AuthorizationInfoService,
              private apiService:ApiService,private router: Router){}

  ngOnInit(): void {
    //если администратор авторизован переходим на страницу редактирования книг
    if(this.authorizationInfoService.isAdminAuthorized){
      this.router.navigate([this.AdministrationPageName]);
    }
    else {
      //если авторизованы сразу переходим на страницу книг
      if(this.authorizationInfoService.isAuthorized)
      {
        this.router.navigate([this.SalePageName]);
      }
    }
  }

  //Запрашиваем новый промокод с сервера
  async getPromoCode() {
    this.promoCode = await this.apiService.getPromoCode();
  }

  //Авторизуем пользователя
  async logIn() {
    //Проверяем наличие промокода в базе
    if (await this.apiService.checkPromoCode(this.promoCode)) {
      //сохраняем cookie
      this.authorizationInfoService.setCookieFromPromoCode(this.promoCode);
      this.promoCode = '';
      this.router.navigate([this.SalePageName]);
    }
  }
}
