import { Injectable, NgZone } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {environment} from '../../../src/environments/environment';
import { Loan } from '../Interfaces/loan';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint+"Loan/";

  constructor(private http:HttpClient) { }

  add(loan:Loan):Observable<Loan>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`
    });
    console.log(loan)
    return this.http.post<Loan>(`${this.apiUrl}Add`,loan, { headers: headers});
  }

  getById(id: number):Observable<Loan>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.get<Loan>(`${this.apiUrl}GetByThingId/${id}`,{ headers: headers })
  }

  returnLoan(id:number):Observable<Loan>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.put<Loan>(`${this.apiUrl}Return/${id}`,{},{ headers: headers })
  }

}
