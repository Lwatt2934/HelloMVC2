using HelloMVC2.Models;
using System;
using System.Web.Mvc;

namespace HelloMVC2.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult ViewCustomer(Customer postedCustomer) // string Name, string Telephone)
        {
            Customer customer = new Customer();

            customer.ID = Guid.NewGuid().ToString();
            customer.Name = postedCustomer.Name;
            customer.Telephone = postedCustomer.Telephone;

            return View(customer);
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
    }
}