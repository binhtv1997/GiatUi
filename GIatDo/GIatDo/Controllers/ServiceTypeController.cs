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
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_serviceTypeService.GetAll());
        }

        [HttpPost]
        public ActionResult CreateAdmin([FromBody] ServiceTypeVM admin)
        {
            ServiceType Service = admin.Adapt<ServiceType>();
            _serviceTypeService.CreateServiceType(Service);
            return BadRequest();
        }
    }
}