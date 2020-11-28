import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Book} from "../../user/models/book";

/**
 * Сервис для работы с Api админки
 */
@Injectable()
export class AdministrationApiService {

  constructor(private http:HttpClient) { }

  //проверяем соответствие логина и пароля данным администратора
  async tryToLoginAsAdmin(login:string, password:string):Promise<boolean>{
    return await this.http.post<boolean>('api/Administration/TryLoginAsAdmin?login='+login+'&password='+password,null).toPromise();
  }

  //отправляет обновлённую информацию о книге на сервер
  async updateBook(book:Book):Promise<boolean>{
    return await this.http.post<boolean>('api/Administration/TryUpdateBook',book).toPromise();
  }

  //отправляет информацию о новой книге на сервер
  async createNewBook(book:Book):Promise<boolean>{
    return await this.http.post<boolean>('api/Administration/TryCreateNewBook',book).toPromise();
  }
}
