import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserToken } from '../_models/UserToken';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: (response) => { console.log(response); },
      error: (err) => { console.log(err); },
      complete: () => { console.log('Request has Completed'); }
    });
  }

  logout() {
    this.accountService.logout();
  }
}

