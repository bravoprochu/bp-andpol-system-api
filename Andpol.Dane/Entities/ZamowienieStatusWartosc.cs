using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class ZamowienieStatusWartosc
    {
        [Key]
        public int Id { get; set; }

        public bool Gotowe { get; set; }

        public string Uwagi { get; set; }
        public DateTime DataUtworzenia { get; set; }

        public int ZamowienieStatusNazwaRefId { get; set; }
        [ForeignKey("ZamowienieStatusNazwaRefId")]
        public virtual ZamowienieStatusNazwa ZamowienieStatusNazwa { get; set; }

        public int ZamowienieRefId { get; set; }
        [ForeignKey("ZamowienieRefId")]
        public virtual Zamowienie Zamowienie { get; set; }
    }
}
