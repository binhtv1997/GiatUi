using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GiatDo.Model
{
    public class Slot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public virtual ICollection<Order> OrderTake { get; set; }
        public virtual ICollection<Order> OrdersDelivery { get; set; }
    }
}
