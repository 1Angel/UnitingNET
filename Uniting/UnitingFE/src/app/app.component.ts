import { Component, effect, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SideBarComponent } from "./components/side-bar/side-bar.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { AuthService } from './core/Services/auth.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SideBarComponent, NavBarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  constructor(){
    effect(()=>{
      this.authService.GetLocalStorageInfo()
    })
  }

  private readonly authService = inject(AuthService);

  title = 'UnitingFE';

  readonly authService = inject(AuthService);

  constructor(){
    effect(()=>{
      // if(typeof window !=='undefined' && !localStorage.getItem("userData")){
      //   this.authService.isAuthenticated.update(()=>true)
      // }
      this.authService.GetLocalStorageInfo();
    })
  }
}
