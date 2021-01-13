using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class FinFakturaPozycje
    {
        public int FinFakturaPozycjeId { get; set; }

        public double Cena { get; set; }

        public int FakturaZakupuRefId { get; set; }
        [ForeignKey("FakturaZakupuRefId")]
        public virtual FinFakturaZakupu FakturaZakupu { get; set; }

        public double Ilosc { get; set; }
        public int PozycjaMagazynowaRefId { get; set; }

        [ForeignKey("PozycjaMagazynowaRefId")]
        public virtual MagPozycjaMagazynowa PozycjaMagazynowa { get; set; }
        public int VatZakupuRefId { get; set; }

        [ForeignKey("VatZakupuRefId")]
        public virtual JednPodatekStawka VatZakupu { get; set; }
        public double Wartosc { get; set; }

    }
}