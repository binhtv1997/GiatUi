﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIatDo.ViewModel
{
    public class CreateServiceTypeVM
    {
        public string Name { get; set; }
    }
    public class UpdateServiceTypeVM
    {
        public Guid Id { get; set; }   
        public string Name { get; set; }
    }
    public class ServiceTypeVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
