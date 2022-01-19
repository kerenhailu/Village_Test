using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Village_Test.Controllers
{
    public class ChiefController : Controller
    {
        // GET: Chief
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowTheChief()
        {
            ViewBag.WelcomeChief = "Welcome Chief";
            return View();
        }
    }
}