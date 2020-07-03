import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserRegistration } from 'src/app/shared/Models/user-registration.model';
import { finalize } from 'rxjs/operators';
import { AlertService } from 'src/app/Services/alert.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  success: boolean;
  error: string;
  userRegistration: UserRegistration = { username: '', password: '', firstname: '', lastname: '',email:'', mobilenumber:'' };
  //model:any={};
  
  constructor(private authService: AuthService, private spinner: NgxSpinnerService, private alertService: AlertService) { }

  ngOnInit(): void {
  }

  register(){
    //console.log(this.model);
    this.spinner.show();

    this.authService.register(this.userRegistration)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(
        result => {
          if (result) {
            this.success = true;
            this.alertService.success('Registration successful');
          }
        },
        error => {
          this.alertService.error(error);
        });
  
  }

}
