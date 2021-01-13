using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class FinFakturaPozycjeTkaniny
    {
        public int FinFakturaPozycjeTkaninyId { get; set; }
        public double Cena { get; set; }
        public int FakturaZakupuRefId { get; set; }
        [ForeignKey("FakturaZakupuRefId")]
        public virtual FinFakturaZakupu FakturaZakupu { get; set; }
        public double Ilosc{ get; set; }

        public int MaterialRefId { get; set; }
        [ForeignKey("MaterialRefId")]
        public virtual Material Material { get; set; }
        public int VatZakupuRefId { get; set; }
        [ForeignKey("VatZakupuRefId")]
        public virtual JednPodatekStawka VatZakupu { get; set; }
        public double Wartosc { get; set; }
    }
}