namespace WeddingRSVP.Api
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class context : DbContext
    {
        public context()
            : base("name=WeddingRSVP")
        {
        }

        public virtual DbSet<Seats> Seats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seats>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Seats>()
                .Property(e => e.FamilyName)
                .IsUnicode(false);

            modelBuilder.Entity<Seats>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
