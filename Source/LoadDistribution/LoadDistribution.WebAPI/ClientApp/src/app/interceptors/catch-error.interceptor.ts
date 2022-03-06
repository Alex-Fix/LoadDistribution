import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
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
        // TODO: fix error formatting
        this._translateService
          .get('common.snackBar.close')
          .subscribe(literal => {
            this._snackBar.open(error?.errors, literal, { duration: 3000, panelClass: 'errorSnack' })
          });

        return throwError(error);
      })
    );
  }
}
