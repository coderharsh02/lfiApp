import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) { }


  title = 'LetsFeedIndia!';

  users: any;

  ngOnInit() {
    this.http.get('https://localhost:5000/api/users').subscribe({
      next: (response) => { this.users = response; console.log(response); },
      error: (err) => { console.log(err); },
      complete: () => { console.log('Request has Completed'); }
    });
  }
}
