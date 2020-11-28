import {Component, OnInit} from '@angular/core';
import {AuthorizationInfoService} from "../../services/authorization-info.service";
import {Router} from "@angular/router";

@Component({
  selector: 'user-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private authorizationInfoService:AuthorizationInfoService, private router:Router) { }

  //проверка авторизованности пользователя
  get isAuthorized():boolean{
    return this.authorizationInfoService.isAuthorized;
  }

  //Возвращает промокод
  get promoCode():string{
    return this.authorizationInfoService.promoCode;
  }

  ngOnInit(): void {
  }

  //обработчик нажатия кнопки Выйти
  logOut():void {
      //Затираем cookie
      this.authorizationInfoService.deletePromoCodeCookies();
      //переходим на страницу авторизации
      this.router.navigate(['']);
  }

  //проверка авторизованности администратора
  get isAdminAuthorised():boolean {
    return this.authorizationInfoService.isAdminAuthorized;
  }

  //возвращает логин администратора
  get adminLogin():string{
    return this.authorizationInfoService.adminLogin;
  }

  //обработчик нажатия кнопки Выйти для администратора
  adminLogOut():void {
    //Затираем cookie
    this.authorizationInfoService.deleteAdminCookies();
    //переходим на страницу авторизации
    this.router.navigate(['']);
  }
}
