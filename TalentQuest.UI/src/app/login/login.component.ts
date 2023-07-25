import { Component } from '@angular/core';
import { LoginRequest } from '../Interfaces/LoginRequest';
import { AuthenticationService } from '../services/authentication.service';
import {Router} from "@angular/router"
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  user: LoginRequest = {} as LoginRequest;
  errorMessage: boolean = false;
  constructor(private authenticationService: AuthenticationService, private router: Router) { }
  login(){
    this.authenticationService.login(this.user).subscribe(data=>{
      if(data.data.accessToken){
        localStorage.setItem('token', data.data.accessToken);
        this.router.navigate(['/selection-process']);
      }
    });
    this.errorMessage = true;
  }
}
