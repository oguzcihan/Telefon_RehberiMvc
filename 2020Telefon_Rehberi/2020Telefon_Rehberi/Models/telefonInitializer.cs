using _2020Telefon_Rehberi.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _2020Telefon_Rehberi.Models
{
    public class telefonInitializer:DropCreateDatabaseIfModelChanges<telefonContext>
    {
        protected override void Seed(telefonContext context)
        {
            List<Departman> departmanlar = new List<Departman>()
            {
                new Departman(){ departmanAdi="Yazılım"},
                new Departman(){ departmanAdi="Muhasebe"}
            };
            foreach (var item in departmanlar)
            {
                context.depts.Add(item);
            }
            context.SaveChanges();

            List<telRehber> telRehbers = new List<telRehber>()
            {
                new telRehber(){ adSoyad="oğuz cihan", departmanId=1, telefon="12345674444", yoneticiBilgisi="deneme"},
                new telRehber(){ adSoyad="cihan oğuz", departmanId=2, telefon="34567436544", yoneticiBilgisi="deneme yönetici"},
            };
            foreach (var item in telRehbers)
            {
                context.telRehber.Add(item);
            }
            context.SaveChanges();


            //roller

            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "yönetici" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "kullanıcı" };
                manager.Create(role);
            }
            //user
            if (!context.Users.Any(i => i.Name == "oguzcihan"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "oguz",
                    Surname = "cihan",
                    UserName = "oguzcihan",
                    Email = "oguzcihan12@gmail.com"
                };

                manager.Create(user, "1234");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context);
        }
    }
}