using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryWebApi.Models.ViewModels
{
    public class UserIndexData
    {
        public User User { get; set; }
        //public IEnumerable<ServiceAssignment> ServiceAssignments { get; set; }
        public List<Service> Services { get; set; }
    }
}
