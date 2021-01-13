using Andpol.Dane.Pomocne.FakturaSprzedazy.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class KontrahentDealer
    {

        public KontrahentDealer()
        {
            this.FakturaSprzedazyDodatkoweInfo = new HashSet<FinFakturaSprzedazyDodatkoweInfo>();
            this.ZamDealer = new HashSet<Zamowienie>();
            this.ZamDealerDostawa = new HashSet<Zamowienie>();
        }

        [Key]
        public int Id { get; set; }

        public bool CzyAdresDostawy { get; set; }
        public bool CzyWjedziePrzyczepa { get; set; }
        public string GodzinyOtwarcia { get; set; }
        public string Kod { get; set; }

        [StringLength(2)]
        public string KodKraju { get; set; }

        public int KontrahentRefId { get; set; }

        [ForeignKey("KontrahentRefId")]
        public Kontrahent Kontrahent { get; set; }

        public string Miejscowosc { get; set; }

        public string Nazwa { get; set; }

        public string Nr { get; set; }

        public string Ulica { get; set; }

        public string Uwagi { get; set; }
        [JsonIgnore]
        [InverseProperty("Dealer")]
        public virtual ICollection<Zamowienie> ZamDealer { get; set; }

        [JsonIgnore]
        [InverseProperty("DealerDostawa")]
        public virtual ICollection<Zamowienie> ZamDealerDostawa { get; set; }

        public virtual ICollection<FinFakturaSprzedazyDodatkoweInfo> FakturaSprzedazyDodatkoweInfo { get; set; }
    }
}
