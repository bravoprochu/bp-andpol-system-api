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
using System.Net.Mail;

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="Dashboard")]
    [EnableCors("*", "*", "*")]
    public class SprawkiController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/Sprawki
        public IQueryable<Sprawki> GetSprawki()
        {
            return db.Sprawki;
        }

        // GET: api/Sprawki/5
        [ResponseType(typeof(Sprawki))]
        public async Task<IHttpActionResult> GetSprawki(int id)
        {
            Sprawki sprawki = await db.Sprawki.FindAsync(id);
            if (sprawki == null)
            {
                return NotFound();
            }

            return Ok(sprawki);
        }

        // PUT: api/Sprawki/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSprawki(int id, Sprawki sprawki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sprawki.SprawkiId)
            {
                return BadRequest();
            }

            db.Entry(sprawki).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprawkiExists(id))
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

        // POST: api/Sprawki
        [ResponseType(typeof(Sprawki))]
        public async Task<IHttpActionResult> PostSprawki(Sprawki sprawki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            sprawki.DataZgloszenia = DateTime.Now;

            db.Sprawki.Add(sprawki);
            await db.SaveChangesAsync();

            

            MailAddress mailFrom = new MailAddress("andpolsystem@gmail.com", "AndpolSystem Admin");
            MailAddress mailTo = new MailAddress("bartoszprochowski@hotmail.com");

            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.Body = "<h1>"+sprawki.Tytul+"</h1><h3>"+sprawki.Grupa+"</h3><small>priorytet: <strong>"+sprawki.Priorytet+"</strong></small><h4>"+sprawki.Opis+"</h4>";
            msg.To.Add(mailTo);
            msg.From = mailFrom;
            msg.Subject = "Andpol System SPRAWKI";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;


            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("andpolsystem@gmail.com", "AndpolSystem1234!");


            try
            {
                client.Send(msg);
            }
            catch (Exception)
            {

                throw;
            }




            return CreatedAtRoute("DefaultApi", new { id = sprawki.SprawkiId }, sprawki);
        }

        // DELETE: api/Sprawki/5
        [ResponseType(typeof(Sprawki))]
        public async Task<IHttpActionResult> DeleteSprawki(int id)
        {
            Sprawki sprawki = await db.Sprawki.FindAsync(id);
            if (sprawki == null)
            {
                return NotFound();
            }

            db.Sprawki.Remove(sprawki);
            await db.SaveChangesAsync();

            return Ok(sprawki);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SprawkiExists(int id)
        {
            return db.Sprawki.Count(e => e.SprawkiId == id) > 0;
        }
    }
}