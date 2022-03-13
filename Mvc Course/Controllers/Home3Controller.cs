using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class Home3Controller : Controller
    {
        //Section
        public ActionResult Blog()
        {
            return View();
        }

        //Section
        public ActionResult Comments()
        {
            return View();
        }
    }
}