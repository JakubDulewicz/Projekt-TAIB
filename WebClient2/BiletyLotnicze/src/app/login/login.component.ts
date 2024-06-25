import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { createWatch } from '@angular/core/primitives/signals';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  credentials = { email: '', password: '' };

  constructor(private authService: AuthService, private router: Router) { }

  login(): void {
    console.log('Logging in with credentials:', this.credentials); // Debugging log
    this.authService.login(this.credentials).subscribe(
      (data) => {
        console.log('Login successful:', data); // Debugging log
        localStorage.setItem('token', data.token);
        this.router.navigate(['/']);
      },
      (error) => {
        console.error('Login failed:', error); // Debugging log
        alert('Login failed');
      }
    );
  }
}
