import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {BooksListService} from "../../../user/services/books-list.service";
import {Book} from "../../../user/models/book";

@Component({
  selector: 'administration-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.scss']
})
export class AdministrationComponent implements OnInit {

  //адрес страницыредактирования книги
  private readonly BookEditorPageName = "bookEditor";

  constructor(private booksListService:BooksListService, private router:Router) { }

  ngOnInit(): void {
    //инициализируем список книг каталога
    this.booksListService.setBooksList()
  }

  //возвращает список книг распродажи
  get books():Book[]{
    return this.booksListService.books;
  }

  //переходим на страницу создания новой книги
  createBook() {
    this.router.navigate([this.BookEditorPageName]);
  }

  //переходим на страницу редактирования книги с id=bookId
  editBook(bookId:number) {
    this.router.navigate([this.BookEditorPageName+'/'+bookId]);
  }
}
