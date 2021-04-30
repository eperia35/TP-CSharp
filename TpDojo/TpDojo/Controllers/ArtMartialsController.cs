using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TpDojo.Data;
using TpDojo.Entities;

namespace TpDojo.Controllers
{
    public class ArtMartialsController : Controller
    {
        private TpDojoContext db = new TpDojoContext();

        public ActionResult Index()
        {
            return View(db.ArtMartial.ToList());
        }

        public ActionResult Details(long? id)
        {
           
            ArtMartial artMartial = db.ArtMartial.Find(id);
            if (artMartial == null)
            {
                return View(db.ArtMartial.ToList());
            }
            return View(artMartial);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtMartial artMartial)
        {
            if (ModelState.IsValid)
            {
                db.ArtMartial.Add(artMartial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artMartial);
        }

        public ActionResult Edit(long? id)
        {

            ArtMartial artMartial = db.ArtMartial.Find(id);
            if (artMartial == null)
            {
                return View(db.ArtMartial.ToList());
            }
            return View(artMartial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ArtMartial artMartial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artMartial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artMartial);
        }

        public ActionResult Delete(long? id)
        {
            ArtMartial artMartial = db.ArtMartial.Find(id);

            return View(artMartial);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ArtMartial artMartial = db.ArtMartial.Find(id);
            db.ArtMartial.Remove(artMartial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
