using System;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerService.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var job = _customerService.GetCustomer(id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            var customer = _customerService.CreateCustomer(model);

            return Created($"customer/{customer.CustomerId}", customer);
        }
    }
}