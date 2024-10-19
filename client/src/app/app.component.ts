import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {NavComponent} from './nav/nav.component';

import { AccountService } from './_services/account.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, NavComponent, HomeComponent, RegisterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Client';
  private accountService = inject(AccountService)



  setuser(){
    const userS= localStorage.getItem("user");

    if(!userS) return;

    const user = JSON.parse(userS);

    this.accountService.currentuser.set( user);

  }


  ngOnInit(): void {

    this.setuser()

  }
}
