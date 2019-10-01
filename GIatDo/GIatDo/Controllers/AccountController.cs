using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiatDo.Model;
using GiatDo.Service.Service;
using GIatDo.ViewModel;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GIatDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public ActionResult CreateAccount([FromBody] AccountCM model)
        {
            var result = _accountService.GetAccounts(a => a.User_Id.Equals(model.User_Id));
            if (result.Count() > 0)
            {
                return BadRequest("User_Id Has Been Exist");
            }
            Account newAccount = model.Adapt<Account>();
            _accountService.CreateAccount(newAccount);
            _accountService.Save();
            return Ok(200);
        }
        [HttpGet("GetById")]
        public ActionResult GetAccount(Guid Id)
        {
            return Ok(_accountService.GetAccount(Id).Adapt<AccountVM>());
        }
        [HttpGet("GetByUserId")]
        public ActionResult GetAccount(string Id)
        {
            return Ok(_accountService.GetAccounts(s => s.User_Id.Equals(Id)).Adapt<List<AccountVM>>());
        }
        [HttpDelete]
        public ActionResult DeleteAccount(Guid Id)
        {
            var result = _accountService.GetAccount(Id);
            if (result != null)
            {
                _accountService.DeleteAccount(result);
                _accountService.Save();
                return Ok(200);
            }
            return NotFound();
        }
        [HttpPut]
        public ActionResult UpdateAccount([FromBody]AccountVM model)
        {
            var result = _accountService.GetAccount(model.Id);
            if (result == null)
            {
                return NotFound("Account Not Found");
            }
            _accountService.UpdateAccount(result);
            _accountService.Save();
            return Ok(200);
        }
        [HttpGet("GetAll")]
        public ActionResult GetAllAccount()
        {
            return Ok(_accountService.GetAccounts().Adapt<List<AccountVM>>());
        }
    }
}