import { Component, inject, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Meta, Title } from '@angular/platform-browser';
import { AuthService } from '../../core/Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-page',
  imports: [ReactiveFormsModule],
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.css'
})
export class RegisterPageComponent implements OnInit{
  ngOnInit(): void {
    this.title.setTitle("Register - Uniting");
    this.meta.addTag({name: "og:title", content: "Register - Uniting"});
    this.meta.addTag({name: "description", content: "Register to use our website"});
    this.meta.addTag({name: "og:description", content: "Register to use our website"});

  }

  private readonly title = inject(Title);
  private readonly meta = inject(Meta);

  private readonly authService = inject(AuthService);
  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);

  registerForm = this.fb.nonNullable.group({
    username: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });


  register(registerForm: FormGroup){

    const {username, email, password} = registerForm.value;

    if(!registerForm.invalid){
      this.authService.Register(username, email, password).subscribe({
        next:()=>this.router.navigateByUrl('/'),
        error(err) {
            console.log(err);
        },
      })
    }
  }

}
