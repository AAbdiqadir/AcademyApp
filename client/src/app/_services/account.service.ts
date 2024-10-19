import {Injectable, inject, signal} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SIGNAL} from "@angular/core/primitives/signals";
import { user } from '../_models/user';
import {map} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private http = inject(HttpClient)
  baseUrl ='http://localhost:5217/'
  currentuser = signal<user| null>(null)

  login( model : any){
    return this.http.post<user>(this.baseUrl+ 'account/login',model).pipe(
      map(user=>{
        if (user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentuser.set(user)
        }

      })
    )
  }
  register( model : any){
    return this.http.post<user>(this.baseUrl+ 'account/Register',model).pipe(
      map(user=>{
        if (user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentuser.set(user)
        }
        return user;

      })
    )
  }

  logout(){
    localStorage.removeItem('user');
    this.currentuser.set(null)
  }


}
