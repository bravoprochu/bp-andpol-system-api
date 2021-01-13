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
using System.Web.Http.Cors;
using Andpol.Dane.ModelsDTO;
using System.Web.Http.OData;

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles = "Normy")]
    [EnableCors("*", "*", "*")]

    public class NormaController : ApiController
    {
        private PoligonContext db = new PoligonContext();


        // GET: api/Norma
        public IHttpActionResult GetNorma()
        {

            var result = (from n in db.Normy
                          select new
                          {
                              Id = n.Id,
                              CzyAktywna=n.CzyAktywna,
                              Nazwa = n.Nazwa,
                              Uwagi = n.Uwagi,
                              KombinacjeIlosc = (from k in db.Kombinacja where k.NormaRefId == n.Id select k).ToList().Count,
                              KombinacjeNazwy = (from k in db.Kombinacja where k.NormaRefId == n.Id select k.NazwaKombinacji.Nazwa).ToList()
                          }).ToList().OrderByDescending(n => n.KombinacjeIlosc);
            return Ok(result);
        }

        // GET: api/Norma/5
        //[ResponseType(typeof(Norma))]
        //public async Task<IHttpActionResult> GetNorma(int id)
        //{
        //    Norma norma = await db.Normy.FindAsync(id);
        //    if (norma == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(norma);
        //}


        [ResponseType(typeof(NormaDTO))]
        public IHttpActionResult GetNorma(int id)
        {

            Norma norma = db.Normy.Find(id);
            if (norma == null)
            {
                return BadRequest("Nie ma takiego rekordu..");
            }

            var normyDTO = db.Normy.Where(w => w.Id == id).Select(n => new NormaDTO
            {
                NormaId = n.Id,
                CzyAktywna = n.CzyAktywna,
                Status = "baza",
                Nazwa = n.Nazwa,
                Uwagi = n.Uwagi,
                Kombinacje = n.Kombinacje.Select(k => new KombinacjaDTO()
                {
                    KombinacjaId = k.KombinacjaId,
                    Status = "baza",
                    Glebokosc = k.Glebokosc,
                    IloscPoduszekOparciowych = k.IloscPoduszekOparciowych,
                    IloscPoduszekSiedzeniowych = k.IloscPoduszekSiedzeniowych,
                    Szerokosc = k.Szerokosc,
                    Uwagi = k.Uwagi,
                    Waga = k.Waga,
                    Wartosc = k.Wartosc,
                    Wysokosc = k.Wysokosc,
                    NazwaKombinacji = new NazwaKombinacjiDTO()
                    {
                        Id = k.NazwaKombinacji.Id,
                        Status = "baza",
                        Nazwa = k.NazwaKombinacji.Nazwa,
                        Uwagi = k.NazwaKombinacji.Uwagi,
                    },
                    //EtapyProdukcyjne = (from kep in db.KombinacjaEtapyProdukcyjne
                    //                    where kep.KombinacjaRefId == k.KombinacjaId
                    //                    select new KombinacjeEtapyProdukcyjneWartoscDTO() {
                    //                        Id = kep.KombinacjaEtapyProdukcyjneId,
                    //                        KombinacjaEtapyProdukcyjneId = kep.EtapyProdukcyjneRefId,
                    //                        Status = "baza",
                    //                        Nazwa = kep.EtapyProdukcyjne.Nazwa
                    //                    }).OrderBy(o => o.Nazwa).ToList(),
                    KombinacjaObszycie = k.KombinacjeObszycie.Select(ow => new KombinacjaObszycieElementowDTO()
                    {
                        Id = ow.KombinacjaObszycieId,
                        IdRef = ow.Obszycie.Id,
                        Jednostka = "cm",
                        Nazwa = ow.Obszycie.Nazwa,
                        Wartosc = ow.Dlugosc,
                        Wartosc2 = ow.Szerokosc,
                        Status = "baza"
                    }).OrderBy(o => o.Nazwa).ToList(),
                    KombinacjaPozycjaMagazynowa = k.KombinacjaPozycjaMagazynowaWartosc.Select(mpm => new KombinacjaPozycjaMagazynowaDTO()
                    {
                        Id = mpm.KombinacjaPozycjaMagazynowaId,
                        Jednostka = mpm.MagPozycjaMagazynowa.JednostkaMiary.Nazwa,
                        Nazwa = mpm.MagPozycjaMagazynowa.Nazwa,
                        Wartosc = mpm.Wartosc,
                        IdRef = mpm.MagPozycjaMagazynowa.MagPozycjaMagazynowaId,
                        Status = "baza"
                    }).OrderBy(o => o.Nazwa).ToList(),
                    //KombinacjaRobocizna =
                    //          (from rw in db.KombinacjaRobocizna
                    //           where rw.KombinacjaRefId == k.KombinacjaId
                    //           select new KombinacjaRobociznaDTO()
                    //           {
                    //               Id = rw.KombinacjaRobociznaId,
                    //               Status = "baza",
                    //               Wartosc = rw.Wartosc
                    //           }).OrderBy(o => o.Nazwa).ToList(),

                    KombinacjaRobocizna = k.KombinacjaRobocizna.Select(s => new KombinacjaRobociznaDTO()
                    {
                        KombinacjaRobociznaId = s.KombinacjaRobociznaId,
                        GrupaRoboczaWybrane = s.KombinacjaRobociznaGrupaRobocza.Select(r => new KombinacjaRobociznaGrupaRoboczaDTO()
                        {
                            Id = r.KombinacjaRobociznaGrupaRoboczaId,
                            Robocizna = new RobociznaDTO()
                            {
                                Id = r.Robocizna.Id,
                                Nazwa = r.Robocizna.Nazwa,
                                Uwagi = r.Robocizna.Uwagi,
                            },
                            Status = "baza",
                            Wartosc = r.Wartosc

                        }).ToList(),
                        ProdukcjaDzial = new ProdukcjaDzialDTO()
                        {
                            GrupaRobocza = s.ProdukcjaDzial.Robocizna.Select(sr => new PlanningGrupaRoboczaSkladDTO()
                            {
                                Id = sr.Id,
                                Nazwa = sr.Nazwa,
                                Uwagi = sr.Uwagi
                            }).ToList(),
                            Nazwa = s.ProdukcjaDzial.Nazwa,
                            ProdukcjaDzialId = s.ProdukcjaDzialRefId,
                            Uwagi = s.ProdukcjaDzial.Uwagi,
                        },
                        ProdukcjaDzialId = s.ProdukcjaDzialRefId,
                        Status = "baza",
                        Wartosc = s.Wartosc,

                    }).ToList(),

                    KombinacjaWykonczenie = k.KombinacjaWykonczenie.Select(kw => new WykonczenieDTO()
                    {
                        WykonczenieId = kw.Wykonczenie.WykonczenieId,
                        CzyPolitykaCenowa = kw.CzyPolitykaCenowa,
                        KombinacjaWykonczenieId = kw.KombinacjaWykonczenieId,
                        Ilosc = kw.Ilosc,
                        Nazwa = kw.Wykonczenie.Nazwa,
                        PolitykaCenowa = kw.CzyPolitykaCenowa ? new PolitykaCenowaDTO
                        {
                            Nazwa = kw.PolitykaCenowa.Nazwa,
                            PolitykaCenowaId = kw.PolitykaCenowa.FinPolitykaCenowaId,
                            Uwagi = kw.PolitykaCenowa.Uwagi
                        } : null,
                        Status = "baza",
                        Uwagi = kw.Wykonczenie.Uwagi,
                        WykonczenieGrupa = new WykonczenieGrupaDTO()
                        {
                            WykonczenieGrupaId = kw.Wykonczenie.WykonczenieGrupa.WykonczenieGrupaId,
                            Nazwa = kw.Wykonczenie.WykonczenieGrupa.Nazwa,
                            Uwagi = kw.Wykonczenie.WykonczenieGrupa.Uwagi
                        }
                    }).ToList(),
                    OpcjeWykonczenia = db.WykonczenieGrupa.Select(ow=> new WykonczenieOpcjaDTO()
                                        {
                                            WykonczenieOpcjaId = ow.WykonczenieGrupaId,
                                            Nazwa = ow.Nazwa,
                                            Wybrane = db.KombinacjaWykonczenie.Any(a => a.Wykonczenie.WykonczenieGrupaRefId == ow.WykonczenieGrupaId && a.KombinacjaRefId == k.KombinacjaId),
                                        }).ToList(),
                }).OrderBy(o => o.NazwaKombinacji.Nazwa).ToList()
            }).SingleOrDefault();

            return Ok(normyDTO);


        }


        // PUT: api/Norma/5

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNorma(int id, NormaDTO nDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Norma nNew = new Norma();


            if (nDTO.Status == "nowy" && id == 0)
            {
                nNew.CzyAktywna = nDTO.CzyAktywna;
                nNew.Nazwa = nDTO.Nazwa;
                nNew.Uwagi = nDTO.Uwagi;

                db.Normy.Add(nNew);
            }


            var nMod = db.Normy.Find(id);
            if (nDTO.Status == "zmieniony" && nMod != null)
            {
                nMod.CzyAktywna = nDTO.CzyAktywna;
                nMod.Nazwa = nDTO.Nazwa;
                nMod.Uwagi = nDTO.Uwagi;
                db.Entry(nMod).State = EntityState.Modified;
            }

            var norma = id > 0 ? nMod : nNew;




            foreach (var k in nDTO.Kombinacje)
            {

                var kombinacjaBaza = (k.Status=="zmieniony" || k.Status=="usuniety") ? db.Kombinacja.Find(k.KombinacjaId) : new Kombinacja();


                if (k.Status == "nowy")
                {
                    kombinacjaBaza.Glebokosc = k.Glebokosc;
                    if (k.IloscPoduszekOparciowych.HasValue) { kombinacjaBaza.IloscPoduszekOparciowych = k.IloscPoduszekOparciowych.Value; } else { kombinacjaBaza.IloscPoduszekOparciowych = null; }
                    if (k.IloscPoduszekSiedzeniowych.HasValue) { kombinacjaBaza.IloscPoduszekSiedzeniowych = k.IloscPoduszekSiedzeniowych.Value; } else { kombinacjaBaza.IloscPoduszekSiedzeniowych = null; }
                    kombinacjaBaza.NazwaKombinacjiRefId = k.NazwaKombinacji.Id;
                    kombinacjaBaza.Norma = norma;
                    kombinacjaBaza.Szerokosc = k.Szerokosc;
                    kombinacjaBaza.Uwagi = k.Uwagi;
                    kombinacjaBaza.Waga = k.Waga;
                    kombinacjaBaza.Wartosc = k.Wartosc;
                    kombinacjaBaza.Wysokosc = k.Wysokosc;
                    norma.Kombinacje.Add(kombinacjaBaza);

                }
                if (k.Status == "zmieniony")
                {
                    if (kombinacjaBaza != null)
                    {
                        db.Entry(kombinacjaBaza).State = EntityState.Modified;
                        kombinacjaBaza.Glebokosc = k.Glebokosc;
                        if (k.IloscPoduszekOparciowych.HasValue) { kombinacjaBaza.IloscPoduszekOparciowych = k.IloscPoduszekOparciowych.Value; } else { kombinacjaBaza.IloscPoduszekOparciowych = null; }
                        if (k.IloscPoduszekSiedzeniowych.HasValue) { kombinacjaBaza.IloscPoduszekSiedzeniowych = k.IloscPoduszekSiedzeniowych.Value; } else { kombinacjaBaza.IloscPoduszekSiedzeniowych = null; }
                        kombinacjaBaza.Szerokosc = k.Szerokosc;
                        kombinacjaBaza.Uwagi = k.Uwagi;
                        kombinacjaBaza.Waga = k.Waga;
                        kombinacjaBaza.Wartosc = k.Wartosc;
                        kombinacjaBaza.Wysokosc = k.Wysokosc;
                    }
                    else
                    {
                        return BadRequest($"Błąd podczas zapisu kombinacji {k.NazwaKombinacji.Nazwa}, nie znaleziono jej ID w bazie..");
                    }
                }
                if (k.Status == "usuniety")
                {
                    if (kombinacjaBaza != null)
                    {
                        db.Entry(kombinacjaBaza).State = EntityState.Deleted;
                    }
                }

                foreach (var obsz in k.KombinacjaObszycie)
                {
                    var kObszycie = (obsz.Status == "zmieniony" || obsz.Status == "usuniety") ? db.KombinacjaObszycie.Find(obsz.Id) : new KombinacjaObszycie();
                    if (obsz.Status == "nowy")
                    {
                        kObszycie.Dlugosc = obsz.Wartosc;
                        kObszycie.Kombinacja = kombinacjaBaza;
                        kObszycie.ObszycieRefId = obsz.IdRef;
                        kObszycie.Szerokosc = obsz.Wartosc2;

                        kombinacjaBaza.KombinacjeObszycie.Add(kObszycie);
                    }
                    if (obsz.Status == "zmieniony" && kObszycie != null)
                    {
                        db.Entry(kObszycie).State = EntityState.Modified;
                        kObszycie.Dlugosc = obsz.Wartosc;
                        kObszycie.Szerokosc = obsz.Wartosc2;
                    }
                    if (obsz.Status == "usuniety" && kObszycie != null)
                    {
                        db.Entry(kObszycie).State = EntityState.Deleted;
                    }
                }

                foreach (var pozMag in k.KombinacjaPozycjaMagazynowa)
                {
                    var pozMagazyn = (pozMag.Status == "zmieniony" || pozMag.Status == "usuniety") ? db.KombinacjaPozycjaMagazynowa.Find(pozMag.Id) : new KombinacjaPozycjaMagazynowa();
                    if (pozMag.Status == "nowy")
                    {
                        pozMagazyn.Kombinacja = kombinacjaBaza;
                        pozMagazyn.MagPozycjaMagazynowaRefId = pozMag.IdRef;
                        pozMagazyn.Wartosc = pozMag.Wartosc;
                        kombinacjaBaza.KombinacjaPozycjaMagazynowaWartosc.Add(pozMagazyn);
                    }
                    if (pozMag.Status == "zmieniony" && pozMagazyn != null)
                    {
                        pozMagazyn.Wartosc = pozMag.Wartosc;
                        db.Entry(pozMagazyn).State = EntityState.Modified;
                    }
                    if (pozMag.Status == "usuniety" && pozMagazyn != null)
                    {
                        db.Entry(pozMagazyn).State = EntityState.Deleted;
                    }
                }

                foreach (var dzial in k.KombinacjaRobocizna)
                {
                    var dzialRobocizna = (dzial.Status == "zmieniony" || dzial.Status == "usuniety") ? db.KombinacjaRobocizna.Find(dzial.KombinacjaRobociznaId) : new KombinacjaRobocizna();
                    if (dzial.Status == "nowy" && dzial.GrupaRoboczaWybrane.Count > 0)
                    {

                        dzialRobocizna.Kombinacja = kombinacjaBaza;
                        dzialRobocizna.ProdukcjaDzialRefId = dzial.ProdukcjaDzial.ProdukcjaDzialId;
                        dzialRobocizna.Wartosc = dzial.Wartosc;


                        foreach (var r in dzial.GrupaRoboczaWybrane)
                        {
                            if (r.Status == "nowy")
                            {
                                dzialRobocizna.KombinacjaRobociznaGrupaRobocza.Add(new KombinacjaRobociznaGrupaRobocza
                                {
                                    KombinacjaRobocizna = dzialRobocizna,
                                    RobociznaRefId = r.Robocizna.Id,
                                    Wartosc = r.Wartosc,
                                });
                            }
                        }
                        kombinacjaBaza.KombinacjaRobocizna.Add(dzialRobocizna); ;
                    }

                    if (dzial.Status == "zmieniony")
                    {
                        db.Entry(dzialRobocizna).State = EntityState.Modified;
                        dzialRobocizna.Wartosc = dzial.Wartosc;

                        foreach (var r in dzial.GrupaRoboczaWybrane)
                        {
                            if (r.Status == "nowy")
                            {
                                dzialRobocizna.KombinacjaRobociznaGrupaRobocza.Add(new KombinacjaRobociznaGrupaRobocza
                                {
                                    KombinacjaRobocizna = dzialRobocizna,
                                    RobociznaRefId = r.Robocizna.Id,
                                    Wartosc = r.Wartosc
                                });
                            }
                            
                            if (r.Status == "zmieniony")
                            {
                                var rMod = db.KombinacjaRobociznaGrupaRobocza.Find(r.Id);
                                rMod.Wartosc = r.Wartosc;
                                db.Entry(rMod).State = EntityState.Modified;
                            }
                            if (r.Status == "usuniety")
                            {
                                var rMod = db.KombinacjaRobociznaGrupaRobocza.Find(r.Id);
                                db.Entry(rMod).State = EntityState.Deleted;
                            }

                        }
                    }
                    if (dzial.Status == "usuniety")
                    {
                        db.Entry(dzialRobocizna).State = EntityState.Deleted;
                    }

                }



                foreach (var wyk in k.KombinacjaWykonczenie)
                {

                    var wykonczenie = (wyk.Status == "zmieniony" || wyk.Status == "usuniety") ? db.KombinacjaWykonczenie.Find(wyk.KombinacjaWykonczenieId) : new KombinacjaWykonczenie();
                    var opcjaWyk = k.OpcjeWykonczenia.Where(wx => wx.WykonczenieOpcjaId == wyk.WykonczenieGrupa.WykonczenieGrupaId).Select(sx => sx.Wybrane).FirstOrDefault();


                    if (wyk.Status == "nowy" && opcjaWyk)
                    {
                        wykonczenie.Kombinacja=kombinacjaBaza;
                        wykonczenie.WykonczenieRefId = wyk.WykonczenieId;
                        if (wyk.CzyPolitykaCenowa)
                        {
                            wykonczenie.CzyPolitykaCenowa = true;
                            wykonczenie.PolitykaCenowaRefId = wyk.PolitykaCenowa.PolitykaCenowaId;
                            wykonczenie.Ilosc = wyk.Ilosc;
                        }
                        kombinacjaBaza.KombinacjaWykonczenie.Add(wykonczenie);
                    };
                    if (wyk.Status == "zmieniony" && opcjaWyk && wykonczenie!=null) {
                        db.Entry(wykonczenie).State = EntityState.Modified;
                        if (wyk.CzyPolitykaCenowa)
                        {
                            wykonczenie.CzyPolitykaCenowa = true;
                            wykonczenie.PolitykaCenowaRefId = wyk.PolitykaCenowa.PolitykaCenowaId;
                            wykonczenie.Ilosc = wyk.Ilosc;
                        }
                        else {
                            wykonczenie.CzyPolitykaCenowa = false;
                            wykonczenie.PolitykaCenowa = null;
                            wykonczenie.Ilosc = 0;
                        }
                    }

                    if (wykonczenie!=null && !opcjaWyk)
                    {
                        db.Entry(wykonczenie).State = EntityState.Deleted;
                    }

                    if (wyk.Status == "usuniety" && wykonczenie != null)
                    {
                        db.Entry(wykonczenie).State = EntityState.Deleted;
                    }


                }
            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NormaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE: api/Norma/5
        [ResponseType(typeof(Norma))]
        public async Task<IHttpActionResult> DeleteNorma(int id)
        {
            Norma norma = await db.Normy.FindAsync(id);
            if (norma == null)
            {
                return NotFound();
            }

            db.Normy.Remove(norma);
            await db.SaveChangesAsync();

            return Ok(new { info = $"Norma {norma.Nazwa } o ID: {norma.Id} została usunięta z bazy" });
        }

        [Route("api/Norma/PomocMagPozycjaMagazynowa")]
        [HttpGet]
        public IHttpActionResult GetPomocMagPozycjaMagazynowa()
        {
            var result = (from m in db.MagPozycjaMagazynowa
                          select new
                          {
                              Id = m.MagPozycjaMagazynowaId,
                              Nazwa = m.Nazwa,
                              Uwagi = m.Uwagi,
                              Status = "baza"

                          }).OrderBy(o => o.Nazwa);


            return Ok(result);
        }


        //[Route("api/Norma/PomocGotowyAndpol")]
        //[HttpGet]
        //public IHttpActionResult GetPomocGotowyAndpol()
        //{
        //    var result = (from x in db.GotowyAndpol
        //                  select new
        //                  {
        //                      Id = x.Id,
        //                      Nazwa = x.Nazwa,
        //                      Uwagi = x.Uwagi,
        //                      Status = "baza",
        //                  }).OrderBy(o => o.Nazwa);
        //    return Ok(result);
        //}

        //[Route("api/Norma/PomocGotowyKupiony")]
        //[HttpGet]
        //public IHttpActionResult GetPomocGotowyKupiony()
        //{
        //    var result = (from x in db.GotowyKupiony
        //                  select new
        //                  {
        //                      Id = x.Id,
        //                      Nazwa = x.Nazwa,
        //                      Uwagi = x.Uwagi,
        //                      Status = "baza",
        //                  }).OrderBy(o => o.Nazwa);
        //    return Ok(result);
        //}

        [Route("api/Norma/PomocRobocizna")]
        [HttpGet]
        public IHttpActionResult GetPomocRobocizna()
        {
            var result = (from x in db.Robocizna
                          select new
                          {
                              Id = x.Id,
                              Nazwa = x.Nazwa,
                              Uwagi = x.Uwagi,
                              Status = "baza",
                          }).OrderBy(o => o.Nazwa);
            return Ok(result);
        }

        [Route("api/Norma/PomocObszycieElementow")]
        [HttpGet]
        public IHttpActionResult GetPomocObszycieElementow()
        {
            var result = (from x in db.Obszycie
                          select new
                          {
                              Id = x.Id,
                              Nazwa = x.Nazwa,
                              Uwagi = x.Uwagi,
                              Status = "baza",
                          }).OrderBy(o => o.Nazwa);
            return Ok(result);
        }

        [Route("api/Norma/PomocEtapyProdukcyjne")]
        [HttpGet]
        public IHttpActionResult GetPomocEtapyProdukcyjne()
        {
            var result = (from x in db.EtapyProdukcyjne
                          select new
                          {
                              KombinacjaEtapyProdukcyjneId = x.EtapyProdukcyjneId,
                              Nazwa = x.Nazwa,
                              Uwagi = x.Uwagi,
                              Status = "baza",
                          }).OrderBy(o => o.Nazwa);
            return Ok(result);
        }


        [Route("api/Norma/PomocNazwyKombinacji")]
        [HttpGet]
        public IHttpActionResult GetPomocNazwyKombinacji()
        {
            var result = (from x in db.NazwaKombinacji
                          select new
                          {
                              Id = x.Id,
                              Nazwa = x.Nazwa,
                              Uwagi = x.Uwagi,
                          }).OrderBy(o => o.Nazwa);
            return Ok(result);
        }



        [Route("api/Norma/PomocAll")]
        [HttpGet]
        public IHttpActionResult GetPomocAll()
        {

            var EtapyProdukcyjne = (from x in db.EtapyProdukcyjne
                                    select new
                                    {
                                        KombinacjaEtapyProdukcyjneId = x.EtapyProdukcyjneId,
                                        Nazwa = x.Nazwa,
                                        Uwagi = x.Uwagi,
                                        Status = "baza",
                                    }).OrderBy(o => o.Nazwa);

            var NazwyKombinacji = (from x in db.NazwaKombinacji
                                   select new
                                   {
                                       Id = x.Id,
                                       Nazwa = x.Nazwa,
                                       Uwagi = x.Uwagi,
                                   }).OrderBy(o => o.Nazwa);

            var MagPozycjaMagazynowa = (from m in db.MagPozycjaMagazynowa
                                        select new MagPozycjaMagazynowaDTO
                                        {
                                            PozycjaMagazynowaId = m.MagPozycjaMagazynowaId,
                                            Nazwa = m.Nazwa,
                                            Uwagi = m.Uwagi,
                                            Jednostka = m.JednostkaMiary.Nazwa,
                                            Status = "baza"
                                        }).OrderBy(o => o.Nazwa);


            var ObszycieElementow = (from x in db.Obszycie
                                     select new
                                     {
                                         Id = x.Id,
                                         Jednostka = "cm",
                                         Nazwa = x.Nazwa,
                                         Uwagi = x.Uwagi,
                                         Status = "baza",
                                     }).OrderBy(o => o.Nazwa);



            var Robocizna = (from x in db.Robocizna
                             select new
                             {
                                 Id = x.Id,
                                 Nazwa = x.Nazwa,
                                 Uwagi = x.Uwagi,
                                 Status = "baza",
                             }).OrderBy(o => o.Nazwa);




            return Ok(new { EtapyProdukcyjne, NazwyKombinacji, MagPozycjaMagazynowa, ObszycieElementow, Robocizna });
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NormaExists(int id)
        {
            return db.Normy.Count(e => e.Id == id) > 0;
        }






    }
}