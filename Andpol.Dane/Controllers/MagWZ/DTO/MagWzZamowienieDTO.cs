using Andpol.Dane.ModelsDTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Andpol.Dane.Pomocne.MagWZ.DTO
{
    public class MagWzZamowienieDTO
    {
        public MagWzZamowienieDTO()
        {
            this.Kombinacje = new List<MagWzZamowienieKombiDTO>();
            this.WykonczeniaPolitykaCenowa = new List<MagWzWyZamowienieKombiWykonczenieDTO>();
        }
        [JsonIgnore]
        public List<MagWzZamowienieKombiDTO> Kombinacje { get; set; }
        public int KombinacjeCount { get {
                return this.Kombinacje.Count;
            } }
        [JsonIgnore]
        public List<MagWzWyZamowienieKombiWykonczenieDTO> WykonczeniaPolitykaCenowa { get; set; }
        public string Commission { get; set; }
        public string MaterialNazwa { get; set; }
        public string NormaNazwa { get; set; }
        public string Reference { get; set; }
        public int ZamowienieId { get; set; }
        public string ZamowienieNr { get; set; }
        public string UniqueKey
        {
            get
            {
                return $"C:{this.Commission}_R:{this.Reference}_Z:{this.ZamowienieNr}_N:{this.ZamowienieKombiNazwaKey}_W:{this.WartoscKombinacji.WartoscPoNaliczeniach}";
            }
        }
        public string ZamowienieKombiNazwaKey
        {
            get
            {
                var czyMaterial = string.IsNullOrWhiteSpace(this.MaterialNazwa) ? null : $", ({this.MaterialNazwa})";
                return this.NormaNazwa + ", " +
                    Pomocne.ZamowieniaHelpful.ZamowienieKombinacjeNazwa(Kombinacje.Select(s => s.NazwaKombinacji).ToList()) +
                    czyMaterial;

            }
        }
        public MagWzZamowienieKombiWartoscDTO WartoscKombinacji
        {
            get {
                var result = new MagWzZamowienieKombiWartoscDTO();
                var regulyAll = this.WykonczeniaPolitykaCenowa.Where(w => w.CzyPolitykaCenowa==true).Select(s => s).ToList();

                foreach (var k in this.Kombinacje)
                {
                    var regulyKombi = regulyAll.Where(w => w.KombinacjaRefId == k.KombinacjaRefId).Select(s => s).ToList();

                    foreach (var regKombi in regulyKombi)
                    {
                        foreach (var regula in regKombi.PolitykaCenowa.Reguly)
                        {
                            double wart = 0;
                            switch (regula.TypRozliczenia)
                            {
                                case (int)Finanse.PolitykaCenowa.PolitykaCenowaRegulaTypEnum.Procentowo:
                                    var procentWartosc= regula.Wartosc > 0 ? (regula.Wartosc/100) : 1;
                                    wart = k.Wartosc * procentWartosc;
                                    result.WartoscNaliczen += wart;

                                    result.NaliczeniaNazwy.Add($"{wart.ToString("0.00")} | {k.Wartosc.ToString("0.00")} | typ: procentowo ({procentWartosc.ToString("P1")}) | '{k.NazwaKombinacji}' {regKombi.WykonczenieGrupa.Nazwa} - {regKombi.Nazwa}, polityka: {regKombi.PolitykaCenowa.Nazwa}");
                                    break;

                                case (int)Finanse.PolitykaCenowa.PolitykaCenowaRegulaTypEnum.WartoscMulti:
                                    wart = regula.Wartosc * regKombi.Ilosc;
                                    result.WartoscNaliczen += wart;
                                    result.NaliczeniaNazwy.Add($"{wart.ToString("0.00")} | {k.Wartosc.ToString("0.00")} | typ: wartoscMulti ({regKombi.Ilosc}x{regula.Wartosc.ToString("0.00")}) | '{k.NazwaKombinacji}' {regKombi.WykonczenieGrupa.Nazwa} - {regKombi.Nazwa}, polityka: {regKombi.PolitykaCenowa.Nazwa}");
                                    break;
                                case (int)Finanse.PolitykaCenowa.PolitykaCenowaRegulaTypEnum.WartoscJednostkowo:
                                    result.WartoscNaliczen += regula.Wartosc;
                                    result.NaliczeniaNazwy.Add($"{regula.Wartosc.ToString("0.00")} | {k.Wartosc.ToString("0.00")} | typ: wartoscJednostkowo ({k.Wartosc.ToString("0.00")}+{regula.Wartosc.ToString("0.00")}) | '{k.NazwaKombinacji}' {regKombi.WykonczenieGrupa.Nazwa} - {regKombi.Nazwa}, polityka: {regKombi.PolitykaCenowa.Nazwa}");
                                    break;
                            }
                        }
                    }
                }
                result.WartoscBaza = Kombinacje.Sum(s => s.Wartosc);
                result.WartoscPoNaliczeniach = result.WartoscBaza + result.WartoscNaliczen;
                return result;
            }
        }
        
    }
}