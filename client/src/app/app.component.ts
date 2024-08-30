import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  http = inject( HttpClient);
  title = 'Client';

  users: any;

  ngOnInit(): void {
  this.http.get('http://localhost:5217/users').subscribe({
    next: response => this.users = response,
    error: err => console.log(err),
    complete: () => console.log('response complete')


  }

  )
  }
}
