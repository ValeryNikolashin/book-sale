import {Component, OnInit} from '@angular/core';
import {Book} from "../../../models/book";
import {ApiService} from "../../../services/api.service";
import {HttpClient} from "@angular/common/http";
import {AuthorizationInfoService} from "../../../services/authorization-info.service";
import {OrderBooksService} from "../../../services/order-books.service";
import {OrderStatuses} from "../../../enums/order-statuses.enum";
import {Router} from "@angular/router";

@Component({
  selector: 'user-order-section',
  templateUrl: './order-section.component.html',
  styleUrls: ['./order-section.component.scss']
})
export class OrderSectionComponent implements OnInit {

  constructor(private httpClient:HttpClient, private apiService:ApiService, private authorizationInfoService:AuthorizationInfoService, private orderBooksService:OrderBooksService, private router:Router) { }

  //вовзращает текущий статус заказа
  private get orderStatus():OrderStatuses{
    return this.orderBooksService.orderStatus;
  };

  //Переход по ссылке для оплаты
  toPay():void{
    this.router.navigate([this.orderBooksService.orderUrl]);
  }

  //Определяет нужно ли отобразить текст с информацией об оформлении заказа
  get showRegisterText():boolean{
    return this.orderCost<2000 && this.orderStatus===OrderStatuses.New;
  }

  //Определяет нужно ли отобразить кнопку оформления заказа
  get showRegisterButton():boolean{
    return this.orderCost>2000 && this.orderStatus===OrderStatuses.New;
  }

  //Определяет нужно ли отобразить текст с информацией об оплате заказа
  get showWaitingText():boolean{
    return this.orderStatus===OrderStatuses.WaitingForProcessing;
  }

  //Определяет нужно ли отобразить кнопку оплаты заказа
  get showPaymentButton():boolean{
    return this.orderStatus===OrderStatuses.WaitingForPayment;
  }

  //если статус заказа отличен от нового, возвращает true
  //нужно чтобы задизейблить кнопки добавления в корзину
  get disabledBookButton(){
    return this.orderStatus!==OrderStatuses.New;
  }

  async ngOnInit() {
    //Инициализировать список книг заказа
    await this.orderBooksService.setOrderBooks();
  }

  //возвращает книги, находящиеся в корзине
  get orderBooks():Book[]{
    return this.orderBooksService.orderBooks;
  }

  //возвращает общую сумму всех книг заказа
  get orderCost():number{
    return this.orderBooksService.orderCost;
  }

  //добавляет книгу в корзину
  async onAddToBasket(bookId: number) {
    await this.apiService.tryToAddBookToBasket(this.authorizationInfoService.promoCode, bookId);
    await this.orderBooksService.setOrderBooks();
  }

  //удаляет книгу  из корзины
  async onDeleteFromBasket(bookId: number) {
    await this.apiService.deleteBookFromBasket(this.authorizationInfoService.promoCode, bookId);
    await this.orderBooksService.setOrderBooks();
  }

  //оформить заказ
  async onRegisterOrder() {
    if(this.orderCost>=2000) {
      await this.apiService.toRegisterOrder(this.authorizationInfoService.promoCode);
      await this.orderBooksService.setOrder();
    }
  }
}
