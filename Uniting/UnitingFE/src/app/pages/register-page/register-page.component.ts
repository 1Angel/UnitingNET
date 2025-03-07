import { Component, inject, OnInit } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';

@Component({
  selector: 'app-register-page',
  imports: [],
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

}
