import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SecurityGuard } from '@core/guard/security.guard';
import { DashboardComponent } from './feature/parkinglot/components/dashboard/dashboard.component';


const routes: Routes = [
  { path: '', redirectTo: '/parkinglot', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent, canActivate: [SecurityGuard]  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
