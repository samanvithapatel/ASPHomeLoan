using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(): base("name=conn")
        {

        }
        public DbSet<SignIn> SignIns { get; set; }
        public DbSet<IncomeDetails> IncomeDetailss{ get; set; }
        public DbSet<Loan> LoanDetailss { get; set; }
        public DbSet<Personal> PersonalDetailss { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Calculation> Calculations { get; set; }

    }
}