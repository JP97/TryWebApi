using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryWebApi.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
