using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.View_Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }



        // GET: Customers/Index
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();          
            return View(customers);
        }


        
      // Get : Customers/Create 
        [HttpGet]
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm",viewModel);
        }



        // Get : Customers/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer =_context.Customers.Single(c => c.Id == id);
           
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel );
        }



        // Post : Customers/Save
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            } 
                      
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


      
    }
}