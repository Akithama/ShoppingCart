import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../../services/user-service.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  myForm: FormGroup;
  constructor(private fb: FormBuilder,
    //private signupService: UserService
  ) { }
  ngOnInit() {
    this.myForm = this.fb.group({
      name: ['', Validators.required],
      email: [
        '',
        [Validators.required, Validators.email]//,
        //this.validateEmailNotTaken.bind(this)
      ]
    });
  }



}
