import { CanDeactivate} from '@angular/router';
import { Observable } from 'rxjs';
import {Injectable} from "@angular/core";

/**
 * Интерфейс для реализации Гуарда ExitBookEditorGuard
 */
export interface ComponentCanDeactivate{
  canDeactivate: () => boolean | Observable<boolean>;
}

/**
 * Гуард регулирующий уход со страницы компонента book-editor-component
 */
@Injectable()
export class ExitBookEditorGuard implements CanDeactivate<ComponentCanDeactivate> {
  canDeactivate(component: ComponentCanDeactivate) : Observable<boolean> | boolean{

    return component.canDeactivate ? component.canDeactivate() : true;
  }

}
