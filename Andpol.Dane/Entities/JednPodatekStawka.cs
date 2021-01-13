using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class JednPodatekStawka
    {
        public JednPodatekStawka()
        {
            VatSprzedazyColl = new HashSet<MagPozycjaMagazynowa>();
            VatZakupuColl = new HashSet<MagPozycjaMagazynowa>();
            FakturaPodsumowanieWartosci = new HashSet<FinFakturaPodsumowanieWartosci>();
            FakturaPozycjeMag = new HashSet<FinFakturaPozycje>();
            FakturaPozycjeTkaniny = new HashSet<FinFakturaPozycjeTkaniny>();
        }

        public int JednPodatekStawkaId { get; set; }

        [Required, MaxLength(50)]
        public string Nazwa { get; set; }

        public double Wartosc { get; set; }

        [MaxLength(100)]
        public string Uwagi { get; set; }

        [JsonIgnore]
        [InverseProperty("VatZakupu")]
        public virtual ICollection<MagPozycjaMagazynowa> VatZakupuColl { get; set;}

        [JsonIgnore]
        [InverseProperty("VatSprzedazy")]
        public virtual ICollection<MagPozycjaMagazynowa> VatSprzedazyColl { get; set; }

        [JsonIgnore]
        [InverseProperty("PodatekStawka")]
        public virtual ICollection<FinFakturaPodsumowanieWartosci> FakturaPodsumowanieWartosci { get; set; }

        [JsonIgnore]
        [InverseProperty("VatZakupu")]
        public virtual ICollection<FinFakturaPozycje> FakturaPozycjeMag { get; set; }

        [JsonIgnore]
        [InverseProperty("VatZakupu")]
        public virtual ICollection<FinFakturaPozycjeTkaniny> FakturaPozycjeTkaniny { get; set; }
    }
}