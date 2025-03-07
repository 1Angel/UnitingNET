import { Component, inject, OnInit } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';

@Component({
  selector: 'app-home-page',
  imports: [],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent implements OnInit{
  ngOnInit(): void {
    this.title.setTitle("Home - Uniting");

    this.meta.addTag({name: "og:title", content: "Home - Uniting"});
    this.meta.addTag({name: "description", content: "Home page of Uniting.net"});
    this.meta.addTag({name: "og:description", content: "Home page of Uniting.net"});
  }

  private readonly title = inject(Title);
  private readonly meta = inject(Meta);

}
