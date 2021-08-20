using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViclesStatus.Models.Dtos;
using ViclesStatus.Models.Entities;

namespace ViclesStatus.Mapping
{
    public static class AutoMapperConfig
    {
        private static IMapper _mapper = null;
        private static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new AutoMapper());
                    });

                    _mapper = mappingConfig.CreateMapper();
                }

                return _mapper;
            }
        }

        public static ICollection<CustomerDto> toCustomerDto(this ICollection<Customer> customers)
        {
          return  Mapper.Map<ICollection<CustomerDto>>(customers);
        }
        public static CustomerDto toCustomerDto(this Customer customers)
        {
            return Mapper.Map<CustomerDto>(customers);
        }

        public static ICollection<Customer> toCustomerModel(this ICollection<CustomerDto> customersDto)
        {
            return Mapper.Map<ICollection<Customer>>(customersDto);
        }
        public static Customer toCustomerModel(this CustomerDto customerDto)
        {
            return Mapper.Map<Customer>(customerDto);
        }

        public static List<VehicleDto> toVehicleDto (this ICollection<Vehicle> vehicles)
        {
            return Mapper.Map<List<VehicleDto>>(vehicles);
        }

        public static VehicleDto toVehicleDto(this Vehicle vehicles)
        {
            return Mapper.Map<VehicleDto>(vehicles);
        }
        public static ICollection<Vehicle> toVehicleModel(this ICollection<VehicleDto> vehicleDtos)
        {
            return Mapper.Map<ICollection<Vehicle>>(vehicleDtos);
        }
        public static Vehicle toVehicleModel(this VehicleDto vehicleDtos)
        {
            return Mapper.Map<Vehicle>(vehicleDtos);
        }

    }
}
