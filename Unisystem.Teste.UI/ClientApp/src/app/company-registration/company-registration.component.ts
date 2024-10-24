import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from '../services/company.service';

@Component({
  selector: 'app-company-registration',
  templateUrl: './company-registration.component.html'
})
export class CompanyRegistrationComponent implements OnInit {
  companyForm: FormGroup;
  submitted = false;
  showCompanyModal = false;

  constructor(
    private formBuilder: FormBuilder,
    private companyService: CompanyService
  ) { }

  ngOnInit(): void {
    this.companyForm = this.formBuilder.group({
      tipo: ['', Validators.required],
      nome: ['', Validators.required],
      cnpj: ['', Validators.required],
      cep: ['', Validators.required],
      endereco: ['', Validators.required],
      bairro: ['', Validators.required],
      uf: ['', Validators.required],
      cidade: ['', Validators.required],
      complemento: [''],
      celular: ['', Validators.required],
      administrador: ['', Validators.required],
      cpf: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  get f() { return this.companyForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.companyForm.invalid) {
      return;
    }

    const companyData = this.companyForm.value;
    this.companyService.registerCompany(companyData).subscribe(() => {
      // Fechar modal e atualizar o menu
      this.showCompanyModal = false;
    });
  }

  buscarCep() {
    const cep = this.companyForm.get('cep')?.value;
    if (cep) {
      this.companyService.buscarCep(cep).subscribe(data => {
        // Preencher os campos de endereço automaticamente
        this.companyForm.patchValue({
          endereco: data.endereco,
          bairro: data.bairro,
          cidade: data.cidade,
          uf: data.uf
        });
      });
    }
  }
}
