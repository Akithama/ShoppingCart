import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FormGroup, AbstractControl } from '@angular/forms';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: "root"
})
export class UserService {
  constructor(private http: HttpClient) { }

  passwordMatchValidator(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.controls[password];
      const confirmPasswordControl = formGroup.controls[confirmPassword];

      if (!passwordControl || !confirmPasswordControl) {
        return null;
      }

      if (
        confirmPasswordControl.errors &&
        !confirmPasswordControl.errors.passwordMismatch
      ) {
        return null;
      }

      if (passwordControl.value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl.setErrors(null);
      }
    };
  }

  validateUsernameNotTaken(control: AbstractControl) {
    return this.checkUsernameNotTaken(control.value).pipe(
      map(res => {
        return res ? null : { usernameTaken: true };
      })
    );
  }

  //API call 
  checkUsernameNotTaken(username: string): Observable<boolean> {
    let params = new HttpParams().set('userName', username)
    return this.http.get("http://localhost:4000/user/userexists", { params }).pipe(
      map((usernameList: Array<any>) =>
        usernameList.filter(user => user.userName === username)
      ),
      map(users => !users.length)
    );
  }
}
