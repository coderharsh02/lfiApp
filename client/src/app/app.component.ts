import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserToken } from './_models/UserToken';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  title = 'LetsFeedIndia!';

  users: any;

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: UserToken | null = JSON.parse(localStorage.getItem('user')!);
    this.accountService.setCurrentUser(user);
  }

}
