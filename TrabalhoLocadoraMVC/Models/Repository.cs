using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrabalhoLocadoraMVC.Models
{
    public class Repository : DbContext
    {
        public Repository() : base("DefaultConnection") { }

        public DbSet<Cliente> Clientes { set; get; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}