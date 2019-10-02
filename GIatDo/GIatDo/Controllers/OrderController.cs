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
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly ISlotService _slotService;
        private readonly ICustomerService _customerService;
        private readonly IShipperService _shipperService;
        private readonly IOrderSService _orderServiceService;

        public OrderController(IOrderService orderService, ISlotService slotService, ICustomerService customerService, IShipperService shipperService, IOrderSService orderServiceService)
        {
            _orderService = orderService;
            _slotService = slotService;
            _customerService = customerService;
            _shipperService = shipperService;
            _orderServiceService = orderServiceService;
        }

        [HttpPost("CreateOrder")]
        public ActionResult CreateOrder([FromBody] OrderCM model)
        {
            var timeCreate = DateTime.Now;
            var checkSlot = _slotService.GetSlots(s => s.TimeStart.Date == timeCreate.Date).Where(t1 => t1.TimeStart.TimeOfDay <= timeCreate.TimeOfDay).Where(t2 => t2.TimeEnd.TimeOfDay >= timeCreate.TimeOfDay).ToList();
            if (checkSlot.Count() > 0)
            {
                var checkCus = _customerService.GetCustomer(model.CustomerId.Value);
                if (checkCus == null)
                {
                    return NotFound();
                }

                Order newOrder = model.Adapt<Order>();
                newOrder.IsDelete = false;
                newOrder.SlotTakeId = checkSlot[0].Id;
                _orderService.CreateOrder(newOrder);
                _orderService.Save();

                foreach (var item in model.ListOrderServices)
                {
                    OrderService orderService = item.Adapt<OrderService>();
                    orderService.OrderId = newOrder.Id;
                    _orderServiceService.CreateOrderService(orderService);
                }
                _orderServiceService.Save();
                return Ok(200);

            }
            else
            {
                return BadRequest("Dont Have Any Slot");
            }
        }
        [HttpGet("GetAllOrder")]
        public ActionResult GetOrder()
        {
            return Ok(_orderService.GetOrders().Adapt<List<OrderVM>>());
        }
        [HttpGet("GetByCustomerId")]
        public ActionResult GetOrder(Guid Id)
        {
            var checkCus = _customerService.GetCustomer(Id);
            if (checkCus == null)
            {
                return NotFound("Not Found Customer");
            }
            return Ok(_orderService.GetOrders(o => o.CustomerId == Id).ToList().ElementAt(0).Adapt<OrderVM>());
        }
        [HttpPut("UpdateSlotDelivery")]
        public ActionResult UpdateSlotDelivery([FromBody]Guid SlotId, Guid OrderId)
        {
            var checkSlot = _slotService.GetSlot(SlotId);
            if (checkSlot == null)
            {
                return NotFound("Slot Not Found");
            }
            var _order = _orderService.GetOrders(o => o.Id == OrderId).ToList().ElementAt(0);
            _order.SlotDeliveryId = checkSlot.Id;
            _orderService.UpdateOrder(_order);
            _orderService.Save();
            return Ok(200);
        }
        [HttpPut("UpdateShipperDelivery")]
        public ActionResult UpdateShipperDelivery([FromBody]Guid ShipperId, Guid OrderId)
        {
            var CheckShipper = _shipperService.GetShipper(ShipperId);
            if (CheckShipper == null)
            {
                return NotFound("Shipper Not Found");
            }
            var _order = _orderService.GetOrders(o => o.Id == OrderId).ToList().ElementAt(0);
            _order.ShipperDeliverId = CheckShipper.Id;
            _orderService.UpdateOrder(_order);
            _orderService.Save();
            return Ok(200);
        }
        [HttpPut("UpdateTakeDelivery")]
        public ActionResult UpdateTakeDelivery([FromBody]Guid ShipperId, Guid OrderId)
        {
            var CheckShipper = _shipperService.GetShipper(ShipperId);
            if (CheckShipper == null)
            {
                return NotFound("Shipper Not Found");
            }
            var _order = _orderService.GetOrders(o => o.Id == OrderId).ToList().ElementAt(0);
            _order.ShipperTakeId = CheckShipper.Id;
            _orderService.UpdateOrder(_order);
            _orderService.Save();
            return Ok(200);
        }
        [HttpDelete("DeleteOrder")]
        public ActionResult Delete(Guid Id)
        {
            var checkOrder = _orderService.GetOrder(Id);
            if (checkOrder == null)
            {
                return NotFound("Not Found Order");
            }
            var listOrderService = _orderServiceService.GetOrderServices(s => s.OrderId == Id).ToList();
            foreach (var item in listOrderService)
            {
                _orderServiceService.DeleteOrderService(item);
            }
            _orderService.DeleteOrder(checkOrder);
            _orderService.Save();
            _orderServiceService.Save();
            return Ok(200);
        }
    }
}