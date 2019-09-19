using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KT.Model;
using KT.Service;
using KT.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }

        [HttpPost]
        public ActionResult CreateAdmin([FromBody] AdminVM admin)
        {
            var result = _adminService.GetAdmins();
            if (result.Count() > 0)
            {
                return BadRequest();
            }
            Admin newAdmin = admin.Adapt<Admin>();
            if (admin.Password.Length > 6)
            {
                _adminService.CreateAdmin(newAdmin);
                _adminService.Save();
                return Ok(200);
            }

            return BadRequest();
        }

        [HttpGet]
        public Admin GetAdmin(Guid Id)
        {
            return _adminService.GetAdmin(Id);
        }

        [HttpGet("GetAll")]
        public ActionResult GetAllAdmin()
        {
            List<Admin> list = new List<Admin>();
            var AdminList = _adminService.GetAdmins();
            foreach(var i in AdminList)
            {
                list.Add(i);
            }
            return Ok(list);
        }
        [HttpPut]
        public ActionResult UpdateAdmin([FromBody] UpdateAdminVM admin)
        {
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

            return BadRequest();
        }

        [HttpDelete]
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