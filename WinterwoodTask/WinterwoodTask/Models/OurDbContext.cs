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

       // public System.Data.Entity.DbSet<WinterwoodTask.Models.Stock> Stocks { get; set; }
    }
}