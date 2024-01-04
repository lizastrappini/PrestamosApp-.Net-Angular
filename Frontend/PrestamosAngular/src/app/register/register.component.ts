import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PersonService } from '../Services/person.service';
import { Person } from '../Interfaces/person';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  validarPasswords(control: AbstractControl): { [key: string]: any } | null {
    const password1 = control.get('password1');
    const password2 = control.get('password2');

    if (password1 && password2 && password1.value !== password2.value) {
      password2.setErrors({ passNoCoinciden: true });
      return { passNoCoinciden: true };
    } else {
      password2?.setErrors(null);
      return null;
    }
  }

  formulario = this.fb.group({
    dni: new FormControl('', [Validators.required, Validators.pattern(/^[0-9]\d*$/), Validators.minLength(7), Validators.maxLength(8)]),
    name: new FormControl('', [Validators.required, Validators.nullValidator]),
    lastName: new FormControl('', [Validators.required,Validators.nullValidator]),
    phoneNumber: new FormControl('', [Validators.required, Validators.pattern(/^[0-9]\d*$/)]),
    email : new FormControl('', [Validators.required, Validators.email]),

    passwords: new FormGroup({
    password1: new FormControl('', [Validators.required, ]),
    password2: new FormControl('', [Validators.required]),
    },{ validators: [this.validarPasswords] })

  });

  constructor(private fb:FormBuilder, private personService: PersonService){}

  Submit(){
    const newPerson = {
      Dni : parseInt(this.formulario.value.dni!),
      Name : this.formulario.value.name!.toString(),
      LastName :this.formulario.value.lastName!.toString(),
      PhoneNumber : this.formulario.value.phoneNumber!.toString(),
      Email : this.formulario.value.email!.toString(),
      Password : this.formulario.value.passwords!.password1!.toString(),
      
    }

    this.personService.register(newPerson).subscribe({
      next:(data)=>{
        console.log(data);
        this.personService.login(newPerson).subscribe({
          next:(data)=>{
            console.log(data);
            localStorage.setItem('dniUser',data.dni);
            localStorage.setItem('token',data.token);
            window.location.href = '/index';
          },error:(err)=>{
            console.log(err);
          }
        })
      },error:(err)=>{
        throw err;
        
      }
    })
  }

}
