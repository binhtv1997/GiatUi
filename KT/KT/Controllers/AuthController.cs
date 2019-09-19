using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KT.Model;
using KT.Service;
using KT.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KT.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly IDataViewsService _dataViewsService;

        public AuthController(UserManager<MyUser> userManager, IDataViewsService dataViewsService)
        {
            _userManager = userManager;
            _dataViewsService = dataViewsService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateAccountAsync([FromBody]AccountVM accountVM)
        {
            try
            {
                DataViews user = accountVM.Adapt<DataViews>();
                _dataViewsService.CreateData(user);
                _dataViewsService.Save();
                return Ok(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPost("getUsers")]
        public async Task<ActionResult> GetUsers(LoginVM model)
        {
            try
            {
                MyUser user = model.Adapt<MyUser>();
                var success = await _userManager.FindByNameAsync(model.UserName);
                if (success == null)
                {
                    return BadRequest();
                }
                var pass = await _userManager.CheckPasswordAsync(user, model.Password);
                if (pass == null)
                {
                    return BadRequest();
                }
                return Ok(_dataViewsService.GetDataViews());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[HttpGet("GetUser")]
        //public async Task<ActionResult> GetAccount()
        //{
        //    var listUser = _userManager.Users;
        //    return Ok(listUser);
        //}

        //[HttpGet("Data")]
        //public ActionResult GetData(Guid Id)
        //{
        //    return Ok(_dataViewsService.GetDataViews(Id));
        //}
    }
}