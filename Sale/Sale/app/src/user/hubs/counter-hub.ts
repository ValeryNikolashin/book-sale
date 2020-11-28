import { Injectable } from '@angular/core';
import "signalr";
import {BooksListService} from "../services/books-list.service";

/**
 *  Хаб для "живого счётчика" */
@Injectable()
export class CounterHub {

  //url для обращения к хабу сервера
  private readonly url:string = "http://localhost:5000";

  //имя хаба на сервере
  private readonly hubName:string = "CounterHub";

  //имя метода хаба для изменения значения счётчика
  private readonly changeCounterHubEventName = "ChangeCounter";

  //Соединение
  connection: SignalR.Hub.Connection;

  //Прокси
  proxy: SignalR.Hub.Proxy;

  //Признак запуска хаба
  hubWorking: boolean = false;

  constructor(private booksListService:BooksListService) {

  }
  /**
   *  Запуск хаба */
  startHub(): JQueryPromise<any> {
    if (!this.hubWorking) {
      this.connection = $.hubConnection(this.url);
      this.proxy=this.connection.createHubProxy(this.hubName);
      //изменяем счётчик книг у книги с id=bookId
      this.proxy.on(this.changeCounterHubEventName, (bookId:number,booksCount:number) => {
        this.booksListService.changeBooksCount(bookId,booksCount);
      });
      this.hubWorking = true;
      return this.connection.start();
    }
  }
  /**
   * Остановка хаба*/
  stopHub() {
    if (this.hubWorking) {
      this.hubWorking = false;
      this.connection.stop();
      this.proxy = null;
    }
  }

}

