
using TpDojo.Entities;
using System.Collections.Generic;

namespace TpDojo.Models
{
    public class SamouraiViewModel
    {

        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public List<ArtMartial> ArtsMartiaux { get; set; }

        public long? ArmeId { get; set; }
        public List<long> ArtsMartiauxIds { get; set; }
    }
}