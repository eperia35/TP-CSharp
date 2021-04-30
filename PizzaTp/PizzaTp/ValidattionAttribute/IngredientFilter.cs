using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaTp.ValidattionAttribute
{
    public class IngredientFilter: ValidationAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override string FormatErrorMessage(string name)
        {
            return $"le nombre d'ingrédient doit être de {this.Min} à {this.Max} ";
        }

        public override bool IsValid(object value)
        {
             bool valid = false;

            if (value is ICollection)
            {
                if ((value as ICollection).Count >= Min && (value as ICollection).Count <= Max)
                {
                    valid = true;
                }
            }

            return valid;
        }

    }
}