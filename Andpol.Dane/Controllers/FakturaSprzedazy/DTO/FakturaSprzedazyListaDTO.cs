using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.DTO
{
    public class FakturaSprzedazyListaDTO
    {
        public int FakturaSprzedazyId { get; set; }
        public string CreatedBy { get; set; }
        public bool CzyKorekta { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime DataWystawienia { get; set; }
        public KontrahentInfoDTO Nabywca { get; set; }
        public string NumerDokumentu { get; set; }
        public double RazemBrutto { get; set; }
        public double RazemNetto { get; set; }
        public double RazemPodatek { get; set; }
        public string Uwagi { get; set; }
        public string WalutaSkrot { get; set; }
    }
}