using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KT.ViewModels
{
    public class AdminVM
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class UpdateAdminVM
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
