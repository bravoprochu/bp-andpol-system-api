using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{

   public class JednRozchodMagRodzaj
    {
        public JednRozchodMagRodzaj()
        {
            this.MaterialBelkaRozchodInne = new HashSet<MaterialBelkaRozchodInne>();
            this.PozycjaMagazynowaRozchodInne = new HashSet<MagPozycjaMagazynowaRozchodInne>();
        }

        public int JednRozchodMagRodzajId { get; set; }
        public string Nazwa { get; set; }
        public bool CzyUwagi { get; set; }
        [JsonIgnore]
        public virtual ICollection<MaterialBelkaRozchodInne> MaterialBelkaRozchodInne { get; set; }
        [JsonIgnore]
        public virtual ICollection<MagPozycjaMagazynowaRozchodInne> PozycjaMagazynowaRozchodInne { get; set; }

    }
}