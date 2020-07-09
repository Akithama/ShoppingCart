import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../shared/config.service';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private configService: ConfigService) {

   }

   register(userRegistration: any) {    
     return this.http.post(this.configService.authApiURI + '/user/register', userRegistration)
     .pipe(
       map((data: any) => {
         return data;
       }), catchError(error => {
         return throwError('Something went wrong!' + error);
       })
     )
     //.pipe(catchError(this.handleError));
  }
}
