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
using Andpol.Dane.ModelsDTO;
using System.Web.Http.Cors;
using System.Data.Entity.Validation;
using System.Text;

namespace Andpol.Dane.Pomocne
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    
    public class KontrahentController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/Kontrahent
        public IQueryable GetKontrahent()
        {

            var kontrahenciDTO = (from kontr in db.Kontrahent
                                  select new
                                  {
                                      CzyDealerzy = kontr.CzyDealerzy,
                                      CzyDostawca = kontr.CzyDostawca,
                                      CzyOdbiorca = kontr.CzyOdbiorca,
                                      TypKontrahenta = kontr.TypKontrahentaRefId,
                                      Email = kontr.Email,
                                      Adres = (kontr.KodKraju == null ? null : kontr.KodKraju) + (kontr.KodPocztowy == null ? null : ", " + kontr.KodPocztowy) + (kontr.Miejscowosc == null ? null : " " + kontr.Miejscowosc) + (kontr.Ulica == null ? null : ", " + kontr.Ulica) + (kontr.UlicaNr == null ? null : " " + kontr.UlicaNr),
                                      Fax = kontr.Fax,
                                      KontrahentId = kontr.KontrahentId,
                                      KontoBankowe = kontr.KontoBankowe,
                                      Nazwa = (kontr.Nazwa == null ? kontr.Imie + " " + kontr.Nazwisko : kontr.Skrot == null ? kontr.Nazwa : kontr.Skrot + " - " + kontr.Nazwa),
                                      NIP = kontr.NIP == null ? "PESEL: "+kontr.Pesel : "NIP: "+kontr.NIP,
                                      Tel = kontr.Tel,
                                      Tel2 = kontr.Tel2,
                                      WWW = kontr.WWW,
                                      //Platnosci = (from p in db.KontrahentPlatnosc
                                      //             where p.KontrahentPlatnoscId == kontr.KontrahentPlatnosc.KontrahentPlatnoscId
                                      //             select new PlatnosciDTO()
                                      //             {
                                      //                 Id = p.KontrahentPlatnoscId,
                                      //                 IleDni = p.IleDni,
                                      //                 Stawka = p.TransportStawka,
                                      //                 TransportWCenie = p.TransportWcenie,
                                      //                 PlatnoscRodzaj = p.PlatnoscRodzaj,
                                      //                 Uwagi = p.Uwagi,
                                      //                 Status = "baza"
                                      //             }).FirstOrDefault(),
                                      //AdresyKontrahenta = (from ak in db.KontrahentDealerzy
                                      //                     where ak.KontrahentRefId == kontr.KontrahentId
                                      //                     select new KontrahentDealerDTO()
                                      //                     {
                                      //                         Id = ak.Id,
                                      //                         Nazwa = ak.Nazwa,
                                      //                         Kod = ak.Kod,
                                      //                         KodKraju = ak.KodKraju,
                                      //                         Miejscowosc = ak.Miejscowosc,
                                      //                         Nr = ak.Nr,
                                      //                         Ulica = ak.Ulica,
                                      //                         Status = "baza"
                                                               
                                      //                     }).ToList()
                                  }).OrderBy(o => o.Nazwa);

                        
            return kontrahenciDTO;
        }
        
        [Route("api/Kontrahent/SmallList")]
        [HttpGet]
        public IHttpActionResult GetSmallList()
        {
            var kontrahenci = from k in db.Kontrahent
                              where k.CzyDostawca == true
                              //select new KontrahentDostawcaDTO()
                              //{
                              //    Adres = (k.KodKraju == null ? null : k.KodKraju) + (k.KodPocztowy == null ? null : ", " + k.KodPocztowy) + (k.Miejscowosc == null ? null : " " + k.Miejscowosc) + (k.Ulica == null ? null : ", " + k.Ulica) + (k.UlicaNr == null ? null : " " + k.UlicaNr),
                              //    KontoBankowe = k.KontoBankowe,
                              //    KontoBankowe2 = k.KontoBankowe2,
                              //    KontrahentId = k.KontrahentId,
                              //    Nazwa = (k.Nazwa == null ? k.Imie + " " + k.Nazwisko : k.Nazwa),
                              //    Nip = k.NIP,
                              //    Skrot = k.Skrot
                              //};
                              select new KontrahentInfoDTO
                              {
                                  Kontrahent = k,
                                  KontrahentId = k.KontrahentId
                              };



            return Ok(kontrahenci);
        }


        [Route("api/Kontrahent/platnoscRodzaj")]
        [HttpGet]
        public IHttpActionResult GetPlatnoscRodzaj()
        {
            var result = db.Kontrahent.Where(w=>w.KontrahentPlatnoscRefId!=null).Select(s => new KontrahentPlatnoscDTO
            {
                IleDni = s.KontrahentPlatnosc.PlatnoscRodzaj.CzyDni ? s.KontrahentPlatnosc.IleDni.Value : 0,
                KontrahentRefId=s.KontrahentId,
                Uwagi = s.KontrahentPlatnosc.PlatnoscRodzaj.CzyUwagi ? s.KontrahentPlatnosc.Uwagi : null,
                PlatnoscRodzaj = s.KontrahentPlatnosc.PlatnoscRodzaj
            }).ToList();

            return Ok(result);
        }


        //[Route("api/Kontrahent/DealerzySmallList")]
        //[HttpGet]
        //public IHttpActionResult GetDealerzySmallList()
        //{

        //    var result = db.KontrahentDealerzy.Where(w=>w.CzyAdresDostawy).Select(s => new KontrahentInfoDTO
        //    {
        //        Kontrahent=new Kontrahent {
        //            Nazwa=s.Nazwa,
        //            KodKraju=s.KodKraju,
        //            KodPocztowy=s.Kod,
        //            KontrahentId=s.Id,
        //            Miejscowosc=s.Miejscowosc,
        //            Skrot=s.Nazwa,
        //            Ulica=s.Ulica,
        //            UlicaNr=s.Nr,
        //        },
        //        KontrahentId=s.Id
        //    }).ToList();



        //    return Ok(result);
        //}


        [Route("api/Kontrahent/KontrahentZdealerem")]
        [HttpGet]
        public IHttpActionResult GetKontrahentZdealerem()
        {
            var kontrahenci = from k in db.Kontrahent
                              where k.CzyDealerzy == true
                              select new KontrahentInfoDTO()
                              {
 
                                  Kontrahent=k,
                                  KontrahentId=k.KontrahentId
                                  
                              };

            return Ok(kontrahenci);
        }



        // GET: api/Kontrahent/5
        [ResponseType(typeof(KontrahentDTO))]
        public async Task<IHttpActionResult> GetKontrahent(int id)
        {


            Kontrahent kontrahent = await db.Kontrahent.FindAsync(id);
            if (kontrahent == null)
            {
                return NotFound();
            }



            var kontrahenciDTO = (from k in db.Kontrahent
                                  where k.KontrahentId == id
                                  select new KontrahentDTO
                                  {
                                      CzyDealerzy = k.CzyDealerzy,
                                      CzyDostawca = k.CzyDostawca,
                                      CzyOdbiorca = k.CzyOdbiorca,
                                      TypKontrahenta = k.TypKontrahentaRefId,
                                      Imie = k.Imie,
                                      Nazwisko = k.Nazwisko,
                                      KodKraju = k.KodKraju,
                                      KodPocztowy = k.KodPocztowy,
                                      Miejscowosc = k.Miejscowosc,
                                      Pesel = k.Pesel,
                                      Ulica = k.Ulica,
                                      UlicaNr = k.UlicaNr,

                                      Email = k.Email,
                                      Fax = k.Fax,
                                      KontrahentId = k.KontrahentId,
                                      KontoBankoweSwift=k.KontoBankoweSwift,
                                      KontoBankowe = k.KontoBankowe,
                                      KontoBankowe2Swift=k.KontoBankowe2Swift,
                                      KontoBankowe2 = k.KontoBankowe2,

                                      Nazwa = k.Nazwa,
                                      Nip = k.NIP,
                                      Skrot = k.Skrot,
                                      Tel1 = k.Tel,
                                      Tel2 = k.Tel2,
                                      WWW = k.WWW,
                                      Status = "baza",
                                      KontrahentPlatnosc = k.CzyDealerzy ? new KontrahentPlatnoscDTO
                                      {
                                          KontrahentPlatnoscId = k.KontrahentPlatnosc.KontrahentPlatnoscId,
                                          IleDni = (int?)k.KontrahentPlatnosc.IleDni ??0,
                                          TransportStawka = (double?)k.KontrahentPlatnosc.TransportStawka ??0,
                                          TransportWcenie = k.KontrahentPlatnosc.TransportWcenie,
                                          Uwagi = k.KontrahentPlatnosc.Uwagi,
                                          PlatnoscRodzaj = k.KontrahentPlatnosc.PlatnoscRodzaj
                                      } : null,
                                      Dealer = k.KontrahentDealerzy.Select(ak => new KontrahentDealerFullDTO()
                                      {
                                          DealerId = ak.Id,
                                          CzyAdresDostawy = ak.CzyAdresDostawy,
                                          CzyWjedziePrzyczepa = ak.CzyWjedziePrzyczepa,
                                          GodzinyOtwarcia = ak.GodzinyOtwarcia,
                                          Nazwa = ak.Nazwa,
                                          Kod = ak.Kod,
                                          KodKraju = ak.KodKraju,
                                          Miejscowosc = ak.Miejscowosc,
                                          Nr = ak.Nr,
                                          Ulica = ak.Ulica,
                                          Uwagi = ak.Uwagi,
                                          Status = "baza"
                                      }).ToList()
                                  }).FirstOrDefault();

            return Ok(kontrahenciDTO);

        }

        [HttpGet]
        [Route("api/kontrahent/kontrahentDealer")]
        public IHttpActionResult KontrahentDealer()
        {
            var result = db.KontrahentDealerzy.Select(s => new KontrahentDealerInfoDTO
            {
                KontrahentDealer = s,
                KontrahentDealerId=s.Id
            });

            return Ok(result);
        }


        [HttpGet]
        [Route("api/kontrahent/kontrahentDealerDostawa")]
        public IHttpActionResult KontrahentDealerDostawa()
        {
            var result = db.KontrahentDealerzy.Where(w => w.CzyAdresDostawy).Select(s => new KontrahentDealerInfoDTO
            {
                KontrahentDealer = s,
                KontrahentDealerId=s.Id
                
            });

            return Ok(result);
        }

        // PUT: api/Kontrahent/5
        [Authorize(Roles = "Kontrahent")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKontrahent(int id, KontrahentDTO kDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kontrahent kZm = db.Kontrahent.Find(id);


            if (id == 0)
            {
                Kontrahent kNew = new Kontrahent();

                kNew.CzyDealerzy = kDTO.CzyDealerzy;
                kNew.CzyDostawca = kDTO.CzyDostawca;
                kNew.CzyOdbiorca = kDTO.CzyOdbiorca;
                kNew.TypKontrahentaRefId = kDTO.TypKontrahenta;

                if (kDTO.TypKontrahenta == 1)
                {

                    kNew.Skrot = kDTO.Skrot;
                    kNew.Nazwa = kDTO.Nazwa;
                    kNew.NIP = kDTO.Nip;

                    if (kDTO.CzyDealerzy)
                    {
                        KontrahentPlatnosc kpNew = new KontrahentPlatnosc();

                        if (kDTO.KontrahentPlatnosc.PlatnoscRodzaj.CzyDni) { kpNew.IleDni = kDTO.KontrahentPlatnosc.IleDni; };
                        if (kDTO.KontrahentPlatnosc.PlatnoscRodzaj.CzyUwagi) { kpNew.Uwagi = kDTO.KontrahentPlatnosc.Uwagi; };
                        if (kDTO.KontrahentPlatnosc.TransportWcenie)
                        {
                            kpNew.TransportWcenie = true;
                        }
                        else {
                            kpNew.TransportStawka = kDTO.KontrahentPlatnosc.TransportStawka;
                            kpNew.TransportWcenie = false;
                        };
                        kpNew.PlatnoscRodzajRefId = kDTO.KontrahentPlatnosc.PlatnoscRodzaj.JednPlatnoscRodzajId;

                        db.KontrahentPlatnosc.Add(kpNew);
                        db.SaveChanges();
                        kDTO.KontrahentPlatnosc.KontrahentPlatnoscId = kpNew.KontrahentPlatnoscId;
                        kNew.KontrahentPlatnoscRefId = kpNew.KontrahentPlatnoscId;

                        foreach (var item in kDTO.Dealer)
                        {
                            KontrahentDealer kdNew = new KontrahentDealer()
                            {
                                CzyAdresDostawy = item.CzyAdresDostawy,
                                CzyWjedziePrzyczepa = item.CzyWjedziePrzyczepa,
                                Kod = item.Kod,
                                KodKraju = item.KodKraju,
                                KontrahentRefId = kNew.KontrahentId,
                                Miejscowosc = item.Miejscowosc,
                                Nazwa = item.Nazwa,
                                Nr = item.Nr,
                                Ulica = item.Ulica,
                                Uwagi = item.Uwagi
                            };

                            db.KontrahentDealerzy.Add(kdNew);
                        }

                    }

                }


                if (kDTO.TypKontrahenta == 2)
                {
                    kNew.Imie = kDTO.Imie;
                    kNew.Nazwisko = kDTO.Nazwisko;
                    kNew.Pesel = kDTO.Pesel;
                }

                kNew.KodKraju = kDTO.KodKraju;
                kNew.KodPocztowy = kDTO.KodPocztowy;
                kNew.Miejscowosc = kDTO.Miejscowosc;
                kNew.Ulica = kDTO.Ulica;
                kNew.UlicaNr = kDTO.UlicaNr;

                kNew.Fax = kDTO.Fax;
                kNew.KontoBankowe = kDTO.KontoBankowe;
                kNew.KontoBankoweSwift = kDTO.KontoBankoweSwift;
                kNew.KontoBankowe2 = kDTO.KontoBankowe2;
                kNew.KontoBankowe2Swift = kDTO.KontoBankowe2Swift;
                kNew.Tel = kDTO.Tel1;
                kNew.Tel2 = kDTO.Tel2;
                kNew.Email = kDTO.Email;
                kNew.WWW = kDTO.WWW;


                db.Kontrahent.Add(kNew);
                await db.SaveChangesAsync();
                kDTO.KontrahentId = kNew.KontrahentId;
                return Ok();
            }
            else {

                if (kZm == null)
                {
                    return BadRequest("Nie ma takiego rekordu");
                }


                if (kDTO.Status == "zmieniony")
                {

                    kZm.CzyDealerzy = kDTO.CzyDealerzy;
                    kZm.CzyDostawca = kDTO.CzyDostawca;
                    kZm.CzyOdbiorca = kDTO.CzyOdbiorca;
                    kZm.TypKontrahentaRefId = kDTO.TypKontrahenta;
                    kZm.Tel = kDTO.Tel1;
                    kZm.Tel2 = kDTO.Tel2;

                    if (kDTO.TypKontrahenta == 1)
                    {
                        kZm.Skrot = kDTO.Skrot;
                        kZm.Nazwa = kDTO.Nazwa;
                        kZm.NIP = kDTO.Nip;

                        kZm.Imie = null;
                        kZm.Nazwisko = null;
                        kZm.Pesel = null;



                        if (kDTO.CzyDealerzy)
                        {
                            KontrahentPlatnosc kp;

                            if (kZm.KontrahentPlatnoscRefId.HasValue)
                            {
                                kp = db.KontrahentPlatnosc.Find(kZm.KontrahentPlatnoscRefId);
                            }
                            else
                            {
                                kp = new KontrahentPlatnosc();
                            }
                            

                            kp.PlatnoscRodzajRefId = kDTO.KontrahentPlatnosc.PlatnoscRodzaj.JednPlatnoscRodzajId;

                            if (kDTO.KontrahentPlatnosc.PlatnoscRodzaj.CzyDni)
                            {
                                kp.IleDni = kDTO.KontrahentPlatnosc.IleDni;
                                kp.Uwagi = null;
                            }
                            else {
                                kp.IleDni = null;
                            }
                            if (kDTO.KontrahentPlatnosc.PlatnoscRodzaj.CzyUwagi)
                            {
                                kp.IleDni = null;
                                kp.Uwagi = kDTO.KontrahentPlatnosc.Uwagi;
                            }
                            else {
                                kp.Uwagi = null;
                            }
                            if (kDTO.KontrahentPlatnosc.TransportWcenie)
                            {
                                kp.TransportWcenie = true;
                                kp.TransportStawka = null;
                            }
                            else {
                                kp.TransportWcenie = false;
                                kp.TransportStawka = kDTO.KontrahentPlatnosc.TransportStawka;
                            }


                            //dodaje do bazy jesli platnosc jest nowa
                            if (!kZm.KontrahentPlatnoscRefId.HasValue) {
                                db.KontrahentPlatnosc.Add(kp);
                                kZm.KontrahentPlatnoscRefId =kp.KontrahentPlatnoscId;
                            }



                                var dealerzy = from aDTO in kDTO.Dealer select aDTO;

                            foreach (var deal in dealerzy)
                            {
                                if (deal.Status == "nowy")
                                {
                                    db.KontrahentDealerzy.Add(new KontrahentDealer
                                    {
                                        Kod = deal.Kod,
                                        CzyAdresDostawy=deal.CzyAdresDostawy,
                                        CzyWjedziePrzyczepa=deal.CzyWjedziePrzyczepa,
                                        KodKraju = deal.KodKraju,
                                        KontrahentRefId = kDTO.KontrahentId,
                                        Miejscowosc = deal.Miejscowosc,
                                        Nazwa = deal.Nazwa,
                                        Nr = deal.Nr,
                                        Ulica = deal.Ulica,
                                        Uwagi=deal.Uwagi,
                                        GodzinyOtwarcia=deal.GodzinyOtwarcia
                                    });
                                };

                                if (deal.Status == "zmieniony")
                                {
                                    KontrahentDealer AOrg = db.KontrahentDealerzy.Find(deal.DealerId);
                                    AOrg.GodzinyOtwarcia = deal.GodzinyOtwarcia;
                                    AOrg.CzyAdresDostawy = deal.CzyAdresDostawy;
                                    AOrg.CzyWjedziePrzyczepa = deal.CzyWjedziePrzyczepa;
                                    AOrg.Kod = deal.Kod;
                                    AOrg.KodKraju = deal.KodKraju;
                                    AOrg.KontrahentRefId = kDTO.KontrahentId;
                                    AOrg.Miejscowosc = deal.Miejscowosc;
                                    AOrg.Nazwa = deal.Nazwa;
                                    AOrg.Nr = deal.Nr;
                                    AOrg.Ulica = deal.Ulica;
                                    AOrg.Uwagi = deal.Uwagi;
                                    db.Entry(AOrg).State = EntityState.Modified;
                                };
                                if (deal.Status == "usuniety")
                                {
                                    var dealer = db.KontrahentDealerzy.Find(deal.DealerId);
                                    if (dealer != null)
                                    {
                                        db.KontrahentDealerzy.Remove(dealer);
                                    }
                                }


                            }
                        }
                        else {
                            kZm.KontrahentPlatnoscRefId = null;
                            if (kZm.KontrahentPlatnoscRefId.HasValue)
                            {
                                db.KontrahentPlatnosc.Remove(db.KontrahentPlatnosc.Find(kZm.KontrahentPlatnoscRefId));
                            }
                        }
                    };

                    if (kDTO.TypKontrahenta == 2)
                    {
                        if (kZm.KontrahentPlatnoscRefId.HasValue)
                        {
                            db.KontrahentPlatnosc.Remove(db.KontrahentPlatnosc.Find(kZm.KontrahentPlatnoscRefId));
                        }
                        kZm.CzyDealerzy = false;
                        kZm.Imie = kDTO.Imie;
                        kZm.Nazwisko = kDTO.Nazwisko;
                        kZm.Pesel = kDTO.Pesel;

                        kZm.Skrot = null;
                        kZm.Nazwa = null;
                        kZm.NIP = null;
                    }

                    kZm.KodKraju = kDTO.KodKraju;
                    kZm.KodPocztowy = kDTO.KodPocztowy;
                    kZm.Miejscowosc = kDTO.Miejscowosc;
                    kZm.Ulica = kDTO.Ulica;
                    kZm.UlicaNr = kDTO.UlicaNr;

                    kZm.Fax = kDTO.Fax;
                    kZm.KontoBankowe = kDTO.KontoBankowe;
                    kZm.KontoBankoweSwift = kDTO.KontoBankoweSwift;
                    kZm.KontoBankowe2 = kDTO.KontoBankowe2;
                    kZm.KontoBankowe2Swift = kDTO.KontoBankowe2Swift;
                    kZm.Tel = kDTO.Tel1;
                    kZm.Tel2 = kDTO.Tel2;
                    kZm.Email = kDTO.Email;
                    kZm.WWW = kDTO.WWW;
                }


                if (kDTO.Status == "usuniety")
                {
                    db.Kontrahent.Remove(db.Kontrahent.Find(id));
                };

            }



            try
            {
                await db.SaveChangesAsync();
            }

            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }


            catch (DbUpdateConcurrencyException)
            {
                if (!KontrahentExists(id))
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


        // DELETE: api/Kontrahent/5
        [ResponseType(typeof(Kontrahent))]
        public async Task<IHttpActionResult> DeleteKontrahent(int id)
        {
            Kontrahent kontrahent = await db.Kontrahent.FindAsync(id);
            if (kontrahent == null)
            {
                return NotFound();
            }

            db.Kontrahent.Remove(kontrahent);
            await db.SaveChangesAsync();

            return Ok(kontrahent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KontrahentExists(int id)
        {
            return db.Kontrahent.Count(e => e.KontrahentId == id) > 0;
        }

    }
}