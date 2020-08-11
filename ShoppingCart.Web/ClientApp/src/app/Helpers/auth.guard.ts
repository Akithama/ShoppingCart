import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../Services/auth.service';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';



@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {


    // not logged in so redirect to login page with the return url
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }

  //canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
  //  return this.authService.isLoggedIn         // {1}
  //    .pipe(
  //      take(1),                              // {2} 
  //      map((isLoggedIn: boolean) => {         // {3}
  //        if (!isLoggedIn) {
  //          this.router.navigate(['/registration/login/login']);  // {4}
  //          return false;
  //        }
  //        return true;
  //      }));
  }
