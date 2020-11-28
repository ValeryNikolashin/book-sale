import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Book} from "../models/book";
import {Order} from "../models/order";

/**
 * Сервис для работы с Api сервера
 */
@Injectable()
export class ApiService {

  constructor(private http: HttpClient) { }

  //получаем новый промокод с сервера
  async getPromoCode():Promise<string> {
    return await this.http.get<string>('api/User/GetPromoCode').toPromise();
  }

  //проверяем наличие промокода в базе
  async checkPromoCode(promoCode: string):Promise<boolean> {
    return await this.http.post<boolean>('api/User/TryLogIn?promoCode=' + promoCode, null).toPromise();
  }

  //получаем список всех книг, участвующих в распродаже
  getBooks() {
    return this.http.get<Book[]>('api/User/GetBooks');
  }

  //получаем список всех книг заказа по промокоду пользователя
  async getOrderBooks(promoCode:string):Promise<Book[]> {
    return await this.http.get<Book[]>('api/User/GetOrderBooks?promoCode='+promoCode).toPromise();
  }

  //добавляет книгу в корзину
  async tryToAddBookToBasket(promoCode:string,bookId:number):Promise<boolean>{
    return await this.http.post<boolean>('api/User/TryToAddBookToBasket?promoCode='+promoCode+"&bookId="+bookId,null).toPromise();
  }

  //удаляет книгу из корзины
  async deleteBookFromBasket(promoCode:string, bookId:number):Promise<void>{
    await this.http.post<boolean>('api/User/DeleteBookFromBasket?promoCode='+promoCode+"&bookId="+bookId,null).toPromise();
  }

  //регистрирует заказ
  async toRegisterOrder(promoCode: string):Promise<void>{
    await this.http.post('api/User/ToRegisterOrder?promoCode=' + promoCode, null).toPromise()
  }

  //получает заказ по промокоду
  async getOrder(promoCode:string):Promise<Order>{
    return await this.http.get<Order>('api/User/GetOrder?promoCode=' + promoCode).toPromise()
  }
}
