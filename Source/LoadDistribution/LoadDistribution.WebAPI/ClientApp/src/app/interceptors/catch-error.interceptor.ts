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
      catchError(error => {
        const message: string | null = typeof error?.error == 'string' ? error.error : null;

        // detailed error
        console.error (error);

        // error message
        this._translateService
          .get(['common.snackBar.error', 'common.snackBar.close'])
          .subscribe(literals => {
            this._snackBar.open(message ?? literals['common.snackBar.error'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'errorSnack' })
          });

        return throwError(error);
      })
    );
  }
}
