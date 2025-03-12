import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../Services/auth.service';

export const userIsAuthGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);
  const authService = inject(AuthService);

  if(authService.isLoggedIn()){
    return router.navigateByUrl('/')
    return true;
  }

  return false;

};
