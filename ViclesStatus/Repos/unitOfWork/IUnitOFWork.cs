using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViclesStatus.Models.IManager;

namespace ViclesStatus.unitOfWork
{
   public interface IUnitOFWork : IDisposable
    {
        ICustomer Customers { get; }
        IVehicle Vehicles { get; }
    }
}
