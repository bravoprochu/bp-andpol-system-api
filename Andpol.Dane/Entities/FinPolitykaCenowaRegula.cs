using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class FinPolitykaCenowaRegula
    {
        public int FinPolitykaCenowaRegulaId { get; set; }
        public bool CzyAktywna { get; set; }
        public int KontrahentRefId { get; set; }
        [ForeignKey("KontrahentRefId")]
        public virtual Kontrahent Kontrahent { get; set; }
        public int PolitykaCenowaRefId { get; set; }
        [ForeignKey("PolitykaCenowaRefId")]
        public virtual FinPolitykaCenowa PolitykaCenowa { get; set; }
        public int TypRozliczenia { get; set; }
        public double Wartosc { get; set; }

    }
}