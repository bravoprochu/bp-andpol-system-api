using Andpol.Dane.Entities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.Entity
{
    public class FinFakturaSprzedazyDodatkoweInfo
    {
        public int FinFakturaSprzedazyId { get; set; }
        public int? Colli { get; set; }
        public virtual FinFakturaSprzedazy FakturaSprzedazy { get; set; }
        public int? KontrahentDealerAdresDostawyRefId { get; set; }
        [ForeignKey("KontrahentDealerAdresDostawyRefId")]
        public virtual KontrahentDealer KontrahentDealerAdresDostawy { get; set; }
        public double? WagaBrutto { get; set; }
        public double? WagaNetto { get; set; }
    }
}