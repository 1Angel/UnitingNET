import { HttpInterceptorFn } from '@angular/common/http';
import { inject, afterNextRender } from '@angular/core';
import { AuthService } from '../Services/auth.service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {

  const authService = inject(AuthService);

  let new_req = req;

  // if(authService.GetLocalStorageInfo() && authService.isLoggedIn()){
  //   new_req = req.clone({
  //     setHeaders:{
  //       Authorization: `Bearer ${authService.GetLocalStorageInfo().access_Token
  //       }`
  //     }
  //   })
  // }

  if (typeof window !== 'undefined' && !!localStorage.getItem('userData')) {
    if(authService.GetLocalStorageInfo() && authService.isLoggedIn()){
      new_req = req.clone({
        setHeaders:{
          Authorization: `Bearer ${authService.GetLocalStorageInfo().access_Token
          }`
        }
      })
    }
  }

  return next(new_req);
};
