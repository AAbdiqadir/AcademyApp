import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { authGuard } from './_guards/auth.guard';

export const routes: Routes = [

  {path: "messages",component: MessagesComponent},
  {path: "lists",component: ListsComponent, canActivate:  [authGuard]},
  {path: "members/:id",component: MemberDetailComponent},
  {path: "members",component: MemberListComponent},
  {path: "**",component: HomeComponent,pathMatch: "full"},


];
