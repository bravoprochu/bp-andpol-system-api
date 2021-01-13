using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class KombinacjaEtapyProdukcyjne
    {
        public int KombinacjaEtapyProdukcyjneId { get; set; }

        public int KombinacjaRefId { get; set; }
        [ForeignKey("KombinacjaRefId")]
        public virtual Kombinacja Kombinacja { get; set; }

        public int EtapyProdukcyjneRefId { get; set; }

        [ForeignKey("EtapyProdukcyjneRefId")]
        public virtual EtapyProdukcyjne EtapyProdukcyjne { get; set; }


    }
}
