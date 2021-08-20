using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViclesStatus.Models.Dtos;
using ViclesStatus.Models.Entities;
using ViclesStatus.Models.IGeneral;

namespace ViclesStatus.Models.IManager
{
   public interface IVehicle : IGeneral<Vehicle>
    {
        public Task<List<VehicleDto>> getData(List<VehicleDto> vehicleDtos);
    }
}
