using BO;
using PizzaTp.ValidattionAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaTp.Models
{
    public class PizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Pate> Pates { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        [IngredientFilter(Max = 5, Min = 2)]
        public List<int> IngredientsIds { get; set; }
        public int PateId { get; set; }


    }
}