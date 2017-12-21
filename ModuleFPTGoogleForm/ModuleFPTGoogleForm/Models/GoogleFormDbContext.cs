using ModuleFPTGoogleForm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcGoogleForm.Models
{
    public class GoogleFormDbContext : DbContext
    {
        public GoogleFormDbContext() : base("GoogleForm") { }
        public DbSet<Form> Form { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<AnwserDetail> AnwserDetail { get; set; }
        
    }
}