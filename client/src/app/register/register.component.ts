import {Component, EventEmitter, inject, Input, output, Output} from '@angular/core';
import {FormGroup, FormsModule} from "@angular/forms";
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService)
  @Input() userFromHomeComponent: any;
  @Output() cancelRegister = new EventEmitter<boolean>();

  model :any = {}
  register(){
    this.accountService.register(this.model).subscribe({
      next: data =>{
        console.log(data)
        this.cancel()

      },

      error: error => console.log(error)
    })
  }
  cancel(){

    this.cancelRegister.emit(false);
  }



}
