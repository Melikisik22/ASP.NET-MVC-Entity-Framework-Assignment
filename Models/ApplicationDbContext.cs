using System.Collections.Generic;
using System.Data.Entity;

namespace InsuranceQuoteApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Insuree> Insurees { get; set; }
    }
}
