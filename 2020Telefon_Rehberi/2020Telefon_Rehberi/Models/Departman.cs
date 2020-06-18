using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2020Telefon_Rehberi.Models
{
    public class Departman
    {
        public int Id { get; set; }
        public string departmanAdi { get; set; }
        public List<telRehber> rehber { get; set; }
    }
}