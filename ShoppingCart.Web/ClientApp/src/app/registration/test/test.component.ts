import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import * as alertyfy from 'alertifyjs';


@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
  ) { }

  userForm = new FormGroup(
    {
      username: new FormControl('',[Validators.required]),
      quantity: new FormControl('',[Validators.required,Validators.min(1),Validators.max(10)])
    }
  );



  // userForm = this.formBuilder.group(
  //   {
  //     username: ["", [Validators.required, Validators.minLength(3)]],
  //     quantity: ["", [Validators.required]]
  //   }
  // );

  get username() {
    return this.userForm.get('username')
  }

  get quantity() {
    return this.userForm.get('quantity')
  }


  ngOnInit() { }

  clear() {
    this.userForm.reset();
    //this.username.setValue("");
  }

  onSubmit() {
    console.log(this.userForm.value);
  }
}
