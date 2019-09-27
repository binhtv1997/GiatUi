using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIatDo.ViewModel
{
    public class ServiceVM
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
