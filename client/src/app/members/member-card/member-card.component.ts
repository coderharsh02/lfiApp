import { Component, Input, OnInit } from '@angular/core';
import { UserDetail } from 'src/app/_models/userDetail';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  @Input() user?: UserDetail;

  constructor() {

  }

  ngOnInit(): void {
    
  }
}
