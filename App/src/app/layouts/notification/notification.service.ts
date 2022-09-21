import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StandardService } from '../../service/Standart.service';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

const url = `${environment.URL}/Notification`;

@Injectable({
  providedIn: 'root'
})
export class NotificationService extends StandardService<any>  {
  constructor(
    protected http: HttpClient) {
    super(http, url, true)
  }
  getById(id: number): Observable<any> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.get(this.url, { params });
  }

  getByFilter(filter: any): Observable<any> {
    let params = new HttpParams();
    params = params.append('sortField', filter.sortField || '');
    params = params.append('sortOrder', filter.sortOrder || '');
    params = params.append('page', filter.page ? filter.page.toString() : '1');
    params = params.append('pageSize', filter.pageSize ? filter.pageSize.toString() : '1');
    if (filter.tipo) {
      params = params.append('tipo', filter.tipo.toString())
    }
    return this.http.get(this.url, { params });
  }
  post(notification: any, callback?) {
    this.http.post<any>(this.url, notification)
      .subscribe((resp: any) => {
        callback(resp);
      });
  }
}
