import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {switchMap} from "rxjs/operators";
import {AdministrationApiService} from "../../services/administration-api.service";
import {Observable} from "rxjs";
import {ComponentCanDeactivate} from "../../guards/exit-book-editor.guard";
import {NgForm} from "@angular/forms";
import {BooksListService} from "../../../user/services/books-list.service";
import {Book} from "../../../user/models/book";

@Component({
  selector: 'administration-book-editor',
  templateUrl: './book-editor.component.html',
  styleUrls: ['./book-editor.component.scss']
})
export class BookEditorComponent implements OnInit, ComponentCanDeactivate {

  @ViewChild("bookInfoForm")
  form: NgForm;

  //Возвращает true, если на форме были изменения
  get IsDirty(): boolean{
    if (!this.form) return false;
    return this.form.dirty;
  }

  constructor(private route:ActivatedRoute, private booksListService:BooksListService, private administrationApiService:AdministrationApiService) { }

  //редактируемая книга
  book:Book;

  //id редактируемой книги
  bookId:number;

  //Флаг задающий возможность редактирования книги
  canEdit:boolean;

  async ngOnInit() {
    //получаем id книги из параметров маршрута
    await this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
      .subscribe(data => this.bookId = +data);
    //если параметры маршрута содержат id книги, инициализируем book
    if(this.bookId) {
      this.book = this.booksListService.books.find(x => x.id === this.bookId);
    }
    //иначе создаём новую книги
    else {
      this.book = new Book();
    }
    this.canEdit = false;
  }

  //изменяет значение флага canEdit на противоположное
  changeEditingCapability() {
    this.canEdit = !this.canEdit;
  }

  //Обработчик кнопки "Сохранить"
  async updateOrCreateBook() {

    //Иначе обновляем информацию о существующей книге
    if(this.book.id)
    {
      await this.administrationApiService.updateBook(this.book);
    }
    //Если книга новая, то добавляем её в бд
    else{
      await this.administrationApiService.createNewBook(this.book);
    }
    this.canEdit = false;
  }

  //Метод гуарда, который срабатывает при уходе с компонента (с маршрута компонента)
  canDeactivate() : boolean | Observable<boolean>{
    //Если есть несохранённые изменения выводим диалоговое окно
    if(this.IsDirty){
      return confirm("Остались несохранённые изменения. Вы действительно хотите покинуть страницу?");
    }
    else{
      return true;
    }
  }
}
