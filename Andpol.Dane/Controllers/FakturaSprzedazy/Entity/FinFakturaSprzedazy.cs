using Andpol.Dane.Pomocne.MagWZ;
using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.Entity
{
    public class FinFakturaSprzedazy
    {
        public FinFakturaSprzedazy()
        {
            this.MagWz = new HashSet<MagWz>();
            this.FakturaPozycje = new HashSet<FinFakturaSprzedazyPozycja>();
            this.FakturaPozycjeZmiany = new HashSet<FinFakturaSprzedazyPozycja>();
        }

        public int FinFakturaSprzedazyId { get; set; }
        public int? BaseFakturaSprzedazyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool CzyAktywna { get; set; }
        public bool CzyDodatkoweInfo { get; set; }
        public bool CzyKorekta { get; set; }
        public DateTime DataWystawienia { get; set; }
        public virtual FinFakturaSprzedazyDodatkoweInfo DodatkoweInfo { get; set; }
        public string MagWzIds { get; set; }
        public int NabywcaRefId { get; set; }
        [ForeignKey("NabywcaRefId")]
        public virtual Kontrahent Nabywca { get; set; }
        public string NumerDokumentu { get; set; }
        public int PlatnoscRefId { get; set; }

        [ForeignKey("PlatnoscRefId")]
        public FinFakturaSprzedazyPlatnosc Platnosc { get; set; }

        public double RazemBrutto { get; set; }
        public double RazemNetto { get; set; }
        public double RazemPodatek { get; set; }

        public int SprzedawcaRefId { get; set; }
        [ForeignKey("SprzedawcaRefId")]
        public virtual Kontrahent Sprzedawca { get; set; }

        public string Uwagi { get; set; }
        public int WalutaRefId { get; set; }
        [ForeignKey("WalutaRefId")]
        public FinWaluta Waluta { get; set; }

        public virtual ICollection<MagWz> MagWz { get; set; }
        [InverseProperty("FakturaSprzedazy")]
        public virtual ICollection<FinFakturaSprzedazyPozycja> FakturaPozycje { get; set; }
        [InverseProperty("FakturaSprzedazyZmmiany")]
        public virtual ICollection<FinFakturaSprzedazyPozycja> FakturaPozycjeZmiany { get; set; }
        




    }
}
