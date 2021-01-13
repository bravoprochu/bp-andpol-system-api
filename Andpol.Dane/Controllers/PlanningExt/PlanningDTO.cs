using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using Andpol.Dane.Pomocne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZuzycieMaterialu.Zuzycie;

namespace Andpol.Dane.Pomocne.PlanningExt
{


    public class PlanningDTO
    {
        public PlanningDTO()
        {
            this.PlanningKalendarzZakres = new HashSet<PlanningZakresDniDTO>();
            this.PozycjaMagazynowa = new HashSet<PlanningPozycjaMagazynowaDTO>();
            this.TkaninaBelka = new HashSet<PlanningTkaninaBelkaGrupaDTO>();
        }

        public int PlanningId { get; set; }
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public ICollection<PlanningZakresDniDTO> PlanningKalendarzZakres { get; set; }
        public ICollection<PlanningPozycjaMagazynowaDTO> PozycjaMagazynowa { get; set; }
        public ICollection<PlanningTkaninaBelkaGrupaDTO> TkaninaBelka { get; set; }
    }


    public class PlanningListDTO:PlanningDTO
    {
        public List<PlanningListDzienRoboczyDTO> PlanningDzienRoboczy { get; set; }
        public DateRangeDTO PlanningDuration { get {
                if (PlanningDzienRoboczy.Any())
                {
                    return new DateRangeDTO
                    {
                        DateStart = this.PlanningDzienRoboczy.Min(m => m.DzienRoboczy),
                        DateEnd = this.PlanningDzienRoboczy.Max(m => m.DzienRoboczy)
                    };
                }
                else {
                    return new DateRangeDTO();
                }
            } }
        public List<string> ElementyZaplanowane { get {
                var elementyZaplanowaneRazem = this.PlanningDzienRoboczy.SelectMany(sm => sm.ElementyZaplanowane).ToList();
                if (elementyZaplanowaneRazem.Any())
                {
                    return StringHelpful.StringListGroup(elementyZaplanowaneRazem.Select(s => s.Nazwa).ToList());
                }
                else {
                    return new List<string>();
                }
            }}

    }

    public class PlanningListDzienRoboczyDTO
    {
        public PlanningListDzienRoboczyDTO()
        {
            this.ElementyZaplanowane = new List<PlanningZamowienieKombiInfo>();
        }

        public DateTime DzienRoboczy { get; set; }
        public List<PlanningZamowienieKombiInfo> ElementyZaplanowane { get; set; }
    }


    public class PlanningZakresDniDTO
    {
        public PlanningZakresDniDTO()
        {
            RaportZaplanowane = new HashSet<ElementZaplanowany>();
        }

        public DateTime DzienRoboczy { get; set; }
        public int DzienRoboczyRefId { get; set; }
        public ICollection<ElementZaplanowany> RaportZaplanowane { get; set; }
    }


    public class PlanningRaportDTO
    {
        public PlanningRaportDTO()
        {
            ZamowienieKombiId = new List<int>();
        }

        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public List<int> ZamowienieKombiId { get; set; }
    }

    public class PlanningRaportPozycjeMagazynoweDTO
    {
        public int PlanningPozycjaMagazynowaId { get; set; }
        public PlanningPozycjaMagazynowaDTO PozycjeMagazynowe { get; set; }
    }


    public class PlanningPozycjaMagazynowaDTO
    {
        public int PozycjaMagazynowaId { get; set; }
        public bool CzyStanOk { get {
                return StanAktualny >= Wartosc;
            } }
        public int KombinacjaRefId { get; set; }
        public string Jednostka { get; set; }
        public string Nazwa { get; set; }
        public double? StanAktualny { get; set; }
        public double? Wartosc { get; set; }
    }


    public class PlanningTkaninyDTO
    {
        public PlanningTkaninyDTO()
        {
            GrupyTkanin = new List<PlanningTkaninaGrupaDTO>();

        }
        public List<PlanningTkaninaGrupaDTO> GrupyTkanin { get; set; }
    }

    public class PlanningTkaninaGrupaDTO
    {
        public MaterialDTO Material { get; set; }
        public List<MaterialBelkaShortDTO> BelkiDostepne { get; set; }
        public List<PlanningTkaninaBelkaGrupaDTO> BelkiZaplanowane { get; set; }

    }

    public class PlanningTkaninaBelkaGrupaDTO
    {
        public PlanningTkaninaBelkaGrupaDTO()
        {
            PlanningMaterialBelka  = new List<PlanningTkaninaBelkaDTO>();
        }

        public Material Material { get; set; }
        public List<PlanningTkaninaBelkaDTO> PlanningMaterialBelka { get; set;}
    }

    public class PlanningTkaninaBelkaDTO
    {
        public PlanningTkaninaBelkaDTO()
        {
            ListaObszyc = new List<ProstokatBaseClass>();
        }
        public MaterialBelkaShortDTO MaterialBelka { get; set; }
        public List<ProstokatBaseClass> ListaObszyc { get; set; }
        public string Uwagi { get; set; }
        public double ZuzycieWartosc { get; set; }
    }

    public class PlanningZamowieniaBazaDTO
    {
        public int ZamowienieId { get; set; }
        public string Commission { get; set; }
        public CreatedInfoDTO  CreatedInfo { get; set; }
        public bool CzyRequireDeliver { get; set; }
        public bool CzyPlanningInProgress { get; set; }
        
        public DateTime DataRealizacji { get; set; }
        public DateTime DataZamowienia { get; set; }
        public DealerInfo DealerInfo { get; set; }
        public int Ilosc { get; set; }
        public string NormaNazwa { get; set; }
        public string Reference { get; set; }
        public string Uwagi { get; set; }
        public ZamowienieKombiInfoDTO ZamowienieKombiInfo { get; set; }
        public string ZamowienieNr { get; set; }

    }


    public class PlanningZamowienieKombiInfo:StatusDTO
    {
        public int PlanningDzienRoboczyZamowienieKombiId { get; set; }
        public bool IsDone { get; set; }
        public int KalendarzDniRoboczychDzialProdRefId { get; set; }
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public ZamowienieInfoDTO Zamowienie { get; set; }
        public string ZamowienieInfo
        {
            get
            {
                return $"ZId: {Zamowienie.ZamowienieId}, ZNr: {Zamowienie.ZamowienieNr}, C: {Zamowienie.Commission}, R: {Zamowienie.Reference}";
            }
        }
        public string Nazwa { get; set; }
    }


    public class PlanningTkaninaBelkaRaportDTO
    {
        public PlanningTkaninaBelkaRaportDTO()
        {
            ListaObszyc = new List<PlanningTkaninaBelkaRaportListaObszycDTO>();
        }
        public Double BelkaStanAktualny { get; set; }
        public Material Material { get; set; }
        public List<PlanningTkaninaBelkaRaportListaObszycDTO> ListaObszyc { get; set; }
        public int TkaninaBelkaId { get; set; }
        public double ZuzycieWartosc { get; set; }
    }


    public class PlanningTkaninaBelkaRaportListaObszycDTO:StatusDTO
    {
        public int PlanningTkaninaBelkaListaObszycId { get; set; }
        public double Dlugosc { get; set; }
        public bool IsDone { get; set; }
        public string NazwaKombinacji { get; set; }
        public string NazwaObszycia { get; set; }
        public int PlanningTkaninaBelkaRefId { get; set; }
        public double Szerokosc { get; set; }
        public string ZamowienieInfo { get; set; }
        public int ZamowienieKombiObszycieRefId { get; set; }

    }


    public class PlanningTkaninaBelkaRaportInputDTO
    {
        public DateTime DzienRoboczy { get; set; }
    }


    public class FindByDateRangeDTO:DateRangeDTO
    {
        public int Id { get; set; }
    }

    public class ElementDoZaplanowaniaGroupDTO
    {
        public ElementDoZaplanowaniaGroupDTO()
        {
            ListaElementow = new List<ElementDoZaplanowania>();
        }
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public string NazwaDzialu
        {
            get
            {
                return this.ProdukcjaDzial.Nazwa;
            }
        }
//        public int PoziomProdukcji { get; set; }
        public List<ElementDoZaplanowania> ListaElementow { get; set; }
    }


    public class PlanningZamowienieStatusPoziomProdukcjiDTO
    {
        public PlanningZamowienieStatusPoziomProdukcjiDTO()
        {
            this.ZamowienieKombiWykonanneIds = new List<int>();
        }
        public int PoziomProdukcji { get; set; }
        public List<int> ZamowienieKombiWykonanneIds { get; set; }
    }


    public class PlanningZamowienieStatusDTO
    {
        public PlanningZamowienieStatusDTO()
        {
            this.PlanningZamowieniaByProdukcjaDzialDTO = new List<PlanningZamowienieStatusPoziomProdukcjiDTO>();
            this.ZamowienieKombiIds = new List<int>();
        }
        public List<int> ZamowienieKombiIds { get; set; }
        public List<PlanningZamowienieStatusPoziomProdukcjiDTO> PlanningZamowieniaByProdukcjaDzialDTO { get; set; }
    }


}