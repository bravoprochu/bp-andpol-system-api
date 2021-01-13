using Andpol.Dane.Pomocne.FakturaSprzedazy.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class JednPlatnoscRodzaj
    {
        public JednPlatnoscRodzaj()
        {
            this.FakturaZakupu = new HashSet<FinFakturaZakupu>();
            this.FakturaSprzedazyPlatnosc = new HashSet<FinFakturaSprzedazyPlatnosc>();
        }

        public int JednPlatnoscRodzajId { get; set; }
        public string Nazwa { get; set; }
        public bool CzyDni { get; set; }
        public bool CzyUwagi { get; set; }

        [JsonIgnore]
        public virtual ICollection<FinFakturaZakupu> FakturaZakupu { get; set; }
        [JsonIgnore]
        public virtual ICollection<FinFakturaSprzedazyPlatnosc> FakturaSprzedazyPlatnosc { get; set; }

    }
}