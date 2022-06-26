import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './baseService';

@Injectable({
  providedIn: 'root'
})
export class CalculationService extends BaseService  {

  constructor(http: HttpClient) {
    super(http);
  }


  public calculation(input: number[]): Observable<any> {
    let url = `/Calculations`;
    return this.post(url, input);
  }
}
