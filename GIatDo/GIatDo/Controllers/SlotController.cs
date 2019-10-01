using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiatDo.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GIatDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        private readonly ISlotService _slotService;
        private readonly IOrderService _orderService;

        public SlotController(IShipperService shipperService, ISlotService slotService, IOrderService orderService)
        {
            _shipperService = shipperService;
            _slotService = slotService;
            _orderService = orderService;
        }
        //[HttpPost("CreateSlot")]

    }
}