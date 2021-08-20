using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViclesStatus.Mapping;
using ViclesStatus.Models.DBContext;
using ViclesStatus.Models.Dtos;
using ViclesStatus.Models.Entities;
using ViclesStatus.Models.IManager;
using ViclesStatus.unitOfWork;

namespace ViclesStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOFWork _unitOfWork;

        public CustomersController(IUnitOFWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }

        //// GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var Customers = await _unitOfWork.Customers.GetAll();
            return Ok(Customers.toCustomerDto());
        }

        //// GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _unitOfWork.Customers.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            //var customerDto = _mapper.Map<CustomerDto>(customer);

            return Ok(customer.toCustomerDto());
        }

        //// PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customerDto)
        {
            var customer = customerDto.toCustomerModel();
            if (id != customer.Customer_ID)
            {
                return BadRequest();
            }

            await _unitOfWork.Customers.Update(customer);
            return Ok();
           

        }

        //// POST: api/Customers
        [HttpPost]
        public  async Task<ActionResult<CustomerDto>> PostCustomer(CustomerDto customerDto)
        {
            var customer = customerDto.toCustomerModel();

            await _unitOfWork.Customers.ADD(customer);

            return Created("Creates", customerDto);
        }

        //// DELETE: api/Customers/5
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
           await _unitOfWork.Customers.Delete(customerId);
            return Ok();
        }

       
    }
}
