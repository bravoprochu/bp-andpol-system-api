using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class EtapyProdukcyjne
    {
        public EtapyProdukcyjne()
        {
            this.KombinacjeEtapyProdukcyjne = new HashSet<KombinacjaEtapyProdukcyjne>();
        }
        

        public int EtapyProdukcyjneId { get; set; }
        [Required(ErrorMessage = "Etapy Produkcyjne, pole NAZWA: jest wymagane")]
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public virtual ICollection<KombinacjaEtapyProdukcyjne> KombinacjeEtapyProdukcyjne { get; set; }
    }
}
