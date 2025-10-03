import {inject} from '@angular/core'
import { CanActivateFn, Router } from '@angular/router';
import { UserService } from './user.service';

export const catGuardGuard: CanActivateFn = (route, state) => {
  const router = inject(Router)
  const service = inject(UserService)

  //si le user ne préfère pas les chat, retourne vers les chiens
  if(!service.currentUser?.prefercat){
    console.log(service.currentUser)
    router.navigate(['/dog'])
    console.log("retourne a chien")
  }
  return true
};
