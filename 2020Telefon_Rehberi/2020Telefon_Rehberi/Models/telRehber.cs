using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2020Telefon_Rehberi.Models
{
    public class telRehber
    {
        public int Id { get; set; }
        [Required]
        public string adSoyad { get; set; }
        [Required]
        [MaxLength(11)]
        public string telefon { get; set; }
        public string yoneticiBilgisi { get; set; }

        public int departmanId { get; set; }
        public  Departman departman { get; set; }
    }
}