import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { User } from '../../shared/Models/user.model';
import { AlertService } from 'src/app/Services/alert.service';
import { first } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  returnUrl: string;
  success: boolean;

  user: User = {
    id: 0, username: '', password: '', firstName: '', lastName: '', token: '', remember: false
  };

  constructor(
    private authService: AuthService,
    private spinner: NgxSpinnerService,
    private alertService: AlertService,
    private route: ActivatedRoute,
    private router: Router) {
    // redirect to home if already logged in
    if (this.authService.currentUserValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }


  login() {
    this.authService.login(this.user.username, this.user.password)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.alertService.error(error);
        });
  }
}
