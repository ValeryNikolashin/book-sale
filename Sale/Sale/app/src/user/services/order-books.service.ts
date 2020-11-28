import { Injectable } from '@angular/core';
import {Book} from "../models/book";
import {ApiService} from "./api.service";
import {AuthorizationInfoService} from "./authorization-info.service";
import {OrderStatuses} from "../enums/order-statuses.enum";
import {Order} from "../models/order";

/**
 * Сервис для работы с заказом
 */
@Injectable()
export class OrderBooksService {

  //книги заказа
  private _orderBooks:Book[];

  //статус заказа
  private _order:Order;

  //возвращает книги, находящиеся в корзине
  get orderBooks():Book[]{
    return this._orderBooks;
  };

  //возвращает текущий статус заказа
  get orderStatus(): OrderStatuses {
    if(!this._order) return null;
    return this._order.status;
  }

  //возвращает текущий статус заказа
  get orderUrl(): string {
    return this._order.url;
  }

  //инициализирует заказ, запрашивая его с сервера
  async setOrder() {
    this._order = await this.apiService.getOrder(this.authorizationInfoService.promoCode);
  }

  //инициализирует список книг корзины, запрашивая их с сервера
  async setOrderBooks() {
    this._orderBooks = await this.apiService.getOrderBooks(this.authorizationInfoService.promoCode);
  }

  //Возвращает true если книга с id=bookId есть в корзине
  locatedInBasket(bookId:number):boolean{
    if(!this._orderBooks){
      return false;
    }
    return this._orderBooks.some(x=>x.id==bookId);
  }

  //Возвращает цену заказа
  get orderCost():number{
    let orderCost:number = 0;
    if(this._orderBooks){
      for(let i:number = 0;i<this._orderBooks.length;i++){
        orderCost += this._orderBooks[i].cost;
      }
    }
    return orderCost;
  }

  constructor(private apiService:ApiService, private authorizationInfoService:AuthorizationInfoService) { }
}
