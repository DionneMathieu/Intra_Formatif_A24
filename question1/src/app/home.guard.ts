import { CanActivateFn, Router } from '@angular/router';
import { UserService } from './user.service';
import { inject } from '@angular/core';

export const homeGuard: CanActivateFn = (route, state) => {
const router = inject(Router)
const service = inject(UserService)

  if (service.currentUser == undefined){
    console.log("nonconnecter")
    return router.navigate(['/login'])
  }
  console.log(service.currentUser)
  return true;
};
