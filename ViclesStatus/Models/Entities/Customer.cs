using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViclesStatus.Models.Entities
{
    public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
