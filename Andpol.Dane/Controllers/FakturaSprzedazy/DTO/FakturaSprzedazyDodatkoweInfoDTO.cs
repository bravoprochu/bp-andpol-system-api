using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Andpol.Dane.ModelsDTO;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.DTO
{
    public class FakturaSprzedazyDodatkoweInfoDTO
    {
        public bool CzyColli { get; set; }
        public bool CzyAdresDostawy { get; set; }
        public bool CzyWaga { get; set; }
        public KontrahentDealerInfoDTO AdresDostawy { get; set; }
        public int Colli { get; set; }
        public double WagaBrutto { get; set; }
        public double WagaNetto { get; set; }

    }
}