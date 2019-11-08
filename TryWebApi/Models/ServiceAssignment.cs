using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TryWebApi.Models
{
    public class ServiceAssignment
    {
        public int ServiceID { get; set; }
        public int UserID { get; set; }

        public Service Service { get; set; }
        public User User { get; set; }
    }
}
