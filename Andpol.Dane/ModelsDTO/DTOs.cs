using Andpol.Dane.Pomocne.PlanningExt;
using Andpol.Dane.Entities;
using Andpol.Dane.Pomocne;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZuzycieMaterialu.Zuzycie;

namespace Andpol.Dane.ModelsDTO
{

    public enum Statusy
    {
        baza = 1,
        nowy = 2,
        usuniety = 3,
        zmieniony = 4
    }

    public class StatusDTO {

        public string Status { get; set; }
        public byte Lp { get; set; }
    }

    public class BrygadzistaDTO : StatusDTO
    {
        public UserDTO User { get; set; }
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
    }


    public class CalendarDTO
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double RazemDni { get; set; }
        public ICollection<CalendarWeekDTO> Weeks { get; set; }
    }

    public class CalendarWeekDTO
    {
        public ICollection<CalendarWeekDayDTO> Days { get; set; }
    }

    public class CalendarWeekDayDTO
    {
        public bool Active { get; set; }
        public DateTime DzienRoboczy { get; set; }
        public int WeekDay { get; set; }
        public KalendarzDniRoboczychDTO DataObj { get; set; }
        public int Hue { get; set; }
    }

    public class CreatedInfoDTO
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }


    public class KontrahentDealerInfoDTO
    {
        public KontrahentDealerInfoDTO()
        {
            this.KontrahentDealer = new KontrahentDealer();
        }

        [JsonIgnore]
        public KontrahentDealer KontrahentDealer { get; set; }
        public int KontrahentDealerId { get; set; }

        public string Adres
        {
            get
            {
                return $"{this.KontrahentDealer.KodKraju}, {this.KontrahentDealer.Kod} {this.KontrahentDealer.Miejscowosc}, {this.KontrahentDealer.Ulica} {this.KontrahentDealer.Nr}";
            }
        }
        public bool CzyAdresDostawy { get {
                return this.KontrahentDealer.CzyAdresDostawy;
            } }
        public bool CzyWjedziePrzyczepa { get {
                return this.KontrahentDealer.CzyWjedziePrzyczepa;
            } }
        public int DealerId { get {
                return this.KontrahentDealer.Id;
            } }
        public int KontrahentRefId { get {
                return this.KontrahentDealer.KontrahentRefId;
            } }
        public string Nazwa { get {
                return $"{this.KontrahentDealer.Nazwa}";
            } }
        public string Uwag { get {
                return this.KontrahentDealer.Uwagi;
            } }
    }

    public class KontrahentDealerDTO : StatusDTO
    {
        public int DealerId { get; set; }
        public bool CzyAdresDostawy { get; set; }
        public bool CzyWjedziePrzyczepa { get; set; }
        public string Adres { get; set; }
        public string Nazwa { get; set; }
        public String Uwagi { get; set; }
    }

    public class KontrahentDealerFullDTO : KontrahentDealerDTO
    {
        public string GodzinyOtwarcia { get; set; }
        public string KodKraju { get; set; }
        public string Kod { get; set; }
        public string Miejscowosc { get; set; }
        public string Ulica { get; set; }
        public string Nr { get; set; }
    }

    public class KontrahentDealerZamowienieDTO : KontrahentDealerDTO
    {
        public string Adres { get; set; }
        public string KontrahentNazwa { get; set; }
        public int KontrahentRefId { get; set; }
        public string GodzinyOtwarcia { get; set; }

    }

    public class EtapyProdukcyjneDTO : StatusDTO
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }

    }

    public class UserRolesDTO
    {
        public string Id { get; set; }
        public string Nazwa { get; set; }
    }

    public class UserDTO : StatusDTO
    {
        public string Id { get; set; }
        public string Nazwa { get; set; }
        public List<UserRolesDTO> Roles { get; set; }
    }
    //public class WykonczenieOpcjaDTO : StatusDTO
    //{
    //    public int Id { get; set; }
    //    public string Nazwa { get; set; }
    //    public string Uwagi { get; set; }
    //}

    public class WykonczenieGrupaDTO : StatusDTO
    {
        public int WykonczenieGrupaId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
    }

    public class KontrahentStartDTO : StatusDTO
    {
        public int KontrahentId { get; set; }
        public string Nazwa { get; set; }
        public string Nip { get; set; }
        public string Skrot { get; set; }
    }

    public class KontrahentSmallList
    {

    }

    public class KontrahentDTO : KontrahentStartDTO
    {

        public bool CzyDealerzy { get; set; }
        public bool CzyDostawca { get; set; }
        public bool CzyOdbiorca { get; set; }
        public int TypKontrahenta { get; set; }
        public string Imie { get; set; }
        public KontrahentPlatnoscDTO KontrahentPlatnosc { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string KodKraju { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Ulica { get; set; }
        public string UlicaNr { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WWW { get; set; }
        public string KontoBankowe { get; set; }
        public string KontoBankoweSwift { get; set; }
        public string KontoBankowe2 { get; set; }
        public string KontoBankowe2Swift { get; set; }

        public ICollection<KontrahentDealerFullDTO> Dealer { get; set; }
    }



    //public class KontrahentInfoDTO : KontrahentStartDTO
    //{
    //    public string KontoBankowe { get; set; }
    //    public string KontoBankowe2 { get; set; }
    //    public string Adres { get; set; }
    //}

    public class KontrahentInfoDTO {
        public KontrahentInfoDTO()
        {
            this.Kontrahent = new Kontrahent();
        }

        [JsonIgnore]
        public Kontrahent Kontrahent { get; set; }
        public string Adres { get {
                return $"({this.Kontrahent.KodKraju}) {this.Kontrahent.KodPocztowy} {this.Kontrahent.Miejscowosc}, {this.Kontrahent.Ulica} {this.Kontrahent.UlicaNr}";
            } }

        public string KontoBankoweSwift { get {
                return String.IsNullOrEmpty(this.Kontrahent.KontoBankoweSwift) ? null : this.Kontrahent.KontoBankoweSwift;
            } }
        public string KontoBankowe { get {
                //var swift = String.IsNullOrEmpty(this.Kontrahent.KontoBankoweSwift) ? null : $"SWIFT:{this.Kontrahent.KontoBankoweSwift}, ";
                return string.IsNullOrWhiteSpace(this.Kontrahent.KontoBankowe) ? null : $"{this.Kontrahent.KontoBankowe}";
            } }
        public int KontrahentId { get; set; }

        public string KontoBankowe2Swift
        {
            get
            {
                return String.IsNullOrEmpty(this.Kontrahent.KontoBankowe2Swift) ? null : this.Kontrahent.KontoBankowe2Swift;
            }
        }
        public string KontoBankowe2 { get {
                //var swift = String.IsNullOrEmpty(this.Kontrahent.KontoBankowe2Swift) ? null : $"SWIFT:{this.Kontrahent.KontoBankowe2Swift}, ";
                return string.IsNullOrWhiteSpace(this.Kontrahent.KontoBankowe2) ? null : $"{this.Kontrahent.KontoBankowe2}";
            } }
        public string Nazwa { get {
                return string.IsNullOrWhiteSpace(this.Kontrahent.Nazwa) ? this.Kontrahent.Imie + " " + this.Kontrahent.Nazwisko : this.Kontrahent.Nazwa;
            }
        }
        public string NIP { get {
                return string.IsNullOrWhiteSpace(this.Kontrahent.NIP) ? this.Kontrahent.Pesel : this.Kontrahent.NIP;
            } }
        public string Skrot { get {
                return string.IsNullOrWhiteSpace(this.Kontrahent.Skrot) ? null : this.Kontrahent.Skrot;
            } }
    }


    public class PlatnoscPrzypomnienieWalutaRaport
    {
        public WalutaDTO Waluta { get; set; }
        public double Kwota { get; set; }
    }

    public class PlatnoscPrzypomnienieDTO
    {
        public DateTime Data { get; set; }
        public List<PlatnoscPrzypomnienieWalutaRaport> PlatnoscPrzypomnienieWalutaRaport { get {
                //                var result = new List<PlatnoscPrzypomnienieWalutaRaport>();

                return Platnosci.GroupBy(g => g.Waluta.WalutaId).Select(s => new PlatnoscPrzypomnienieWalutaRaport() {
                    Waluta = s.FirstOrDefault().Waluta,
                    Kwota = s.Sum(sum => sum.Kwota)
                }).ToList();


            } }
        public List<PlatnoscPrzypomnienieCardDTO> Platnosci { get; set; }

    }


    public class PlatnoscPrzypomnienieCardDTO {
        public int PlatnoscPrzypomnienieId { get; set; }
        public KontrahentInfoDTO Kontrahent { get; set; }
        //        public KontrahentDostawcaDTO Kontrahent { get; set; }
        public DateTime TerminPlatnosci { get; set; }
        public string FakturaNr { get; set; }
        public int? FakturaId { get; set; }
        public double Kwota { get; set; }
        public string Uwagi { get; set; }
        public bool IsDone { get; set; }
        public string DoneBy { get; set; }
        public DateTime? DataZaplaty { get; set; }
        public WalutaDTO Waluta { get; set; }
    }

    public class MaterialGrupaKontrahentDTO
    {
        public int MaterialGrupaKontrahentId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
    }

    public class MaterialDTO : StatusDTO
    {
        public int MaterialId { get; set; }
        public bool CzyUtrudnienie { get; set; }
        public string Nazwa { get; set; }
        public double SzerokoscBelki { get; set; }
        public string Uwagi { get; set; }
        public MaterialGrupaKontrahentDTO MaterialGrupaKontrahent { get; set; }
    }

    public class MaterialCenyStatsDTO : MaterialDTO
    {
        public StatystykiDTO Statystyki { get; set; }
    }


    public class NazwaKombinacjiDTO : StatusDTO
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
    }



    public class NormaDTO : StatusDTO
    {
        public int NormaId { get; set; }
        public bool CzyAktywna { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public ICollection<KombinacjaDTO> Kombinacje { get; set; }
    }


    public class KalendarzDniRoboczychDTO : StatusDTO
    {
        public int KalendarzDniRoboczychId { get; set; }
        public DateTime DzienRoboczy { get; set; }
        public ICollection<KalendarzDniRoboczychDzialProdDTO> ProdukcjaDzial { get; set; }
        public string Uwagi { get; set; }
    }

    public class KalendarzDniRoboczychDzialProdDTO : StatusDTO
    {
        public KalendarzDniRoboczychDzialProdDTO()
        {
            CzasPracyZakres = new HashSet<KalendarzDniRoboczychZakresDTO>();
            PlanningZamowienieKombiInfo = new List<Pomocne.PlanningExt.PlanningZamowienieKombiInfo>();
        }

        public int KalendarzDniRoboczychDzialProdId { get; set; }
        public string CzasPracyDuration { get; set; }
        public DateTime CzasPracyEnd { get; set; }
        public DateTime CzasPracyStart { get; set; }
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public ICollection<KalendarzDniRoboczychZakresDTO> CzasPracyZakres { get; set; }
        public List<PlanningZamowienieKombiInfo> PlanningZamowienieKombiInfo { get; set; }
    }


    public class KalendarzDniRoboczychZakresDTO : StatusDTO
    {
        public KalendarzDniRoboczychZakresDTO()
        {
            Sklad = new List<PlanningGrupaRoboczaSkladDTO>();
        }
        public int KalendarzDniRoboczychZakresId { get; set; }
        public string CzasDuration { get; set; }
        public DateTime CzasEnd { get; set; }
        public DateTime CzasStart { get; set; }
        public List<PlanningGrupaRoboczaSkladDTO> Sklad { get; set; }
        public string Uwagi { get; set; }
    }


    public class KalendarzDniRoboczychSzablonDTO : StatusDTO
    {
        public int KalendarzDniRoboczychSzablonId { get; set; }
        public string Nazwa { get; set; }
        public KalendarzDniRoboczychDzialProdDTO DzialProdukcyjny { get; set; }
    }

    public class KombinacjaDTO : StatusDTO
    {
        public int KombinacjaId { get; set; }
        public NazwaKombinacjiDTO NazwaKombinacji { get; set; }
        public double? Kubatura { get; set; }
        public int? Glebokosc { get; set; }
        public int? IloscPoduszekOparciowych { get; set; }
        public int? IloscPoduszekSiedzeniowych { get; set; }
        public int? Szerokosc { get; set; }
        public string Uwagi { get; set; }
        public int? Wysokosc { get; set; }
        public double? Waga { get; set; }
        public double? Wartosc { get; set; }

        public ICollection<KombinacjeEtapyProdukcyjneWartoscDTO> EtapyProdukcyjne { get; set; }
        public ICollection<KombinacjaObszycieElementowDTO> KombinacjaObszycie { get; set; }
        public ICollection<KombinacjaPozycjaMagazynowaDTO> KombinacjaPozycjaMagazynowa { get; set; }
        public ICollection<KombinacjaRobociznaDTO> KombinacjaRobocizna { get; set; }
        public ICollection<WykonczenieDTO> KombinacjaWykonczenie { get; set; }
        public ICollection<WykonczenieOpcjaDTO> OpcjeWykonczenia { get; set; }
    }


    public class ObszycieDTO : StatusDTO
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
    }

    public class KombinacjaObszycieElementowDTO : StatusDTO
    {
        public int Id { get; set; }
        public string Jednostka { get; set; }
        public string Nazwa { get; set; }
        public int IdRef { get; set; }
        public double Wartosc { get; set; }
        public double Wartosc2 { get; set; }
    }


    public class KombinacjaPozycjaMagazynowaDTO : StatusDTO
    {
        public int Id { get; set; }
        public string Jednostka { get; set; }
        public string Nazwa { get; set; }
        public int IdRef { get; set; }
        public double Wartosc { get; set; }
    }

    public class KombinacjaRobociznaDTO : StatusDTO
    {
        public int KombinacjaRobociznaId { get; set; }
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public int ProdukcjaDzialId { get; set; }
        public int Wartosc { get; set; }
        public ICollection<KombinacjaRobociznaGrupaRoboczaDTO> GrupaRoboczaWybrane { get; set; }

    }

    public class KombinacjaRobociznaGrupaRoboczaDTO : StatusDTO
    {
        public int Id { get; set; }
        public RobociznaDTO Robocizna { get; set; }
        public int Wartosc { get; set; }

    }

    public class RobociznaDTO : StatusDTO {
        public int Id { get; set; }
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
    }

    public class WykonczenieBasicDTO : StatusDTO
    {
        public int WykonczenieId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public int WykonczenieGrupaRefId { get; set; }
    }

    public class KombinacjaWykonczenieDTO:WykonczenieBasicDTO
    {
        public int KombinacjaWykonczenieRefId { get; set; }
    }

    public class WykonczenieDTO : WykonczenieBasicDTO
    {
        
        public bool CzyPolitykaCenowa { get; set; }
        public byte Ilosc { get; set; }
        public int KombinacjaWykonczenieId { get; set; }
        public WykonczenieGrupaDTO WykonczenieGrupa { get; set; }
        public PolitykaCenowaDTO PolitykaCenowa { get; set; }

    }

    public class MaterialBelkaPzTkaninyNierozliczoneDTO
    {
        public string CreatedBy { get; set; }
        public bool CzyPowierzona { get; set; }
        public bool CzyZaksiegowana { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string DokumentZrodlowyNr { get; set; }
        public int PzTkaninyId { get; set; }
        public ICollection<MaterialBelkaPzTkaninyNierozliczoneBelkaDTO> MaterialBelka { get; set; }
        public string Uwagi { get; set; }

    }

    public class MaterialBelkaPzTkaninyNierozliczoneBelkaDTO
    {
        public int MaterialId { get; set; }
        public double Ilosc { get; set; }
        public MaterialCenyStatsDTO Material { get; set; }



    }

    public class MaterialBelkaRozchodInneDTO : StatusDTO
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime DataRealizacji { get; set; }
        public DateTime DataRozchodu { get; set; }
        public double Wartosc { get; set; }
        public int MaterialBelkaId { get; set; }
        public JednRozchodMagRodzaj RozchodMagRodzaj { get; set; }
        public string Uwagi { get; set; }
    }

    public class MaterialBelkaRozchodObszycieDTO : StatusDTO
    {
        public int Id { get; set; }
        public int ZamowienieObszycieId { get; set; }
        public int PlanningId { get; set; }
        public string Reference { get; set; }
        public string Commission { get; set; }
        public string Obszycie { get; set; }
        public double Wartosc { get; set; }
        public DateTime DataRealizacji { get; set; }
    }


    public class MaterialBelkaDTO : MaterialBelkaShortDTO
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool CzyAktywna { get; set; }
        public string FakturaNr { get; set; }

        public string OznaczenieWewnetrzne { get; set; }
        public double StanPlanning { get; set; }
        public double StanPoczatkowy { get; set; }
        public double StanRzeczywisty { get; set; }

        public ICollection<MaterialBelkaRozchodInneDTO> RozchodInne { get; set; }


    }

    public class MaterialBelkaShortDTO : StatusDTO
    {
        public int Id { get; set; }
        public DateTime DataPrzyjecia { get; set; }
//        public Material MaterialSource { get; set; }
        public MaterialDTO Material { get; set; }
        public string Nazwa { get; set; }
            //{ get {
            //    //                if (Material == null) return "";
            //    string uwagi = string.IsNullOrEmpty(this.MaterialSource.Uwagi) ? null : $" ({MaterialSource.Uwagi})";
            //    string czyPowierzona = this.MaterialSource.CzyUtrudnienie ? $", powierzona: TAK" : null;

            //    return $"[Id: {this.MaterialSource.MaterialId}, P: {this.DataPrzyjecia.ToShortDateString()}]{uwagi}{czyPowierzona}";
            //} }
        public double StanAktualny { get; set; }
        public string Uwagi { get; set; }
    }

    public class MaterialBelkaPzTkaninyDTO {
        public int PzTkaninyId { get; set; }
        public string CreatedBy { get; set; }
        public bool CzyPowierzona { get; set; }
        public bool CzyZaksiegowana { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string DokumentZrodlowyNr { get; set; }
        public int? FakturaRefId { get; set; }
        public string Uwagi { get; set; }
        public ICollection<MaterialBelkaDTO> MaterialBelka { get; set; }

    }



    public class KombinacjeEtapyProdukcyjneWartoscDTO : StatusDTO
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int KombinacjaEtapyProdukcyjneId { get; set; }
    }

    public class ZamowienieNormaDTO : StatusDTO
    {
        public ZamowienieNormaDTO()
        {
            this.Kombinacje = new List<ZamowienieNormaKombinacjaDTO>();
        }
        public int NormaId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public List<ZamowienieNormaKombinacjaDTO> Kombinacje { get; set; }
    }

    public class ZamowienieNormaKombinacjaDTO : StatusDTO
    {
        public ZamowienieNormaKombinacjaDTO()
        {
            this.KombinacjaObszycie = new List<ZamowienieKombiObszycieDTO>();
            this.KombinacjaWykonczenie = new List<ZamowienieKombiWykonczenieDTO>();
        }

        public int ZamowienieKombiId { get; set; }
        public int KombinacjaId { get; set; }
        public NazwaKombinacjiDTO NazwaKombinacji { get; set; }
        public List<ZamowienieKombiObszycieDTO> KombinacjaObszycie { get; set; }
        public List<ZamowienieKombiWykonczenieDTO> KombinacjaWykonczenie { get; set; }


    }

    public class ZamowienieKombiWykonczenieDTO : StatusDTO
    {
        public ZamowienieKombiWykonczenieDTO()
        {
            WykonczenieOpcje = new List<KombinacjaWykonczenieDTO>();
        }
        public int ZamowienieKombiWykonczenieId { get; set; }
        public int KombinacjaWykonczenieRefId { get; set; }
        public int WykonczenieRefId { get; set; }
        public WykonczenieGrupa WykonczenieGrupa { get; set; }
        public List<KombinacjaWykonczenieDTO> WykonczenieOpcje { get; set; }

    }

    //public class ZamowienieKombiObszycieDTO : KombinacjaObszycieElementowDTO
    //{
    //    public Material Material { get; set; }
    //    public string Uwagi { get; set; }
    //}

    public class ZamowienieKombiObszycieDTO : StatusDTO
    {
        public int ZamowienieKombiObszycieId { get; set; }
        public int KombinacjaObszycieRefId { get; set; }
        public Material Material { get; set; }
        public string ObszycieNazwa { get; set; }
        public int ObszycieRefId { get; set; }
        public string Uwagi { get; set; }
    }


    public class WykonczenieOpcjaDTO
    {
        public int WykonczenieOpcjaId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public bool Wybrane { get; set; }
    }


    public class MagPozycjaMagazynowaDTO : StatusDTO
    {
        public int PozycjaMagazynowaId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public string Jednostka { get; set; }
        public StatystykiDTO Statystyki { get; set; }
        public PodatekStawkaDTO VatZakupu { get; set; }
    }

    public class MagPozycjaMagazynowaStanShortDTO
    {
        public string GrupaZakladowa { get; set; }
        public string Jednostka { get; set; }
        public string Nazwa { get; set; }
        public int PozycjaMagazynowaId { get; set; }
        public double RazemRozchodInne { get; set; }
        public double StanAktualny { get; set; }
        public double StanRzeczywisty { get; set; }
        public string Uwagi { get; set; }

    }

    public class MagPozycjaMagazynowaFullDTO : MagPozycjaMagazynowaDTO
    {
        public bool CzyPotwierdzone { get; set; }
        public string KodKreskowy { get; set; }
        public int TypTowaru { get; set; }

        public JednGrupaZakladowa GrupaZakladowa { get; set; }
        public JednJednostkaMiary JednostkaMiary { get; set; }
        public JednMarzaZakladowa MarzaZakladowa { get; set; }

        public double? StanMinAlarm { get; set; }
        public JednPodatekStawka VatSprzedazy { get; set; }
        public JednPodatekStawka VatZakupu { get; set; }
        public ICollection<MagPozycjaMagazynowaRozchodInneDTO> RozchodInne { get; set; }
        public ICollection<MagPozycjaMagazynowaZakupyDTO> Zakupy { get; set; }
        public ICollection<MagPozycjaMagazynowaPrzyjecieZewnetrzneDTO> PrzyjecieZewnetrzne { get; set; }
    }


    public class MagPozycjaMagazynowaPrzyjecieZewnetrzneDTO
    {
        public int PzId { get; set; }
        public string DokumentZrodlowyNr { get; set; }
        public bool CzyKorekta { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DataWplywu { get; set; }
        public double Ilosc { get; set; }
        public KontrahentInfoDTO Kontrahent { get; set; }
        public string Uwagi { get; set; }

    }


    public class MagPozycjaMagazynowaZakupyDTO
    {
        public double Cena { get; set; }
        public DateTime DataSprzedazy { get; set; }
        public string FakturaNr { get; set; }
        public int FinFakturaZakupuId { get; set; }

        public double Ilosc { get; set; }

        public string Kontrahent { get; set; }
        public double Wartosc { get; set; }
    }


    public class MagPozycjaMagazynowaRozchodInneDTO : StatusDTO
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DataRozchodu { get; set; }
        public JednRozchodMagRodzaj RozchodMagRodzaj { get; set; }
        public string Uwagi { get; set; }
        public double Wartosc { get; set; }
    }

    public class MagPozycjaMagazynowaFullCennikDTO : MagPozycjaMagazynowaFullDTO
    {
        public MagPozycjaMagazynowaFullCennikDTO()
        {
            this.WydanieZewnetrzne = new List<MagPozycjaMagazynowaWydanieZewnetrzneDTO>();
        }
        public StatystykiDTO Statystyki { get; set; }
        public MagPozycjaMagazynowaStanDTO Stan { get; set; }
        public List<MagPozycjaMagazynowaWydanieZewnetrzneDTO> WydanieZewnetrzne { get; set; }
    }

    public class MagPozycjaMagazynowaWydanieZewnetrzneDTO
    {
        public int MagWzId { get; set; }
        public DateTime DataWystawienia { get; set; }
        public double Ilosc { get; set; }
        public KontrahentInfoDTO Kontrahent { get; set; }
        public string NumerDokumentu { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Uwagi { get; set; }

    }

    public class MagPozycjaMagazynowaStanDTO
    {
        public double RazemPz { get; set; }
        public double RazemRozchodInne { get; set; }
        public double RazemWz { get; set; }
        public double StanRzeczywisty { get; set; }
        public double StanAktualny { get; set; }
    }


    public class StatystykiDTO
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Avg { get; set; }
        public int Count { get; set; }
        public MagPozOstatniDTO Ostatni { get; set; }

    }
    public class StatystykiBoxDTO
    {
        public int UniqueKeyId { get; set; }
        public StatystykiDTO Statystyki { get; set; }
    }


    public class MagPozOstatniDTO
    {
        public DateTime DataOstatniegoZakupu { get; set; }
        public double Cena { get; set; }
        public string Kontrahent { get; set; }
    }


    public class ZamowienieDTO : StatusDTO
    {
        public int ZamowienieId { get; set; }
        public string Commission { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime DataZamowienia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public KontrahentDealerZamowienieDTO Dealer { get; set; }
        public KontrahentDealerZamowienieDTO DealerDostawa { get; set; }
        public int Ilosc { get; set; }
        public ICollection<ZamowienieNormaKombinacjaDTO> Kombinacje { get; set; }
        public List<string> KombinacjeRaport { get {
                return StringHelpful.StringListGroup(Kombinacje.Select(s => s.NazwaKombinacji.Nazwa).ToList());
            } }
        public KontrahentStartDTO Kontrahent { get; set; }
        public ZamowienieNormaDTO Norma { get; set; }
        public string Reference { get; set; }
        public bool RequireDeliver { get; set; }
        public string Uwagi { get; set; }
        public string ZamowienieNr { get; set; }
    }





    public class ZamowienieRaportMaterialDTO : StatusDTO
    {
        public Material Material { get; set; }
        public int ObszycieIlosc { get; set; }
        public ICollection<MaterialBelkaShortDTO> MaterialBelkaDost { get; set; }
        public ICollection<ZamowienieRaportObszycieWynikDTO> Obszycie { get; set; }
        public ProstokatParent Wynik { get; set; }
        public ICollection<ZuzycieMaterialGrupaDTO> PlanningMaterialBelka { get; set; }
    }

    public class ZamowienieRaportObszycieWynikDTO
    {
        public int ObszycieId { get; set; }
        public string Nazwa { get; set; }
        public double Dlugosc { get; set; }
        public double Szerokosc { get; set; }
        public string Uwagi { get; set; }
    }

    public class ZamowienieRaportObszycieDTO
    {
        public ProstokatBaseClass ProstokatBaza { get; set; }
        public int[] ZamowienieIdLista { get; set; }
    }




    public class PlanningDzienRoboczyDTO
    {
        public int ZamowienieRefId { get; set; }
        public int ZamKombiRefId { get; set; }
        public int KombinacjaRefId { get; set; }
        public string Nazwa { get; set; }
        public PlanningDzienRoboczyCzasPracyDTO CzasPracy { get; set; }
    }

    public class PlanningDzienRoboczyExtDTO : PlanningDzienRoboczyDTO
    {
        public int RazemCzas { get; set; }

    }

    public class PlanningDzienRoboczyCzasPracyDTO
    {
        public PlanningDzienRoboczyCzasPracyDTO()
        {
            GrupaRobocza = new List<PlanningDzienRoboczyGrupaRoboczaDTO>();
        }
        public int DzialProdukcyjnyRefId { get; set; }
        public string DzialProdukcyjnyNazwa { get; internal set; }
        public List<PlanningDzienRoboczyGrupaRoboczaDTO> GrupaRobocza { get; set; }
        public int GrupaRoboczaUniqueId { get; set; }
        public int Wartosc { get; set; }
    }

    public class PlanningDzienRoboczyGrupaRoboczaDTO
    {
        public int RobociznaId { get; set; }
        public string Nazwa { get; set; }
        public int Wartosc { get; set; }
    }

    public class PlanningDzienRoboczyInputDTO
    {
        public int[] ZamowienieListaId { get; set; }
    }

    public class PlanningDzienRoboczyEtapInputDTO
    {
        public PlanningDzienRoboczyEtapInputDTO()
        {
            ElementyDoZaplanowania = new List<PlanningDzienRoboczyDTO>();
            ProdukcjaDzialSklad = new List<PlanningGrupaRoboczaSkladDTO>();
            Raport = new List<PlanningDzienRoboczyRaportDTO>();
        }

        public int DzialProdukcyjnyRefId { get; set; }
        public int DzienRoboczyRefId { get; set; }
        public PlanningDzienRoboczyRaportDTO KolejnoscObj { get; set; }
        public List<PlanningDzienRoboczyDTO> ElementyDoZaplanowania { get; set; }
        public List<PlanningGrupaRoboczaSkladDTO> ProdukcjaDzialSklad { get; set; }
        public List<PlanningDzienRoboczyRaportDTO> Raport { get; set; }


    }

    public class PlanningDzienRoboczyRaportDTO
    {
        public PlanningDzienRoboczyRaportDTO()
        {
            GrupaRobocza = new List<PlanningDzienRoboczyGrupaRoboczaDTO>();
        }
        public int CzasRazem { get; set; }
        public List<PlanningDzienRoboczyGrupaRoboczaDTO> GrupaRobocza { get; set; }
        public int Ilosc { get; set; }
        public int KombinacjaRefId { get; set; }
        public string Nazwa { get; set; }
    }


    public class PlanningElementResultDTO
    {
        public PlanningElementResultDTO()
        {
            this.GrupaRoboczaStrata = new List<PlanningDzienRoboczyGrupaRoboczaDTO>();
        }
        public PlanningDzienRoboczyDTO Element { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<PlanningDzienRoboczyGrupaRoboczaDTO> GrupaRoboczaStrata { get; set; }
    }

    public class PlanningEtapResultDTO
    {
        public PlanningEtapResultDTO()
        {
            BrakCzasu = new List<PlanningDzienRoboczyDTO>();
            BrakLudzi = new List<PlanningDzienRoboczyDTO>();
            ResztaProces = new List<PlanningDzienRoboczyDTO>();
            Result = new List<PlanningElementResultDTO>();
            Reszta = new List<PlanningDzienRoboczyDTO>();
        }
        public int EtapId { get; set; }
        public List<PlanningDzienRoboczyDTO> BrakCzasu { get; set; }
        public List<PlanningDzienRoboczyDTO> BrakLudzi { get; set; }
        public bool CzyOstatniEtap { get; set; }
        public PlanningEtapResultRaport Raport { get; set; }
        public List<PlanningDzienRoboczyDTO> ResztaProces { get; set; }
        public List<PlanningElementResultDTO> Result { get; set; }
        public List<PlanningDzienRoboczyDTO> Reszta { get; set; }

    }


    public class PlanningEtapResultRaport
    {
        public PlanningEtapResultRaport()
        {
            BrakCzasu = new List<RaportNazw>();
            BrakLudzi = new List<RaportNazw>();
            ElementyDoZaplanowania = new List<RaportNazw>();
            SkladStrata = new List<PlanningGrupaRoboczaSkladDTO>();
        }
        public int EtapId { get; set; }
        public List<RaportNazw> BrakCzasu { get; set; }
        public List<RaportNazw> BrakLudzi { get; set; }
        public List<RaportNazw> ElementyDoZaplanowania { get; set; }
        public List<PlanningGrupaRoboczaSkladDTO> SkladStrata { get; set; }
    }


    public class PlanningEtapDTO
    {
        public PlanningEtapDTO()
        {
            Etap = new List<PlanningEtapResultDTO>();
        }
        public List<PlanningEtapResultDTO> Etap { get; set; }
        public PlanningEtapResultRaport Raport { get; set; }
    }

    public class PlanningGrupaRoboczaSkladDTO : RobociznaDTO
    {
        public int PlanningGrupaRoboczaSkladId { get; set; }
        public int Ilosc { get; set; }
        public string StrataRh { get; set; }
    }


    public class ZamowienieInfoDTO
    {
        public int ZamowienieId { get; set; }
        public string Commission { get; set; }
        public string CreatedBy { get; set; }
        public string Dealer { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public DateTime DataZamowienia { get; set; }
        public ICollection<string> ZamowienieKombi { get; set; }
        public string Kontrahent { get; set; }
        public string Reference { get; set; }
        public bool RequireDeliver { get; set; }
        public string Uwagi { get; set; }
        public string ZamowienieNr { get; set; }
    }

    public class ZamowienieKombiDTO
    {
        public int ZamowienieKombiId { get; set; }
        public string NazwaKombinacji { get; set; }
        public int KombinacjaRefId { get; set; }
        public double Wartosc { get; set; }
        public double Waga { get; set; }
    }

    public class ZamowienieKombiInfoDTO
    {
        public ZamowienieKombiInfoDTO()
        {
            ZamowienieKombi = new List<ElementDoZaplanowania>();
        }
        public List<ElementDoZaplanowania> ZamowienieKombi { get; set; }
        public string ZamowieniaKombiList {
            get {
                return String.Join("", this.ZamowienieKombi.OrderBy(o=>o.ZamowienieKombiId).Select(s=>s.Nazwa).ToList());
            }
        }
        public string ZamowieniaKombiRaport
        {
            get
            {
                return Pomocne.ZamowieniaHelpful.ZamowienieKombinacjeNazwa(this.ZamowienieKombi.Select(s => s.Nazwa).ToList());
            }
        }
        public List<int> ZamowienieKombiIds
        {
            get
            {
                return ZamowienieKombi.Select(s => s.ZamowienieKombiId).ToList();
            }
        }
    }


    public class PlanningMaterialDTO : StatusDTO
    {
        public int PlanningMaterialId { get; set; }
        public MaterialDTO Material { get; set; }
        public ICollection<PlanningMaterialBelkaDTO> PlanningMaterialBelka { get; set; }
    }

    public class PlanningMaterialBelkaDTO : StatusDTO
    {
        public int PlanningMaterialBelkaId { get; set; }
        public ICollection<PlanningMaterialBelkaObszycieDTO> ListaObszyc { get; set; }
        public MaterialBelkaShortDTO MaterialBelka { get; set; }
        public double ZuzycieWartosc { get; set; }

    }

    public class PlanningMaterialBelkaObszycieDTO : StatusDTO
    {
        public int Id { get; set; }
        public double Dlugosc { get; set; }
        public string Name { get; set; }
        public double Szerokosc { get; set; }

    }


    public class MagPZDTO : StatusDTO
    {
        public int PzId { get; set; }

        public string CreatedBy { get; set; }
        public bool CzyKorekta { get; set; }
        public bool CzyZaksiegowana { get; set; }
        public DateTime DataWplywu { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string DokumentZrodlowyNr { get; set; }

        public DokumentTypDTO DokumentTyp { get; set; }
        public int? FakturaZakupuRefId { get; set; }

        public Object FakturaZakupu { get; set; }

        public KontrahentInfoDTO Kontrahent { get; set; }
        public PzKorektaDTO Korekta { get; set; }

        public ICollection<PzKorektaDTO> PzKorekta { get; set; }
        public ICollection<PZPozycjaDTO> PzPozycja { get; set; }

        public string Uwagi { get; set; }
    }


    public class PzKorektaDTO : StatusDTO
    {
        public int PzKorektaId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DataWplywu { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string DokumentZrodlowyNr { get; set; }
        public DokumentTypDTO DokumentTyp { get; set; }
        public KontrahentInfoDTO Kontrahent { get; set; }
        public string Uwagi { get; set; }
        public ICollection<PZPozycjaDTO> PzPozycja { get; set; }
    }


    public class PlatnoscRodzajDTO
    {
        public int JednPlatnoscRodzajId { get; set; }
        public string Nazwa { get; set; }
        public bool CzyDni { get; set; }
        public bool CzyUwagi { get; set; }
    }

    public class PlatnoscRodzajInfoDTO
    {
        public JednPlatnoscRodzaj PlatnoscRodzaj { get; set; }
        public string Info {
            get {

                return "";
            }}

    }

    public class DateRangeDTO
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

    }

    public class DealerInfo {
        [JsonIgnore]
        public Kontrahent Kontrahent { get; set; }
        public string KontrahentShort
        {
            get
            {
                return DTOHelpful.KontrahentInfo(Kontrahent);
            }
        }
        [JsonIgnore]
        public KontrahentDealer Dealer { get; set; }
        public string DealerShort
        {
            get
            {
                return DTOHelpful.DealerInfo(Dealer);
            }
        }
        [JsonIgnore]
        public KontrahentDealer DealerDostawa { get; set; }
        public string DealerDostawaShort
        {
            get
            {
                return DTOHelpful.DealerInfo(DealerDostawa);
            }
        }
    }

    public class DokumentTypDTO
    {
        public int DokumentTypId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
    }

    public class ProdukcjaBrygadzistaZaplanowaneInputDTO
    {
        public DateTime DzienRoboczy { get; set; }
        public string UserName { get; set; }
    }

    public class ProdukcjaBrygadzistaZaplanowaneDTO
    {
        public ProdukcjaBrygadzistaZaplanowaneDTO()
        {
            PlanningZamowienieKombiInfo = new List<Pomocne.PlanningExt.PlanningZamowienieKombiInfo>();
        }
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public List<PlanningZamowienieKombiInfo> PlanningZamowienieKombiInfo { get; set; }
    }


    public class ProdukcjaDzialDTO
    {
        public ProdukcjaDzialDTO()
        {
            NadrzednyNazwaLista = new List<string>();
        }
        public int ProdukcjaDzialId { get; set; }
        public bool CzyTkaninaBelka { get; set; }
        public bool CzyPozycjaMagazynowa { get; set; }
        public string NadrzednyIds { get; set; }
        public List<int> NadrzednyIdsLista { get {
                var result = new List<int>();
                if (NadrzednyIds == null) return result;

                string baseString = NadrzednyIds.Trim();
                if (!String.IsNullOrEmpty(baseString)) {
                    int value;
                    string[] ids = baseString.Split(',');
                    foreach (var item in ids)
                    {
                        if (int.TryParse(item, out value)) {
                            result.Add(value);
                        }
                    }
                }
                return result;
            } }
        public List<string> NadrzednyNazwaLista { get; set; }
        public ICollection<PlanningGrupaRoboczaSkladDTO> GrupaRobocza { get; set; }
        public string Nazwa { get; set; }
        public int PoziomProdukcji { get; set; }
        public string Uwagi { get; set; }
    }

    public class ProdukcjaDzialByPoziomDTO
    {
        public int PoziomProdukcji { get; set; }
        public List<ProdukcjaDzialDTO> ProdukcjaDzial { get; set; }
        public string Dzialy { get {
                string result = $"Poziom {this.PoziomProdukcji} ";
                if (this.ProdukcjaDzial.Count > 0)
                {
                    result = result.Trim() + ", [";
                    for (int i = 0; i < this.ProdukcjaDzial.Count; i++)
                    {
                        var dzial = this.ProdukcjaDzial[i].Nazwa;
                        if (i < this.ProdukcjaDzial.Count - 1)
                        {
                            result += dzial + ", ";
                        }
                        else {
                            result += dzial + "]";
                        }
                    }

                }

                return result;
            } }

    }

    public class PZPozycjaDTO
    {
        public int MagPzPozycjaId { get; set; }
        public double Ilosc { get; set; }
        public MagPozycjaMagazynowaDTO PozycjaMagazynowa { get; set; }
    }

    public class FakturaZakupuDTO : StatusDTO
    {
        public FakturaZakupuDTO()
        {
            PlatnoscPrzypomnienie = new PlatnoscPrzypomnienieCardDTO();
        }
        public int FakturaZakupuId { get; set; }
        public bool CzyEuro { get; set; }
        public bool CzyPrzypomnieniePlatnosc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime DataSprzedazy { get; set; }
        public DateTime DataWplywu { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string FakturaNr { get; set; }
        public ICollection<FakturaPodsumowanieWartosciDTO> FakturaPodsumowanieWartosci { get; set; }
        public ICollection<FakturaPozycjeMagDTO> FakturaPozycjeMag { get; set; }
        public ICollection<FakturaPozycjeTkaninyDTO> FakturaPozycjeTkaniny { get; set; }
        public KontrahentInfoDTO Kontrahent { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public PlatnoscPrzypomnienieCardDTO PlatnoscPrzypomnienie { get; set; }
        public string PlatnoscPrzypomnienieUwagi { get; set; }
        public PlatnoscRodzajDTO PlatnoscRodzaj { get; set; }
        public int? PlatnoscRodzajIleDni { get; set; }
        public string PlatnoscRodzajUwagi { get; set; }
        public ICollection<MagPZDTO> PzRozliczoneMag { get; set; }
        public ICollection<MaterialBelkaPzTkaninyDTO> PzRozliczoneTkaniny { get; set; }
        public double RazemBrutto { get; set; }
        public double RazemNetto { get; set; }
        public double RazemVat { get; set; }
        public string Uwagi { get; set; }
        public WalutaDTO Waluta { get; set; }


    }

    public class FakturaPodsumowanieWartosciDTO : StatusDTO
    {
        public int FakturaPodsumowanieWartosciId { get; set; }
        public int FakturaZakupuRefId { get; set; }
        public PodatekStawkaDTO PodatekStawka { get; set; }
        public double? WartoscBrutto { get; set; }
        public double? WartoscNetto { get; set; }
        public double? WartoscVat { get; set; }
    }

    public class PodatekStawkaDTO
    {
        public int JednPodatekStawkaId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public double Wartosc { get; set; }


    }

    public class FakturaPozycjeMagDTO : StatusDTO
    {
        public int FakturaPozycjeMagId { get; set; }
        public double Cena { get; set; }
        public double Ilosc { get; set; }
        public string Jednostka { get; set; }
        public string Nazwa { get; set; }
        public JednPodatekStawka PodatekStawka { get; set; }
        public int PozycjaMagazynowaRefId { get; set; }
        public double Wartosc { get; set; }
    }

    public class FakturaPozycjeTkaninyDTO : StatusDTO
    {
        public int FakturaPozycjeTkaninyId { get; set; }
        public int MaterialId { get; set; }
        public double Cena { get; set; }
        public double Ilosc { get; set; }
        public string Jednostka { get; set; }
        public string Nazwa { get; set; }
        public JednPodatekStawka PodatekStawka { get; set; }
        public double Wartosc { get; set; }
    }


    public class PolitykaCenowaDTO : StatusDTO
    {
        public PolitykaCenowaDTO()
        {
            this.Reguly = new HashSet<PolitykaCenowaRegulaDTO>();
        }
        public int PolitykaCenowaId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public ICollection<PolitykaCenowaRegulaDTO> Reguly { get; set; }

    }

    public class PolitykaCenowaRegulaDTO : StatusDTO
    {
        public int PolitykaCenowaRegulaId { get; set; }
        public bool CzyAktywna { get; set; }
        public KontrahentInfoDTO Kontrahent { get; set; }
        public int PolitykaCenowaRefId { get; set; }
        public int TypRozliczenia { get; set; }
        public double Wartosc { get; set; }

    }

    public class KontrahentPlatnoscDTO {
        public int KontrahentPlatnoscId { get; set; }
        public int? IleDni { get; set; }
        public int KontrahentRefId { get; set; }
        public string Uwagi { get; set; }
        public double? TransportStawka { get; set; }
        public bool TransportWcenie { get; set; }
        public JednPlatnoscRodzaj PlatnoscRodzaj { get; set; }
    }

    public class UsersManagementDTO
    {
        public UsersManagementDTO()
        {
            Brygadzista = new List<BrygadzistaDTO>();
            Users = new List<UserDTO>();

        }
        public List<UserDTO> Users { get; set; }
        public List<BrygadzistaDTO> Brygadzista { get; set; }
    }



    public class WalutaDTO
    {
        public int WalutaId { get; set; }
        public string Nazwa { get; set; }
        public string Skrot { get; set; }
    }


    public class ZamowienieListaDTO
    {
        public ZamowienieListaDTO()
        {

            ZamowienieKombi = new List<ElementDoZaplanowania>();
        }
        public int ZamowienieId { get; set; }
        public bool CzyZaplanowane { get; set; }
        public string Commission { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime DataRealizacji { get; set; }
        public DateTime DataZamowienia { get; set; }
        [JsonIgnore]
        public KontrahentDealer Dealer { get; set; }
        public string DealerShort { get {
                return DTOHelpful.DealerInfo(Dealer);
            } }
        [JsonIgnore]
        public KontrahentDealer DealerDostawa { get; set; }
        public string DealerDostawaShort { get {
                return DTOHelpful.DealerInfo(DealerDostawa);
            } }
        public int Ilosc { get; set; }

        [JsonIgnore]
        public Kontrahent Kontrahent { get; set; }
        public string KontrahentShort { get {
                return DTOHelpful.KontrahentInfo(Kontrahent);
            } }
        public string Reference { get; set; }
        public bool RequireDeliver { get; set; }
        //public ZamowienieStatusDTO ZamowienieStatus {get;set;}
        public ZamowienieStatusDTO ZamowienieStatus { get; set; }
        [JsonIgnore]
        public List<ElementDoZaplanowania> ZamowienieKombi { get; set; }
        public string ZamowienieKombiNazwa { get {
                return Pomocne.ZamowieniaHelpful.ZamowienieKombinacjeNazwa(this.ZamowienieKombi.Select(s => s.Nazwa).ToList());
            } }
        public string ZamowienieKombiRaport { get {
                return String.Join("", this.ZamowienieKombiNazwa);
            } }
        public List<string> ZamowienieKombiRaportIlosc { get {
                return StringHelpful.StringListGroup(this.ZamowienieKombi.Select(s=>s.Nazwa).ToList());
            } }
        public string ZamowienieNr { get; set; }
    }





    public class ZamowienieStatusDTO
    {
        public int PoziomProdukcji { get; set; }
        public string Info
        {
            get
            {
                var procent = this.ProcentRealizacjiPoziomu.ToString("P2");
                return $"[{this.ZamowieniaWykonane}/{this.ZamowieniaCount}]";
            }
        }
        public bool PlanningInProgress { get; set; }
        public double ProcentRealizacjiPoziomu
        {
            get
            {

                return (double)this.ZamowieniaWykonane / (double)this.ZamowieniaCount;
            }
        }
        public int ZamowieniaCount { get; set; }
        public int ZamowieniaWykonane { get; set; }


    }


    public class ZuzycieMaterialGrupaDTO : StatusDTO
    {
        public int ZuzycieMaterialGrupaId { get; set; }
        public ProstokatBaseClass Baza { get; set; }
        public ICollection<ProstokatBaseClass> ListaObszyc { get; set; }
        public MaterialBelkaShortDTO MaterialBelka { get; set; }
        public string Zuzycie { get; set; }


    }









}


public static class DTOHelpful
{
    public static string DealerInfo(KontrahentDealer dealer)
    {
        if (dealer == null) return "brak danych";
        return $"{dealer.Nazwa}, ({dealer.KodKraju}) {dealer.Miejscowosc}, {dealer.Ulica} {dealer.Nr}";
    }

    public static string KontrahentInfo(Kontrahent kontrahent)
    {
        if (kontrahent == null) return "brak danych";
        string nazwa = kontrahent.Nazwa!=null ? kontrahent.Nazwa : $"{kontrahent.Nazwisko} {kontrahent.Imie}";
        return $"{nazwa}, ({kontrahent.KodKraju.ToUpper()}) {kontrahent.Miejscowosc} {kontrahent.Ulica} {kontrahent.UlicaNr}";
    }
    
}





