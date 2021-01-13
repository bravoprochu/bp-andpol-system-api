using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class KombinacjaObszycie
    {
        public KombinacjaObszycie()
        {
            this.ZamowienieObszycie = new HashSet<ZamowienieKombiObszycie>();
        }

        public int KombinacjaObszycieId { get; set; }

        [Required(ErrorMessage = "Obszycie wartość, pole Wartosc jest wymagane")]
        public double Dlugosc { get; set; }
        public int KombinacjaRefId { get; set; }
        [ForeignKey("KombinacjaRefId")]
        public virtual Kombinacja Kombinacja { get; set; }
        public int  ObszycieRefId { get; set; }
        [ForeignKey("ObszycieRefId")]
        public virtual Obszycie Obszycie { get; set; }

        [Required(ErrorMessage = "Obszycie wartość, pole Wartosc jest wymagane")]
        public double Szerokosc { get; set; }

        [JsonIgnore]
        public virtual ICollection<ZamowienieKombiObszycie> ZamowienieObszycie { get; set; }


    }
}
