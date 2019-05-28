﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {           
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=>c.Id==id);                     
            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }
}