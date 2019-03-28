namespace WinterwoodTask
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BatchModel : DbContext
    {
        public BatchModel()
            : base("name=BatchModel")
        {
        }

        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>()
                .Property(e => e.Fruit)
                .IsUnicode(false);

            modelBuilder.Entity<Batch>()
                .Property(e => e.Variety)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .Property(e => e.Fruit)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .Property(e => e.Variety)
                .IsUnicode(false);
        }

       
    }
}
