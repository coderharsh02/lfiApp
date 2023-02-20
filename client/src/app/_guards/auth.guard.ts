import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';
import { UserToken } from '../_models/userToken';
import { CanActivate } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toastr: ToastrService) {}

  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map((user: UserToken | any) => {
        if(user) return true;
        this.toastr.error('You shall not pass!');
        return false;
      })
    )
  }
  
}
