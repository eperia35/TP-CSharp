using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaTp.Utils
{
    public class FakeDB
    {
        private static readonly Lazy<FakeDB> lazy = new Lazy<FakeDB>(() => new FakeDB());

        public static FakeDB Instance
        {
            get { return lazy.Value; }
        }

        private FakeDB()
        {
            this.InitializeData();
        }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Pate> Pates { get; set; } = new List<Pate>();

        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        private void InitializeData()
        {

            Ingredients = Pizza.IngredientsDisponibles;

            Pates = Pizza.PatesDisponibles;

            List<Ingredient> IngredientsPizza = new List<Ingredient>();
            IngredientsPizza.Add(Ingredients.FirstOrDefault(x => x.Id == 1));
            IngredientsPizza.Add(Ingredients.FirstOrDefault(x => x.Id == 2));
            IngredientsPizza.Add(Ingredients.FirstOrDefault(x => x.Id == 7));

            Pizzas.Add(
                new Pizza { Id = 1, Nom = "Reine", Ingredients = IngredientsPizza, Pate = Pates.FirstOrDefault(x => x.Id == 4) }
            );
        }

    }
}