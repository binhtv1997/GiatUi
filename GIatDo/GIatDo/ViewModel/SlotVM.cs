using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIatDo.ViewModel
{
    public class SlotVM
    {
        public Guid Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
    public class SlotCM
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
