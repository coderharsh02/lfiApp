import { Component, OnInit } from '@angular/core';
import { DonationsService } from '../_services/donations.service';

@Component({
  selector: 'app-collect',
  templateUrl: './collect.component.html',
  styleUrls: ['./collect.component.css']
})
export class CollectComponent {

  donations: any;

  constructor(public donationsService: DonationsService) { }

  ngOnInit(): void {  
    this.donationsService.getDonations().subscribe((donations) => {
      this.donations = donations
      console.log(this.donations);
    });
  }

}
