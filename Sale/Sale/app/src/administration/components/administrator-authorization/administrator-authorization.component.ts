import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {AdministrationAuthorizationInfoService} from "../../services/administration-authorization-info.service";
import {AdministrationApiService} from "../../services/administration-api.service";

@Component({
  selector: 'administration-administrator-authorization',
  templateUrl: './administrator-authorization.component.html',
  styleUrls: ['./administrator-authorization.component.scss']
})
export class AdministratorAuthorizationComponent implements OnInit {

  //наименование страницы администратора (с книгами)
  private readonly AdministrationPageName:string = 'administration';

  login:string;

  password:string;

  constructor(private administrationApiService:AdministrationApiService, private administrationAuthorizationInfoService:AdministrationAuthorizationInfoService, private router:Router) { }

  ngOnInit(): void {
    //если авторизованы сразу переходим на страницу книг (для администратора)
    if(this.administrationAuthorizationInfoService.isAdminAuthorized)
    {
      this.router.navigate([this.AdministrationPageName]);
    }
  }

  async logIn() {
    //Проверяем соответствие логина и пароля
    if (await this.administrationApiService.tryToLoginAsAdmin(this.login,this.password)) {
      //сохраняем cookie
      this.administrationAuthorizationInfoService.setAdminCookies(this.login,this.password);
      this.login = '';
      this.password = '';
      this.router.navigate([this.AdministrationPageName]);
    }
  }
}
