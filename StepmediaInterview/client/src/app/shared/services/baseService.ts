import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable()
export class BaseService {
  protected baseUrl: string;

  constructor(protected http: HttpClient) {
    this.baseUrl = environment.backendUrl;
  }

  protected get<Type>(url: string, options?: any): Observable<HttpEvent<Type>> {
    return this.http
      .get<Type>(this.baseUrl + url, options)
      .pipe(catchError(this.handleError));
  }

  protected post<Type>(
    url: string,
    data: any,
    options?: any
  ): Observable<HttpEvent<Type>> {
    return this.http
      .post<Type>(this.baseUrl + url, data, options)
      .pipe(catchError(this.handleError));
  }

  protected put<Type>(
    url: string,
    data: any,
    options?: any
  ): Observable<HttpEvent<Type>> {
    return this.http
      .put<Type>(this.baseUrl + url, data, options)
      .pipe(catchError(this.handleError));
  }

  protected delete<Type>(
    url: string,
    options?: any
  ): Observable<HttpEvent<Type>> {
    return this.http
      .delete<Type>(this.baseUrl + url, options)
      .pipe(catchError(this.handleError));
  }

  protected handleError(error: HttpErrorResponse) {
    return throwError(()=>error);
  }
}
