import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { throwError, BehaviorSubject, Observable } from 'rxjs';
import { User } from '../shared/Models/user.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {

  }

  //Check whether the user is logged or not.
  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('auth_token');
    return (authToken !== null) ? true : false;
  }

  getUserName() {
    return localStorage.getItem('logged_userName');
  }

  register(userRegistration: any) {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };
    return this.http.post(environment.apiUrl + '/user/register', userRegistration, options)
      .pipe(
        map((data: any) => {
          return data;
        }), catchError(error => {
          return throwError(error);
        })
      )
  }

  login(username: string, password: string) {
    return this.http.post(environment.apiUrl + '/user/Authenticate', { username, password })
      .pipe(
        map((data: any) => {
          localStorage.setItem('auth_token', data.token);
          localStorage.setItem('logged_userName', data.username);
          return data;
        }), catchError(error => {
          return throwError(error);
        })
      )
  }

  logOut() {
    let removeToken = localStorage.removeItem('auth_token');
    let removeUser = localStorage.removeItem('logged_userName');
  }


}
