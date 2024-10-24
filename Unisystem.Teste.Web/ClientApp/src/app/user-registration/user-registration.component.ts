import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})

export class UserRegistrationComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmacaoSenha: ['', [Validators.required]],
      aceitarTermos: [false, [Validators.requiredTrue]]
    }, {
      validator: this.mustMatch('senha', 'confirmacaoSenha') // Aplicando o validador MustMatch
    });
  }


  // Custom validator to check if passwords match
  mustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }

  get f() { return this.registerForm.controls; }

  onSubmit() {

    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }

    const user = {
      nome: this.registerForm.value.nome,
      email: this.registerForm.value.email,
      password: this.registerForm.value.senha
    };

    const primeiroNome = user.nome.split(' ')[0];

    this.router.navigate(['/home'], { state: { nome: primeiroNome } });


    /*
    this.userService.registerUser(user).subscribe(
      response => {
        // Se o registro for bem-sucedido, redirecionar para a página 'home'
        const primeiroNome = user.name.split(' ')[0];

        this.router.navigate(['/home'], { state: { nome: primeiroNome } });
      },
      error => {
        alert('Erro ao registrar usuário');
        console.log('Erro ao registrar usuário:', error);
      }
    );
    */
  }







}
