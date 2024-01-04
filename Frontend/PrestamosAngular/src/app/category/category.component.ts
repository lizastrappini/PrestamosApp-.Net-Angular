import {Category} from '../Interfaces/category';
import {CategoryService} from '../Services/category.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {Component, OnInit} from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ReactiveFormsModule, HttpClientModule,RouterModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit{

  listCategories:Category[] = [];
  
 constructor( private categoryService: CategoryService){}

 GetAllCategories(){
  this.categoryService.getAll().subscribe({
    next:(data)=>{
      this.listCategories = data;
  },error:(err)=>{console.log(err);},
})
}

ngOnInit(): void {
    this.GetAllCategories();
}

}
