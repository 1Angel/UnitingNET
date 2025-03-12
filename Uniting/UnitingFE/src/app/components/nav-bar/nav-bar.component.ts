import { Component, computed, inject, signal, effect } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../core/Services/auth.service';

@Component({
  selector: 'app-nav-bar',
  imports: [RouterLink],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {

  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  public isAuth = computed(()=>this.authService.isLoggedIn());

  public isOpenDropDown = signal<boolean>(false);

  toggleIsOpen(){
    if(this.isOpenDropDown() == false){
      this.isOpenDropDown.set(true);
    }else{
      this.isOpenDropDown.update(()=>false)
    }
  };

  Logout(){
    this.authService.LogOut();
    this.router.navigateByUrl('/');
  }

  constructor(){
    effect(()=>{
      console.log(`change xd ${this.isOpenDropDown()}`)
    })
  }
}