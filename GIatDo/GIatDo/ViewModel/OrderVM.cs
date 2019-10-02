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
        //public Guid? ShipperDeliverId { get; set; }
        //public Guid? CustomerId { get; set; }
        //public Guid? SlotDeliveryId { get; set; }
    }
}
