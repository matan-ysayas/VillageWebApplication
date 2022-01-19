using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VillageWebApplication.Models
{
    public partial class VillageContext : DbContext
    {
        public VillageContext()
            : base("name=VillageContext")
        {
        }
      public virtual  DbSet<Resident> Residents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
