using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViclesStatus.Models.Dtos
{
    public class VehicleDto
    {
        public int vehicleId { get; set; }
        public string regNr { get; set; }
        public int customerId { get; set; }
        public string customerName { get; set; }

        public int status { get; set; }

    }
}
