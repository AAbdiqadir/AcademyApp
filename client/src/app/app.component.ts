import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {NavComponent} from './nav/nav.component';

import { AccountService } from './_services/account.service';
import { HomeComponent } from './home/home.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  http = inject( HttpClient);
  title = 'Client';
  private accountService = inject(AccountService)

  users: any;

  setuser(){
    const userS= localStorage.getItem("user");

    if(!userS) return;

    const user = JSON.parse(userS);

    this.accountService.currentuser.set( user);

  }

  getuser(){
    this.http.get('http://localhost:5217/users').subscribe({
        next: response => this.users = response,
        error: err => console.log(err),
        complete: () => console.log('response complete')
      }

    )
  }
  ngOnInit(): void {
    this.getuser();
    this.setuser()

  }
}
