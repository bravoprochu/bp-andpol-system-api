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
using Andpol.Dane.ModelsDTO;
using System.Web.Http.Cors;
using Andpol.Dane.Entities;

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="Normy")]
    [EnableCors("*", "*", "*")]
    public class WykonczenieController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/Wykonczenie
        public IHttpActionResult GetWykonczenie()
        {
            var result = (from w in db.Wykonczenie
                          select new WykonczenieDTO()
                          {
                              WykonczenieId = w.WykonczenieId,
                              Nazwa = w.Nazwa,
                              Uwagi = w.Uwagi,
                              WykonczenieGrupa = new WykonczenieGrupaDTO() {
                                  WykonczenieGrupaId = w.WykonczenieGrupa.WykonczenieGrupaId,
                                  Nazwa = w.WykonczenieGrupa.Nazwa,
                                  Uwagi = w.WykonczenieGrupa.Uwagi
                              },
                         }).ToList();

            return Ok(result);
        }

        // GET: api/Wykonczenie/5
        [ResponseType(typeof(Wykonczenie))]
        public async Task<IHttpActionResult> GetWykonczenie(int id)
        {
            Wykonczenie wyk = await db.Wykonczenie.FindAsync(id);
            if (wyk == null) { return BadRequest("Nie znaleziono rekordu"); }

            var result = (from w in db.Wykonczenie
                          where w.WykonczenieId == id
                          select new WykonczenieDTO()
                          {

                              WykonczenieId = w.WykonczenieId,
                              Nazwa = w.Nazwa,
                              Status = "baza",
                              Uwagi = w.Uwagi,
                              WykonczenieGrupa = new WykonczenieGrupaDTO()
                              {
                                  WykonczenieGrupaId= w.WykonczenieGrupa.WykonczenieGrupaId,
                                  Nazwa = w.WykonczenieGrupa.Nazwa,
                                  Uwagi = w.WykonczenieGrupa.Uwagi
                              },
                          }).FirstOrDefault();



            return Ok(result);
        }

        // PUT: api/Wykonczenie/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWykonczenie(int id, WykonczenieDTO wDTO)
        {

            if (id == 0) {
                Wykonczenie wNew = new Wykonczenie()
                {
                    Nazwa = wDTO.Nazwa,
                    Uwagi = wDTO.Uwagi,
                    WykonczenieGrupaRefId = wDTO.WykonczenieGrupa.WykonczenieGrupaId,
                };
                db.Wykonczenie.Add(wNew);
                await db.SaveChangesAsync();
                return StatusCode(HttpStatusCode.OK);
                

            } else {
                Wykonczenie wMod = db.Wykonczenie.Find(id);
                if (wMod == null || wDTO.WykonczenieId != id) { return BadRequest("Coś jest nie tak z przesłanymi danymi, Id się nie zgadza.."); }

                if (wDTO.Status == "zmieniony") {
                    wMod.Nazwa = wDTO.Nazwa;
                    wMod.Uwagi = wDTO.Uwagi;
                    wMod.WykonczenieGrupa = db.WykonczenieGrupa.Find(wDTO.WykonczenieGrupa.WykonczenieGrupaId);
                }
            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WykonczenieExists(id))
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

        // POST: api/Wykonczenie
        [ResponseType(typeof(Wykonczenie))]
        public async Task<IHttpActionResult> PostWykonczenie(Wykonczenie wykonczenie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wykonczenie.Add(wykonczenie);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = wykonczenie.WykonczenieId }, wykonczenie);
        }

        // DELETE: api/Wykonczenie/5
        [ResponseType(typeof(Wykonczenie))]
        public async Task<IHttpActionResult> DeleteWykonczenie(int id)
        {
            Wykonczenie wykonczenie = await db.Wykonczenie.FindAsync(id);
            if (wykonczenie == null)
            {
                return NotFound();
            }

            db.Wykonczenie.Remove(wykonczenie);
            await db.SaveChangesAsync();

            return Ok(wykonczenie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WykonczenieExists(int id)
        {
            return db.Wykonczenie.Count(e => e.WykonczenieId == id) > 0;
        }
    }
}