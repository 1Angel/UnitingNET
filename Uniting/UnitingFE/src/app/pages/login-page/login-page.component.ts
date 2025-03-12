import { Component, inject, OnInit, signal } from '@angular/core';
import {ReactiveFormsModule, FormBuilder, Validators, FormGroup} from '@angular/forms';
import { Meta, Title } from '@angular/platform-browser';
import { AuthService } from '../../core/Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  imports: [ReactiveFormsModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent implements OnInit{
  ngOnInit(): void {
    this.title.setTitle("Login - Uniting");
    this.meta.addTag({name: "title", content: "Login - Uniting"});
    this.meta.addTag({name: "og:title", content: "Login - Uniting"});
    this.meta.addTag({name: "og:description", content: "Log In to use our website"});
    this.meta.addTag({name: "description", content: "Log In to use our website"});

  }

  private readonly title = inject(Title);
  private readonly meta = inject(Meta);
  private readonly fb = inject(FormBuilder);

  private readonly service = inject(AuthService);
  private readonly router = inject(Router);

  readonly errorMessage = signal<string>('');

  loginForm = this.fb.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.maxLength(15), Validators.min(4)]]
  });


  LoginUser(form: FormGroup){
    const {email, password} = form.value;
    if(!form.invalid){
      this.service.Login(email, password).subscribe({
        next:() => this.router.navigateByUrl('/'),
        error(err) {
          
        },
      })
    }
  }

}
