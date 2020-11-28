import {OrderStatuses} from "../enums/order-statuses.enum";

//заказ
export class Order {

  //id заказа
  id:number;

  //ссылка для оплаты заказа
  url:string;

  //статус заказа
  status:OrderStatuses;

  //ISBN-коды книг заказа
  bookIsbnCodes:string[];

  //промокод пользователя
  userPromoCode:string;
}
