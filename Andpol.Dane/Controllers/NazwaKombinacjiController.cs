using Andpol.Dane.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Andpol.Dane.ModelsDTO;


namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="Normy")]
    [EnableCors("*", "*", "*")]
    
    public class NazwaKombinacjiController : ApiController
    {
        private PoligonContext db = new PoligonContext();

         //GET: api/NazwaKombinacji
        //public IQueryable<NazwaKombinacji> GetNazwaKombinacji()
        //{
        //    return db.NazwaKombinacji;
        //}

        public IQueryable<NazwaKombinacjiDTO> GetNazwaKombinacji()
        {
            var kombinacje = from n in db.NazwaKombinacji
                             select new NazwaKombinacjiDTO()
                             {
                                 Id = n.Id,
                                 Nazwa = n.Nazwa,
                                 Uwagi = n.Uwagi
                             };


            return kombinacje;
        }



        // GET: api/NazwaKombinacji/5
        //[ResponseType(typeof(NazwaKombinacji))]
        //public async Task<IHttpActionResult> GetNazwaKombinacji(int id)
        //{
        //    NazwaKombinacji nazwaKombinacji = await db.NazwaKombinacji.FindAsync(id);
        //    if (nazwaKombinacji == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(nazwaKombinacji);
        //}


        [ResponseType(typeof(NazwaKombinacji))]
        public async Task<IHttpActionResult> GetNazwaKombinacji(int id)
        {
            NazwaKombinacji nazwaKombinacji = await db.NazwaKombinacji.FindAsync(id);
            if (nazwaKombinacji == null)
            {
                return NotFound();
            }
            
            NazwaKombinacjiDTO nkDTO = new NazwaKombinacjiDTO
            {
                Id = nazwaKombinacji.Id,
                Nazwa = nazwaKombinacji.Nazwa,
                Uwagi = nazwaKombinacji.Uwagi,
                Status = "baza"
            };

            return Ok(nkDTO);
        }


        // PUT: api/NazwaKombinacji/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNazwyKombinacji(int id, NazwaKombinacjiDTO nkDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id == 0)
            {
                NazwaKombinacji nkNew = new NazwaKombinacji
                {
                    Nazwa = nkDTO.Nazwa,
                    Uwagi = nkDTO.Uwagi
                };
                db.NazwaKombinacji.Add(nkNew);
                db.SaveChanges();

                id = nkNew.Id;
            };


            if (!NazwaKombinacjiExists(id))
            {
                return NotFound();
            }


            if (nkDTO.Status == "zmieniony")
            {
                var rMod = db.NazwaKombinacji.Find(id);
                rMod.Nazwa = nkDTO.Nazwa;
                rMod.Uwagi = nkDTO.Uwagi;
            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NazwaKombinacjiExists(id))
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


        // DELETE: api/NazwaKombinacji/5
        [ResponseType(typeof(NazwaKombinacji))]
        public async Task<IHttpActionResult> DeleteNazwaKombinacji(int id)
        {
            NazwaKombinacji nazwaKombinacji = await db.NazwaKombinacji.FindAsync(id);
            if (nazwaKombinacji == null)
            {
                return NotFound();
            }

            db.NazwaKombinacji.Remove(nazwaKombinacji);
            await db.SaveChangesAsync();

            return Ok(nazwaKombinacji);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NazwaKombinacjiExists(int id)
        {
            return db.NazwaKombinacji.Count(e => e.Id == id) > 0;
        }
    }
}