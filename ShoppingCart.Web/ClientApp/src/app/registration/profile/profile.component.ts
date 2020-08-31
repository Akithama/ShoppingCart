import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  profileForm = this.formBuilder.group(
    {
      username: ["", [Validators.required]],
      email: ["", [Validators.required]],
      firstname: ["", Validators.required],
      lastname: ["", Validators.required],
      mobilenumber: ["", Validators.required],
      address1: ["", Validators.required],
      address2: ["", Validators.required],
      address3: ["", Validators.required]
    });

  ngOnInit(): void {
  }

  get username() {
    return this.profileForm.get("username");
  }

  onSubmit() {
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
