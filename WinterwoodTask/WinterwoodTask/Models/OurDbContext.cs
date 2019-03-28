using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WinterwoodTask.Models
{
    public class OurDbContext:DbContext 
    {
        public DbSet<UserAccount>UserAccount { get; set; }

       //public DbSet<Batch > Batches { get; set; }
       // public DbSet<Stock> Stocks { get; set; }
    }
}