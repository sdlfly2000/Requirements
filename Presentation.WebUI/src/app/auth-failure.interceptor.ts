import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable()
export class AuthFailureInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {

    return next.handle(req)
      .pipe(
        tap({
          error: (err) => {
            if (err instanceof HttpErrorResponse && err.status == 401) {
              window.location.href = "https://192.168.71.154/#/login?returnUrl=" + environment.serverUrl
            }
          }
        })
      );
  }
}
