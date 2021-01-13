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
    [Authorize(Roles ="Tkaniny")]
    [EnableCors("*", "*", "*")]
    
    public class MaterialController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/Material
        public IQueryable GetMaterial()
        {

            var result = (from m in db.Material.Include(i=>i.MaterialGrupa)
                         select new MaterialDTO()
                         {
                             MaterialId = m.MaterialId,
                             CzyUtrudnienie = m.CzyUtrudnienie,
                             Nazwa = m.Nazwa,
                             SzerokoscBelki=m.SzerokoscBelki,
                             Uwagi = m.Uwagi,
                             MaterialGrupaKontrahent=new MaterialGrupaKontrahentDTO() {
                                 MaterialGrupaKontrahentId=m.MaterialGrupa.MaterialGrupaKontrahentId,
                                 Nazwa=m.MaterialGrupa.Nazwa,
                                 Uwagi = m.MaterialGrupa.Uwagi
                             }
                             
                             //MaterialGrupa=(from mbg in db.MaterialGrupaKontrahent where mbg.MaterialGrupaKontrahentId==m.MaterialGrupaRefId select mbg).FirstOrDefault(),
                             
                         }).OrderBy(o => o.Nazwa);
            
            return result;
        }

        // GET: api/Material/5
        [ResponseType(typeof(Material))]
        public async Task<IHttpActionResult> GetMaterial(int id)
        {
            Material material = await db.Material.FindAsync(id);
            if (material == null)
            {
                return BadRequest("Nie ma takiego rekordu");
            }

            var result = (from m in db.Material
                          where m.MaterialId == id
                          select new MaterialDTO()
                          {
                              MaterialId = material.MaterialId,
                              Nazwa = material.Nazwa,
                              Uwagi = material.Uwagi,
                              CzyUtrudnienie = m.CzyUtrudnienie,
                              MaterialGrupaKontrahent = new MaterialGrupaKontrahentDTO() {
                                  MaterialGrupaKontrahentId = m.MaterialGrupa.MaterialGrupaKontrahentId,
                                  Nazwa = m.MaterialGrupa.Nazwa,
                                  Uwagi = m.MaterialGrupa.Uwagi
                              },
                              SzerokoscBelki=m.SzerokoscBelki,
                              Status = "baza"
                          }).FirstOrDefault();


            return Ok(result);
        }

        // PUT: api/Material/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMaterial(int id, MaterialDTO mDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mDTO.MaterialId)
            {
                return BadRequest("Błąd w przesyłanych danych, niezgodny Id");
            }


            if (id == 0) {
                Material mNew = new Material();
                mNew.CzyUtrudnienie = mDTO.CzyUtrudnienie;
                mNew.MaterialGrupaRefId = mDTO.MaterialGrupaKontrahent.MaterialGrupaKontrahentId;
                mNew.SzerokoscBelki = mDTO.SzerokoscBelki;
                mNew.Uwagi = mDTO.Uwagi;
                mNew.Nazwa = mDTO.Nazwa;


                db.Material.Add(mNew);
                db.SaveChanges();

                id = mNew.MaterialId;

            } else

            if (mDTO.Status == "zmieniony") {
                Material mMod = db.Material.Find(id);
                mMod.CzyUtrudnienie = mDTO.CzyUtrudnienie;
                mMod.Nazwa = mDTO.Nazwa;
                mMod.SzerokoscBelki = mDTO.SzerokoscBelki;
                mMod.Uwagi = mDTO.Uwagi;
                mMod.MaterialGrupaRefId = mDTO.MaterialGrupaKontrahent.MaterialGrupaKontrahentId;
            }

            if (mDTO.Status == "usuniety") {
                db.Material.Remove(db.Material.Find(id));
            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Material
        [ResponseType(typeof(MaterialBelka))]
        public async Task<IHttpActionResult> PostMaterial(Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Material.Add(material);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = material.MaterialId }, material);
        }

        // DELETE: api/Material/5
        [ResponseType(typeof(Material))]
        public async Task<IHttpActionResult> DeleteMaterial(int id)
        {
            Material material = await db.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            db.Material.Remove(material);
            await db.SaveChangesAsync();

            return Ok(material);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialExists(int id)
        {
            return db.Material.Count(e => e.MaterialId == id) > 0;
        }
    }
}