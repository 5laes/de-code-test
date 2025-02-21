import { Injectable } from '@angular/core';
import { map, ReplaySubject } from 'rxjs';
import { IUser } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { ISignupUser } from '../models/signupUser';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: IUser) {
    return this.http.post("https://localhost:5001/api/account/login", model).pipe(
      map((response: IUser) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
        }
      })
    );
  }

  signup(model: ISignupUser) {
    return this.http.post("https://localhost:5001/api/account/signup", model).pipe(
      map((user: IUser) => {
        if (user) {
          this.setCurrentUser(user);
        }
      })
    );
  }

  setCurrentUser(user: IUser) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

}
