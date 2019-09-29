using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIatDo.ViewModel
{
    public class StoreVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float Rate { get; set; }
        public Guid? AccountId { get; set; }
        public string Phone { get; set; }
    }
    public class StoreUM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float Rate { get; set; }
        public Guid? AccountId { get; set; }
        public string Phone { get; set; }
    }
    public class StoreCM
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float Rate { get; set; }
        public Guid? AccountId { get; set; }
    }
}
