import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private apiUrl = 'https://localhost:44376/api/companies';

  constructor(private http: HttpClient) { }

  registerCompany(company: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, company);
  }

  buscarCep(cep: string): Observable<any> {
    return this.http.get(`https://viacep.com.br/ws/${cep}/json`);
  }
}
