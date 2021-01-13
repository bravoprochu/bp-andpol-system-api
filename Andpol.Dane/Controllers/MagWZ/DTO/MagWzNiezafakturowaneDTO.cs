using Andpol.Dane.Pomocne.FakturaSprzedazy.DTO;
using Andpol.Dane.ModelsDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.MagWZ.DTO
{
    public class MagWzNiezafakturowaneDTO
    {
        public MagWzNiezafakturowaneDTO()
        {
            this.ZamowienieKombi = new List<MagWzZamowienieDTO>();
        }

        public int MagWzId { get; set; }
        public bool CzyPozMag { get; set; }
        public MagWzBasicInfoDTO BasicInfo { get; set; }

        public List<FakturaSprzedazyPozycjaDTO> Pozycja
        {
            get
            {
                if (this.ZamowienieKombi.Count > 0)
                {

                    return ZamowienieKombi.Select(s => new FakturaSprzedazyPozycjaDTO
                    {
                        Ilosc = 1,
                        IloscKombinacji=s.Kombinacje.Count(),
                        Nazwa = s.ZamowienieKombiNazwaKey,
                        UniqueKey = s.UniqueKey,
                        Waga=s.Kombinacje.Sum(sum=>sum.Waga),
                        WartoscJedn = s.WartoscKombinacji.WartoscPoNaliczeniach,
                        WartoscKombinacjiJedn = s.WartoscKombinacji,
                        NaliczeniaNazwy = s.WartoscKombinacji.NaliczeniaNazwy.ToList()
                    }).ToList();
                }
                else
                {
                    return this.CzyPozMag && this.PozycjeMagazynowe!=null ? this.PozycjeMagazynowe.Select(s => new FakturaSprzedazyPozycjaDTO
                    {
                        //CzyPozMag = true,
                        //Ilosc=s.Ilosc,
                        //Nazwa=s.Nazwa,
                        //PozMagId=s.PozycjaMagazynowaId,
                        //UniqueKey=s.UniqueKey,
                    }).ToList() : new List<FakturaSprzedazyPozycjaDTO>();
                }
            }
        }
        public List<FakturaSprzedazyPozycjaDTO> PozycjaGroup
        {
            get
            {
                if (this.ZamowienieKombi.Count > 0)
                {

                    return ZamowienieKombi.GroupBy(g => g.UniqueKey).Select(s => new FakturaSprzedazyPozycjaDTO
                    {
                        Ilosc = (int)s.Count(),
                        IloscKombinacji = s.FirstOrDefault().Kombinacje.Count(),
                        Nazwa = s.FirstOrDefault().ZamowienieKombiNazwaKey,
                        UniqueKey = s.FirstOrDefault().UniqueKey,
                        //Waga=s.SelectMany(sm=>sm.Kombinacje).Sum(sum=>sum.Waga),
                        Waga=s.FirstOrDefault().Kombinacje.Sum(sum=>sum.Waga),
                        WartoscJedn = s.FirstOrDefault().WartoscKombinacji.WartoscPoNaliczeniach,
                        WartoscKombinacjiJedn = s.FirstOrDefault().WartoscKombinacji,
                        NaliczeniaNazwy = s.SelectMany(sm => sm.WartoscKombinacji.NaliczeniaNazwy).Select(n => n).ToList()
                        
                    }).ToList();
                }
                else {
                    return CzyPozMag && this.PozycjeMagazynowe!=null ? this.PozycjeMagazynowe.GroupBy(g => g.UniqueKey).Select(s => new FakturaSprzedazyPozycjaDTO
                    {
                        CzyPozMag = true,
                        Ilosc = s.Sum(sum => sum.Ilosc),
                        Nazwa = s.FirstOrDefault().Nazwa,
                        PodatekStawka = s.FirstOrDefault().PodatekStawka,
                        PozMagId = s.FirstOrDefault().PozycjaMagazynowaId,
                        UniqueKey = s.FirstOrDefault().UniqueKey
                    }).ToList() : new List<FakturaSprzedazyPozycjaDTO>();
                }
            }
        }

        [JsonIgnore]
        public List<MagWzPozycjeMagazynoweDTO> PozycjeMagazynowe { get; set; }

        [JsonIgnore]
        public List<MagWzZamowienieDTO> ZamowienieKombi { get; set; }

    }
}