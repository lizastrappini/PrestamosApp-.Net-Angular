import { Component } from '@angular/core';
import { Router, RouterOutlet,ActivatedRoute } from '@angular/router';
import { LoanService } from '../Services/loan.service';
import { Thing } from '../Interfaces/thing';
import { ThingService} from '../Services/thing.service';
import { CommonModule, formatDate } from '@angular/common';
import { AbstractControl, FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { CategoryService } from '../Services/category.service';
import { Category } from '../Interfaces/category';
import { Loan } from '../Interfaces/loan';
import { format } from 'date-fns';

@Component({
  selector: 'app-loan',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule, ],
  templateUrl: './loan.component.html',
  styleUrl: './loan.component.css'
})
export class LoanComponent {
  
  dataThing:Thing | undefined;
  dataCategory: Category | undefined;

  constructor(private route: ActivatedRoute, 
    private thingService: ThingService, 
    private loanService: LoanService,
    private fb: FormBuilder,
    private router:Router,
    private categoryService: CategoryService) { }

  validDate(control: AbstractControl) {
    const returnDate = new Date(control.value);
    const actualDate = new Date();

    if (returnDate < actualDate) {
      return { invalidDate: true };
    }
    return null;
  }
  
  formulario = this.fb.group({
    returnDate : new FormControl('', [Validators.required, this.validDate.bind(this)]),
    borrowedTo: new FormControl('', [Validators.required]),
  });

 
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      if (idParam) {
        const id = parseInt(idParam, 10);
        this.thingService.getById(id).subscribe({
          next: (data) => {
            console.log("a ver:"+data)
            this.dataThing = data;
            this.getCategoryDescription(this.dataThing.IdCategory!)
          },
          error: (err) => { console.log(err); },
        });
      }
    })
  }

  getCategoryDescription(idThing : number){
    this.categoryService.getById(idThing ).subscribe({
      next: (data) => {
        console.log("a ver:"+data)
        this.dataCategory = data;
      },
      error: (err: any) => { console.log(err); },
    });
  }
  
  loan(){

    const dateObject = new Date(this.formulario.value.returnDate!);
    const formattedDate = format(dateObject, 'yyyy-MM-dd HH:mm:ss');
    
    var loan: Omit<Loan, 'Id'> = {
      ReturnDate: new Date(formattedDate),
      CreationDateTime: new Date(),
      Status: "Prestado",
      DniPerson: 123,
      IdThing: this.dataThing?.Id,
      BorrowerName: this.formulario.value.borrowedTo,
    };

    this.loanService.add(loan).subscribe({
      next: (data) => { 
        this.router.navigate(['/thing']);
      },
      error: (err: any) => { console.log(err); },
    })

}
}