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
using Andpol.Dane.Pomocne.PlanningExt;
using Andpol.Dane.Pomocne.FakturaSprzedazy.DTO;
using System.Net.Http.Headers;
using System.IO;
using OfficeOpenXml;
using Andpol.Dane.Pomocne.Zamowienia.DTO;
using System.Globalization;
using Andpol.Dane.Pomocne.Wykonczenia.DTO;

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles = "Zamowienia")]
    [EnableCors("*", "*", "*")]

    public class ZamowienieController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/Zamowienie

        public IHttpActionResult GetZamowienie()
        {
            var dateRange = Pomocne.DateHelpful.DateRangeOstKwartal();
            var result = this.ZamowienieDateRange(dateRange);

            return Ok(new { info = $"Filtr dla pola: 'dataUtworzenia' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result });
        }


        // GET: api/Zamowienie/5
        [ResponseType(typeof(ZamowienieDTO))]
        public async Task<IHttpActionResult> GetZamowienie(int id)
        {
            Zamowienie zamowienie = await db.Zamowienie.FindAsync(id);
            if (zamowienie == null)
            {
                return BadRequest("Nie znaleziono rekordu");
            }

            var result = (from z in db.Zamowienie
                          where z.Id == id
                          select new ZamowienieDTO
                          {
                              Commission = z.Commission,
                              CreatedBy = z.CreatedBy,
                              CreatedDateTime = z.CreatedDateTime,
                              DataRealizacji = z.DataRealizacji,
                              DataZamowienia = z.DataZamowienia,
                              Dealer = new KontrahentDealerZamowienieDTO()
                              {
                                  Adres = z.Dealer.KodKraju + " " + z.Dealer.Miejscowosc + " " + z.Dealer.Ulica + " " + z.Dealer.Nr,
                                  GodzinyOtwarcia=z.Dealer.GodzinyOtwarcia,
                                  CzyAdresDostawy = z.Dealer.CzyAdresDostawy,
                                  CzyWjedziePrzyczepa = z.Dealer.CzyWjedziePrzyczepa,
                                  DealerId = z.Dealer.Id,
                                  KontrahentRefId = z.Dealer.KontrahentRefId,
                                  Nazwa = z.Dealer.Nazwa,
                                  Uwagi = z.Dealer.Uwagi
                              },
                              DealerDostawa = new KontrahentDealerZamowienieDTO()
                              {
                                  Adres = z.DealerDostawa.KodKraju + " " + z.DealerDostawa.Miejscowosc + " " + z.DealerDostawa.Ulica + " " + z.DealerDostawa.Nr,
                                  GodzinyOtwarcia=z.DealerDostawa.GodzinyOtwarcia,
                                  CzyAdresDostawy = z.DealerDostawa.CzyAdresDostawy,
                                  CzyWjedziePrzyczepa = z.DealerDostawa.CzyWjedziePrzyczepa,
                                  DealerId = z.DealerDostawa.Id,
                                  KontrahentRefId = z.DealerDostawa.KontrahentRefId,
                                  Nazwa = z.DealerDostawa.Nazwa,
                                  Uwagi = z.DealerDostawa.Uwagi
                              },
                              Ilosc = z.Ilosc,
                              Kombinacje = z.ZamowienieKombi.Select(s => new ZamowienieNormaKombinacjaDTO()
                              {
                                  KombinacjaId = s.KombinacjaRefId,
                                  KombinacjaObszycie = s.ZamowienieObszycie.Select(so => new ZamowienieKombiObszycieDTO()
                                  {
                                      ZamowienieKombiObszycieId = so.ZamowienieKombiObszycieId,
                                      KombinacjaObszycieRefId = so.KombinacjeObszycie.KombinacjaObszycieId,
                                      Material = so.Material,
                                      ObszycieNazwa = so.KombinacjeObszycie.Obszycie.Nazwa,
                                      ObszycieRefId=so.KombinacjeObszycie.Obszycie.Id,
                                      Status = "baza",
                                      Uwagi = so.Uwagi,
                                  }).ToList(),
                                  KombinacjaWykonczenie = s.ZamowienieKombiWykonczenie.Select(zkw=>
                                                           new ZamowienieKombiWykonczenieDTO()
                                                           {
                                                               ZamowienieKombiWykonczenieId = zkw.ZamowienieKombiWykonczenieId,
                                                               KombinacjaWykonczenieRefId = zkw.KombinacjaWykonczenie.KombinacjaWykonczenieId,
                                                               WykonczenieRefId=zkw.KombinacjaWykonczenie.Wykonczenie.WykonczenieId,
                                                               Status = "baza",
                                                               WykonczenieGrupa=zkw.KombinacjaWykonczenie.Wykonczenie.WykonczenieGrupa
                                                           }).ToList(),
                                  NazwaKombinacji = new NazwaKombinacjiDTO()
                                  {
                                      Id = s.Kombinacja.NazwaKombinacji.Id,
                                      Nazwa = s.Kombinacja.NazwaKombinacji.Nazwa,
                                      Uwagi = s.Kombinacja.NazwaKombinacji.Uwagi
                                  },
                                  Status = "baza",
                                  ZamowienieKombiId = s.ZamowienieKombiId,
                              }).ToList(),
                              Kontrahent = new KontrahentStartDTO()
                                            {
                                                KontrahentId = z.Dealer.Kontrahent.KontrahentId,
                                                Nazwa = z.Dealer.Kontrahent.Nazwa,
                                                Skrot = z.Dealer.Kontrahent.Skrot,
                                            },
                              Norma=new ZamowienieNormaDTO {
                                  NormaId=z.Norma.Id
                              },
                              RequireDeliver = z.RequireDeliver,
                              Reference = z.Reference,
                              Uwagi = z.Uwagi,
                              ZamowienieNr = z.ZamowienieNr,
                              Status = "baza",

                          }).FirstOrDefault();

            var norma = db.Normy.Where(w => w.Id == result.Norma.NormaId).Select(s => new ZamowienieNormaDTO {
                NormaId = s.Id,
                Nazwa = s.Nazwa,
                Uwagi = s.Uwagi,
                Kombinacje = s.Kombinacje.Select(k => new ZamowienieNormaKombinacjaDTO {
                    KombinacjaId = k.KombinacjaId,
                    NazwaKombinacji = new NazwaKombinacjiDTO {
                        Id = k.NazwaKombinacji.Id,
                        Nazwa = k.NazwaKombinacji.Nazwa,
                        Uwagi = k.NazwaKombinacji.Uwagi
                    },
                    KombinacjaWykonczenie = k.KombinacjaWykonczenie.GroupBy(g=>g.Wykonczenie.WykonczenieGrupa.WykonczenieGrupaId).Select(sw => new ZamowienieKombiWykonczenieDTO
                    {
                        KombinacjaWykonczenieRefId = sw.Select(swg=>swg.KombinacjaWykonczenieId).FirstOrDefault(),
                        WykonczenieGrupa = sw.Select(swg=>swg.Wykonczenie.WykonczenieGrupa).FirstOrDefault()

                    }).ToList(),
                    KombinacjaObszycie=k.KombinacjeObszycie.Select(sko=>new ZamowienieKombiObszycieDTO {
                        KombinacjaObszycieRefId=sko.KombinacjaObszycieId,
                        ObszycieNazwa=sko.Obszycie.Nazwa,
                        ObszycieRefId=sko.Obszycie.Id,
                        Uwagi=sko.Obszycie.Uwagi,
                    }).ToList()
                }).ToList()
            }).FirstOrDefault();


            var wykonczenieOpcjeByKombinacjeNormy = db.KombinacjaWykonczenie
                .WhereIn(wi => wi.Kombinacja.KombinacjaId, norma.Kombinacje.Select(sk => sk.KombinacjaId).ToList())
                .GroupBy(g => g.Kombinacja.KombinacjaId).Select(sg => new WykonczenieOpcjeByKombinacjeNormyDTO
                {
                    KombinacjaRefId = sg.Key,
                    KombinacjaNazwa = sg.Select(s => s.Kombinacja.NazwaKombinacji.Nazwa).FirstOrDefault(),
                    WykonczenieByGrupa = sg.GroupBy(gw => gw.Wykonczenie.WykonczenieGrupa.WykonczenieGrupaId)
                        .Select(s => new WykonczenieOpcjeByWykonczenieGrupaDTO
                        {
                            WykonczenieGrupaRefId = s.Key,
                            WykonczenieGrupaNazwa = s.Select(swg => swg.Wykonczenie.WykonczenieGrupa.Nazwa).FirstOrDefault(),
                            Wykonczenia = s.Select(sw => new ModelsDTO.KombinacjaWykonczenieDTO()
                            {
                                Nazwa = sw.Wykonczenie.Nazwa,
                                Uwagi = sw.Wykonczenie.Uwagi,
                                WykonczenieId = sw.Wykonczenie.WykonczenieId,
                                WykonczenieGrupaRefId = sw.Wykonczenie.WykonczenieGrupa.WykonczenieGrupaId,
                                KombinacjaWykonczenieRefId=sw.KombinacjaWykonczenieId
                            }).ToList()
                        }).ToList()
                }).ToList();





            var material = db.Material.Where(w=>w. MaterialGrupa.Kontrahent.KontrahentId==result.Kontrahent.KontrahentId).Select(s=>s).ToList();

            foreach (var k in result.Kombinacje)
            {
                foreach (var kw in k.KombinacjaWykonczenie)
                {
                    var opcjaBykombi = wykonczenieOpcjeByKombinacjeNormy
                        .Where(w => w.KombinacjaRefId == k.KombinacjaId).FirstOrDefault().WykonczenieByGrupa;

                    var opcjeGrupy = opcjaBykombi.Where(w => w.WykonczenieGrupaRefId == kw.WykonczenieGrupa.WykonczenieGrupaId)
                        .Select(s => s.Wykonczenia).FirstOrDefault();
                    kw.WykonczenieOpcje = opcjeGrupy;
                }
            }

            foreach (var k in norma.Kombinacje)
            {
                foreach (var kw in k.KombinacjaWykonczenie)
                {
                    var opcjaBykombi = wykonczenieOpcjeByKombinacjeNormy
                        .Where(w => w.KombinacjaRefId == k.KombinacjaId).FirstOrDefault().WykonczenieByGrupa;

                    var opcjeGrupy = opcjaBykombi.Where(w => w.WykonczenieGrupaRefId == kw.WykonczenieGrupa.WykonczenieGrupaId)
                        .Select(s => s.Wykonczenia).FirstOrDefault();

                    kw.WykonczenieOpcje = opcjeGrupy;
                }
            }

            result.Norma = norma;


            return Ok(new { result, material });
        }

        // PUT: api/Zamowienie/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZamowienie(int id, ZamowienieDTO zDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var listaKopii = new List<Zamowienie>();

            for (int kopiaNr = 0; kopiaNr < zDTO.Ilosc ; kopiaNr++)
            {
                if (id == 0 || kopiaNr>0)
                {
                    var zNew = new Zamowienie();
                    if (zDTO.Status != "usuniety")
                    {
                        zNew.Commission = zDTO.Commission;
                        zNew.CreatedBy = zDTO.CreatedBy;
                        zNew.CreatedDateTime = DateTime.Now;
                        zNew.DataRealizacji = zDTO.DataRealizacji;
                        zNew.DataZamowienia = zDTO.DataZamowienia;
                        zNew.Ilosc = 1;
                        zNew.KontrahentDealerRefId = zDTO.Dealer.DealerId;
                        zNew.KontrahentDealerDostawaRefId = zDTO.DealerDostawa.DealerId;
                        zNew.NormaRefId = zDTO.Norma.NormaId;
                        zNew.Reference = zDTO.Reference;
                        zNew.RequireDeliver = zDTO.RequireDeliver;
                        zNew.ZamowienieStatus = 3;
                        zNew.Uwagi = zDTO.Uwagi;
                        zNew.ZamowienieNr = zDTO.ZamowienieNr;
                    }

                    foreach (var k in zDTO.Kombinacje.OrderBy(o => o.Lp).ToList())
                    {
                        if (k.Status != "usuniety")
                        {
                            var kNew = new ZamowienieKombi();
                            kNew.Zamowienie = zNew;
                            kNew.KombinacjaRefId = k.KombinacjaId;
                            zNew.ZamowienieKombi.Add(kNew);

                            foreach (var obsz in k.KombinacjaObszycie)
                            {
                                if (obsz.Status != "usuniety")
                                {
                                    var obszNew = new ZamowienieKombiObszycie();
                                    obszNew.MaterialRefId = obsz.Material.MaterialId;
                                    obszNew.KombinacjeObszycieRefId = obsz.KombinacjaObszycieRefId;
                                    obszNew.Uwagi = obsz.Uwagi;
                                    obszNew.ZamowienieKombi = kNew;
                                    kNew.ZamowienieObszycie.Add(obszNew);
                                }
                            }
                            foreach (var wyk in k.KombinacjaWykonczenie)
                            {
                                if (wyk.Status != "usuniety") {
                                    var wykNew = new ZamowienieKombiWykonczenie();
                                    wykNew.KombinacjaWykonczenieRefId = wyk.KombinacjaWykonczenieRefId;
                                    wykNew.ZamowienieKombi = kNew;
                                    kNew.ZamowienieKombiWykonczenie.Add(wykNew);
                                }
                            }

                        }
                    }
                    listaKopii.Add(zNew);

                }

                //zamowienie zapisane w bazie:

                if (id > 0 && kopiaNr==0)
                {
                    var zMod = db.Zamowienie.Find(id);
                    if (zMod == null) return BadRequest($"Nie znaleziono rekordu o ID: {id}");

                    if (zDTO.Status == "zmieniony" && kopiaNr == 0)
                    {
                        zMod.Commission = zDTO.Commission;
                        zMod.DataRealizacji = zDTO.DataRealizacji;
                        zMod.DataZamowienia = zDTO.DataZamowienia;
                        zMod.Ilosc = 1;
                        zMod.KontrahentDealerRefId = zDTO.Dealer.DealerId;
                        zMod.KontrahentDealerDostawaRefId = zDTO.DealerDostawa.DealerId;
                        zMod.NormaRefId = zDTO.Norma.NormaId;
                        zMod.Reference = zDTO.Reference;
                        zMod.RequireDeliver = zDTO.RequireDeliver;
                        zMod.ZamowienieStatus = 3;
                        zMod.Uwagi = zDTO.Uwagi;
                        zMod.ZamowienieNr = zDTO.ZamowienieNr;

                        db.Entry(zMod).State = EntityState.Modified;
                    }

                    //var zNew = new Zamowienie();
                    //if (zDTO.Status != "usuniety" && kopiaNr > 1)
                    //{
                    //    zNew.Commission = zDTO.Commission;
                    //    zNew.CreatedBy = zDTO.CreatedBy;
                    //    zNew.CreatedDateTime = DateTime.Now;
                    //    zNew.DataRealizacji = zDTO.DataRealizacji;
                    //    zNew.DataZamowienia = zDTO.DataZamowienia;
                    //    zNew.Ilosc = 1;
                    //    zNew.KontrahentDealerRefId = zDTO.Dealer.DealerId;
                    //    zNew.KontrahentDealerDostawaRefId = zDTO.DealerDostawa.DealerId;
                    //    zNew.NormaRefId = zDTO.Norma.NormaId;
                    //    zNew.Reference = zDTO.Reference;
                    //    zNew.RequireDeliver = zDTO.RequireDeliver;
                    //    zNew.ZamowienieStatus = 3;
                    //    zNew.Uwagi = zDTO.Uwagi;
                    //    zNew.ZamowienieNr = zDTO.ZamowienieNr;

                    //    zNew.ZamowienieStatus = 3;
                    //}


                    foreach (var k in zDTO.Kombinacje.OrderBy(o => o.Lp).ToList())
                    {
                        var kombiEntit= k.Status == "zmieniony" || k.Status == "usuniety" ? db.ZamowienieKombi.Find(k.ZamowienieKombiId) : new ZamowienieKombi();
                        kombiEntit.KombinacjaRefId = k.KombinacjaId;

                            if (k.Status == "nowy") {
                                kombiEntit.Zamowienie = zMod;
                                zMod.ZamowienieKombi.Add(kombiEntit);
                            }
                            if (k.Status == "usuniety") {
                                db.Entry(kombiEntit).State = EntityState.Deleted;
                            }


                        foreach (var obsz in k.KombinacjaObszycie)
                        {
                            var obszEntit = obsz.Status == "zmieniony" || obsz.Status == "usuniety" ? db.ZamowienieKombiObszycie.Find(obsz.ZamowienieKombiObszycieId) : new ZamowienieKombiObszycie();

                            obszEntit.MaterialRefId = obsz.Material.MaterialId;
                            obszEntit.Uwagi = obsz.Uwagi;
                            obszEntit.KombinacjeObszycieRefId = obsz.KombinacjaObszycieRefId;

                                switch (obsz.Status)
                                {
                                    case "nowy":
                                        obszEntit.ZamowienieKombi = kombiEntit;
                                        kombiEntit.ZamowienieObszycie.Add(obszEntit);
                                        break;
                                    case "zmieniony":
                                        obszEntit.MaterialRefId = obsz.Material.MaterialId;
                                        obszEntit.Uwagi = obsz.Uwagi;
                                        db.Entry(obszEntit).State = EntityState.Modified;
                                        break;
                                    case "usuniety":
                                        db.Entry(obszEntit).State = EntityState.Deleted;
                                        break;
                                }
                        }

                        foreach (var wyk in k.KombinacjaWykonczenie)
                        {
                            var wykEntit = wyk.Status == "zmieniony" || wyk.Status == "usuniety" ? db.ZamowienieKombiWykonczenie.Find(wyk.ZamowienieKombiWykonczenieId) : new ZamowienieKombiWykonczenie();


                                switch (wyk.Status)
                                {
                                    case "nowy":
                                        wykEntit.KombinacjaWykonczenieRefId = wyk.KombinacjaWykonczenieRefId;
                                        wykEntit.ZamowienieKombi = kombiEntit;
                                        kombiEntit.ZamowienieKombiWykonczenie.Add(wykEntit);
                                        break;
                                    case "zmieniony":
                                        wykEntit.KombinacjaWykonczenieRefId = wyk.KombinacjaWykonczenieRefId;
                                        db.Entry(wykEntit).State = EntityState.Modified;
                                        break;
                                    case "usuniety":
                                        db.Entry(wykEntit).State = EntityState.Deleted;
                                        break;
                                }
                        }
                    }
                }
            }


         db.Zamowienie.AddRange(listaKopii);
            


            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }

            return Ok(new { info = "Dane zostały zaktualizowan" });
        }


        [HttpPost]
        [Route("api/zamowienie/listaProdukcyjna")]
        public HttpResponseMessage PostListaProdukcyjna(ListaProdukcyjnaPostDTO reqData)
        {

            var daneBaza =new List<Zamowienie>();

            daneBaza = db.Zamowienie
                .Include(i => i.Dealer.Kontrahent)
                .Include(i => i.DealerDostawa)
                .Include(i => i.Norma)
                .Include(i => i.ZamowienieKombi.Select(si => si.Kombinacja.NazwaKombinacji))
                .Include(i => i.ZamowienieKombi.Select(si => si.ZamowienieObszycie.Select(sio => sio.KombinacjeObszycie.Obszycie)))
                .Include(i => i.ZamowienieKombi.Select(si => si.ZamowienieObszycie.Select(sio => sio.Material)))
                .Include(i => i.ZamowienieKombi.Select(si => si.ZamowienieKombiWykonczenie.Select(siw => siw.KombinacjaWykonczenie.Wykonczenie.WykonczenieGrupa)))
                .WhereIn(wi => wi.Id, reqData.ListaZamowien.Select(s => s.ZamowienieId).ToList())
                .Select(s => s).ToList();



            var daneBazaGrouped = daneBaza.GroupBy(g => new {
                UniqueKey = g.Norma.Nazwa+ g.Commission + g.Reference + g.ZamowienieNr
              }).Select(s =>new {
                  Ilosc=s.Count(),
                  Zamowienie = s.FirstOrDefault()
              }).ToList();

            if (reqData.isGrouped) {
                foreach (var z in daneBazaGrouped)
                {
                    z.Zamowienie.Ilosc = z.Ilosc;
                }
                daneBaza = daneBazaGrouped.Select(s => s.Zamowienie).ToList();
            }


            var dane = new List<ListaProdukcyjnaDTO>();
            var chronologiaKombi = new List<int>();
            foreach (var z in daneBaza)
            {
                chronologiaKombi = z.ZamowienieKombi.Select(s => s.ZamowienieKombiId).ToList();
                var zamObszycie = z.ZamowienieKombi.SelectMany(sm => sm.ZamowienieObszycie).ToList();
                var fabric = zamObszycie.GroupBy(g => g.Material.MaterialId).Select(s => new ListaProdukcyjnaGroupedByMaterial()
                {
                    MaterialId = s.Key,
                    Material = s.Select(sm=>sm.Material).FirstOrDefault(),
                    KombiGroupedByObszycie=s.GroupBy(gk=>gk.KombinacjeObszycie.Obszycie.Id).Select(so=>new ListProdukcyjnaGroupByObszycie(chronologiaKombi)
                    {
                        ObszycieId=so.Key,
                        ObszycieNazwa=so.Select(son=>son.KombinacjeObszycie.Obszycie.Nazwa).FirstOrDefault(),
                        ZamowienieKombi=so.Select(sok=>sok.ZamowienieKombi).ToList()
                    }).ToList()
                }).ToList();


                //statyczny ID obszyciaGrupa nóżki: 5
                var feet = zamObszycie.SelectMany(sm => sm.ZamowienieKombi.ZamowienieKombiWykonczenie.Where(w => w.KombinacjaWykonczenie.Wykonczenie.WykonczenieGrupa.WykonczenieGrupaId == 5))
                    .Select(sms => sms).ToList()
                    .GroupBy(g => g.KombinacjaWykonczenie.Wykonczenie.WykonczenieId)
                    .Select(smsg => new ListaProdukcyjnaGroupedByFeet(chronologiaKombi)
                    {
                        WykonczenieId=smsg.Key,
                        WykonczenieNazwa=smsg.Select(s=>s.KombinacjaWykonczenie.Wykonczenie.Nazwa).FirstOrDefault(),
                        ZamowienieKombi=smsg.Select(s=>s.ZamowienieKombi).ToList(),
                    }).ToList();



                dane.Add(new ListaProdukcyjnaDTO
                {
                    Pos = z.Id,
                    Combination = Pomocne.ZamowieniaHelpful.ZamowienieKombinacjeNazwa(z.ZamowienieKombi.Select(s => s.Kombinacja.NazwaKombinacji.Nazwa).ToList()),
                    Commission = z.Commission,
                    Customer = z.Dealer.Kontrahent.Skrot,

                    Feet=feet.Count==1 ? 
                        feet.Select(s=>s.WykonczenieNazwa).FirstOrDefault():
                        Pomocne.ZamowieniaHelpful.ValueKeyConcat(feet.Select(s=>s.WykonczenieNazwa).ToList(), feet.Select(s=>s.FeetResult).ToList()),

                    Fabric = fabric.Count == 1 ?
                        fabric.FirstOrDefault().Material.Nazwa :
                        Pomocne.ZamowieniaHelpful.ValueKeyConcat(fabric.Select(s => s.Material.Nazwa).ToList(), fabric.Select(s => s.MaterialResult).ToList()),
                    OrderDate = z.DataZamowienia.ToShortDateString(),
                    Model=z.Norma.Nazwa,
                    OrderNumber = z.ZamowienieNr,
                    Quantity=z.Ilosc,
                    PlaceOfDelivery= DTOHelpful.DealerInfo(z.Dealer),
                    Reference = z.Reference,
                    RequireDelivery=z.RequireDeliver,
                });
            }


            using (ExcelPackage pck = new ExcelPackage())
            {
                var ws = pck.Workbook.Worksheets.Add("contentus");
                ws.Cells["A1"].LoadFromCollection<ListaProdukcyjnaDTO>(dane, true, OfficeOpenXml.Table.TableStyles.Light18);
                //ws.Column(16).Style.Numberformat.Format = "[$-x-sysdate]dddd, mmmm dd, rrrr";
                ws.Cells.AutoFitColumns();
                

                MemoryStream ms = new MemoryStream(pck.GetAsByteArray());
                HttpResponseMessage res = new HttpResponseMessage();
                res.StatusCode = HttpStatusCode.OK;


            MediaTypeHeaderValue mediaType = new MediaTypeHeaderValue("application/octet-stream");
            res.Content = new StreamContent(ms);
            res.Content.Headers.ContentType = mediaType;
            res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            res.Content.Headers.ContentDisposition.FileName = "ListaProdukcyjna.xlsx";
            return res;


            }









            //res.Content = new ByteArrayContent(ms.GetBuffer());
            //res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachement")
            //{
            //    FileName = $"listaProdukcyjna.pdf",
            //};
            //res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");





        }


        // DELETE: api/Zamowienie/5
        [ResponseType(typeof(Zamowienie))]
        public IHttpActionResult DeleteZamowienie(int id)
        {
            //var zamowienie = (from z in db.ZamowienieKombi
            //                  where z.Zamowienie.Id == id
            //                  select new
            //                  {
            //                      ZamowienieKombi=z,
            //                      ZamowienieKombiWykonczenie = z.ZamowienieKombiWykonczenie.Select(sw => sw).ToList(),
            //                      ZamowienieKombiObszycie = z.ZamowienieObszycie.Select(so => so).ToList()
            //                  }).ToList();

            var zamowienia = db.ZamowienieKombi.Where(w=>w.ZamowienieRefId==id).Include(iz => iz.ZamowienieKombiWykonczenie).Include(iobsz => iobsz.ZamowienieObszycie).ToList();

            

            if (zamowienia == null)
            {
                return BadRequest($"Dupa, nie ma zamowienia o ID: {id}");
            }

            db.ZamowienieKombiObszycie.RemoveRange(zamowienia.SelectMany(sm => sm.ZamowienieObszycie));
            db.ZamowienieKombiWykonczenie.RemoveRange(zamowienia.SelectMany(sm => sm.ZamowienieKombiWykonczenie));
            db.ZamowienieKombi.RemoveRange(zamowienia);
            db.Zamowienie.Remove(db.Zamowienie.Find(id));
           



            //foreach (var kombi in zamowienie.ZamowienieKombi)
            //{
            //    if (kombi.ZamowienieKombiWykonczenie.Count > 0)
            //    {
            //        foreach(var wykon in kombi.ZamowienieKombiWykonczenie)
            //        {

            //            db.Entry(wykon).State = EntityState.Deleted;

            //            //var wyk = db.ZamowienieKombiWykonczenie.Find((int)wykon);

            //            //if (wyk != null)
            //            //{
            //            //    db.ZamowienieKombiWykonczenie.Remove(wyk);
            //            //}
            //        }
            //    }


            //    if (kombi.ZamowienieObszycie.Count > 0)
            //    {
            //        foreach (var obszycie in kombi.ZamowienieObszycie)
            //        {
            //            db.Entry(obszycie).State = EntityState.Deleted;

            //            //var obsz = db.ZamowienieKombiObszycie.Find((int)obszycie);

            //            //db.ZamowienieKombiObszycie.Remove(obsz);
            //        }

            //    }

            //    db.Entry(kombi).State = EntityState.Deleted;

            //    //db.ZamowienieKombi.Remove(db.ZamowienieKombi.Find((int)kombi.ZamowienieKombiId));

            //}

            //db.Zamowienie.Remove(db.Zamowienie.Find(id));





            db.SaveChanges();

            return Ok(new { info = $"Zamowienie o id: {id} zostało usunięte" });
        }


        [HttpGet]
        [Route("api/zamowienie/ZamowienieFakturaSprzedazy")]
        public IHttpActionResult GetZamowienieFakturaSprzedaz()
        {

            var result = (from z in db.Zamowienie
                          where z.ZamowienieStatus == 3
                          select new FakturaSprzedazZamowieniaBazaDTO()
                          {
                              ZamowienieId = z.Id,
                              Commission = z.Commission,
                              CreatedInfo = new CreatedInfoDTO
                              {
                                  CreatedBy = z.CreatedBy,
                                  CreatedDateTime = z.CreatedDateTime,
                              },
                              DataRealizacji = z.DataRealizacji.Value,
                              DataZamowienia = z.DataZamowienia,
                              DealerInfo = new DealerInfo
                              {
                                  Dealer = z.Dealer,
                                  DealerDostawa = z.DealerDostawa,
                                  Kontrahent = z.Dealer.Kontrahent
                              },
                              Ilosc = z.Ilosc,
                              NormaNazwa = z.Norma.Nazwa,
                              Reference = z.Reference,
                              ZamowienieKombiInfo = new ZamowienieKombiInfoDTO
                              {
                                  ZamowienieKombi = z.ZamowienieKombi.Where(w => !w.Kombinacja.NazwaKombinacji.Nazwa.StartsWith("   ")).Select(s => new ElementDoZaplanowania
                                  {
                                      KombinacjaId = s.KombinacjaRefId,
                                      Nazwa = s.Kombinacja.NazwaKombinacji.Nazwa,
                                      ZamowienieKombiId = s.ZamowienieKombiId
                                  }).OrderBy(o => o.ZamowienieKombiId).ToList(),
                              },
                              CzyRequireDeliver = z.RequireDeliver,
                              Uwagi = z.Uwagi,
                              Wartosc = z.ZamowienieKombi.Sum(x => (double?)(x.Kombinacja.Wartosc)) ?? 0,
                              ZamowienieNr = z.ZamowienieNr,
                          }).OrderBy(o => o.ZamowienieId).ToList();

            return Ok(result);
        }


        [HttpPost]
        [Route("api/zamowienie/ZamowieniaBazaPlanning")]
        public IHttpActionResult PostZamowieniaBazaPlanning(ProdukcjaDzialDTO produkcjaDzial)
        {

            List<PlanningZamowieniaBazaDTO> zamowienia = new List<PlanningZamowieniaBazaDTO>();
            //List<PlanningZamowieniaDTO> zamowienia = new List<PlanningZamowieniaDTO>();
            //            List<PlanningZamowieniaDTO> zamowieniaBaza = new List<PlanningZamowieniaDTO>();

            var zamowieniaKombiDlaProdukcjaDzial = db.PlanningDzienRoboczyZamowienieKombi
                .Where(w => w.IsDone == true || w.IsDone == false
                    && !w.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa.StartsWith("   ")
                    && w.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.KalendarzDniRoboczychDzialProd.Where(wk => wk.KalendarzDniRoboczychDzialProdId == w.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProdRefId).FirstOrDefault().ProdukcjaDzial.ProdukcjaDzialId == produkcjaDzial.ProdukcjaDzialId)
                .Select(s => new
                {
                    ZamowienieKombiRefId = s.ZamowienieKombiRefId
                }).ToList();

            if (produkcjaDzial.PoziomProdukcji == 1)
            {
                var zamowieniaBaza = (from z in db.Zamowienie
                                      where z.CzyZaplanowane == false
                                      select new PlanningZamowieniaBazaDTO()
                                      {
                                          ZamowienieId = z.Id,
                                          Commission = z.Commission,
                                          CreatedInfo = new CreatedInfoDTO
                                          {
                                              CreatedBy = z.CreatedBy,
                                              CreatedDateTime = z.CreatedDateTime,
                                          },
                                          CzyRequireDeliver = z.RequireDeliver,
                                          DataRealizacji = z.DataRealizacji.Value,
                                          DataZamowienia = z.DataZamowienia,
                                          DealerInfo = new DealerInfo
                                          {
                                              Dealer = z.Dealer,
                                              DealerDostawa = z.DealerDostawa,
                                              Kontrahent = z.Dealer.Kontrahent
                                          },
                                          Ilosc = z.Ilosc,
                                          NormaNazwa = z.Norma.Nazwa,
                                          Reference = z.Reference,
                                          Uwagi = z.Uwagi,
                                          ZamowienieKombiInfo = new ZamowienieKombiInfoDTO
                                          {
                                              ZamowienieKombi = z.ZamowienieKombi.Where(w => !w.Kombinacja.NazwaKombinacji.Nazwa.StartsWith("   ")).Select(s => new ElementDoZaplanowania
                                              {
                                                  KombinacjaId = s.KombinacjaRefId,
                                                  Nazwa = s.Kombinacja.NazwaKombinacji.Nazwa,
                                                  ZamowienieKombiId = s.ZamowienieKombiId
                                              }).OrderBy(o => o.ZamowienieKombiId).ToList(),
                                          },

                                          ZamowienieNr = z.ZamowienieNr,
                                      }).OrderBy(o => o.ZamowienieId).ToList();



                foreach (var zam in zamowieniaBaza)
                {
                    var unikalneElementyDoZaplanowania = new List<ElementDoZaplanowania>();
                    foreach (var zk in zam.ZamowienieKombiInfo.ZamowienieKombi)
                    {
                        if (zamowieniaKombiDlaProdukcjaDzial.Any(a => a.ZamowienieKombiRefId == zk.ZamowienieKombiId) == false)
                        {
                            unikalneElementyDoZaplanowania.Add(zk);
                        }
                    }

                    zam.ZamowienieKombiInfo.ZamowienieKombi = unikalneElementyDoZaplanowania;
                    if (zam.ZamowienieKombiInfo.ZamowienieKombi.Count > 0)
                    {
                        zamowienia.Add(zam);
                    }
                }


                //foreach (var z in zamowieniaBaza)
                //{
                //    mPlanningZamowienieKombiByProdukcjaDzial(z);
                //}


            }

            if (produkcjaDzial.PoziomProdukcji > 1)
            {
                var zamowieniaByProdukcjaDzial = db.PlanningDzienRoboczyZamowienieKombi
                .WhereIn(wi => wi.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzialRefId, produkcjaDzial.NadrzednyIdsLista)
                .Where(w => w.IsDone == true)
                .GroupBy(g => g.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzialRefId)
                .Select(sg => sg.Select(s => s.ZamowienieKombiRefId).ToList()).ToList();


                if (zamowieniaByProdukcjaDzial.Count == 0)
                {
                    return Ok(new { zamowienia, produkcjaDzial });
                }

                var intersectedList = zamowieniaByProdukcjaDzial.Aggregate((prev, next) => prev.Intersect(next).ToList());


                zamowienia = db.ZamowienieKombi
                    .WhereIn(wi => wi.ZamowienieKombiId, intersectedList)
                    .GroupBy(g => g.ZamowienieRefId)
                    .Select(sg => new PlanningZamowieniaBazaDTO
                    {
                        Commission = sg.Select(s => s.Zamowienie.Commission).FirstOrDefault(),
                        CreatedInfo = new CreatedInfoDTO
                        {
                            CreatedBy = sg.Select(s => s.Zamowienie.CreatedBy).FirstOrDefault(),
                            CreatedDateTime = sg.Select(s => s.Zamowienie.CreatedDateTime).FirstOrDefault(),
                        },
                        CzyRequireDeliver = sg.Select(s => s.Zamowienie.RequireDeliver).FirstOrDefault(),
                        DataRealizacji = sg.Select(s => s.Zamowienie.DataRealizacji.Value).FirstOrDefault(),
                        DataZamowienia = sg.Select(s => s.Zamowienie.DataZamowienia).FirstOrDefault(),
                        DealerInfo = new DealerInfo
                        {
                            DealerDostawa = sg.Select(s => s.Zamowienie.DealerDostawa).FirstOrDefault(),
                            Dealer = sg.Select(s => s.Zamowienie.Dealer).FirstOrDefault(),
                            Kontrahent = sg.Select(s => s.Zamowienie.Dealer.Kontrahent).FirstOrDefault()
                        },
                        Reference = sg.Select(s => s.Zamowienie.Reference).FirstOrDefault(),
                        ZamowienieKombiInfo = new ZamowienieKombiInfoDTO
                        {
                            ZamowienieKombi = sg.Select(s => new ElementDoZaplanowania()
                            {
                                KombinacjaId = s.KombinacjaRefId,
                                Nazwa = s.Kombinacja.NazwaKombinacji.Nazwa,
                                ZamowienieKombiId = s.ZamowienieKombiId
                            }).ToList(),
                        },
                        ZamowienieNr = sg.Select(s => s.Zamowienie.ZamowienieNr).FirstOrDefault(),
                        ZamowienieId = sg.Key
                    }).ToList();


                //foreach (var z in zamowienia)
                //{
                //    //z.ZamowienieStatus = ZamowienieStatus(z.ZamowienieId);
                //    mPlanningZamowienieKombiByProdukcjaDzial(z);
                //}

            }





            return Ok(new { zamowienia, produkcjaDzial });
        }


        [HttpPost]
        [Route("api/Zamowienie/DateRange")]
        public IHttpActionResult PostZamowienieDateRange(DateRangeDTO dateRange)
        {

            var result = ZamowienieDateRange(dateRange);

            return Ok(new { info = $"Filtr dla pola: 'dataUtworzenia' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result });
        }

        public List<ZamowienieListaDTO> ZamowienieDateRange(DateRangeDTO dateRange)
        {
            var result = new List<ZamowienieListaDTO>();

            result = db.Zamowienie
                .Where(w=>w.DataZamowienia>=dateRange.DateStart && w.DataZamowienia<=dateRange.DateEnd)
                .Select(z=> new ZamowienieListaDTO()
                          {
                              ZamowienieId = z.Id,
                              CzyZaplanowane = z.CzyZaplanowane,
                              Commission = z.Commission,
                              CreatedBy = z.CreatedBy,
                              CreatedDateTime = z.CreatedDateTime,
                              DataRealizacji = z.DataRealizacji.Value,
                              DataZamowienia = z.DataZamowienia,
                              Dealer = z.Dealer,

                              DealerDostawa = z.DealerDostawa,
                              Ilosc = z.Ilosc,
                              Kontrahent = z.Dealer.Kontrahent,

                              Reference = z.Reference,
                              RequireDeliver = z.RequireDeliver,
                              ZamowienieKombi = z.ZamowienieKombi.Select(s => new ElementDoZaplanowania
                              {
                                  KombinacjaId = s.KombinacjaRefId,
                                  Nazwa = s.Kombinacja.NazwaKombinacji.Nazwa,
                                  ZamowienieKombiId = s.ZamowienieKombiId
                              }).OrderBy(o => o.ZamowienieKombiId).ToList(),
                              //ZamowienieKombiNazwa = z.ZamowienieKombi.OrderBy(o => o.ZamowienieKombiId).Select(sk => sk.Kombinacja.NazwaKombinacji.Nazwa).ToList(),
                              ZamowienieNr = z.ZamowienieNr,
                          }).OrderBy(o => o.ZamowienieId).ToList();

            foreach (var z in result)
            {
                //z.ZamowienieStatus = ZamowienieStatus(z.ZamowienieId);
                mPlanningStatus(z);
            }

            return result;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZamowienieExists(int id)
        {
            return db.Zamowienie.Count(e => e.Id == id) > 0;
        }

        private void mPlanningStatus(ZamowienieListaDTO zamowienie)
        {

            var produkcjaPoziom = mPoziomProdukcjiDlaZamowienia(zamowienie.ZamowienieId);
            if (produkcjaPoziom == null)
            {
                return;
            }
            //            var planningInProgress = db.PlanningDzienRoboczyZamowienieKombi.Any(z => z.ZamowienieKombi.ZamowienieRefId == zamowienie.ZamowienieId);

            //var produkcjaDzialIds = db.ProdukcjaDzial.Where(wa => wa.PoziomProdukcji ==
            //db.PlanningDzienRoboczyZamowienieKombi
            //    .Where(w => w.ZamowienieKombi.Zamowienie.Id == zamowienieId)
            //    .Select(s => s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.PoziomProdukcji)
            //    .OrderByDescending(o => o)
            //    .FirstOrDefault()
            //).Select(s => s.ProdukcjaDzialId).ToList();


            var pogrupowaneDaneDlaNajwyzszegoPoziomuByProdukcjaDzialId = db.PlanningDzienRoboczyZamowienieKombi
                .WhereIn(wi => wi.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.ProdukcjaDzialId, produkcjaPoziom.ProdukcjaDzialIds)
                .Where(w => w.ZamowienieKombi.ZamowienieRefId == zamowienie.ZamowienieId)
                .Where(w => w.IsDone == true)
                .GroupBy(g => g.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.ProdukcjaDzialId)
                .Select(sg => new ElementDoZaplanowaniaGroupDTO
                {
                    ProdukcjaDzial = sg.Select(s => new ProdukcjaDzialDTO
                    {
                        CzyPozycjaMagazynowa = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.CzyPozycjaMagazynowa,
                        CzyTkaninaBelka = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.CzyTkaninaBelka,
                        NadrzednyIds = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.NadrzedneIds,
                        Nazwa = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.Nazwa,
                        ProdukcjaDzialId = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.ProdukcjaDzialId,
                        PoziomProdukcji = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.PoziomProdukcji,
                        Uwagi = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.Uwagi,
                    }).FirstOrDefault(),

                    ListaElementow = sg.Select(s => new ElementDoZaplanowania
                    {
                        KombinacjaId = s.ZamowienieKombi.KombinacjaRefId,
                        Nazwa = s.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa,
                        ZamowienieKombiId = s.ZamowienieKombiRefId
                    }).ToList()
                })
                .OrderByDescending(o => o.ProdukcjaDzial.PoziomProdukcji)
                .ToList();

            var kombiComparer = new ZamowienieKombiComparer();
            zamowienie.ZamowienieStatus = new ZamowienieStatusDTO();



            if (pogrupowaneDaneDlaNajwyzszegoPoziomuByProdukcjaDzialId.Count < produkcjaPoziom.ProdukcjaDzialCount)
            {

                foreach (var prodDzialId in produkcjaPoziom.ProdukcjaDzialIds)
                {
                    var foundInPogrupowane = pogrupowaneDaneDlaNajwyzszegoPoziomuByProdukcjaDzialId.Where(w => w.ProdukcjaDzial.ProdukcjaDzialId == prodDzialId).Select(s => s).FirstOrDefault();
                    if (foundInPogrupowane == null)
                    {
                        pogrupowaneDaneDlaNajwyzszegoPoziomuByProdukcjaDzialId.Add(new ElementDoZaplanowaniaGroupDTO
                        {
                            ProdukcjaDzial = new ProdukcjaDzialDTO
                            {
                                ProdukcjaDzialId = produkcjaPoziom.ProdukcjaDzialId,
                                PoziomProdukcji = produkcjaPoziom.PoziomProdukcji
                            }
                        });
                    }
                }

            }

            var intersected = pogrupowaneDaneDlaNajwyzszegoPoziomuByProdukcjaDzialId.Aggregate((prev, next) => new ElementDoZaplanowaniaGroupDTO
            {
                ProdukcjaDzial = prev.ProdukcjaDzial.PoziomProdukcji >= next.ProdukcjaDzial.PoziomProdukcji ? prev.ProdukcjaDzial : next.ProdukcjaDzial,
                ListaElementow = prev.ListaElementow.Intersect(next.ListaElementow, kombiComparer).ToList()
            });

            zamowienie.ZamowienieStatus = new ZamowienieStatusDTO
            {
                PoziomProdukcji = intersected.ProdukcjaDzial.PoziomProdukcji,
                ZamowieniaCount = zamowienie.ZamowienieKombi.Where(w => !w.Nazwa.StartsWith("   ")).ToList().Count,
                ZamowieniaWykonane = intersected.ListaElementow.Count
            };


            zamowienie.ZamowienieStatus.PlanningInProgress = pogrupowaneDaneDlaNajwyzszegoPoziomuByProdukcjaDzialId.Count > 0 ? true : false;




            //.Select(sg => new ZamowienieStatusDTO
            //{
            //    PoziomProdukcji = sg.Key,
            //    ZamowieniaCount = sg.Count(),
            //    ZamowieniaWykonane = sg.Where(w => w.IsDone == true).Select(s=>s).Count()
            //})
            //.OrderByDescending(o=>o.PoziomProdukcji)
            //.FirstOrDefault();
        }

        private PoziomProdukcjiInfoDTO mPoziomProdukcjiDlaZamowienia(int zamowienieId)
        {
            var produkcjaDzial = db.PlanningDzienRoboczyZamowienieKombi
                .Where(w => w.ZamowienieKombi.Zamowienie.Id == zamowienieId)
                .Select(s => new
                {
                    ProdukcjaDzial = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial,
                    DzienRoboczy = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy
                })
                .OrderByDescending(o => o.DzienRoboczy)
                .FirstOrDefault();

            if (produkcjaDzial != null)
            {
                var produkcjaDzialIds = db.ProdukcjaDzial.Where(w => w.PoziomProdukcji == produkcjaDzial.ProdukcjaDzial.PoziomProdukcji).Select(s => s.ProdukcjaDzialId).ToList();
                return new PoziomProdukcjiInfoDTO
                {
                    PoziomProdukcji = produkcjaDzial.ProdukcjaDzial.PoziomProdukcji,
                    ProdukcjaDzialIds = produkcjaDzialIds,
                    ProdukcjaDzialId = produkcjaDzial.ProdukcjaDzial.ProdukcjaDzialId
                };
            }
            else
            {
                return null;
            }



        }

    }


    public class ZamowienieKombiComparer : IEqualityComparer<ElementDoZaplanowania>
    {
        public bool Equals(ElementDoZaplanowania x, ElementDoZaplanowania y)
        {
            return x.ZamowienieKombiId == y.ZamowienieKombiId;
        }

        public int GetHashCode(ElementDoZaplanowania obj)
        {
            return obj.ZamowienieKombiId.GetHashCode();
        }

    }


    public class PoziomProdukcjiInfoDTO
    {
        public PoziomProdukcjiInfoDTO()
        {
            this.ProdukcjaDzialIds = new List<int>();
        }
        public int PoziomProdukcji { get; set; }
        public int ProdukcjaDzialId { get; set; }
        public List<int> ProdukcjaDzialIds { get; set; }
        public int ProdukcjaDzialCount
        {
            get
            {
                return this.ProdukcjaDzialIds.Count;
            }
        }

    }





}