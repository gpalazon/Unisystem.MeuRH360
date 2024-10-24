import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Company } from '../models/company.model'; // Crie o modelo de empresa

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private apiUrl = 'https://localhost:44376/api/Companies';

  constructor(private http: HttpClient) { }

  //registerCompany(company: Company): Observable<Company> {
  //  return this.http.post<Company>(`${this.apiUrl}/register`, company);
  //}

  registerCompany(user: any): Observable<any> {
    //alert('teste');
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  buscarCep(cep: string): Observable<any> {
    return this.http.get(`https://viacep.com.br/ws/${cep}/json`);
  }

  // Método para buscar os detalhes da empresa pelo ID
  getCompanyDetails(companyId: number): Observable<Company> {
    return this.http.get<Company>(`${this.apiUrl}/${companyId}`);
  }

}
