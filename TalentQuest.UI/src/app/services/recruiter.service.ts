import { Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class RecruiterService {

  constructor(private http: HttpClient) { }
  
  private apiUrl = environment.apiurl;  // URL to web api
  /** GET heroes from the server */
  getRecruiters(): Observable<any> {
    return this.http.get<any>(this.apiUrl+"/recruiters")
  } 
}

