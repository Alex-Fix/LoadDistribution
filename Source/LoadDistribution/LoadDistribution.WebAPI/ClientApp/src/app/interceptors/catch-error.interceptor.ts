import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';

@Injectable()
export class CatchErrorInterceptor implements HttpInterceptor {

  constructor(
    private readonly _snackBar: MatSnackBar,
    private readonly _translateService: TranslateService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      retry(3),
      catchError(error => {
        this._translateService
          .get('common.snackBar.close')
          .subscribe(literal => {
            this._snackBar.open(error?.error, literal, { duration: 3000, panelClass: 'errorSnack' })
          });

        return throwError(error);
      })
    );
  }
}
