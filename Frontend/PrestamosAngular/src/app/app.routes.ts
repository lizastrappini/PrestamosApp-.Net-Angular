import { RouterModule, Routes } from '@angular/router';
import { ThingComponent } from './thing/thing.component';
import { PersonComponent } from './person/person.component';
import { CategoryComponent } from './category/category.component';
import { NgModule } from '@angular/core';
import { LoginComponent} from './login/login.component';
import { AppComponent } from './app.component';
import { authGuard, authUser } from './auth.guard';
import { LoanComponent } from './loan/loan.component';
import { AddThingComponent } from './add-thing/add-thing.component';
import { IndexPageComponent } from './index-page/index-page.component';
import { RegisterComponent } from './register/register.component';

export const routes: Routes = [
  { path: 'thing', component: ThingComponent, canActivate: [authGuard]},
  {path: 'person', component: PersonComponent, canActivate: [authGuard]},
  {path: 'category', component: CategoryComponent},
  {path: 'login', component: LoginComponent, canActivate:[authUser]},
  {path: 'index', component: IndexPageComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'loan/:id', component: LoanComponent,canActivate: [authGuard]},
  {path: 'addThing', component: AddThingComponent,canActivate: [authGuard]},
  { path: '', redirectTo: 'index', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })

export class AppRoutes { }