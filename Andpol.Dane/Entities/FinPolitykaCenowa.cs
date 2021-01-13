using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class FinPolitykaCenowa
    {
        public FinPolitykaCenowa()
        {
            this.PolitykaCenowaRegula = new HashSet<FinPolitykaCenowaRegula>();
            this.KombinacjaWykonczenie = new HashSet<KombinacjaWykonczenie>();
        }

        public int FinPolitykaCenowaId { get; set; }

        [Required]
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }

        public virtual ICollection<FinPolitykaCenowaRegula> PolitykaCenowaRegula { get; set; }
        public virtual ICollection<KombinacjaWykonczenie> KombinacjaWykonczenie { get; set; }
    }
}