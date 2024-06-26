import { Component } from '@angular/core';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user = {
    name: '',
    pesel: '',
    email: '',
    password: '',
    confirmPassword: '',
    date: '',
    phone: '',
    roles: 1, // Domyślna rola
    tickets:[]
  };

  constructor(private authService: AuthService, private router: Router) { }

  register(): void {
    if (this.user.password !== this.user.confirmPassword) {
      alert('Passwords do not match');
      return;
    }

    console.log(this.user);

    this.authService.register(this.user).subscribe(
      response => {
        alert('Registration successful');
        this.router.navigate(['/login']);
      },
      error => {
        alert('Registration failed');
        console.error(error);
      }
    );
  }
}
