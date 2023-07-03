import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomepageComponent } from './homepage/homepage.component';
import { UserComponent } from './user/user.component';
import { AdminComponent } from './admin/admin.component';
import { ContentComponent } from './content/content.component';


const routes: Routes = [
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'homepage',component:HomepageComponent},
  {path:'user', component:UserComponent},
  {path:'admin', component:AdminComponent},
  {path:'content', component:ContentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
