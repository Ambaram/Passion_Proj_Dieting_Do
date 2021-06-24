using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dieting_Do.Controllers
{
    public class Feed_ScheduleController : Controller
    {
        // GET: Feed_Schedule
        public ActionResult Index()
        {
            return View();
        }

        // GET: Feed_Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Feed_Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feed_Schedule/Create
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

        // GET: Feed_Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Feed_Schedule/Edit/5
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

        // GET: Feed_Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Feed_Schedule/Delete/5
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
