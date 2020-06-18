using _2020Telefon_Rehberi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2020Telefon_Rehberi.Controllers
{
    public class HomeController : Controller
    {
        private telefonContext db = new telefonContext(); 
        // GET: Home
        public ActionResult Index()
        {

            return View(db.telRehber.ToList());
        }
    }
}