import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private _authService : AuthenticationService){}
  title = 'TalentQuest'; 
  public isAuthenticated(): boolean {
    return this._authService.isAuthenticated();
  }
  public logout(): void {
    this._authService.logout();
  }
}
