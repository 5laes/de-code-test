import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AccountService } from '../services/account.service';
import { map, Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toastr: ToastrService) {}

  canActivate(): Observable<boolean> {
    console.log(this.accountService.currentUser$)
    return this.accountService.currentUser$.pipe(
      map(user => {
        if (user) return true;
        else {
          this.toastr.error("You are not authorized");
          return false;
        }
      })
    )
  }

}
