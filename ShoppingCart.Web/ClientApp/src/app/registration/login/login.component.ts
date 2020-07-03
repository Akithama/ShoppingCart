import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserRegistration } from 'src/app/shared/Models/user-registration.model';
import { finalize } from 'rxjs/operators';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  // success: boolean;
  // error: string;
  // userRegistration: UserRegistration = { username: '', password: '', firstname: '' };
  model:any={};

  constructor(private authService: AuthService, private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
  }

  login() {
    //console.log(this.model);

    
  }
}
