using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiatDo.Service.Service;
using GIatDo.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GIatDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly ISlotService _slotService;

        public OrderController(IOrderService orderService, ISlotService slotService)
        {
            _orderService = orderService;
            _slotService = slotService;
        }

        [HttpPost("CreateOrder")]
        public ActionResult CreateOrder([FromBody] OrderCM model)
        {
            var timeCreate = DateTime.Now;
            var checkSlot = _slotService.GetSlots(s => s.TimeStart.Date == timeCreate.Date).Where(t1 => t1.TimeStart.TimeOfDay <= timeCreate.TimeOfDay).Where(t2 => t2.TimeEnd.TimeOfDay >= timeCreate.TimeOfDay);
            if(checkSlot.Count() > 0)
            {

            }
            return Ok(200);
        }
    }
}