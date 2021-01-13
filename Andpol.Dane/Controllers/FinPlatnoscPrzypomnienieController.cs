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
    [Authorize(Roles = "FinansePrzypomnieniePlatnosci")]
    [EnableCors("*", "*", "*")]

    public class FinPlatnoscPrzypomnienieController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/FinPlatnoscPrzypomnienie
        [HttpGet]
        [Route("api/finPlatnoscPrzypomnienie")]
        public IHttpActionResult GetFinPlatnoscPrzypomnienie()
        {

            var kontrahenci = db.Kontrahent.Where(w => w.CzyDostawca == true)
                .Select(s => new KontrahentInfoDTO()
                {
                    Kontrahent = s,
                    KontrahentId=s.KontrahentId
                }).ToList();



            var result = this.mPlatnoscPrzypomnienieLista();

            var waluta = (from w in db.FinWaluta
                          select new WalutaDTO()
                          {
                              Nazwa = w.Nazwa,
                              Skrot = w.Skrot,
                              WalutaId = w.FinWalutaId
                          }).ToList();

            //            object result = new { platnosci, kontrahenci };


            return Ok(new { Info = "Dane dla płatnośćPrzypomnienie", result, kontrahenci, waluta });

        }

        // GET: api/FinPlatnoscPrzypomnienie/5
        [ResponseType(typeof(FinPlatnoscPrzypomnienie))]
        public IHttpActionResult GetFinPlatnoscPrzypomnienie(int id)
        {

            var result = mPlatnoscPrzypomnienieById(id);

            return Ok(result);
        }

        // PUT: api/FinPlatnoscPrzypomnienie/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFinPlatnoscPrzypomnienie(int id, PlatnoscPrzypomnienieCardDTO ppDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ppDTO.PlatnoscPrzypomnienieId)
            {
                return BadRequest();
            }

            FinPlatnoscPrzypomnienie pp = new FinPlatnoscPrzypomnienie();
            pp = db.FinPlatnoscPrzypomnienie.Find(ppDTO.PlatnoscPrzypomnienieId);
            if (pp.IsDone == false && ppDTO.IsDone == true)
            {
                pp.DoneDateTime = DateTime.Now;
                pp.IsDone = true;
                pp.DoneBy = ppDTO.DoneBy;
                var dz = ppDTO.DataZaplaty.Value;
                pp.DataZaplaty = new DateTime(dz.Year, dz.Month, dz.Day, 0, 0, 0);

                pp.FakturaNr = ppDTO.FakturaNr;
                pp.Kwota = ppDTO.Kwota;
                pp.KontrahentRefId = ppDTO.Kontrahent.KontrahentId;
                pp.TerminPlatnosci = ppDTO.TerminPlatnosci;
                pp.Uwagi = ppDTO.Uwagi;
                pp.WalutaRefId = ppDTO.Waluta.WalutaId;
            }
            else
            {
                pp.FakturaNr = ppDTO.FakturaNr;
                pp.Kwota = ppDTO.Kwota;
                pp.KontrahentRefId = ppDTO.Kontrahent.KontrahentId;
                pp.TerminPlatnosci = ppDTO.TerminPlatnosci;
                pp.Uwagi = ppDTO.Uwagi;
                pp.WalutaRefId = ppDTO.Waluta.WalutaId;
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatnoscPrzypomnienieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var updated = mPlatnoscPrzypomnienieById(pp.FinPlatnoscPrzypomnienieId);

            var result = mPlatnoscPrzypomnienieLista();

            return Ok(new { info = $"Płatność o ID: {id} została zaktualizowana w bazie", result, updated });
        }

        // POST: api/FinPlatnoscPrzypomnienie
        [HttpPost]
        [Route("api/FinPlatnoscPrzypomnienie")]
        public async Task<IHttpActionResult> PostFinPlatnoscPrzypomnienie(PlatnoscPrzypomnienieCardDTO ppDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DateTime termin = new DateTime();
            termin = ppDTO.TerminPlatnosci;

            ppDTO.TerminPlatnosci = new DateTime(termin.Year, termin.Month, termin.Day, 09, 00, 00);

            FinPlatnoscPrzypomnienie pp = new FinPlatnoscPrzypomnienie();

            pp.FakturaNr = ppDTO.FakturaNr;
            pp.KontrahentRefId = ppDTO.Kontrahent.KontrahentId;
            pp.Kwota = ppDTO.Kwota;
            pp.Uwagi = ppDTO.Uwagi;
            pp.TerminPlatnosci = ppDTO.TerminPlatnosci;
            pp.DataZaplaty = null;
            pp.IsDone = false;
            pp.WalutaRefId = ppDTO.Waluta.WalutaId;


            db.FinPlatnoscPrzypomnienie.Add(pp);
            await db.SaveChangesAsync();

            ppDTO.PlatnoscPrzypomnienieId = pp.FinPlatnoscPrzypomnienieId;

            var result = mPlatnoscPrzypomnienieLista();

            return Ok(new { info = $"Płatność została zapisana w bazie, Id: {pp.FinPlatnoscPrzypomnienieId}", result });
        }

        // DELETE: api/FinPlatnoscPrzypomnienie/5
        [ResponseType(typeof(FinPlatnoscPrzypomnienie))]
        public async Task<IHttpActionResult> DeleteFinPlatnoscPrzypomnienie(int id)
        {
            var platnoscPrzypomnienie = (from pp in db.FinPlatnoscPrzypomnienie
                                         where pp.FinPlatnoscPrzypomnienieId == id
                                         select new
                                         {
                                             CzyEuro = pp.CzyEuro,
                                             KontrahentRefId = pp.KontrahentRefId,
                                             TerminPlatnosci = pp.TerminPlatnosci,
                                             Kwota = pp.Kwota,
                                             FakturaZakupuId = pp.FakturaZakupu != null ? pp.FakturaZakupu.FinFakturaZakupuId : 0
                                         }).FirstOrDefault();
            if (platnoscPrzypomnienie == null)
            {
                return NotFound();
            }

            db.LogsDelete.Add(new LogsDelete
            {
                DataUsuniecia = DateTime.Now,
                Tabela = "FinPlatnoscPrzypomnienie",
                UserName = User.Identity.Name,
                Uwagi = "TerminPlatnosci: " + platnoscPrzypomnienie.TerminPlatnosci.ToShortDateString() + " KontrahentRefId: " + platnoscPrzypomnienie.KontrahentRefId + " kwota: " + platnoscPrzypomnienie.Kwota.ToString("0.00") + "CzyEuro: " + platnoscPrzypomnienie.CzyEuro
            });


            if (platnoscPrzypomnienie.FakturaZakupuId > 0)
            {
                var fak = db.FinFakturaZakupu.Find(platnoscPrzypomnienie.FakturaZakupuId);
                fak.CzyPrzypomnieniePlatnosc = false;
            }

            db.FinPlatnoscPrzypomnienie.Remove(db.FinPlatnoscPrzypomnienie.Find(id));
            await db.SaveChangesAsync();

            var result = mPlatnoscPrzypomnienieLista();


            return Ok(new { info = $"FinPlatnoscPrzypomnienie Id: {id} zostało usunięte", result });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlatnoscPrzypomnienieExists(int id)
        {
            return db.FinPlatnoscPrzypomnienie.Count(e => e.FinPlatnoscPrzypomnienieId == id) > 0;
        }

        [HttpGet]
        [Route("api/FinPlatnoscPrzypomnienie/Zaplacone")]
        public IHttpActionResult FinPlatnoscZaplacone()
        {
            var kwartal = Pomocne.DateHelpful.kwartal();
            var result = (from ppz in db.FinPlatnoscPrzypomnienie
                          join k in db.Kontrahent on ppz.KontrahentRefId equals k.KontrahentId
                          where ppz.IsDone == true && ppz.TerminPlatnosci >= kwartal
                          select new
                          {
                              DataZaplaty = ppz.DataZaplaty,
                              DoneBy = ppz.DoneBy,
                              FakturaNr = ppz.FakturaNr,
                              KontrahentAdres = (k.KodKraju == null ? null : k.KodKraju) + (k.KodPocztowy == null ? null : ", " + k.KodPocztowy) + (k.Miejscowosc == null ? null : " " + k.Miejscowosc) + (k.Ulica == null ? null : ", " + k.Ulica) + (k.UlicaNr == null ? null : " " + k.UlicaNr),
                              KontrahentNazwa = (k.Nazwa == null ? k.Imie + " " + k.Nazwisko : k.Nazwa),
                              Kwota = ppz.Kwota,
                              Nip = k.NIP,
                              Pesel = k.Pesel,
                              PlatnoscPrzypomnienieId = ppz.FinPlatnoscPrzypomnienieId,
                              TerminPlatnosci = ppz.TerminPlatnosci,
                              Uwagi = ppz.Uwagi,
                              Waluta = new WalutaDTO()
                              {
                                  Nazwa = ppz.Waluta.Nazwa,
                                  Skrot = ppz.Waluta.Skrot,
                                  WalutaId = ppz.Waluta.FinWalutaId
                              }

                          }).ToList();


            var raportDane = (from r in result
                              where r.Waluta.WalutaId == 1
                              group r by new { r.TerminPlatnosci.Year, r.TerminPlatnosci.Month } into pGroup
                              select new
                              {
                                  Miesiac = pGroup.Key.Year.ToString() + "-" + pGroup.Key.Month.ToString("00"),
                                  Wartosc = pGroup.Sum(s => s.Kwota)


                              }).OrderBy(o => o.Miesiac).ToList();

            var raport = new List<RaportPozycja>();

            foreach (var item in raportDane)
            {
                RaportPozycja raportTemp = new RaportPozycja();
                raportTemp.Wartosc = Math.Truncate(item.Wartosc * 100) / 100;
                raportTemp.Label = item.Miesiac;
                raport.Add(raportTemp);
            }


            var raportKontrahentDane = (from r in result
                                        where r.Waluta.WalutaId == 1
                                        orderby r.Kwota descending
                                        group r by r.KontrahentNazwa into rGroup
                                        select new
                                        {
                                            Kontrahent = rGroup.Key,
                                            Wartosc = rGroup.Sum(s => s.Kwota)
                                        }).Take(10).ToList();
            var raportKontrahent = new List<RaportPozycja>();


            foreach (var item in raportKontrahentDane)
            {
                RaportPozycja raportTemp = new RaportPozycja();
                raportTemp.Wartosc = Math.Truncate(item.Wartosc * 100) / 100;
                raportTemp.Label = item.Kontrahent;
                raportKontrahent.Add(raportTemp);
            }



            return Ok(new { Info = $"Filtr dla 'terminPlatnosci' od dnia: {kwartal.ToShortDateString()}", result, raport, raportKontrahent });
        }

        [HttpPost]
        [Route("api/FinPlatnoscPrzypomnienie/DateRange")]
        public IHttpActionResult PlatnoscPrzypomnienieZaplaconeDateRange(DateRangeDTO dateRange)
        {
            var result = (from ppz in db.FinPlatnoscPrzypomnienie
                          join k in db.Kontrahent on ppz.KontrahentRefId equals k.KontrahentId
                          where ppz.IsDone == true && ppz.TerminPlatnosci >= dateRange.DateStart && ppz.TerminPlatnosci <= dateRange.DateEnd
                          select new
                          {
                              DataZaplaty = ppz.DataZaplaty,
                              DoneBy = ppz.DoneBy,
                              FakturaNr = ppz.FakturaNr,
                              KontrahentAdres = (k.KodKraju == null ? null : k.KodKraju) + (k.KodPocztowy == null ? null : ", " + k.KodPocztowy) + (k.Miejscowosc == null ? null : " " + k.Miejscowosc) + (k.Ulica == null ? null : ", " + k.Ulica) + (k.UlicaNr == null ? null : " " + k.UlicaNr),
                              KontrahentNazwa = (k.Nazwa == null ? k.Imie + " " + k.Nazwisko : k.Nazwa),
                              Kwota = ppz.Kwota,
                              Nip = k.NIP,
                              Pesel = k.Pesel,
                              PlatnoscPrzypomnienieId = ppz.FinPlatnoscPrzypomnienieId,
                              TerminPlatnosci = ppz.TerminPlatnosci,
                              Uwagi = ppz.Uwagi,
                              Waluta = new WalutaDTO()
                              {
                                  Nazwa = ppz.Waluta.Nazwa,
                                  Skrot = ppz.Waluta.Skrot,
                                  WalutaId = ppz.Waluta.FinWalutaId
                              }

                          }).ToList();

            var raportWartosc = (from r in result
                                 where r.Waluta.WalutaId == 1
                                 group r by new { r.TerminPlatnosci.Year, r.TerminPlatnosci.Month } into pGroup
                                 select new
                                 {
                                     Miesiac = pGroup.Key.Year.ToString() + "-" + pGroup.Key.Month.ToString("00"),
                                     Wartosc = pGroup.Sum(s => s.Kwota)


                                 }).OrderBy(o => o.Miesiac).ToList();

            var raport = new List<RaportPozycja>();

            foreach (var item in raportWartosc)
            {
                RaportPozycja raportTemp = new RaportPozycja();
                raportTemp.Wartosc = Math.Truncate(item.Wartosc * 100) / 100;
                raportTemp.Label = item.Miesiac;
                raport.Add(raportTemp);
            }


            var raportKontrahentDane = (from r in result
                                        where r.Waluta.WalutaId == 1
                                        orderby r.Kwota descending
                                        group r by r.KontrahentNazwa into rGroup
                                        select new
                                        {
                                            Kontrahent = rGroup.Key,
                                            Wartosc = rGroup.Sum(s => s.Kwota)
                                        }).Take(10).ToList();
            var raportKontrahent = new List<RaportPozycja>();


            foreach (var item in raportKontrahentDane)
            {
                RaportPozycja raportTemp = new RaportPozycja();
                raportTemp.Wartosc = Math.Truncate(item.Wartosc * 100) / 100;
                raportTemp.Label = item.Kontrahent;
                raportKontrahent.Add(raportTemp);
            }






            return Ok(new { info = $"Filtr dla pola: 'terminPlatnosci' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result, raport, raportKontrahent });
        }

        public PlatnoscPrzypomnienieCardDTO mPlatnoscPrzypomnienieById(int id)
        {
            return db.FinPlatnoscPrzypomnienie.Where(w => w.FinPlatnoscPrzypomnienieId == id).Select(s => new PlatnoscPrzypomnienieCardDTO
            {
                DataZaplaty = s.DataZaplaty.Value,
                DoneBy = s.DoneBy,
                FakturaId = s.FakturaZakupu.FinFakturaZakupuId,
                FakturaNr = s.FakturaNr,
                IsDone = s.IsDone,
                Kontrahent = new KontrahentInfoDTO()
                {
                    Kontrahent = s.Kontrahent,
                    KontrahentId = s.KontrahentRefId
                },
                Kwota = s.Kwota,
                PlatnoscPrzypomnienieId = s.FinPlatnoscPrzypomnienieId,
                TerminPlatnosci = s.TerminPlatnosci,
                Uwagi = s.Uwagi,
                Waluta = new WalutaDTO
                {
                    Nazwa = s.Waluta.Nazwa,
                    Skrot = s.Waluta.Skrot,
                    WalutaId = s.Waluta.FinWalutaId
                }


            }).FirstOrDefault();

        }


        public List<PlatnoscPrzypomnienieDTO> mPlatnoscPrzypomnienieLista()
        {
            return (from pp in db.FinPlatnoscPrzypomnienie
                    .Include(i => i.Kontrahent)
                    where pp.IsDone == false
                    group pp by pp.TerminPlatnosci into platnosciGroup
                    select new PlatnoscPrzypomnienieDTO()
                    {
                        Data = platnosciGroup.Key,
                        Platnosci = platnosciGroup.Select(p=> new PlatnoscPrzypomnienieCardDTO()
                                     {
                                         FakturaNr = p.FakturaNr,
                                         FakturaId = p.FakturaZakupu.FinFakturaZakupuId > 0 ? p.FakturaZakupu.FinFakturaZakupuId : 0,
                                         IsDone = p.IsDone,
                                         Kwota = p.Kwota,
                                         Kontrahent = new KontrahentInfoDTO()
                                         {
                                             Kontrahent = p.Kontrahent,
                                             KontrahentId=p.KontrahentRefId
                                             
                                         },
                                         PlatnoscPrzypomnienieId = p.FinPlatnoscPrzypomnienieId,
                                         TerminPlatnosci = p.TerminPlatnosci,
                                         Uwagi = p.Uwagi,
                                         Waluta = new WalutaDTO() { 
                                             WalutaId = p.Waluta.FinWalutaId,
                                             Nazwa = p.Waluta.Nazwa,
                                             Skrot = p.Waluta.Skrot
                                         }
                                     }).ToList()
                    }).ToList();
        }

    }

    public class RaportPozycja
    {
        public string Label { get; set; }
        public double Wartosc { get; set; }
    };
}


