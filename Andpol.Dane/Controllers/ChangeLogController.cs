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

namespace Andpol.Dane.Pomocne
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    public class ChangeLogController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/ChangeLog
        public IQueryable<ChangeLog> GetChangeLog()
        {
            return db.ChangeLog;
        }

        // GET: api/ChangeLog/5
        [ResponseType(typeof(ChangeLog))]
        public async Task<IHttpActionResult> GetChangeLog(int id)
        {
            ChangeLog changeLog = await db.ChangeLog.FindAsync(id);
            if (changeLog == null)
            {
                return NotFound();
            }

            return Ok(changeLog);
        }

        // PUT: api/ChangeLog/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChangeLog(int id, ChangeLog changeLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != changeLog.ChangeLogId)
            {
                return BadRequest();
            }

            db.Entry(changeLog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeLogExists(id))
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

        // POST: api/ChangeLog
        [ResponseType(typeof(ChangeLog))]
        public async Task<IHttpActionResult> PostChangeLog(ChangeLog changeLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            changeLog.Data = DateTime.Now;

            db.ChangeLog.Add(changeLog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = changeLog.ChangeLogId }, changeLog);
        }

        // DELETE: api/ChangeLog/5
        [ResponseType(typeof(ChangeLog))]
        public async Task<IHttpActionResult> DeleteChangeLog(int id)
        {
            ChangeLog changeLog = await db.ChangeLog.FindAsync(id);
            if (changeLog == null)
            {
                return NotFound();
            }

            db.ChangeLog.Remove(changeLog);
            await db.SaveChangesAsync();

            return Ok(changeLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChangeLogExists(int id)
        {
            return db.ChangeLog.Count(e => e.ChangeLogId == id) > 0;
        }
    }
}