import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LanguageService } from 'src/app/services/language.service';

@Injectable()
export class LanguageInterceptor implements HttpInterceptor {
  constructor(
    private readonly _languageService: LanguageService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const languageRequest: HttpRequest<unknown> = request.clone({
      setHeaders: {
        'Accept-Language': this._languageService.getSavedOrDefault()
      }
    });

    return next.handle(languageRequest);
  }
}
