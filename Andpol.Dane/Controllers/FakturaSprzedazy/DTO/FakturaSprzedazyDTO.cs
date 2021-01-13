using Andpol.Dane.Pomocne.MagWZ.DTO;
using Andpol.Dane.Pomocne.PlanningExt;
using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.DTO
{
    public class FakturaSprzedazyDTO:StatusDTO
    {

        public FakturaSprzedazyDTO()
        {
            this.FakturaPozycje = new List<FakturaSprzedazyPozycjaDTO>();
            this.FakturaPozycjePrzed = new List<FakturaSprzedazyPozycjaDTO>();
            this.FakturaPozycjeZmiany = new List<FakturaSprzedazyPozycjaDTO>();
            this.MagWzWybrane = new List<MagWzNiezafakturowaneDTO>();
            this.MagWzIds = new List<int>();
            this.MagWzIdsUsuniete = new List<int>();
        }

        public int FakturaSprzedazyId { get; set; }
        public int BaseFakturaId { get; set; }
        public string BaseFakturaNumerDokumentu { get; set; }
        public DateTime BaseFakturaDataWystawienia { get; set; }
        public double BaseFakturaRazemNetto { get; set; }
        public double BaseFakturaRazemBrutto { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool CzyDodatkoweInfo { get; set; }
        public bool CzyAktywna { get; set; }
        public bool CzyEng { get; set; }
        public bool CzyGenerujFakture { get; set; }
        public bool CzyKorekta { get; set; }
        public DateTime DataWystawienia { get; set; }
        public FakturaSprzedazyDodatkoweInfoDTO DodatkoweInfo { get; set; }
        public KontrahentInfoDTO Nabywca { get; set; }
        public string NumerDokumentu { get; set; }
        public FakturaSprzedazyPlatnoscDTO Platnosc { get; set; }
        public double RazemBrutto { get; set; }
        public double RazemNetto { get; set; }
        public double RazemPodatek { get; set; }
        public KontrahentInfoDTO Sprzedawca { get; set; }
        public string Uwagi { get; set; }
        public WalutaDTO Waluta { get; set; }
        public List<FakturaSprzedazyPozycjaDTO> FakturaPozycje { get; set; }
        public List<FakturaSprzedazyPozycjaDTO> FakturaPozycjePrzed { get; set; }
        public List<FakturaSprzedazyPozycjaDTO> FakturaPozycjeZmiany { get; set; }
        public List<int> MagWzIds { get; set; }
        public List<int> MagWzIdsUsuniete { get; set; }
        public List<MagWzNiezafakturowaneDTO> MagWzWybrane { get; set; }
    }
}