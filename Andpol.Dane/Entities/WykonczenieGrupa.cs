using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class WykonczenieGrupa
    {
        public WykonczenieGrupa()
        {
            this.Wykonczenie = new HashSet<Wykonczenie>();
        }
        public int WykonczenieGrupaId { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        [JsonIgnore]
        public virtual ICollection<Wykonczenie> Wykonczenie { get; set; }
    }
}