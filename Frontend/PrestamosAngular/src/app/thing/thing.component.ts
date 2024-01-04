import {Thing} from '../Interfaces/thing';
import {ThingService} from '../Services/thing.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import {Router, RouterModule, RouterOutlet } from '@angular/router';
import { LoanService } from '../Services/loan.service';

@Component({
  selector: 'app-thing',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ReactiveFormsModule, HttpClientModule,RouterModule],
  templateUrl: './thing.component.html',
  styleUrl: './thing.component.css'
})
export class ThingComponent implements OnInit {
  listThings:Thing[] = [];
  
  FormThing:FormGroup;

  listAvailableThings:Thing[] = [];

  listBorrowedThings:Thing[] = [];

 constructor( private thingService: ThingService, 
  private formBuilder: FormBuilder, 
  private router:Router, 
  private loanService: LoanService,
  private cdr: ChangeDetectorRef){
  this.FormThing = this.formBuilder.group({
    Description: ["",Validators.required],
  })
 }
 
 ngOnInit(): void {
  this.getAvailablesByDni(localStorage.getItem('dniUser') as unknown as number)
  this.getBorrowedByDni(localStorage.getItem('dniUser') as unknown as number)
  }


  getAvailablesByDni(dni:number){
    this.thingService.getAvailablesByDni(dni).subscribe({
      next:(data)=>{
        
        this.listAvailableThings = data;

      },error:(err)=>{console.log(err);},
    })
  }

  getBorrowedByDni(dni:number){
    this.thingService.getBorrowedByDni(dni).subscribe({
      next:(data)=>{
        this.listBorrowedThings = data;
        data.forEach(thing => {
          this.loanService.getById(thing.Id!).subscribe(
            (data)=>{  
              console.log(data)
              thing.Loan = data}
          )
        });
      },error:(err)=>{console.log(err);},
    })
  }

  addThing(){
    this.router.navigate(["/addThing"])
    
  } 

  toLoan(idThing: number){
    this.router.navigate(['/loan', idThing]);
  }

  returnLoan(id : number){
    this.loanService.returnLoan(id).subscribe({
      next:(data)=>{
        this.cdr.detectChanges();
      },error:(err)=>{console.log(err);},
    })
  }

  add(){
    this.router.navigate(['/addThing'])
  }

}
