import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MustMatch } from '../../Helpers/must.match.validator';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../Services/auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { AlertService } from '../../Services/alert.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  success: boolean;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private spinner: NgxSpinnerService,
    private alertService: AlertService) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      mobilenumber: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      address1: ['', Validators.required],
      address2: ['', Validators.required],
      address3: ['', Validators.required]
    }, {
      validator: MustMatch('password', 'confirmPassword')
    });
  }

  get f() { return this.registerForm.controls; }

  onSubmit() {

    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    this.authService.register(this.registerForm.value)
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

    //console.log(this.registerForm.value);

    //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value, null, 4));
  }

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
  }
}



//import { Component, OnInit } from '@angular/core';
//import { AuthService } from 'src/app/Services/auth.service';
//import { NgxSpinnerService } from 'ngx-spinner';
//import { UserRegistration } from 'src/app/shared/Models/user-registration.model';
//import { finalize } from 'rxjs/operators';
//import { AlertService } from 'src/app/Services/alert.service';
//import { FormGroup, FormBuilder, Validators } from '@angular/forms';
//import { MustMatch } from '../../Helpers/must.match.validator';

//@Component({
//  selector: 'app-register',
//  templateUrl: './register.component.html',
//  styleUrls: ['./register.component.css']
//})
//export class RegisterComponent implements OnInit {

//  success: boolean;
//  error: string;
//  userRegistration: UserRegistration = {
//    username: '', password: '', firstname: '', lastname: '', email: '', mobilenumber: '',
//    address1: '', address2: '', address3: '', confirmPassword: ''
//  };

//  constructor(private authService: AuthService, private spinner: NgxSpinnerService, private alertService: AlertService) { }

//  ngOnInit(): void {

//  }

//  register() {
//    this.spinner.show();

//    this.authService.register(this.userRegistration)
//      .pipe(finalize(() => {
//        this.spinner.hide();
//      }))
//      .subscribe(
//        result => {
//          if (result) {
//            this.success = true;
//            this.alertService.success('Registration successful');
//          }
//        },
//        error => {
//          this.alertService.error(error);
//        });
//  }
//}

