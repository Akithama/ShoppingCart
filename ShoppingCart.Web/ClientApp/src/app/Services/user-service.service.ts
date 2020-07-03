import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  readonly rootUrl = 'http://localhost:4000';

  constructor(private http: HttpClient) { }
  
  registerUser(user : User){
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }
    return this.http.post(this.rootUrl + '/api/User/Register', body);
  }
}
