using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.PlanningExt
{
    public static class PlanningHelp
    {
        public static int CzasGrupRoboczych(List<KalendarzDniRoboczychZakresDTO> zakresy)
        {
            var result = new TimeSpan();

            foreach (var z in zakresy)
            {
                result += z.CzasEnd - z.CzasStart;
            }

            return (int)result.TotalMinutes;
        }
        public static List<PlanningDzienRoboczyGrupaRoboczaDTO> GrupaMaxOkresl(List<PlanningDzienRoboczyDTO> elementy)
        {

            var grupy = elementy.GroupBy(g => g.KombinacjaRefId).Select(s => new PlanningDzienRoboczyRaportDTO()
            {
                KombinacjaRefId = s.Key,
                Nazwa = s.Select(sn => sn.Nazwa).FirstOrDefault(),
                Ilosc = s.Count(),
                CzasRazem = s.Sum(sc => sc.CzasPracy.Wartosc),
                GrupaRobocza = s.Select(sg => sg.CzasPracy.GrupaRobocza.ToList()).FirstOrDefault(),
            }).ToList();


            var result = new List<PlanningDzienRoboczyGrupaRoboczaDTO>();
            foreach (var el in grupy)
            {
                var grR = el.GrupaRobocza.Select(s => new PlanningDzienRoboczyGrupaRoboczaDTO()
                {
                    Nazwa = s.Nazwa,
                    RobociznaId = s.RobociznaId,
                    Wartosc = s.Wartosc
                }).ToList();


                foreach (var grupa in grR)
                {

                    var grupaInResult = result.Find(f => f.RobociznaId == grupa.RobociznaId);

                    if (grupaInResult == null)
                    {
                        result.Add(grupa);
                    }
                    else
                    {
                        if (grupa.Wartosc > grupaInResult.Wartosc)
                        {
                            result.Remove(grupaInResult);
                            result.Add(grupa);
                        }
                    }
                }
            }

            result.OrderBy(o => o.RobociznaId);
            return result;
        }
        public static bool GrupaMaxStanCheck(List<PlanningGrupaRoboczaSkladDTO> sklad, List<PlanningDzienRoboczyGrupaRoboczaDTO> grupaMax)
        {
            if (sklad == null || grupaMax == null)
            {
                return false;
            };

            var result = new List<bool>();

            foreach (var rob in grupaMax.ToList())
            {
                var robFound = sklad.Find(f => f.Id == rob.RobociznaId);
                if (robFound != null)
                {
                    if (robFound.Ilosc >= rob.Wartosc)
                    {
                        result.Add(true);
                    }
                    else
                    {
                        result.Add(false);
                    }
                }
            }

            return result.All(a => a == true);
        }
        public static List<PlanningGrupaRoboczaSkladDTO> GrupaMaxReszta(List<PlanningGrupaRoboczaSkladDTO> sklad, List<PlanningDzienRoboczyGrupaRoboczaDTO> grupaMax)
        {
            if (!GrupaMaxStanCheck(sklad, grupaMax))
            {
                return new List<PlanningGrupaRoboczaSkladDTO>();
            }

            var result = new List<PlanningGrupaRoboczaSkladDTO>();

            foreach (var rob in sklad)
            {
                var robFound = grupaMax.Find(f => f.RobociznaId == rob.Id);
                if (robFound != null)
                {
                    result.Add(new PlanningGrupaRoboczaSkladDTO
                    {
                        Id = rob.Id,
                        Nazwa = rob.Nazwa,
                        ProdukcjaDzial = rob.ProdukcjaDzial,
                        Ilosc = rob.Ilosc - robFound.Wartosc,
                        Uwagi = rob.Uwagi
                    });
                }
            }

            return result;
        }
        public static void GrupaRoboczaUnikalnoscOkresl(List<PlanningDzienRoboczyDTO> elementyDoZaplanowania)
        {
            var rozne = new List<PlanningDzienRoboczyCzasPracyDTO>();
            int uniqueId = 1;
            foreach (var el in elementyDoZaplanowania)
            {

                // var czasPracy = el.Select(se => se.CzasPracy).FirstOrDefault();

                var czasPracy = el.CzasPracy;
                var elUniqueString = el.CzasPracy.GrupaRobocza.OrderBy(o => o.RobociznaId).Select(s => s.RobociznaId.ToString() + s.Wartosc).Aggregate((p, n) => p + "" + n);
                var znalezionoWRozne = rozne.Find(f => f.GrupaRobocza.OrderBy(o => o.RobociznaId).Select(s => s.RobociznaId.ToString() + s.Wartosc).Aggregate((p, n) => p + "" + n) == elUniqueString);
                if (znalezionoWRozne == null)
                {
                    czasPracy.GrupaRoboczaUniqueId = uniqueId;
                    rozne.Add(czasPracy);
                    uniqueId++;
                }
                else
                {
                    czasPracy.GrupaRoboczaUniqueId = znalezionoWRozne.GrupaRoboczaUniqueId;
                }
            }

            return;
        }
        public static List<PlanningDzienRoboczyExtDTO> ElementyDoZaplanowania(List<PlanningDzienRoboczyDTO> elementyDoZaplanowania)
        {
            var result = new List<PlanningDzienRoboczyExtDTO>();
            var elementyDoZaplanowaniaExtGroup = elementyDoZaplanowania.GroupBy(g => g.KombinacjaRefId).Select(s => new PlanningDzienRoboczyRaportDTO()
            {
                KombinacjaRefId = s.Key,
                Nazwa = s.Select(sn => sn.Nazwa).FirstOrDefault(),

                Ilosc = s.Count(),
                CzasRazem = s.Sum(sc => sc.CzasPracy.Wartosc),
                GrupaRobocza = s.Select(sg => sg.CzasPracy.GrupaRobocza.ToList()).FirstOrDefault(),
            }).ToList();

            foreach (var el in elementyDoZaplanowania)
            {
                result.Add(new PlanningDzienRoboczyExtDTO
                {
                    CzasPracy = el.CzasPracy,
                    KombinacjaRefId = el.KombinacjaRefId,
                    Nazwa = el.Nazwa,
                    RazemCzas = elementyDoZaplanowaniaExtGroup.Where(w => w.KombinacjaRefId == el.KombinacjaRefId).Select(s => s.CzasRazem).FirstOrDefault(),
                    ZamKombiRefId = el.ZamKombiRefId,
                    ZamowienieRefId = el.ZamowienieRefId
                });
            }

            result.OrderByDescending(o => o.CzasPracy.GrupaRobocza.Max(m => m.Wartosc)).ThenByDescending(o => o.CzasPracy.GrupaRobocza.Count).ToList();

            return result;
        }

        public static List<PlanningGrupaRoboczaSkladDTO> GrupaRoboczaToSklad(List<PlanningDzienRoboczyGrupaRoboczaDTO> grupaRobocza)
        {
            var result = new List<PlanningGrupaRoboczaSkladDTO>();

            result.AddRange(grupaRobocza.Select(s => new PlanningGrupaRoboczaSkladDTO()
            {
                Id = s.RobociznaId,
                Ilosc = s.Wartosc,
                Nazwa = s.Nazwa,
            }).ToList());

            return result;
        }

        public static List<KalendarzDniRoboczychZakresDTO> EtapResultToZakres(List<PlanningElementResultDTO> elementyResult)
        {
            var result = new List<KalendarzDniRoboczychZakresDTO>();

            result.AddRange(elementyResult.Select(s => new KalendarzDniRoboczychZakresDTO()
            {
                CzasEnd = s.DateEnd,
                CzasStart = s.DateStart,
                Sklad = GrupaRoboczaToSklad(s.GrupaRoboczaStrata),
            }).ToList());


            return result;
        }

        public static List<PlanningDzienRoboczyGrupaRoboczaDTO> OkreslStrate(List<PlanningDzienRoboczyGrupaRoboczaDTO> grupyRobocze, List<PlanningGrupaRoboczaSkladDTO> sklad)
        {
            var result = new List<PlanningDzienRoboczyGrupaRoboczaDTO>();

            foreach (var grupa in sklad)
            {
                var grupaInRobocze = grupyRobocze.Find(f => f.RobociznaId == grupa.Id);
                if (grupaInRobocze == null)
                {
                    result.Add(new PlanningDzienRoboczyGrupaRoboczaDTO()
                    {
                        Nazwa = grupa.Nazwa,
                        RobociznaId = grupa.Id,
                        Wartosc = grupa.Ilosc


                    });
                }
                else
                {
                    result.Add(new PlanningDzienRoboczyGrupaRoboczaDTO()
                    {
                        Nazwa = grupa.Nazwa,
                        RobociznaId = grupa.Id,
                        Wartosc = grupa.Ilosc - grupaInRobocze.Wartosc
                    });
                }

            }

            return result;
        }
        public static PlanningDzienRoboczyDTO OznaczElementNaPrzelomie(PlanningDzienRoboczyDTO element, bool czyNaPrzelomie = false)
        {
            if (czyNaPrzelomie == true)
            {
                element.Nazwa += $" [part] ({element.CzasPracy.Wartosc}m)";
            }
            else
            {
                element.Nazwa += $" ({element.CzasPracy.Wartosc}m)";
            }


            return element;
        }
        public static PlanningEtapResultDTO PlanningEtapResult(List<PlanningDzienRoboczyDTO> elementyDoZaplanowania, List<KalendarzDniRoboczychZakresDTO> zakresBaza, KalendarzDniRoboczychDzialProdDTO dzienRoboczy)
        {
            var duration = new TimeSpan();
            var zakresPozycja = new TimeSpan();
            var res = new PlanningEtapResultDTO();
            var zakresBazaCopy = zakresBaza.ToList();


            for (int i = 0; i < elementyDoZaplanowania.Count; i++)
            {
                var el = elementyDoZaplanowania[i];
                var zakresy = ZakresBasedOnGrupaMax(zakresBaza, PlanningHelp.GrupaRoboczaToSklad(el.CzasPracy.GrupaRobocza));

                var zakresAct = zakresy.FirstOrDefault();

                var czasCalegoZakresu = PlanningHelp.CzasGrupRoboczych(zakresy);

                //if (zakresBaza.Count == 0 || zakresy.Count == 0)
                //{
                //    res.Reszta.Add(el);
                //    continue;
                //}

                if (el.CzasPracy.Wartosc > (czasCalegoZakresu - (int)duration.TotalMinutes))
                {
                    res.ResztaProces.Add(el);
                    continue;
                }

                var elNazwa = el.Nazwa+$" ({el.CzasPracy.Wartosc}m) ";
                var elPozostaloDoPrzypisania = new TimeSpan(0, el.CzasPracy.Wartosc, 0);
                var isUnfinished = true;
                int licznik = 1;

                    while (isUnfinished)
                    {
                    zakresAct = zakresy.FirstOrDefault();
                    var start = zakresAct.CzasStart.Add(duration);
                    var end = start.Add(new TimeSpan(0, el.CzasPracy.Wartosc, 0));
                    //dodaje pierwsza czesc czasu elementu:

                    var czasZakresu = zakresAct.CzasEnd - zakresAct.CzasStart - duration - zakresPozycja;

                    if (elPozostaloDoPrzypisania < czasZakresu) {
                        var nazwa = licznik == 1 ?
                            elNazwa+" (full)" :
                            elNazwa + $"part[{licznik}] end";
                        var elResult = new PlanningElementResultDTO();

                        elResult.DateEnd = start.Add(elPozostaloDoPrzypisania);
                        elResult.DateStart = start;
                        elResult.Element = new PlanningDzienRoboczyDTO()
                        {
                            CzasPracy = el.CzasPracy,
                            KombinacjaRefId = el.KombinacjaRefId,
                            Nazwa = nazwa,
                            ZamKombiRefId = el.ZamKombiRefId,
                            ZamowienieRefId = el.ZamowienieRefId
                        };
                        elResult.GrupaRoboczaStrata = PlanningHelp.OkreslStrate(elResult.Element.CzasPracy.GrupaRobocza, zakresy.FirstOrDefault().Sklad);
                        res.Result.Add(elResult);
                        duration += elPozostaloDoPrzypisania;
                        elPozostaloDoPrzypisania = new TimeSpan();
                        isUnfinished = false;
                        continue;
                    }

                    if (elPozostaloDoPrzypisania > czasZakresu) {
                        
                        var elResult = new PlanningElementResultDTO();
                        var nazwa = licznik == 1 ? 
                            elNazwa+$" part[1] start" :
                            elNazwa + $" part[{licznik}]";
                        var roznica = zakresAct.CzasEnd - start;

                        elResult.DateEnd = zakresAct.CzasEnd;
                        elResult.DateStart = start;
                        elResult.Element = new PlanningDzienRoboczyDTO()
                        {
                            CzasPracy = el.CzasPracy,
                            KombinacjaRefId = el.KombinacjaRefId,
                            Nazwa = nazwa,
                            ZamKombiRefId = el.ZamKombiRefId,
                            ZamowienieRefId = el.ZamowienieRefId
                        };
                        elResult.GrupaRoboczaStrata = PlanningHelp.OkreslStrate(elResult.Element.CzasPracy.GrupaRobocza, zakresAct.Sklad);
                        res.Result.Add(elResult);

                        elPozostaloDoPrzypisania = elPozostaloDoPrzypisania-roznica;
                        licznik++;

                        zakresBaza.Remove(zakresBaza.Find(f => f.CzasStart == zakresAct.CzasStart && f.CzasEnd == zakresAct.CzasEnd));
                        zakresy.Remove(zakresAct);
                        duration = new TimeSpan();
                    }


                    if (elPozostaloDoPrzypisania == czasZakresu) {
                        var elResult = new PlanningElementResultDTO();
                        var nazwa = licznik == 1 ?
                            elNazwa + $" (full)" :
                            elNazwa + $"[{licznik}] (end)";
                           
                        var roznica = zakresAct.CzasEnd - start;

                        elResult.DateEnd = zakresAct.CzasEnd;
                        elResult.DateStart = start;
                        elResult.Element = new PlanningDzienRoboczyDTO()
                        {
                            CzasPracy = el.CzasPracy,
                            KombinacjaRefId = el.KombinacjaRefId,
                            Nazwa = nazwa,
                            ZamKombiRefId = el.ZamKombiRefId,
                            ZamowienieRefId = el.ZamowienieRefId
                        };
                        elResult.GrupaRoboczaStrata = PlanningHelp.OkreslStrate(elResult.Element.CzasPracy.GrupaRobocza, zakresAct.Sklad);
                        res.Result.Add(elResult);

                        elPozostaloDoPrzypisania = new TimeSpan();
                        isUnfinished = false;
                        duration = new TimeSpan();

                        zakresBaza.Remove(zakresBaza.Find(f => f.CzasStart == zakresAct.CzasStart && f.CzasEnd == zakresAct.CzasEnd));
                        zakresy.Remove(zakresAct);
                        duration = zakresy.Count > 0 ? elPozostaloDoPrzypisania : new TimeSpan();
                        continue;
                    }
                }

            }
            res.Result = ZakresUzupelnijBasedOnParent(res.Result, zakresBazaCopy);
            res =UporzadkujReszte(res);
            return res;
        }
        public static List<PlanningDzienRoboczyGrupaRoboczaDTO> SkladToGrupaRobocza(List<PlanningGrupaRoboczaSkladDTO> sklad)
        {
            var result = new List<PlanningDzienRoboczyGrupaRoboczaDTO>();

            result.AddRange(sklad.Select(s => new PlanningDzienRoboczyGrupaRoboczaDTO()
            {
                Nazwa = s.Nazwa,
                RobociznaId = s.Id,
                Wartosc = s.Ilosc
            }).ToList());

            return result;
        }
        public static List<KalendarzDniRoboczychZakresDTO> ZakresBasedOnGrupaMax(List<KalendarzDniRoboczychZakresDTO> zakres, List<PlanningGrupaRoboczaSkladDTO> sklad)
        {

            var result = new List<KalendarzDniRoboczychZakresDTO>();
            foreach (var z in zakres)
            {
                if (GrupaMaxStanCheck(z.Sklad, SkladToGrupaRobocza(sklad)))
                {
                    result.Add(z);
                }
            }
            return result;
        }

        public static List<PlanningElementResultDTO> ZakresUzupelnijBasedOnParent(List<PlanningElementResultDTO> zakresyDoUzupelnienia, List<KalendarzDniRoboczychZakresDTO> parentZakres)
        {

            var result = zakresyDoUzupelnienia.ToList();

            for (int i = 0; i < parentZakres.Count; i++)
            {
                var pz = parentZakres[i];
                var sklad = pz.Sklad;

                var listaZakresow = zakresyDoUzupelnienia.Where(w => w.DateStart >= pz.CzasStart && w.DateEnd <= pz.CzasEnd).ToList();

                if (listaZakresow.Count == 0)
                {
                    result.Add(new PlanningElementResultDTO()
                    {
                        DateStart = pz.CzasStart,
                        DateEnd = pz.CzasEnd,
                        GrupaRoboczaStrata = SkladToGrupaRobocza(sklad)
                    });
                    continue;
                }

                var zakresScalony = new PlanningElementResultDTO()
                {
                    DateStart = listaZakresow.Min(min => min.DateStart),
                    DateEnd = listaZakresow.Max(max => max.DateEnd),
                };

                if (zakresScalony.DateStart > pz.CzasStart)
                {
                    result.Add(new PlanningElementResultDTO()
                    {
                        DateStart = pz.CzasStart,
                        DateEnd = zakresScalony.DateStart,
                        GrupaRoboczaStrata = SkladToGrupaRobocza(sklad)
                    });
                }

                if (zakresScalony.DateEnd < pz.CzasEnd)
                {
                    result.Add(new PlanningElementResultDTO()
                    {
                        DateStart = zakresScalony.DateEnd,
                        DateEnd = pz.CzasEnd,
                        GrupaRoboczaStrata = SkladToGrupaRobocza(sklad)
                    });
                }
            }

            return result.OrderBy(o => o.DateStart).ToList();
        }

        public static PlanningEtapResultDTO UporzadkujReszte(PlanningEtapResultDTO etap)
        {
            var result = new PlanningEtapResultDTO();
            result.Result = etap.Result.ToList();
            var unikalne = new List<Unikalna>();

            foreach (var el in etap.ResztaProces)
            {
                var zakresy = ZakresBasedOnGrupaMax(EtapResultToZakres(etap.Result), GrupaRoboczaToSklad(el.CzasPracy.GrupaRobocza));
                if (zakresy.Count == 0)
                {
                    result.BrakLudzi.Add(el);
                }
                else
                {
                    var czasCalegoZakresu = PlanningHelp.CzasGrupRoboczych(zakresy);
                    if (el.CzasPracy.Wartosc > czasCalegoZakresu)
                    {
                        result.BrakCzasu.Add(el);
                    }
                    else {
                        result.Reszta.Add(el);
                    }
                } 
                //{
                //    //czy jest unikalna..
                //    var actGroupKey = new Unikalna()
                //    {
                //        Key = el.CzasPracy.GrupaRobocza.Select(s => s.Nazwa + s.Wartosc.ToString()).ToList().Aggregate((p, n) => p + n),
                //        Wartosc = el.CzasPracy.Wartosc
                //    };
                //    var czasCalegoZakresu = PlanningHelp.CzasGrupRoboczych(zakresy);
                //    var foundInUnikalne = unikalne.Find(f => f.Key == actGroupKey.Key);
                //    if (foundInUnikalne!=null) {
                //        czasCalegoZakresu -= foundInUnikalne.Wartosc;
                //    }

                //    if (el.CzasPracy.Wartosc > czasCalegoZakresu)
                //    {
                //        result.Reszta.Add(el);
                //    }
                //    else
                //    {
                //        result.Reszta.Add(el);
                //        if (foundInUnikalne != null)
                //        {
                //            foundInUnikalne.Wartosc += actGroupKey.Wartosc;
                //        }
                //        else {
                //            unikalne.Add(actGroupKey);
                //        }
                //    }
                //}
               
            }

            return result;
        }

        public static void RaportToString(PlanningEtapResultDTO etap)
        {

            var brakCzasu = etap.BrakCzasu.Select(s => s.Nazwa).ToList();

            //var rap = new PlanningEtapResultRaport();
            //rap.EtapId = etap.EtapId;
            //var brakCzasu = etap.BrakCzasu.GroupBy(g => g.KombinacjaRefId).Select(s => new
            //{
            //    Nazwa = s.Select(sg => sg.Nazwa).FirstOrDefault(),
            //    Wartosc = s.Count(),
            //});

            //var brakLudzi = etap.BrakLudzi.GroupBy(g => g.KombinacjaRefId).Select(s => new
            //{
            //    Nazwa = s.Select(sg => sg.Nazwa).FirstOrDefault(),
            //    Wartosc = s.Count(),
            //});

            //foreach (var el in brakCzasu)
            //{
            //    rap.BrakCzasu.Add($" {el.Wartosc}x | {el.Nazwa} ||");
            //}

            //foreach (var el in brakLudzi)
            //{
            //    rap.BrakLudzi.Add($" {el.Wartosc}x | {el.Nazwa} ||");
            //}

            //// strata w przeliczeniu na minuty


            //var sklad = new List<PlanningGrupaRoboczaSkladDTO>();
            //foreach (var e in etap.Result)
            //{
            //    var duration = e.DateEnd - e.DateStart;
            //    var grupyRobocze = e.GrupaRoboczaStrata.Select(s => s).ToList();
            //    foreach (var r in grupyRobocze)
            //    {
            //        var foundInSklad = sklad.Find(f => f.Id == r.RobociznaId);

            //        if (foundInSklad != null)
            //        {
            //            TimeSpan actIlosc = new TimeSpan(0, foundInSklad.Ilosc, 0);
            //            TimeSpan wartoscCzasu = new TimeSpan(0, r.Wartosc* (int)duration.TotalMinutes , 0);

            //            foundInSklad.Ilosc += (int)wartoscCzasu.TotalMinutes;
            //            //foundInSklad.StrataRh = $"{(actIlosc + wartoscCzasu).Days}d {(actIlosc+wartoscCzasu).Hours}h {(actIlosc+ wartoscCzasu).Minutes}m";
            //            foundInSklad.StrataRh = $"{(actIlosc + wartoscCzasu).TotalHours.ToString("#")} Rh ";
            //        }
            //        else {
            //            TimeSpan wartoscCzasu = new TimeSpan(0, r.Wartosc * (int)duration.TotalMinutes, 0);

            //            sklad.Add(new PlanningGrupaRoboczaSkladDTO() {
            //                Id = r.RobociznaId,
            //                Ilosc = (int)wartoscCzasu.TotalMinutes,
            //                Nazwa = r.Nazwa,
            //            });
            //        }
            //    }
            //}
            //rap.SkladStrata = sklad;





            //etap.Raport = rap;
            return;
        }

        public static List<RaportNazw> RaportNazw(List<string> nazwy)
        {
            return (from n in nazwy group n by n into nGroup
                select new RaportNazw()
            {
                Count = nGroup.Count(),
                Nazwa = nGroup.Select(sg => sg).FirstOrDefault()
            }).ToList();

        }

    }
}


public class Unikalna
{
    public string Key { get; set; }
    public int Wartosc { get; set; }

}

public class RaportNazw
{
    public int Count { get; set; }
    public string Nazwa { get; set; }
}