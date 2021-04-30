using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TpDojo.Entities
{
    public class Arme : CommonModel
    {

        [Required]
        private String _Nom;
        [Required]
        private int _Degats;

        public String Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        public int Degats
        {
            get { return _Degats; }
            set { _Degats = value; }
        }

    }
}