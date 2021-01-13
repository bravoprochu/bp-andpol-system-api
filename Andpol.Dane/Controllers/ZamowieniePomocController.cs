using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using ZuzycieMaterialu.Zuzycie;

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="Zamowienia")]
    [EnableCors("*", "*", "*")]

    public class ZamowieniePomocController : ApiController
    {
        private PoligonContext db = new PoligonContext();


        [Route("api/ZamowieniePomoc/getNormy")]
        [HttpGet]
        public IHttpActionResult GetNormy()
        {
            var normy = from n in db.Normy
                        where n.Kombinacje.All(a=>a.Wartosc.HasValue)
                        select new ZamowieniePomocNormyDTO
                        {
                            Id = n.Id,
                            Nazwa = n.Nazwa,
                            //Kombinacje = (from k in db.Kombinacja
                            //              where k.NormaRefId == n.Id
                            //              select new ZamowieniePomocKombinacjeDTO
                            //              {
                            //                  Nazwa = k.NazwaKombinacji.Nazwa,
                            //                  Id = k.KombinacjaId,
                            //              }).OrderBy(m => m.Nazwa),
                            Kombinacje=n.Kombinacje.Select(s=>new ZamowieniePomocKombinacjeDTO() {
                                Id=s.KombinacjaId,
                                Nazwa=s.NazwaKombinacji.Nazwa
                            }).OrderBy(o=>o.Nazwa).ToList(),
                            KombinacjeCount = n.Kombinacje.Count(),
                        };

            //normy.Where(w => w.KombinacjeCount > 0).OrderBy(o => o.Nazwa).Select(s => s).ToList();

            
            


            return Ok(normy.Where(w => w.KombinacjeCount > 0).OrderBy(o => o.Nazwa).Select(s => s));
        }
        [HttpGet]
        [Route("api/ZamowieniePomoc/GetNormaDetail/{id}")]
        public IHttpActionResult GetNormaDetail(int id)
        {
            var result = db.Normy.Where(w=>w.Id==id).Select(n=> new ZamowienieNormaDTO()
                          {
                              Nazwa = n.Nazwa,
                              NormaId = n.Id,
                              Uwagi = n.Uwagi,
                              Kombinacje = n.Kombinacje.Select(k=> new ZamowienieNormaKombinacjaDTO()
                                            {
                                                NazwaKombinacji = new NazwaKombinacjiDTO() { Id = k.NazwaKombinacji.Id, Nazwa = k.NazwaKombinacji.Nazwa, Uwagi = k.NazwaKombinacji.Uwagi },
                                                KombinacjaId = k.KombinacjaId,
                                                KombinacjaObszycie = k.KombinacjeObszycie.Select(ko=> new ZamowienieKombiObszycieDTO()
                                                                      {
                                                                          KombinacjaObszycieRefId = ko.KombinacjaObszycieId,
                                                                          ObszycieNazwa = ko.Obszycie.Nazwa,
                                                                          ObszycieRefId = ko.Obszycie.Id,
                                                                          Status = "nowy",
                                                                      }).OrderBy(o => o.ObszycieNazwa).ToList(),
                                                KombinacjaWykonczenie = (from kw in db.KombinacjaWykonczenie where kw.KombinacjaRefId == k.KombinacjaId group kw by kw.Wykonczenie.WykonczenieGrupaRefId into wykGroup select new ZamowienieKombiWykonczenieDTO() {
                                                    ZamowienieKombiWykonczenieId = wykGroup.Key,
                                                    WykonczenieGrupa = wykGroup.Select(s => s.Wykonczenie.WykonczenieGrupa).FirstOrDefault(),
                                                    WykonczenieOpcje = wykGroup.Select(sw => new KombinacjaWykonczenieDTO() {
                                                        WykonczenieId = sw.Wykonczenie.WykonczenieId,
                                                        KombinacjaWykonczenieRefId=sw.KombinacjaWykonczenieId,
                                                        WykonczenieGrupaRefId=sw.Wykonczenie.WykonczenieGrupa.WykonczenieGrupaId,
                                                        Nazwa = sw.Wykonczenie.Nazwa,
                                                        Uwagi=sw.Wykonczenie.Uwagi
                                                    }).ToList(),
                                                }).ToList(),
                                            }).ToList()
                          }).FirstOrDefault();

            return Ok(result);
        }


        [Route("api/ZamowieniePomoc/WykonczeniePomoc")]
        [HttpGet]
        public IHttpActionResult GetWykonczeniePomoc()
        {
            var dealers = db.KontrahentDealerzy.Select(a => new
            {
                DealerId = a.Id,
                KontrahentId = a.Kontrahent.KontrahentId,
                Nazwa = a.Nazwa,
                Adres = a.KodKraju + " " + a.Miejscowosc + " " + a.Ulica + " " + a.Nr
            }).ToList();


            return Ok(dealers);
        }


        [Route("api/ZamowieniePomoc/getDealers")]
        [HttpGet]
        public IHttpActionResult GetDealers()
        {
            var dealers = db.KontrahentDealerzy.Select(a => new KontrahentDealerZamowienieDTO()
            {
                DealerId = a.Id,
                CzyAdresDostawy = a.CzyAdresDostawy,
                CzyWjedziePrzyczepa = a.CzyWjedziePrzyczepa,
                GodzinyOtwarcia = a.GodzinyOtwarcia,
                KontrahentRefId = a.Kontrahent.KontrahentId,
                KontrahentNazwa = a.Kontrahent.Nazwa,
                Nazwa = a.Nazwa,
                Adres = a.KodKraju + " " + a.Miejscowosc + " " + a.Ulica + " " + a.Nr,
                Uwagi = a.Uwagi
            }).ToList();

            return Ok(dealers);
        }

        [Route("api/ZamowieniePomoc/getDealersDostawa")]
        [HttpGet]
        public IHttpActionResult GetDealersDostawa()
        {
            var dealers = db.KontrahentDealerzy.Where(w => w.CzyAdresDostawy).Select(a => new KontrahentDealerZamowienieDTO()
            {
                DealerId = a.Id,
                CzyAdresDostawy = a.CzyAdresDostawy,
                CzyWjedziePrzyczepa = a.CzyWjedziePrzyczepa,
                GodzinyOtwarcia = a.GodzinyOtwarcia,
                KontrahentRefId = a.Kontrahent.KontrahentId,
                KontrahentNazwa = a.Kontrahent.Nazwa,
                Nazwa = a.Nazwa,
                Adres = a.KodKraju + " " + a.Miejscowosc + " " + a.Ulica + " " + a.Nr,
                Uwagi = a.Uwagi
            }).OrderBy(o=>o.Nazwa).ToList();
            return Ok(dealers);
        }


        [Route("api/ZamowieniePomoc/GetKontrahentDetail/{id}")]
        [HttpGet]
        public IHttpActionResult GetKontrahentDetail(int id)
        {
            var result = db.Kontrahent.Where(w=>w.KontrahentId==id).Select(k=>new
                          {
                              kontrahent = new KontrahentStartDTO() {
                                  KontrahentId=k.KontrahentId,
                                  Nazwa = k.Nazwa,
                                  Skrot = k.Skrot,
                                  },
                              Material= k.MaterialGrupa.Material.OrderBy(o=>o.Nazwa).ToList(),
                          }).FirstOrDefault();

            return Ok(result);
        }


        [HttpPost]
        [Route("api/ZamowieniePomoc/ZuzycieMaterialGrupa")]
        public IHttpActionResult PostZuzycieMaterialGrupaObszycie(ZuzycieMaterialGrupaDTO zuzycie)
        {

            var wynik = new ProstokatParent(zuzycie.Baza, zuzycie.ListaObszyc.ToList(), true);
            return Ok(new {zuzycie=wynik.Zuzycie, zuzycieWartosc=wynik.ZuzycieWartosc});
        }
    }


    public class ZamowieniePomocNormyDTO
    {
        public ZamowieniePomocNormyDTO()
        {
            this.Kombinacje = new HashSet<ZamowieniePomocKombinacjeDTO>();
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int KombinacjeCount { get; set; }

        public ICollection<ZamowieniePomocKombinacjeDTO> Kombinacje { get; set; }
    }

    public class ZamowieniePomocKombinacjeDTO
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
    }
      
}
