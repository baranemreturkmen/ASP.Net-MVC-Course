using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class Home6Controller : Controller
    {
        //Auto Generated Controller Read & Write Actions

        // GET: Home6
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home6/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home6/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home6/Create
        //FormCollection Yerine Model de verebilirim, Person, Address model klasörümün altındaki classlar vs.
        //2 metodun imzası aynı ise eğer, metod ismini değiştirip (x olsun) [HttpPost, ActionName("y")] metodu y diye çağırabilirsin.
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home6/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home6/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home6/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home6/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
