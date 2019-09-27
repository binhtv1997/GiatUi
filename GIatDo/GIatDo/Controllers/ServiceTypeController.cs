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
            return Ok(_serviceTypeService.GetAll().Adapt<List<ServiceTypeVM>>());
        }

        [HttpPost("Create")]
        public ActionResult CreateAdmin([FromBody] CreateServiceTypeVM ServiceType)
        {
            ServiceType Service = ServiceType.Adapt<ServiceType>();
            _serviceTypeService.CreateServiceType(Service);
            _serviceTypeService.Save();
            return Ok(200);
        }
        [HttpPut("Update")]
        public ActionResult UpdateService([FromBody] UpdateServiceTypeVM ServiceType)
        {
            var result = _serviceTypeService.GetServiceType(ServiceType.Id);
            if (result == null)
            {
                return NotFound();
            }
            ServiceType newService = ServiceType.Adapt(result);
            _serviceTypeService.UpdateServiceType(newService);
            _serviceTypeService.Save();
            return Ok(200);
        }
        [HttpDelete("Delete")]
        public ActionResult DeleteService(Guid Id)
        {
            var result = _serviceTypeService.GetServiceType(Id);
            if (result == null)
            {
                return NotFound();
            }
            _serviceTypeService.DeleteServiceType(result);
            _serviceTypeService.Save();
            return Ok(200);
        }
    }
}