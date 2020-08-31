import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { AuthService } from '../../Services/auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from '../../services/user-service.service';
import { finalize } from 'rxjs/operators';
import { AlertifyService } from 'src/app/Services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private spinner: NgxSpinnerService,
    private alertifyService: AlertifyService,
    private userService: UserService) { }

  userForm = this.formBuilder.group(
    {
      username: [
        "",
        [Validators.required, Validators.minLength(3)],
        this.userService.validateUsernameNotTaken.bind(this.userService)
      ],
      email: ["",
        [Validators.required]],
      password: ["", Validators.required],
      confirmPassword: ["", Validators.required],//, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")
      firstname: ["", Validators.required],
      lastname: ["", Validators.required],
      mobilenumber: ["", Validators.required],//, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")
      address1: ["", Validators.required],
      address2: ["", Validators.required],
      address3: ["", Validators.required],
    }, {
    validator: this.userService.passwordMatchValidator(
      "password",
      "confirmPassword"
    )
  }
  );


  get username() {
    return this.userForm.get("username");
  }

  get email() {
    return this.userForm.get("email");
  }

  get confirmPassword() {
    return this.userForm.get("confirmPassword");
  }

  get password() {
    return this.userForm.get("password");
  }

  get firstname() {
    return this.userForm.get("firstname");
  }

  get lastname() {
    return this.userForm.get("lastname");
  }

  get mobilenumber() {
    return this.userForm.get("mobilenumber");
  }

  get address1() {
    return this.userForm.get("address1");
  }

  get address2() {
    return this.userForm.get("address2");
  }

  get address3() {
    return this.userForm.get("address3");
  }

  ngOnInit() { }

  clear() {
    this.userForm.reset();
    //this.username.setValue("");
  }

  onSubmit() {
    console.log(this.userForm.value);
    this.authService.register(this.userForm.value)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(
        result => {
          if (result) {
            this.alertifyService.success('Registration successful');
          }
        },
        error => {
          this.alertifyService.error(error);
        });
  }
}
