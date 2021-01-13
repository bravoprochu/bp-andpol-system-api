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
    [Authorize(Roles ="MagazynPz, FinanseFaktury")]
    [EnableCors("*", "*", "*")]
    public class MagPzController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/MagPZ
        public IHttpActionResult GetMagPZ()
        {
            var kwartal = Pomocne.DateHelpful.kwartal();

            var resultBezKorekt = db.MagPz.Where(w=>w.DataWystawienia>=kwartal && w.CzyKorekta==false)
                         .Select(pz=> new MagPZDTO()
                         {
                             CreatedBy = pz.CreatedBy,
                             DataWystawienia = pz.DataWystawienia,
                             DataWplywu = pz.DataWplywu,
                             DokumentZrodlowyNr = pz.DokumentZrodlowyNr,
                             DokumentTyp = new DokumentTypDTO {
                                 DokumentTypId=pz.JednDokumentTyp.JednDokumentTypId,
                                 Nazwa=pz.JednDokumentTyp.Nazwa,
                                 Uwagi=pz.JednDokumentTyp.Uwagi
                             },
                             PzId = pz.MagPzId,
                             Kontrahent = new KontrahentInfoDTO {
                                 Kontrahent=pz.Kontrahent,
                                 KontrahentId=pz.KontrahentRefId
                             },
                             Uwagi = pz.Uwagi
                         }).ToList();

            var resultkorekty = db.MagPzKorekta.Where(w => w.MagPz.DataWystawienia >= kwartal).GroupBy(g => g.MagPzRefId).Select(sg => new MagPZDTO
            {
                CreatedBy = sg.OrderByDescending(o => o.MagPzKorektaId).Select(s => s.CreatedBy).FirstOrDefault(),
                CzyKorekta = true,
                DataWplywu = sg.OrderByDescending(o => o.MagPzKorektaId).Select(s => s.DataWplywu).FirstOrDefault(),
                DataWystawienia = sg.OrderByDescending(o => o.MagPzKorektaId).Select(s => s.DataWystawienia).FirstOrDefault(),
                DokumentTyp = sg.OrderByDescending(o => o.MagPzKorektaId).Select(s => new DokumentTypDTO
                {
                    DokumentTypId = s.JednDokumentTyp.JednDokumentTypId,
                    Nazwa = s.JednDokumentTyp.Nazwa,
                    Uwagi = s.JednDokumentTyp.Uwagi
                }).FirstOrDefault(),
                DokumentZrodlowyNr=sg.OrderByDescending(o=>o.MagPzKorektaId).Select(s=>s.DokumentZrodlowyNr).FirstOrDefault(),
                PzId = sg.OrderByDescending(o => o.MagPzKorektaId).Select(s => s.MagPzRefId).FirstOrDefault(),
                Kontrahent = sg.OrderByDescending(o => o.MagPzKorektaId).Select(s => new KontrahentInfoDTO
                {
                    Kontrahent = s.Kontrahent,
                    KontrahentId = s.KontrahentRefId
                }).FirstOrDefault(),
                Uwagi = sg.OrderByDescending(o => o.MagPzKorektaId).Select(s => s.Uwagi).FirstOrDefault()
            }).ToList();

            var result = new List<MagPZDTO>();
            result.AddRange(resultBezKorekt);
            result.AddRange(resultkorekty);

            result.OrderByDescending(o => o.PzId);


            return Ok(new { Info = $"Filtr dla 'DataWystawienia' od dnia: {kwartal.ToShortDateString()}", result });
        }

        // GET: api/MagPZ/5
        public async Task<IHttpActionResult> GetMagPZ(int id)
        {

            if (await db.MagPz.FindAsync(id) == null) { return BadRequest("Nie ma takiego rekordu"); }

            var result = db.MagPz.Where(w=>w.MagPzId==id).Select(pz=> new MagPZDTO()
                          {
                              CreatedBy = pz.CreatedBy,
                              CzyKorekta=pz.CzyKorekta,
                              CzyZaksiegowana=pz.CzyZaksiegowana,
                              DataWystawienia = pz.DataWystawienia,
                              DataWplywu = pz.DataWplywu,
                              DokumentZrodlowyNr = pz.DokumentZrodlowyNr,
                              DokumentTyp = new DokumentTypDTO() {
                                  DokumentTypId = pz.JednDokumentTyp.JednDokumentTypId,
                                  Nazwa = pz.JednDokumentTyp.Nazwa,
                                  Uwagi = pz.JednDokumentTyp.Uwagi
                              },
                              
                              FakturaZakupuRefId=pz.FakturaZakupuRefId.HasValue? pz.FakturaZakupuRefId: null,
                              FakturaZakupu=pz.FakturaZakupuRefId.HasValue? new {
                                  FakturaNr=pz.FakturaZakupu.FakturaNr,
                              } :null,
                              PzId = pz.MagPzId,
                              Kontrahent=new KontrahentInfoDTO {
                                  Kontrahent=pz.Kontrahent,
                                  KontrahentId=pz.KontrahentRefId
                              },
                              PzKorekta= pz.MagPzKorekta.Select(pk=>new PzKorektaDTO() {
                                  CreatedBy=pk.CreatedBy,
                                  DataWplywu=pk.DataWplywu,
                                  DataWystawienia=pk.DataWystawienia,
                                  DokumentTyp= new DokumentTypDTO() {
                                      DokumentTypId=pk.JednDokumentTyp.JednDokumentTypId,
                                      Nazwa=pk.JednDokumentTyp.Nazwa,
                                        Uwagi=pk.JednDokumentTyp.Uwagi
                                    },
                                  DokumentZrodlowyNr=pk.DokumentZrodlowyNr,
                                  Kontrahent = new KontrahentInfoDTO()
                                                {
                                                    Kontrahent=pk.Kontrahent,
                                                    KontrahentId = pk.Kontrahent.KontrahentId,
                                                },
                                  PzKorektaId=pk.MagPzKorektaId,
                                  PzPozycja = pk.MagPzPozycja.Select(pzpKor=> new PZPozycjaDTO()
                                               {
                                                   MagPzPozycjaId = pzpKor.MagPzPozycjaId,
                                                   Ilosc = pzpKor.Ilosc,
                                                   PozycjaMagazynowa =  new MagPozycjaMagazynowaDTO()
                                                                        {
                                                                            Nazwa = pzpKor.PozycjaMagazynowa.Nazwa,
                                                                            Jednostka = pzpKor.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                                                                            PozycjaMagazynowaId = pzpKor.PozycjaMagazynowa.MagPozycjaMagazynowaId,
                                                                            Uwagi = pzpKor.PozycjaMagazynowa.Uwagi
                                                                        },
                                               }).OrderBy(x => x.PozycjaMagazynowa).ToList(),

                                  Uwagi =pk.Uwagi

                              }).OrderByDescending(o => o.PzKorektaId).ToList(),


                           PzPozycja=pz.MagPzPozycja.Select(pzp=> new PZPozycjaDTO() {
                                MagPzPozycjaId = pzp.MagPzPozycjaId,
                                Ilosc =pzp.Ilosc,
                                PozycjaMagazynowa= new MagPozycjaMagazynowaDTO() {
                                  Nazwa=pzp.PozycjaMagazynowa.Nazwa,
                                  Jednostka= pzp.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                                  PozycjaMagazynowaId= pzp.PozycjaMagazynowa.MagPozycjaMagazynowaId,
                                  Uwagi= pzp.PozycjaMagazynowa.Uwagi
                                },
                           }).OrderBy(x=>x.PozycjaMagazynowa).ToList(),
                           Uwagi=pz.Uwagi
        }).FirstOrDefault();


            return Ok(result);
        }

        // PUT: api/MagPZ/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMagPZ(int id, MagPZDTO pzDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pzDTO.PzId) {
                return BadRequest("PZ ID się nie zgadza");
            }

            MagPz pzNew = id == 0 ? new MagPz() : db.MagPz.Find(id);

            if (id == 0)
            {
                if (pzDTO.PzPozycja.Count == 0 || pzDTO.Kontrahent==null) {
                    return BadRequest("Nie dodano żanych pozycji magazynowych lub nie wybrano kontrahenta !");
                }

                pzNew.DataWplywu = new DateTime(pzDTO.DataWplywu.Year, pzDTO.DataWplywu.Month, pzDTO.DataWplywu.Day);
                pzNew.DataWystawienia = DateTime.Now;
                pzNew.DokumentZrodlowyNr = pzDTO.DokumentZrodlowyNr;
                pzNew.DokumentZrodlowyRefId = pzDTO.DokumentTyp.DokumentTypId;
                pzNew.KontrahentRefId = pzDTO.Kontrahent.KontrahentId;
                pzNew.Uwagi = pzDTO.Uwagi;
                pzNew.CreatedBy = pzDTO.CreatedBy;

                db.MagPz.Add(pzNew);

                foreach (var poz in pzDTO.PzPozycja)
                {
                    db.MagPzPozycja.Add(new MagPzPozycja
                    {
                        Ilosc = poz.Ilosc,
                        PozycjaMagazynowaRefId = poz.PozycjaMagazynowa.PozycjaMagazynowaId,
                        MagPz = pzNew,
                        Valid=true                
                    });
                    MagPozycjaMagazynowa pMag = db.MagPozycjaMagazynowa.Find(poz.PozycjaMagazynowa.PozycjaMagazynowaId);
                    pMag.StanRzeczywisty = pMag.StanRzeczywisty.HasValue ? pMag.StanRzeczywisty.Value + poz.Ilosc : poz.Ilosc;
                    pMag.StanAktualny = pMag.StanAktualny.HasValue? pMag.StanAktualny+poz.Ilosc: poz.Ilosc;
                    db.Entry(pMag).State = EntityState.Modified;
                }
            } else {
                if (pzNew == null) { return BadRequest($"Nie znaleziono rekordu w bazie o ID {id}"); }
                if (pzDTO.Status == "zmieniony" && pzDTO.CzyKorekta && pzDTO.Korekta != null)
                {
                    var kor = pzDTO.Korekta;
                    MagPzKorekta korNew = new MagPzKorekta();
                    korNew.CreatedBy = kor.CreatedBy;
                    korNew.DataWplywu = kor.DataWplywu;
                    korNew.DataWystawienia = DateTime.Now;
                    korNew.DokumentZrodlowyNr = kor.DokumentZrodlowyNr;
                    korNew.DokumentZrodlowyRefId = kor.DokumentTyp.DokumentTypId;
                    korNew.KontrahentRefId = kor.Kontrahent.KontrahentId;
                    korNew.MagPz = pzNew;
                    korNew.Uwagi = kor.Uwagi;
                    
                    db.MagPzKorekta.Add(korNew);


                    var pzPozOld = db.MagPzPozycja.WhereIn(wi => wi.MagPzPozycjaId, pzDTO.Korekta.PzPozycja.Select(s => s.MagPzPozycjaId).ToList().Select(s => s)).ToList();

                    foreach (var pOld in pzPozOld)
                    {
                        pOld.Valid = false;
                        MagPozycjaMagazynowa pMag = db.MagPozycjaMagazynowa.Find(pOld.PozycjaMagazynowaRefId);
                        pMag.StanRzeczywisty -= pOld.Ilosc;
                        pMag.StanAktualny -= pOld.Ilosc;
                        db.Entry(pMag).State = EntityState.Modified;
                        db.Entry(pOld).State = EntityState.Modified;
                    }

                    foreach (var item in kor.PzPozycja)
                    {
                        db.MagPzPozycja.Add(new MagPzPozycja
                        {
                            Ilosc = item.Ilosc,
                            PozycjaMagazynowaRefId = item.PozycjaMagazynowa.PozycjaMagazynowaId,
                            MagPzKorekta = korNew,
                            Valid=true
                        });
                        MagPozycjaMagazynowa pMag= db.MagPozycjaMagazynowa.Find(item.PozycjaMagazynowa.PozycjaMagazynowaId);
                        pMag.StanRzeczywisty += item.Ilosc;
                        pMag.StanAktualny += item.Ilosc;
                        db.Entry(pMag).State = EntityState.Modified;
                    }

                    MagPz pzMod = db.MagPz.Find(id);
                    pzMod.CzyKorekta = true;
                    db.Entry(pzMod).State = EntityState.Modified;
                }
                else {
                    return BadRequest("Nie można edytować PZ'ki, utwórz jej korektę");
                }

            }

          

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagPZExists(id))
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

        // POST: api/MagPZ
        [ResponseType(typeof(Entities.MagPz))]
        public IHttpActionResult PostMagPZ(Entities.MagPz magPZ)
        {
            return BadRequest("Put only...");
        }

        // DELETE: api/MagPZ/5
        [ResponseType(typeof(Entities.MagPz))]
        public IHttpActionResult DeleteMagPZ(int id)
        {

            var pzka = (from pz in db.MagPz
                        where pz.MagPzId == id
                        select new
                        {
                            DataWystawienia = pz.DataWystawienia,
                            CzyKorekta = pz.CzyKorekta,
                            CzyZaksiegowana = pz.CzyZaksiegowana,
                            DokumentZrodlowy = pz.DokumentZrodlowyNr,
                            FakturaRefId = pz.FakturaZakupuRefId,
                            KontrahentId = pz.KontrahentRefId,
                            KorektaCount = pz.MagPzKorekta.Count,
                            Korekty=pz.MagPzKorekta,
                            KorektyIds = pz.MagPzKorekta.Select(s => s.MagPzKorektaId).ToList(),
                        }).FirstOrDefault();


            if (pzka == null) {
                return BadRequest($"Nie znaleziono rekordu o ID {id}");
            }
            if (pzka.CzyZaksiegowana) {
                return BadRequest($"PZ został już zaksięgowany, FakuraZakupu id: {pzka.FakturaRefId}. Należy usunąć najpierw fakturę");
            }

            var pozycjePZki = (from pzPoz in db.MagPzPozycja where pzPoz.MagPzRefId == id || pzka.KorektyIds.Contains(pzPoz.MagPzKorekta.MagPzKorektaId) select pzPoz).ToList();


            var pozycjePzkiStr = pozycjePZki.Count > 0 ? " PozycjePz: " : "";

            foreach (var item in pozycjePZki)
            {
                if (item.Valid==true) {
                    var pozMag = db.MagPozycjaMagazynowa.Find(item.PozycjaMagazynowaRefId);
                    pozMag.StanAktualny -= item.Ilosc;
                    pozMag.StanRzeczywisty -= item.Ilosc;
                    pozycjePzkiStr +=  item.PozycjaMagazynowaRefId.ToString() + "("+item.Ilosc.ToString("0.00")+"),";
                }
                db.MagPzPozycja.Remove(item);
            }

            if (pzka.KorektaCount > 0)
            {
                var korekty = (from pzk in pzka.Korekty select pzk).ToList();

                foreach (var item in korekty)
                {
                    db.MagPzKorekta.Remove(item);
                }
            }



            db.LogsDelete.Add(new LogsDelete()
            {
                DataUsuniecia = DateTime.Now,
                Tabela = "MagPz",
                UserName = User.Identity.Name,
                Uwagi = "DataUtworzenia " + pzka.DataWystawienia.ToShortDateString() + " CzyKorekta: " + pzka.CzyKorekta + " DokumentZrodlowy: " + pzka.DokumentZrodlowy + " KontrahentRefId: " + pzka.KontrahentId + pozycjePzkiStr
            });







            db.MagPz.Remove(db.MagPz.Find(id));
            db.SaveChanges();
            return Ok($"PZ Id: {id} została usunięta.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MagPZExists(int id)
        {
            return db.MagPz.Count(e => e.MagPzId == id) > 0;
        }

        [HttpPost]
        [Route("api/MagPz/dateRange")]
        public IHttpActionResult MagPzDateRange(DateRangeDTO dateRange)
        {

            var result= from pz in db.MagPz where pz.DataWystawienia>=dateRange.DateStart && pz.DataWystawienia<=dateRange.DateEnd 
                        select new MagPZDTO()
                        {
                            CreatedBy = pz.CreatedBy,
                            DataWystawienia = pz.DataWystawienia,
                            DataWplywu = pz.DataWplywu,
                            DokumentZrodlowyNr = pz.DokumentZrodlowyNr,
                            DokumentTyp = new DokumentTypDTO()
                                        {
                                            DokumentTypId = pz.JednDokumentTyp.JednDokumentTypId,
                                            Nazwa = pz.JednDokumentTyp.Nazwa,
                                            Uwagi = pz.JednDokumentTyp.Uwagi
                                        },
                            PzId = pz.MagPzId,
                            Kontrahent=new KontrahentInfoDTO {
                                Kontrahent=pz.Kontrahent,
                                KontrahentId=pz.KontrahentRefId
                            },
                            //Kontrahent = new KontrahentDostawcaDTO()
                            //            {
                            //    Adres = (pz.Kontrahent.KodKraju == null ? null : pz.Kontrahent.KodKraju) + (pz.Kontrahent.KodPocztowy == null ? null : ", " + pz.Kontrahent.KodPocztowy) + (pz.Kontrahent.Miejscowosc == null ? null : " " + pz.Kontrahent.Miejscowosc) + (pz.Kontrahent.Ulica == null ? null : ", " + pz.Kontrahent.Ulica) + (pz.Kontrahent.UlicaNr == null ? null : " " + pz.Kontrahent.UlicaNr),
                            //    Nazwa = (pz.Kontrahent.Nazwisko == null ? null : pz.Kontrahent.Nazwisko) + (pz.Kontrahent.Imie == null ? null : " " + pz.Kontrahent.Imie) + (pz.Kontrahent.Nazwa == null ? null : pz.Kontrahent.Nazwa),
                            //    KontrahentId = pz.Kontrahent.KontrahentId,
                            //    Nip = pz.Kontrahent.NIP,
                            //    Skrot = pz.Kontrahent.Skrot
                            //},
                            Uwagi = pz.Uwagi
                        };

            return Ok(new { info = $"Filtr dla pola: 'dataWystawienia' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result });
        }

        [HttpGet]
        [Route("api/MagPz/NierozliczonePz")]
        public IHttpActionResult GetNierozliczonePzMag()
        {


            var pozycje = (from pzPoz in db.MagPzPozycja
                           where pzPoz.Valid == true &&
                           pzPoz.MagPz.CzyZaksiegowana == false || pzPoz.MagPzKorekta.MagPz.CzyZaksiegowana==false
                               select new 
                               {
                                   CreatedBy = pzPoz.MagPzRefId.HasValue ? pzPoz.MagPz.CreatedBy : pzPoz.MagPzKorekta.CreatedBy,
                                   CzyKorekta = pzPoz.MagPzRefId.HasValue ? pzPoz.MagPz.CzyKorekta : pzPoz.MagPzKorekta.MagPz.CzyKorekta,
                                   DokumentZrodlowyNr = pzPoz.MagPzRefId.HasValue ? pzPoz.MagPz.DokumentZrodlowyNr : pzPoz.MagPzKorekta.MagPz.DokumentZrodlowyNr,
                                   DataWystawienia = pzPoz.MagPzRefId.HasValue ? pzPoz.MagPz.DataWystawienia : pzPoz.MagPzKorekta.DataWystawienia,
                                   DataWplywu= pzPoz.MagPzRefId.HasValue ? pzPoz.MagPz.DataWplywu : pzPoz.MagPzKorekta.DataWplywu,
                                   Kontrahent = pzPoz.MagPzRefId.HasValue ? new KontrahentInfoDTO()
                                   {
                                       Kontrahent=pzPoz.MagPz.Kontrahent,
                                       KontrahentId=pzPoz.MagPz.KontrahentRefId
                                   } : new KontrahentInfoDTO()
                                   {
                                       Kontrahent=pzPoz.MagPzKorekta.Kontrahent,
                                       KontrahentId=pzPoz.MagPzKorekta.KontrahentRefId
                                   },
                                   PzId = pzPoz.MagPzRefId.HasValue ? pzPoz.MagPz.MagPzId : pzPoz.MagPzKorekta.MagPz.MagPzId,
                                   PzPozycja =  new PZPozycjaDTO() {
                                       Ilosc=pzPoz.Ilosc,
                                       MagPzPozycjaId=pzPoz.MagPzPozycjaId,
                                       PozycjaMagazynowa=new MagPozycjaMagazynowaDTO() {
                                           Jednostka=pzPoz.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                                           Nazwa= pzPoz.PozycjaMagazynowa.Nazwa,
                                           PozycjaMagazynowaId= pzPoz.PozycjaMagazynowa.MagPozycjaMagazynowaId,
                                           VatZakupu=new PodatekStawkaDTO() {
                                               JednPodatekStawkaId= pzPoz.PozycjaMagazynowa.VatZakupu.JednPodatekStawkaId,
                                               Nazwa= pzPoz.PozycjaMagazynowa.VatZakupu.Nazwa,
                                               Wartosc= pzPoz.PozycjaMagazynowa.VatZakupu.Wartosc
                                           }
                                       }
                                   },
                                   Uwagi = pzPoz.MagPzRefId.HasValue ? pzPoz.MagPz.Uwagi : pzPoz.MagPzKorekta.Uwagi,
                               }).ToList();


            var pozycjeByPozMag = db.FinFakturaPozycje.WhereIn(wi => wi.PozycjaMagazynowaRefId, pozycje.Select(sw => sw.PzPozycja.PozycjaMagazynowa.PozycjaMagazynowaId)).Select(s => new
            {
                Cena = s.Cena,
                PozycjaMagazynowaRefId = s.PozycjaMagazynowaRefId,
                FakturaZakupu = new
                {
                    DataWystawienia = s.FakturaZakupu.DataWystawienia,
                    Kontrahent = s.FakturaZakupu.Kontrahent.Skrot
                },
            }).ToList();



            var fakturaPozycjeStats = pozycjeByPozMag.GroupBy(g => g.PozycjaMagazynowaRefId).Select(s => new StatystykiBoxDTO()
            {
                UniqueKeyId = s.Key,
                Statystyki = new StatystykiDTO()
                {
                    Avg = (double?)s.Average(a => a.Cena) ?? 0,
                    Count = s.Count(),
                    Max = (double?)s.Max(a => a.Cena) ?? 0,
                    Min = (double?)s.Min(a => a.Cena) ?? 0,
                }
            }).ToList();


            foreach (var item in fakturaPozycjeStats)
            {
                var ost = pozycjeByPozMag.Find(f => f.PozycjaMagazynowaRefId == item.UniqueKeyId);

                item.Statystyki.Ostatni = new MagPozOstatniDTO()
                {
                    Cena = ost.Cena,
                    DataOstatniegoZakupu = ost.FakturaZakupu.DataWystawienia,
                    Kontrahent=ost.FakturaZakupu.Kontrahent
                    
                };
            }

            foreach (var item in pozycje)
            {
                item.PzPozycja.PozycjaMagazynowa.Statystyki = fakturaPozycjeStats.Where(w => w.UniqueKeyId == item.PzPozycja.PozycjaMagazynowa.PozycjaMagazynowaId).Select(s => s.Statystyki).FirstOrDefault();
            }




            List<MagPZDTO> ListaPz = new List<MagPZDTO>();



            var pozycjeByPz = pozycje.GroupBy(g => g.PzId).Select(pz => new MagPZDTO()
            {
                PzId = pz.Select(s => s.PzId).FirstOrDefault(),
                CreatedBy = pz.Select(s=>s.CreatedBy).FirstOrDefault(),
                CzyKorekta= pz.Select(s => s.CzyKorekta).FirstOrDefault(),
                DataWystawienia = pz.Select(s => s.DataWystawienia).FirstOrDefault(),
                DataWplywu= pz.Select(s => s.DataWplywu).FirstOrDefault(),
                DokumentZrodlowyNr = pz.Select(s => s.DokumentZrodlowyNr).FirstOrDefault(),
                Kontrahent = pz.Select(s =>s.Kontrahent).FirstOrDefault(),
                Uwagi = pz.Select(s => s.Uwagi).FirstOrDefault(),
                PzPozycja= pz.Select(s => s.PzPozycja).ToList(),
            }).ToList();










            return Ok(pozycjeByPz);


  
            //var statsyCenDlaPozMag = (from pm in db.MagPozycjaMagazynowa.WhereIn(wi => wi.MagPozycjaMagazynowaId, pozMagDistinct.Select(si => si.Id))
            //                          let ostatni = pm.FakturaPozycje.Select(so => so).OrderByDescending(oo => oo.FakturaZakupu.DataWystawienia).FirstOrDefault()
            //                          select new
            //                          {

            //                              PozycjaMagazynowaId = pm.MagPozycjaMagazynowaId,
            //                              Statystyki = new StatystykiDTO()
            //                              {
            //                                  Avg = (double?)pm.FakturaPozycje.Average(s => s.Cena) ?? 0,
            //                                  Count = pm.FakturaPozycje.Count(),
            //                                  Max = (double?)pm.FakturaPozycje.Max(s => s.Cena) ?? 0,
            //                                  Min = (double?)pm.FakturaPozycje.Min(s => s.Cena) ?? 0,
            //                                  Ostatni = new MagPozOstatniDTO()
            //                                  {
            //                                      Cena = (double?)ostatni.Cena ?? 0,
            //                                      DataOstatniegoZakupu = ostatni != null ? ostatni.FakturaZakupu.DataWystawienia : DateTime.Now,
            //                                      Kontrahent = ostatni != null ? ostatni.FakturaZakupu.Kontrahent.Skrot.Length > 1 ? ostatni.FakturaZakupu.Kontrahent.Skrot : ostatni.FakturaZakupu.Kontrahent.Nazwa : ""

            //                                  }

            //                              }

            //                          }).ToList();

        }

    }
}