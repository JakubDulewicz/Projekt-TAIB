import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  credentials = {
    email: '',
    password: ''
  };
  errorMessage: string = ''; // Pole do przechowywania wiadomości o błędzie

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {}

  login(): void {
    console.log('Logging in with credentials:', this.credentials); // Debugging log
    this.authService.login(this.credentials).subscribe(
      (data: any) => {
        console.log('Login successful:', data); // Debugging log
        localStorage.setItem('token', data.token);
        this.router.navigate(['/']);
      },
      (error: any) => {
        console.error('Login failed:', error); // Debugging log
        this.errorMessage = 'Login failed. Please check your credentials and try again.';
        alert(this.errorMessage);
      }
    );
  }
}
