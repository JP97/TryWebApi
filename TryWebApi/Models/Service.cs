using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TryWebApi.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public double Cost { get; set; }

        // dataannotations for at serializern ikke gå videre herfra
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<ServiceAssignment> ServiceAssignment { get; set; }
    }
}
