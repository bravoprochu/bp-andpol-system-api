using Andpol.Dane.Pomocne.FakturaSprzedazy.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class FinWaluta
    {
        public FinWaluta()
        {
            this.FakturaZakupu = new HashSet<FinFakturaZakupu>();
            this.PlatnoscPrzypomnienie = new HashSet<FinPlatnoscPrzypomnienie>();
            this.FakturaSprzedazy = new HashSet<FinFakturaSprzedazy>();

        }
        public int FinWalutaId { get; set; }
        [MaxLength(3)]
        public string Skrot { get; set; }
        [MaxLength(30)]
        public string Nazwa { get; set; }

        [JsonIgnore]
        [InverseProperty("Waluta")]
        public virtual ICollection<FinFakturaZakupu> FakturaZakupu { get; set; }
        [JsonIgnore]
        [InverseProperty("Waluta")]
        public virtual ICollection<FinPlatnoscPrzypomnienie> PlatnoscPrzypomnienie { get; set; }
        public virtual ICollection<FinFakturaSprzedazy> FakturaSprzedazy { get; set; }

    }
}