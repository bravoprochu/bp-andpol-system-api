using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class FinFakturaPodsumowanieWartosci
    {

        public int FinFakturaPodsumowanieWartosciId { get; set; }
        public int FakturaZakupuRefId { get; set; }

        [ForeignKey("FakturaZakupuRefId")]
        public virtual FinFakturaZakupu FakturaZakupu { get; set; }

        public int PodatekStawkaRefId { get; set; }
        [ForeignKey("PodatekStawkaRefId")]
        public virtual JednPodatekStawka PodatekStawka { get; set; }
        public double? WartoscBrutto { get; set; }
        public double? WartoscNetto{ get; set; }
        public double? WartoscVat { get; set; }

    }
}