using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class FinFakturaZakupu
    {
        public FinFakturaZakupu()
        {
            this.FakturaPodsumowanieWartosci = new HashSet<FinFakturaPodsumowanieWartosci>();
            this.FakturaPozycje = new HashSet<FinFakturaPozycje>();
            this.FakturaPozycjeTkaniny = new HashSet<FinFakturaPozycjeTkaniny>();
            this.PzRozliczoneMag = new HashSet<MagPz>();
        }


        public int FinFakturaZakupuId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool CzyEuro { get; set; }
        public bool CzyPrzypomnieniePlatnosc { get; set; }

        public DateTime DataSprzedazy { get; set; }
        public DateTime DataWplywu { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string FakturaNr { get; set; }

        public int KontrahentRefId { get; set; }

        [ForeignKey("KontrahentRefId")]
        public virtual Kontrahent Kontrahent { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }


        public virtual FinPlatnoscPrzypomnienie PlatnoscPrzypomnienie { get; set; }

        public int PlatnoscRodzajRefId { get; set; }

        [ForeignKey("PlatnoscRodzajRefId")]
        public virtual JednPlatnoscRodzaj PlatnoscRodzaj { get; set; }

        public int? PlatnoscRodzajIleDni { get; set; }
        public string PlatnoscRodzajUwagi { get; set; }
        public double RazemBrutto { get; set; }
        public double RazemNetto { get; set; }
        public double RazemVat { get; set; }
        public string Uwagi { get; set; }
        public int WalutaRefId { get; set; }

        [ForeignKey("WalutaRefId")]
        public virtual FinWaluta Waluta { get; set; }




        [JsonIgnore]
        public virtual ICollection<FinFakturaPodsumowanieWartosci> FakturaPodsumowanieWartosci { get; set; }

        [JsonIgnore]
        public virtual ICollection<FinFakturaPozycje> FakturaPozycje { get; set; }
        [JsonIgnore]
        public virtual ICollection<FinFakturaPozycjeTkaniny> FakturaPozycjeTkaniny { get; set; }
        [JsonIgnore]
        public virtual ICollection<MagPz> PzRozliczoneMag { get; set; }

        public virtual ICollection<MaterialBelkaPzTkaniny> PzRozliczoneTkaniny { get; set; }
        
        








    }
}