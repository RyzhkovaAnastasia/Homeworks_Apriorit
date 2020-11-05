  
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment'
import { Message } from '../interfaces/message-interface';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private httpClient: HttpClient) { }

  private url = environment.apiUrl;

  get(): Observable<Message[]> {
    return this.httpClient.get<Message[]>(this.url);
  }

  post(message): Observable<Message> {
    return this.httpClient.post<Message>(this.url, message);
  }

  put(message): Observable<Message> {
    return this.httpClient.put<Message>(this.url + message.id, message);
  }

  delete(id) {
    return this.httpClient.delete<number>(this.url + id);
  }
}