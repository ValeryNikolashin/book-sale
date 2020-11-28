import { Injectable } from '@angular/core';
import {Book} from "../models/book";
import {ApiService} from "./api.service";

/**
 * Сервис для работы со списком книг каталога
 */
@Injectable()
export class BooksListService {

  //список книг распродажи
  private _books:Book[];

  //Возвращает список книг распродажи
  get books(): Book[] {
    return this._books;
  }

  //задаёт список книг распродажи, запрашивая их с сервера
  setBooksList() {
    this.apiService.getBooks().subscribe(data=>this._books=data);
  }

  //изменяет количество, доступных для продажи экземпляров книг
  //у книги с id = bookId
  changeBooksCount(bookId:number, booksCount){
    let book = this._books.find(x=>x.id===bookId).count=booksCount;
  }

  constructor(private apiService:ApiService) { }
}
