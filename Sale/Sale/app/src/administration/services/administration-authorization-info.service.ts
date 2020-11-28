import { Injectable } from '@angular/core';
import {CookieService} from "ngx-cookie-service";

/**
 * Сервис для работы с авторизацией администратора
 */
@Injectable()
export class AdministrationAuthorizationInfoService {

  //Количество дней до истечения срока действия файлов cookie
  private readonly cookieDays: number = 1000;
  //Имя cookie для логина администратора
  private readonly loginCookieName = 'login';
  //Имя cookie для пароля администратора
  private readonly passwordCookieName = 'password';

  constructor(private cookieService:CookieService) { }

  //устанавливаем cookie админа
  setAdminCookies(login:string, password:string) {
    this.cookieService.set(this.loginCookieName, login, this.cookieDays);
    this.cookieService.set(this.passwordCookieName, password, this.cookieDays);
  }

  //Проверяем авторизованность администратора
  get isAdminAuthorized():boolean{
    return !!this.adminLogin;
  }

  //Возвращает логин администратора
  get adminLogin():string{
    return this.cookieService.get(this.loginCookieName);
  }
}
