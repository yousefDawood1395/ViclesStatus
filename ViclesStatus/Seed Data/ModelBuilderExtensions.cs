using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViclesStatus.Models.Entities;

namespace ViclesStatus.Models.Seed_Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   Customer_ID = 1,
                   Address = "Nasr City",
                   CustomerName = "customer1"
               },
                new Customer
                {
                    Customer_ID = 2,
                    Address = "maady",
                    CustomerName = "customer2"
                }, new Customer
                {
                    Customer_ID = 3,
                    Address = "fifth sittlement",
                    CustomerName = "customer3"
                }

               );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Customer_ID = 1,
                    RegNr = "hsdgdt1245",
                    Vehicle_ID = 1
                },
                new Vehicle
                {
                    Customer_ID = 2,
                    RegNr = "hhiuie3565",
                    Vehicle_ID = 2
                },
                new Vehicle
                {
                    Customer_ID = 3,
                    RegNr = "llddldl65487",
                    Vehicle_ID = 3
                }
                );
        }
    }
}
