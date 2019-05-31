
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.APIs
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // Get : Api/Customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetAll()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }


        // Get : Api/Customers/1
        [HttpGet]
        public CustomerDto Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)            
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customerDto = Mapper.Map<Customer,CustomerDto>(customer);

            return customerDto;
        }


        // Post : Api/Customers
        [HttpPost]
        public CustomerDto Create(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)           
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var customer = Mapper.Map<CustomerDto,Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }


        // Put : Api/Customers/1
        [HttpPut]
        public void Edit(int id,CustomerDto customerDto)
        {  
            var customerInDb =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)            
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            if (!ModelState.IsValid)            
                throw new HttpResponseException(HttpStatusCode.BadRequest);

           Mapper.Map(customerDto, customerInDb);
                             
            _context.SaveChanges();            
        }


        // Delete : Api/Customers/1
        [HttpDelete]
        public void Delete(int id)
        {  
            var customer =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            _context.Customers.Remove(customer);        
            _context.SaveChanges();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
