
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();


            return View(customers);
        }

        public ActionResult Details(int id)
        {
           
            var customer = GetCustomers().ToList().SingleOrDefault(c=>c.Id==id);
           
            
            return View(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 0, Name = "Mohamed Moawad"},
                new Customer {Id = 1, Name = "Mosh Hemdani"},
                new Customer {Id = 2, Name = "Tim Corey"},
            };

            return customers;

        }
    }
}