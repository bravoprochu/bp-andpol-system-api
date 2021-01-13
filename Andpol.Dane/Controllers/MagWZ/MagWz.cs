using Andpol.Dane.Pomocne.FakturaSprzedazy.Entity;
using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.MagWZ
{
    public class MagWz
    {

        public MagWz()
        {
            this.MagWzPozycjaPozMag = new HashSet<MagWzPozycjaPozMag>();
            this.MagWzPozycjaZamowienie = new HashSet<MagWzPozycjaZamowienie>();
        }

        public int MagWzId { get; set; }
        public int BaseMagWzId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool CzyKorekta { get; set; }
        public bool CzyZaksiegowana { get; set; }
        public DateTime DataWystawienia { get; set; }

        public int? FinFakturaSprzedazyRefId { get; set; }
        [ForeignKey("FinFakturaSprzedazyRefId")]
        public virtual FinFakturaSprzedazy FakturaSprzedazy { get; set; }

        public int KontrahentRefId { get; set; }
        [ForeignKey("KontrahentRefId")]
        public virtual Kontrahent Kontrahent { get; set; }
        public string NumerDokumentu { get; set; }
        public string NumerDokumentuZrodlowego { get; set; }
        public string Uwagi { get; set; }

        public virtual ICollection<MagWzPozycjaPozMag> MagWzPozycjaPozMag { get; set; }
        public virtual ICollection<MagWzPozycjaZamowienie> MagWzPozycjaZamowienie { get; set; }

    }
}