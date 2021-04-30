using BO;
using PizzaTp.Models;
using PizzaTp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaTp.Controllers
{
    public class PizzaController : Controller
    {

        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDB.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View(FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == id));
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            return View(new PizzaViewModel() {Pizza = new Pizza() {Id = FakeDB.Instance.Pizzas.Max(p => p.Id) + 1 }, Ingredients = FakeDB.Instance.Ingredients, Pates = FakeDB.Instance.Pates, IngredientsIds = new List<int>() {1}, PateId = 1 });
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel pizzavm)
        {
            if (this.OtherValidations(ModelState, pizzavm))
            {
                try
                {
                    Pizza insert = new Pizza();
                    insert.Id = pizzavm.Pizza.Id;
                    insert.Nom = pizzavm.Pizza.Nom;
                    insert.Pate = FakeDB.Instance.Pates.Where(p => p.Id == pizzavm.PateId).FirstOrDefault();
                    insert.Ingredients = FakeDB.Instance.Ingredients.Where(p => pizzavm.IngredientsIds.Contains(p.Id)).ToList();

                    FakeDB.Instance.Pizzas.Add(insert);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(pizzavm);
                }
            }
            else
            {
                pizzavm.Ingredients = FakeDB.Instance.Ingredients;
                pizzavm.Pates = FakeDB.Instance.Pates;
                return View(pizzavm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            Pizza pizzaFakeDB = FakeDB.Instance.Pizzas.Where(p => p.Id == id).FirstOrDefault();
            return View(new PizzaViewModel() { Pizza = pizzaFakeDB, Ingredients = FakeDB.Instance.Ingredients, Pates = FakeDB.Instance.Pates, IngredientsIds = pizzaFakeDB.Ingredients.Select(i => i.Id).ToList(),PateId = pizzaFakeDB.Pate.Id });
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel pizzavm)
        {
            if (this.OtherValidations(ModelState, pizzavm))
            {
                try
                {
                    Pizza toUpdate = FakeDB.Instance.Pizzas.Where(p => p.Id == pizzavm.Pizza.Id).FirstOrDefault();
                    toUpdate.Nom = pizzavm.Pizza.Nom;
                    toUpdate.Pate = FakeDB.Instance.Pates.Where(p => p.Id == pizzavm.PateId).FirstOrDefault();
                    toUpdate.Ingredients = FakeDB.Instance.Ingredients.Where(p => pizzavm.IngredientsIds.Contains(p.Id)).ToList();


                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(pizzavm);
                }

            }
            else
            {
                pizzavm.Ingredients = FakeDB.Instance.Ingredients;
                pizzavm.Pates = FakeDB.Instance.Pates;
                return View(pizzavm);
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == id));
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                FakeDB.Instance.Pizzas.Remove(FakeDB.Instance.Pizzas.FirstOrDefault(x => x.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private bool OtherValidations(ModelStateDictionary modelState, PizzaViewModel pizzavm)
        {
            if (FakeDB.Instance.Pizzas.Any(x => x.Nom.Equals(pizzavm.Pizza.Nom) && pizzavm.Pizza.Id != x.Id))
            {
                modelState.AddModelError("Pizza.Nom", "Nom déjà pris");
            }

            if (FakeDB.Instance.Pizzas.Distinct()
                .Any(
                    x => x.Ingredients.Select(y => y.Id).OrderBy(z => z)
                    .SequenceEqual(
                    pizzavm.IngredientsIds.OrderBy(z => z)
                )
                && pizzavm.Pizza.Id != x.Id))
            {
                modelState.AddModelError("IngredientIds", "Il existe déjà une pizza avec ces ingrédients");
            }

            return modelState.IsValid;
        }

    }
}
