import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError, flatMap } from 'rxjs/operators';

import { School } from './school-model';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  private readonly localInMemoryRestfull = 'api/schools';
  private readonly localHostBackEndPath = 'https://localhost:5010/v1/schools';  
  private apiPath = 'urlService';

  constructor(private http: HttpClient) { 
    this.apiPath = this.localInMemoryRestfull;
   }

  getAll(): Observable<School[]> {
    return this.http.get(this.apiPath).pipe(
      catchError(this.handleError),
      map(this.jsonDataToSchools)
    );
  }

  getById(id: string): Observable<School> {
    const url = `${this.apiPath}/${id}`;

    return this.http.get(url).pipe(
      catchError(this.handleError),
      map(this.jsonDataToSchool)
    );
  }


  create(school: School): Observable<School> {
    const newGuid = Math.random().toString(36).substring(2) + Date.now().toString(36);
    school.id = newGuid;
    console.log(newGuid);
    return this.http.post(this.apiPath, school).pipe(
      catchError(this.handleError),
      map(this.jsonDataToSchool)
    );

  //   this.http.post('https://jsonplaceholder.typicode.com/invalid-url', { title: 'Angular POST Request Example' }).subscribe({
  //     next: data => this.postId = data.id,
  //     error: error => console.error('There was an error!', error)
  // })

  }

  update(school: School): Observable<School> {
    const url = `${this.apiPath}/${school.id}`;

    return this.http.put(url, school).pipe(
      catchError(this.handleError),
      map(() => school)
    );
  }

  delete(id: string): Observable<any> {
    const url = `${this.apiPath}/${id}`;

    return this.http.delete(url).pipe(
      catchError(this.handleError),
      map(() => null)
    );
  }

  private jsonDataToSchools(jsonData: any[]): School[] {
    const schools: School[] = [];
    jsonData.forEach(element => schools.push(element as School));
    return schools;
  }

  private jsonDataToSchool(jsonData: any): School {
    return jsonData as School;
  }

  private handleError(error: any): Observable<any>{
    console.log('ERRO NA SOLICITAÇÃO => ', error);
    return throwError(error);
  }


}
