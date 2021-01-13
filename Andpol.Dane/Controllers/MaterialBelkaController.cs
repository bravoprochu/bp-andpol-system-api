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

namespace Andpol.Dane.Pomocne
{
    [Authorize(Roles ="TkaninyBelki, FinanseFaktury")]
    [EnableCors("*", "*", "*")]

    public class MaterialBelkaController : ApiController
    {
        private PoligonContext db = new PoligonContext();

        // GET: api/MaterialBelka
        public IHttpActionResult GetMaterialBelka()
        {

            //var result = (from mb in db.MaterialBelka.Include(i => i.PlanningMaterialBelka).Include(i2 => i2.MaterialBelkaRozchodInne).Include(ip => ip.PlanningMaterialBelka)
            var result = (from mb in db.MaterialBelka.Include(i2 => i2.MaterialBelkaRozchodInne)
                          select new
                          {
                              Id = mb.MaterialBelkaId,
                              CreatedBy = mb.CreatedBy,
                              CreatedDateTime = mb.CreatedDateTime,
                              CzyAktywna = mb.CzyAktywna,
                              CzyPotwierdzona=mb.CzyPotwierdzona,
                              CzyPowierzona=mb.CzyPowierzona,
                              Nazwa = mb.Material.Nazwa,
                              MaterialGrupaKontrahentNazwa = mb.Material.MaterialGrupa.Nazwa,
                              OznaczenieWewnetrzne = mb.OznaczenieWewnetrzne,
                              StanAktualny = mb.StanAktualny,
                              StanPoczatkowy = mb.StanPoczatkowy,
                              StanRzeczywisty = mb.StanRzeczywisty,
                              DataPrzyjecia = mb.DataPrzyjecia,
                              Faktura = mb.DokumentZrodlowyNr,
                              RozchodInne = mb.MaterialBelkaRozchodInne.Sum(si => (double?)si.Wartosc) ?? 0,
                              RozchodInneTwo = (from mbri in db.MaterialBelkaRozchodInne where mbri.MaterialBelkaRefId == mb.MaterialBelkaId group mbri by mbri.MaterialBelkaRefId into rozchodInneGroup select new {
                                  Wartosc = rozchodInneGroup.Sum(x => x.Wartosc)
                              }),

                          }).ToList().OrderBy(o => o.Nazwa);

            return Ok(result);
        }

        // GET: api/MaterialBelka/5
        public IHttpActionResult GetMaterialBelka(int id)
        {

            if (db.MaterialBelka.Find(id) == null) {
                return BadRequest("Nie ma takiego rekordu");
            }

            var result = (from mb in db.MaterialBelka
                          where mb.MaterialBelkaId == id
                          let sumaRozchodInne = mb.MaterialBelkaRozchodInne.Count > 0 ? mb.MaterialBelkaRozchodInne.Sum(s => s.Wartosc) : 0
                          select new
                          {
                              CreatedBy = mb.CreatedBy,
                              CreatedDateTime = mb.CreatedDateTime,
                              CzyAktywna = mb.CzyAktywna,
                              CzyPotwierdzona = mb.CzyPotwierdzona,
                              CzyPowierzona = mb.CzyPowierzona,
                              DataPrzyjecia = mb.DataPrzyjecia,
                              FakturaNr = mb.DokumentZrodlowyNr,
                              Id = mb.MaterialBelkaId,
                              Material = new MaterialDTO()
                              {
                                  CzyUtrudnienie = mb.Material.CzyUtrudnienie,
                                  MaterialGrupaKontrahent = new MaterialGrupaKontrahentDTO()
                                  {
                                      MaterialGrupaKontrahentId = mb.Material.MaterialGrupa.MaterialGrupaKontrahentId,
                                      Nazwa = mb.Material.MaterialGrupa.Kontrahent.Nazwa,
                                      Uwagi = mb.Material.MaterialGrupa.Uwagi
                                  },
                                  MaterialId = mb.Material.MaterialId,
                                  Nazwa = mb.Material.Nazwa,
                                  SzerokoscBelki = mb.Material.SzerokoscBelki
                              },
                              Nazwa = mb.Material.Nazwa,
                              OznaczenieWewnetrzne = mb.OznaczenieWewnetrzne,
                              //Planning = mb.PlanningMaterialBelka.Select(pi => new
                              //{
                              //    Id = pi.PlanningMaterial.Planning.Id,
                              //    ProdukcjaEnd = pi.PlanningMaterial.Planning.ProdukcjaEnd,
                              //    ProdukcjaStart = pi.PlanningMaterial.Planning.ProdukcjaStart,
                              //    ListaObszyc = pi.ListaObszyc.Select(l => new PlanningMaterialBelkaObszycieDTO()
                              //    {
                              //        Id = l.ZamowienieKombiObszycieId,
                              //        Dlugosc = l.KombinacjeObszycie.Dlugosc,
                              //        Name = l.ZamowienieKombi.Zamowienie.ZamowienieNr + ", [" + l.ZamowienieKombi.Kombinacja.NazwaKombinacji.Nazwa + " (" + l.ZamowienieKombiRefId + ")]" + l.KombinacjeObszycie.Obszycie.Nazwa,
                              //        Szerokosc = l.KombinacjeObszycie.Szerokosc,
                              //    }).ToList(),

                              //    UwagiPlanning = pi.PlanningMaterial.Planning.Uwagi


                              //}).ToList(),
                              StanAktualny = mb.StanAktualny,
                              //StanPlanning = mb.PlanningMaterialBelka.Sum(sp => (double?)sp.ZuzycieWartosc) ?? 0,
                              StanPoczatkowy = mb.StanPoczatkowy,
                              StanRzeczywisty = mb.StanRzeczywisty,
                              Status = "baza",
                              Uwagi = mb.Uwagi,
                              RozchodInne = mb.MaterialBelkaRozchodInne.Select(mbri => new MaterialBelkaRozchodInneDTO()
                              {
                                  Id = mbri.Id,
                                  CreatedBy = mbri.CreatedBy,
                                  CreatedDateTime = mbri.CreatedDateTime,
                                  DataRozchodu = mbri.DataRozchodu,
                                  MaterialBelkaId = mbri.MaterialBelkaRefId,
                                  RozchodMagRodzaj = mbri.RozchodMagRodzaj,
                                  Status = "baza",
                                  Uwagi = mbri.Uwagi,
                                  Wartosc = mbri.Wartosc
                              }).OrderBy(o => o.DataRozchodu).ToList(),
                          });

            return Ok(result);
        }

        // PUT: api/MaterialBelka/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterialBelka(int id, MaterialBelkaDTO mbDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mbDTO.Id == 0)
            {
                MaterialBelka mbNew = new MaterialBelka();
                mbNew.CreatedBy = mbDTO.CreatedBy;
                mbNew.CreatedDateTime = DateTime.Now;
                mbNew.CzyAktywna = mbDTO.CzyAktywna;
                mbNew.DataPrzyjecia = mbDTO.DataPrzyjecia;
                mbNew.DokumentZrodlowyNr = mbDTO.FakturaNr;
                mbNew.Material = db.Material.Find(mbDTO.Material.MaterialId);
                mbNew.OznaczenieWewnetrzne = mbDTO.OznaczenieWewnetrzne;

                mbNew.StanAktualny = mbDTO.StanPoczatkowy;
                mbNew.StanPoczatkowy = mbDTO.StanPoczatkowy;
                mbNew.StanRzeczywisty = mbDTO.StanPoczatkowy;

                mbNew.Uwagi = mbDTO.Uwagi;
                

                db.MaterialBelka.Add(mbNew);
                db.SaveChanges();
                id = mbNew.MaterialBelkaId;
            } else {

                MaterialBelka mbMod = db.MaterialBelka.Find(id);
                double stanAktualny = mbMod.MaterialBelkaRozchodInne.Sum(s => s.Wartosc);
                if (mbDTO.Status == "zmieniony" && mbMod != null)
                {
                    //                    if (stanAktualny != mbDTO.StanAktualny) { return BadRequest("Podczas edycji, stan aktualny belki został zmieniony, pobierz aktualne dane"); }
                    if (mbMod.StanPoczatkowy != mbDTO.StanPoczatkowy) { return BadRequest("Gdy dodano już rozchód / zaplanowano obszycie, nie można zmienić stanu początkowego belki"); }

                    mbMod.CzyAktywna = mbDTO.CzyAktywna;
                    mbMod.DataPrzyjecia = mbDTO.DataPrzyjecia;
                    mbMod.DokumentZrodlowyNr = mbDTO.FakturaNr;
                    mbMod.MaterialRefId = mbDTO.Material.MaterialId;
                    mbMod.OznaczenieWewnetrzne = mbDTO.OznaczenieWewnetrzne;

                    mbMod.Uwagi = mbDTO.Uwagi;

                    if (mbMod.CzyPotwierdzona == true)
                    {
                        foreach (var ri in mbDTO.RozchodInne)
                        {
                            MaterialBelkaRozchodInne riMod = db.MaterialBelkaRozchodInne.Find(ri.Id);
                            if (ri.Status == "nowy")
                            {
                                db.MaterialBelkaRozchodInne.Add(new MaterialBelkaRozchodInne
                                {
                                    DataRozchodu = ri.DataRozchodu,
                                    MaterialBelkaRefId = id,
                                    Uwagi = ri.Uwagi,
                                    Wartosc = ri.Wartosc,
                                    CreatedBy = mbDTO.CreatedBy,
                                    CreatedDateTime = DateTime.Now,
                                    RozchodMagRodzajRefId = ri.RozchodMagRodzaj.JednRozchodMagRodzajId
                                });
                                mbMod.StanAktualny -= ri.Wartosc;
                                mbMod.StanRzeczywisty -= ri.Wartosc;
                            };

                        }
                    }


                }
            }

            //MaterialBelka mb = db.MaterialBelka.Find(id);
            //var rozchodInneSum = mb.MaterialBelkaRozchodInne.Count > 0 ? mb.MaterialBelkaRozchodInne.Sum(s => s.Wartosc) : 0;
            //mb.StanAktualny = mb.StanPoczatkowy - rozchodInneSum;



            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MaterialBelka
        [ResponseType(typeof(MaterialBelka))]
        public async Task<IHttpActionResult> PostMaterialBelka(MaterialBelka materialBelka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaterialBelka.Add(materialBelka);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = materialBelka.MaterialBelkaId }, materialBelka);
        }

        // DELETE: api/MaterialBelka/5
        [ResponseType(typeof(MaterialBelka))]
        public async Task<IHttpActionResult> DeleteMaterialBelka(int id)
        {

            MaterialBelka materialBelka = await db.MaterialBelka.FindAsync(id);
            if (materialBelka == null)
            {
                return NotFound();
            }

            var mbelka = (from mb in db.MaterialBelka
                          where mb.MaterialBelkaId == id
                          select new
                          {
                              CzyPotwierdzona=mb.CzyPotwierdzona,
                              //PlanningCount = mb.PlanningMaterialBelka.Count,
                              RozchodInneCount = mb.MaterialBelkaRozchodInne.Count
                          }).FirstOrDefault();

            //if (mbelka.PlanningCount > 0 || mbelka.RozchodInneCount > 0 || mbelka.CzyPotwierdzona==true ) {
            //    return BadRequest("Nie można usunąć Belki ponieważ są z nią związane relacje (rozchódInne, planning itp..)");
            //}



            db.LogsDelete.Add(new LogsDelete()
            {
                DataUsuniecia=DateTime.Now,
                Tabela="MaterialBelka",
                UserName=User.Identity.Name,
                Uwagi="DataPrzyjecia "+ materialBelka.DataPrzyjecia.ToShortDateString()+ " StanPoczatkowy: "+materialBelka.StanPoczatkowy.ToString("0.00")+" materialRefId: "+materialBelka.MaterialRefId+" FV: "+materialBelka.DokumentZrodlowyNr
            });


            db.MaterialBelka.Remove(materialBelka);
            await db.SaveChangesAsync();

            return Ok($"Usunięto MateriałBelka Id: {id}");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialBelkaExists(int id)
        {
            return db.MaterialBelka.Count((System.Linq.Expressions.Expression<Func<MaterialBelka, bool>>)(e => e.MaterialBelkaId == id)) > 0;
        }
        [HttpGet]
        [Route("api/materialBelka/DoPotwierdzenia")]
        public IHttpActionResult MaterialBelkaDoPotwierdzenia()
        {
            var result = (from mb in db.MaterialBelka
                          where mb.CzyAktywna == true && mb.CzyPotwierdzona == false
                          select new MaterialBelkaDTO()
                          {
                              CreatedBy=mb.CreatedBy,
                              CreatedDateTime=mb.CreatedDateTime,
                              FakturaNr=mb.DokumentZrodlowyNr,
                              DataPrzyjecia=mb.DataPrzyjecia,
                              Id=mb.MaterialBelkaId,
                              Material=new MaterialDTO {
                                  CzyUtrudnienie=mb.Material.CzyUtrudnienie,
                                  MaterialGrupaKontrahent= new MaterialGrupaKontrahentDTO() {
                                      MaterialGrupaKontrahentId= mb.Material.MaterialGrupa.MaterialGrupaKontrahentId,
                                      Nazwa= mb.Material.MaterialGrupa.Nazwa,
                                  },
                                  MaterialId= mb.Material.MaterialId,
                                  Nazwa = mb.Material.Nazwa,
                                  SzerokoscBelki= mb.Material.SzerokoscBelki
                              },
                              OznaczenieWewnetrzne = mb.OznaczenieWewnetrzne,
                              StanPoczatkowy = mb.StanPoczatkowy,
                              Uwagi =mb.Uwagi,
                              
                             
                          });

            return Ok(result);
        }


        [HttpDelete]
        [Route("api/MaterialBelka/PzTkaniny/{id}")]
        public IHttpActionResult DeletePzTkaniny(int id)
        {
            var pzT = db.MaterialBelkaPzTkaniny.Where(w => w.MaterialBelkaPzTkaninyId == id).Select(s => new 
            {
                CzyPowierzona=s.CzyPowierzona,
                PzTkaninyId = s.MaterialBelkaPzTkaninyId,
                DataWystawienia=s.DataWystawienia,
                CzyZaksiegowana = s.CzyZaksiegowana,
                FakturaRefId=s.FakturaZakupuRefId,
                MaterialBelka = s.MaterialBelka.Select(smb => new MaterialBelkaDTO() {
                    Id=smb.MaterialBelkaId,
                }).ToList()
            }).FirstOrDefault();

            var belkiId = "Belka/i o ID: ";
            if (pzT == null)
            {
                return BadRequest($"Nie znaleziono Pz'ki o Id: {id}");
            }
            else {
                if (pzT.CzyZaksiegowana == true) {
                    return BadRequest($"Nie można usunąć PZ'ki gdy została już zaksięgowana. Faktura Id: {pzT.FakturaRefId}");
                }

                
                foreach (var item in pzT.MaterialBelka)
                {
                    var belka = db.MaterialBelka.Find(item.Id);
                    if (belka != null) {
                        belkiId += belka.MaterialBelkaId.ToString() + ", ";
                        belka.CzyPotwierdzona = false;
                        belka.MaterialBelkaPzTkaninyRefId = null;
                    }
                }
            }
            db.LogsDelete.Add(new LogsDelete()
            {
                DataUsuniecia = DateTime.Now,
                Tabela="MaterialBelkaPzTkaniny",
                UserName=User.Identity.Name,
                Uwagi="DataUtworzenia: "+ pzT.DataWystawienia.ToShortDateString()+" CzyPowierzona: "+pzT.CzyPowierzona.ToString()+" "+ belkiId
            

            });
            db.MaterialBelkaPzTkaniny.Remove(db.MaterialBelkaPzTkaniny.Find(id));
            db.SaveChanges();
            return Ok(new {info=$"PZ'ka tkaniny o id: {id} została usunięta. {belkiId} oznaczono jako nieprzypisane" });
        }


        [HttpGet]
        [Route("api/MaterialBelka/PzTkaniny")]
        public IHttpActionResult GetMaterialBelkaPzTkaniny() {

            var result = (from pzt in db.MaterialBelkaPzTkaniny
                          select new MaterialBelkaPzTkaninyDTO()
                          {
                              CreatedBy=pzt.CreatedBy,
                              CzyPowierzona=pzt.CzyPowierzona,
                              CzyZaksiegowana=pzt.CzyZaksiegowana,
                              DataWystawienia=pzt.DataWystawienia,
                              DokumentZrodlowyNr=pzt.DokumentZrodlowyNr,
                              PzTkaninyId=pzt.MaterialBelkaPzTkaninyId,
                              Uwagi=pzt.Uwagi
                          });


            return Ok(result);
        }

        [HttpGet]
        [Route("api/MaterialBelka/NierozliczonePzTkaniny")]
        public IHttpActionResult GetNierozliczonePzTkaniny()
        {

            var result = (from pzt in db.MaterialBelkaPzTkaniny where pzt.CzyZaksiegowana == false && pzt.CzyPowierzona==false
                          select new MaterialBelkaPzTkaninyNierozliczoneDTO()
                          {
                              CreatedBy = pzt.CreatedBy,
                              CzyPowierzona = pzt.CzyPowierzona,
                              CzyZaksiegowana = pzt.CzyZaksiegowana,
                              DataWystawienia = pzt.DataWystawienia,
                              DokumentZrodlowyNr = pzt.DokumentZrodlowyNr,

                              PzTkaninyId = pzt.MaterialBelkaPzTkaninyId,
                              MaterialBelka = pzt.MaterialBelka.GroupBy(g => g.MaterialRefId).Select(s => new MaterialBelkaPzTkaninyNierozliczoneBelkaDTO() {
                                 MaterialId=s.Key,
                                 Ilosc=s.Sum(su=>su.StanPoczatkowy),
                                 Material=s.Select(sn=>new MaterialCenyStatsDTO {
                                     Nazwa=sn.Material.Nazwa,
                                     MaterialId=sn.MaterialRefId,
                                     }).FirstOrDefault(),
                              }).ToList(),
                              Uwagi = pzt.Uwagi,
                          }).ToList();

            

            List<MaterialDTO> ListaMaterialow = new List<MaterialDTO>();

            var MatBelki = result.Select(s => s.MaterialBelka).ToList();

            foreach (var item in result)
            {
                var materialy=item.MaterialBelka.Select(s => s.Material).ToList();
                foreach (var mat in materialy)
                {
                    var m = ListaMaterialow.Exists(e=>e.MaterialId==mat.MaterialId);
                    if (m==false) {
                        ListaMaterialow.Add(mat);
                    }
                }

            }

            var fakturaPozycjeTkanin = (from fpt in db.FinFakturaPozycjeTkaniny.WhereIn(wi => wi.MaterialRefId, ListaMaterialow.Select(sl => sl.MaterialId))
                                        group fpt by fpt.MaterialRefId into matGroup
                                        let ostatni=matGroup.OrderByDescending(o=>o.FakturaZakupu.DataWystawienia).FirstOrDefault()
                                        select new
                                        {
                                            MaterialId=matGroup.Key,
                                            Statystyki=new StatystykiDTO()
                                            {
                                                Avg = matGroup.Average(a => a.Cena),
                                                Count = matGroup.Count(),
                                                Max = matGroup.Max(a => a.Cena),
                                                Min= matGroup.Min(a => a.Cena),
                                                Ostatni=new MagPozOstatniDTO() {
                                                    Cena=ostatni.Cena,
                                                    DataOstatniegoZakupu=ostatni.FakturaZakupu.DataWystawienia,
                                                    Kontrahent=ostatni.FakturaZakupu.Kontrahent.Skrot.Length>0? ostatni.FakturaZakupu.Kontrahent.Skrot: ostatni.FakturaZakupu.Kontrahent.Nazwa
                                                }
                                            }


                                        }).ToList();


            foreach (var pz in result)//wszystkie pzki
            {
                foreach (var matBelka in pz.MaterialBelka)//wszystkie belki
                {
                    matBelka.Material.Statystyki = fakturaPozycjeTkanin.Where(w => w.MaterialId == matBelka.MaterialId).Select(s => s.Statystyki).FirstOrDefault();
                }
            }



            return Ok(result);
        }

        


        [HttpGet]
        [Route("api/MaterialBelka/PzTkaniny/{id:int}")]
        public IHttpActionResult GetMaterialBelkaPzTkaniny(int id)
        {

            var result = (from pzt in db.MaterialBelkaPzTkaniny where pzt.MaterialBelkaPzTkaninyId==id
                          select new MaterialBelkaPzTkaninyDTO()
                          {
                              CreatedBy = pzt.CreatedBy,
                              CzyPowierzona = pzt.CzyPowierzona,
                              CzyZaksiegowana = pzt.CzyZaksiegowana,
                              DataWystawienia = pzt.DataWystawienia,
                              DokumentZrodlowyNr = pzt.DokumentZrodlowyNr,
                              FakturaRefId= pzt.FakturaZakupuRefId.Value,
                              PzTkaninyId = pzt.MaterialBelkaPzTkaninyId,
                              MaterialBelka=pzt.MaterialBelka.Select(s=> new MaterialBelkaDTO() {
                                  CreatedBy = s.CreatedBy,
                                  CreatedDateTime = s.CreatedDateTime,
                                  FakturaNr = s.DokumentZrodlowyNr,
                                  DataPrzyjecia = s.DataPrzyjecia,
                                  Id = s.MaterialBelkaId,
                                  Material = new MaterialDTO
                                  {
                                      CzyUtrudnienie = s.Material.CzyUtrudnienie,                                      
                                      MaterialGrupaKontrahent = new MaterialGrupaKontrahentDTO()
                                      {
                                          MaterialGrupaKontrahentId = s.Material.MaterialGrupa.MaterialGrupaKontrahentId,
                                          Nazwa = s.Material.MaterialGrupa.Nazwa,
                                      },
                                      MaterialId = s.Material.MaterialId,
                                      Nazwa = s.Material.Nazwa,
                                      SzerokoscBelki = s.Material.SzerokoscBelki
                                  },
                                  OznaczenieWewnetrzne = s.OznaczenieWewnetrzne,
                                  StanPoczatkowy = s.StanPoczatkowy,
                                  Uwagi = s.Uwagi
                              }).ToList(),
                              Uwagi = pzt.Uwagi
                          });


            return Ok(result);
        }

        [HttpPut]
        [Route("api/materialBelka/pzTkaniny/{id}")]

        public IHttpActionResult PutMaterialBelkaPzTkaniny(int id, MaterialBelkaPzTkaninyDTO pzDTO)
        {

            var pz = db.MaterialBelkaPzTkaniny.Find(id);

            if (!ModelState.IsValid)
            {
                return BadRequest("Przesłane dane nie są zgodne");
            }

            if (id == 0)
            {
                MaterialBelkaPzTkaniny pzNew = db.MaterialBelkaPzTkaniny.Add(new MaterialBelkaPzTkaniny());
                pzNew.CreatedBy = pzDTO.CreatedBy;
                pzNew.CzyPowierzona = pzDTO.CzyPowierzona;
                pzNew.DataWystawienia = DateTime.Now;
                pzNew.DokumentZrodlowyNr = pzDTO.DokumentZrodlowyNr;
                pzNew.Uwagi = pzDTO.Uwagi;

                foreach (var item in pzDTO.MaterialBelka)
                {
                    var mb=db.MaterialBelka.Find(item.Id);
                    mb.MaterialBelkaPzTkaninyRefId = pzNew.MaterialBelkaPzTkaninyId;
                    mb.CzyPotwierdzona = true;
                    mb.CzyPowierzona = pzDTO.CzyPowierzona;
                }


            }
            else {

                if (pz == null) {
                    return BadRequest($"Nie znaleziono PZ'ki o Id: {id}");
                }


                var pzMod = db.MaterialBelkaPzTkaniny.Where(w => w.MaterialBelkaPzTkaninyId == id).Select(s => new MaterialBelkaPzTkaninyDTO()
                {
                    CzyPowierzona = s.CzyPowierzona,
                    CzyZaksiegowana=s.CzyZaksiegowana,
                    DokumentZrodlowyNr = s.DokumentZrodlowyNr,
                    Uwagi = s.Uwagi,
                    MaterialBelka = s.MaterialBelka.Select(smb => new MaterialBelkaDTO() {
                        Id = smb.MaterialBelkaId
                    }).ToList(),
                    PzTkaninyId=s.MaterialBelkaPzTkaninyId
                }).FirstOrDefault();


                if (pzMod.CzyZaksiegowana == true || pzDTO.MaterialBelka.Count == 0) {
                    return BadRequest("Nie można zakutalizować danych. Nie dodano żadnych belek lub PZ'ka została już zaksięgowana");
                }
                             
                foreach (var item in pzMod.MaterialBelka)
                {
                    var mb = db.MaterialBelka.Find(item.Id);
                    mb.CzyPotwierdzona = false;
                    mb.CzyPowierzona = false;
                }

                

                pz.DokumentZrodlowyNr = pzDTO.DokumentZrodlowyNr;
                pz.CzyPowierzona = pzDTO.CzyPowierzona;
                pz.Uwagi = pzDTO.Uwagi;

                foreach (var item in pzDTO.MaterialBelka)
                {
                    var mb = db.MaterialBelka.Find(item.Id);
                    mb.MaterialBelkaPzTkaninyRefId = pzMod.PzTkaninyId;
                    mb.CzyPotwierdzona = true;
                    mb.CzyPowierzona = pzDTO.CzyPowierzona;
                }


                //return BadRequest("Nie ma opcji edycji");
            }


            db.SaveChanges();



            return Ok("Dane zostały zaktualizowane");
        }


        



    }


}