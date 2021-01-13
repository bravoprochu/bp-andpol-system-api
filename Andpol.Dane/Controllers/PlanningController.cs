using Andpol.Dane.Pomocne.NormaExt;
using Andpol.Dane.Pomocne.PlanningExt;
using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using Andpol.Dane.Pomocne;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ZuzycieMaterialu.Zuzycie;

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles = "Planning")]
    [EnableCors("*", "*", "*")]

    public class PlanningController : ApiController
    {

        private PoligonContext db = new PoligonContext();
        // GET: api/Planning

        public IHttpActionResult GetPlanning()
        {

            var result = this.mPlanningList();

            return Ok(result);
        }

        // GET: api/Planning/5
        public IHttpActionResult Get(int id)
        {

            var result = mPlanningList().Where(w => w.PlanningId == id).Select(s => s).FirstOrDefault();
            if (result == null)
            {
                return BadRequest($"Nie znaleziono planningu o ID: {id}");
            }

            return Ok(result);
        }

        // PUT: api/Planning/5

        public IHttpActionResult PutPlanning(int id)
        {

            return Ok();

            //if (id > 0 && pDTO.Status == "zmieniony")
            //{
            //    Planning pMod = db.Planning.Find(id);
            //    if (pMod != null)
            //    {
            //        pMod.ProdukcjaStart = pDTO.ProdukcjaStart;
            //        pMod.ProdukcjaEnd = pDTO.ProdukcjaEnd;
            //        pMod.Uwagi = pDTO.Uwagi;
            //        db.SaveChanges();
            //        return Ok();
            //    }
            //    else
            //    {
            //        return BadRequest("Nie znaleziono Planningu o ID " + id.ToString());
            //    }

            //}

            //if (id == 0 && pDTO.Id == 0)
            //{
            //    Planning pNew = new Planning();
            //    pNew.ProdukcjaEnd = pDTO.ProdukcjaEnd;
            //    pNew.ProdukcjaStart = pDTO.ProdukcjaStart;
            //    pNew.Uwagi = pDTO.Uwagi;

            //    db.Planning.Add(pNew);
            //    db.SaveChanges();
            //    id = pNew.Id;
            //}

            //foreach (var pMat in pDTO.PlanningMaterial)
            //{
            //    if (pMat.Status == "nowy")
            //    {
            //        PlanningMaterial pMatNew = new PlanningMaterial();
            //        pMatNew.MaterialRefId = pMat.Material.MaterialId;
            //        pMatNew.PlanningRefId = id;
            //        db.PlanningMaterial.Add(pMatNew);
            //        db.SaveChanges();
            //        pMat.PlanningMaterialId = pMatNew.PlanningMaterialId;
            //    }


            //    foreach (var pMatBelka in pMat.PlanningMaterialBelka)
            //    {
            //        MaterialBelka mBelka = db.MaterialBelka.Find(pMatBelka.MaterialBelka.Id);

            //        if (pMatBelka.Status == "nowy" && mBelka != null)
            //        {
            //            PlanningMaterialBelka pMatBelkaNew = new PlanningMaterialBelka();
            //            pMatBelkaNew.MaterialBelkaRefId = pMatBelka.MaterialBelka.Id;
            //            pMatBelkaNew.PlanningMaterialRefId = pMat.PlanningMaterialId;
            //            pMatBelkaNew.ZuzycieWartosc = pMatBelka.ZuzycieWartosc;
            //            db.PlanningMaterialBelka.Add(pMatBelkaNew);
            //            db.SaveChanges();
            //            pMatBelka.PlanningMaterialBelkaId = pMatBelkaNew.PlanningMaterialBelkaId;

            //            mBelka.StanAktualny -= pMatBelka.ZuzycieWartosc;

            //            foreach (var obszycie in pMatBelka.ListaObszyc)
            //            {
            //                ZamowienieKombiObszycie zobszMod = db.ZamowienieKombiObszycie.Find(obszycie.Id);
            //                zobszMod.PlanningMaterialBelkaRefId = pMatBelka.PlanningMaterialBelkaId;
            //            }
            //            db.SaveChanges();

            //        }

            //    }
            //}

            //foreach (var zam in pDTO.ZamowienieInfo)
            //{
            //    Zamowienie zamMod = db.Zamowienie.Find(zam.ZamowienieId);
            //    if (zamMod != null)
            //    {
            //        //zamMod.PlanningRefId = id;
            //    }
            //}
            //db.SaveChanges();








            //return Ok(id);

        }


        [HttpGet]
        [Route("api/planning/produkcjaDzial")]
        public IHttpActionResult GetProdukcjaDzial()
        {

            var result = db.ProdukcjaDzial.Select(s => new ProdukcjaDzialDTO
            {
                CzyPozycjaMagazynowa=s.CzyPozycjaMagazynowa,
                CzyTkaninaBelka=s.CzyTkaninaBelka,
                NadrzednyIds=s.NadrzedneIds,
                Nazwa=s.Nazwa,
                PoziomProdukcji=s.PoziomProdukcji,
                ProdukcjaDzialId=s.ProdukcjaDzialId,
                Uwagi=s.Uwagi
            }).ToList();

            return Ok(result);
        }


        [HttpDelete]
        [Route("api/planning/ProdukcjaDzial/{id}")]
        public IHttpActionResult DeleteProdukcjaDzial(int id)
        {

            var data = db.ProdukcjaDzial.Find(id);

            if (data!=null) {

                db.ProdukcjaDzial.Remove(data);
                db.SaveChanges();
            }

            return Ok(new { info = $"Dzial {data.Nazwa} został usunięty" });

        }

        [HttpPut]
        [Route("api/planning/ProdukcjaDzial/{id}")]
        public IHttpActionResult PutProdukcjaDzial(int id, ProdukcjaDzialDTO produkcjaDzial)
        {
            if (!ModelState.IsValid) {
                return BadRequest("Błędny format przesłanych danych");
            }

            if (id == 0)
            {
                var data = new ProdukcjaDzial();
                if (produkcjaDzial.PoziomProdukcji == 1)
                {
                    data.CzyPozycjaMagazynowa = produkcjaDzial.CzyPozycjaMagazynowa;
                    data.CzyTkaninaBelka = produkcjaDzial.CzyTkaninaBelka;
                    data.NadrzedneIds = "";
                }
                else {
                    data.CzyPozycjaMagazynowa = false;
                    data.CzyTkaninaBelka = false;
                    data.NadrzedneIds = produkcjaDzial.NadrzednyIds;
                }
                
                data.Nazwa = produkcjaDzial.Nazwa;
                data.PoziomProdukcji = produkcjaDzial.PoziomProdukcji;
                data.Uwagi = produkcjaDzial.Uwagi;

                db.ProdukcjaDzial.Add(data);
                db.SaveChanges();
                return Ok(new { info = $"Dział {produkcjaDzial.Nazwa} został dodany do bazy", data =data });

            }
            else
            {
                var data = db.ProdukcjaDzial.Where(w => w.ProdukcjaDzialId == id).FirstOrDefault();

                if (produkcjaDzial.PoziomProdukcji == 1)
                {
                    data.CzyPozycjaMagazynowa = produkcjaDzial.CzyPozycjaMagazynowa;
                    data.CzyTkaninaBelka = produkcjaDzial.CzyTkaninaBelka;
                    data.NadrzedneIds = "";
                }
                else
                {
                    data.CzyPozycjaMagazynowa = false;
                    data.CzyTkaninaBelka = false;
                    data.NadrzedneIds = produkcjaDzial.NadrzednyIds;
                }
                data.Nazwa = produkcjaDzial.Nazwa;
                data.PoziomProdukcji = produkcjaDzial.PoziomProdukcji;
                data.Uwagi = produkcjaDzial.Uwagi;

                db.SaveChanges();
                return Ok(new { info = $"Dział {produkcjaDzial.Nazwa} został zaktualizowany", data = data });
            }


            
        }


        [HttpGet]
        [Route("api/Planning/PlanningRaport")]
        public IHttpActionResult GetPlanningRaport(PlanningRaportDTO raportInput)
        {
            //            var tkaninaBelka=raportInput.CzyTkaninaBelka==false ? null: (from ptb in db.PlanningTkaninaBelka



            return Ok();
        }



        // DELETE: api/Planning/5
        public IHttpActionResult Delete(int id)
        {
            var belki = db.PlanningTkaninaBelka.Where(w => w.PlanningRefId == id).Select(s => s).ToList();

            foreach (var belka in belki)
            {
                var matBelkaBaza = db.MaterialBelka.Find(belka.MaterialBelkaRefId);
                matBelkaBaza.StanAktualny += belka.Wartosc;
                matBelkaBaza.StanRzeczywisty += belka.Wartosc;
            }

            var pozycjeMagazynowe = db.PlanningPozycjaMagazynowa.Where(w => w.PlanningRefId == id).Select(s => s).ToList();
            foreach (var pozMag in pozycjeMagazynowe)
            {
                var pozycjaMagBaza = db.MagPozycjaMagazynowa.Find(pozMag.PozycjaMagazynowaRefId);
                pozycjaMagBaza.StanAktualny += pozMag.Wartosc;
                pozycjaMagBaza.StanRzeczywisty += pozMag.Wartosc;
            }

            var kalendarzDzialProdIdsList = db.PlanningDzienRoboczy.Where(w => w.PlanningRefId == id).Select(s => s.KalendarzDniRoboczychDzialProdRefId).ToList();
            foreach (var dzienId in kalendarzDzialProdIdsList)
            {
                var dzien = db.KalendarzDniRoboczychDzialProd.Find(dzienId);
                dzien.CzyKalendarzDniRoboczychZakresAktywny = true;
            }


            db.Planning.Remove(db.Planning.Find(id));
            db.SaveChanges();


            return Ok(new { info = $"Ok, usunięte id: {id}" });
        }



        [Route("api/Planning/Belki")]
        [HttpGet]
        public IHttpActionResult GetDanePomocniczeBelki()
        {
            var result = (from mb in db.MaterialBelka
                          where mb.CzyPotwierdzona == true
                          group mb by mb.MaterialRefId into materialBelkaGroup
                          select new
                          {
                              MaterialRefId = materialBelkaGroup.Key,
                              MaterialBelkaId = materialBelkaGroup.Select(x => x.MaterialBelkaId),
                              StanPoczatkowyAllWartosc = materialBelkaGroup.Sum(x => x.StanPoczatkowy),
                              StanPoczatkowyAllIloscElementoww = materialBelkaGroup.Count(),
                              StanAktualny = materialBelkaGroup.Sum(x => x.StanPoczatkowy),
                              RozchodInne = (from ri in db.MaterialBelkaRozchodInne
                                             where ri.MaterialBelka.MaterialRefId == materialBelkaGroup.Key
                                             group ri by ri.MaterialBelkaRefId into mbriGroup
                                             select new
                                             {
                                                 RozchodInneId = mbriGroup.Key,
                                                 Nazwa = (from n in mbriGroup select n.MaterialBelka.Material.Nazwa).Distinct(),
                                                 WartoscRazem = (from m in mbriGroup select m.Wartosc).Sum(),
                                                 //IloscElementow = (from m in mbriGroup select m.Wartosc).Count(),



                                             }),
                              RozchodObszycie = (from mbro in db.MaterialBelkaRozchodObszycie
                                                 where mbro.MaterialBelka.MaterialRefId == materialBelkaGroup.Key
                                                 group mbro by mbro.MaterialBelkaRefId into mbroGroup
                                                 select new
                                                 {
                                                     RozchodObszycieId = mbroGroup.Key,
                                                     WartoscRazemm = mbroGroup.Sum(x => x.ZamowienieObszycie.KombinacjeObszycie.Dlugosc),


                                                 }),

                              BelkiSzczegoly = (from b in materialBelkaGroup
                                                select new
                                                {
                                                    MaterialBelkaId = b.MaterialBelkaId,
                                                    StanPoczatkowy = b.StanPoczatkowy,
                                                    RozchodInne = (from ri in db.MaterialBelkaRozchodInne
                                                                   where ri.MaterialBelkaRefId == b.MaterialBelkaId
                                                                   group ri by ri.MaterialBelkaRefId into rozchodGroup
                                                                   select new
                                                                   {
                                                                       RozchodWartosc = (from r in rozchodGroup select r.Wartosc).Sum()
                                                                   }),
                                                    RozchodObszycie = (from ro in db.MaterialBelkaRozchodObszycie
                                                                       where ro.MaterialBelkaRefId == b.MaterialBelkaId
                                                                       group ro by ro.MaterialBelkaRefId into rozchodGroup
                                                                       select new
                                                                       {
                                                                           RozchodWartosc = (from r in rozchodGroup select r.ZamowienieObszycie.KombinacjeObszycie.Dlugosc).Sum()
                                                                       })

                                                })

                          }).ToList();




            return Ok(result);
        }


        [Route("api/planning/RealizacjaTkaniny")]
        [HttpPost]
        public IHttpActionResult PostRealizacjaTkaniny(PlanningTkaninaBelkaRaportInputDTO test)
        {
            List<PlanningTkaninaBelkaRaportDTO> obszyciaByBelka = new List<PlanningTkaninaBelkaRaportDTO>();
            var planningByDate = mPlanningIdByDate(test.DzienRoboczy );
            if (planningByDate.Id > 0) { 
                obszyciaByBelka=mRealizacjaTkaniny(test.DzienRoboczy, planningByDate.Id);
            } 



            return Ok(new { ObszyciaByBelka=obszyciaByBelka, planningInfo=planningByDate});
        }


        [Route("api/planning/RealizacjaTkaninyUpdate")]
        [HttpPost]
        public IHttpActionResult PostRealizacjaTkaninyUpdate(List<PlanningTkaninaBelkaRaportDTO> input)
        {
            var zamKombiListaZmienione = new List<int>();
            var kombinacjeIds = new List<int>();
            int planningRefId=0;
            int updatedItems = 0;

            foreach (var belka in input)
            {
                foreach (var obsz in belka.ListaObszyc)
                {
                    if (obsz.Status == "zmieniony") {
                        var obszycieToUpdate = db.PlanningTkaninaBelkaListaObszyc
                            .Include(i=>i.ZamowienieKombiObszycie.ZamowienieKombi)
                            .Include(i=>i.PlanningTkaninaBelka)
                            .Where(w=>w.PlanningTkaninaBelkaListaObszycId==obsz.PlanningTkaninaBelkaListaObszycId)
                            .Select(s=>s).FirstOrDefault();

                        obszycieToUpdate.IsDone = obsz.IsDone;
                        zamKombiListaZmienione.Add(obszycieToUpdate.ZamowienieKombiObszycie.ZamowienieKombiRefId);
                        planningRefId = obszycieToUpdate.PlanningTkaninaBelka.PlanningRefId;
                        kombinacjeIds.Add(obszycieToUpdate.ZamowienieKombiObszycie.ZamowienieKombi.KombinacjaRefId);
                        updatedItems++;
                    }
                }
            }

            db.SaveChanges();


            var kombinacjeObszycieBaza = db.KombinacjaObszycie.WhereIn(wi => wi.KombinacjaRefId, kombinacjeIds.GroupBy(gwi => gwi).Select(swig => swig.FirstOrDefault())).GroupBy(g => g.KombinacjaRefId).Select(sg => new
            {
                KombiRefId = sg.Key,
                KombinacjaNazwa = sg.Select(s => s.Kombinacja.NazwaKombinacji.Nazwa).FirstOrDefault(),
                ListaObszyc = sg.Select(s => s).ToList()
            }).ToList();

            var kombinacjaObszycieBazaByZamowienieKombi = db.PlanningTkaninaBelkaListaObszyc.WhereIn(wi => wi.ZamowienieKombiObszycie.ZamowienieKombiRefId, zamKombiListaZmienione).GroupBy(g => g.ZamowienieKombiObszycie.ZamowienieKombiRefId).Select(sg => new
            {
                ZamowienieKombiRefId = sg.Key,
                KombiRefId = sg.Select(s => s.ZamowienieKombiObszycie.KombinacjeObszycie.KombinacjaRefId).FirstOrDefault(),
                KombinacjaNazwa = sg.Select(s => s.ZamowienieKombiObszycie.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa).FirstOrDefault(),
                ListaObszyc = sg.Where(w => w.IsDone == true).Select(s => s).ToList(),
            }).ToList();

            var zamKombiListaZmienioneGrouped = zamKombiListaZmienione.GroupBy(g => g).Select(s => s.FirstOrDefault()).ToList();

            //lista zamowienieKombi Id's w ktorych zmienil sie status przynajmniej jednego z obszyc
            foreach (var zam in kombinacjaObszycieBazaByZamowienieKombi)
            {
                var foundInBaza = kombinacjeObszycieBaza.Where(w => w.KombiRefId == zam.KombiRefId).Select(s => s).FirstOrDefault();
                var planningZamowienieKombi = db.PlanningDzienRoboczyZamowienieKombi.Where(w => w.PlanningDzienRoboczy.PlanningRefId == planningRefId && w.ZamowienieKombiRefId == zam.ZamowienieKombiRefId).Select(s=>s).FirstOrDefault();
                if (planningZamowienieKombi != null)
                {
                    if (zam.ListaObszyc.Count < foundInBaza.ListaObszyc.Count)
                    {
                        planningZamowienieKombi.IsDone = false;
                        planningZamowienieKombi.BrygadzistaNazwa = User.Identity.Name;
                        System.Diagnostics.Debug.WriteLine($"{zam.KombinacjaNazwa}, baza: {foundInBaza.ListaObszyc.Count}, planning: {zam.ListaObszyc.Count}");
                    }
                    else
                    {
                        planningZamowienieKombi.IsDone = true;
                        planningZamowienieKombi.BrygadzistaNazwa = User.Identity.Name;
                    }
                }
                else {

                    System.Diagnostics.Debug.WriteLine($"Nie znalazlem zamKombi dla kombinacji {zam.KombinacjaNazwa}");
                    var brakujaca = db.PlanningTkaninaBelkaListaObszyc.Where(w => w.ZamowienieKombiObszycie.KombinacjeObszycie.Obszycie.Nazwa == zam.KombinacjaNazwa).Select(s => s.ZamowienieKombiObszycie.ZamowienieKombiRefId).ToList();
                }


            }

            db.SaveChanges();


            var result = mRealizacjaTkaniny(db.Planning.Where(w => w.PlanningId == planningRefId).Select(s => s.PlanningDzienRoboczy.Where(ws => ws.PlanningRefId == planningRefId).Select(sw => sw.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy).FirstOrDefault()).Select(s => s).FirstOrDefault(), planningRefId);

            return Ok(new { info = $"Dane zostały zaktualizowane, łącznie: {updatedItems}", result = result });
        }




        [Route("api/Planning/PlanningKalendarz")]
        [HttpPost]
        public IHttpActionResult PostPlanningKalendarz(PlanningKalendarzInput input)
        {
            int produkcjaDzialId = input.ProdukcjaDzial.ProdukcjaDzialId;
            var zamowieniaIds = input.ZamowieniaIds;
            var dzienRoboczyStart = input.DzienRoboczyZakres.CzasStart;
            var dzienRoboczyEnd = input.DzienRoboczyZakres.CzasEnd > dzienRoboczyStart ? input.DzienRoboczyZakres.CzasEnd : dzienRoboczyStart.AddYears(1);

            if (zamowieniaIds.Count == 0) {
                return BadRequest("Nie wskazano listy zamowienieKombi, planning nie może zostać przeliczony");
            }

            //var allZamowieniaIds = db.ZamowienieKombi.Select(s => s.ZamowienieKombiId).ToList();
            //bool allZamowieniaFits = true;
            //for (int i = 0; i < zamowieniaIds.Count; i++)
            //{
            //    if (!allZamowieniaIds.Any(a => a == zamowieniaIds[i])) {
            //        allZamowieniaFits = false;
            //        break;
            //    }
            //}

            var elementyDoZaplanowania = (from zk in db.ZamowienieKombi.WhereIn(zw => zw.ZamowienieKombiId, zamowieniaIds).Where(w => !w.Kombinacja.NazwaKombinacji.Nazwa.StartsWith("  "))
                                          select new ElementDoZaplanowania
                                          {
                                              KombinacjaId = zk.KombinacjaRefId,
                                              Nazwa = zk.Kombinacja.NazwaKombinacji.Nazwa,
                                              RobociznaWartosc = zk.Kombinacja.KombinacjaRobocizna.Where(wr => wr.ProdukcjaDzialRefId == produkcjaDzialId).Select(sr => sr.Wartosc).FirstOrDefault(),
                                              GrupaRobocza = zk.Kombinacja.KombinacjaRobocizna.Where(wg => wg.ProdukcjaDzialRefId == produkcjaDzialId).Select(sr => new GrupaRoboczaDTO()
                                              {
                                                  ProdukcjaDzialId = produkcjaDzialId,
                                                  ProdukcjaDzialNazwa = input.ProdukcjaDzial.Nazwa,
                                                  Stanowiska = sr.KombinacjaRobociznaGrupaRobocza.Where(ws => ws.KombinacjaRobocizna.ProdukcjaDzialRefId == produkcjaDzialId).Select(ss => new RobociznaStanowiskoDTO()
                                                  {
                                                      RobociznaId = ss.RobociznaRefId,
                                                      RobociznaNazwa = ss.Robocizna.Nazwa,
                                                      Wartosc = ss.Wartosc
                                                  }).ToList(),
                                              }).FirstOrDefault(),
                                              ZamowienieKombiId = zk.ZamowienieKombiId
                                          })
                                        .OrderByDescending(o => o.RobociznaWartosc).ThenBy(o => o.GrupaRobocza.Stanowiska.Count)
                                        .ToList();





            var zakresy = (from kdrz in db.KalendarzDniRoboczychZakres.Where(
                w => w.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy >= input.DzienRoboczyZakres.CzasStart &&
                w.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy <= dzienRoboczyEnd &&
                w.KalendarzDniRoboczychDzialProd.ProdukcjaDzialRefId == produkcjaDzialId &&
                w.KalendarzDniRoboczychDzialProd.CzyKalendarzDniRoboczychZakresAktywny==true
                )
                           select new ZakresDTO
                           {
                               CzasZakres = new CzasZakres
                               {
                                   CzasStart = kdrz.CzasStart,
                                   CzasEnd = kdrz.CzasEnd
                               },
                               KalendarzDniRoboczychId = kdrz.KalendarzDniRoboczychDzialProdId,
                               GrupaRobocza = new GrupaRoboczaDTO()
                               {
                                   ProdukcjaDzialId = kdrz.KalendarzDniRoboczychDzialProd.ProdukcjaDzialRefId,
                                   ProdukcjaDzialNazwa = kdrz.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.Nazwa,
                                   Stanowiska = kdrz.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad.Where(wg => wg.KalendarzDniRoboczychDzialProdRefId == kdrz.KalendarzDniRoboczychDzialProdId).Select(s => new RobociznaStanowiskoDTO()
                                   {
                                       RobociznaId = s.RobociznaRefId,
                                       RobociznaNazwa = s.Robocizna.Nazwa,
                                       Wartosc = s.Ilosc

                                   }).ToList()
                               }
                               

                           }).OrderBy(o => o.CzasZakres.CzasStart).ToList();





            List<string> errorList = new List<string>();
            var elementyDoZaplanowaniaZeSkladem = new List<ElementDoZaplanowania>();
            var zakresyZeSkladem = new List<ZakresDTO>();
            //pusty zakres:
            if (zakresy.Count == 0) { errorList.Add("Brak zakresów"); }
            //czy zakresy maja przypisany sklad:

            foreach (var z in zakresy)
            {
                if (z.GrupaRobocza.Stanowiska.Count == 0)
                {
                    errorList.Add($"Brak dostępnego składu w dniu: {z.CzasZakres.CzasStart.ToShortDateString()}");
                }
                else
                {
                    zakresyZeSkladem.Add(z);
                }
            }
            //czy elementy maja sklad normy

            foreach (var el in elementyDoZaplanowania)
            {
                if (el.GrupaRobocza == null)
                {
                    errorList.Add($"Element {el.Nazwa} nie ma przypisanej grupy roboczej (Norma)");
                }
                else
                {
                    elementyDoZaplanowaniaZeSkladem.Add(el);
                }
            }




            if (zakresyZeSkladem.Count > 0 && errorList.Count == 0 && elementyDoZaplanowaniaZeSkladem.Count > 0)
            {
                var planning = new PlanningKalendarzDzienZakres(zakresyZeSkladem, elementyDoZaplanowaniaZeSkladem);
                return Ok(planning);
            }
            else
            {
                return Ok(new
                {
                    PlanningZakres = new CzasZakres
                    {
                        CzasStart = dzienRoboczyStart,
                        CzasEnd = dzienRoboczyEnd
                    },
                    ProdukcjaDzial = input.ProdukcjaDzial,
                    Errors = errorList.GroupBy(g => g).ToList().Select(s => s.Key)
                });
            }
        }




        [HttpPost]
        [Route("api/Planning/RaportPrzelicz")]
        public IHttpActionResult PostPlanningKalendarzRaportUpdate(PlanningRaportUpdateDTO raportToUpdate)
        {
            //1. raportShort - raport
            var elementyZaplanowaneRazem = new List<ElementZaplanowany>();

            foreach (var dzien in raportToUpdate.PlanningDniRobocze)
            {
                elementyZaplanowaneRazem.AddRange(dzien.RaportZaplanowane);
            }

            RaportShort raport = new RaportShort() {
                Zaplanowane = StringHelpful.StringListGroup(elementyZaplanowaneRazem.Select(s => s.ElementBaza.Nazwa).ToList())
            };

            //2. materiałowka - pozycjeMagazynowe
            var kombinacjeIdsDistinct = elementyZaplanowaneRazem.GroupBy(g => g.ElementBaza.KombinacjaId).Select(s => new {
                Key=s.Key,
                Count=s.Count(),
                ElementZaplanowany=s.Select(se=>se.ElementBaza).FirstOrDefault(),
            }).ToList().Select(sg => sg).ToList();
            //{
            //    Key = s.Key,
            //    ElementBaza = s.Select(se => se.ElementBaza).FirstOrDefault()
            //}).ToList();

            var pozycjaMagazynowaResult = new List<PlanningPozycjaMagazynowaDTO>();
            var planningPozycjeMagazynowe = new List<PlanningRaportPozycjeMagazynoweDTO>();

            if (raportToUpdate.ProdukcjaDzial.CzyPozycjaMagazynowa == true)
            {

                //unikalne pozycje magazynowe, wartosc przemnozona przez ilosc elelmentow z kombi
                var pozycjeMagazynowe = db.KombinacjaPozycjaMagazynowa.WhereIn(wi => wi.KombinacjaRefId, elementyZaplanowaneRazem.Select(sk => sk.ElementBaza.KombinacjaId).ToList())
                    .GroupBy(g => g.KombinacjaPozycjaMagazynowaId)
                    .Select(sg => new PlanningPozycjaMagazynowaDTO()
                    {

                        Jednostka = sg.Select(s => s.MagPozycjaMagazynowa.JednostkaMiary.Nazwa).FirstOrDefault(),
                        KombinacjaRefId = sg.Select(s => s.KombinacjaRefId).FirstOrDefault(),
                        Nazwa = sg.Select(s => s.MagPozycjaMagazynowa.Nazwa).FirstOrDefault(),
                        PozycjaMagazynowaId = sg.Select(s => s.MagPozycjaMagazynowaRefId).FirstOrDefault(),
                        StanAktualny = sg.Select(s => s.MagPozycjaMagazynowa.StanAktualny.Value).FirstOrDefault(),
                        Wartosc = sg.Select(s => s.Wartosc).FirstOrDefault()
                    }).ToList();


                foreach (var pozMag in pozycjeMagazynowe)
                {
                    pozMag.Wartosc = pozMag.Wartosc * kombinacjeIdsDistinct.Where(w => w.ElementZaplanowany.KombinacjaId == pozMag.KombinacjaRefId).Select(s => s.Count).FirstOrDefault();
                }

                pozycjaMagazynowaResult = pozycjeMagazynowe.GroupBy(g => g.PozycjaMagazynowaId).Select(sg => new PlanningPozycjaMagazynowaDTO
                {
                    Jednostka = sg.Select(s => s.Jednostka).FirstOrDefault(),
                    KombinacjaRefId = sg.Select(s => s.KombinacjaRefId).FirstOrDefault(),
                    Nazwa = sg.Select(s => s.Nazwa).FirstOrDefault(),
                    PozycjaMagazynowaId = sg.Select(s => s.PozycjaMagazynowaId).FirstOrDefault(),
                    StanAktualny = sg.Select(s => s.StanAktualny).FirstOrDefault(),
                    Wartosc = sg.Sum(s => s.Wartosc)

                }).ToList();


                //.GroupBy(g => g.PozycjaMagazynowaId).Select(sg => new PlanningPozycjaMagazynowaDTO()
                //{
                //    Jednostka = sg.FirstOrDefault().Jednostka,
                //    KombinacjaRefId = sg.FirstOrDefault().KombinacjaRefId,
                //    Nazwa = sg.FirstOrDefault().Nazwa,
                //    PozycjaMagazynowaId = sg.FirstOrDefault().PozycjaMagazynowaId,
                //    StanAktualny = sg.FirstOrDefault().StanAktualny,
                //    Wartosc = sg.Sum(sum => sum.Wartosc)
                //}).ToList();



                //planningPozycjeMagazynowe = pozycjeMagazynowe.GroupBy(g => g.PozycjaMagazynowaId).Select(spm => new PlanningRaportPozycjeMagazynoweDTO
                //{
                //    PlanningPozycjaMagazynowaId = spm.Key,
                //    PozycjeMagazynowe = spm.Select(s => new PlanningPozycjaMagazynowaDTO
                //    {
                //        Jednostka = s.Jednostka,
                //        KombinacjaRefId = s.KombinacjaRefId,
                //        Nazwa = s.Nazwa,
                //        PozycjaMagazynowaId = s.PozycjaMagazynowaId,
                //        StanAktualny = s.StanAktualny,
                //        Wartosc = s.Wartosc
                //    }).FirstOrDefault()
                //}).ToList();
            }

            var pozycjeMagazynoweRaport = new
                {
                    CzyPozycjeMagazynoweZapewnione = pozycjaMagazynowaResult.All(a => a.CzyStanOk),
                    PozycjeMagazynowe = pozycjaMagazynowaResult,
                    Braki = pozycjaMagazynowaResult.Where(w => w.CzyStanOk == false).Select(s => s)
                };



            // 3. TkaninyBelka

            var zamowienia = (from zko in db.ZamowienieKombiObszycie.WhereIn(w => w.ZamowienieKombi.ZamowienieKombiId, elementyZaplanowaneRazem.Select(sko=>sko.ElementBaza.ZamowienieKombiId).ToList())
                              group zko by zko.Material.MaterialId into obszycieG
                              select new ZamowienieRaportMaterialDTO
                              {
                                  Material = obszycieG.Select(m => m.Material).FirstOrDefault(),
                                  ObszycieIlosc = obszycieG.Count(),
                                  Obszycie = obszycieG.Select(o => (new ZamowienieRaportObszycieWynikDTO
                                  {
                                      ObszycieId = o.ZamowienieKombiObszycieId,
                                      Nazwa = o.ZamowienieKombi.Zamowienie.ZamowienieNr + ", [" + o.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa + " (" + o.ZamowienieKombiRefId + ")]" + o.KombinacjeObszycie.Obszycie.Nazwa,
                                      Dlugosc = o.KombinacjeObszycie.Dlugosc,
                                      Szerokosc = o.KombinacjeObszycie.Szerokosc,
                                      Uwagi = o.Uwagi,
                                  })).OrderBy(o => o.Nazwa).ToList()
                              }).ToList();

            var materialBelka = (from mb in db.MaterialBelka.WhereIn(w => w.MaterialRefId, zamowienia.Select(sm => sm.Material.MaterialId)).Where(wm => wm.CzyAktywna == true && wm.CzyPotwierdzona == true)
                                 select new MaterialBelkaShortDTO
                                 {
                                     DataPrzyjecia = mb.DataPrzyjecia,
                                     Id = mb.MaterialBelkaId,
                                     Material = new MaterialDTO() { MaterialId = mb.Material.MaterialId, Nazwa = mb.Material.Nazwa },
//                                     MaterialSource=mb.Material,
                                     Nazwa = mb.MaterialBelkaId.ToString() + " - " + mb.Material.Nazwa + " - " + mb.Material.MaterialGrupa.Nazwa,
                                     StanAktualny = mb.StanAktualny,
                                     Uwagi = mb.Uwagi
                                 }).ToList();


            foreach (var zam in zamowienia)
            {
                List<ProstokatBaseClass> obszycia = new List<ProstokatBaseClass>();
                foreach (var obsz in zam.Obszycie)
                {
                    obszycia.Add(new ProstokatBaseClass((int)obsz.Dlugosc, (int)obsz.Szerokosc, 0, 0, obsz.Nazwa, obsz.ObszycieId));
                }
                zam.Obszycie = null;
                //                zam.Wynik = new ProstokatParent(zamowienieRaport.ProstokatBaza, obszycia, true);

//              var wynik = new ProstokatParent(zamowienieRaport.ProstokatBaza, obszycia, true);

                var wynik = new ProstokatParent(new ProstokatBaseClass(10000,(int)zam.Material.SzerokoscBelki,0,0)
                    
                , obszycia, true);

                ZuzycieMaterialGrupaDTO zuzycieMatGrupa = new ZuzycieMaterialGrupaDTO();
                zuzycieMatGrupa.Baza = new ProstokatBaseClass(wynik.Dlugosc, wynik.Szerokosc);
                zuzycieMatGrupa.Zuzycie = wynik.Zuzycie;
                zuzycieMatGrupa.ListaObszyc = new List<ProstokatBaseClass>();
                zuzycieMatGrupa.Status = "nowy";
                foreach (var obsz in wynik.ObszycieRozlozenie)
                {
                    zuzycieMatGrupa.ListaObszyc.Add(new ProstokatBaseClass(obsz.Dlugosc, obsz.Szerokosc, obsz.PosStartX, obsz.PosStartY, obsz.Name, obsz.Id));
                }

                zam.PlanningMaterialBelka = new List<ZuzycieMaterialGrupaDTO>();
                zam.PlanningMaterialBelka.Add(zuzycieMatGrupa);


                //                double zuzycieDouble = Convert.ToDouble(zam.Wynik.Zuzycie);
                zam.MaterialBelkaDost = materialBelka.Where(w => w.Material.MaterialId == zam.Material.MaterialId).Select(mb => new MaterialBelkaShortDTO()
                {
                    Id = mb.Id,
                    
                    DataPrzyjecia = mb.DataPrzyjecia,
//                    MaterialSource=mb.MaterialSource,
                    Nazwa = "stan: " + mb.StanAktualny.ToString("0.00") + " mb" ,
                    StanAktualny = mb.StanAktualny,
                    Uwagi = mb.Uwagi,
                }).ToList();
                zam.Status = "nowy";
            }


            return Ok(new { Raport = raport, pozycjeMagazynowe = pozycjeMagazynoweRaport, tkaniny=zamowienia });
        }


 
        


        [HttpGet]
        [Route("api/planning/ProdukcjaDzialByPoziom")]
        public IHttpActionResult GetProdukcjaDzialByPoziom()
        {
            var result = db.ProdukcjaDzial.GroupBy(g => g.PoziomProdukcji).Select(s => new ProdukcjaDzialByPoziomDTO {
                PoziomProdukcji = s.Key,
                ProdukcjaDzial = s.Select(s2 => new ProdukcjaDzialDTO {
                    Nazwa=s2.Nazwa,
                    ProdukcjaDzialId=s2.ProdukcjaDzialId
                }).ToList(),
            }).ToList();





            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult PostPlanning(PlanningDTO dto)
        {
            if (dto.PlanningKalendarzZakres.Count == 0) {
                return BadRequest("Brak zaplanowanych zakresów");
            }

            var pNew = new Planning();

            foreach (var dzien in dto.PlanningKalendarzZakres)
            {
                PlanningDzienRoboczy pdr = new PlanningDzienRoboczy();
                pdr.KalendarzDniRoboczychDzialProdRefId = dzien.DzienRoboczyRefId;
                var dzialProd = db.KalendarzDniRoboczychDzialProd.Where(w => w.KalendarzDniRoboczychDzialProdId == pdr.KalendarzDniRoboczychDzialProdRefId).Select(s => s).FirstOrDefault();
                dzialProd.CzyKalendarzDniRoboczychZakresAktywny = false;
               

                foreach (var zam in dzien.RaportZaplanowane)
                {
                    var allreadyInDb = db.PlanningDzienRoboczyZamowienieKombi.Where(w => w.ZamowienieKombiRefId == zam.ElementBaza.ZamowienieKombiId && w.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzialRefId==dto.ProdukcjaDzial.ProdukcjaDzialId).FirstOrDefault();
                    if (allreadyInDb == null)
                    {
                        pdr.PlanningDzienRoboczyZamowienieKombi.Add(new PlanningDzienRoboczyZamowienieKombi()
                        {
                            PlanningDzienRoboczy = pdr,
                            ZamowienieKombiRefId = zam.ElementBaza.ZamowienieKombiId,
                        });
                    }
                    else {
                        System.Diagnostics.Debug.WriteLine($"znalazlem zamKombiId ktore bylo juz w bazie {allreadyInDb.ZamowienieKombiRefId}");
                        allreadyInDb.PlanningDzienRoboczy = pdr;
                    }
                }

                pNew.PlanningDzienRoboczy.Add(pdr);
            }

            if (dto.TkaninaBelka.Count > 0 && dto.ProdukcjaDzial.CzyTkaninaBelka==true) {

                foreach (var matBelkaGrupa in dto.TkaninaBelka)
                {
                    foreach (var matBelka in matBelkaGrupa.PlanningMaterialBelka)
                    {

                        if (matBelka.MaterialBelka == null) {
                            return BadRequest($"Nie przypisano belek dla grupy materiałowej {matBelkaGrupa.Material.Nazwa}, zapis planningu: PRZERWANO !");
                        }

                        PlanningTkaninaBelka ptb = new PlanningTkaninaBelka();
                        ptb.Planning = pNew;
                        ptb.MaterialBelkaRefId = matBelka.MaterialBelka.Id;
                        ptb.Uwagi = matBelka.Uwagi;
                        ptb.Wartosc = matBelka.ZuzycieWartosc;

                        var belkaToUpdateStanAktualny= db.MaterialBelka.Find(matBelka.MaterialBelka.Id);
                        belkaToUpdateStanAktualny.StanAktualny -= matBelka.ZuzycieWartosc;


                        foreach (var obsz in matBelka.ListaObszyc)
                        {
                            ptb.PlanningTkaninaBelkaListaObszyc.Add(new PlanningTkaninaBelkaListaObszyc
                            {
                                PlanningTkaninaBelka = ptb,
                                ZamowienieKombiObszycieRefId = obsz.Id
                            });
                        }
                        pNew.PlanningTkaninaBelka.Add(ptb);
                    }
                }
            }


            db.Planning.Add(pNew);
            db.SaveChanges();

            return Ok(new { info=$"Planning został zapisany, id: {pNew.PlanningId}"});
        }



        private FindByDateRangeDTO mPlanningIdByDate(DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);

            var planningBasedOnDate = db.PlanningDzienRoboczy
                .Where(a => a.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy == date && a.KalendarzDniRoboczychDzialProd.ProdukcjaDzialRefId == db.ProdukcjaDzial.Where(wp => wp.CzyTkaninaBelka == true).Select(sw => sw.ProdukcjaDzialId).FirstOrDefault())
                .Select(s => new FindByDateRangeDTO{
                    Id=s.PlanningRefId,
                    DateStart=s.Planning.PlanningDzienRoboczy.Min(m=>m.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy),
                    DateEnd=s.Planning.PlanningDzienRoboczy.Max(m=>m.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy)
                }).FirstOrDefault();



            if (planningBasedOnDate != null)
            {
                return planningBasedOnDate;
            }
            else {
                return new FindByDateRangeDTO
                {
                    Id = 0,
                    DateStart = date,
                    DateEnd = date,
                };
            }



        }

        private List<PlanningTkaninaBelkaRaportDTO> mRealizacjaTkaniny(DateTime dzienRoboczy, int planningId)
        {
            //            var d = test.DzienRoboczy;
            //            test.DzienRoboczy = new DateTime(d.Year, d.Month, d.Day, 9, 0, 0);

            var wszystkieObszycia = db.PlanningTkaninaBelkaListaObszyc
                .Where(w => w.PlanningTkaninaBelka.Planning.PlanningId == planningId)
                //                .Where(wpd => wpd.PlanningRefId == w.PlanningTkaninaBelka.PlanningRefId)
                //                        .Select(spdr => spdr).FirstOrDefault().KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy == test.DzienRoboczy)
                .Select(s => s);


            return wszystkieObszycia.GroupBy(g => g.PlanningTkaninaBelka.MaterialBelkaRefId).Select(sg => new PlanningTkaninaBelkaRaportDTO
            {
                TkaninaBelkaId = sg.Key,
                BelkaStanAktualny = sg.Select(s => s.PlanningTkaninaBelka.MaterialBelka.StanAktualny).FirstOrDefault(),
                Material = sg.Select(s => s.PlanningTkaninaBelka.MaterialBelka.Material).FirstOrDefault(),
                ZuzycieWartosc = sg.Select(s => s.PlanningTkaninaBelka.Wartosc).FirstOrDefault(),
                ListaObszyc = sg.Select(s => new PlanningTkaninaBelkaRaportListaObszycDTO
                {
                    PlanningTkaninaBelkaListaObszycId = s.PlanningTkaninaBelkaListaObszycId,
                    IsDone = s.IsDone,
                    PlanningTkaninaBelkaRefId = s.PlanningTkaninaBelkaRefId,
                    Dlugosc = s.ZamowienieKombiObszycie.KombinacjeObszycie.Dlugosc,
                    NazwaKombinacji = s.ZamowienieKombiObszycie.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa,
                    NazwaObszycia = "(" + s.ZamowienieKombiObszycieRefId + ") " + s.ZamowienieKombiObszycie.KombinacjeObszycie.Obszycie.Nazwa + ", (" + s.ZamowienieKombiObszycie.KombinacjeObszycie.Dlugosc + "/" + s.ZamowienieKombiObszycie.KombinacjeObszycie.Szerokosc + ")",
                    ZamowienieInfo = "ZId: " + s.ZamowienieKombiObszycie.ZamowienieKombi.ZamowienieRefId + ", C: " + s.ZamowienieKombiObszycie.ZamowienieKombi.Zamowienie.Commission + ", R: " + s.ZamowienieKombiObszycie.ZamowienieKombi.Zamowienie.Reference,
                    Status = "baza",
                    Szerokosc = s.ZamowienieKombiObszycie.KombinacjeObszycie.Szerokosc,
                    ZamowienieKombiObszycieRefId = s.ZamowienieKombiObszycieRefId
                }).OrderBy(o => o.ZamowienieInfo).ThenBy(o => o.NazwaKombinacji).ThenBy(o => o.NazwaObszycia).ToList()
            }).OrderBy(o => o.Material.MaterialGrupaRefId).ToList();
        }


        private List<PlanningListDTO> mPlanningList() {

            return db.Planning.Select(p => new PlanningListDTO
            {
                PlanningId = p.PlanningId,
                ProdukcjaDzial = p.PlanningDzienRoboczy.Where(wpd => wpd.PlanningRefId == p.PlanningId).Select(spd => spd.KalendarzDniRoboczychDzialProd.ProdukcjaDzial).Select(s => new ProdukcjaDzialDTO
                {
                    CzyPozycjaMagazynowa = s.CzyPozycjaMagazynowa,
                    CzyTkaninaBelka = s.CzyTkaninaBelka,
                    NadrzednyIds = s.NadrzedneIds,
                    Nazwa = s.Nazwa,
                    Uwagi = s.Uwagi,
                }).FirstOrDefault(),
                PlanningDzienRoboczy = p.PlanningDzienRoboczy.Where(wpd => wpd.PlanningRefId == p.PlanningId).Select(spdr => new PlanningListDzienRoboczyDTO
                {
                    DzienRoboczy = spdr.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy,
                    ElementyZaplanowane = spdr.PlanningDzienRoboczyZamowienieKombi.Select(s => new PlanningZamowienieKombiInfo
                    {
                        IsDone = s.IsDone,
                        Nazwa = s.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa,
                        Zamowienie = new ZamowienieInfoDTO
                        {
                            Commission = s.ZamowienieKombi.Zamowienie.Commission,
                            Reference = s.ZamowienieKombi.Zamowienie.Reference,
                            ZamowienieNr = s.ZamowienieKombi.Zamowienie.ZamowienieNr,
                            ZamowienieId = s.ZamowienieKombi.Zamowienie.Id,
                        },
                    }).ToList(),
                }).ToList(),
                PozycjaMagazynowa = p.PlanningPozycjaMagazynowa.Select(s => new PlanningPozycjaMagazynowaDTO
                {
                    Jednostka = s.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                    Nazwa = s.PozycjaMagazynowa.Nazwa,
                    Wartosc = s.Wartosc,
                    StanAktualny = s.PozycjaMagazynowa.StanAktualny,
                    PozycjaMagazynowaId = s.PozycjaMagazynowaRefId
                }).ToList(),
                TkaninaBelka = p.PlanningTkaninaBelka.Select(s => new PlanningTkaninaBelkaGrupaDTO
                {

                }).ToList()


            })
            .OrderBy(o => o.PlanningDzienRoboczy.FirstOrDefault().DzienRoboczy)
            .ToList();
        }
        

    }


    



}