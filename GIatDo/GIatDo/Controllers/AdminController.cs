﻿using System;
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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IAccountService _accountService;

        public AdminController(IAdminService adminService, IAccountService accountService)
        {
            _adminService = adminService;
            _accountService = accountService;
        }

        [HttpPost]
        public ActionResult CreateAdmin([FromBody] AdminCM admin)
        {
            var checkAccount = _accountService.GetAccount(admin.AccountId);
            if(checkAccount== null)
            {
                return BadRequest("Account Dont Exist");
            }
            var result = _adminService.GetAdmins().Where(a => a.Phone == admin.Phone);
            if (result.Count() > 0)
            {
                return BadRequest("Phone Number Has Been Exsit");
            }

            Admin newAdmin = admin.Adapt<Admin>();
            if (admin.Password.Length > 6)
            {
                _adminService.CreateAdmin(newAdmin);
                _adminService.Save();
                return Ok(200);
            }
            return BadRequest("Password has more 6 charater");
        }

        [HttpGet("GetById")]
        public ActionResult GetAdmin(Guid Id)
        {
            var result = _adminService.GetAdmin(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Adapt<AdminVM>());
        }

        [HttpGet("GetAll")]
        public ActionResult GetAllAdmin()
        {
            var AdminList = _adminService.GetAdmins();
            var a = AdminList.Adapt<List<AdminVM>>();
            return Ok(a);
        }

        [HttpPut("UpdateAdmin")]
        public ActionResult UpdateAdmin([FromBody] UpdateAdminVM admin)
        {
            var checkAccount = _accountService.GetAccount(admin.AccountId);
            if (checkAccount == null)
            {
                return BadRequest("Account Dont Exist");
            }
            var result = _adminService.GetAdmin(admin.Id);
            if (result == null)
            {
                return BadRequest();
            }
            Admin newAdmin = admin.Adapt(result);
            if (admin.Password.Length > 6)
            {
                _adminService.UpdateAdmin(newAdmin);
                _adminService.Save();
                return Ok(200);
            }
            return BadRequest("Password has more 6 charater");
        }

        [HttpDelete("DeleteAdmin")]
        public ActionResult DeleteAdmin(Guid Id)
        {
            var result = _adminService.GetAdmin(Id);
            if (result == null)
            {
                return BadRequest();
            }
            _adminService.DeleteAdmin(result);
            _adminService.Save();
            return Ok(200);
        }

    }
}