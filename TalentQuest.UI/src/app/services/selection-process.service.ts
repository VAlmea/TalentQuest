import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SelectionProcessRequest } from '../Interfaces/SelectionProcessRequest';
import {environment} from '../../environments/environment';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*' // Reemplaza con el origen de tu API
  })
};

@Injectable({
  providedIn: 'root'
})
export class SelectionProcessService {

  constructor(private http: HttpClient) { }
  
  private apiUrl = environment.apiurl;  // URL to web api
  /** GET heroes from the server */
  getProcess(): Observable<any> {
    return this.http.get<any>(this.apiUrl+"/selection-process", httpOptions)
  }
  removeProcess(id: string): Observable<any> {
    return this.http.delete<any>(this.apiUrl+"/selection-process/"+id, httpOptions)
  }
  createProcess(request: SelectionProcessRequest): Observable<any> {
    return this.http.post<any>(this.apiUrl+"/selection-process",request, httpOptions)
  }
}

