import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../Services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);
  const authService = inject(AuthService);

  if(!authService.GetLocalStorageInfo() && !authService.isLoggedIn()){
    router.navigateByUrl('/auth/login')
    return false;
  }

  return true;
};
