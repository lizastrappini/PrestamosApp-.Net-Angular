import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {environment} from '../../../src/environments/environment';
import { Thing } from '../Interfaces/thing';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ThingService {
  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint+"Thing/";

  constructor(private http:HttpClient) { }

  getAll():Observable<Thing[]>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.get<Thing[]>(`${this.apiUrl}GetAll`, { headers: headers });
  }

  add(request:Thing):Observable<Thing>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.post<Thing>(`${this.apiUrl}Add`,request,{ headers: headers });
  }

  getByDni(dni:number):Observable<Thing[]>{
    return this.http.get<Thing[]>(`${this.apiUrl}GetByDni/${dni}`);
  }

  getById(id:number):Observable<Thing>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.get<Thing>(`${this.apiUrl}GetThingById/${id}`, { headers: headers });
  }

  getAvailablesByDni(dni:number):Observable<Thing[]>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.get<Thing[]>(`${this.apiUrl}GetAvailablesByDni/${dni}`, { headers: headers });
  }

  getBorrowedByDni(dni:number):Observable<Thing[]>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.get<Thing[]>(`${this.apiUrl}GetBorrowedByDni/${dni}`, { headers: headers });
  }

  update(Id:number):Observable<Thing>{
    return this.http.put<Thing>(`${this.apiUrl}Update/${Id}`,Id);
  }
}
