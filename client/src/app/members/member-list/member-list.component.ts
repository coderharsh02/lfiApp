import { Component, OnInit } from '@angular/core';
import { UserDetail } from 'src/app/_models/userDetail';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  users: UserDetail[] = [];

  constructor(private userService: UserService)
  {

  }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe({
      next: (response) => { this.users = response; console.log(this.users); }
    })
  }
}
