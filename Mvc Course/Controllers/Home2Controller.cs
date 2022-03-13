using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class Home2Controller : Controller
    {
        //Nested Layout
        public ActionResult Platform()
        {
            return View();
        }

        //Nested Layout
        public ActionResult AddCart()
        {
            return View();
        }

        //Section
        public ActionResult Campaigns()
        {
            return View();
        }
    }
}