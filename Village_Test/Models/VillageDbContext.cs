using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Village_Test.Models
{
    public partial class VillageDbContext : DbContext
    {
        public VillageDbContext()
            : base("name=VillageDbContext")
        {
        }

        public object Residents { get; internal set; }
        DbSet<Resident> _residents { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
