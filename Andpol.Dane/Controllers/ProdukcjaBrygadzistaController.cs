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

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles = "Brygadzista")]
    [EnableCors("*", "*", "*")]

    public class ProdukcjaBrygadzistaController : ApiController
    {

        private PoligonContext db = new PoligonContext();


        // POST: api/ProdukcjaBrygadzista
        [HttpPost]
        [Route("api/ProdukcjaBrygadzista/Zaplanowane")]
        public IHttpActionResult PostProdukcjaBrygadzistaZaplanowane (ProdukcjaBrygadzistaZaplanowaneInputDTO reqDTO)
        {

            var brygadzista = db.ProdukcjaBrygadzista.Include(i=>i.ProdukcjaDzial).Where(w => w.UserName == reqDTO.UserName).Select(s => s).ToList();
            if (brygadzista.Count == 0) {
                return BadRequest("Nie jesteś brygadzistą, więc czego oczekujesz ?");
            }
            
            var result = new List<ProdukcjaBrygadzistaZaplanowaneDTO>();

            var zamowienieKombi = db.PlanningDzienRoboczyZamowienieKombi
                .Where(w => w.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.KalendarzDniRoboczych.DzienRoboczy==DbFunctions.CreateDateTime(reqDTO.DzienRoboczy.Year, reqDTO.DzienRoboczy.Month,reqDTO.DzienRoboczy.Day,9,0,0))
                .Select(s => new PlanningZamowienieKombiInfo()
                {
                    PlanningDzienRoboczyZamowienieKombiId=s.PlanningDzienRoboczyZamowienieKombiId,
                    IsDone = s.IsDone,
                    Nazwa = s.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa,
                    ProdukcjaDzial=new ProdukcjaDzialDTO() {
                        CzyTkaninaBelka= s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.CzyTkaninaBelka,
                        Nazwa = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.Nazwa,
                        ProdukcjaDzialId= s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProd.ProdukcjaDzial.ProdukcjaDzialId
                    }, 
                    Zamowienie = new ZamowienieInfoDTO()
                    {
                        Commission = s.ZamowienieKombi.Zamowienie.Commission,
                        Reference = s.ZamowienieKombi.Zamowienie.Reference,
                        ZamowienieNr = s.ZamowienieKombi.Zamowienie.ZamowienieNr,
                        ZamowienieId = s.ZamowienieKombi.Zamowienie.Id,
                    },
                    KalendarzDniRoboczychDzialProdRefId = s.PlanningDzienRoboczy.KalendarzDniRoboczychDzialProdRefId,
                    Status="baza"
                }).ToList();



            foreach (var item in brygadzista)
            {
                result.Add(new ProdukcjaBrygadzistaZaplanowaneDTO()
                {
                    ProdukcjaDzial = new ProdukcjaDzialDTO()
                    {
                        CzyTkaninaBelka=item.ProdukcjaDzial.CzyTkaninaBelka,
                        Nazwa = item.ProdukcjaDzial.Nazwa,
                        ProdukcjaDzialId = item.ProdukcjaDzial.ProdukcjaDzialId
                    },
                    PlanningZamowienieKombiInfo = zamowienieKombi.Where(w => w.ProdukcjaDzial.ProdukcjaDzialId == item.ProdukcjaDzial.ProdukcjaDzialId).Select(s => s).ToList()

                });
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("api/ProdukcjaBrygadzista/Update")]
        public IHttpActionResult PostProdukcjaBrygadzistaUpdate(List<ProdukcjaBrygadzistaZaplanowaneDTO> reqDTO)
        {
            //var produkcjaDzial = reqDTO.FirstOrDefault().ProdukcjaDzial;
            //if (produkcjaDzial.CzyTkaninaBelka == true) {
            //    return BadRequest($"Do aktualizacji pozycji dla działu {produkcjaDzial.Nazwa} powinna być aktualizowana w widoku 'Tkaniny'");
            //}

            var brygadzista = db.ProdukcjaBrygadzista.Where(w => w.UserName == User.Identity.Name).FirstOrDefault();
            string dodatkoweInfo = "";

            int poprawione = 0;
            foreach (var dzial in reqDTO)
            {
                bool czyTkaninaBelka = false;
                foreach (var zam in dzial.PlanningZamowienieKombiInfo)
                {
                    if (zam.Status == "zmieniony") {

                        if (dzial.ProdukcjaDzial.CzyTkaninaBelka==true)
                        {
                            czyTkaninaBelka = true;
                        }
                        else
                        {
                            var zamInDb = db.PlanningDzienRoboczyZamowienieKombi.Find(zam.PlanningDzienRoboczyZamowienieKombiId);
                            if (zamInDb != null)
                            {
                                zamInDb.IsDone = zam.IsDone;
                                zamInDb.BrygadzistaNazwa = brygadzista.UserName;
                                poprawione++;
                            }
                        }
                    }
                }
                if (czyTkaninaBelka == true) {
                    dodatkoweInfo += $", {dzial.ProdukcjaDzial.Nazwa} nie może być aktualizowany w tym widoku..";
                }
            }

            db.SaveChanges();
            var result = "asdfas";

            return Ok(new { info= $"Dane zaktualizowane. Poprawiono: {poprawione}{dodatkoweInfo}", result=result});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}