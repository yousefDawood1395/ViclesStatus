using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViclesStatus.Models.Dtos;
using ViclesStatus.Models.Entities;

namespace ViclesStatus.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.customerName,
                opt => opt.MapFrom(src => src.Customer.CustomerName))
                .ForMember(dest => dest.customerId,
                opt => opt.MapFrom(src => src.Customer_ID))
                .ForMember(dest => dest.vehicleId,
                opt => opt.MapFrom(src => src.Vehicle_ID))
                .ReverseMap();

        }


        
    }
}
