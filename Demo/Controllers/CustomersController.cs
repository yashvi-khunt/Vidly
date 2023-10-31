using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Controllers;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Infrastructure.MappingViews;
using Vidly.ViewModel;



//for practice
//namespace Vidly.Controllers
//{
//    public class CustomersController : Controller
//    {

//        // GET: Customers
//        public ActionResult Index()
//        {
//            var customers = GetCustomers();


//            return View(customers);

//        }

//        public ActionResult Details(int id)
//        {
//            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
//            return View(customer);
//        }

//        private IEnumerable<Customer> GetCustomers()
//        {
//            {
//                return new List<Customer>
//                {
//                    new Customer { Id = 1, Name = "John Smith" },
//                    new Customer { Id = 2, Name = "Mary Williams" }
//                };
//                //return new List<Customer>();
//            }
//        }
//    }
//}

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            return View(customers);

        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer == null) 
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New() {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new ViewModel.CustomerFormViewModel { MembershipTypes = membershipTypes };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        { 
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }
    }
}


