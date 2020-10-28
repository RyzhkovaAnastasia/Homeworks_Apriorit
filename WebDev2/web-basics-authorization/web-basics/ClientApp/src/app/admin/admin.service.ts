import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { Account } from "./account";

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  constructor(private httpClient: HttpClient) { }

  url: string = "api/admin";

  get(): Observable<Account[]> {
    return this.httpClient.get<Account[]>(this.url);
  }

  post(account: Account): Observable<string> {
    return this.httpClient.post<string>(this.url, account);
  }

  put(account: Account): Observable<string> {
    return this.httpClient.put<string>(this.url, account);
  }

  delete(id: number): Observable<string> {
    return this.httpClient.delete<string>(this.url + "/" + id);
  }
}
