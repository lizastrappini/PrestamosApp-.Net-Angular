import {Person} from '../Interfaces/person';
import {PersonService} from '../Services/person.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {Component, OnInit} from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-person',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ReactiveFormsModule, HttpClientModule,RouterModule],
  templateUrl: './person.component.html',
  styleUrl: './person.component.css'
})
export class PersonComponent implements OnInit{
  listPeople:Person[] = [];
  FormPerson:FormGroup;

 constructor( private personService: PersonService, private formBuilder: FormBuilder){
  this.FormPerson = this.formBuilder.group({
    Name: ["",Validators.required],
    LastName: ["",Validators.required],
    PhoneNumber: ["",Validators.required],
    Email: ["",Validators.required],
    Password: ["",Validators.required],

  })
 }

 GetAllPeople(){
  this.personService.getAll().subscribe({
    next:(data)=>{
      this.listPeople = data;
    },error:(err)=>{console.log(err);},
  })
}
ngOnInit(): void {
    this.GetAllPeople();
}
}
