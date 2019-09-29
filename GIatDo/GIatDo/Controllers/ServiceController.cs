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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IServiceTypeService _serviceTypeService;
        private readonly IStoreService _storeService;

        public ServiceController(IServiceService serviceService, IServiceTypeService serviceTypeService, IStoreService storeService)
        {
            _serviceService = serviceService;
            _serviceTypeService = serviceTypeService;
            _storeService = storeService;
        }

        [HttpGet("GetById")]
        public ActionResult GetService(Guid Id)
        {
            return Ok(_serviceService.GetService(Id).Adapt<ServiceVM>());
        }

        [HttpGet("GetAll")]
        public ActionResult GetAllService()
        {
            return Ok(_serviceService.GetServices().Adapt<List<ServiceVM>>());
        }

        [HttpPost("CreateService")]
        public ActionResult CreateService([FromBody] ServiceCM model)
        {
            if(_serviceTypeService.GetServiceType(model.ServiceTypeId) == null)
            {
                return NotFound(400);
            }
            if (_storeService.GetStore(model.StoreId) == null)
            {
                return NotFound(400);
            }

            Services _services = model.Adapt<Services>();
            _serviceService.CreateService(_services);
            _serviceService.Save();
            return Ok(200);
        }
        [HttpPut("UpdateService")]
        public ActionResult UpdateServiec([FromBody] ServiceUM model)
        {
            if (_serviceTypeService.GetServiceType(model.ServiceTypeId) == null)
            {
                return NotFound(400);
            }
            if (_storeService.GetStore(model.StoreId) == null)
            {
                return NotFound(400);
            }
            var service = _serviceService.GetService(model.Id);
            if (service == null)
            {
                return NotFound(400);
            }
            Services UServices = model.Adapt(service);
            _serviceService.UpdateService(UServices);
            _serviceService.Save();
            return Ok(200);
        }
        [HttpDelete("Delete")]
        public ActionResult DeleteService(Guid Id)
        {
            var service = _serviceService.GetService(Id);
            if (service == null)
            {
                return NotFound(400);
            }
            _serviceService.DeleteService(service);
            _serviceService.Save();
            return Ok(200);
        }
    }
}