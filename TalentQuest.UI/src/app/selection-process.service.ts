import { Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SelectionProcess } from './Interfaces/SelectionProcess';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': 'https://localhost:7118' // Reemplaza con el origen de tu API
  })
};

@Injectable({
  providedIn: 'root'
})
export class SelectionProcessService {

  constructor(private http: HttpClient) { }
  
  private apiUrl = 'https://localhost:7118/api/selection-process';  // URL to web api
  /** GET heroes from the server */
  getProcess(): Observable<any> {
    return this.http.get<any>(this.apiUrl, httpOptions)
  }
  removeProcess(id: string): Observable<any> {
    return this.http.delete<any>(this.apiUrl+"/"+id, httpOptions)
  }
}

