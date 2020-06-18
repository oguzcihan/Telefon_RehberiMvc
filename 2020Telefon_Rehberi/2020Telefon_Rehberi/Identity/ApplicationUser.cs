using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2020Telefon_Rehberi.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}