import {Component, OnInit, inject} from '@angular/core';
import { RegisterComponent } from '../register/register.component';
import {HttpClient} from "@angular/common/http";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent,FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  http = inject( HttpClient);
  registerMode = false
  users: any;

  ngOnInit(): void {
    this.getuser();

  }

  registetoggle(){
    this.registerMode = !this.registerMode;
  }
  getuser(){
    this.http.get('http://localhost:5217/users').subscribe({
        next: response => this.users = response,
        error: err => console.log(err),
        // complete: () => console.log(this.users.length),

      }

    )
  }

  cancelRegisterMode($event: boolean) {
    this.registerMode = $event

  }
}
