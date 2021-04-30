using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TpDojo.Entities
{
    public class Samourai : CommonModel
    {

        [Required]
        private String _Nom;
        [Required]
        private int _Force;
        private Arme _Arme;
   
        private List<ArtMartial> _ArtsMartiaux = new List<ArtMartial>();
        [NotMapped]
        public int Potentiel { get { return (Force + (Arme != null ? Arme.Degats : 0)) * (ArtsMartiaux.Count + 1); } }

        public String Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        public int Force
        {
            get { return _Force; }
            set { _Force = value; }
        }

        public virtual Arme Arme
        {
            get { return _Arme; }
            set { _Arme = value; }
        }

        public virtual List<ArtMartial> ArtsMartiaux
        {
            get { return _ArtsMartiaux; }
            set { _ArtsMartiaux = value; }
        }

    }
}