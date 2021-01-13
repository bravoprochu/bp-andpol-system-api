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
    [Authorize(Roles ="QrCode")]
    [EnableCors("*", "*", "*")]
    public class QrCodeBasketController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/QrCodeBasket
        public IQueryable<QrCodeBasket> GetQrCodeBasket()
        {
            return db.QrCodeBasket;
        }

        // GET: api/QrCodeBasket/5
        [ResponseType(typeof(QrCodeBasket))]
        public async Task<IHttpActionResult> GetQrCodeBasket(int id)
        {
            QrCodeBasket qrCodeBasket = await db.QrCodeBasket.FindAsync(id);
            if (qrCodeBasket == null)
            {
                return NotFound();
            }

            return Ok(qrCodeBasket);
        }

        // PUT: api/QrCodeBasket/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQrCodeBasket(int id, QrCodeBasket qrCodeBasket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qrCodeBasket.QrCodeBasketId)
            {
                return BadRequest();
            }

            db.Entry(qrCodeBasket).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QrCodeBasketExists(id))
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

        // POST: api/QrCodeBasket
        [ResponseType(typeof(QrCodeBasket))]
        public async Task<IHttpActionResult> PostQrCodeBasket(QrCodeBasket qrCodeBasket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QrCodeBasket.Add(qrCodeBasket);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = qrCodeBasket.QrCodeBasketId }, qrCodeBasket);
        }

        // DELETE: api/QrCodeBasket/5
        [ResponseType(typeof(QrCodeBasket))]
        public async Task<IHttpActionResult> DeleteQrCodeBasket(int id)
        {
            QrCodeBasket qrCodeBasket = await db.QrCodeBasket.FindAsync(id);
            if (qrCodeBasket == null)
            {
                return NotFound();
            }

            db.QrCodeBasket.Remove(qrCodeBasket);
            await db.SaveChangesAsync();

            return Ok(new { info=$"QRCode o Id: {id} został usunięty z bazy"});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QrCodeBasketExists(int id)
        {
            return db.QrCodeBasket.Count(e => e.QrCodeBasketId == id) > 0;
        }
    }
}