using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryWebApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }

        public ICollection<ServiceAssignment> ServiceAssignment { get; set; }
    }
}
