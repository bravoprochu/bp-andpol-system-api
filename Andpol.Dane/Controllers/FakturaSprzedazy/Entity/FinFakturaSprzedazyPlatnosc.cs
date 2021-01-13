using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.Entity
{
    public class FinFakturaSprzedazyPlatnosc
    {
        public FinFakturaSprzedazyPlatnosc()
        {
            this.FakturaSprzedazy = new HashSet<FinFakturaSprzedazy>();
        }

        public int FinFakturaSprzedazyPlatnoscId { get; set; }
        public int? IleDni { get; set; }
        public string Uwagi { get; set; }
        public int PlatnoscRodzajRefId { get; set; }
        [ForeignKey("PlatnoscRodzajRefId")]
        public virtual JednPlatnoscRodzaj PlatnoscRodzaj { get; set; }
        public virtual ICollection<FinFakturaSprzedazy> FakturaSprzedazy { get; set; }
    }
}