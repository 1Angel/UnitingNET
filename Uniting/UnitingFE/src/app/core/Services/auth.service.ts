import { HttpClient } from '@angular/common/http';
import { computed, Inject, inject, Injectable, PLATFORM_ID, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { AuthResponse } from '../models/AuthResponse-interface';
import { map, Observable } from 'rxjs';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(@Inject(PLATFORM_ID) platformid: Object){
    this.isBrowser = isPlatformBrowser(platformid);
  }

  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  isBrowser:boolean;
  public readonly isAuthenticated = signal<boolean>(false);
  public readonly isLoggedIn = computed(()=> this.isAuthenticated());

  Login(email: string, password: string){
    return this.http.post<AuthResponse>(`${this.apiUrl}/auth/login`, {email, password}).pipe(map(response=>{
      this.SetCrendetials(response);
    }));
  }


  LogOut(){
    localStorage.removeItem("userData");
    this.isAuthenticated.update(()=>false);
  }

  SetCrendetials(userData: AuthResponse){
    localStorage.setItem("userData", JSON.stringify(userData));
    this.isAuthenticated.set(true);
  };


  GetLocalStorageInfo(){
    if(this.isBrowser){
      var data = JSON.parse(localStorage.getItem("userData")!);
      if(data){
        this.isAuthenticated.set(true)
      }
      return data;  
    }
  }
}
