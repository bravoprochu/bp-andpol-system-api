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
using Andpol.Dane.Pomocne.MagWZ.DTO;
using Andpol.Dane.Pomocne.FakturaSprzedazy.DTO;
using Andpol.Dane.ModelsDTO;
using Andpol.Dane.Pomocne.PlanningExt;

namespace Andpol.Dane.Pomocne.MagWZ
{
    [Authorize(Roles = "MagazynWz, FinanseFaktury")]
    [EnableCors("*", "*", "*")]
    public class MagWzController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/MagWz
        public IHttpActionResult GetMagWz()
        {
            var dateRange = Pomocne.DateHelpful.DateRangeOstKwartal();
            var result = this.GetDataByDateRange(dateRange);
            return Ok(new { info = $"Filtr dla pola: 'dataWystawienia' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result });
        }

        // GET: api/MagWz/5
        [ResponseType(typeof(MagWz))]
        public async Task<IHttpActionResult> GetMagWz(int id)
        {
            MagWz magWz = await db.MagWz.FindAsync(id);
            if (magWz == null)
            {
                return NotFound();
            }

            if (magWz.CzyKorekta) return BadRequest("Dokument miał utworzoną korektę pobierz ostatnią wersję..");

            var result = db.MagWz.Where(w => w.MagWzId == id).Select(s => new MagWzDetailDTO
            {
                MagWzId=s.MagWzId,
                BaseMagWzId=s.BaseMagWzId,
                CreatedInfo=new CreatedInfoDTO {
                    CreatedBy = s.CreatedBy,
                    CreatedDateTime = s.CreatedDateTime
                },
                CzyKorekta =s.CzyKorekta,
                DataWystawienia=s.DataWystawienia,
                Kontrahent=new ModelsDTO.KontrahentInfoDTO {
                    Kontrahent=s.Kontrahent,
                    KontrahentId=s.KontrahentRefId
                },
                NumerDokumentu=s.NumerDokumentu,
                NumerDokumentuZrodlowego=s.NumerDokumentuZrodlowego,
                Uwagi=s.Uwagi,

                PozycjeMagazynowe=s.MagWzPozycjaPozMag.Select(sp=>new MagWzPozycjeMagazynoweDTO() {
                    Ilosc=sp.Ilosc,
                    Jednostka=sp.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                    Nazwa=sp.PozycjaMagazynowa.Nazwa,
                    PozycjaMagazynowaId=sp.PozycjaMagazynowa.MagPozycjaMagazynowaId,
                    StanAktualny=sp.PozycjaMagazynowa.StanAktualny.Value
                }).ToList(),

                ZamowieniaWybrane=s.MagWzPozycjaZamowienie.Select(z=>new FakturaSprzedazZamowieniaBazaDTO() {
                    ZamowienieId = z.Zamowienie.Id,
                    Commission = z.Zamowienie.Commission,
                    CreatedInfo = new CreatedInfoDTO
                    {
                        CreatedBy = z.Zamowienie.CreatedBy,
                        CreatedDateTime = z.Zamowienie.CreatedDateTime,
                    },
                    DataRealizacji = z.Zamowienie.DataRealizacji.Value,
                    DataZamowienia = z.Zamowienie.DataZamowienia,
                    DealerInfo = new DealerInfo
                    {
                        Dealer = z.Zamowienie.Dealer,
                        DealerDostawa = z.Zamowienie.DealerDostawa,
                        Kontrahent = z.Zamowienie.Dealer.Kontrahent
                    },
                    NormaNazwa = z.Zamowienie.Norma.Nazwa,
                    Reference = z.Zamowienie.Reference,
                    ZamowienieKombiInfo = new ZamowienieKombiInfoDTO
                    {
                        ZamowienieKombi = z.Zamowienie.ZamowienieKombi.Where(w => !w.Kombinacja.NazwaKombinacji.Nazwa.StartsWith("   ")).Select(sz => new ElementDoZaplanowania
                        {
                            KombinacjaId = sz.KombinacjaRefId,
                            Nazwa = sz.Kombinacja.NazwaKombinacji.Nazwa,
                            ZamowienieKombiId = sz.ZamowienieKombiId
                        }).OrderBy(o => o.ZamowienieKombiId).ToList(),
                    },
                    CzyRequireDeliver = z.Zamowienie.RequireDeliver,
                    //Wartosc = (double?)z.Zamowienie.ZamowienieKombi.Sum(sz => sz.Kombinacja.Wartosc.Value) ?? 0,
                    ZamowienieNr = z.Zamowienie.ZamowienieNr,
                }).ToList()

            }).FirstOrDefault();

            var dokumentyBazowe = db.MagWz.Where(w => w.CzyKorekta==true && ((w.BaseMagWzId==result.BaseMagWzId && w.BaseMagWzId != 0) || 
            w.MagWzId==result.BaseMagWzId)).Select(s => new MagWzDetailDTO
            {
                MagWzId=s.MagWzId,
                    BaseMagWzId = s.BaseMagWzId,
                    CreatedInfo = new CreatedInfoDTO
                    {
                        CreatedBy = s.CreatedBy,
                        CreatedDateTime = s.CreatedDateTime
                    },
                    CzyKorekta = s.CzyKorekta,
                    DataWystawienia = s.DataWystawienia,
                    Kontrahent = new ModelsDTO.KontrahentInfoDTO
                    {
                        Kontrahent = s.Kontrahent,
                        KontrahentId = s.KontrahentRefId
                    },
                    NumerDokumentu = s.NumerDokumentu,
                    NumerDokumentuZrodlowego = s.NumerDokumentuZrodlowego,
                    Uwagi = s.Uwagi,
                PozycjeMagazynowe = s.MagWzPozycjaPozMag.Select(sp => new MagWzPozycjeMagazynoweDTO()
                {
                    Ilosc = sp.Ilosc,
                    Jednostka = sp.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                    Nazwa = sp.PozycjaMagazynowa.Nazwa,
                    PozycjaMagazynowaId = sp.PozycjaMagazynowa.MagPozycjaMagazynowaId,
                    StanAktualny = sp.PozycjaMagazynowa.StanAktualny.Value
                }).ToList(),
                ZamowieniaWybrane = s.MagWzPozycjaZamowienie.Select(z => new FakturaSprzedazZamowieniaBazaDTO()
                {
                    ZamowienieId = z.Zamowienie.Id,
                    Commission = z.Zamowienie.Commission,
                    CreatedInfo = new CreatedInfoDTO
                    {
                        CreatedBy = z.Zamowienie.CreatedBy,
                        CreatedDateTime = z.Zamowienie.CreatedDateTime,
                    },
                    DataRealizacji = z.Zamowienie.DataRealizacji.Value,
                    DataZamowienia = z.Zamowienie.DataZamowienia,
                    DealerInfo = new DealerInfo
                    {
                        Dealer = z.Zamowienie.Dealer,
                        DealerDostawa = z.Zamowienie.DealerDostawa,
                        Kontrahent = z.Zamowienie.Dealer.Kontrahent
                    },
                    NormaNazwa = z.Zamowienie.Norma.Nazwa,
                    Reference = z.Zamowienie.Reference,
                    ZamowienieKombiInfo = new ZamowienieKombiInfoDTO
                    {
                        ZamowienieKombi = z.Zamowienie.ZamowienieKombi.Where(w => !w.Kombinacja.NazwaKombinacji.Nazwa.StartsWith("   ")).Select(sz => new ElementDoZaplanowania
                        {
                            KombinacjaId = sz.KombinacjaRefId,
                            Nazwa = sz.Kombinacja.NazwaKombinacji.Nazwa,
                            ZamowienieKombiId = sz.ZamowienieKombiId
                        }).OrderBy(o => o.ZamowienieKombiId).ToList(),
                    },
                    CzyRequireDeliver = z.Zamowienie.RequireDeliver,
                    Wartosc = z.Zamowienie.ZamowienieKombi.Sum(sz => sz.Kombinacja.Wartosc.Value),
                    ZamowienieNr = z.Zamowienie.ZamowienieNr,
                }).ToList()
            }).OrderByDescending(o=>o.MagWzId).ToList();

            return Ok(new { result=result, dokumentyBazowe=dokumentyBazowe});
        }

        // PUT: api/MagWz/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMagWz(int id, MagWzDetailDTO wzDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var wzInBaza = db.MagWz.Find(wzDTO.MagWzId);
            var wzBaza = new MagWz();

            if (id == 0)
            {
                wzBaza.CreatedBy = wzDTO.CreatedInfo.CreatedBy;
                wzBaza.CreatedDateTime = DateTime.Now;
                wzBaza.DataWystawienia = wzDTO.DataWystawienia;
                wzBaza.KontrahentRefId = wzDTO.Kontrahent.KontrahentId;
                wzBaza.Uwagi = wzDTO.Uwagi = wzDTO.Uwagi;
                var numeryDokumentow = db.MagWz.Where(w=>w.CzyKorekta==false).Select(s => s.NumerDokumentu).ToArray();
                var numerDokumentu = Pomocne.DocumentNumbers.DocNumbersMethods.NextDocNumberLong(numeryDokumentow, wzDTO.DataWystawienia);
                numerDokumentu.Przedrostek = "WZ";
                wzBaza.NumerDokumentu = numerDokumentu.FullString();

                if (wzDTO.CzyKorekta && wzInBaza!=null)
                {
                    wzBaza.BaseMagWzId = wzDTO.BaseMagWzId > 0 ? wzDTO.BaseMagWzId : wzDTO.MagWzId;
                    wzBaza.DataWystawienia = wzDTO.DataWystawienia;
                    wzBaza.KontrahentRefId = wzDTO.Kontrahent.KontrahentId;
                    wzBaza.NumerDokumentuZrodlowego = wzDTO.NumerDokumentu;

                    var numeryDokumentowKor = db.MagWz.Where(w => w.NumerDokumentu.StartsWith("KWZ")).Select(s => s.NumerDokumentu).ToArray();
                    var numerDokKor = Pomocne.DocumentNumbers.DocNumbersMethods.NextDocNumberLong(numeryDokumentowKor, wzDTO.DataWystawienia);
                    numerDokKor.Przedrostek = "KWZ";
                    wzBaza.NumerDokumentu = numerDokKor.FullString();

                    wzInBaza.CzyKorekta = true;
                    db.Entry(wzInBaza).State = EntityState.Modified;

                    //zamowienia
                    var zamWybr = db.MagWzPozycjaZamowienie.Where(w => w.MagWzRefId == wzDTO.MagWzId).Select(s => s).ToList();
                    foreach (var zam in zamWybr)
                    {
                        var z = db.Zamowienie.Find(zam.ZamowienieRefId);
                        z.ZamowienieStatus = (int)ZamowienieStatusEnum.GotoweDoWysylki;
                        db.Entry(z).State = EntityState.Modified;
                    }
                    var pozMagWybr = db.MagWzPozycjaPozMag.Where(w => w.MagWzRefId == wzDTO.MagWzIdKorekta).Select(s => s).ToList();
                    foreach (var pozMag in pozMagWybr)
                    {
                        var pm = db.MagPozycjaMagazynowa.Find(pozMag.PozycjaMagazynowaRefId);
                        pm.StanAktualny += pozMag.Ilosc;
                        pm.StanRzeczywisty += pozMag.Ilosc;
                        db.Entry(pm).State = EntityState.Modified;
                    }
                }

            }
            else {


                if (wzInBaza == null) return BadRequest($"Nie znaleziono dokumentu o id: {id}");
            }

            if (wzDTO.TypDanychDokumentu == (int)MagWzTypEnum.PozycjeMagazynowe) {
                foreach (var poz in wzDTO.PozycjeMagazynowe)
                {
                    var pozMagBaza = db.MagPozycjaMagazynowa.Find(poz.PozycjaMagazynowaId);

                    if (pozMagBaza == null) return BadRequest($"Nie znaleziono pozycji magazynowej {poz.Nazwa} o Id: {poz.PozycjaMagazynowaId}");

                    pozMagBaza.StanAktualny -= poz.Ilosc;
                    pozMagBaza.StanRzeczywisty -= poz.Ilosc;
                    db.Entry(pozMagBaza).State = EntityState.Modified;

                    var pozPM = new MagWzPozycjaPozMag();
                    pozPM.Ilosc = poz.Ilosc;
                    pozPM.PozycjaMagazynowaRefId = poz.PozycjaMagazynowaId;
                    pozPM.MagWz = wzBaza;
                    db.MagWzPozycjaPozMag.Add(pozPM);
                }
            }
            if (wzDTO.TypDanychDokumentu == (int)MagWzTypEnum.Zamowienia)
            {
                foreach (var zam in wzDTO.ZamowieniaWybrane)
                {

                    var zamBaza = db.Zamowienie.Find(zam.ZamowienieId);
                    if (zamBaza == null) return BadRequest($"Nie znaleziono zamówienia  o Id: {zam.ZamowienieId}");
                    zamBaza.ZamowienieStatus = (int)ModelsDTO.ZamowienieStatusEnum.Transport;
                    db.Entry(zamBaza).State = EntityState.Modified;

                    var zamPoz = new MagWzPozycjaZamowienie();
                    zamPoz.MagWz = wzBaza;
                    zamPoz.ZamowienieRefId = zam.ZamowienieId;
                    db.MagWzPozycjaZamowienie.Add(zamPoz);
                }
            }

            try
            {
                 db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e ;
            }
            

            var info = id > 0 ? $"Dane od id {id} zostały zaktualizowane poprawnie" : $"Nowy dokument został zapisany w bazie, uzyskał Id: {wzBaza.MagWzId}, a numer to: {wzBaza.NumerDokumentu}";
            return Ok(new { info = info});
        }

        // POST: api/MagWz
        [ResponseType(typeof(MagWz))]
        public async Task<IHttpActionResult> PostMagWz(MagWz magWz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MagWz.Add(magWz);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = magWz.MagWzId }, magWz);
        }

        // DELETE: api/MagWz/5
        [ResponseType(typeof(MagWz))]
        public async Task<IHttpActionResult> DeleteMagWz(int id)
        {
            MagWz magWz = await db.MagWz.FindAsync(id);
            if (magWz == null)
            {
                return NotFound();
            }

            db.MagWz.Remove(magWz);
            await db.SaveChangesAsync();

            return Ok(magWz);
        }



        [HttpPost]
        [Route("api/MagWz/DateRange")]
        public IHttpActionResult PostMagWzDateRange(DateRangeDTO dateRange)
        {

            var result = this.GetDataByDateRange(dateRange);

            return Ok(new { info = $"Filtr dla pola: 'dataWystawienia' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result });
        }

        [HttpGet]
        [Route("api/MagWz/Niezafakturowane")]
        public IHttpActionResult GetNiezafakturowane()
        {
            var podatekStawka = db.JednPodatekStawka.Select(p => new PodatekStawkaDTO
            {
                JednPodatekStawkaId = p.JednPodatekStawkaId,
                Nazwa = p.Nazwa,
                Wartosc = p.Wartosc,
                Uwagi = p.Uwagi
            }).OrderBy(o => o.JednPodatekStawkaId).ToList();

            var result = db.MagWz.Where(w => w.CzyZaksiegowana == false && w.CzyKorekta==false).Select(s => new MagWzNiezafakturowaneDTO
            {
                MagWzId=s.MagWzId,
                CzyPozMag=s.MagWzPozycjaPozMag.Count>0?true:false,
                BasicInfo=new MagWzBasicInfoDTO {
                    MagWzId=s.MagWzId,
                    CreatedInfo = new CreatedInfoDTO
                    {
                        CreatedBy = s.CreatedBy,
                        CreatedDateTime = s.CreatedDateTime,
                    },
                    DataWystawienia = s.DataWystawienia,
                    Kontrahent = new ModelsDTO.KontrahentInfoDTO
                    {
                        Kontrahent = s.Kontrahent,
                        KontrahentId = s.KontrahentRefId
                    },
                    NumerDokumentu = s.NumerDokumentu,
                    Uwagi = s.Uwagi,
                },
                ZamowienieKombi = s.MagWzPozycjaZamowienie.Select(sz => new MagWzZamowienieDTO
                {
                    Commission = sz.Zamowienie.Commission,
                    MaterialNazwa=sz.Zamowienie.ZamowienieKombi.FirstOrDefault().ZamowienieObszycie.FirstOrDefault().Material.Nazwa,
                    NormaNazwa=sz.Zamowienie.Norma.Nazwa,
                    WykonczeniaPolitykaCenowa = sz.Zamowienie.ZamowienieKombi.SelectMany(sm => sm.ZamowienieKombiWykonczenie)
                        .Select(wyk => new MagWzWyZamowienieKombiWykonczenieDTO()
                        {
                            KombinacjaRefId = wyk.ZamowienieKombi.KombinacjaRefId,
                            NazwaKombinacji = wyk.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa,
                            CzyPolitykaCenowa = wyk.KombinacjaWykonczenie.CzyPolitykaCenowa,
                            Ilosc = wyk.KombinacjaWykonczenie.Ilosc,
                            Nazwa = wyk.KombinacjaWykonczenie.Wykonczenie.Nazwa,
                            PolitykaCenowa = new PolitykaCenowaDTO
                            {
                                Nazwa = wyk.KombinacjaWykonczenie.PolitykaCenowa.Nazwa,
                                Reguly = wyk.KombinacjaWykonczenie.PolitykaCenowa.PolitykaCenowaRegula.Where(wr => wr.KontrahentRefId == sz.Zamowienie.Dealer.KontrahentRefId).Select(pcr => new PolitykaCenowaRegulaDTO
                                {
                                    CzyAktywna = pcr.CzyAktywna,
                                    TypRozliczenia = pcr.TypRozliczenia,
                                    Wartosc = pcr.Wartosc
                                }).ToList(),
                            },
                            WykonczenieGrupa = new WykonczenieGrupaDTO
                            {
                                WykonczenieGrupaId=wyk.KombinacjaWykonczenie.Wykonczenie.WykonczenieGrupa.WykonczenieGrupaId,
                                Nazwa = wyk.KombinacjaWykonczenie.Wykonczenie.WykonczenieGrupa.Nazwa
                            }
                        }).ToList(),

                    Kombinacje = sz.Zamowienie.ZamowienieKombi.Select(szk => new MagWzZamowienieKombiDTO
                    {
                        NazwaKombinacji = szk.Kombinacja.NazwaKombinacji.Nazwa,
                        KombinacjaRefId = szk.KombinacjaRefId,
                        ZamowienieKombiId = szk.ZamowienieKombiId,
                        Wartosc = (double?)szk.Kombinacja.Wartosc ?? 0,
                        Waga=(double?)szk.Kombinacja.Waga ?? 0
                    }).ToList(),
                    Reference = sz.Zamowienie.Reference,
                    ZamowienieNr = sz.Zamowienie.ZamowienieNr,
                    ZamowienieId=sz.ZamowienieRefId
                }).ToList(),
                PozycjeMagazynowe=s.MagWzPozycjaPozMag.Select(pzmag=>new MagWzPozycjeMagazynoweDTO {
                    Ilosc=pzmag.Ilosc,
                    Jednostka =pzmag.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                    Nazwa=pzmag.PozycjaMagazynowa.Nazwa,
                    PodatekStawka=new PodatekStawkaDTO {
                        JednPodatekStawkaId= pzmag.PozycjaMagazynowa.VatSprzedazy.JednPodatekStawkaId,
                        Nazwa= pzmag.PozycjaMagazynowa.VatSprzedazy.Nazwa,
                        Wartosc= pzmag.PozycjaMagazynowa.VatSprzedazy.Wartosc
                    },
                    PozycjaMagazynowaId=pzmag.PozycjaMagazynowaRefId,
                    Uwagi=pzmag.PozycjaMagazynowa.Uwagi,
                    UniqueKey=pzmag.PozycjaMagazynowaRefId.ToString(),
                }).ToList()
            }).OrderByDescending(o=>o.MagWzId).ToList();

            return Ok(result);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MagWzExists(int id)
        {
            return db.MagWz.Count(e => e.MagWzId == id) > 0;
        }


        private List<MagWzListaDTO> GetDataByDateRange(DateRangeDTO dateRange)
        {
            var result = db.MagWz.Where(w => w.CzyKorekta == false && w.DataWystawienia<=dateRange.DateEnd && w.DataWystawienia>=dateRange.DateStart).Select(s => new MagWzListaDTO
            {
                MagWzId=s.MagWzId,
                CreatedInfo=new CreatedInfoDTO {
                    CreatedBy = s.CreatedBy,
                    CreatedDateTime = s.CreatedDateTime,
                },
                DataWystawienia = s.DataWystawienia,
                Kontrahent = new ModelsDTO.KontrahentInfoDTO
                {
                    Kontrahent = s.Kontrahent,
                    KontrahentId = s.KontrahentRefId
                },
                NumerDokumentu = s.NumerDokumentu,
                Uwagi = s.Uwagi,
                PozycjeMagazynoweCount = s.MagWzPozycjaPozMag.Count,
                ZamowieniaWybraneCount = s.MagWzPozycjaZamowienie.Count
            }).ToList();

            return result;
        }

    }
}