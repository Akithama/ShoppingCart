import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { User } from '../../shared/Models/user.model';
import { first } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { StorageService } from 'src/app/Services/storage.service';

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
    private alertifyService: AlertifyService,
    private route: ActivatedRoute,
    private router: Router,
    private storageService: StorageService) {
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
          this.alertifyService.success("Sucessfully Logged in");
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.alertifyService.error(error);
        });
  }
}
