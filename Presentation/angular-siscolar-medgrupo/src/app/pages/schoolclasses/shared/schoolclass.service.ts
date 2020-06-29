import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError, flatMap } from 'rxjs/operators';

import { SchoolClass } from './schoolclass.model';

@Injectable({
  providedIn: 'root'
})
export class SchoolclassService {

  private readonly localInMemoryRestfull = 'api/schoolclasses';
  private readonly localHostBackEndPath = 'https://localhost:5010/v1/schoolclasses';  
  private apiPath = 'urlService';

  constructor(private http: HttpClient) { 
    this.apiPath = this.localHostBackEndPath;
   }

  getAll(): Observable<SchoolClass[]> {    
    return this.http.get(this.apiPath).pipe(
      catchError(this.handleError),
      map(this.jsonDataToSchoolclasses)
    );
  }

  getById(id: string): Observable<SchoolClass> {
    const url = `${this.apiPath}/${id}`;

    return this.http.get(url).pipe(
      catchError(this.handleError),
      map(this.jsonDataToSchoolclass)
    );
  }

  create(schoolclass: SchoolClass): Observable<SchoolClass> {
    const newGuid = Math.random().toString(36).substring(2) + Date.now().toString(36);
    schoolclass.id = newGuid;
    console.log(newGuid);
    return this.http.post(this.apiPath, schoolclass).pipe(
      catchError(this.handleError),
      map(this.jsonDataToSchoolclass)
    );
  }

  update(schoolclass: SchoolClass): Observable<SchoolClass> {
    const url = `${this.apiPath}/${schoolclass.id}`;

    return this.http.put(url, schoolclass).pipe(
      catchError(this.handleError),
      map(() => schoolclass)
    );
  }

  delete(id: string): Observable<any> {
    const url = `${this.apiPath}/${id}`;

    return this.http.delete(url).pipe(
      catchError(this.handleError),
      map(() => null)
    );
  }

  private jsonDataToSchoolclasses(jsonData: any[]): SchoolClass[] {
    const schoolclasses: SchoolClass[] = [];
    jsonData.forEach(element => schoolclasses.push(element as SchoolClass));
    return schoolclasses;
  }

  private jsonDataToSchoolclass(jsonData: any): SchoolClass {
    return jsonData as SchoolClass;
  }

  private handleError(error: any): Observable<any>{
    console.log('ERRO NA SOLICITAÇÃO => ', error);
    return throwError(error);
  }


}
