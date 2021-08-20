using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViclesStatus.Models.DBContext;
using ViclesStatus.Models.IManager;

namespace ViclesStatus.unitOfWork
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly Context _context;

        public ICustomer Customers { get; }

        public IVehicle Vehicles { get; }

        public UnitOfWork(Context context , ICustomer customers , IVehicle vehicles )
        {
            this._context = context;
            this.Customers = customers;
            this.Vehicles = vehicles;

        }
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
