import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import * as alertyfy from 'alertifyjs';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  id: number;

  form: FormGroup;


  constructor(
  ) { }

  ngOnInit() {        
    this.form = new FormGroup({
      title: new FormControl('', [Validators.required])
    });

    this.form.setValue({
      title: 'Title'
    })
  }

  clear() {
    this.form.reset();
  }

  submit() {
    console.log(this.form.value);
  }

  get f() {
    return this.form.controls;
  }

  get title(): any {
    return this.form.get('title');
  }

  setValue() {
    this.form.setValue({title:'Title'});
  }
}
