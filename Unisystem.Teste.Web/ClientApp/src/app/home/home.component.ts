import { Component, OnInit  } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CompanyRegistrationComponent } from '../company-registration/company-registration.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})



export class HomeComponent implements OnInit {

  nomeUsuario: string = '';


  constructor(private modalService: NgbModal,
              private router: Router  ) { }

  ngOnInit(): void {
    // Capturar o nome do usuário da navegação
    //const state = this.router.getCurrentNavigation()?.extras.state;

    const navigation = this.router.getCurrentNavigation();
    const state = navigation ? navigation.extras.state : null;

    if (state) {
      this.nomeUsuario = state['nome'];
    }
  }

  openCompanyModal() {
    this.modalService.open(CompanyRegistrationComponent, {
      windowClass: 'custom-modal-size',
      centered: true
    });
  }

}
