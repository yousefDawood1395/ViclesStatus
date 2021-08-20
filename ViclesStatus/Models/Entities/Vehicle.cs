using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViclesStatus.Models.Entities
{
    public class Vehicle
    {
        [Key]
        public int Vehicle_ID { get; set; }
        public string RegNr { get; set; }

        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }


        public virtual Customer Customer { get; set; }
    }
}
