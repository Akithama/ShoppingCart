import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { throwError, BehaviorSubject, Observable } from 'rxjs';
import { User } from '../shared/Models/user.model';
import { environment } from '../../environments/environment';
import { StorageService } from './storage.service';
import { Router } from '@angular/router';
import { userUrl } from 'src/config/api';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient, 
    private storageService: StorageService, 
    private router: Router) {
  }

  get isLoggedIn(): boolean {
    if (sessionStorage.getItem('auth_token') != null) {
      return true
    }
    false
    //let authToken = sessionStorage.getItem('auth_token')
    //return (authToken !== null) ? true : false;
  }

  getUserName() {
    //return localStorage.getItem('logged_userName');
    if (sessionStorage.getItem('logged_userName') != null) {
      this.storageService.decryptData(sessionStorage.getItem('logged_userName'))
    }
  }

  getUserFullName() {
    //return localStorage.getItem('user_fullName');
    if (sessionStorage.getItem('user_fullName') != null) {
      return this.storageService.decryptData(sessionStorage.getItem('user_fullName'))
    }
  }

  register(userRegistration: any) {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };
    return this.http.post(userUrl + '/register', userRegistration, options)
      .pipe(
        map((data: any) => {
          return data;
        }), catchError(error => {
          return throwError(error);
        })
      )
  }

  login(username: string, password: string) {
    return this.http.post(userUrl + '/Authenticate', { username, password })
      .pipe(
        map((data: any) => {
          sessionStorage.setItem('user_id', this.storageService.encryptData(data.userId))
          sessionStorage.setItem('auth_token', this.storageService.encryptData(data.token))
          sessionStorage.setItem('logged_userName', this.storageService.encryptData(data.username))
          sessionStorage.setItem('user_fullName', this.storageService.encryptData(data.firstName + ' ' + data.lastName))
          return data;
        }), catchError(error => {
          return throwError(error);
        })
      )
  }

  updateUser(userUpdate: any) {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };
    return this.http.put(userUrl + '/UpdateUser', userUpdate, options)
      .pipe(
        map((data: any) => {
          return data;
        }), catchError(error => {
          return throwError(error);
        })
      )
  }

  registerCard(paymentUpdate: any) {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };
    return this.http.put(userUrl + '/RegisterCard', paymentUpdate, options)
      .pipe(
        map((data: any) => {
          return data;
        }), catchError(error => {
          return throwError(error);
        })
      )
  }

  logOut() {
    sessionStorage.removeItem('user_id')
    sessionStorage.removeItem('auth_token')
    sessionStorage.removeItem('logged_userName')
    sessionStorage.removeItem('user_fullName')

    this.router.navigate(["/shoppingcart"])
  }
}
