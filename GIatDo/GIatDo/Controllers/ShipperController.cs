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
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        private readonly IOrderService _orderService;

        public ShipperController(IShipperService shipperService, IOrderService orderService)
        {
            _shipperService = shipperService;
            _orderService = orderService;
        }
        [HttpPost("CreateShipper")]
        public ActionResult CreateShipper([FromBody] CreateShipperVM shipper)
        {
            var result = _shipperService.GetShippers(s => s.Phone == shipper.Phone);
            if (result.Count() > 0)
            {
                return BadRequest("Phone Number Has Been Exist");
            }
            Shipper newShipper = shipper.Adapt<Shipper>();
            _shipperService.CreateShipper(newShipper);
            _shipperService.Save();
            return Ok(200);
        }
        [HttpGet("GetAll")]
        public ActionResult GetShipper()
        {
            return Ok(_shipperService.GetShippers().Adapt<List<ShipperVM>>());
        }
        [HttpGet("GetById")]
        public ActionResult GetShipper(Guid Id)
        {
            return Ok(_shipperService.GetShipper(Id).Adapt<ShipperVM>());
        }
        [HttpDelete("Delete")]
        public ActionResult DeleteShipper(Guid Id)
        {
            Shipper shipper = _shipperService.GetShipper(Id);
            if (shipper == null)
            {
                return NotFound();
            }
            _shipperService.DeleteShipper(shipper);
            _shipperService.Save();
            return Ok(200);

        }
        [HttpGet("GetOrderTake")]
        public ActionResult GetOrderTake(Guid Id)
        {
            var listOrder = _orderService.GetOrders(s => s.ShipperTakeId == Id);
            foreach (var i in listOrder)
            {

            }
            return Ok(listOrder.Adapt<List<OrderTakeVM>>());
        }
        [HttpGet("GetOrderDelivery")]
        public ActionResult GetOrderDelevery(Guid Id)
        {
            var listOrder = _orderService.GetOrders(s => s.ShipperDeliverId == Id);
            return Ok(listOrder.Adapt<List<OrderTakeVM>>());
        }

        [HttpPut("Update")]
        public ActionResult UpdateShipper(ShipperVM model)
        {
            var _shipper = _shipperService.GetShipper(model.Id);
            if (_shipper == null)
            {
                return NotFound();
            }
            if (_shipperService.GetShippers(s => s.Phone == model.Phone).Count() > 0)
            {
                return BadRequest("Phone Number Has Been Exist");
            }
            Shipper newShipper = model.Adapt(_shipper);
            _shipperService.UpdateShipper(newShipper);
            _shipperService.Save();
            return Ok(200);
        }

    }
}