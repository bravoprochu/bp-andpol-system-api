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

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="FinansePolitykaCenowa")]
    [EnableCors("*", "*", "*")]
    public class FinPolitykaCenowaController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/FinPolitykaCenowa
        public IHttpActionResult GetFinPolitykaCenowa()
        {
            var result = (from pc in db.FinPolitykaCenowa.Include(i => i.PolitykaCenowaRegula)
                          select new
                          {
                              Nazwa = pc.Nazwa,
                              PolitykaCenowaId = pc.FinPolitykaCenowaId,
                              Uwagi = pc.Uwagi
                          }).ToList();

            return Ok(result);
        }

        // GET: api/FinPolitykaCenowa/5
        [ResponseType(typeof(PolitykaCenowaDTO))]
        public IHttpActionResult GetFinPolitykaCenowa(int id)
        {

            FinPolitykaCenowa pcFind = db.FinPolitykaCenowa.Find(id);
            if (pcFind == null) { return BadRequest("Nie ma takigo rekordu"); }

            var kontraheciZDealerami = db.Kontrahent.Where(w => w.CzyDealerzy).Select(s => new KontrahentInfoDTO
            {
                Kontrahent = s,
                KontrahentId = s.KontrahentId
            }).ToList();

            var result = db.FinPolitykaCenowa.Where(w => w.FinPolitykaCenowaId == id).Select(s => new PolitykaCenowaDTO
            {
                Nazwa=s.Nazwa,
                PolitykaCenowaId=s.FinPolitykaCenowaId,
                Reguly=s.PolitykaCenowaRegula.Select(reg=>new PolitykaCenowaRegulaDTO {
                    CzyAktywna=reg.CzyAktywna,
                    Kontrahent=new KontrahentInfoDTO() {
                        Kontrahent=reg.Kontrahent,
                        KontrahentId=reg.KontrahentRefId
                    },
                    PolitykaCenowaRegulaId=reg.FinPolitykaCenowaRegulaId,
                    Status="baza",
                    TypRozliczenia=reg.TypRozliczenia,
                    Wartosc=reg.Wartosc,
                }).ToList(),
                Status="baza",
                Uwagi=s.Uwagi
            }).FirstOrDefault();

            foreach (var k in kontraheciZDealerami)
            {
                if (!result.Reguly.Any(a => a.Kontrahent.KontrahentId == k.KontrahentId)) {
                    result.Reguly.Add(new PolitykaCenowaRegulaDTO
                    {
                        Kontrahent = k,
                    });
                }
            }
            return Ok(result);
        }

        // PUT: api/FinPolitykaCenowa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFinPolitykaCenowa(int id, PolitykaCenowaDTO pcDTO)
        {
            if (id == 0)
            {
                FinPolitykaCenowa pcNew = new FinPolitykaCenowa()
                {
                    Nazwa = pcDTO.Nazwa,
                    Uwagi = pcDTO.Uwagi
                };

                foreach (var reg in pcDTO.Reguly)
                {
                    var regNew = new FinPolitykaCenowaRegula()
                    {
                        CzyAktywna=reg.CzyAktywna,
                        KontrahentRefId=reg.Kontrahent.KontrahentId,
                        PolitykaCenowa=pcNew,
                        TypRozliczenia=reg.TypRozliczenia,
                        Wartosc=reg.Wartosc
                    };

                    pcNew.PolitykaCenowaRegula.Add(regNew);
                }

                db.FinPolitykaCenowa.Add(pcNew);
            }
            else {
                FinPolitykaCenowa pcMod = await db.FinPolitykaCenowa.FindAsync(id);

                if (pcMod == null || pcDTO.PolitykaCenowaId != pcMod.FinPolitykaCenowaId) { return BadRequest("Nie znaleziono takiego rekordu"); }

                if (pcDTO.Status == "zmieniony") {
                    pcMod.Nazwa = pcDTO.Nazwa;
                    pcMod.Uwagi = pcDTO.Uwagi;


                    foreach (var reg in pcDTO.Reguly)
                    {
                        if (reg.Status == "nowy") {
                            FinPolitykaCenowaRegula regNew = new FinPolitykaCenowaRegula() { CzyAktywna = reg.CzyAktywna, KontrahentRefId = reg.Kontrahent.KontrahentId, PolitykaCenowaRefId = id, TypRozliczenia = reg.TypRozliczenia, Wartosc = reg.Wartosc };
                            db.FinPolitykaCenowaRegula.Add(regNew);
                        };
                        if (reg.Status == "zmieniony") {
                            FinPolitykaCenowaRegula regMod = db.FinPolitykaCenowaRegula.Find(reg.PolitykaCenowaRegulaId);
                            regMod.CzyAktywna = reg.CzyAktywna;
                            regMod.TypRozliczenia = reg.TypRozliczenia;
                            regMod.Wartosc = reg.Wartosc;
                        }
                    }

                }


            }





            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinPolitykaCenowaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var info = id > 0 ? "Dane zostały zaktualizowane poprawnie" : "Dane zostały zapisane do bazy";

            return Ok( new { info = info });
        }

        // POST: api/FinPolitykaCenowa
        [ResponseType(typeof(FinPolitykaCenowa))]
        public async Task<IHttpActionResult> PostFinPolitykaCenowa(FinPolitykaCenowa finPolitykaCenowa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinPolitykaCenowa.Add(finPolitykaCenowa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = finPolitykaCenowa.FinPolitykaCenowaId }, finPolitykaCenowa);
        }

        // DELETE: api/FinPolitykaCenowa/5
        [ResponseType(typeof(FinPolitykaCenowa))]
        public async Task<IHttpActionResult> DeleteFinPolitykaCenowa(int id)
        {
            FinPolitykaCenowa finPolitykaCenowa = await db.FinPolitykaCenowa.FindAsync(id);
            if (finPolitykaCenowa == null)
            {
                return NotFound();
            }

            db.FinPolitykaCenowa.Remove(finPolitykaCenowa);
            await db.SaveChangesAsync();

            return Ok(finPolitykaCenowa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinPolitykaCenowaExists(int id)
        {
            return db.FinPolitykaCenowa.Count(e => e.FinPolitykaCenowaId == id) > 0;
        }
    }
}