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
using Andpol.Dane.Pomocne;

namespace Andpol.Dane.Pomocne
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    public class BazaJednostekController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/BazaJednostek
        public IQueryable<JednGrupaZakladowa> GetJednGrupaZakladowa()
        {
            return db.JednGrupaZakladowa;
        }

        [HttpGet]
        [Route("api/bazaJednostek/jednostkaMiary")]
        public IHttpActionResult JednostkaMiary()
        {

            var result = (from j in db.JednJednostkaMiary
                          select new
                          {
                              JednJednostkaMiaryId = j.JednJednostkaMiaryId,
                              Nazwa = j.Nazwa,
                              Uwagi = j.Uwagi
                          }).OrderBy(o => o.JednJednostkaMiaryId);


            return Ok(result);
        }

        [HttpGet]
        [Route("api/bazaJednostek/podatekStawka")]
        public IHttpActionResult PodatekStawka()
        {
            var result = (from p in db.JednPodatekStawka
                          select new PodatekStawkaDTO
                          {
                              JednPodatekStawkaId = p.JednPodatekStawkaId,
                              Nazwa = p.Nazwa,
                              Wartosc = p.Wartosc,
                              Uwagi = p.Uwagi

                          }).OrderBy(o => o.JednPodatekStawkaId);


            return Ok(result);
        }

        [HttpGet]
        [Route("api/bazaJednostek/grupaZakladowa")]
        public IHttpActionResult GrupaZakladowa()
        {
            var result = (from g in db.JednGrupaZakladowa
                          select new
                          {
                              JednGrupaZakladowaId = g.JednGrupaZakladowaId,
                              Nazwa = g.Nazwa,
                              Uwagi = g.Uwagi

                          }).OrderBy(o => o.JednGrupaZakladowaId);


            return Ok(result);
        }


        [HttpGet]
        [Route("api/bazaJednostek/marzaZakladowa")]
        public IHttpActionResult MarzaZakladowa()
        {
            var result = (from m in db.JednMarzaZakladowa
                          select new
                          {
                              JednMarzaZakladowaId = m.JednMarzaZakladowaId,
                              Nazwa = m.Nazwa,
                              Wartosc = m.Wartosc,
                              Uwagi = m.Uwagi

                          }).OrderBy(o => o.JednMarzaZakladowaId);


            return Ok(result);
        }


        [HttpGet]
        [Route("api/bazaJednostek/dokumentTyp")]
        public IHttpActionResult DokumentTyp()
        {

            var result = (from dt in db.JednDokumentTyp
                          select new DokumentTypDTO()
                          {
                              DokumentTypId = dt.JednDokumentTypId,
                              Nazwa = dt.Nazwa,
                              Uwagi = dt.Uwagi
                          }).OrderBy(x=>x.DokumentTypId);

            return Ok(result);
        }

        [HttpGet]
        [Route("api/bazaJednostek/platnoscRodzaj")]
        public IHttpActionResult PlatnoscRodzaj()
        {

            var result = (from pr in db.JednPlatnoscRodzaj
                          select pr);
                          //{
                          //    JednPlatnoscRodzajId = pr.JednPlatnoscRodzajId,
                          //    Nazwa = pr.Nazwa,
                          //    CzyDni=pr.CzyDni,
                          //    CzyUwagi=pr.CzyUwagi
                              
                          //}).ToList().OrderBy(x => x.JednPlatnoscRodzajId);

            return Ok(result);
        }


        [HttpGet]
        [Route("api/bazaJednostek/produkcjaDzial")]
        public IHttpActionResult ProdukcjaDzial()
        {
            var result = (from pd in db.ProdukcjaDzial
                          select new ProdukcjaDzialDTO()
                          {
                              ProdukcjaDzialId = pd.ProdukcjaDzialId,
                              CzyPozycjaMagazynowa = pd.CzyPozycjaMagazynowa,
                              CzyTkaninaBelka = pd.CzyTkaninaBelka,
                              NadrzednyIds = pd.NadrzedneIds,
                              GrupaRobocza = pd.Robocizna.Select(s => new PlanningGrupaRoboczaSkladDTO() {
                                  Id = s.Id,
                                  Nazwa = s.Nazwa,
                                  Uwagi = s.Uwagi
                              }).ToList(),
                              Nazwa = pd.Nazwa,
                              PoziomProdukcji = pd.PoziomProdukcji,
                              Uwagi = pd.Uwagi
                          }).ToList();

            foreach (var d in result)
            {
                d.NadrzednyNazwaLista = db.ProdukcjaDzial.WhereIn(wi => wi.ProdukcjaDzialId, d.NadrzednyIdsLista).Select(s => s.Nazwa).ToList();
            }


            return Ok(result.ToList());
        }
        [HttpPost]
        [Route("api/BazaJednostek/raportList")]
        public IHttpActionResult RaportList(List<string> lista)
        {
            return Ok(StringHelpful.StringListGroup(lista));
        }



        [HttpGet]
        [Route("api/bazaJednostek/rozchodMagRodzaj")]
        public IHttpActionResult RozchodMagRodzaj()
        {
            var result = (from rmr in db.JednRozchodMagRodzaj
                          select rmr);


            

            return Ok(result);
        }


        [HttpGet]
        [Route("api/bazaJednostek/materialGrupaKontrahent")]
        public IHttpActionResult MaterialGrupaKontrahent()
        {
            var result = from mgk in db.MaterialGrupaKontrahent
                          select new MaterialGrupaKontrahentDTO() {
                              MaterialGrupaKontrahentId = mgk.MaterialGrupaKontrahentId,
                              Nazwa = mgk.Nazwa,
                              Uwagi = mgk.Uwagi,
                          };

            
            return Ok(result);
        }

        [HttpGet]
        [Route("api/bazaJednostek/waluta")]
        public IHttpActionResult Waluta()
        {
            var result = (from g in db.FinWaluta
                          select new
                          {
                              WalutaId = g.FinWalutaId,
                              Nazwa = g.Nazwa,
                              Skrot = g.Skrot

                          }).OrderBy(o => o.WalutaId);


            return Ok(result);
        }

        [HttpGet]
        [Route("api/bazaJednostek/jednostkiRazem")]
        public IHttpActionResult JednostkiRazem()
        {

            var dokumentTyp = (from dt in db.JednDokumentTyp
                               select new DokumentTypDTO()
                               {
                                   DokumentTypId = dt.JednDokumentTypId,
                                   Nazwa = dt.Nazwa,
                                   Uwagi = dt.Uwagi
                               }).OrderBy(x => x.DokumentTypId);

            var marza = (from m in db.JednMarzaZakladowa
                         select new
                         {
                             JednMarzaZakladowaId = m.JednMarzaZakladowaId,
                             Nazwa = m.Nazwa,
                             Wartosc = m.Wartosc,
                             Uwagi = m.Uwagi

                         }).OrderBy(o => o.JednMarzaZakladowaId);


            var grupaZakladowa = (from g in db.JednGrupaZakladowa
                                  select new
                                  {
                                      JednGrupaZakladowaId = g.JednGrupaZakladowaId,
                                      Nazwa = g.Nazwa,
                                      Uwagi = g.Uwagi

                                  }).OrderBy(o => o.JednGrupaZakladowaId);

            var podatekStawka = (from p in db.JednPodatekStawka
                                 select new
                                 {
                                     JednPodatekStawkaId = p.JednPodatekStawkaId,
                                     Nazwa = p.Nazwa,
                                     Wartosc = p.Wartosc,
                                     Uwagi = p.Uwagi

                                 }).OrderBy(o => o.JednPodatekStawkaId);

            var jednostkaMiary = (from j in db.JednJednostkaMiary
                                  select new
                                  {
                                      JednJednostkaMiaryId = j.JednJednostkaMiaryId,
                                      Nazwa = j.Nazwa,
                                      Uwagi = j.Uwagi
                                  }).OrderBy(o => o.JednJednostkaMiaryId);

            var waluta = (from g in db.FinWaluta
                          select new
                          {
                              WalutaId = g.FinWalutaId,
                              Nazwa = g.Nazwa,
                              Skrot = g.Skrot

                          }).OrderBy(o => o.WalutaId);


            var result = new
            {
                dokumentTyp,
                grupaZakladowa,
                jednostkaMiary,
                marza,
                podatekStawka,
                waluta                
                
            };

            
            return Ok(result);
        }


    }
}