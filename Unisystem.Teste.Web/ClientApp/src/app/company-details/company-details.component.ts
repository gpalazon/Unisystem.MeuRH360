import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CompanyService } from '../services/company.service';
import { Company } from '../models/company.model';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css'],
})
export class CompanyDetailsComponent implements OnInit {
  company: Company | null = null;
  companyId: number;

  constructor(
    private route: ActivatedRoute,
    private companyService: CompanyService
  ) {
    this.companyId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.loadCompanyDetails();
  }

  // Método para carregar os detalhes da empresa
  loadCompanyDetails(): void {
    this.companyService.getCompanyDetails(this.companyId).subscribe(
      (data: Company) => {
        this.company = data;
      },
      (error) => {
        console.error('Erro ao buscar os detalhes da empresa', error);
      }
    );
  }
}
