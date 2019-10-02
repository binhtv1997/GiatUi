using GiatDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIatDo.ViewModel
{
    public class OrderTakeVM
    {
        public Guid Id { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
        public string CustomerName { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? ShipperTakeId { get; set; }
        public Guid? SlotTakeId { get; set; }
    }

    public class OrderDeleveryVM
    {
        public Guid Id { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
        public Guid? ShipperDeliverId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid? SlotDeliveryId { get; set; }
    }
    public class OrderCM
    {
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
        public Guid? CustomerId { get; set; }
        public List<ListOrderServiceCM> ListOrderServices { get; set; }
    }
    public class ListOrderServiceCM
    {
        public string Quantity { get; set; }
        public string Price { get; set; }
        public Guid? ServiceId { get; set; }
    }
    public class OrderVM
    {
        public Guid Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? TakeTime { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? ShipperTakeId { get; set; }
        public Guid? ShipperDeliverId { get; set; }
        public Guid? SlotTakeId { get; set; }
        public Guid? SlotDeliveryId { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsDelete { get; set; }
    }
}
