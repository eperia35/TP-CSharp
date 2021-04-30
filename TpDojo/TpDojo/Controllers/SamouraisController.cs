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
using TpDojo.Models;

namespace TpDojo.Controllers
{
    public class SamouraisController : Controller
    {
        private TpDojoContext db = new TpDojoContext();

        public ActionResult Index()
        {
            return View(db.Samourais.Include(x => x.ArtsMartiaux).ToList());
        }

      
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            db.Entry(samourai).Collection(x => x.ArtsMartiaux).Load();
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

       
        public ActionResult Create()
        {
            SamouraiViewModel svm = new SamouraiViewModel();
            svm.ArtsMartiaux = db.ArtMartial.ToList();
            svm.Armes = db.Armes.ToList();

            return View(svm);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel svm)
        {
            if (this.MyValidations(ModelState, svm))
            {
                svm.Samourai.Arme = db.Armes.Find(svm.ArmeId);
                svm.Samourai.ArtsMartiaux = db.ArtMartial.Where(x => svm.ArtsMartiauxIds.Contains(x.Id)).ToList();
                db.Entry(svm.Samourai).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            svm.ArtsMartiaux = db.ArtMartial.ToList();
            svm.Armes = db.Armes.ToList();

            return View(svm);
        }

     
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SamouraiViewModel svm = new SamouraiViewModel();
            svm.Samourai = db.Samourais.Find(id);
            db.Entry(svm.Samourai).Collection(x => x.ArtsMartiaux).Load();
            svm.Armes = db.Armes.ToList();
            svm.ArmeId = svm.Samourai.Arme?.Id;
            svm.ArtsMartiaux = db.ArtMartial.ToList();

            if (svm.Samourai.ArtsMartiaux != null && svm.Samourai.ArtsMartiaux.Count > 0)
            {
                svm.ArtsMartiauxIds = svm.Samourai.ArtsMartiaux.Select(x => x.Id).ToList();
            }

            if (svm.Samourai == null)
            {
                return HttpNotFound();
            }

            return View(svm);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel svm)
        {
            if (this.MyValidations(ModelState, svm))
            {
                Samourai Samourai = db.Samourais.Include(x => x.Arme).SingleOrDefault(x => x.Id == svm.Samourai.Id);
                Samourai.Nom = svm.Samourai.Nom;
                Samourai.Force = svm.Samourai.Force;
                Samourai.Arme = db.Armes.Find(svm.ArmeId);
                Samourai.ArtsMartiaux = db.ArtMartial.Where(x => svm.ArtsMartiauxIds.Contains(x.Id)).ToList();

                db.Entry(Samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            svm.Armes = db.Armes.ToList();
            svm.ArtsMartiaux = db.ArtMartial.ToList();
            return View(svm);
        }

      
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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

        private bool MyValidations(ModelStateDictionary modelState, SamouraiViewModel svm)
        {
          
            if (svm.ArmeId != null)
            {
                if (db.Samourais.Distinct().Any(x => x.Arme.Id == svm.ArmeId))
                {
                    modelState.AddModelError("ArmeId", "Il existe déjà un samouraï possédant cette arme");
                }
            }

            return modelState.IsValid;
        }
    }
}
