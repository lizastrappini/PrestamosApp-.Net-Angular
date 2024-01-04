import { Injectable, NgZone } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../../../src/environments/environment';
import { Category } from '../Interfaces/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint+"Category/";

  constructor(private http:HttpClient) { }

  getAll():Observable<Category[]>{
    return this.http.get<Category[]>(`${this.apiUrl}getAll`)
  }

  getById(IdCategory: number):Observable<Category>{
    return this.http.get<Category>(`${this.apiUrl}GetById/${IdCategory}`)
  }

  update(Id:number):Observable<Category>{
    return this.http.put<Category>(`${this.apiUrl}Update/${Id}`, Id)
  }

}
