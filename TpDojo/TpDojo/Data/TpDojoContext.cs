using TpDojo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TpDojo.Data
{
    public class TpDojoContext : DbContext
    {    
        public TpDojoContext() : base("name=TpDojoContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Samourai>().HasOptional(x => x.Arme).WithOptionalPrincipal();
            modelBuilder.Entity<Samourai>().HasMany(x => x.ArtsMartiaux).WithMany();
        }

        public System.Data.Entity.DbSet<TpDojo.Entities.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<TpDojo.Entities.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<TpDojo.Entities.ArtMartial> ArtMartial { get; set; }
    }
}
