import { Component, OnInit } from '@angular/core';
import { PersonService } from '../Services/person.service';
import { Router, RouterOutlet } from '@angular/router';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterOutlet,CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent  {

  constructor(private personService: PersonService,private router:Router,private fb: FormBuilder) {}
  
  formulario = this.fb.group({
    email : new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
});

onSubmit() {
  const user = this.formulario.value;
        console.log(user);
        this.personService.login(user).subscribe(
          (response) => {
            //ver duracion de token
            console.log(response.user)
            console.log(response.token)
            localStorage.setItem('dniUser', JSON.stringify(response.user));
            localStorage.setItem('token', response.token);
            this.router.navigate(['/thing']);
          },
          (error) => {console.log(error);
          }
        );
}

 
}
