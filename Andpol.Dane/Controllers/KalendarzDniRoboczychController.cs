using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using System.Web.Http.Cors;
using System.Data.Entity.SqlServer;
using System.Globalization;
using Andpol.Dane.Pomocne.PlanningExt;

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="Planning")]
    [EnableCors("*", "*", "*")]
    public class KalendarzDniRoboczychController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        [HttpPost]
        [Route("api/kalendarzDniRoboczych/DateRange")]
        public IHttpActionResult GetKalendarzDniRoboczychZakres(DateRangeDTO range)
        {
            if (range == null ||
               (range.DateEnd.Date-range.DateStart.Date).TotalDays==0 || 
               range.DateStart.Date>range.DateEnd.Date)
            {
                return BadRequest("Przesłane dane są nieprawidłowe");
            }

            CultureInfo cul = CultureInfo.CurrentCulture;


            var start = range.DateStart.Date;
            var end = range.DateEnd.Date;

            if ((int)range.DateStart.DayOfWeek >1)
            {
                start = start.Subtract(new TimeSpan(((int)range.DateStart.DayOfWeek)-1, 0, 0, 0));
            };
            if ((int)range.DateStart.DayOfWeek == 0)
            {
                start = start.Subtract(new TimeSpan(6, 0, 0, 0));
            };


            if ((int)range.DateEnd.DayOfWeek > 0)
            {
                end = end.Add(new TimeSpan((7-(int)range.DateEnd.DayOfWeek), 0, 0, 0));
            };


            DateTime odDaty = range.DateStart.Date;
            DateTime doDaty = range.DateEnd.Date.Add(new TimeSpan(1, 0, 0, 0)).Date;

            var kal = (from k in db.KalendarzDniRoboczych
                       where k.DzienRoboczy > odDaty && k.DzienRoboczy < doDaty
                       select new KalendarzDniRoboczychDTO()
                       {
                           DzienRoboczy = k.DzienRoboczy,
                           ProdukcjaDzial = k.KalendarzDniRoboczychDzialProd.Select(s => new KalendarzDniRoboczychDzialProdDTO()
                           {
                               CzasPracyStart=s.KalendarzDniRoboczychZakres.Min(m=>m.CzasStart),
                               CzasPracyEnd=s.KalendarzDniRoboczychZakres.Max(m=>m.CzasEnd),
                               ProdukcjaDzial = new ProdukcjaDzialDTO()
                               {
                                   Nazwa = s.ProdukcjaDzial.Nazwa,
                                   ProdukcjaDzialId = s.ProdukcjaDzialRefId
                               }

                           }).ToList(),
                           KalendarzDniRoboczychId = k.KalendarzDniRoboczychId,
                           Uwagi = k.Uwagi

                       }).ToList();


            foreach (var dzien in kal)
            {

                foreach (var item in dzien.ProdukcjaDzial)
                {
                    TimeSpan roznica = item.CzasPracyEnd - item.CzasPracyStart;
                    item.CzasPracyDuration = roznica.Hours.ToString("00") + ":" + roznica.Minutes.ToString("00");
                }
            }




            CalendarDTO result = new CalendarDTO
            {
                DateEnd = range.DateEnd,
                DateStart = range.DateStart,
                RazemDni = (end-start).TotalDays+1
            };

            List<CalendarWeekDayDTO> days = new List<CalendarWeekDayDTO>();

            int weekNr = cul.Calendar.GetWeekOfYear(start, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            for (int i = 0; i < result.RazemDni; i++)
            {
                var actDay = start.Add(new TimeSpan(i, 0, 0, 0));
                var actMonth = actDay.Month;

                if (i > 1) {

                }

                CalendarWeekDayDTO day = new CalendarWeekDayDTO
                {
                    DzienRoboczy = actDay.Date,
                    WeekDay=weekNr,
                };


                if (day.DzienRoboczy.Date>=range.DateStart.Date && day.DzienRoboczy.Date<=range.DateEnd.Date)
                {
                    day.Active = true;
                };


                days.Add(day);
                if (actDay.DayOfWeek == 0) { weekNr++; }
            };

            var hueList = new List<int>() {50,400,100,600};
            int hueIndex = 0;


            foreach (var d in days.OrderBy(o=>o.DzienRoboczy))
            {
                

                var zapisanyDzienRoboczy = kal.Where(w => w.DzienRoboczy.Date == d.DzienRoboczy.Date).Select(s => s).FirstOrDefault();
                if(zapisanyDzienRoboczy!=null) {
                    d.DataObj = zapisanyDzienRoboczy;
                };
                if (d.DzienRoboczy.Month > d.DzienRoboczy.Subtract(new TimeSpan(1, 0, 0, 0)).Month)
                {
                    hueIndex = hueIndex + 1 < hueList.Count ? hueIndex + 1 : 0;
                    d.Hue = hueList[hueIndex];
                }
                else {
                    d.Hue = hueList[hueIndex];
                }

            }



            var weeks = days.GroupBy(g => g.WeekDay).Select(s => new CalendarWeekDTO()
            {
                Days = s.Select(sd => sd).ToList()
            }).ToList();


            result.Weeks = weeks;




            return Ok(new { info = $"Zakres od {range.DateStart.ToShortDateString()} - {range.DateEnd.ToShortDateString()} wygenerowany prawidłowo, razem: {kal.Count}", result});
        }


        [HttpGet]
        public IHttpActionResult GetKalendarzDniRoboczych(int id)
        {

            var result = (from k in db.KalendarzDniRoboczych
                          where k.KalendarzDniRoboczychId == id
                          select new KalendarzDniRoboczychDTO()
                          {
                              DzienRoboczy = k.DzienRoboczy,
                              KalendarzDniRoboczychId = k.KalendarzDniRoboczychId,
                              ProdukcjaDzial=k.KalendarzDniRoboczychDzialProd.Select(s=> new KalendarzDniRoboczychDzialProdDTO() {
                                  CzasPracyStart = s.KalendarzDniRoboczychZakres.Min(m=>m.CzasStart),
                                  CzasPracyZakres = s.KalendarzDniRoboczychZakres.Select(sz => new KalendarzDniRoboczychZakresDTO()
                                  {
                                      CzasDuration = sz.CzasDuration,
                                      CzasEnd = sz.CzasEnd,
                                      CzasStart = sz.CzasStart,
                                      KalendarzDniRoboczychZakresId = sz.KalendarzDniRoboczychZakresId,
                                      Status = "baza",
                                      Uwagi = sz.Uwagi
                                  }).OrderBy(ocp => ocp.CzasStart).ToList(),
                                  KalendarzDniRoboczychDzialProdId =s.KalendarzDniRoboczychDzialProdId,
                                  ProdukcjaDzial=new ProdukcjaDzialDTO() {
                                      CzyPozycjaMagazynowa = s.ProdukcjaDzial.CzyPozycjaMagazynowa,
                                      CzyTkaninaBelka=s.ProdukcjaDzial.CzyTkaninaBelka,
                                      NadrzednyIds=s.ProdukcjaDzial.NadrzedneIds,
                                      GrupaRobocza = s.ProdukcjaDzial.Robocizna.Select(sp => new PlanningGrupaRoboczaSkladDTO()
                                      {
                                          PlanningGrupaRoboczaSkladId = sp.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad.Where(w => w.KalendarzDniRoboczychDzialProdRefId == s.KalendarzDniRoboczychDzialProdId).Select(si => si.KalendarzDniRoboczychDzialProdGrupaRoboczaSkladId).FirstOrDefault(),
                                          Id = sp.Id,
                                          Ilosc = sp.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad.Where(w => w.KalendarzDniRoboczychDzialProdRefId == s.KalendarzDniRoboczychDzialProdId).Select(si => si.Ilosc).FirstOrDefault(),
                                          Nazwa = sp.Nazwa,
                                      }).ToList(),

                                      Nazwa= s.ProdukcjaDzial.Nazwa,
                                      
                                      PoziomProdukcji = s.ProdukcjaDzial.PoziomProdukcji,
                                      ProdukcjaDzialId =s.ProdukcjaDzialRefId,
                                      
                                  },
                                  Status="baza",
                              }).OrderByDescending(o => o.ProdukcjaDzial.ProdukcjaDzialId).ToList(),

                              Uwagi = k.Uwagi
                          }).FirstOrDefault();

            //zaplanowane ZamowienieKombi
            var zamowienieKombi = db.PlanningDzienRoboczyZamowienieKombi
                .Where(w => w.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczychRefId == id)
                .Select(s => new PlanningZamowienieKombiInfo()
                {
                    IsDone=s.IsDone,
                    Nazwa=s.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa,
                    Zamowienie=new ZamowienieInfoDTO() {
                        Commission=s.ZamowienieKombi.Zamowienie.Commission,
                        Reference= s.ZamowienieKombi.Zamowienie.Reference,
                        ZamowienieNr= s.ZamowienieKombi.Zamowienie.ZamowienieNr,
                        ZamowienieId= s.ZamowienieKombi.Zamowienie.Id,
                    },
                    KalendarzDniRoboczychDzialProdRefId=s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProdRefId
                }).ToList();


            //Dodanie pola czas pracy duration

            foreach (var item in result.ProdukcjaDzial)
            {
                TimeSpan roznica = item.CzasPracyEnd - item.CzasPracyStart;
                item.CzasPracyDuration = roznica.Hours.ToString("00") + ":" + roznica.Minutes.ToString("00");
                item.ProdukcjaDzial.NadrzednyNazwaLista= db.ProdukcjaDzial.WhereIn(wi => wi.ProdukcjaDzialId, item.ProdukcjaDzial.NadrzednyIdsLista).Select(s => s.Nazwa).ToList();
                item.PlanningZamowienieKombiInfo = zamowienieKombi.Where(w => w.KalendarzDniRoboczychDzialProdRefId == item.KalendarzDniRoboczychDzialProdId).Select(s => s).ToList();
            }


            if (result == null) { return BadRequest($"Nie znaleziono rekordu o Id: {id}"); }


            var dzialyProd = db.ProdukcjaDzial.Select(s => new ProdukcjaDzialDTO()
            {
                Nazwa = s.Nazwa,
                PoziomProdukcji = s.PoziomProdukcji,
                ProdukcjaDzialId = s.ProdukcjaDzialId, 
                
            }).ToList();



            foreach (var d in dzialyProd)
            {
                var n = result.ProdukcjaDzial.Any(a => a.ProdukcjaDzial.ProdukcjaDzialId == d.ProdukcjaDzialId);
                if (n == false) {
                    KalendarzDniRoboczychDzialProdDTO pNew = new KalendarzDniRoboczychDzialProdDTO()
                    {
                        ProdukcjaDzial=new ProdukcjaDzialDTO() {
                            Nazwa=d.Nazwa,
                            PoziomProdukcji=d.PoziomProdukcji,
                            ProdukcjaDzialId=d.ProdukcjaDzialId,
                            CzyPozycjaMagazynowa=d.CzyPozycjaMagazynowa,
                            CzyTkaninaBelka=d.CzyTkaninaBelka,
                            NadrzednyIds=d.NadrzednyIds,
                            Uwagi=d.Uwagi
                        },
                    };


                    result.ProdukcjaDzial.Add(pNew);
                }

            }





            return Ok(new { info = "Dane wygenerowane poprawnie", result });
        }




        [HttpPut]
        public IHttpActionResult PutKalendarzDniRoboczych(int id, KalendarzDniRoboczychDTO kalDTO)
        {

            DateTime dR = Pomocne.DateHelpful.dataStalaGodzina(kalDTO.DzienRoboczy);

            if (id == 0)
            {
                
                KalendarzDniRoboczych kNew = new KalendarzDniRoboczych
                {
                    DzienRoboczy = dR,
                    Uwagi = kalDTO.Uwagi,
                };
                db.KalendarzDniRoboczych.Add(kNew);

                foreach (var dzial in kalDTO.ProdukcjaDzial)
                {
                    if (dzial.CzasPracyDuration != null) {

                    KalendarzDniRoboczychDzialProd dNew = new KalendarzDniRoboczychDzialProd
                    {
                        KalendarzDniRoboczych=kNew,
                        ProdukcjaDzialRefId=dzial.ProdukcjaDzial.ProdukcjaDzialId,
                    };

                    foreach (var z in dzial.CzasPracyZakres)
                    {
                        KalendarzDniRoboczychZakres zNew = new KalendarzDniRoboczychZakres
                        {
                            CzasDuration = z.CzasDuration,
                            CzasEnd = new DateTime(dR.Year, dR.Month,dR.Day,z.CzasEnd.Hour, z.CzasEnd.Minute, 0),
                            CzasStart = new DateTime(dR.Year, dR.Month, dR.Day, z.CzasStart.Hour, z.CzasStart.Minute, 0),
                            KalendarzDniRoboczychDzialProd = dNew,
                            Uwagi = z.Uwagi
                        };
                        db.KalendarzDniRoboczychZakres.Add(zNew);
                    }

                    foreach (var item in dzial.ProdukcjaDzial.GrupaRobocza)
                    {
                        if (item.Ilosc > 0)
                        {
                            KalendarzDniRoboczychDzialProdGrupaRoboczaSklad skladNew = new KalendarzDniRoboczychDzialProdGrupaRoboczaSklad();
                            skladNew.Ilosc = item.Ilosc;
                            skladNew.RobociznaRefId = item.Id;
                            skladNew.KalendarzDniRoboczychDzialProd = dNew;

                            db.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad.Add(skladNew);
                        }
                    }
                        dNew.CzyKalendarzDniRoboczychZakresAktywny = dzial.CzasPracyZakres.Count > 0 ? true : false;


                    db.KalendarzDniRoboczychDzialProd.Add(dNew);
                }

                db.SaveChanges();
                id = kNew.KalendarzDniRoboczychId;

                }


            }
            else {

                var kMod = db.KalendarzDniRoboczych.Find(id);

                if (kMod == null) {
                    return BadRequest($"Nie danych KalendarzDniRoboczych o Id: {id}");
                }

                kMod.Uwagi = kalDTO.Uwagi;

                foreach (var dzial in kalDTO.ProdukcjaDzial)
                {
                    var prodMod = db.KalendarzDniRoboczychDzialProd.Find(dzial.KalendarzDniRoboczychDzialProdId);

                    if (dzial.Status == "nowy")
                    {
                        prodMod= new KalendarzDniRoboczychDzialProd
                        {
                            KalendarzDniRoboczych = kMod,
                            ProdukcjaDzialRefId = dzial.ProdukcjaDzial.ProdukcjaDzialId,
                        };

                        db.Entry(prodMod).State = EntityState.Added;
                        db.SaveChanges();
                    }

                    if (dzial.Status == "zmieniony" && prodMod != null) {



                    }


                    if (dzial.ProdukcjaDzial.GrupaRobocza != null)
                    {
                        foreach (var r in dzial.ProdukcjaDzial.GrupaRobocza)
                        {
                            var rMod = db.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad.Where(w => w.KalendarzDniRoboczychDzialProdGrupaRoboczaSkladId == r.PlanningGrupaRoboczaSkladId).FirstOrDefault();
                            if (r.Ilosc > 0)
                            {
                                if (rMod != null)
                                {
                                    rMod.Ilosc = r.Ilosc;
                                }
                                else
                                {
                                    KalendarzDniRoboczychDzialProdGrupaRoboczaSklad rNew = new KalendarzDniRoboczychDzialProdGrupaRoboczaSklad
                                    {
                                        Ilosc = r.Ilosc,
                                        KalendarzDniRoboczychDzialProdRefId = prodMod.KalendarzDniRoboczychDzialProdId,
                                        RobociznaRefId = r.Id
                                    };
                                    db.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad.Add(rNew);
                                }
                            }
                            else {
                                if (rMod != null) {
                                    db.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad.Remove(rMod);
                                }
                            }

                        }
                    }



                    if (dzial.CzasPracyZakres.Count > 0) {
                        foreach (var z in dzial.CzasPracyZakres)
                        {
                            if (z.Status == "nowy") {
                                KalendarzDniRoboczychZakres zNew = new KalendarzDniRoboczychZakres
                                {
                                    CzasDuration = z.CzasDuration,
                                    CzasEnd = new DateTime(dR.Year, dR.Month, dR.Day, z.CzasEnd.Hour, z.CzasEnd.Minute, 0),
                                    CzasStart = new DateTime(dR.Year, dR.Month, dR.Day, z.CzasStart.Hour, z.CzasStart.Minute, 0),
                                    KalendarzDniRoboczychDzialProd = prodMod,
                                    Uwagi = z.Uwagi
                                };
                                db.KalendarzDniRoboczychZakres.Add(zNew);
                            };
                            if (z.Status == "usuniety") {
                                var zMod = db.KalendarzDniRoboczychZakres.Find(z.KalendarzDniRoboczychZakresId);
                                if (zMod != null)
                                {
                                    db.KalendarzDniRoboczychZakres.Remove(zMod);
                                }
                            }
                        }
                        prodMod.CzyKalendarzDniRoboczychZakresAktywny = true;
                    }

                    if(prodMod!=null && dzial.CzasPracyDuration==null) {

                        db.KalendarzDniRoboczychDzialProd.Remove(prodMod);
                    }



        
                }
                if (kMod.KalendarzDniRoboczychDzialProd.Count == 0) {
                    db.KalendarzDniRoboczych.Remove(kMod);
                }
            }


            db.SaveChanges();


            return Ok(new { info = $"Dane zostały zapisane, Id: {id}" });
        }






        [Route("api/KalendarzDniRoboczych/Szablon")]
        [HttpPost]
        [ResponseType(typeof(KalendarzDniRoboczychSzablonDTO))]
        public IHttpActionResult PostKalendarzDniRoboczychSzablon(KalendarzDniRoboczychSzablonDTO szablonDTO)
        {

            if (szablonDTO.Nazwa == null) {
                return BadRequest("Przesłany obiekt jest nieprawidłowy..");
            }
            

            KalendarzDniRoboczychSzablon szablon = new KalendarzDniRoboczychSzablon
            {
                Nazwa = szablonDTO.Nazwa                
            };

            db.KalendarzDniRoboczychSzablon.Add(szablon);

            KalendarzDniRoboczychDzialProd prod = new KalendarzDniRoboczychDzialProd
            {
                ProdukcjaDzialRefId=szablonDTO.DzialProdukcyjny.ProdukcjaDzial.ProdukcjaDzialId,
                KalendarzDniRoboczychSzablon=szablon
            };
            db.KalendarzDniRoboczychDzialProd.Add(prod);
//            szablon.KalendarzDniRoboczychDzialProdRefId = prod.KalendarzDniRoboczychDzialProdId;

            foreach (var z in szablonDTO.DzialProdukcyjny.CzasPracyZakres)
            {
                db.KalendarzDniRoboczychZakres.Add(new KalendarzDniRoboczychZakres
                {
                    CzasDuration = z.CzasDuration,
                    CzasEnd = z.CzasEnd,
                    CzasStart = z.CzasStart,
                    KalendarzDniRoboczychDzialProd = prod,
                    Uwagi = z.Uwagi
                });
            }



            db.SaveChanges();

            KalendarzDniRoboczychSzablonDTO result = new KalendarzDniRoboczychSzablonDTO
            {
                Nazwa = szablon.Nazwa,
                KalendarzDniRoboczychSzablonId = szablon.KalendarzDniRoboczychDzialProdId,
                DzialProdukcyjny = new KalendarzDniRoboczychDzialProdDTO
                {
                    CzasPracyZakres = szablon.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczychZakres.Select(s => new KalendarzDniRoboczychZakresDTO()
                    {
                        CzasDuration=s.CzasDuration,
                        CzasEnd=s.CzasEnd,
                        CzasStart=s.CzasStart,
                        KalendarzDniRoboczychZakresId=s.KalendarzDniRoboczychZakresId,
                        Status="nowy",
                        Uwagi=s.Uwagi,
                    }).ToList()

                }
            };


            return Ok(new { info= $"greeejt ! szablonID: "+szablon.KalendarzDniRoboczychDzialProdId, result });
        }


        [Route("api/KalendarzDniRoboczych/Szablon")]
        [HttpGet]
        public IHttpActionResult GetKalendarzDniRoboczychSzablon()
        {
            var result=from szablon in db.KalendarzDniRoboczychSzablon select new KalendarzDniRoboczychSzablonDTO() {
                Nazwa = szablon.Nazwa,
                KalendarzDniRoboczychSzablonId = szablon.KalendarzDniRoboczychDzialProdId,
                DzialProdukcyjny = new KalendarzDniRoboczychDzialProdDTO
                {
                    CzasPracyZakres = szablon.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczychZakres.Select(s => new KalendarzDniRoboczychZakresDTO()
                    {
                        CzasDuration = s.CzasDuration,
                        CzasEnd = s.CzasEnd,
                        CzasStart = s.CzasStart,
                        KalendarzDniRoboczychZakresId = s.KalendarzDniRoboczychZakresId,
                        Status = "nowy",
                        Uwagi = s.Uwagi,
                    }).ToList(),
                    KalendarzDniRoboczychDzialProdId=szablon.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczychDzialProdId,
                    Status="nowy"
                },
                Status="nowy"
            };

            return Ok(new { info = "Dane wygenerowane prawidłowo", result });
        }

        [Route("api/KalendarzDniRoboczych/Szablon/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteKalendarzDniRoboczychSzablon(int id)
        {

            var dzial = db.KalendarzDniRoboczychDzialProd.Find(id);


            if (dzial == null) {
                return BadRequest($"Nie znaleziono szablonu o Id: {id}");
            }
            //var prod = db.KalendarzDniRoboczychDzialProd.Find(szablon.FirstOrDefault().KalendarzDniRoboczychDzialProdRefId);
            //db.KalendarzDniRoboczychDzialProd.Remove(prod);
            db.KalendarzDniRoboczychDzialProd.Remove(dzial);
            db.SaveChanges();



            return Ok(new { info = $"Szablon o Id: {id} został usunięty" });
        }


        [Route("api/KalendarzDniRoboczych/WorkingDayByDate")]
        [HttpPost]
        public IHttpActionResult PostWorkingDayByDate(DateRangeDTO dateRange)
        {
            var workingDay= Pomocne.DateHelpful.dataStalaGodzina(dateRange.DateStart);

            var workingDayId = (from d in db.KalendarzDniRoboczych where d.DzienRoboczy == workingDay select d.KalendarzDniRoboczychId).FirstOrDefault();


            var responseStr = workingDayId > 0 ? "Znaleziono workingDay o Id: " + workingDayId : "Nie znaleziono workingDay w dniu "+dateRange.DateStart.ToShortDateString();

            return Ok(new { info=responseStr, workingDayId} );
        }


        [HttpDelete]
        public IHttpActionResult DeleteKalendarzDniRoboczych(int id)
        {

            var dzien = db.KalendarzDniRoboczych.Find(id);


            if (dzien == null)
            {
                return BadRequest($"Nie znaleziono dnia roboczego o Id: {id}");
            }
            //var prod = db.KalendarzDniRoboczychDzialProd.Find(szablon.FirstOrDefault().KalendarzDniRoboczychDzialProdRefId);
            //db.KalendarzDniRoboczychDzialProd.Remove(prod);
            db.KalendarzDniRoboczych.Remove(dzien);
            db.SaveChanges();



            return Ok(new { info = $"Dzień roboczy o Id: {id} został usunięty" });
        }










        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KalendarzDniRoboczychSzablonExists(int id)
        {
            return db.KalendarzDniRoboczychSzablon.Count(e => e.KalendarzDniRoboczychDzialProdId == id) > 0;
        }




    }
}