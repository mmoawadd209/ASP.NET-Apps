
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
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
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }


        // Get : Api/Customers/1
        [HttpGet]
        public Customer Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)            
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return customer;
        }


        // Post : Api/Customers
        [HttpPost]
        public Customer Create(Customer customer)
        {
            if (!ModelState.IsValid)           
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }


        // Put : Api/Customers/1
        [HttpPut]
        public void Edit(int id,Customer customer)
        {  
            var customerInDb =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)            
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            if (!ModelState.IsValid)            
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            customerInDb.Name = customer.Name;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;                        
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
