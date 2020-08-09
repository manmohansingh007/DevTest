import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})

export class CustomerComponent implements OnInit {

   showMainContent: Boolean = true;
  
    public customers: CustomerModel[] = [];
  
    public newCustomer: CustomerModel = {
      name: null,
      type: null
    };
  
    constructor(
      private customerService: CustomerService) { }
  
      ShowHideButton() {
        this.showMainContent = this.showMainContent ? false : true;
     }
    ngOnInit() {
      this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
    }
  
    public createCustomer(form: NgForm): void {
      if (form.invalid) {
        alert('form is not valid');
      } else {
        this.customerService.CreateCustomer(this.newCustomer).then(() => {
          this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
        });
      }
    }
  }
  