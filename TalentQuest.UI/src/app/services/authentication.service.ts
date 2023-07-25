import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginRequest } from '../Interfaces/LoginRequest';
import { environment } from '../../environments/environment';
import { RegisterRequest } from '../Interfaces/RegisterRequest';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private loginUrl = environment.apiurl + '/account/login'
  private registerUrl = environment.apiurl + '/account/register'
  constructor(private http: HttpClient, private router: Router) {}

  public login(loginModel: LoginRequest): Observable<any> {
    return this.http.post<any>(this.loginUrl, loginModel);
  }
  public register(registerModel: RegisterRequest): Observable<any> {
    return this.http.post<any>(this.registerUrl, registerModel);
  }
  public logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return token != null;
  }
}
