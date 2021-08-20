using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViclesStatus.Models.DBContext;
using Microsoft.Extensions.Configuration;
using ViclesStatus.Models.IManager;
using ViclesStatus.Models.Manager;
using ViclesStatus.unitOfWork;

namespace ViclesStatus.Models.Injection
{
    public static class DependencyInjection
    {
        

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICustomer,CustomerRepository>();
            services.AddScoped<IVehicle, VehicleRepository>();
            services.AddScoped<IUnitOFWork, UnitOfWork>();


            return services;
        }
    }
}
