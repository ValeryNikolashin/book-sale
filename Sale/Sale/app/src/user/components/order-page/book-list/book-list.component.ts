import {Component, OnDestroy, OnInit} from '@angular/core';
import {Book} from "../../../models/book";
import {HttpClient} from "@angular/common/http";
import {ApiService} from "../../../services/api.service";
import {AuthorizationInfoService} from "../../../services/authorization-info.service";
import {OrderBooksService} from "../../../services/order-books.service";
import {CounterHub} from "../../../hubs/counter-hub";
import {BooksListService} from "../../../services/books-list.service";
import {OrderStatuses} from "../../../enums/order-statuses.enum";

@Component({
  selector: 'user-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit, OnDestroy {

  constructor(private httpClient:HttpClient, private apiService:ApiService,
              private authorizationInfoService:AuthorizationInfoService,
              private orderBooksService:OrderBooksService,
              private counterHub:CounterHub,
              private booksListService:BooksListService)
  { }

  //возвращает список книг распродажи
  get books():Book[]{
    return this.booksListService.books;
  }

  //возвращает статус заказа
  private get orderStatus():OrderStatuses{
    return this.orderBooksService.orderStatus;
  };

  //если статус заказа отличен от нового, возвращает true
  //нужно чтобы задизейблить кнопки добавления в корзину
  get disabledBookButton():boolean{
    return this.orderStatus!==OrderStatuses.New;
  }

  async ngOnInit() {
    //инициализируем статус заказа
    await this.orderBooksService.setOrder();
    //инициализируем список книг
    await this.booksListService.setBooksList();
    //запускаем хаб
    await this.counterHub.startHub();
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

  //Возвращает true если книга с id=bookId есть в корзине
  locatedInBasket(bookId:number):boolean{
    return this.orderBooksService.locatedInBasket(bookId);
  }

  ngOnDestroy(): void {
    //останавливаем хаб
    this.counterHub.stopHub();
  }
}
