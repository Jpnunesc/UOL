import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  decodedToken: any;
  jwtHelper = new JwtHelperService();
  constructor(private http: HttpClient) { }


  login(login: string, password: string) {
      return this.http.post<any>(`${environment.URL}/users/authenticate`, { login, password })
          .pipe(map(data => {
              if (data.success) {
                  const user = data;
                  localStorage.setItem('token', user.token);
                  this.decodedToken = this.jwtHelper.decodeToken(user.token);
                  sessionStorage.setItem('username', this.decodedToken.unique_name);
              }
              return data;
          }));
  }
  register(model: any) {
      return this.http.post(`${environment.URL}register`, model);
    }
  
    loggedIn() {
      const token = localStorage.getItem('token');
      return !this.jwtHelper.isTokenExpired(token);
    }
    logout() {
      localStorage.removeItem('token');
    }
}
