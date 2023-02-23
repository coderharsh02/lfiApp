import { Component, OnInit } from '@angular/core';
import { DonationsService } from '../_services/donations.service';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';
@Component({
  selector: 'app-collect',
  templateUrl: './collect.component.html',
  styleUrls: ['./collect.component.css']
})
export class CollectComponent {

  constructor(public donationsService: DonationsService) { }
  public configuration: any;
  public columns: any;
  public donations: any;

  ngOnInit(): void {
    this.configuration = { ...DefaultConfig };
    this.configuration.searchEnabled = true;
    // ... etc.

    this.columns = [
      { key: 'donatedBy.name', title: 'Donar Name' },
      { key: 'noOfMeals', title: 'No Of Meals' },
      { key: 'donatedBy.pincode', title: 'Pincode' },
      { key: 'status', title: 'Status' }
    ];

    this.donationsService.getDonations().subscribe((donations) => {
      this.donations = donations;
    });
  }
}
