import { Component, inject, OnInit } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';

@Component({
  selector: 'app-login-page',
  imports: [],
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

}
