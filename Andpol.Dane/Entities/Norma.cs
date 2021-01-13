using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class Norma
    {
        public Norma() {
            this.Kombinacje = new HashSet<Kombinacja>();
            this.Zamowienie = new HashSet<Zamowienie>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Norma, pole NAZWA jest wymagane")]
        public bool CzyAktywna { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }

        public virtual ICollection<Kombinacja> Kombinacje { get;  set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }

    }
}