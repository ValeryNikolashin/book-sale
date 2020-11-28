import {CookieService} from "ngx-cookie-service";
import {Injectable} from "@angular/core";

/**
 * Сервис для работы с авторизацией
 */
@Injectable()
export class AuthorizationInfoService {

  //Количество дней до истечения срока действия файлов cookie
  private readonly cookieDays: number = 1000;
  //Название cookie для промокода
  private readonly promoCodeCookieName = 'promoCode';
  //Название cookie для логина администратора
  private readonly loginCookieName = 'login';
  //Название cookie для пароля администратора
  private readonly passwordCookieName = 'password';

  //Возрващает промокод
  get promoCode(): string {
    return this.cookieService.get(this.promoCodeCookieName);
  }

  constructor(private cookieService:CookieService) {

  }

  //проверяем авторизованность пользователя
  get isAuthorized():boolean {
    return !!this.promoCode;
  }

  //устанавливаем куки пользователя
  setCookieFromPromoCode(promoCode:string) {
    this.cookieService.set(this.promoCodeCookieName, promoCode, this.cookieDays);
  }

  //удаляем куки пользователя (разлогиниваемся)
  deletePromoCodeCookies() {
    this.cookieService.delete(this.promoCodeCookieName);
  }

  get adminLogin():string{
    return this.cookieService.get(this.loginCookieName);
  }

  get isAdminAuthorized():boolean{
    return !!this.adminLogin
  }

  //удаляем cookie админа
  deleteAdminCookies(){
    this.cookieService.delete(this.loginCookieName);
    this.cookieService.delete(this.passwordCookieName);
  }
}
