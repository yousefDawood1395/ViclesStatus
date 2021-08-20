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
    public class CustomerRepository : ICustomer
    {
        private Context _context;
        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public async Task ADD(Customer customer)
        {
                if (customer == null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    throw new HttpResponseException(response);
                }
                await _context.AddAsync(customer);
                _context.SaveChanges();
           
           
        }

        public async Task Delete(int customerId)
        {

           
                Customer customer = await _context.Customers.FindAsync(customerId);
                if (customer == null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    throw new HttpResponseException(response);
                }
                _context.Customers.Remove(customer);
                _context.SaveChanges();
          
        }

        public async Task<List<Customer>> GetAll()
        {
            
            return await _context.Customers.ToListAsync();
          
        }

        public async Task<List<CustomerDto>> getAllCustomer()
        {
            var customers = await _context.Customers.ToListAsync();
            List<CustomerDto> customersDto = new List<CustomerDto>();
            foreach(var item in customers)
            {
                CustomerDto dtos = new CustomerDto()
                {
                    customerName = item.CustomerName,
                    address = item.Address
                };
                customersDto.Add(dtos);
            }
            return customersDto;
        }

        public async Task<Customer> GetById(int customerId)
        {
           
                var customer = await _context.Customers.FirstOrDefaultAsync(i => i.Customer_ID == customerId);
                if (customer == null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    throw new HttpResponseException(response);
                }
                return customer;
            
              
        }

        public async Task<CustomerDto> getCustomerById(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(i => i.Customer_ID == customerId);
            if (customer == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }

            CustomerDto customerDto = new CustomerDto()
            {
                customerName = customer.CustomerName,
                address = customer.Address
            };
            return customerDto;
        }

        public async Task Update(Customer customer)
        {
           
                if (customer == null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    throw new HttpResponseException(response);
                }
                _context.Customers.Update(customer);
                _context.SaveChanges();
            
           
        }
    }
}
