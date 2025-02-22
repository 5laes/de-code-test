import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  standalone: false,
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent{
  errors: string[] | null = null;
  registerForm: any;
  complexPassword = "(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$";

  constructor(private fb: FormBuilder, private accountService: AccountService, private route: Router) {
    this.registerForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', [Validators.required, Validators.pattern(this.complexPassword)]] 
    })
  }

  onSubmit() {
    this.accountService.signup(this.registerForm.value).subscribe({
      next: () => this.route.navigateByUrl("/quiz"),
      error: error => this.errors = error
    })
  }

}
