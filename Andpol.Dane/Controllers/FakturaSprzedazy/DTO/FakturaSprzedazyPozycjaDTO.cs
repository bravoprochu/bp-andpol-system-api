using Andpol.Dane.Pomocne.MagWZ.DTO;
using Andpol.Dane.Pomocne.Zamowienia.DTO;
using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using System.Collections.Generic;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.DTO
{
    public class FakturaSprzedazyPozycjaDTO:StatusDTO
    {
        public FakturaSprzedazyPozycjaDTO()
        {
            this.NaliczeniaNazwy = new List<string>();
        }
        public int FakturaSprzedazyPozycjaId { get; set; }
        public bool CzyKorekta { get; set; }
        public bool CzyPozMag { get; set; }
        public int? FakturaSprzedazyPozycjaOrygRef { get; set; }
        public double Ilosc { get; set; }
        public int IloscKombinacji { get; set; }
        public List<string> NaliczeniaNazwy { get; set; }
        public string Nazwa { get; set; }
        public PodatekStawkaDTO PodatekStawka  { get; set; }
        public int PozMagId { get; set; }
        public string UniqueKey { get; set; }
        public double Waga { get; set; }
        public double WartoscJedn { get; set; }
        public MagWzZamowienieKombiWartoscDTO WartoscKombinacjiJedn { get; set; }


    }
}