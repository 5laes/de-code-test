import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';
import { IUser } from './models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'DC Quiz';

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: IUser = JSON.parse(localStorage.getItem('user'));
    if (user) { 
      this.accountService.setCurrentUser(user);
    }
  }
}
