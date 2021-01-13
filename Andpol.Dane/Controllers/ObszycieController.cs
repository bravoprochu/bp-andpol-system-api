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
    [Authorize(Roles ="Normy")]
    [EnableCors("*", "*", "*")]
    
    public class ObszycieController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/Obszycie
        public IQueryable<ObszycieDTO> GetObszycie()
        {
            var obsz = from o in db.Obszycie
                       select new ObszycieDTO
                       {
                           Id = o.Id,
                           Nazwa = o.Nazwa,
                           Uwagi = o.Uwagi,
                           Status="baza"
                       };

            obsz.OrderBy(o => o.Nazwa);

            return obsz;
        }

        // GET: api/Obszycie/5
        [ResponseType(typeof(ObszycieDTO))]
        public async Task<IHttpActionResult> GetObszycie(int id)
        {
            Obszycie obszycie = await db.Obszycie.FindAsync(id);
            if (obszycie == null)
            {
                return NotFound();
            }

            ObszycieDTO obszDTO = new ObszycieDTO
            {
                Id = obszycie.Id,
                Nazwa = obszycie.Nazwa,
                Uwagi = obszycie.Uwagi,
                Status = "baza"
            };

            return Ok(obszDTO);
        }

        // PUT: api/Obszycie/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutObszycie(int id, ObszycieDTO oDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id == 0)
            {
                Obszycie wnNew = new Obszycie
                {
                    Nazwa = oDTO.Nazwa,
                    Uwagi = oDTO.Uwagi
                };
                db.Obszycie.Add(wnNew);
                db.SaveChanges();

                id = wnNew.Id;

                return CreatedAtRoute("DefaultApi", new { id = wnNew.Id }, wnNew);
            };


            if (!ObszycieExists(id))
            {
                return NotFound();
            }


            if (oDTO.Status == "zmieniony")
            {
                var oMod = db.Obszycie.Find(id);
                oMod.Nazwa = oDTO.Nazwa;
                oMod.Uwagi = oDTO.Uwagi;
            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObszycieExists(id))
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




        // DELETE: api/Obszycie/5
        [ResponseType(typeof(Obszycie))]
        public async Task<IHttpActionResult> DeleteObszycie(int id)
        {
            Obszycie obszycie = await db.Obszycie.FindAsync(id);
            if (obszycie == null)
            {
                return NotFound();
            }

            db.Obszycie.Remove(obszycie);
            await db.SaveChangesAsync();

            return Ok(obszycie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObszycieExists(int id)
        {
            return db.Obszycie.Count(e => e.Id == id) > 0;
        }
    }
}