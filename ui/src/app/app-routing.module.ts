import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobComponent } from './job/job.component';
import { HomeComponent } from './home/home.component';
import { CustomerComponent } from './customer/customer.component';
import { JobDetailComponent } from './job-detail/job-detail.component';
import { CustomerDetailsComponent } from './customer-details/customer-details.component';



const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'jobs', component: JobComponent },
  { path: 'customers', component: CustomerComponent },
  { path: 'job/:id', component: JobDetailComponent },
  { path: 'customer/:id', component: CustomerDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
