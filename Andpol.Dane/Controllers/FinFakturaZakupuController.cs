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
using System.Globalization;

namespace Andpol.Dane.Pomocne
{

    [Authorize(Roles ="FinanseFaktury")]
    [EnableCors("*", "*", "*")]
    public class FinFakturaZakupuController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/FinFakturaZakupu
        public IHttpActionResult GetFinFakturaZakupu()
        {
            var kwartal = Pomocne.DateHelpful.kwartal();

            var result = (from fz in db.FinFakturaZakupu
                          .Include(i => i.FakturaPodsumowanieWartosci)
                          where fz.DataWystawienia >= kwartal
                          select new FakturaZakupuDTO()
                          {
                              CreatedBy = fz.CreatedBy,
                              CreatedDateTime = fz.CreatedDateTime,
                              CzyPrzypomnieniePlatnosc = fz.CzyPrzypomnieniePlatnosc,
                              DataSprzedazy = fz.DataSprzedazy,
                              DataWplywu = fz.DataWplywu,
                              DataWystawienia = fz.DataWystawienia,
                              FakturaNr = fz.FakturaNr,
                              FakturaZakupuId = fz.FinFakturaZakupuId,
                              Kontrahent = new KontrahentInfoDTO()
                              {
                                  Kontrahent=fz.Kontrahent,
                                  KontrahentId=fz.KontrahentRefId
                              },
                              PlatnoscRodzaj = new PlatnoscRodzajDTO()
                              {
                                  CzyDni = fz.PlatnoscRodzaj.CzyDni,
                                  CzyUwagi = fz.PlatnoscRodzaj.CzyUwagi,
                                  Nazwa = fz.PlatnoscRodzaj.Nazwa,
                              },
                              PlatnoscPrzypomnienie = fz.PlatnoscPrzypomnienie != null ? new PlatnoscPrzypomnienieCardDTO
                              {
                                  DoneBy = fz.PlatnoscPrzypomnienie.DoneBy,
                                  DataZaplaty = fz.PlatnoscPrzypomnienie.DataZaplaty,
                                  IsDone = fz.PlatnoscPrzypomnienie.IsDone,
                                  PlatnoscPrzypomnienieId = fz.PlatnoscPrzypomnienie.FinPlatnoscPrzypomnienieId,
                              } : null,
                              PlatnoscRodzajIleDni = fz.PlatnoscRodzajIleDni,
                              PlatnoscRodzajUwagi = fz.PlatnoscRodzajUwagi,
                              RazemBrutto = fz.RazemBrutto,
                              RazemNetto = fz.RazemNetto,
                              RazemVat = fz.RazemVat,
                              Waluta = new WalutaDTO()
                              {
                                  Nazwa = fz.Waluta.Nazwa,
                                  Skrot = fz.Waluta.Skrot,
                                  WalutaId = fz.Waluta.FinWalutaId
                              }
                          }).OrderByDescending(o => o.FakturaZakupuId).ToList();


            var raport = (from fpw in db.FinFakturaPodsumowanieWartosci
                          where fpw.FakturaZakupu.DataWystawienia >= kwartal
                          group fpw by fpw.FakturaZakupu.WalutaRefId into fpwWalutaGroup
                          select new {
                              WalutaId= fpwWalutaGroup.Select(s => s.FakturaZakupu.Waluta.FinWalutaId).FirstOrDefault(),
                              Nazwa =fpwWalutaGroup.Select(s=>s.FakturaZakupu.Waluta.Nazwa).FirstOrDefault(),
                              Skrot=fpwWalutaGroup.Select(s=>s.FakturaZakupu.Waluta.Skrot).FirstOrDefault(),
                              Szczegoly = (from w in fpwWalutaGroup
                                           group w by w.PodatekStawkaRefId into fzpwGroup
                                           select new
                                           {
                                               PodatekStawkaId = fzpwGroup.Key,
                                               Ilosc = fzpwGroup.Count(),
                                               Stawka = fzpwGroup.Select(s => s.PodatekStawka.Nazwa).FirstOrDefault(),
                                               StawkaWartosc = fzpwGroup.Select(sw => sw.PodatekStawka.Wartosc).FirstOrDefault(),
                                               WartoscBrutto = fzpwGroup.Sum(sum => sum.WartoscBrutto),
                                               WartoscNetto = fzpwGroup.Sum(sum => sum.WartoscNetto),
                                               WartoscVat = fzpwGroup.Sum(sum => sum.WartoscVat),
                                           }).ToList(),
                              RazemBrutto =fpwWalutaGroup.Sum(s=>s.WartoscBrutto),
                              RazemNetto=fpwWalutaGroup.Sum(s=>s.WartoscNetto),
                              RazemPodatek = fpwWalutaGroup.Sum(s => s.WartoscVat)
                          }).ToList();






            return Ok(new {Info = $"Filtr dla 'DataWystawienia' od dnia: {kwartal.ToShortDateString()}", result, raport });
        }

        // GET: api/FinFakturaZakupu/5
        [ResponseType(typeof(FakturaZakupuDTO))]
        public async Task<IHttpActionResult> GetFinFakturaZakupu(int id)
        {
            FinFakturaZakupu fakturaZakupu = await db.FinFakturaZakupu.FindAsync(id);
            if (fakturaZakupu == null)
            {
                return BadRequest("Nie ma takiego rekordu");
            }

            var result = await (from fz in db.FinFakturaZakupu.Include(i=>i.PlatnoscPrzypomnienie)
                                where fz.FinFakturaZakupuId == id
                                select new FakturaZakupuDTO()
                                {
                                    CreatedBy = fz.CreatedBy,
                                    CreatedDateTime = fz.CreatedDateTime,
                                    CzyPrzypomnieniePlatnosc = fz.CzyPrzypomnieniePlatnosc,
                                    DataSprzedazy = fz.DataSprzedazy,
                                    DataWplywu = fz.DataWplywu,
                                    DataWystawienia = fz.DataWystawienia,
                                    FakturaNr = fz.FakturaNr,
                                    FakturaPozycjeMag = fz.FakturaPozycje.Select(fp => new FakturaPozycjeMagDTO() {
                                        FakturaPozycjeMagId = fp.FinFakturaPozycjeId,
                                        Cena = fp.Cena,
                                        Ilosc = fp.Ilosc,
                                        Jednostka = fp.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                                        Nazwa = fp.PozycjaMagazynowa.Nazwa,
                                        PodatekStawka = fp.VatZakupu,
                                        PozycjaMagazynowaRefId = fp.PozycjaMagazynowaRefId,
                                        Status = "baza",
                                        Wartosc = fp.Wartosc,
                                    }).ToList(),
                                    FakturaPozycjeTkaniny = fz.FakturaPozycjeTkaniny.Select(fpt => new FakturaPozycjeTkaninyDTO() {
                                        FakturaPozycjeTkaninyId=fpt.FinFakturaPozycjeTkaninyId,
                                        Cena = fpt.Cena,
                                        Ilosc = fpt.Ilosc,
                                        Jednostka = "mb",
                                        MaterialId = fpt.MaterialRefId,
                                        Nazwa = fpt.Material.Nazwa,
                                        PodatekStawka = fpt.VatZakupu,
                                        Status = "baza",
                                        Wartosc = fpt.Wartosc,
                                    }).ToList(),
                                    FakturaZakupuId = fz.FinFakturaZakupuId,
                                    Kontrahent = new KontrahentInfoDTO() {
                                        Kontrahent=fz.Kontrahent,
                                        KontrahentId=fz.KontrahentRefId
                                    },
                                    ModifiedBy = fz.ModifiedBy,
                                    ModifiedDateTime = fz.ModifiedDateTime.HasValue? fz.ModifiedDateTime.Value: DateTime.Now,

                                    PlatnoscPrzypomnienieUwagi = fz.PlatnoscPrzypomnienie.Uwagi,
                                    PlatnoscRodzaj = new PlatnoscRodzajDTO() {
                                        CzyDni = fz.PlatnoscRodzaj.CzyDni,
                                        CzyUwagi = fz.PlatnoscRodzaj.CzyUwagi,
                                        Nazwa = fz.PlatnoscRodzaj.Nazwa,
                                        JednPlatnoscRodzajId = fz.PlatnoscRodzaj.JednPlatnoscRodzajId
                                    },
                                    PlatnoscRodzajIleDni = fz.PlatnoscRodzaj.CzyDni ? fz.PlatnoscRodzajIleDni : null,
                                    PlatnoscRodzajUwagi = fz.PlatnoscRodzajUwagi,
                                    PzRozliczoneMag = fz.PzRozliczoneMag.Select(frm => new MagPZDTO() {
                                        CreatedBy = frm.CreatedBy,
                                        DataWplywu = frm.DataWplywu,
                                        DataWystawienia = frm.DataWystawienia,
                                        DokumentZrodlowyNr = frm.DokumentZrodlowyNr,
                                        PzId = frm.MagPzId,
                                        Uwagi = frm.Uwagi,
                                    }).ToList(),
                                    PzRozliczoneTkaniny = fz.PzRozliczoneTkaniny.Select(frt => new MaterialBelkaPzTkaninyDTO() {
                                        CreatedBy=frt.CreatedBy,
                                        DataWystawienia=frt.DataWystawienia,
                                        DokumentZrodlowyNr=frt.DokumentZrodlowyNr,
                                        PzTkaninyId=frt.MaterialBelkaPzTkaninyId,
                                        Uwagi=frt.Uwagi
                                    }).ToList(),
                                    RazemBrutto=fz.RazemBrutto,
                                    RazemNetto=fz.RazemNetto,
                                    RazemVat=fz.RazemVat,
                                    Status="baza",
                                    Uwagi=fz.Uwagi,                                    
                                    Waluta=new WalutaDTO() {
                                        Nazwa=fz.Waluta.Nazwa,
                                        Skrot=fz.Waluta.Skrot,
                                        WalutaId=fz.Waluta.FinWalutaId
                                    }
                                    
                                    
                                }).FirstOrDefaultAsync();



            var platnoscPrzypomnienie = db.FinPlatnoscPrzypomnienie.Where(w => w.FakturaZakupu.FinFakturaZakupuId ==id ).Select(s => new PlatnoscPrzypomnienieCardDTO
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

            if (platnoscPrzypomnienie != null) {
                result.PlatnoscPrzypomnienie = platnoscPrzypomnienie;
            }




            var stawki = (from j in db.JednPodatekStawka
                          select new PodatekStawkaDTO()
                          {
                              JednPodatekStawkaId = j.JednPodatekStawkaId,
                              Nazwa = j.Nazwa,
                              Uwagi = j.Uwagi,
                              Wartosc = j.Wartosc
                          }).ToList();

            var podsumowanieWartosci = (from fpw in db.FinFakturaPodsumowanieWartosci
                                        where fpw.FakturaZakupuRefId == id
                                        select new FakturaPodsumowanieWartosciDTO()
                                        {
                                            FakturaPodsumowanieWartosciId = fpw.FinFakturaPodsumowanieWartosciId,
                                            PodatekStawka = new PodatekStawkaDTO()
                                            {
                                                JednPodatekStawkaId = fpw.PodatekStawka.JednPodatekStawkaId,
                                                Nazwa = fpw.PodatekStawka.Nazwa,
                                                Uwagi = fpw.PodatekStawka.Uwagi,
                                                Wartosc = fpw.PodatekStawka.Wartosc
                                            },
                                            WartoscBrutto = fpw.WartoscBrutto,
                                            WartoscNetto = fpw.WartoscNetto,
                                            WartoscVat = fpw.WartoscVat,
                                        }).ToList();


            for (int i = 0; i < stawki.Count(); i++)
            {
                bool found = new bool();
                foreach (var pw in podsumowanieWartosci)
                {
                    if (pw.PodatekStawka.JednPodatekStawkaId == stawki[i].JednPodatekStawkaId)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    podsumowanieWartosci.Add(new FakturaPodsumowanieWartosciDTO()
                    {
                        FakturaZakupuRefId = id,
                        PodatekStawka = new PodatekStawkaDTO()
                        {
                            JednPodatekStawkaId = stawki[i].JednPodatekStawkaId,
                            Nazwa = stawki[i].Nazwa,
                            Uwagi = stawki[i].Uwagi,
                            Wartosc = stawki[i].Wartosc
                        },
                        Status = "baza",
                    });
                }
            }

            podsumowanieWartosci.OrderBy(o => o.PodatekStawka.JednPodatekStawkaId);
            result.FakturaPodsumowanieWartosci = podsumowanieWartosci;



            return Ok(result);
        }

        // PUT: api/FinFakturaZakupu/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFinFakturaZakupu(int id, FakturaZakupuDTO FZDTO)
        {


            if (id != FZDTO.FakturaZakupuId)
            {
                return BadRequest("ID się nie zgadzają...");
            }


            if (id == 0)
            {
                FinFakturaZakupu FZNew = new FinFakturaZakupu();
                FZNew.CreatedDateTime = DateTime.Now;
                FZNew.CreatedBy = FZDTO.CreatedBy;
                FZNew.CzyPrzypomnieniePlatnosc = FZDTO.CzyPrzypomnieniePlatnosc;
                FZNew.DataSprzedazy = FZDTO.DataSprzedazy;
                FZNew.DataWplywu = FZDTO.DataWplywu;
                FZNew.DataWystawienia = FZDTO.DataWystawienia;
                FZNew.FakturaNr = FZDTO.FakturaNr;
                FZNew.KontrahentRefId = FZDTO.Kontrahent.KontrahentId;
                FZNew.PlatnoscRodzajRefId = FZDTO.PlatnoscRodzaj.JednPlatnoscRodzajId;
                if (FZDTO.PlatnoscRodzaj.CzyDni == true) {
                    FZNew.PlatnoscRodzajIleDni = FZDTO.PlatnoscRodzajIleDni;
                    if (FZDTO.CzyPrzypomnieniePlatnosc == true)
                    {

                        var termPlatnosci = new DateTime(FZDTO.DataWystawienia.Year, FZDTO.DataWystawienia.Month, FZDTO.DataWystawienia.Day, 9, 0, 0, 0);
                        FZNew.PlatnoscPrzypomnienie = new FinPlatnoscPrzypomnienie()
                        {
                            FakturaNr = FZDTO.FakturaNr,
                            FakturaZakupu = FZNew,
                            KontrahentRefId = FZDTO.Kontrahent.KontrahentId,
                            Kwota = FZDTO.RazemBrutto,
                            TerminPlatnosci = termPlatnosci.AddDays(FZDTO.PlatnoscRodzajIleDni.Value),
                            Uwagi = FZDTO.PlatnoscPrzypomnienieUwagi,
                            WalutaRefId = FZDTO.Waluta.WalutaId
                        };
                    }
                };
                if (FZDTO.PlatnoscRodzaj.CzyUwagi == true) {
                    FZNew.PlatnoscRodzajUwagi = FZDTO.PlatnoscRodzajUwagi;
                }
                FZNew.RazemBrutto = FZDTO.RazemBrutto;
                FZNew.RazemNetto = FZDTO.RazemNetto;
                FZNew.RazemVat = FZDTO.RazemVat;
                FZNew.Uwagi = FZDTO.Uwagi;
                FZNew.WalutaRefId = FZDTO.Waluta.WalutaId;


                
                db.FinFakturaZakupu.Add(FZNew);
                await db.SaveChangesAsync();
                id = FZNew.FinFakturaZakupuId;

                foreach (var item in FZDTO.FakturaPozycjeMag)
                {
                    db.FinFakturaPozycje.Add(new FinFakturaPozycje
                    {
                        Cena = item.Cena,
                        FakturaZakupuRefId=id,
                        Ilosc=item.Ilosc,
                        PozycjaMagazynowaRefId=item.PozycjaMagazynowaRefId,
                        Wartosc=item.Wartosc,
                        VatZakupuRefId=item.PodatekStawka.JednPodatekStawkaId
                    });

                }

                foreach (var item in FZDTO.FakturaPozycjeTkaniny)
                {
                    db.FinFakturaPozycjeTkaniny.Add(new FinFakturaPozycjeTkaniny
                    {
                        Cena = item.Cena,
                        FakturaZakupuRefId = id,
                        Ilosc = item.Ilosc,
                        MaterialRefId=item.MaterialId,
                        Wartosc = item.Wartosc,
                        VatZakupuRefId = item.PodatekStawka.JednPodatekStawkaId
                    });
                }


                foreach (var item in FZDTO.FakturaPodsumowanieWartosci)
                {
                    if (item.WartoscBrutto.HasValue)
                    {
                        db.FinFakturaPodsumowanieWartosci.Add(new FinFakturaPodsumowanieWartosci
                        {
                            FakturaZakupuRefId = id,
                            PodatekStawkaRefId = item.PodatekStawka.JednPodatekStawkaId,
                            WartoscBrutto = item.WartoscBrutto,
                            WartoscNetto = item.WartoscNetto,
                            WartoscVat = item.WartoscVat
                        });
                    }
                }

                foreach (var item in FZDTO.PzRozliczoneMag)
                {
                    MagPz pzTemp = await db.MagPz.FindAsync(item.PzId);
                    pzTemp.CzyZaksiegowana = true;
                    pzTemp.FakturaZakupuRefId = id;
                }

                foreach (var item in FZDTO.PzRozliczoneTkaniny)
                {
                    MaterialBelkaPzTkaniny pzt = db.MaterialBelkaPzTkaniny.Find(item.PzTkaninyId);
                    pzt.CzyZaksiegowana = true;
                    pzt.FakturaZakupuRefId = id;
                }


                if (FZDTO.PlatnoscRodzaj.CzyDni == true)
                {
                    //if (FZDTO.CzyPrzypomnieniePlatnosc == true) {


                    //    int? ileDni = FZDTO.PlatnoscRodzajIleDni;
                        
                    //    DateTime terminPlatnosci = new DateTime(FZDTO.DataWystawienia.AddDays(ileDni.Value).Year, FZDTO.DataWystawienia.AddDays(ileDni.Value).Month, FZDTO.DataWystawienia.AddDays(ileDni.Value).Day, 9, 0, 0);

                    //    db.FinPlatnoscPrzypomnienie.Add(new FinPlatnoscPrzypomnienie
                    //    {
                    //        CzyEuro = false,
                    //        FakturaNr=FZDTO.FakturaNr,
                    //        KontrahentRefId=FZDTO.Kontrahent.KontrahentId,
                    //        Kwota= FZDTO.RazemBrutto,
                    //        Uwagi=FZDTO.Uwagi,
                    //        TerminPlatnosci= terminPlatnosci
                    //    });
                    //}
                };

            }

            else {

//                return BadRequest("Jeszcze nie ma opcji aktualizacji faktury...");

                if (FZDTO.Status == "zmieniony") {
                    FinFakturaZakupu fzMod = await db.FinFakturaZakupu.FindAsync(id);
                    db.Entry(fzMod).State = EntityState.Modified;

                    fzMod.ModifiedDateTime = DateTime.Now;
                    fzMod.ModifiedBy = FZDTO.ModifiedBy;
                    fzMod.DataSprzedazy = FZDTO.DataSprzedazy;
                    fzMod.DataWplywu = FZDTO.DataWplywu;
                    fzMod.DataWystawienia = FZDTO.DataWystawienia;
                    fzMod.FakturaNr = FZDTO.FakturaNr;
                    fzMod.KontrahentRefId = FZDTO.Kontrahent.KontrahentId;
                    fzMod.PlatnoscRodzajRefId = FZDTO.PlatnoscRodzaj.JednPlatnoscRodzajId;
                    if (FZDTO.PlatnoscRodzaj.CzyDni == true)
                    {
                        fzMod.PlatnoscRodzajIleDni = FZDTO.PlatnoscRodzajIleDni;
                    };
                    if (FZDTO.PlatnoscRodzaj.CzyUwagi == true)
                    {
                        fzMod.PlatnoscRodzajUwagi = FZDTO.PlatnoscRodzajUwagi;
                    }
                    fzMod.RazemBrutto = FZDTO.RazemBrutto;
                    fzMod.RazemNetto = FZDTO.RazemNetto;
                    fzMod.RazemVat = FZDTO.RazemVat;
                    fzMod.Uwagi = FZDTO.Uwagi;
                    fzMod.WalutaRefId = FZDTO.Waluta.WalutaId;

                    var termPlatnosci = new DateTime(FZDTO.DataWystawienia.Year, FZDTO.DataWystawienia.Month, FZDTO.DataWystawienia.Day, 9, 0, 0, 0);

                    var platnoscOld = (from pp in db.FinPlatnoscPrzypomnienie where pp.FakturaZakupu.FinFakturaZakupuId == id select pp).FirstOrDefault();
                    if (FZDTO.PlatnoscRodzaj.CzyDni)
                    {
                        if (FZDTO.CzyPrzypomnieniePlatnosc)
                        {
                            if (platnoscOld != null )
                            {
                                platnoscOld.FakturaNr = FZDTO.FakturaNr;
                                platnoscOld.KontrahentRefId = FZDTO.Kontrahent.KontrahentId;
                                platnoscOld.Kwota = FZDTO.RazemBrutto;
                                platnoscOld.TerminPlatnosci = termPlatnosci.AddDays(FZDTO.PlatnoscRodzajIleDni.Value);
                                platnoscOld.Uwagi = FZDTO.PlatnoscPrzypomnienieUwagi;
                                platnoscOld.WalutaRefId = FZDTO.Waluta.WalutaId;
                                db.Entry(platnoscOld).State = EntityState.Modified;
                            }
                            else
                            {
                                fzMod.PlatnoscPrzypomnienie = new FinPlatnoscPrzypomnienie()
                                {
                                    FakturaNr = FZDTO.FakturaNr,
                                    FakturaZakupu = fzMod,
                                    KontrahentRefId = FZDTO.Kontrahent.KontrahentId,
                                    Kwota = FZDTO.RazemBrutto,
                                    TerminPlatnosci = termPlatnosci.AddDays(FZDTO.PlatnoscRodzajIleDni.Value),
                                    Uwagi = FZDTO.PlatnoscPrzypomnienieUwagi,
                                    WalutaRefId = FZDTO.Waluta.WalutaId
                                };
                                fzMod.CzyPrzypomnieniePlatnosc = true;
                            }

                        }
                        else {
                            if (platnoscOld != null)
                            {
                                db.FinPlatnoscPrzypomnienie.Remove(platnoscOld);
                                fzMod.CzyPrzypomnieniePlatnosc = false;

                                db.LogsDelete.Add(new LogsDelete
                                {
                                    DataUsuniecia = DateTime.Now,
                                    Tabela = "FinPlatnoscPrzypomnienie_FZ",
                                    UserName = User.Identity.Name,
                                    Uwagi = "TerminPlatnosci: " + platnoscOld.TerminPlatnosci.ToShortDateString() + " KontrahentRefId: " + platnoscOld.KontrahentRefId + " kwota: " + platnoscOld.Kwota.ToString("0.00") + " WalutaRefId: " + platnoscOld.WalutaRefId.ToString()
                                });
                            }
                        }

                    } else {
                        if (platnoscOld != null)
                        {
                            db.FinPlatnoscPrzypomnienie.Remove(platnoscOld);
                            fzMod.CzyPrzypomnieniePlatnosc = false;

                            db.LogsDelete.Add(new LogsDelete
                            {
                                DataUsuniecia = DateTime.Now,
                                Tabela = "FinPlatnoscPrzypomnienie_FZ",
                                UserName = User.Identity.Name,
                                Uwagi = "TerminPlatnosci: " + platnoscOld.TerminPlatnosci.ToShortDateString() + " KontrahentRefId: " + platnoscOld.KontrahentRefId + " kwota: " + platnoscOld.Kwota.ToString("0.00") + " WalutaRefId: " + platnoscOld.WalutaRefId.ToString()
                            });
                        }
                        fzMod.PlatnoscRodzajIleDni = null;
                    }

                    
                    foreach (var item in FZDTO.FakturaPozycjeMag)
                    {
                        if (item.Status == "zmieniony")
                        {
                            FinFakturaPozycje fPoz = await db.FinFakturaPozycje.FindAsync(item.FakturaPozycjeMagId);
                            fPoz.Cena = item.Cena;
                            fPoz.VatZakupuRefId = item.PodatekStawka.JednPodatekStawkaId;
                        }
                    }

                    foreach (var item in FZDTO.FakturaPozycjeTkaniny)
                    {
                        var fpozT = db.FinFakturaPozycjeTkaniny.Find(item.FakturaPozycjeTkaninyId);

                        if (fpozT != null) {
                            fpozT.Cena = item.Cena;
                            fpozT.VatZakupuRefId = item.PodatekStawka.JednPodatekStawkaId;
                        }
                    }



                    foreach (var item in FZDTO.FakturaPodsumowanieWartosci)
                    {
                        if (item.FakturaPodsumowanieWartosciId > 0 && item.WartoscBrutto>0) {
                            var podsMod=db.FinFakturaPodsumowanieWartosci.Find(item.FakturaPodsumowanieWartosciId);
                            podsMod.WartoscBrutto = item.WartoscBrutto.Value;
                            podsMod.WartoscNetto = item.WartoscNetto.HasValue? item.WartoscNetto :null;
                            podsMod.WartoscVat = item.WartoscVat.HasValue? item.WartoscVat: null;
                        }

                        if (item.FakturaPodsumowanieWartosciId == 0 && item.WartoscBrutto > 0)
                        {
                            var podsMod = db.FinFakturaPodsumowanieWartosci.Add(new FinFakturaPodsumowanieWartosci());
                            podsMod.FakturaZakupuRefId = id;
                            podsMod.PodatekStawkaRefId = item.PodatekStawka.JednPodatekStawkaId;
                            podsMod.WartoscBrutto = item.WartoscBrutto.Value;
                            podsMod.WartoscNetto = item.WartoscNetto.HasValue ? item.WartoscNetto: null;
                            podsMod.WartoscVat = item.WartoscVat.HasValue ? item.WartoscVat : null;
                        }
                        if (item.FakturaPodsumowanieWartosciId > 0 && !item.WartoscBrutto.HasValue)
                        {
                            db.FinFakturaPodsumowanieWartosci.Remove(db.FinFakturaPodsumowanieWartosci.Find(item.FakturaPodsumowanieWartosciId));
                        }
                    }



                };


            }
            




            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinFakturaZakupuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { Info = $"Faktura id {id} została zapisana" });
        }

        // POST: api/FinFakturaZakupu
        [ResponseType(typeof(FinFakturaZakupu))]
        public async Task<IHttpActionResult> PostFinFakturaZakupu(FinFakturaZakupu magPozycjaMagazynowa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinFakturaZakupu.Add(magPozycjaMagazynowa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = magPozycjaMagazynowa.FinFakturaZakupuId }, magPozycjaMagazynowa);
        }

        // DELETE: api/FinFakturaZakupu/5
        [ResponseType(typeof(FinFakturaZakupu))]
        public async Task<IHttpActionResult> DeleteFinFakturaZakupu(int id)
        {
            FinFakturaZakupu fz = await db.FinFakturaZakupu.FindAsync(id);
            if (fz == null)
            {
                return NotFound();
            }

            //zmiana pzTkanin
            var pztkiTkaniny = (from pzk in db.MaterialBelkaPzTkaniny where pzk.FakturaZakupuRefId == id select pzk).ToList();
            string pztkiTkaninyStr = pztkiTkaniny.Count > 0 ? " PzTkaniny: " : "";
            foreach (var item in pztkiTkaniny)
            {
                item.CzyZaksiegowana = false;
                pztkiTkaninyStr += item.MaterialBelkaPzTkaninyId+ ",";
            }

            //zmiana statusu dla PZtek
            var pzki = (from pz in db.MagPz where pz.FakturaZakupuRefId == id select pz).ToList();

            string pzkiStr = pzki.Count > 0 ? " PzMag: " : "";
            foreach (var item in pzki)
            {
                item.FakturaZakupuRefId = null;
                item.CzyZaksiegowana = false;
                pzkiStr += item.MagPzId + ",";
            }
            
            //usuniecie platnoscPrzypomnienie

            var pprzyp = (from pp in db.FinPlatnoscPrzypomnienie where pp.FakturaZakupu.FinFakturaZakupuId == id select pp).FirstOrDefault();



            string przypStr = fz.CzyPrzypomnieniePlatnosc ? " PlatPrzypId: " + pprzyp.FinPlatnoscPrzypomnienieId.ToString() : "";
            


            db.LogsDelete.Add(new LogsDelete()
            {
                DataUsuniecia = DateTime.Now,
                Tabela = "FinFakturaZakupu",
                UserName = User.Identity.Name,
                Uwagi = "DataWystawienia: " + fz.DataWystawienia.ToShortDateString() + " kwotaBrutto: " + fz.RazemBrutto.ToString("0.00") +" walutaRefId: "+ fz.WalutaRefId.ToString() + " kontrahentRefId: " + fz.KontrahentRefId + pzkiStr+pztkiTkaninyStr+przypStr
            });

            if (fz.CzyPrzypomnieniePlatnosc) { db.FinPlatnoscPrzypomnienie.Remove(pprzyp);}
            db.FinFakturaZakupu.Remove(fz);
            await db.SaveChangesAsync();

            string pzkiStrRes = pzki.Count > 0 ? pzkiStr += " pozostaje(ą) do usunięcia" : "";


            return Ok($"FinFakturaZakupu Id {id} została usunięta. {pzkiStrRes}");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinFakturaZakupuExists(int id)
        {
            return db.FinFakturaZakupu.Count(e => e.FinFakturaZakupuId == id) > 0;
        }


        [HttpGet]
        [Route("api/finFakturaZakupu/nierozliczonePz")]
        public IHttpActionResult NierozliczonePz()
        {


            var pz = (from npz in db.MagPz
                          where npz.CzyZaksiegowana == false && npz.CzyKorekta == false
                          select new MagPZDTO()
                          {
                              CreatedBy = npz.CreatedBy,
                              DataWplywu = npz.DataWplywu,
                              DataWystawienia = npz.DataWystawienia,
                              DokumentTyp = (from dt in db.JednDokumentTyp
                                             where dt.JednDokumentTypId == npz.DokumentZrodlowyRefId
                                             select new DokumentTypDTO()
                                             {
                                                 Nazwa = dt.Nazwa,
                                             }).FirstOrDefault(),
                              DokumentZrodlowyNr = npz.DokumentZrodlowyNr,
                              PzId = npz.MagPzId,
                              Kontrahent = new KontrahentInfoDTO {
                                  Kontrahent=npz.Kontrahent,
                                  KontrahentId=npz.KontrahentRefId
                              },
                              PzPozycja = (from pzpoz in db.MagPzPozycja
                                           where pzpoz.MagPzRefId == npz.MagPzId
                                           select new PZPozycjaDTO()
                                           {
                                               MagPzPozycjaId = pzpoz.MagPzPozycjaId,
                                               Ilosc = pzpoz.Ilosc,
                                               PozycjaMagazynowa = (from pm in db.MagPozycjaMagazynowa
                                                                    where pm.MagPozycjaMagazynowaId == pzpoz.PozycjaMagazynowaRefId
                                                                    select new MagPozycjaMagazynowaFullCennikDTO()
                                                                    {
                                                                        Nazwa = pm.Nazwa,
                                                                        PozycjaMagazynowaId = pm.MagPozycjaMagazynowaId,
                                                                        Uwagi = pm.Uwagi,
                                                                        CzyPotwierdzone = pm.czyPotwierdzone,
                                                                        JednostkaMiary = pm.JednostkaMiary,
                                                                        VatZakupu = pm.VatZakupu,
                                                                        GrupaZakladowa = pm.GrupaZakladowa,
                                                                        MarzaZakladowa = pm.MarzaZakladowa,
                                                                        Statystyki = (from z in db.FinFakturaPozycje
                                                                                      where z.PozycjaMagazynowaRefId == pm.MagPozycjaMagazynowaId
                                                                                      group z by z.PozycjaMagazynowaRefId into zGroup

                                                                                      select new StatystykiDTO()
                                                                                      {
                                                                                          Min = zGroup.Min(x => x.Cena),
                                                                                          Max = zGroup.Max(x => x.Cena),
                                                                                          Avg = zGroup.Average(x => x.Cena),
                                                                                          Count = zGroup.Count(),
                                                                                          Ostatni = (from fp in db.FinFakturaPozycje join fz in db.FinFakturaZakupu on fp.FakturaZakupuRefId equals fz.FinFakturaZakupuId join k in db.Kontrahent on fz.KontrahentRefId equals k.KontrahentId where fp.PozycjaMagazynowaRefId ==zGroup.Key orderby fz.DataWystawienia descending select new MagPozOstatniDTO() {
                                                                                              Cena=fp.Cena,
                                                                                              DataOstatniegoZakupu=fz.DataWystawienia,
                                                                                              Kontrahent=k.Skrot
                                                                                          }).FirstOrDefault()
                                                                                          
                                                                                          
                                                                                          
                                                                                      }).FirstOrDefault()



                                                                    }).FirstOrDefault()
                                           }).ToList(),
                              Uwagi = npz.Uwagi
                          }).ToList().OrderBy(x => x.DataWystawienia);

            var pzK = (from npz in db.MagPzKorekta
                       where npz.MagPz.CzyZaksiegowana == false
                       select new MagPZDTO()
                       {
                           CreatedBy = npz.CreatedBy,
                           CzyKorekta = true,
                           DataWplywu = npz.DataWplywu,
                           DataWystawienia = npz.DataWystawienia,
                           DokumentTyp = (from dt in db.JednDokumentTyp
                                          where dt.JednDokumentTypId == npz.DokumentZrodlowyRefId
                                          select new DokumentTypDTO()
                                          {
                                              Nazwa = dt.Nazwa,
                                          }).FirstOrDefault(),
                           DokumentZrodlowyNr = npz.DokumentZrodlowyNr,
                           Kontrahent = new KontrahentInfoDTO {
                               Kontrahent=npz.Kontrahent,
                               KontrahentId=npz.KontrahentRefId
                           },
                           PzId = npz.MagPz.MagPzId,
                           PzPozycja = (from pzpoz in db.MagPzPozycja
                                        where pzpoz.MagPzKorektaRefId == npz.MagPzKorektaId
                                        select new PZPozycjaDTO()
                                        {
                                            MagPzPozycjaId=pzpoz.MagPzPozycjaId,
                                            Ilosc = pzpoz.Ilosc,
                                            PozycjaMagazynowa = (from pm in db.MagPozycjaMagazynowa
                                                                 where pm.MagPozycjaMagazynowaId == pzpoz.PozycjaMagazynowaRefId
                                                                 select new MagPozycjaMagazynowaFullCennikDTO()
                                                                 {
                                                                     Nazwa = pm.Nazwa,
                                                                     PozycjaMagazynowaId = pm.MagPozycjaMagazynowaId,
                                                                     Uwagi = pm.Uwagi,
                                                                     CzyPotwierdzone = pm.czyPotwierdzone,
                                                                     JednostkaMiary = pm.JednostkaMiary,
                                                                     VatZakupu = pm.VatZakupu,
                                                                     GrupaZakladowa = pm.GrupaZakladowa,
                                                                     MarzaZakladowa = pm.MarzaZakladowa,
                                                                     Statystyki = (from z in db.FinFakturaPozycje
                                                                                   where z.PozycjaMagazynowaRefId == pm.MagPozycjaMagazynowaId
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



                                                                                   }).FirstOrDefault()



                                                                 }).FirstOrDefault()
                                        }).ToList(),
                           Uwagi = npz.Uwagi
                       }).ToList();

            var pzk_gruuped = pzK.GroupBy(p => p.PzId).Select(y => y.LastOrDefault());


            return Ok(new { pz= pz, pzKorekta=pzk_gruuped});
        }

        [HttpPost]
        [Route("api/FinFakturaZakupu/DateRange")]
        public IHttpActionResult PostFinFakturaZakupuDateRange(DateRangeDTO dateRange) {



            var result = db.FinFakturaZakupu.Include(i=>i.PlatnoscPrzypomnienie).Where(w=>w.DataWystawienia >= dateRange.DateStart && w.DataWystawienia <= dateRange.DateEnd).Select(fz=> new FakturaZakupuDTO()
            {
                CreatedBy = fz.CreatedBy,
                CreatedDateTime = fz.CreatedDateTime,
                CzyEuro = fz.CzyEuro,
                CzyPrzypomnieniePlatnosc = fz.CzyPrzypomnieniePlatnosc,
                DataSprzedazy = fz.DataSprzedazy,
                DataWplywu = fz.DataWplywu,
                DataWystawienia = fz.DataWystawienia,
                FakturaNr = fz.FakturaNr,
                FakturaZakupuId = fz.FinFakturaZakupuId,
                PlatnoscPrzypomnienie=fz.PlatnoscPrzypomnienie!=null? new PlatnoscPrzypomnienieCardDTO {
                    DoneBy=fz.PlatnoscPrzypomnienie.DoneBy,
                    DataZaplaty =fz.PlatnoscPrzypomnienie.DataZaplaty,
                    IsDone=fz.PlatnoscPrzypomnienie.IsDone,
                    PlatnoscPrzypomnienieId = fz.PlatnoscPrzypomnienie.FinPlatnoscPrzypomnienieId,
                }: null,
               
                Kontrahent = new KontrahentInfoDTO()
                              {
                                Kontrahent=fz.Kontrahent,
                                KontrahentId=fz.KontrahentRefId
                },
                PlatnoscRodzaj=new PlatnoscRodzajDTO {
                    Nazwa=fz.PlatnoscRodzaj.Nazwa,
                },
                PlatnoscRodzajIleDni = fz.PlatnoscRodzajIleDni,
                PlatnoscRodzajUwagi = fz.PlatnoscRodzajUwagi,
                RazemBrutto = fz.RazemBrutto,
                RazemNetto = fz.RazemNetto,
                RazemVat = fz.RazemVat,
                Uwagi=fz.Uwagi,
                Waluta=new WalutaDTO {
                    Skrot=fz.Waluta.Skrot
                }
            }).OrderByDescending(o => o.FakturaZakupuId).ToList();

            var raport = (from fpw in db.FinFakturaPodsumowanieWartosci
                          where fpw.FakturaZakupu.DataWystawienia >= dateRange.DateStart && fpw.FakturaZakupu.DataWystawienia<=dateRange.DateEnd
                          group fpw by fpw.FakturaZakupu.CzyEuro into fpwWalutaGroup
                          select new
                          {
                              WalutaId = fpwWalutaGroup.Select(s => s.FakturaZakupu.Waluta.FinWalutaId).FirstOrDefault(),
                              Nazwa = fpwWalutaGroup.Select(s => s.FakturaZakupu.Waluta.Nazwa).FirstOrDefault(),
                              Skrot = fpwWalutaGroup.Select(s => s.FakturaZakupu.Waluta.Skrot).FirstOrDefault(),
                              Szczegoly = (from w in fpwWalutaGroup
                                           group w by w.PodatekStawkaRefId into fzpwGroup
                                           select new
                                           {
                                               PodatekStawkaId = fzpwGroup.Key,
                                               Ilosc = fzpwGroup.Count(),
                                               Stawka = fzpwGroup.Select(s => s.PodatekStawka.Nazwa).FirstOrDefault(),
                                               StawkaWartosc = fzpwGroup.Select(sw => sw.PodatekStawka.Wartosc).FirstOrDefault(),
                                               WartoscBrutto = fzpwGroup.Sum(sum => sum.WartoscBrutto),
                                               WartoscNetto = fzpwGroup.Sum(sum => sum.WartoscNetto),
                                               WartoscVat = fzpwGroup.Sum(sum => sum.WartoscVat),
                                           }).ToList(),
                              RazemBrutto = fpwWalutaGroup.Sum(s => s.WartoscBrutto),
                              RazemNetto = fpwWalutaGroup.Sum(s => s.WartoscNetto),
                              RazemPodatek = fpwWalutaGroup.Sum(s => s.WartoscVat)
                          }).ToList();



            return Ok(new { info= $"Filtr dla pola: 'dataWystawienia' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result, raport} );
        }

    }

   
}