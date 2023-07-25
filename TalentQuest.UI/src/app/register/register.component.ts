import { Component } from '@angular/core';
import { RegisterRequest } from '../Interfaces/RegisterRequest';
import { AuthenticationService } from '../services/authentication.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private authenticationService: AuthenticationService) { }
  user: RegisterRequest = {} as RegisterRequest;
  register() {
    this.authenticationService.register(this.user).subscribe(data => {

    });
  }
}