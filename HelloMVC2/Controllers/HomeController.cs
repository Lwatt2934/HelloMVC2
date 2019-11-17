using HelloMVC2.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Web.Mvc;
using System.Linq;

namespace HelloMVC2.Controllers
{
    public class HomeController : Controller
    {         
        ObjectCache cache = MemoryCache.Default;
        List<Customer> customers;

        public HomeController() //Created for the cache...
        {
            customers = cache["customers"] as List<Customer>;
            if (customers == null)
            {
                customers = new List<Customer>();
            }
        }

        public void SaveCache()
        {
            cache["customers"] = customers;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.MySuperProperty = "This is my first app!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewCustomer(string id) // string Name, string Telephone)
        {
            Customer customer = customers.FirstOrDefault(c => c.ID == id); //use Linq 
            if(customer==null)
            {
                return HttpNotFound(); //44
            }
            else
            {
                return View(customer);
            }
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            customer.ID = Guid.NewGuid().ToString();
            customers.Add(customer);
            SaveCache();

            return RedirectToAction("CustomerList");
        }

        public ActionResult CustomerList()
        {
            return View(customers);
        }

        public ActionResult EditCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.ID == id); //use Linq 
            if (customer == null)
            {
                return HttpNotFound(); //44
            }
            else
            {
                return View(customer);
            }

            return View();
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer, string Id)
        {
            var customerToEdit = customers.FirstOrDefault(c => c.ID == Id);

            if (customer == null)
            {
                return HttpNotFound(); //44
            }
            else
            {
                customerToEdit.Name = customer.Name;
                customerToEdit.Telephone = customer.Telephone;
                SaveCache();

                return RedirectToAction("CustomerList");
            }
        }


    }
}