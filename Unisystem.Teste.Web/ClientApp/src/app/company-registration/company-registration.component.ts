import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from '../services/company.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-registration',
  templateUrl: './company-registration.component.html',
  styleUrls: ['./company-registration.component.css']
})


export class CompanyRegistrationComponent implements OnInit {

  companyForm: FormGroup;
  submitted = false;
  showCompanyModal = false;


  // Lista de estados (UF)
  estados = [
    { sigla: 'AC', nome: 'Acre' },
    { sigla: 'AL', nome: 'Alagoas' },
    { sigla: 'AM', nome: 'Amazonas' },
    { sigla: 'BA', nome: 'Bahia' },
    { sigla: 'CE', nome: 'Ceará' },
    { sigla: 'DF', nome: 'Distrito Federal' },
    { sigla: 'ES', nome: 'Espírito Santo' },
    { sigla: 'GO', nome: 'Goiás' },
    { sigla: 'MA', nome: 'Maranhão' },
    { sigla: 'MT', nome: 'Mato Grosso' },
    { sigla: 'MS', nome: 'Mato Grosso do Sul' },
    { sigla: 'MG', nome: 'Minas Gerais' },
    { sigla: 'PA', nome: 'Pará' },
    { sigla: 'PB', nome: 'Paraíba' },
    { sigla: 'PR', nome: 'Paraná' },
    { sigla: 'PE', nome: 'Pernambuco' },
    { sigla: 'PI', nome: 'Piauí' },
    { sigla: 'RJ', nome: 'Rio de Janeiro' },
    { sigla: 'RN', nome: 'Rio Grande do Norte' },
    { sigla: 'RS', nome: 'Rio Grande do Sul' },
    { sigla: 'RO', nome: 'Rondônia' },
    { sigla: 'RR', nome: 'Roraima' },
    { sigla: 'SC', nome: 'Santa Catarina' },
    { sigla: 'SP', nome: 'São Paulo' },
    { sigla: 'SE', nome: 'Sergipe' },
    { sigla: 'TO', nome: 'Tocantins' }
  ];

  // Lista de cidades (preenchida ao selecionar UF)
  cidades: string[] = [];

  // Um exemplo de lista de cidades por estado (pode ser expandida ou carregada de API)
  cidadesPorEstado = {
    'SP': ['São Paulo', 'Campinas', 'Santos'],
    'RJ': ['Rio de Janeiro', 'Niterói', 'Angra dos Reis'],
    'MG': ['Belo Horizonte', 'Uberlândia', 'Contagem'],
    // Adicione mais estados e cidades conforme necessário
  };


  constructor(
    private formBuilder: FormBuilder,
    private companyService: CompanyService,
    private router: Router,
    public activeModal: NgbActiveModal
  ) { }

  ngOnInit(): void {
    this.companyForm = this.formBuilder.group({
      tipo: [''], //['', Validators.required],
      nome: ['', Validators.required],
      cnpj: ['', Validators.required],
      cep: [''], //['', Validators.required],
      endereco: [''], //['', Validators.required],
      bairro: [''], //['', Validators.required],
      uf: [''], //['', Validators.required],
      cidade: [''], //['', Validators.required],
      complemento: [''],
      celular: ['', Validators.required],
      administrador: ['', Validators.required],
      cpf: [''], //['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }


  // Método que será chamado ao alterar o UF
  onUfChange(uf: string) {
    this.cidades = this.cidadesPorEstado[uf] || [];
    this.companyForm.get('cidade').setValue('');  // Reseta a cidade ao trocar UF
  }

  // Método para popular o endereço ao buscar o CEP
  popularEndereco(dados: any) {
    if (!dados.erro) {
      this.companyForm.patchValue({
        endereco: dados.logradouro,
        bairro: dados.bairro,
        cidade: dados.localidade,
        estado: dados.uf,
      });
      this.onUfChange(dados.uf);  // Atualiza a lista de cidades com base no CEP
    }
  }



  get f() { return this.companyForm.controls; }

  onSubmit() {

    this.submitted = true;
    if (this.companyForm.invalid) {
      return;
    }

    const company = {      
      email: this.companyForm.value.email,
      tipo: this.companyForm.value.tipo,
      cnpj: this.companyForm.value.cnpj,
      cep: this.companyForm.value.cep,
      endereco: this.companyForm.value.endereco,
      bairro: this.companyForm.value.bairro,
      estado: this.companyForm.value.uf,
      cidade: this.companyForm.value.cidade,
      celular: this.companyForm.value.celular,
      nomeAdministrador: this.companyForm.value.administrador,
      cpfAdministrador: this.companyForm.value.cpf,
      nome: this.companyForm.value.nome,
      complemento: this.companyForm.value.complemento
    };


    this.router.navigate(['/company/1']);
    /*
    this.companyService.registerCompany(company).subscribe(
      response => {
        // Se o registro for bem-sucedido, redirecionar para a página 'home'
        this.router.navigate(['/empresa']);
      },
      error => {
        alert('Erro ao registrar a emresa');
        console.log('Erro ao registrar emresa:', error);
      }
    );*/

    
  }

  onCancel() {
    this.activeModal.dismiss();
  }

  
  // Método que será chamado ao trocar o texto do CEP
  BuscarCEP(cep: string) {
    if (cep.length === 8) {
      this.companyService.buscarCep(cep).subscribe(data => {
        // Preencher os campos de endereço automaticamente
        this.companyForm.patchValue({
          endereco: data.logradouro,
          bairro: data.bairro,
          cidade: data.localidade,
          uf: data.uf
        });
      });
    }
  }
 
}
