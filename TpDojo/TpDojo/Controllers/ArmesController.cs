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
    public class ArmesController : Controller
    {
        private TpDojoContext db = new TpDojoContext();

        // GET: Récupère la liste des armes en base
        public ActionResult Index()
        {
            return View(db.Armes.ToList());
        }

        // GET: Récupère une arme en fonction de son identifiant
        public ActionResult Details(long? id)
        {
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return View(db.Armes.ToList());
            }
            return View(arme);
        }

        // GET: Permet de récupérer la page de création d'une arme
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permet de créer une arme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Arme arme)
        {
            if (ModelState.IsValid)
            {
                db.Armes.Add(arme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arme);
        }

        // GET: Permet de récupérer la page de modification d'une arme
        public ActionResult Edit(long? id)
        {
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return View(db.Armes.ToList());
            }
            return View(arme);
        }

        // POST: Permet de modifier une arme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Arme arme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arme);
        }

        // GET: Permet de récupérer la page de confirmation de suppression d'une arme
        public ActionResult Delete(long? id)
        {
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return View(db.Armes.ToList());
            }
            return View(arme);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Arme arme = db.Armes.Find(id);

            Samourai SamouraiArme = db.Samourais.Include(x => x.Arme).Where(x => x.Arme.Id == arme.Id).SingleOrDefault();
            if (SamouraiArme != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Armes.Remove(arme);
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
