using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.APIs
{
    [Authorize(Roles =RoleName.CanManageCustmers)]
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // Get : Api/Customers
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>));
        }


        // Get : Api/Customers/1
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
               return NotFound();
         
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }


        // Post : Api/Customers
        [HttpPost]
        public IHttpActionResult Create(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var customer = Mapper.Map<CustomerDto,Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id),customerDto);
        }


        // Put : Api/Customers/1
        [HttpPut]
        public IHttpActionResult Edit(int id,CustomerDto customerDto)
        {  
            var customerInDb =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

           Mapper.Map(customerDto, customerInDb);                             
            _context.SaveChanges();

            return Ok();
        }


        // Delete : Api/Customers/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {  
            var customer =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            
            _context.Customers.Remove(customer);        
            _context.SaveChanges();

            return Ok();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
