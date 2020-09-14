import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, Form, FormGroup, FormControl } from '@angular/forms';
import { StorageService } from 'src/app/Services/storage.service';
import { UserService } from 'src/app/services/user-service.service';
import { UserUpdate } from 'src/app/Models/UserUpdate';
import { AuthService } from 'src/app/Services/auth.service';
import { finalize } from 'rxjs/operators';
import { NgxSpinnerService } from 'ngx-spinner';
import { AlertifyService } from 'src/app/Services/alertify.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  id: string
  user: UserUpdate
  profileForm: FormGroup
  cardForm: FormGroup

  model;
  bsValue: Date = new Date();

  constructor(
    private storageService: StorageService,
    private userService: UserService,
    private authService: AuthService,
    private spinner: NgxSpinnerService,
    private alertifyService: AlertifyService) {
  }

  ngOnInit(): void {    

    this.profileForm = new FormGroup({
      userId: new FormControl(''),
      username: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      firstname: new FormControl('', [Validators.required]),
      lastname: new FormControl('', [Validators.required]),
      mobilenumber: new FormControl('', [Validators.required]),
      address1: new FormControl('', [Validators.required]),
      address2: new FormControl('', [Validators.required]),
      address3: new FormControl('', [Validators.required])
    });

    this.id = this.storageService.decryptData(sessionStorage.getItem("user_id"))
    this.userService.find(this.id).subscribe((data) => {
      this.user = data;
      console.log(data)
      this.profileForm.patchValue({
        userId: data.userId,
        username: data.userName,
        email: data.email,
        firstname: data.firstName,
        lastname: data.lastName,
        mobilenumber: data.mobileNumber,
        address1:data.address1,
        address2:data.address2,
        address3:data.address3
      })
    });

    this.cardForm = new FormGroup({
      nameOnCard: new FormControl('', [Validators.required]),
      cardNumber: new FormControl('', [Validators.required]),
      expireDate: new FormControl('', [Validators.required]),
      cvv: new FormControl('', [Validators.required]),
    })
  }

  get f() {
    return this.profileForm.controls;
  }

  onSubmit() {
    this.authService.updateUser(this.profileForm.value)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(
        result => {
          if (result) {
            this.alertifyService.success('User Update successful');
          }
        },
        error => {
          this.alertifyService.error(error);
        });
  }

  onPaymentSubmit(){
    this.authService.registerCard(this.cardForm.value)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(
        result => {
          if (result) {
            this.alertifyService.success('Card Registration successful');
          }
        },
        error => {
          this.alertifyService.error(error);
        });
  }

  get userId() {
    return this.profileForm.get("userId");
  }

  get username() {
    return this.profileForm.get("username");
  }

  get email() {
    return this.profileForm.get("email");
  }

  get firstname() {
    return this.profileForm.get("firstname");
  }

  get lastname() {
    return this.profileForm.get("lastname");
  }

  get mobilenumber() {
    return this.profileForm.get("mobilenumber");
  }

  get address1() {
    return this.profileForm.get("address1");
  }

  get address2() {
    return this.profileForm.get("address2");
  }

  get address3() {
    return this.profileForm.get("address3");
  }
}
