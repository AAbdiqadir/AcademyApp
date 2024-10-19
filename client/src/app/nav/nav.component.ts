import { Component, inject } from '@angular/core';
import {FormsModule} from "@angular/forms";
import { AccountService } from '../_services/account.service';
import {NgIf, TitleCasePipe} from "@angular/common";
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import {Router, RouterModule} from '@angular/router';
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, NgIf, BsDropdownModule, RouterModule, TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {

  private routerService = inject(Router);
  accountService = inject(AccountService);
  private toasterService = inject(ToastrService)


  model: any = {};

  login(){
   this.accountService.login(this.model).subscribe({
     next: _ =>{

       this.routerService.navigateByUrl("/lists");


     },

     error: error => this.toasterService.error(error.error)
   })
  }

  logout(){
    this.accountService.logout();
    this.routerService.navigateByUrl("/");
  }


}
