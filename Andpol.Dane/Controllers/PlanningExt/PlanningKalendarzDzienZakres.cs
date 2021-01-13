using Andpol.Dane.Pomocne.NormaExt;
using Andpol.Dane.Pomocne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.PlanningExt
{
    public class PlanningKalendarzDzienZakres
    {
        public PlanningKalendarzDzienZakres(List<ZakresDTO> zakresy, List<ElementDoZaplanowania> elementyDoZaplanowania)
        {
            ElementyDoZaplanowania = new List<ElementDoZaplanowania>();
            PlanningKalendarzDzienList = new List<PlanningZakresDzienDTO>();
            Zakresy = new List<ZakresDTO>();
            ZakresyGrouped = new List<ZakresGroupedDTO>();


            ElementyDoZaplanowania = elementyDoZaplanowania;
            Zakresy = zakresy;
            ZakresyGroup();
            Init();
        }

        private List<ElementDoZaplanowania> ElementyDoZaplanowania { get; set; }
        private void Init()
        {
            bool end = true;
            int dzienId = 0;

            while (end)
            {

                var planningDay = new PlanningKalendarzDzien(ZakresyGrouped[dzienId].ZakresyGrouped,ElementyDoZaplanowania);

                var planningZakresDzien = new PlanningZakresDzienDTO();
                planningZakresDzien.DzienRoboczy = planningDay.DzienRoboczy;
                planningZakresDzien.PlanningKalendarzDzien = planningDay;


                PlanningKalendarzDzienList.Add(new PlanningZakresDzienDTO {
                    DzienRoboczy=planningDay.DzienRoboczy,
                    PlanningKalendarzDzien=planningDay,
                });

                if (planningDay.RaportBrakCzasu.Count > 0 && dzienId + 1 < ZakresyGrouped.Count)
                {
                    ElementyDoZaplanowania = planningDay.RaportBrakCzasu.ToList();
                    dzienId++;
                }
                else
                {
                    end = false;
                }

            }

        }
        public List<PlanningZakresDzienDTO> PlanningKalendarzDzienList { get; set; }
        public CzasZakres PlanningZakres
        {
            get
            {
                var result = new CzasZakres();


                //result.CzasStart = RaportZaplanowaneAll.Min(m => m.CzasZaplanowania.CzasStart);
                //result.CzasEnd = RaportZaplanowaneAll.Max(m => m.CzasZaplanowania.CzasEnd);

                //return result;

                if (RaportZaplanowaneAll.Count > 0)
                {
                    result.CzasStart = RaportZaplanowaneAll.Min(m => m.CzasZaplanowania.CzasStart);
                    result.CzasEnd = RaportZaplanowaneAll.Max(m => m.CzasZaplanowania.CzasEnd);
                    } else {
                    result.CzasStart = this.PlanningKalendarzDzienList.FirstOrDefault().PlanningKalendarzDzien.Zakresy.Min(m => m.CzasZakres.CzasStart);
                    result.CzasEnd = this.PlanningKalendarzDzienList.LastOrDefault().PlanningKalendarzDzien.Zakresy.Max(m => m.CzasZakres.CzasEnd);
                }

                return result;
            }
        }
        public ModelsDTO.ProdukcjaDzialDTO ProdukcjaDzial { get {
                var prod = Zakresy.FirstOrDefault().GrupaRobocza;

                ModelsDTO.ProdukcjaDzialDTO prodDzial = new ModelsDTO.ProdukcjaDzialDTO();
                prodDzial.ProdukcjaDzialId = prod.ProdukcjaDzialId;
                prodDzial.Nazwa = prod.ProdukcjaDzialNazwa;


                return prodDzial;
            } }
        public List<ElementDoZaplanowania> RaportBrakCzasuAll { get {
                return PlanningKalendarzDzienList.LastOrDefault().PlanningKalendarzDzien.RaportBrakCzasu;
            } }
        public List<string> RaportErrorsAll
        {
            get
            {
                List<string> result = new List<string>();

                foreach (var planningDzien in PlanningKalendarzDzienList)
                {
                    result.AddRange(planningDzien.PlanningKalendarzDzien.RaportErrors.ToList());
                }

                return result;
            }
        }
        public List<RobociznaStanowiskoStrataDTO> RaportZaplanowaneStrataAll
        {
            get
            {
                List<RobociznaStanowiskoStrataDTO> result = new List<RobociznaStanowiskoStrataDTO>();

                foreach (var planningDzien in PlanningKalendarzDzienList)
                {
                    var strataDzien=planningDzien.PlanningKalendarzDzien.RaportZaplanowaneStrata;
                    foreach (var stanowisko in strataDzien)
                    {
                        var foundInResult = result.Where(w => w.RobociznaId == stanowisko.RobociznaId).Select(s => s).FirstOrDefault();


                        if (foundInResult == null)
                        {
                            var robStrata= new RobociznaStanowiskoStrataDTO {
                                RobociznaId=stanowisko.RobociznaId,
                                RobociznaNazwa=stanowisko.RobociznaNazwa,
                                Strata=stanowisko.Strata,
                            };

                            foreach (var strata in PlanningKalendarzDzienList)
                            {
                                robStrata.SkladWyjsciowy+= strata.PlanningKalendarzDzien.RaportZaplanowaneStrata.Where(w => w.RobociznaId == robStrata.RobociznaId).Select(s => s.SkladWyjsciowy).FirstOrDefault();
                                robStrata.RoboczoGodziny += strata.PlanningKalendarzDzien.RaportZaplanowaneStrata.Where(w => w.RobociznaId == robStrata.RobociznaId).Select(s => s.RoboczoGodziny).FirstOrDefault();
                            }

                            result.Add(robStrata);
                        }
                        else {
                            foundInResult.Strata+=stanowisko.Strata;
                        }

                    }

                }

                return result;
            }
        }
        private List<ElementZaplanowany> RaportZaplanowaneAll { get {
                List<ElementZaplanowany> result = new List<ElementZaplanowany>();
                foreach (var planningDzien in PlanningKalendarzDzienList)
                {
                    if (planningDzien.PlanningKalendarzDzien.Zaplanowane.Count > 0)
                    {
                        result.AddRange(planningDzien.PlanningKalendarzDzien.Zaplanowane);
                    }
                    else {
                        RaportErrorsAll.Add($"Brak zaplanowanych elementów w dniu {planningDzien.DzienRoboczy.ToShortDateString()}");
                        }
                   
                }


                return result;
            } }
        public RaportShort RaportShort
        {
            get
            {
                var zaplanowane = StringHelpful.StringListGroup(RaportZaplanowaneAll.GroupBy(g => g.ElementBaza.ZamowienieKombiId).Select(s => new { Key = s.Key, Element = s.FirstOrDefault().ElementBaza }).ToList().Select(se => se.Element.Nazwa).ToList());
                var brakCzasu = StringHelpful.StringListGroup(RaportBrakCzasuAll.GroupBy(g => g.ZamowienieKombiId).Select(sg => new { nazwa = sg.FirstOrDefault().Nazwa }).ToList().Select(sn => sn.nazwa).ToList());

                return new RaportShort
                {
                    Zaplanowane = zaplanowane,
                    BrakCzasu = brakCzasu
                };

            }
        }
        private List<ZakresDTO> Zakresy { get; set; }
        private List<ZakresGroupedDTO> ZakresyGrouped { get; set; }
        private void ZakresyGroup()
        {
            ZakresyGrouped = Zakresy.GroupBy(g => g.CzasZakres.CzasStart.Date).Select(s => new ZakresGroupedDTO()
            {
                DzienRoboczy = s.Key,
                ZakresyGrouped = s.OrderBy(o=>o.CzasZakres.CzasStart).ToList()
            }).OrderBy(order=>order.DzienRoboczy).ToList();

            return;
        }

    }
}