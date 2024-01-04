import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {

  localStorage: Storage = window.localStorage;
  user = this.localStorage.getItem('dniUser');

  constructor(private router:Router,private cdr: ChangeDetectorRef){ }

  toThing(){
    this.router.navigate(['/thing']);
  }
  toPerson(){
    this.router.navigate(['/person']);
  }
  toCategory(){
    this.router.navigate(['/category']);
  }
  Login(){
    this.router.navigate(['/login']);
  }
  LogOut(dni:number | string){
    localStorage.removeItem('dniUser');
    localStorage.removeItem('token');
    this.router.navigate(['/index']);
  }
  Register(){
    this.router.navigate(['/register']);
  }

}
