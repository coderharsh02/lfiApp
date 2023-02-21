import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDetail } from '../_models/userDetail';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + (JSON.parse(localStorage.getItem('user') || '{}'))?.token
  })
}


@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers(): Observable<UserDetail[]> {
    return this.http.get<UserDetail[]>(this.baseUrl + 'users', httpOptions);
  }

  getUser(username: string): Observable<UserDetail> {
    return this.http.get<UserDetail>(this.baseUrl + 'users/username' + username, httpOptions);
  }

   
}
