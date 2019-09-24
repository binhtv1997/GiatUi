using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiatDo.Model;
using GiatDo.Service.Service;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GIatDo.ViewModel
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] CustomerCM Model)
        {
            var result = _customerService.GetCustomers().Where(a => a.Phone == Model.Phone);
            if (result.Count() > 0)
            {
                return BadRequest();
            }
            Customer newCustomer = Model.Adapt<Customer>();
            _customerService.CreateCustomer(newCustomer);
            _customerService.Save();
            return Ok(200);
        }

        [HttpGet("GetById")]
        public ActionResult GetCustomer(Guid Id)
        {
            var result = _customerService.GetCustomer(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Adapt<CustomerVM>());
        }

        [HttpGet("GetAll")]
        public ActionResult GetAllCustomer()
        {
            var CustomerList = _customerService.GetCustomers();
            var a = CustomerList.Adapt<List<CustomerVM>>();
            return Ok(a);
        }

        [HttpPut("UpdateCustomer")]
        public ActionResult UpdateCustomer([FromBody] CustomerVM model)
        {
            var result = _customerService.GetCustomer(model.Id);
            if (result == null)
            {
                return BadRequest();
            }
            Customer newCustomer = model.Adapt(result);
            _customerService.UpdateCustomer(newCustomer);
            _customerService.Save();
            return Ok(200);
        }

        [HttpDelete("DeleteCustomer")]
        public ActionResult DeleteCustomer(Guid Id)
        {
            var result = _customerService.GetCustomer(Id);
            if (result == null)
            {
                return BadRequest();
            }
            _customerService.DeleteCustomer(result);
            _customerService.Save();
            return Ok(200);
        }

    }
}