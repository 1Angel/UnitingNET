import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { AuthResponse } from '../models/AuthResponse-interface';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  private readonly isAuthenticated = signal<boolean>(false);
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
    if (typeof window !== 'undefined') {
      var userinfo =localStorage.getItem("userData");
      if(userinfo){
        this.isAuthenticated.update(()=>true);
      }
    }
  }
}
