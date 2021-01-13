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
    [Authorize(Roles ="Normy, Zamowienia")]
    [EnableCors("*", "*", "*")]
    public class WykonczenieGrupaController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/WykonczenieGrupa
        public IHttpActionResult GetWykonczenieGrupa()
        {
            var result = from wg in db.WykonczenieGrupa
                         select new WykonczenieGrupaDTO()
                         {
                             WykonczenieGrupaId = wg.WykonczenieGrupaId,
                             Nazwa = wg.Nazwa,
                             Uwagi = wg.Uwagi,
                         };

            return Ok(result);
        }

        // GET: api/WykonczenieGrupa/5
        [ResponseType(typeof(WykonczenieGrupa))]
        public async Task<IHttpActionResult> GetWykonczenieGrupa(int id)
        {
            WykonczenieGrupa wykonczenieGrupa = await db.WykonczenieGrupa.FindAsync(id);
            if (wykonczenieGrupa == null)
            {
                return NotFound();
            }

            return Ok(wykonczenieGrupa);
        }

        // PUT: api/WykonczenieGrupa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWykonczenieGrupa(int id, WykonczenieGrupa wykonczenieGrupa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wykonczenieGrupa.WykonczenieGrupaId)
            {
                return BadRequest();
            }

            db.Entry(wykonczenieGrupa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WykonczenieGrupaExists(id))
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

        // POST: api/WykonczenieGrupa
        [ResponseType(typeof(WykonczenieGrupa))]
        public async Task<IHttpActionResult> PostWykonczenieGrupa(WykonczenieGrupa wykonczenieGrupa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WykonczenieGrupa.Add(wykonczenieGrupa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = wykonczenieGrupa.WykonczenieGrupaId }, wykonczenieGrupa);
        }

        // DELETE: api/WykonczenieGrupa/5
        [ResponseType(typeof(WykonczenieGrupa))]
        public async Task<IHttpActionResult> DeleteWykonczenieGrupa(int id)
        {
            WykonczenieGrupa wykonczenieGrupa = await db.WykonczenieGrupa.FindAsync(id);
            if (wykonczenieGrupa == null)
            {
                return NotFound();
            }

            db.WykonczenieGrupa.Remove(wykonczenieGrupa);
            await db.SaveChangesAsync();

            return Ok(wykonczenieGrupa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WykonczenieGrupaExists(int id)
        {
            return db.WykonczenieGrupa.Count(e => e.WykonczenieGrupaId == id) > 0;
        }
    }
}