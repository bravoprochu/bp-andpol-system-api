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
using System.IO;
using Andpol.Dane.Pomocne.FakturaSprzedazy.DTO;
using System.Web.Http.Cors;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using System.Web.Hosting;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas;
using System.Net.Http.Headers;
using Andpol.Dane.Pomocne.FakturaSprzedazy.Entity;
using Andpol.Dane.ModelsDTO;
using Andpol.Dane.Pomocne.MagWZ.DTO;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy
{
    [Authorize(Roles = "FinanseFaktury")]
    [EnableCors("*", "*", "*")]
    public class FinFakturaSprzedazyController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/FinFakturaSprzedazy
        public IHttpActionResult GetFinFakturaSprzedazy()
        {
            var dateRange = Pomocne.DateHelpful.DateRangeOstKwartal();
            var result = this.FakturaSprzedazyDateRane(dateRange);
            return Ok(new { info = $"Filtr dla pola: 'dataWystawienia' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result });
        }

        // GET: api/FinFakturaSprzedazy/5
        [ResponseType(typeof(FinFakturaZakupu))]
        public IHttpActionResult GetFinFakturaSprzedazy(int id)
        {
            var fv = db.FinFakturaSprzedazy.Find(id);
            if (fv == null)
            {
                return BadRequest($"Nie znaleziono rekordu o id: {id}");
            }

            var result = db.FinFakturaSprzedazy.Where(w => w.FinFakturaSprzedazyId == id).Select(s => new FakturaSprzedazyDTO
            {
                BaseFakturaId = s.BaseFakturaSprzedazyId.HasValue ? s.BaseFakturaSprzedazyId.Value : 0,
                CzyDodatkoweInfo = (s.DodatkoweInfo.Colli.HasValue || s.DodatkoweInfo.KontrahentDealerAdresDostawyRefId.HasValue || s.DodatkoweInfo.WagaNetto.HasValue) ? true : false,
                CreatedBy = s.CreatedBy,
                CreatedDateTime = s.CreatedDateTime,
                CzyAktywna=s.CzyAktywna,
                CzyKorekta = s.CzyKorekta,
                DodatkoweInfo = new FakturaSprzedazyDodatkoweInfoDTO {
                    CzyAdresDostawy = s.DodatkoweInfo.KontrahentDealerAdresDostawyRefId.HasValue,
                    CzyColli = s.DodatkoweInfo.Colli.HasValue,
                    CzyWaga = s.DodatkoweInfo.WagaNetto.HasValue,
                    AdresDostawy = s.DodatkoweInfo.KontrahentDealerAdresDostawyRefId.HasValue ? new KontrahentDealerInfoDTO {
                        KontrahentDealer = s.DodatkoweInfo.KontrahentDealerAdresDostawy,
                        KontrahentDealerId = s.DodatkoweInfo.KontrahentDealerAdresDostawy.Id
                    } : null,
                    Colli = s.DodatkoweInfo.Colli.HasValue ? s.DodatkoweInfo.Colli.Value : 0,
                    WagaNetto = s.DodatkoweInfo.WagaNetto.HasValue ? s.DodatkoweInfo.WagaNetto.Value : 0,
                    WagaBrutto = s.DodatkoweInfo.WagaBrutto.HasValue ? s.DodatkoweInfo.WagaBrutto.Value : 0
                },
                DataWystawienia = s.DataWystawienia,
                FakturaSprzedazyId = s.FinFakturaSprzedazyId,
                FakturaPozycje = s.FakturaPozycje.Select(f => new FakturaSprzedazyPozycjaDTO {
                    FakturaSprzedazyPozycjaId = f.FinFakturaSprzedazyPozycjaId,
                    CzyPozMag = f.CzyPozMag,
                    Nazwa = f.Nazwa,
                    PodatekStawka = new PodatekStawkaDTO {
                        JednPodatekStawkaId = f.PodatekStawka.JednPodatekStawkaId,
                        Nazwa = f.PodatekStawka.Nazwa,
                        Wartosc = f.PodatekStawka.Wartosc,
                        Uwagi = f.PodatekStawka.Uwagi
                    },
                    PozMagId = f.CzyPozMag ? f.PozycjaMagazynowa.MagPozycjaMagazynowaId : 0,
                    Status = "baza",
                    Ilosc = f.Ilosc,
                    WartoscJedn = f.WartoscJedn,
                }).ToList(),
                MagWzIds = s.MagWz.Select(mg => mg.MagWzId).ToList(),
                Nabywca = new KontrahentInfoDTO {
                    Kontrahent = s.Nabywca,
                    KontrahentId = s.Nabywca.KontrahentId
                },
                NumerDokumentu = s.NumerDokumentu,
                Platnosc = new FakturaSprzedazyPlatnoscDTO {
                    IleDni = s.Platnosc.PlatnoscRodzaj.CzyDni ? s.Platnosc.IleDni.Value : 0,
                    Uwagi = s.Platnosc.PlatnoscRodzaj.CzyUwagi ? s.Platnosc.Uwagi : null,
                    PlatnoscRodzaj = s.Platnosc.PlatnoscRodzaj
                },
                RazemBrutto = s.RazemBrutto,
                RazemNetto = s.RazemNetto,
                RazemPodatek = s.RazemPodatek,
                Sprzedawca = new KontrahentInfoDTO {
                    Kontrahent = s.Sprzedawca,
                    KontrahentId = s.Sprzedawca.KontrahentId
                },
                Status = "baza",
                Uwagi = s.Uwagi,
                Waluta = new WalutaDTO {
                    Nazwa = s.Waluta.Nazwa,
                    Skrot = s.Waluta.Skrot,
                    WalutaId = s.Waluta.FinWalutaId
                }

            }).FirstOrDefault();


            var magWz = db.MagWz.WhereIn(wi => wi.MagWzId, result.MagWzIds)
                .Select(s => new MagWzNiezafakturowaneDTO
                {
                    MagWzId = s.MagWzId,
                    CzyPozMag = s.MagWzPozycjaPozMag.Count > 0 ? true : false,
                    BasicInfo = new MagWzBasicInfoDTO
                    {
                        MagWzId = s.MagWzId,
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
                        MaterialNazwa = sz.Zamowienie.ZamowienieKombi.FirstOrDefault().ZamowienieObszycie.FirstOrDefault().Material.Nazwa,
                        NormaNazwa = sz.Zamowienie.Norma.Nazwa,
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
                            Waga = (double?)szk.Kombinacja.Waga ?? 0
                        }).ToList(),
                        Reference = sz.Zamowienie.Reference,
                        ZamowienieNr = sz.Zamowienie.ZamowienieNr,
                        ZamowienieId = sz.ZamowienieRefId
                    }).ToList(),
                    PozycjeMagazynowe = s.MagWzPozycjaPozMag.Select(pzmag => new MagWzPozycjeMagazynoweDTO
                    {
                        Ilosc = pzmag.Ilosc,
                        Jednostka = pzmag.PozycjaMagazynowa.JednostkaMiary.Nazwa,
                        Nazwa = pzmag.PozycjaMagazynowa.Nazwa,
                        PodatekStawka = new PodatekStawkaDTO
                        {
                            JednPodatekStawkaId = pzmag.PozycjaMagazynowa.VatSprzedazy.JednPodatekStawkaId,
                            Nazwa = pzmag.PozycjaMagazynowa.VatSprzedazy.Nazwa,
                            Wartosc = pzmag.PozycjaMagazynowa.VatSprzedazy.Wartosc
                        },
                        PozycjaMagazynowaId = pzmag.PozycjaMagazynowaRefId,
                        Uwagi = pzmag.PozycjaMagazynowa.Uwagi,
                        UniqueKey = pzmag.PozycjaMagazynowaRefId.ToString(),
                    }).ToList()
                }).OrderByDescending(o => o.MagWzId).ToList();


            //korekta...
            if (result.BaseFakturaId > 0) {

                var zmiany = db.FinFakturaSprzedazyPozycja.Where(w => w.FakturaSprzedazyZmianyRefId == id).Select(f => new FakturaSprzedazyPozycjaDTO
                {
                    FakturaSprzedazyPozycjaId = f.FinFakturaSprzedazyPozycjaId,
                    FakturaSprzedazyPozycjaOrygRef=f.FakturaSprzedazyPozycjaOrygRef,
                    CzyPozMag = f.CzyPozMag,
                    Nazwa = f.Nazwa,
                    PodatekStawka = new PodatekStawkaDTO
                    {
                        JednPodatekStawkaId = f.PodatekStawka.JednPodatekStawkaId,
                        Nazwa = f.PodatekStawka.Nazwa,
                        Wartosc = f.PodatekStawka.Wartosc,
                        Uwagi = f.PodatekStawka.Uwagi
                    },
//                    PozMagId = f.CzyPozMag ? f.PozycjaMagazynowa.MagPozycjaMagazynowaId : 0,
                    Status = "baza",
                    Ilosc = f.Ilosc,
                    WartoscJedn = f.WartoscJedn,
                }).ToList();


                //var przed = db.FinFakturaSprzedazyPozycja.WhereIn(wi => wi.FinFakturaSprzedazyPozycjaId, zmiany.Select(s => s.FakturaSprzedazyPozycjaOrygRef).ToList()).Select(f => new FakturaSprzedazyPozycjaDTO
                //{
                //    FakturaSprzedazyPozycjaId = f.FinFakturaSprzedazyPozycjaId,
                //    FakturaSprzedazyPozycjaOrygRef = f.FakturaSprzedazyPozycjaOrygRef,
                //    CzyPozMag = f.CzyPozMag,
                //    Nazwa = f.Nazwa,
                //    PodatekStawka = new PodatekStawkaDTO
                //    {
                //        JednPodatekStawkaId = f.PodatekStawka.JednPodatekStawkaId,
                //        Nazwa = f.PodatekStawka.Nazwa,
                //        Wartosc = f.PodatekStawka.Wartosc,
                //        Uwagi = f.PodatekStawka.Uwagi
                //    },
                //    //                    PozMagId = f.CzyPozMag ? f.PozycjaMagazynowa.MagPozycjaMagazynowaId : 0,
                //    Status = "baza",
                //    Ilosc = f.Ilosc,
                //    WartoscJedn = f.WartoscJedn,
                //}).ToList();
                result.FakturaPozycjeZmiany = zmiany;
            }

            result.MagWzWybrane = magWz;

            
            return Ok(result);
        }

        public IHttpActionResult PutFinFakturaSprzedazy(int id, FakturaSprzedazyDTO fvDTO)
        {
            if (!ModelState.IsValid) {
                return BadRequest("Przesłane dane są nieprawidłowe");
            }
            if (fvDTO.BaseFakturaId > 0 && fvDTO.CzyKorekta)
            {
                return BadRequest("Nie można modyfikować zapisanej korekty, można jedynie ją usunąć..");
            }
            var fNew = (id == 0 || fvDTO.CzyKorekta) ? new FinFakturaSprzedazy() : db.FinFakturaSprzedazy.Include(i => i.Platnosc).Where(w => w.FinFakturaSprzedazyId == id).Select(s => s).FirstOrDefault();
            if (id > 0 && fNew == null) { return BadRequest($"Nie znaleziono rekordu o Id: {id}");};

            var numeryDokumentow = db.FinFakturaSprzedazy.Select(sg => new Finanse.NumeryDokumentowDTO.NumerDokumentuDTO
            {
                CzyKorekta = sg.CzyKorekta,
                NumerDokumentu = sg.NumerDokumentu
            }).GroupBy(g => g.CzyKorekta).Select(s => new
            {
                CzyKorekta = s.Key,
                NumerDokumentu = s.Select(n => n.NumerDokumentu).ToList()
            }).ToList();

            var magWzIds = new List<MagWZ.MagWz>();
            var magWzIdsUsuniete = new List<MagWZ.MagWz>();

            var numeryDokumentowKorekty = numeryDokumentow.Where(w => w.CzyKorekta).Select(s => s.NumerDokumentu).FirstOrDefault();
            var numeryDokumentowOryg = numeryDokumentow.Where(w => !w.CzyKorekta).Select(s => s.NumerDokumentu).FirstOrDefault();

            var stawkiPodatku = db.JednPodatekStawka.Select(s => s).ToList();

            fNew.BaseFakturaSprzedazyId = fvDTO.CzyKorekta ? id : (int?)null;
            fNew.CreatedBy = fvDTO.CreatedBy;
            fNew.CreatedDateTime = DateTime.Now;
            fNew.CzyDodatkoweInfo = fvDTO.DodatkoweInfo.CzyAdresDostawy || fvDTO.DodatkoweInfo.CzyColli || fvDTO.DodatkoweInfo.CzyWaga ? true : false;
            fNew.DataWystawienia = fvDTO.DataWystawienia;
            fNew.MagWzIds = fvDTO.MagWzWybrane.Count==0? null: String.Join(",", fvDTO.MagWzIds);
            fNew.NabywcaRefId = fvDTO.Nabywca.KontrahentId;
            //razem netto/brutto/podatek = zlicze na koncu
            fNew.SprzedawcaRefId = fvDTO.Sprzedawca.KontrahentId;
            fNew.Uwagi = fvDTO.Uwagi;
            fNew.WalutaRefId = fvDTO.Waluta.WalutaId;

            var platnosc = (id == 0 || fvDTO.CzyKorekta) ? new FinFakturaSprzedazyPlatnosc() : fNew.Platnosc;

            platnosc.IleDni = fvDTO.Platnosc.PlatnoscRodzaj.CzyDni ? fvDTO.Platnosc.IleDni : (int?)null;
            platnosc.Uwagi = fvDTO.Platnosc.PlatnoscRodzaj.CzyUwagi ? fvDTO.Platnosc.Uwagi : null;
            platnosc.PlatnoscRodzajRefId = fvDTO.Platnosc.PlatnoscRodzaj.JednPlatnoscRodzajId;


            var dodatkoweInfo = (id == 0 || fvDTO.CzyKorekta) ? new FinFakturaSprzedazyDodatkoweInfo(): db.FinFakturaSprzedazyDodatkoweInfo.Find(id);
            var dodatkoweInfoBaza = dodatkoweInfo != null && id>0 ? true : false;
            if (fvDTO.CzyDodatkoweInfo)
            {
                if (!dodatkoweInfoBaza)
                {
                    dodatkoweInfo = new FinFakturaSprzedazyDodatkoweInfo();
                }

//                db.Entry(dodatkoweInfo).State = dodatkoweInfoBaza ? EntityState.Modified : EntityState.Added;
                dodatkoweInfo.Colli = (fvDTO.DodatkoweInfo.CzyColli) ? fvDTO.DodatkoweInfo.Colli : (int?)null;
                dodatkoweInfo.KontrahentDealerAdresDostawyRefId = fvDTO.DodatkoweInfo.CzyAdresDostawy ? fvDTO.DodatkoweInfo.AdresDostawy.KontrahentDealerId : (int?)null;
                dodatkoweInfo.WagaBrutto = fvDTO.DodatkoweInfo.CzyWaga? fvDTO.DodatkoweInfo.WagaBrutto : (double?)null;
                dodatkoweInfo.WagaNetto = fvDTO.DodatkoweInfo.CzyWaga ? fvDTO.DodatkoweInfo.WagaNetto : (double?)null;
                dodatkoweInfo.FakturaSprzedazy = fNew;
                
            }
            else {
                if (dodatkoweInfoBaza)
                {
                    //db.Entry(dodatkoweInfo).State = EntityState.Deleted;
                    db.FinFakturaSprzedazyDodatkoweInfo.Remove(dodatkoweInfo);
                    fNew.DodatkoweInfo = null;
                    fNew.CzyDodatkoweInfo = false;                  
                }
            }

            fNew.DodatkoweInfo = fvDTO.CzyDodatkoweInfo ? dodatkoweInfo : null;


            if (fvDTO.MagWzIds.Count > 0)
            {
                magWzIds = db.MagWz.WhereIn(wi => wi.MagWzId, fvDTO.MagWzIds).Select(s => s).ToList();
                foreach (var wz in magWzIds)
                {
                    wz.CzyZaksiegowana = true;
                    wz.FakturaSprzedazy = fNew;
                    db.Entry(wz).State = EntityState.Modified;
                }
            }

            if (fvDTO.MagWzIdsUsuniete.Count > 0)
            {
                magWzIdsUsuniete = db.MagWz.Include(i=>i.MagWzPozycjaPozMag).WhereIn(wi => wi.MagWzId, fvDTO.MagWzIdsUsuniete).Select(s => s).ToList();
                foreach (var wz in magWzIdsUsuniete)
                {
                    wz.CzyZaksiegowana = false;
                    wz.FinFakturaSprzedazyRefId = null;
                    db.Entry(wz).State = EntityState.Modified;
                }

            }

            var pozMagIds = magWzIdsUsuniete.SelectMany(sm => sm.MagWzPozycjaPozMag).Select(s => s.PozycjaMagazynowaRefId).Distinct().ToList();

            foreach (var poz in fvDTO.FakturaPozycje)
            {

                if (poz.WartoscJedn==0 || poz.Ilosc == 0 || poz.PodatekStawka==null) {
                    return BadRequest($"W pozycji '{poz.Nazwa}' ilość, wartość jednostkowa wynosi 0 lub nie określono stawki podatku, nie można zapisać takich danych");
                }

                var pBaza = (poz.Status == "zmieniony" || poz.Status == "usuniety") ? db.FinFakturaSprzedazyPozycja.Find(poz.FakturaSprzedazyPozycjaId) : new FinFakturaSprzedazyPozycja();

                if (pozMagIds.Any(a => a == poz.PozMagId)) {
                    db.Entry(pBaza).State = EntityState.Deleted;
                }
                else {
                    pBaza.CzyPozMag = poz.CzyPozMag;
                    pBaza.Ilosc = poz.Ilosc;
                    pBaza.Nazwa = poz.Nazwa;
                    pBaza.PodatekStawkaRefId = poz.PodatekStawka.JednPodatekStawkaId;
                    pBaza.WartoscJedn = poz.WartoscJedn;
                    if (poz.CzyPozMag && poz.PozMagId>0) {
                        pBaza.PozycjaMagazynowaRefId = poz.PozMagId;
                    }
                    if (poz.Status == "nowy") { fNew.FakturaPozycje.Add(pBaza); }
                    if (poz.Status == "zmieniony") { db.Entry(pBaza).State = EntityState.Modified; }
                    if (poz.Status == "usuniety") { db.Entry(pBaza).State = EntityState.Deleted;}
                }
            }

            if (fvDTO.CzyKorekta) {
                if (fvDTO.FakturaPozycjeZmiany.Count == 0) {
                    return BadRequest("Zapis anulowano ponieważ tworzona korekta nie zawiera zmian");
                }
                foreach (var poz in fvDTO.FakturaPozycjeZmiany)
                {

                    var pBaza = new FinFakturaSprzedazyPozycja();
                    pBaza.CzyKorekta = true;
                    pBaza.CzyPozMag = poz.CzyPozMag;
                    pBaza.Ilosc = poz.Ilosc;
                    pBaza.Nazwa = poz.Nazwa;
                    pBaza.FakturaSprzedazyPozycjaOrygRef = poz.FakturaSprzedazyPozycjaOrygRef;
                    pBaza.PodatekStawkaRefId = poz.PodatekStawka.JednPodatekStawkaId;
                    pBaza.WartoscJedn = poz.WartoscJedn;
                    fNew.FakturaPozycjeZmiany.Add(pBaza);
                }

            }


           

            var netto = fNew.FakturaPozycje.Sum(s => (s.WartoscJedn*s.Ilosc));
            var podatek = fNew.FakturaPozycje.Sum(s => ( stawkiPodatku.Where(w=>w.JednPodatekStawkaId==s.PodatekStawkaRefId).Select(sp=>sp.Wartosc).FirstOrDefault() * s.Ilosc* s.WartoscJedn));
            fNew.RazemBrutto = netto + podatek;
            fNew.RazemNetto = netto;
            fNew.RazemPodatek = podatek;


            if (id == 0)
            {
                fNew.CzyAktywna = true;
                fNew.NumerDokumentu= Pomocne.DocumentNumbers.DocNumbersMethods.NextDocNumberShort(numeryDokumentowOryg, fvDTO.DataWystawienia).NumerDokumentuFullName;
                fNew.Platnosc = platnosc;

                db.Entry(fNew).State = EntityState.Added;
            }

            if (id > 0 && !fvDTO.CzyKorekta)
            {
                    db.Entry(platnosc).State = EntityState.Modified;
                    db.Entry(fNew).State = EntityState.Modified;

            }

            if (fvDTO.CzyKorekta) {
                fNew.CzyAktywna = true;
                fNew.CzyKorekta = true;
                fNew.NumerDokumentu = Pomocne.DocumentNumbers.DocNumbersMethods.NextDocNumberShort(numeryDokumentowKorekty, fvDTO.DataWystawienia, '/', "KOR").NumerDokumentuFullName;
                fNew.Platnosc = platnosc;
                
                db.Entry(fNew).State = EntityState.Added;
                var oryg = db.FinFakturaSprzedazy.Find(id);
                if (oryg != null)
                {
                    oryg.CzyAktywna = false;
                    db.Entry(oryg).State = EntityState.Modified;
                }
                else
                {
                    return BadRequest($"Błąd przy aktualizacji danych fakturyBazowej, nie znaleziono FV o Id {id}");
                }
            }






            db.SaveChanges();

            return Ok(new { info=$"Dane zostały prawidłowo zapisane w bazie pod ID: {fNew.FinFakturaSprzedazyId}"});
        }



        [HttpPost]
        [Route("api/finFakturaSprzedazy/dateRange")]
        public IHttpActionResult PostFakturaSprzedazyDateRange(DateRangeDTO dateRange)
        {
            var result = FakturaSprzedazyDateRane(dateRange);


            return Ok(new { info = $"Filtr dla pola: 'dataWystawienia' dla zakresu od {dateRange.DateStart.ToShortDateString()} do {dateRange.DateEnd.ToShortDateString()}", result });
        }




        public List<FakturaSprzedazyListaDTO> FakturaSprzedazyDateRane(DateRangeDTO dateRange)
        {
            var result = db.FinFakturaSprzedazy.Where(w => w.CzyAktywna && w.DataWystawienia >= dateRange.DateStart && w.DataWystawienia <= dateRange.DateEnd).Select(s => new FakturaSprzedazyListaDTO
            {
                CreatedBy=s.CreatedBy,
                CreatedDateTime=s.CreatedDateTime,
                CzyKorekta=s.CzyKorekta,
                DataWystawienia = s.DataWystawienia,
                FakturaSprzedazyId = s.FinFakturaSprzedazyId,
                Nabywca = new KontrahentInfoDTO
                {
                    Kontrahent = s.Nabywca,
                    KontrahentId = s.Nabywca.KontrahentId
                },
                NumerDokumentu=s.NumerDokumentu,
                RazemBrutto = s.RazemBrutto,
                RazemNetto = s.RazemNetto,
                RazemPodatek = s.RazemPodatek,
                WalutaSkrot = s.Waluta.Nazwa,
                Uwagi = s.Uwagi

            }).ToList();

            return result;
        }

        [HttpPost]
        [Route("api/finFakturaSprzedazy/pdfGenFv")]
        public HttpResponseMessage PostGenFv(FakturaSprzedazyDTO fv)
        {

            

            var kontr = db.Kontrahent
                .Include(i=>i.KontrahentDealerzy)
                .Include(i=>i.KontrahentPlatnosc)
                .Include(i=>i.KontrahentPlatnosc.PlatnoscRodzaj)
                .WhereIn(w => w.KontrahentId, new int[] { fv.Sprzedawca.KontrahentId, fv.Nabywca.KontrahentId }).Select(s => s).ToList();
            var ms = Pomocne.PdfGen.PdfGen.FakturaSprzedazy(fv , kontr);

            HttpResponseMessage result = new HttpResponseMessage();
            result.StatusCode = HttpStatusCode.OK;
            result.Content = new ByteArrayContent(ms.GetBuffer());
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachement")
            {
                FileName = $"pdfTest.pdf",
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return result;
        }


        // DELETE: api/FinFakturaSprzedazy/5
        [ResponseType(typeof(FinFakturaZakupu))]
        public IHttpActionResult DeleteFinFakturaZakupu(int id)
        {

            var fv = db.FinFakturaSprzedazy
                .Include(i => i.FakturaPozycje)
                .Include(im=>im.MagWz)
                .Include(idi=>idi.DodatkoweInfo)
                .Where(w => w.FinFakturaSprzedazyId == id).Select(s => s).FirstOrDefault();

            if (fv == null) {
                return BadRequest($"Nie znaleziono FV o id {id}");
            }

            if (!fv.CzyKorekta)
            {
                foreach (var wz in fv.MagWz.ToList())
                {
                    wz.FinFakturaSprzedazyRefId = null;
                    wz.CzyZaksiegowana = false;
                    db.Entry(wz).State = EntityState.Modified;
                }
                if (fv.DodatkoweInfo != null)
                {
                    db.FinFakturaSprzedazyDodatkoweInfo.Remove(fv.DodatkoweInfo);
                }
                db.FinFakturaSprzedazyPozycja.RemoveRange(fv.FakturaPozycje);
                db.Entry(fv).State = EntityState.Deleted;
            }
            else {
                var oryg = db.FinFakturaSprzedazy.Find(fv.BaseFakturaSprzedazyId);
                if (oryg == null)
                {


                    return BadRequest("Nie znaleziono faktury bazowej, anulowano zapis do bazy");
                }
                else {
                    fv.CzyAktywna = false;
                    oryg.CzyAktywna = true;

                    if (!string.IsNullOrWhiteSpace(fv.MagWzIds))
                    {
                        var magWzIds = fv.MagWzIds.Split(',');
                        var magWzIdsList = new List<int>();
                        foreach (var i in magWzIds)
                        {
                            int number;
                            var res = Int32.TryParse(i, out number);
                            magWzIdsList.Add(number);
                        }

                        if (magWzIdsList.Count > 0)
                        {
                            var magWz = db.MagWz.WhereIn(wi => wi.MagWzId, magWzIdsList).Select(s => s);
                            foreach (var wz in magWz)
                            {
                                wz.FinFakturaSprzedazyRefId = oryg.FinFakturaSprzedazyId;
                                db.Entry(wz).State = EntityState.Modified;
                            }
                        }
                    }
                    
                }
            }
            var info = fv.CzyKorekta ? $"Faktura korekta o Id {id} została usunięta. Bazowy dokument o Id: {fv.BaseFakturaSprzedazyId} został przywrócony jako aktywny" :
                $"FakturaSprzedaży o ID: {id} została usunięta z bazy danych";

            db.SaveChanges();

            return Ok(new { info=info, baseFakturaId=fv.BaseFakturaSprzedazyId});
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
    }
}