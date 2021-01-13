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

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="Planning, Normy")]
    [EnableCors("*", "*", "*")]
    
    public class EtapyProdukcyjneController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/EtapyProdukcyjne
        public IQueryable<EtapyProdukcyjneDTO> GetEtapyProdukcyjne()
        {
            var result = (from n in db.EtapyProdukcyjne
                          select new EtapyProdukcyjneDTO()
                          {
                              Id = n.EtapyProdukcyjneId,
                              Nazwa = n.Nazwa,
                              Uwagi = n.Uwagi,
                              Status="baza"
                          }).OrderBy(o => o.Nazwa);

            return result;
        }

        // GET: api/EtapyProdukcyjne/5
        [ResponseType(typeof(EtapyProdukcyjne))]
        public async Task<IHttpActionResult> GetEtapyProdukcyjne(int id)
        {
            EtapyProdukcyjne ep = await db.EtapyProdukcyjne.FindAsync(id);
            if (ep == null)
            {
                return NotFound();
            }

            EtapyProdukcyjneDTO epDTO = new EtapyProdukcyjneDTO
            {
                Id = ep.EtapyProdukcyjneId,
                Nazwa = ep.Nazwa,
                Uwagi = ep.Uwagi,
                Status = "baza"
            };

            return Ok(epDTO);
        }

        // PUT: api/EtapyProdukcyjne/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEtapyProdukcyjne(int id, EtapyProdukcyjneDTO epDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id == 0)
            {
                EtapyProdukcyjne wnNew = new EtapyProdukcyjne
                {
                    Nazwa = epDTO.Nazwa,
                    Uwagi = epDTO.Uwagi
                };
                db.EtapyProdukcyjne.Add(wnNew);
                db.SaveChanges();

                id = wnNew.EtapyProdukcyjneId;
            };


            if (!EtapyProdukcyjneExists(id))
            {
                return NotFound();
            }


            if (epDTO.Status == "zmieniony")
            {
                var wnMod = db.EtapyProdukcyjne.Find(id);
                wnMod.Nazwa = epDTO.Nazwa;
                wnMod.Uwagi = epDTO.Uwagi;
            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtapyProdukcyjneExists(id))
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

        // POST: api/EtapyProdukcyjne
        [ResponseType(typeof(EtapyProdukcyjne))]
        public async Task<IHttpActionResult> PostEtapyProdukcyjne(EtapyProdukcyjne etapyProdukcyjne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EtapyProdukcyjne.Add(etapyProdukcyjne);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = etapyProdukcyjne.EtapyProdukcyjneId }, etapyProdukcyjne);
        }

        // DELETE: api/EtapyProdukcyjne/5
        [ResponseType(typeof(EtapyProdukcyjne))]
        public async Task<IHttpActionResult> DeleteEtapyProdukcyjne(int id)
        {
            EtapyProdukcyjne etapyProdukcyjne = await db.EtapyProdukcyjne.FindAsync(id);
            if (etapyProdukcyjne == null)
            {
                return NotFound();
            }

            db.EtapyProdukcyjne.Remove(etapyProdukcyjne);
            await db.SaveChangesAsync();

            return Ok(etapyProdukcyjne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EtapyProdukcyjneExists(int id)
        {
            return db.EtapyProdukcyjne.Count(e => e.EtapyProdukcyjneId == id) > 0;
        }
    }
}