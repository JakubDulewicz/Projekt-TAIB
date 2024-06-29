import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder, FormGroup,  } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  form: FormGroup;

  constructor(formBuilder: FormBuilder, private authService: AuthService, private router: Router) {this.form = formBuilder.group({
    email: [null, [Validators.required]],
    password: [null, [Validators.required]]

  }); }

  login(): void {
    const credentials = this.form.value;
    console.log(this.form.value);
    this.authService.login(credentials).subscribe(
      response => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/']);
      },
      (error) => {
        console.error('Login failed:', error); // Debugging log
        alert('Login failed');
      }
    );
  }
}
