import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../shared/config.service';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private configService: ConfigService) {

   }

   register(userRegistration: any) {    
    return this.http.post(this.configService.authApiURI + '/user/register', userRegistration)//.pipe(catchError(this.handleError));
  }
}
