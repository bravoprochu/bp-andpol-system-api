using Andpol.Dane.Pomocne.NormaExt;
using Andpol.Dane.Entities;
using Andpol.Dane.Pomocne;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.PlanningExt
{
    public class PlanningKalendarzDzien
    {
        public PlanningKalendarzDzien(List<ZakresDTO> zakresy, List<ElementDoZaplanowania> elementyDoZaplanowania)
        {
            ElementyDoZaplanowania = new List<ElementDoZaplanowania>();
            EtapZakresy = new List<ZakresDTO>();
            RaportBrakCzasu = new List<ElementDoZaplanowania>();
            RaportEtapBledy = new List<ElementDoZaplanowania>();
            RaportErrors = new List<string>();
            Zaplanowane = new List<ElementZaplanowany>();
            Zakresy = new List<ZakresDTO>();

            ElementyDoZaplanowania = elementyDoZaplanowania;
            Zakresy = zakresy;
            SkladKalendarzDzienRoboczySkladZapisz();
            ZaplanujEtap();

        }

        private bool CzyElementFitByDuration(ElementDoZaplanowania el, ZakresDTO zakres)
        {
            return el.RobociznaWartosc <= zakres.CzasZakres.Duration.TotalMinutes;
        }
        private bool CzyElementFitByGrupaAndDurationInZakres(ElementDoZaplanowania el, List<ZakresDTO> zakresy)
        {
            int czasZakresuRazem = 0;

            foreach (var zakres in zakresy)
            {
                if (CzyElementFitByGrupaRobocza(el, zakres))
                {
                    czasZakresuRazem += (int)zakres.CzasZakres.Duration.TotalMinutes;
                }
            }

            return czasZakresuRazem >= el.RobociznaWartosc ? true: false;
        }
        private bool CzyElementFitByGrupaRobocza(ElementDoZaplanowania el, ZakresDTO zakres)
        {
            bool result = true;
            foreach (var stanowisko in el.GrupaRobocza.Stanowiska)
            {
                var stanowiskoInZakres = zakres.GrupaRobocza.Stanowiska.Where(w => w.RobociznaId == stanowisko.RobociznaId).Select(s=>s).FirstOrDefault();
                if (stanowiskoInZakres == null || stanowisko.Wartosc > stanowiskoInZakres.Wartosc) {return false; };
            }
            return result;
        }
        public DateTime DzienRoboczy { get {
                return Zakresy.FirstOrDefault().CzasZakres.CzasStart;
            } }
        public int DzienRoboczyRefId { get {
                return Zakresy.FirstOrDefault().KalendarzDniRoboczychId;
            } }
        private List<ElementDoZaplanowania> ElementyDoZaplanowania { get; set; }
        private int EtapId { get; set; }
        private List<ZakresDTO> EtapZakresy { get; set; }
        public List<ElementDoZaplanowania> RaportBrakCzasu { get; set; }
        public List<string> RaportErrors { get; set; }
        private List<ElementDoZaplanowania> RaportEtapBledy { get; set; }
        public List<ElementZaplanowany> RaportZaplanowane { get {
                return Zaplanowane.GroupBy(g => g.ElementBaza.ZamowienieKombiId).Select(s=>s.FirstOrDefault()).ToList();
            } }
        public List<RaportByEtapDTO> RaportZaplanowaneByEtap 
        {
            get {
                return this.Zaplanowane.GroupBy(g => g.EtapId).Select(s => new RaportByEtapDTO() {
                    EtapId = s.Key,
                    IloscElementow=s.Count(),
                    CzasZakres=new CzasZakres() {
                        CzasStart=s.Min(m=>m.CzasZaplanowania.CzasStart),
                        CzasEnd=s.Max(m=>m.CzasZaplanowania.CzasEnd)
                    },
                    ElementyZaplanowane = s.OrderBy(o=>o.ElementBaza.ZamowienieKombiId).ThenBy(o2=>o2.CzasZaplanowania.CzasStart).ToList()
                }).ToList();
            }
        }
        public List<RobociznaStanowiskoStrataDTO> RaportZaplanowaneStrata
        {
            get
            {
                List<RobociznaStanowiskoStrataDTO> result = new List<RobociznaStanowiskoStrataDTO>();
                var stanowiska = Zakresy.SelectMany(s => s.GrupaRobocza.Stanowiska).ToList().Where(w => w.Wartosc > 0).ToList().GroupBy(g => g.RobociznaId).Select(sg => new RobociznaStanowiskoStrataDTO() {
                    RobociznaId=sg.Key,
                    RobociznaNazwa=sg.FirstOrDefault().RobociznaNazwa,
                    Wartosc=sg.Sum(sum=>sum.Wartosc)
                }).ToList();




                var czasPrzeliczonyNaStanowisko = Zakresy.Where(w => w.CzasZakres.Duration.TotalMinutes > 0 && w.GrupaRobocza.Stanowiska.Any(a => a.Wartosc > 0) == true).Select(s => new {
                    CzasZakres=s.CzasZakres,
                    StanowiskaLista=s.GrupaRobocza.Stanowiska.Select(ss=>new RobociznaStanowiskoStrataCzasZakres()  {
                        StrataInt=ss.Wartosc*(int)s.CzasZakres.Duration.TotalMinutes,
                        Stanowisko=ss
                    }).ToList()
                }).ToList();


                var stanowiskaList = czasPrzeliczonyNaStanowisko.SelectMany(s => s.StanowiskaLista).GroupBy(g => g.Stanowisko.RobociznaId).Select(sg => new RobociznaStanowiskoStrataDTO()
                {
                    RobociznaId=sg.FirstOrDefault().Stanowisko.RobociznaId,
                    RobociznaNazwa=sg.FirstOrDefault().Stanowisko.RobociznaNazwa,
                    SkladWyjsciowy=Sklad.Stanowiska.Where(w=>w.RobociznaId==sg.FirstOrDefault().Stanowisko.RobociznaId).Select(skladwyj=>skladwyj.Wartosc).FirstOrDefault(),
                    Strata =new TimeSpan(0,sg.Sum(sum=>sum.StrataInt),0),
                }).ToList();

                foreach (var stan in stanowiskaList)
                {
                    var totHours = (int)stan.Strata.TotalHours;
                    var totMinutes = (int)stan.Strata.TotalMinutes;
                    var minutes = (int)stan.Strata.Minutes;

                    if (totMinutes > 0) {
                        stan.RoboczoGodziny = minutes > 0 ? totHours + 1 : totHours;
                    }
                    else
                    {
                        stan.RoboczoGodziny = minutes > 0 ? 1 : 0;
                    }
                    
                }

                return stanowiskaList;



            }
        }
        public RaportShort RaportShort
        {
            get {
                var zaplanowane = StringHelpful.StringListGroup(Zaplanowane.GroupBy(g => g.ElementBaza.ZamowienieKombiId).Select(s => new { Key = s.Key, Element = s.FirstOrDefault().ElementBaza }).ToList().Select(se => se.Element.Nazwa).ToList());
                var brakCzasu = StringHelpful.StringListGroup(RaportBrakCzasu.GroupBy(g => g.ZamowienieKombiId).Select(sg => new { nazwa = sg.FirstOrDefault().Nazwa }).ToList().Select(sn => sn.nazwa).ToList());

                return new RaportShort {
                    Zaplanowane=zaplanowane,
                    BrakCzasu=brakCzasu
                };

            }
        }
        private GrupaRoboczaDTO Sklad { get; set; }
        private void SkladKalendarzDzienRoboczySkladZapisz()
        {
            Sklad = Zakresy[0].GrupaRobocza;
            return;
        }
        public List<ZakresDTO> Zakresy { get; set; }
        public CzasZakres ZakresPlanninguBrutto
        {
            get
            {
                var cz = new CzasZakres();
                if (Zaplanowane.Count > 0)
                {
                    cz.CzasStart = Zaplanowane.Min(m => m.CzasZaplanowania.CzasStart);
                    cz.CzasEnd = Zaplanowane.Max(m => m.CzasZaplanowania.CzasEnd);
                }
                else {
                    RaportErrors.Add($"Brak elementów zaplanowanych [{DzienRoboczy.ToShortDateString()}], ZakresPlanninguBrutto zostaje ustawiony jako cały dzień (również strata !)");
                    cz.CzasStart = Zakresy.Min(m=>m.CzasZakres.CzasStart);
                    cz.CzasEnd = Zakresy.Max(m=>m.CzasZakres.CzasEnd);
                }
                return cz;
            }
        }
        private int ZakresPlanningCzasOverall(List<ZakresDTO> zakresy) {
            int result = 0;
            foreach (var item in zakresy)
            {
                result+=(int)item.CzasZakres.Duration.TotalMinutes;
            }
            return result;
        }
        private GrupaRoboczaDTO ZakresGrupaRoboczaPomniejsz(GrupaRoboczaDTO grupaRobocza, ElementDoZaplanowania el)
        {
            var result = new GrupaRoboczaDTO();
            result.ProdukcjaDzialId = grupaRobocza.ProdukcjaDzialId;
            result.ProdukcjaDzialNazwa = grupaRobocza.ProdukcjaDzialNazwa;

            if (grupaRobocza.Stanowiska.Count != Sklad.Stanowiska.Count)
            {
                foreach (var stanowisko in Sklad.Stanowiska)
                {
                    var found = grupaRobocza.Stanowiska.Where(w => w.RobociznaId == stanowisko.RobociznaId).Select(s => s).FirstOrDefault();
                    if (found == null)
                    {
                        grupaRobocza.Stanowiska.Add(stanowisko);
                    }
                }
            }


            if (el.Nazwa == "-2-") {
                System.Diagnostics.Debug.WriteLine("mam -2-");
            }
            foreach (var stanowisko in grupaRobocza.Stanowiska)
            {
                var stanowiskoInElement = el.GrupaRobocza.Stanowiska.Where(w => w.RobociznaId == stanowisko.RobociznaId).Select(s => s).FirstOrDefault();
                if (stanowiskoInElement != null)
                {
                    var stanowiskoToAdd = new RobociznaStanowiskoDTO();
                    stanowiskoToAdd.RobociznaId = stanowisko.RobociznaId;
                    stanowiskoToAdd.RobociznaNazwa = stanowisko.RobociznaNazwa;
                    stanowiskoToAdd.Wartosc = stanowisko.Wartosc - stanowiskoInElement.Wartosc;

                    result.Stanowiska.Add(stanowiskoToAdd);
                }
                else {
                    result.Stanowiska.Add(stanowisko);
                }

            }

            //if (result.Stanowiska.Count != Sklad.Stanowiska.Count) {
            //    foreach (var stanowiskoInSklad in Sklad.Stanowiska)
            //    {
            //        var found = result.Stanowiska.Where(w => w.RobociznaId == stanowiskoInSklad.RobociznaId).Select(s => s).FirstOrDefault();
            //        if (found == null) {
            //            result.Stanowiska.Add(stanowiskoInSklad);
            //        }
            //    }
            //}

            return result;
        }
        private void ZakresCzasPomniejszElement(ZakresDTO zakres, ElementDoZaplanowania el, ElementZaplanowany elZapl, int czasJuzZaplanowany=0)
        {
            TimeSpan czasDoZaplanowania = new TimeSpan(0, el.RobociznaWartosc - czasJuzZaplanowany, 0);

            //zaplanowany - czasZakres:
            elZapl.CzasZaplanowania.CzasStart = zakres.CzasZakres.CzasStart;
            // wartosc robocizny miesci sie w zakresie
            if (czasDoZaplanowania.TotalMinutes < zakres.CzasZakres.Duration.TotalMinutes)
            {
                elZapl.CzasZaplanowania.CzasEnd = elZapl.CzasZaplanowania.CzasStart.Add(czasDoZaplanowania);
            }
            // wartosc robocizny jest za duza na zakres (podzielony)
            else {
                elZapl.CzasZaplanowania.CzasEnd = zakres.CzasZakres.CzasEnd;
            }
            
            //nowyZakres o pomniejszonej grupie roboczej
            var zakresNew = new ZakresDTO();
            zakresNew.CzasZakres.CzasStart = elZapl.CzasZaplanowania.CzasStart;
            zakresNew.CzasZakres.CzasEnd = elZapl.CzasZaplanowania.CzasEnd;
            zakresNew.EtapId = EtapId+1;
            zakresNew.KalendarzDniRoboczychId = zakres.KalendarzDniRoboczychId;
            zakresNew.GrupaRobocza = ZakresGrupaRoboczaPomniejsz(zakres.GrupaRobocza, el);

            Zakresy.Add(zakresNew);

            //zakres pomniejszenie czasu
            zakres.CzasZakres.CzasStart = elZapl.CzasZaplanowania.CzasEnd;
            if (zakres.CzasZakres.Duration.TotalMinutes == 0) {
                Zakresy.Remove(zakres);
            }
        }

        private ZakresDTO ZakresZnajdzDostepny(ElementDoZaplanowania el)
        {
            foreach (var zakres in Zakresy.Where(w=>w.EtapId==EtapId).OrderBy(o=>o.CzasZakres.CzasStart))
            {
                if (CzyElementFitByGrupaRobocza(el, zakres)) {
                    return zakres;
                }
            }
            return null;
        }
        public List<ElementZaplanowany> Zaplanowane { get; set; }
        private void ZaplanujEtap()
        {
            while (ZaplanujEtapNext()==true)
            {
                while (ElementyDoZaplanowania.Count > 0)
                {
                    var el = ElementyDoZaplanowania.First();

                    if (CzyElementFitByGrupaAndDurationInZakres(el, Zakresy.Where(w=>w.EtapId==EtapId).ToList()))
                    {
                        var zakres = ZakresZnajdzDostepny(el);
                        if (CzyElementFitByDuration(el, zakres))
                        {
                            ZaplanujElementCaly(el, zakres);
                        }
                        else
                        {
                            ZaplanujElementPodzielony(el, zakres);
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"ni ma zakresu.. el: {el.Nazwa}");
                        RaportEtapBledy.Add(el);
                        ElementyDoZaplanowania.Remove(el);
                    }
                }
                //System.Diagnostics.Debug.WriteLine(EtapId);
                // rozliczenie RaportEtapBledy - czy znajda sie zakresy pasujace do grupyRoboczej, jesli nie to wyrzucenie do RaportBrakLudzi
                EtapId++;
            }
        }
        private bool ZaplanujEtapNext() {
            if (EtapId == 0) return true;


            bool result = false;
            if (RaportEtapBledy.Count == 0) return false;

            var elementyDoZaplanowaniaTemp = new List<ElementDoZaplanowania>();

            //zmiana EtapId w zakresach
            foreach (var z in Zakresy.Where(w=>w.EtapId==EtapId-1))
            {
                z.EtapId = EtapId;

            }

            foreach (var el in RaportEtapBledy)
            {
                if (CzyElementFitByGrupaAndDurationInZakres(el, Zakresy))
                {
                    elementyDoZaplanowaniaTemp.Add(el);
                }
                else {
                    RaportBrakCzasu.Add(el);
                }
            }

            if (elementyDoZaplanowaniaTemp.Count > 0)
            {
                ElementyDoZaplanowania.AddRange(elementyDoZaplanowaniaTemp.ToList());
                result = true;
            }

            RaportEtapBledy.Clear();
            return result;
        }
        private void ZaplanujElementCaly(ElementDoZaplanowania el, ZakresDTO zakres)
        {
            // if (el == null || zakres == null) return;
            var zapl = new ElementZaplanowany();
            zapl.EtapId = EtapId;
            ZakresCzasPomniejszElement(zakres, el, zapl);
            zapl.ElementBaza = el;
            Zaplanowane.Add(zapl);
            ElementyDoZaplanowania.Remove(el);
            return;
        }
        private void ZaplanujElementPodzielony(ElementDoZaplanowania el, ZakresDTO zakres)
        {
            var dzielenieElementuInProgress = true;
            int czasJuzZaplanowany = 0;
            int count = 1;
            while (dzielenieElementuInProgress)
            {
                var zapl = new ElementZaplanowany() {
                    CzyPodzielony = true,
                    ElementBaza = el,
                    EtapId = EtapId
                };
                ZakresCzasPomniejszElement(count>1? ZakresZnajdzDostepny(el): zakres, el, zapl, czasJuzZaplanowany);
                czasJuzZaplanowany += (int)zapl.CzasZaplanowania.Duration.TotalMinutes;
                zapl.ElementPodzielony.PartName = $"part {count}, {zapl.CzasZaplanowania.Duration.TotalMinutes}/{czasJuzZaplanowany}/{el.RobociznaWartosc}";
                Zaplanowane.Add(zapl);
                if (czasJuzZaplanowany == el.RobociznaWartosc){
                    ElementyDoZaplanowania.Remove(el);
                    return;
                }
                count++;
            }

        }

    }
}