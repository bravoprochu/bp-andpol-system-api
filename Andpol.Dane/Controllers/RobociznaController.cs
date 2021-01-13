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
    [Authorize(Roles ="Planning, Normy")]
    [EnableCors("*", "*", "*")]
    
    public class RobociznaController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/Robocizna
        public IHttpActionResult GetRobociznas()
        {
            var result = (from n in db.Robocizna
                         select new RobociznaDTO()
                         {
                             Id = n.Id,
                             ProdukcjaDzial=new ProdukcjaDzialDTO() {
                                 ProdukcjaDzialId=n.ProdukcjaDzialRefId,
                                 Nazwa=n.ProdukcjaDzial.Nazwa,
                             },
                             Nazwa = n.Nazwa,
                             Uwagi = n.Uwagi,
                            Status="baza"
                         }).OrderBy(o => o.Nazwa);

            return Ok(result);
        }

        // GET: api/Robocizna/5
        [ResponseType(typeof(RobociznaDTO))]
        public IHttpActionResult GetRobocizna(int id)
        {
            var rob = db.Robocizna.Find(id);
            if (rob == null) { return BadRequest("Nie znaleziono rekordu"); }

            var result = (from r in db.Robocizna where r.Id == id
                          select new RobociznaDTO()
                          {
                              Id = r.Id,
                              ProdukcjaDzial = new ProdukcjaDzialDTO()
                              {
                                  
                                  Nazwa = r.ProdukcjaDzial.Nazwa,
                                  ProdukcjaDzialId = r.ProdukcjaDzial.ProdukcjaDzialId,
                              },
                              Nazwa = r.Nazwa,
                              Uwagi = r.Uwagi,
                              Status = "baza"
                          }).FirstOrDefault();



            return Ok(new {info=$"Dane o id: {id} zostaly pobrane właściwie", result});
        }

        // PUT: api/Robocizna/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRobocizna(int id, RobociznaDTO rDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id == 0) {
                Robocizna rNew = new Robocizna
                {
                    Nazwa = rDTO.Nazwa,
                    Uwagi = rDTO.Uwagi,
                    ProdukcjaDzialRefId=rDTO.ProdukcjaDzial.ProdukcjaDzialId
                    
                };
                db.Robocizna.Add(rNew);
                db.SaveChanges();
                
                id = rNew.Id;

                return CreatedAtRoute("DefaultApi", new { id = rNew.Id }, rNew);
            };


            if (!RobociznaExists(id))
            {
                return NotFound();
            }


            if(rDTO.Status=="zmieniony")
            {
                var rMod = db.Robocizna.Find(id);
                rMod.Nazwa = rDTO.Nazwa;
                rMod.Uwagi = rDTO.Uwagi;
                rMod.ProdukcjaDzialRefId = rDTO.ProdukcjaDzial.ProdukcjaDzialId;
            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RobociznaExists(id))
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

        // DELETE: api/WykonczenieBoczka/5
        [ResponseType(typeof(Robocizna))]
        public async Task<IHttpActionResult> DeleteRobocizna(int id)
        {
            Robocizna robocizna = await db.Robocizna.FindAsync(id);
            if (robocizna == null)
            {
                return NotFound();
            }

            db.Robocizna.Remove(robocizna);
            await db.SaveChangesAsync();

            return Ok("OK");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RobociznaExists(int id)
        {
            return db.Robocizna.Count(e => e.Id == id) > 0;
        }

    }
}