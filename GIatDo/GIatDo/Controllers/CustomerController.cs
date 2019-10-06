using System;
using System.Collections.Generic;
using System.Linq;
using GiatDo.Model;
using GiatDo.Service.Service;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace GIatDo.ViewModel
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;

        public CustomerController(ICustomerService customerService, IAccountService accountService)
        {
            _customerService = customerService;
            _accountService = accountService;
        }
        [HttpPost]
        public ActionResult CreateCustomer([FromBody] CustomerCM model) 
        {
            try
            {
                var checkAccount = _accountService.GetAccount(model.AccountId);
                if (checkAccount == null)
                {
                    return NotFound(400);
                }
                var result = _customerService.GetCustomers().Where(a => a.Phone == model.Phone);
                if (result.Count() > 0)
                {
                    return BadRequest("Phone Number Has Been Exsit");
                }
                Customer newCustomer = model.Adapt<Customer>();
                newCustomer.IsDelete = false;
                _customerService.CreateCustomer(newCustomer);
                _customerService.Save();
                return Ok(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

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
  
            return Ok(_customerService.GetCustomers(s=> !s.IsDelete).Adapt<List<CustomerVM>>());
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
    
        [HttpGet("GetByAccountID")]
        public ActionResult GetCustomerByAccountId(Guid Id)
        {
            var result = _customerService.GetCustomers(c => c.AccountId == Id);
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result.Adapt<List<CustomerVM>>());
        }
        [HttpGet("GetByUserID")]
        public ActionResult GetCustomerByUserId(string Id)
        {
            var AccountId = _accountService.GetAccounts(a => a.User_Id.Equals(Id)).ToList();
            if (!AccountId.Any())
            {
                return NotFound();
            }
            var result = _customerService.GetCustomers(c => c.AccountId == AccountId[0].Id).ToList();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result[0].Adapt<CustomerVM>());
        }
    }
}