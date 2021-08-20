using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ViclesStatus.Models.DBContext;
using ViclesStatus.Models.Dtos;
using ViclesStatus.Models.Entities;
using ViclesStatus.Models.IManager;

namespace ViclesStatus.Models.Manager
{
    public class VehicleRepository : IVehicle
    {
        private Context _context;
        public VehicleRepository(Context context)
        {
            _context = context;
        }

        public async Task ADD(Vehicle vehicle)
        {

            if (vehicle == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }
            await _context.Vehicles.AddAsync(vehicle);
            _context.SaveChanges();


        }

        public async Task Delete(int vehicleId)
        {

            Vehicle vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();


        }

        public async Task<List<Vehicle>> GetAll()
        {

            return await _context.Vehicles.ToListAsync();
        }


        public async Task<Vehicle> GetById(int vehicleId)
        {

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(i => i.Vehicle_ID == vehicleId);
            if (vehicle == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }
            return vehicle;



        }

        public async Task<List<VehicleDto>> getData(List<VehicleDto> vehicleDtos)
        {
            var r = new Random();
            List<VehicleDto> statusModels = new List<VehicleDto>();
            foreach (var item in vehicleDtos)
            {
              statusModels.Add( new VehicleDto { vehicleId = item.vehicleId,
                  customerId = item.customerId,
                  customerName = item.customerName,
                  regNr=item.regNr,
                  status = r.Next(1, 40)});
            }

            return  statusModels;
        }

        public async Task Update(Vehicle vehicle)
        {

            if (vehicle == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();


        }
    }
}
