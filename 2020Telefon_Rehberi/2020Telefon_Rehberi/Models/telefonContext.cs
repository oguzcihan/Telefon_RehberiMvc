using _2020Telefon_Rehberi.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _2020Telefon_Rehberi.Models
{
    public class telefonContext : IdentityDbContext<ApplicationUser>
    {
        public telefonContext():base("telDb")
        {
            Database.SetInitializer(new telefonInitializer());
        }
        public DbSet<Departman> depts { get; set; }
        public DbSet<telRehber> telRehber { get; set; }
    }
}