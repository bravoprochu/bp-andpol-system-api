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
    [Authorize(Roles ="MagazynPozycjaMagazynowa, MagazynMagazynier, MagazynPz")]
    [EnableCors("*", "*", "*")]
    public class MagPozycjaMagazynowaController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/MagPozycjaMagazynowa
        public IQueryable GetMagPozycjaMagazynowa()
        {
            var result = (from mpm in db.MagPozycjaMagazynowa.Include(pp => pp.MagPZPozycjaColl).Include(pmr=>pmr.MagPozycjaMagazynowaRozchodInne)
                          let razemPz = mpm.MagPZPozycjaColl.Where(p => p.Valid == true).Sum(x => (double?)(x.Ilosc)) ?? 0
                          let razemRozchodInne = mpm.MagPozycjaMagazynowaRozchodInne.Sum(y => (double?)(y.Wartosc)) ?? 0
                          let razemWz=mpm.MagWzPozycjaPozMag.Where(w=>w.MagWz.CzyKorekta==false).Sum(wz=>(double?)(wz.Ilosc))??0
                          select new
                          {
                              GrupaZakladowa = mpm.GrupaZakladowa.Nazwa,
                              Jednostka = mpm.JednostkaMiary.Nazwa,
                              Nazwa = mpm.Nazwa,
                              PozycjaMagazynowaId = mpm.MagPozycjaMagazynowaId,
//                              RazemPz =razemPz,
                              RazemRozchodInne = razemRozchodInne,
                              RazemWZ=razemWz,
                              StanAktualny =mpm.StanAktualny,
                              StanRzeczywisty=mpm.StanRzeczywisty,
                              Uwagi = mpm.Uwagi,
                          });

            return result;
        }

        // GET: api/MagPozycjaMagazynowa/5
        [ResponseType(typeof(MagPozycjaMagazynowa))]
        public async Task<IHttpActionResult> GetMagPozycjaMagazynowa(int id)
        {

            MagPozycjaMagazynowa magPozycjaMagazynowa = await db.MagPozycjaMagazynowa.FindAsync(id);


            if (magPozycjaMagazynowa == null)
            {
                return BadRequest("Nie znaleziono rekordu");
            }

            var pozycjaMagazynowa = await (from mp in db.MagPozycjaMagazynowa.Include(pzp => pzp.MagPZPozycjaColl).Include(pz => pz.MagPZPozycjaColl)
                                           where mp.MagPozycjaMagazynowaId == id
                                           let razemPz = mp.MagPZPozycjaColl.Where(p => p.Valid == true).Sum(x => (double?)(x.Ilosc)) ?? 0
                                           let razemRozchodInne = mp.MagPozycjaMagazynowaRozchodInne.Sum(y => (double?)(y.Wartosc)) ?? 0
                                           let razemWz=mp.MagWzPozycjaPozMag.Where(w => w.MagWz.CzyKorekta == false).Sum(wz=>(double?)(wz.Ilosc))?? 0
                                           select new MagPozycjaMagazynowaFullCennikDTO()
                                           {
                                               CzyPotwierdzone = mp.czyPotwierdzone,
                                               GrupaZakladowa = mp.GrupaZakladowa,
                                               JednostkaMiary = mp.JednostkaMiary,
                                               KodKreskowy = mp.KodKreskowy,
                                               MarzaZakladowa = mp.MarzaZakladowa,
                                               Nazwa = mp.Nazwa,
                                               PrzyjecieZewnetrzne = mp.MagPZPozycjaColl.Where(p => p.Valid == true).Select(pz => new MagPozycjaMagazynowaPrzyjecieZewnetrzneDTO
                                               {
                                                   PzId = pz.MagPzRefId == null ? pz.MagPzKorekta.MagPzKorektaId : pz.MagPz.MagPzId,
                                                   DokumentZrodlowyNr= pz.MagPzRefId == null ? pz.MagPzKorekta.DokumentZrodlowyNr: pz.MagPz.DokumentZrodlowyNr,
                                                   CzyKorekta=pz.MagPzRefId==null? pz.MagPzKorekta.MagPz.CzyKorekta: pz.MagPz.CzyKorekta,
                                                   CreatedBy = pz.MagPzRefId == null ? pz.MagPzKorekta.CreatedBy : pz.MagPz.CreatedBy,
                                                   DataWplywu = pz.MagPzRefId == null ? pz.MagPzKorekta.DataWplywu : pz.MagPz.DataWplywu,
                                                   Ilosc=pz.Ilosc,
                                                   Kontrahent = pz.MagPzRefId == null ? new KontrahentInfoDTO()
                                                   {
                                                       Kontrahent=pz.MagPzKorekta.Kontrahent,
                                                       KontrahentId=pz.MagPzKorekta.KontrahentRefId
                                                   }: new KontrahentInfoDTO() {
                                                       Kontrahent=pz.MagPz.Kontrahent,
                                                       KontrahentId=pz.MagPz.KontrahentRefId
                                                   },
                                                   Uwagi = pz.MagPz.Uwagi,
                                               }).ToList(),
                                               RozchodInne = mp.MagPozycjaMagazynowaRozchodInne.Select(c => new MagPozycjaMagazynowaRozchodInneDTO() { CreatedBy = c.CreatedBy, DataRozchodu = c.DataRozchodu, Id = c.MagPozycjaMagazynowaRozchodInneId, RozchodMagRodzaj = c.RozchodMagRodzaj, Uwagi = c.Uwagi, Wartosc = c.Wartosc }).ToList(),
                                               
                                               Status = "baza",
                                               Stan = new MagPozycjaMagazynowaStanDTO()
                                               {
                                                   RazemPz = razemPz,
                                                   RazemRozchodInne = razemRozchodInne,
                                                   RazemWz=razemWz,
                                                   StanAktualny = (double?)(mp.StanAktualny) ?? 0,
                                                   StanRzeczywisty = (double?)(mp.StanRzeczywisty) ?? 0
                                               },
                                               StanMinAlarm = mp.StanMinAlarm,
                                               TypTowaru = mp.TypTowaru,
                                               Uwagi = mp.Uwagi,
                                               VatSprzedazy = mp.VatSprzedazy,
                                               VatZakupu = mp.VatZakupu,
                                               WydanieZewnetrzne=mp.MagWzPozycjaPozMag.Where(w => w.MagWz.CzyKorekta == false).Select(wz=>new MagPozycjaMagazynowaWydanieZewnetrzneDTO {
                                                   CreatedBy=wz.MagWz.CreatedBy,
                                                   CreatedDateTime=wz.MagWz.CreatedDateTime,
                                                   DataWystawienia=wz.MagWz.DataWystawienia,
                                                   Ilosc=wz.Ilosc,
                                                   Kontrahent=new KontrahentInfoDTO {
                                                       Kontrahent=wz.MagWz.Kontrahent,
                                                       KontrahentId=wz.MagWz.KontrahentRefId
                                                   },
                                                   MagWzId=wz.MagWzRefId,
                                                   NumerDokumentu=wz.MagWz.NumerDokumentu,
                                                   Uwagi=wz.MagWz.Uwagi
                                               }).ToList(),
                                               Statystyki = (from z in db.FinFakturaPozycje
                                                             where z.PozycjaMagazynowaRefId == id
                                                             group z by z.PozycjaMagazynowaRefId into zGroup

                                                             select new StatystykiDTO()
                                                             {
                                                                 Min = zGroup.Min(x => x.Cena),
                                                                 Max = zGroup.Max(x => x.Cena),
                                                                 Avg = zGroup.Average(x => x.Cena),
                                                                 Count = zGroup.Count(),
                                                                 Ostatni = (from fp in db.FinFakturaPozycje
                                                                            join fz in db.FinFakturaZakupu on fp.FakturaZakupuRefId equals fz.FinFakturaZakupuId
                                                                            join k in db.Kontrahent on fz.KontrahentRefId equals k.KontrahentId
                                                                            where fp.PozycjaMagazynowaRefId == zGroup.Key
                                                                            orderby fz.DataWystawienia descending
                                                                            select new MagPozOstatniDTO()
                                                                            {
                                                                                Cena = fp.Cena,
                                                                                DataOstatniegoZakupu = fz.DataWystawienia,
                                                                                Kontrahent = k.Skrot
                                                                            }).FirstOrDefault()
                                                             }).FirstOrDefault(),
                                               Zakupy = (from fp in db.FinFakturaPozycje
                                                         join fz in db.FinFakturaZakupu on fp.FakturaZakupuRefId equals fz.FinFakturaZakupuId
                                                         join pm in db.MagPozycjaMagazynowa on fp.PozycjaMagazynowaRefId equals pm.MagPozycjaMagazynowaId
                                                         join k in db.Kontrahent on fz.KontrahentRefId equals k.KontrahentId

                                                         where pm.MagPozycjaMagazynowaId == id
                                                         select new MagPozycjaMagazynowaZakupyDTO
                                                         {
                                                             Cena = fp.Cena,
                                                             FakturaNr = fz.FakturaNr,
                                                             FinFakturaZakupuId = fz.FinFakturaZakupuId,
                                                             DataSprzedazy = fz.DataWystawienia,
                                                             Ilosc = fp.Ilosc,
                                                             Kontrahent = (k.Nazwa == null ? k.Imie + " " + k.Nazwisko : k.Nazwa),
                                                             Wartosc = fp.Ilosc * fp.Cena,
                                                         }
                                                        ).ToList()
                                           }).FirstOrDefaultAsync();




            //var zakupy = await (from fp in db.FinFakturaPozycje
            //              join fz in db.FinFakturaZakupu on fp.FakturaZakupuRefId equals fz.FinFakturaZakupuId
            //              join pm in db.MagPozycjaMagazynowa on fp.PozycjaMagazynowaRefId equals pm.MagPozycjaMagazynowaId
            //              join k in db.Kontrahent on fz.KontrahentRefId equals k.KontrahentId

            //              where pm.MagPozycjaMagazynowaId==id
            //              select new {
            //                  Cena = fp.Cena,
            //                  FakturaNr = fz.FakturaNr,
            //                  FinFakturaZakupuId=fz.FinFakturaZakupuId,
            //                  DataSprzedazy = fz.DataWystawienia,
            //                  Ilosc =fp.Ilosc,
            //                  Kontrahent= (k.Nazwa == null ? k.Imie + " " + k.Nazwisko : k.Nazwa),
            //                  Wartosc = fp.Ilosc * fp.Cena,
            //              }
            //             ).ToListAsync();


            //return Ok( new { pozycjaMagazynowa, zakupy});


            return Ok(pozycjaMagazynowa);
        }

        // PUT: api/MagPozycjaMagazynowa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMagPozycjaMagazynowa(int id, MagPozycjaMagazynowaFullCennikDTO mpmDTO)
        {


            if (id == 0)
            {
                MagPozycjaMagazynowa mpmNew = new MagPozycjaMagazynowa()
                {
                    Nazwa = mpmDTO.Nazwa,
                    Uwagi = mpmDTO.Uwagi,
                    GrupaZakladowaRefId = mpmDTO.GrupaZakladowa.JednGrupaZakladowaId,
                    JednostkaMiaryRefId = mpmDTO.JednostkaMiary.JednJednostkaMiaryId,
                    KodKreskowy = mpmDTO.KodKreskowy,
                    MarzaZakladowaRefId = mpmDTO.MarzaZakladowa.JednMarzaZakladowaId,
                    TypTowaru = mpmDTO.TypTowaru,
                    VatSprzedazyRefId = mpmDTO.VatSprzedazy.JednPodatekStawkaId,
                    VatZakupuRefId = mpmDTO.VatZakupu.JednPodatekStawkaId,
                    czyPotwierdzone = mpmDTO.CzyPotwierdzone,
                    StanMinAlarm =mpmDTO.StanMinAlarm.HasValue ? mpmDTO.StanMinAlarm : null,
                };

                db.MagPozycjaMagazynowa.Add(mpmNew);
                await db.SaveChangesAsync();

                id = mpmNew.MagPozycjaMagazynowaId;

                var newAdded = (from mg in db.MagPozycjaMagazynowa
                                where mg.MagPozycjaMagazynowaId == id
                                select new MagPozycjaMagazynowaDTO()
                                {
                                    Jednostka = mg.JednostkaMiary.Nazwa,
                                    Nazwa = mg.Nazwa,
                                    PozycjaMagazynowaId = mg.MagPozycjaMagazynowaId,
                                    Uwagi = mg.Uwagi,
                                    Status = "baza"
                                }).FirstOrDefault();
            return Ok(newAdded);

            }
            else {

                if (await db.MagPozycjaMagazynowa.FindAsync(id) == null)
                {
                    return BadRequest("Nie znalazłem");
                }



                if (mpmDTO.Status == "zmieniony")
                {

                    var stanRzeczywisty = await (from mp in db.MagPozycjaMagazynowa.Include(ppz => ppz.MagPZPozycjaColl).Include(pri => pri.MagPozycjaMagazynowaRozchodInne)
                                          where mp.MagPozycjaMagazynowaId == id
                                          let razemPz= mp.MagPZPozycjaColl.Where(p => p.Valid == true).Sum(x => (double?)(x.Ilosc)) ?? 0
                                          let razemRozchodInne= mp.MagPozycjaMagazynowaRozchodInne.Sum(y => (double?)(y.Wartosc)) ?? 0
                                          select new MagPozycjaMagazynowaStanDTO()
                                          {
                                            RazemPz = razemPz,
                                            RazemRozchodInne = razemRozchodInne,
                                            RazemWz = mp.MagWzPozycjaPozMag.Sum(wz => (double?)(wz.Ilosc)) ?? 0,
                                            StanRzeczywisty =razemPz-razemRozchodInne,
                                            StanAktualny=razemPz-razemRozchodInne
                                          }).FirstOrDefaultAsync();
                    var rozchodInneRazem = (from ri in db.MagPozycjaMagazynowaRozchodInne
                                           where ri.PozycjaMagazynowaRefId == id
                                           group ri by ri.MagPozycjaMagazynowaRozchodInneId into riGroup
                                           select new
                                           {
                                               Wartosc = riGroup.Sum(s => (double?)(s.Wartosc)) ?? 0
                                           });

                    var mpmMod = db.MagPozycjaMagazynowa.Find(id);
                    if (mpmMod.StanRzeczywisty != mpmDTO.Stan.StanRzeczywisty || mpmMod.StanAktualny!=mpmDTO.Stan.StanAktualny) { return BadRequest("Stan rzeczywisty uległ zmianie, odśwież dane pozycji magazynowej"); }

//                    if (stanRzeczywisty.StanRzeczywisty != mpmDTO.Stan.StanRzeczywisty) { return BadRequest("Stan rzeczywisty uległ zmianie, odśwież dane pozycji magazynowej"); }

                    mpmMod.czyPotwierdzone = mpmDTO.CzyPotwierdzone;
                    mpmMod.GrupaZakladowaRefId = mpmDTO.GrupaZakladowa.JednGrupaZakladowaId;
                    mpmMod.JednostkaMiaryRefId = mpmDTO.JednostkaMiary.JednJednostkaMiaryId;
                    mpmMod.KodKreskowy = mpmDTO.KodKreskowy;
                    mpmMod.MarzaZakladowaRefId = mpmDTO.MarzaZakladowa.JednMarzaZakladowaId;
                    mpmMod.Nazwa = mpmDTO.Nazwa;
                    mpmMod.TypTowaru = mpmDTO.TypTowaru;
                    mpmMod.Uwagi = mpmDTO.Uwagi;
                    mpmMod.VatSprzedazyRefId = mpmDTO.VatSprzedazy.JednPodatekStawkaId;
                    mpmMod.VatZakupuRefId = mpmDTO.VatZakupu.JednPodatekStawkaId;
                    mpmMod.StanMinAlarm = mpmDTO.StanMinAlarm.HasValue ? mpmDTO.StanMinAlarm : null;

                    //foreach (var item in mpmDTO.RozchodInne)
                    //{
                    //    if (item.Status == "nowy")
                    //    {
                    //        double t = rozchodInneRazem.Sum(s =>(double?)(s.Wartosc)) ?? 0;

                    //        //if (stanRzeczywisty.StanRzeczywisty - item.Wartosc >= 0 && ((item.Wartosc + stanRzeczywisty.RazemRozchodInne) <= stanRzeczywisty.RazemPz))
                    //            if(mpmMod.StanRzeczywisty-item.Wartosc>=0 && ((item.Wartosc+ rozchodInneRazem)<=
                    //        {

                    //            db.MagPozycjaMagazynowaRozchodInne.Add(new MagPozycjaMagazynowaRozchodInne()
                    //            {
                    //                CreatedBy = item.CreatedBy,
                    //                CreatedDateTime = DateTime.Now,
                    //                DataRozchodu = item.DataRozchodu,
                    //                PozycjaMagazynowaRefId = id,
                    //                RozchodMagRodzajRefId = item.RozchodMagRodzaj.JednRozchodMagRodzajId,
                    //                Uwagi = item.Uwagi,
                    //                Wartosc = item.Wartosc
                    //            });

                    //            stanRzeczywisty.StanRzeczywisty -= item.Wartosc;
                    //            stanRzeczywisty.RazemRozchodInne -= item.Wartosc;
                    //        } else {
                    //            return BadRequest("Wartość rozchodu jest nieprawidłowa !");
                    //        }
                    //    }

                    //}

                    //nowa wersja

                    foreach (var item in mpmDTO.RozchodInne)
                    {
                        if (item.Status == "nowy")
                        {
                            db.MagPozycjaMagazynowaRozchodInne.Add(new MagPozycjaMagazynowaRozchodInne()
                            {
                                CreatedBy = item.CreatedBy,
                                CreatedDateTime = DateTime.Now,
                                DataRozchodu = item.DataRozchodu,
                                PozycjaMagazynowaRefId = id,
                                RozchodMagRodzajRefId = item.RozchodMagRodzaj.JednRozchodMagRodzajId,
                                Uwagi = item.Uwagi,
                                Wartosc = item.Wartosc
                            });
                            mpmMod.StanRzeczywisty -= item.Wartosc;
                            mpmMod.StanAktualny -= item.Wartosc;

                        }
                    }
                }

                if (mpmDTO.Status == "usuniety")
                {
                    db.MagPozycjaMagazynowa.Remove(await db.MagPozycjaMagazynowa.FindAsync(id));
                }

            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagPozycjaMagazynowaExists(id))
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

        // POST: api/MagPozycjaMagazynowa
        [ResponseType(typeof(MagPozycjaMagazynowa))]
        public async Task<IHttpActionResult> PostMagPozycjaMagazynowa(MagPozycjaMagazynowa magPozycjaMagazynowa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MagPozycjaMagazynowa.Add(magPozycjaMagazynowa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = magPozycjaMagazynowa.MagPozycjaMagazynowaId }, magPozycjaMagazynowa);
        }

        // DELETE: api/MagPozycjaMagazynowa/5
        [ResponseType(typeof(MagPozycjaMagazynowa))]
        public async Task<IHttpActionResult> DeleteMagPozycjaMagazynowa(int id)
        {
            MagPozycjaMagazynowa magPozycjaMagazynowa = await db.MagPozycjaMagazynowa.FindAsync(id);
            if (magPozycjaMagazynowa == null)
            {
                return NotFound();
            }

            db.MagPozycjaMagazynowa.Remove(magPozycjaMagazynowa);
            await db.SaveChangesAsync();

            return Ok(magPozycjaMagazynowa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MagPozycjaMagazynowaExists(int id)
        {
            return db.MagPozycjaMagazynowa.Count(e => e.MagPozycjaMagazynowaId == id) > 0;
        }

        [HttpGet]
        [Route("api/magPozycjaMagazynowa/magPozycjaMagazynowaCeny/{id?}")]
        public async Task<IHttpActionResult> GetMagPozycjaMagazynowaCeny(int id)
        {


            if (await db.MagPozycjaMagazynowa.FindAsync(id) == null) { return BadRequest("Nie znaleziono rekordu"); }


            var fakturaPozycje = from fp in db.FinFakturaPozycje
                                 join fz in db.FinFakturaZakupu on fp.FakturaZakupuRefId equals fz.FinFakturaZakupuId
                                 join k in db.Kontrahent on fz.KontrahentRefId equals k.KontrahentId
                                 select new
                                 {
                                     Cena = fp.Cena,
                                     Kontrahent = k.Skrot,
                                     Wartosc=fp.Wartosc,
                                     DataZakupu=fz.DataWystawienia
                                 };
            return Ok(fakturaPozycje);
      }

        [HttpGet]
        [Route("api/magPozycjaMagazynowa/magazynier/{id?}")]
        public async Task<IHttpActionResult> GetMagPozycjaMagazynowaMagazynier(int id)
        {
            MagPozycjaMagazynowa magPozycjaMagazynowa = await db.MagPozycjaMagazynowa.FindAsync(id);


            if (magPozycjaMagazynowa == null)
            {
                return BadRequest("Nie znaleziono rekordu");
            }

            var pozycjaMagazynowa = await (from mp in db.MagPozycjaMagazynowa.Include(pzp => pzp.MagPZPozycjaColl).Include(pz => pz.MagPZPozycjaColl)
                                           where mp.MagPozycjaMagazynowaId == id
                                           let razemPz = mp.MagPZPozycjaColl.Where(p => p.Valid == true).Sum(x => (double?)(x.Ilosc)) ?? 0
                                           let razemRozchodInne = mp.MagPozycjaMagazynowaRozchodInne.Sum(y => (double?)(y.Wartosc)) ?? 0
                                           select new MagPozycjaMagazynowaFullCennikDTO()
                                           {
                                               CzyPotwierdzone = mp.czyPotwierdzone,
                                               GrupaZakladowa = mp.GrupaZakladowa,
                                               JednostkaMiary = mp.JednostkaMiary,
                                               KodKreskowy = mp.KodKreskowy,
                                               MarzaZakladowa = mp.MarzaZakladowa,
                                               Nazwa = mp.Nazwa,
                                               PrzyjecieZewnetrzne = mp.MagPZPozycjaColl.Where(p => p.Valid == true).Select(pz => new MagPozycjaMagazynowaPrzyjecieZewnetrzneDTO
                                               {
                                                   PzId = pz.MagPzRefId == null ? pz.MagPzKorekta.MagPz.MagPzId : pz.MagPz.MagPzId,
                                                   DokumentZrodlowyNr = pz.MagPzRefId == null ? pz.MagPzKorekta.DokumentZrodlowyNr : pz.MagPz.DokumentZrodlowyNr,
                                                   CzyKorekta = pz.MagPzRefId == null ? pz.MagPzKorekta.MagPz.CzyKorekta : pz.MagPz.CzyKorekta,
                                                   CreatedBy = pz.MagPzRefId == null ? pz.MagPzKorekta.CreatedBy : pz.MagPz.CreatedBy,
                                                   DataWplywu = pz.MagPzRefId == null ? pz.MagPzKorekta.DataWplywu : pz.MagPz.DataWplywu,
                                                   Ilosc=pz.Ilosc,
                                                   Kontrahent = pz.MagPzRefId == null ? new KontrahentInfoDTO
                                                   {
                                                       Kontrahent=pz.MagPzKorekta.Kontrahent,
                                                       KontrahentId=pz.MagPzKorekta.KontrahentRefId,
                                                   } : new KontrahentInfoDTO
                                                   {
                                                       Kontrahent=pz.MagPz.Kontrahent,
                                                       KontrahentId=pz.MagPz.KontrahentRefId
                                                   },
                                                   Uwagi = pz.MagPz.Uwagi,
                                                   
                                               }).ToList(),
                                               RozchodInne = mp.MagPozycjaMagazynowaRozchodInne.Select(c => new MagPozycjaMagazynowaRozchodInneDTO() { CreatedBy = c.CreatedBy, DataRozchodu = c.DataRozchodu, Id = c.MagPozycjaMagazynowaRozchodInneId, RozchodMagRodzaj = c.RozchodMagRodzaj, Uwagi = c.Uwagi, Wartosc = c.Wartosc }).ToList(),
                                               Status = "baza",
                                               Stan = new MagPozycjaMagazynowaStanDTO()
                                               {
                                                   RazemPz = razemPz,
                                                   RazemRozchodInne = razemRozchodInne,
                                                   RazemWz = mp.MagWzPozycjaPozMag.Sum(wz => (double?)(wz.Ilosc)) ?? 0,
                                                   StanAktualny = razemPz - razemRozchodInne,
                                                   StanRzeczywisty = razemPz - razemRozchodInne
                                               },
                                               StanMinAlarm = mp.StanMinAlarm,
                                               TypTowaru = mp.TypTowaru,
                                               Uwagi = mp.Uwagi,
                                               VatSprzedazy = mp.VatSprzedazy,
                                               VatZakupu = mp.VatZakupu,
                                           }).FirstOrDefaultAsync();

            return Ok(pozycjaMagazynowa);
        }


        [HttpGet]
        [Route("api/magPozycjaMagazynowa/SmallList")]
        public IHttpActionResult GetSmallList() {

            var result = (from mpm in db.MagPozycjaMagazynowa
                          select new MagPozycjaMagazynowaDTO()
                          {
                              Jednostka = mpm.JednostkaMiary.Nazwa,
                              Nazwa = mpm.Nazwa,
                              PozycjaMagazynowaId = mpm.MagPozycjaMagazynowaId,
                              Uwagi = mpm.Uwagi,
                          });

            return Ok(result);
        }

        [HttpGet]
        [Route("api/magPozycjaMagazynowa/dostepne")]
        public IHttpActionResult GetDostepne()
        {
            var result = (from mpm in db.MagPozycjaMagazynowa.Include(pp => pp.MagPZPozycjaColl).Include(pmr=>pmr.MagPozycjaMagazynowaRozchodInne)
                          let razemPz = mpm.MagPZPozycjaColl.Where(p => p.Valid == true).Sum(x => (double?)(x.Ilosc)) ?? 0
                          let razemRozchodInne = mpm.MagPozycjaMagazynowaRozchodInne.Sum(y => (double?)(y.Wartosc)) ?? 0
                          select new MagPozycjaMagazynowaStanShortDTO()
                          {
                              GrupaZakladowa = mpm.GrupaZakladowa.Nazwa,
                              Jednostka = mpm.JednostkaMiary.Nazwa,
                              Nazwa = mpm.Nazwa,
                              PozycjaMagazynowaId = mpm.MagPozycjaMagazynowaId,
                              RazemRozchodInne = razemRozchodInne,
                              StanAktualny =mpm.StanAktualny.Value,
                              StanRzeczywisty=mpm.StanAktualny.Value,
                              Uwagi = mpm.Uwagi,
                          });

            return Ok(result.Where(w => w.StanAktualny>0).Select(s => s).ToList());
        }

    }
}