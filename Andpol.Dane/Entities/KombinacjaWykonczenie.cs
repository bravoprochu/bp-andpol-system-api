using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class KombinacjaWykonczenie
    {
        public int KombinacjaWykonczenieId { get; set; }
        public bool CzyPolitykaCenowa { get; set; }

        public byte Ilosc { get; set; }
        public int KombinacjaRefId { get; set; }
        [ForeignKey("KombinacjaRefId")]
        public virtual Kombinacja Kombinacja { get; set; }

        public int? PolitykaCenowaRefId { get; set; }

        [ForeignKey("PolitykaCenowaRefId")]
        public virtual FinPolitykaCenowa PolitykaCenowa { get; set; }

        public int WykonczenieRefId { get; set; }
        [ForeignKey("WykonczenieRefId")]
        public virtual Wykonczenie Wykonczenie { get; set; }
    }
}