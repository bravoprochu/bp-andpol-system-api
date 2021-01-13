using Andpol.Dane.Pomocne.NormaExt;
using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.PlanningExt
{

    public class CzasZakres
    {
        public DateTime CzasStart { get; set; }
        public DateTime CzasEnd { get; set; }
        public TimeSpan Duration
        {
            get
            {
                return CzasEnd - CzasStart;
            }
        }
    }
    public class ElementPodzielony
    {
        public string PartName { get; set; }
        public double CzescWykonania { get; set; }

    }

    public class ElementDoZaplanowania
    {
        public GrupaRoboczaDTO GrupaRobocza { get; set; }
        public int KombinacjaId { get; set; }
        public string Nazwa { get; set; }
        public int RobociznaWartosc { get; set; }
        public int ZamowienieKombiId { get; set; }
    }
    public class ElementZaplanowany
    {
        public ElementZaplanowany()
        {
            CzasZaplanowania = new CzasZakres();
            ElementBaza = new ElementDoZaplanowania();
            ElementPodzielony = new ElementPodzielony();
        }
        public bool CzyPodzielony { get; set; }
        public CzasZakres CzasZaplanowania { get; set; }
        public ElementDoZaplanowania ElementBaza { get; set; }
        public ElementPodzielony ElementPodzielony { get; set; }
        public int EtapId { get; set; }
    }

    public class PlanningKalendarzInput
    {
        public PlanningKalendarzInput()
        {
            ZamowieniaIds = new List<int>();
        }
        public List<int> ZamowieniaIds { get; set; }
        public CzasZakres DzienRoboczyZakres { get; set; }
        public ModelsDTO.ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        
    }

    public class RaportShort
    {
        public List<string> Zaplanowane { get; set; }
        public List<string> BrakCzasu { get; set; }
    }
    public class RaportByEtapDTO
    {
        public int EtapId { get; set; }
        public int IloscElementow { get; set; }
        public CzasZakres CzasZakres { get; set; }
        public List<ElementZaplanowany> ElementyZaplanowane { get; set; }
    }
    public class ZakresDTO
    {
        public ZakresDTO()
        {
            CzasZakres = new CzasZakres();
            GrupaRobocza = new GrupaRoboczaDTO();
        }
        public CzasZakres CzasZakres { get; set; }
        public int KalendarzDniRoboczychId { get; set; }
        public GrupaRoboczaDTO GrupaRobocza { get; set; }
        public int EtapId { get; set; }
    }


    public class PlanningRaportUpdateDTO
    {
        public ProdukcjaDzialDTO ProdukcjaDzial { get; set; }
        public List<PlanningRaportUpdateDzienDTO> PlanningDniRobocze { get; set; }
    }

    public class PlanningRaportUpdateDzienDTO
    {
        public List<ElementZaplanowany> RaportZaplanowane { get; set; }
        public List<RobociznaStanowiskoStrataDTO> RaportZaplanowaneStrata { get; set; }
    }


    public class PlanningRaportUpdateResultDTO
    {
        private PoligonContext db = new PoligonContext();
        public PlanningRaportUpdateResultDTO(PlanningRaportUpdateDTO raportToUpdate)
        {
            this.ElementyZaplanowaneRazem = new List<ElementZaplanowany>();

            foreach (var dzien in raportToUpdate.PlanningDniRobocze)
            {
                ElementyZaplanowaneRazem.AddRange(dzien.RaportZaplanowane);
            }
        }
        public RaportShort RaportZaplanowane { get {
                return new RaportShort
                {
                    Zaplanowane = Pomocne.StringHelpful.StringListGroup(ElementyZaplanowaneRazem.Select(s => s.ElementBaza.Nazwa).ToList())
                };
            }}

        private List<ElementZaplanowany> ElementyZaplanowaneRazem { get; set; }
        private List<PlanningPozycjaMagazynowaDTO> PozycjeMagazynowe { get {

                var kombinacjeIdsDistinct = ElementyZaplanowaneRazem.GroupBy(g => g.ElementBaza.KombinacjaId).Select(s => new {
                    Key = s.Key,
                    Count = s.Count(),
                    ElementZaplanowany = s.Select(se => se.ElementBaza).FirstOrDefault(),
                }).ToList().Select(sg => sg).ToList();

                return db.KombinacjaPozycjaMagazynowa.WhereIn(wi => wi.KombinacjaRefId, kombinacjeIdsDistinct.Select(sk => sk.Key).ToList()).Select(s => new PlanningPozycjaMagazynowaDTO()
                {

                    Jednostka = s.MagPozycjaMagazynowa.JednostkaMiary.Nazwa,
                    KombinacjaRefId = s.KombinacjaRefId,
                    Nazwa = s.MagPozycjaMagazynowa.Nazwa,
                    PozycjaMagazynowaId = s.MagPozycjaMagazynowaRefId,
                    StanAktualny = s.MagPozycjaMagazynowa.StanAktualny.Value,
                    Wartosc = s.Wartosc
                }).ToList();
            } }

        private void KombinacjaPozycjaMagazynowa(PoligonContext db)
        {

        }
    }

}