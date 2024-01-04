import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ThingService } from '../Services/thing.service';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { CategoryService } from '../Services/category.service';
import { Category } from '../Interfaces/category';
import { Thing } from '../Interfaces/thing';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-add-thing',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ReactiveFormsModule, HttpClientModule,RouterModule,FormsModule],
  templateUrl: './add-thing.component.html',
  styleUrl: './add-thing.component.css'
})
export class AddThingComponent implements OnInit {
  
  categories: Category[] =  []
  categorySelected!: Category[] ;
  
  constructor( 
    private thingService: ThingService, 
    //private loanService: LoanService,
    private fb: FormBuilder,
    private router:Router,
    private categoryService: CategoryService) { }

  formulario = this.fb.group({
    description : new FormControl('', [Validators.required]),
    category: new FormControl('', [Validators.required]),

  });

  ngOnInit(): void {
    this.getCategories()

  }

  getCategories(){
    this.categoryService.getAll().subscribe({
      next:(data)=>{
        console.log(data)
        this.categories = data
      },error:(err)=>{console.log(err);},
    })
  }


  addThing(){

    var thing: Omit<Thing, 'Id'> = {
      CreationDate: new Date(),
      Description: this.formulario.value.description,
      IdCategory: parseInt(this.formulario.value.category!,10),
      PersonDni: 123
    };

    this.thingService.add(thing!).subscribe({
      next:(data)=>{
        this.router.navigate(['/thing']);
      },error:(err)=>{console.log(err);},
    })
  }
}
