﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryWebApi.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public double Cost { get; set; }

        public User Users { get; set; }
    }
}
