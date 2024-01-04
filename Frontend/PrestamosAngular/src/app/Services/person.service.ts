import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {environment} from '../../../src/environments/environment';
import { Person } from '../Interfaces/person';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint+"Person/";

  constructor(private http:HttpClient) { }

  login(user: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}login`, user);
  }

    register(newUser: Person):Observable<Person>{
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: `Bearer ${localStorage.getItem('token')}`
      });
      return this.http.post<Person>(`${this.apiUrl}Register`, newUser, { headers: headers })
    }

    getAll():Observable<Person[]>{
      return this.http.get<Person[]>(`${this.apiUrl}People`);
    }

    delete(dni:number){
      return this.http.delete(`${this.apiUrl}Delete/${dni}`)
    }

    update(request: Person):Observable<Person>{
      var dni = request.Dni
      return this.http.put<Person>(`${this.apiUrl}Update/${dni}`, request)
    }
    
}