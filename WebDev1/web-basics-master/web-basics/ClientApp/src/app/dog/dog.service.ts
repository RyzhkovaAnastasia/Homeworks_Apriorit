import { Injectable } from '@angular/core';
import { Dog } from './dog';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DogService {
  constructor(private httpClient: HttpClient) { }

  url: string = "api/dog";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  get(): Observable<Dog[]> {
    return this.httpClient.get<Dog[]>(this.url);
  }

  addDog(dog: Dog): Observable<string> {
    return this.httpClient.post<string>(this.url, JSON.stringify(dog), this.httpOptions);
  }
}
