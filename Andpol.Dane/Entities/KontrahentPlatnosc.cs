using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class KontrahentPlatnosc
    {

        public KontrahentPlatnosc()
        {
            this.Kontrahent = new HashSet<Kontrahent>();
        }
        public int KontrahentPlatnoscId { get; set; }

        public int? IleDni { get; set; }
        
        public string Uwagi { get; set; }

        public bool TransportWcenie { get; set; }

        public double? TransportStawka { get; set; }

        public int PlatnoscRodzajRefId { get; set; }
        
        [ForeignKey("PlatnoscRodzajRefId")]
        public virtual JednPlatnoscRodzaj PlatnoscRodzaj { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kontrahent> Kontrahent { get; set; }


    }
}
