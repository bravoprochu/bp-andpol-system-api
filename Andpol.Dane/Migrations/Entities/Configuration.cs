namespace Andpol.Dane.Migrations.Entities
{
    using Andpol.Dane.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Andpol.Dane.Entities.PoligonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Entities";
        }



        protected override void Seed(Andpol.Dane.Entities.PoligonContext context)
        {
            //    //  This method will be called after migrating to the latest version.

            //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //    //  to avoid creating duplicate seed data. E.g.
            //    //
            //    //    context.People.AddOrUpdate(
            //    //      p => p.FullName,
            //    //      new Person { FullName = "Andrew Peters" },
            //    //      new Person { FullName = "Brice Lambson" },
            //    //      new Person { FullName = "Rowan Miller" }
            //    //    );
            //    //

            if (false)
            {

                List<NazwaKombinacji> nazwaKombi = new List<NazwaKombinacji>();
                nazwaKombi.Add(new NazwaKombinacji() { Id = 1, Nazwa = "-1-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 2, Nazwa = "-1,5-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 3, Nazwa = "-2-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 4, Nazwa = "-2,5-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 5, Nazwa = "-3-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 6, Nazwa = "-4-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 7, Nazwa = "-OTS-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 8, Nazwa = "-OTM-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 9, Nazwa = "-OTL-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 10, Nazwa = "-OTXL-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 11, Nazwa = "-H-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 12, Nazwa = "-XLH-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 13, Nazwa = "-3XLR-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 14, Nazwa = "-2,5 XLR-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 15, Nazwa = "-ISL" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 16, Nazwa = "ISL-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 17, Nazwa = "-EOT" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 18, Nazwa = "EOT-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 19, Nazwa = "-OTSV-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 20, Nazwa = "-OTMV-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 21, Nazwa = "-OTLV-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 22, Nazwa = "HO 60X90" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 23, Nazwa = "HO 45X45" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 24, Nazwa = "HO 80X80" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 25, Nazwa = "HO 97X80" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 26, Nazwa = "HO" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 27, Nazwa = "ARM LEFT-" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 28, Nazwa = "-ARM RIGHT" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 29, Nazwa = "DP45" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 30, Nazwa = "DP50" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 31, Nazwa = "VP- Vintage Pillows" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 32, Nazwa = "AP- Arvin Pillows" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 33, Nazwa = "SP- Side pillows" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 34, Nazwa = "RP- Roll pillows" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 35, Nazwa = "PL- Plate pillows" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 36, Nazwa = "FPG Front Pillow Giorno" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 37, Nazwa = "FPL Lorenzo" });
                nazwaKombi.Add(new NazwaKombinacji() { Id = 38, Nazwa = "FPP Provence" });


                foreach (var item in nazwaKombi)
                {
                    context.NazwaKombinacji.AddOrUpdate(item);
                }




                List<WykonczenieGrupa> wykGrupaLista = new List<WykonczenieGrupa>();

                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 1, Nazwa = "Boczek" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 2, Nazwa = "Deska" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 3, Nazwa = "Korpus" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 4, Nazwa = "£πcznik" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 5, Nazwa = "NÛøka" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 6, Nazwa = "Poduszka dekoracyjna" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 7, Nazwa = "Poduszka lÍdüwiowa" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 8, Nazwa = "Poduszka oparciowa" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 9, Nazwa = "Poduszka siedzeniowa" });
                wykGrupaLista.Add(new WykonczenieGrupa { WykonczenieGrupaId = 10, Nazwa = "Rπczka" });


                foreach (var item in wykGrupaLista)
                {
                    context.WykonczenieGrupa.AddOrUpdate(item);
                }

                context.SaveChanges();

                List<Wykonczenie> wykLista = new List<Wykonczenie>();
                wykLista.Add(new Wykonczenie { WykonczenieId = 1, WykonczenieGrupaRefId = 1, Nazwa = "brak", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 2, WykonczenieGrupaRefId = 1, Nazwa = "BN-s", Uwagi = "Brown nails (small)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 3, WykonczenieGrupaRefId = 1, Nazwa = "BN-l", Uwagi = "Brown nails (large)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 4, WykonczenieGrupaRefId = 1, Nazwa = "SN-s", Uwagi = "Silver nails (small)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 5, WykonczenieGrupaRefId = 1, Nazwa = "SN-l", Uwagi = "Silver nails (large)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 6, WykonczenieGrupaRefId = 1, Nazwa = "Bt", Uwagi = "Guziki (button)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 7, WykonczenieGrupaRefId = 2, Nazwa = "brak", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 8, WykonczenieGrupaRefId = 2, Nazwa = "BN-s", Uwagi = "Brown nails (small)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 9, WykonczenieGrupaRefId = 2, Nazwa = "BN-l", Uwagi = "Brown nails (large)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 10, WykonczenieGrupaRefId = 2, Nazwa = "SN-s", Uwagi = "Silver nails (small)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 11, WykonczenieGrupaRefId = 2, Nazwa = "SN-l", Uwagi = "Silver nails (large)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 12, WykonczenieGrupaRefId = 2, Nazwa = "Bt", Uwagi = "Guziki (button)" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 13, WykonczenieGrupaRefId = 3, Nazwa = "Brak", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 14, WykonczenieGrupaRefId = 3, Nazwa = "LD", Uwagi = "Less depth" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 15, WykonczenieGrupaRefId = 4, Nazwa = "CR", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 16, WykonczenieGrupaRefId = 4, Nazwa = "CRM", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 17, WykonczenieGrupaRefId = 4, Nazwa = "Blachy", Uwagi = "domyúlne" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 18, WykonczenieGrupaRefId = 4, Nazwa = "Tkanina", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 19, WykonczenieGrupaRefId = 5, Nazwa = "natural", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 20, WykonczenieGrupaRefId = 5, Nazwa = "unfinished", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 21, WykonczenieGrupaRefId = 5, Nazwa = "metal", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 22, WykonczenieGrupaRefId = 5, Nazwa = "aluminium", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 23, WykonczenieGrupaRefId = 5, Nazwa = "plastic", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 24, WykonczenieGrupaRefId = 5, Nazwa = "colonial", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 25, WykonczenieGrupaRefId = 5, Nazwa = "black", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 26, WykonczenieGrupaRefId = 5, Nazwa = "wheels", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 27, WykonczenieGrupaRefId = 5, Nazwa = "black+wheel", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 28, WykonczenieGrupaRefId = 5, Nazwa = "colonial+wheel", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 29, WykonczenieGrupaRefId = 6, Nazwa = "Brak", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 30, WykonczenieGrupaRefId = 6, Nazwa = "Bt", Uwagi = "guzik" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 31, WykonczenieGrupaRefId = 6, Nazwa = "BtW", Uwagi = "guzik drewniany" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 32, WykonczenieGrupaRefId = 7, Nazwa = "brak", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 33, WykonczenieGrupaRefId = 7, Nazwa = "1", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 34, WykonczenieGrupaRefId = 7, Nazwa = "1.5", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 35, WykonczenieGrupaRefId = 7, Nazwa = "2", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 36, WykonczenieGrupaRefId = 7, Nazwa = "2.5", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 37, WykonczenieGrupaRefId = 7, Nazwa = "3", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 38, WykonczenieGrupaRefId = 7, Nazwa = "OTS", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 39, WykonczenieGrupaRefId = 7, Nazwa = "OTM", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 40, WykonczenieGrupaRefId = 7, Nazwa = "OTL", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 41, WykonczenieGrupaRefId = 8, Nazwa = "brak", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 42, WykonczenieGrupaRefId = 8, Nazwa = "CASIA", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 43, WykonczenieGrupaRefId = 8, Nazwa = "PRESTO", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 44, WykonczenieGrupaRefId = 8, Nazwa = "VINTAGE", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 45, WykonczenieGrupaRefId = 9, Nazwa = "brak", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 46, WykonczenieGrupaRefId = 9, Nazwa = "HS hard seat", Uwagi = "Hard seat" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 47, WykonczenieGrupaRefId = 9, Nazwa = "CS comfort", Uwagi = "Comfort" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 48, WykonczenieGrupaRefId = 9, Nazwa = "OI old insert", Uwagi = "Old insert" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 49, WykonczenieGrupaRefId = 9, Nazwa = "LS latex seat", Uwagi = "Latex seat" });
                wykLista.Add(new Wykonczenie { WykonczenieId = 50, WykonczenieGrupaRefId = 9, Nazwa = "Dwustronna", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 51, WykonczenieGrupaRefId = 10, Nazwa = "brak", Uwagi = null });
                wykLista.Add(new Wykonczenie { WykonczenieId = 52, WykonczenieGrupaRefId = 10, Nazwa = "BH", Uwagi = "Big henger" });


                foreach (var item in wykLista)
                {
                    context.Wykonczenie.AddOrUpdate(item);
                }



                //    List<WykonczenieObszycie> WykonczenieObszycieList = new List<WykonczenieObszycie>();
                //    WykonczenieObszycieList.Add(new WykonczenieObszycie() { Id = 1, Nazwa = "oparcie" });
                //    WykonczenieObszycieList.Add(new WykonczenieObszycie() { Id = 2, Nazwa = "poduszka lÍdüwiowa" });
                //    WykonczenieObszycieList.Add(new WykonczenieObszycie() { Id = 3, Nazwa = "poduszka dekoracyjna" });
                //    WykonczenieObszycieList.Add(new WykonczenieObszycie() { Id = 4, Nazwa = "keder" });
                //    WykonczenieObszycieList.Add(new WykonczenieObszycie() { Id = 5, Nazwa = "guziki" });
                //    WykonczenieObszycieList.Add(new WykonczenieObszycie() { Id = 6, Nazwa = "korpus" });
                //    WykonczenieObszycieList.Add(new WykonczenieObszycie() { Id = 7, Nazwa = "siedzenie" });
                //    foreach (var item in WykonczenieObszycieList)
                //    {
                //        context.WykonczenieObszycie.AddOrUpdate(item);
                //    }
                //    context.SaveChanges();



                List<JednGrupaZakladowa> GrupaZakladowaList = new List<JednGrupaZakladowa>();
                GrupaZakladowaList.Add(new JednGrupaZakladowa { JednGrupaZakladowaId = 1, Nazwa = "OgÛlne" });
                GrupaZakladowaList.Add(new JednGrupaZakladowa { JednGrupaZakladowaId = 2, Nazwa = "Micha≥ - meble twarde" });

                foreach (var item in GrupaZakladowaList)
                {
                    context.JednGrupaZakladowa.AddOrUpdate(item);
                }


                List<JednMarzaZakladowa> MarzaZakladowaList = new List<JednMarzaZakladowa>();
                MarzaZakladowaList.Add(new JednMarzaZakladowa { JednMarzaZakladowaId = 1, Nazwa = "Domyúlna", Wartosc = 0.3d });

                foreach (var item in MarzaZakladowaList)
                {
                    context.JednMarzaZakladowa.AddOrUpdate(item);
                }

                List<JednPodatekStawka> PodatekStawkaList = new List<JednPodatekStawka>();
                PodatekStawkaList.Add(new JednPodatekStawka { JednPodatekStawkaId = 1, Nazwa = "23 %", Wartosc = 0.23 });
                PodatekStawkaList.Add(new JednPodatekStawka { JednPodatekStawkaId = 2, Nazwa = "8 %", Wartosc = 0.08 });
                PodatekStawkaList.Add(new JednPodatekStawka { JednPodatekStawkaId = 3, Nazwa = "5 %", Wartosc = 0.05 });
                PodatekStawkaList.Add(new JednPodatekStawka { JednPodatekStawkaId = 4, Nazwa = "0 %", Wartosc = 0 });
                PodatekStawkaList.Add(new JednPodatekStawka { JednPodatekStawkaId = 5, Nazwa = "6 %", Wartosc = 0.06 });
                PodatekStawkaList.Add(new JednPodatekStawka { JednPodatekStawkaId = 6, Nazwa = "zwolniony", Wartosc = 0 });
                PodatekStawkaList.Add(new JednPodatekStawka { JednPodatekStawkaId = 7, Nazwa = "bez odliczeÒ", Wartosc = 0 });


                foreach (var item in PodatekStawkaList)
                {
                    context.JednPodatekStawka.AddOrUpdate(item);
                }

                List<JednDokumentTyp> dokumentTypList = new List<JednDokumentTyp>();

                dokumentTypList.Add(new JednDokumentTyp { JednDokumentTypId = 1, Nazwa = "FV", Uwagi = "Faktura" });
                dokumentTypList.Add(new JednDokumentTyp { JednDokumentTypId = 2, Nazwa = "PZ", Uwagi = "PrzyjÍcie zewnÍtrzne" });
                dokumentTypList.Add(new JednDokumentTyp { JednDokumentTypId = 3, Nazwa = "WZ", Uwagi = "Wydanie zewnÍtrzne" });


                foreach (var item in dokumentTypList)
                {
                    context.JednDokumentTyp.AddOrUpdate(item);
                }

                List<JednPlatnoscRodzaj> jednPlatnoscList = new List<JednPlatnoscRodzaj>();
                jednPlatnoscList.Add(new JednPlatnoscRodzaj { JednPlatnoscRodzajId = 1, Nazwa = "GotÛwka", CzyDni = false, CzyUwagi = false });
                jednPlatnoscList.Add(new JednPlatnoscRodzaj { JednPlatnoscRodzajId = 2, Nazwa = "GotÛwka w terminie", CzyDni = true, CzyUwagi = false });
                jednPlatnoscList.Add(new JednPlatnoscRodzaj { JednPlatnoscRodzajId = 3, Nazwa = "Przelew", CzyDni = true, CzyUwagi = false });
                jednPlatnoscList.Add(new JednPlatnoscRodzaj { JednPlatnoscRodzajId = 4, Nazwa = "Inne", CzyDni = false, CzyUwagi = true });
                jednPlatnoscList.Add(new JednPlatnoscRodzaj { JednPlatnoscRodzajId = 5, Nazwa = "Karta kredytowa", CzyDni = false, CzyUwagi = false });


                foreach (var item in jednPlatnoscList)
                {
                    context.JednPlatnoscRodzaj.AddOrUpdate(item);
                }


                List<JednJednostkaMiary> JednostkaMiaryList = new List<JednJednostkaMiary>();
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 1, Nazwa = "100szt.", Uwagi = "100 sztuk" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 2, Nazwa = "kg", Uwagi = "kilogram" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 3, Nazwa = "kpl.", Uwagi = "komplet" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 4, Nazwa = "m2", Uwagi = "metr kwadratowy" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 5, Nazwa = "m3", Uwagi = "metr szeúcienny" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 6, Nazwa = "mb", Uwagi = "metr bieøπcy" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 7, Nazwa = "opak.", Uwagi = "opakowanie" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 8, Nazwa = "szt.", Uwagi = "sztuka" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 9, Nazwa = "t", Uwagi = "tona" });
                JednostkaMiaryList.Add(new JednJednostkaMiary { JednJednostkaMiaryId = 10, Nazwa = "dm3", Uwagi = "litr" });


                foreach (var item in JednostkaMiaryList)
                {
                    context.JednJednostkaMiary.AddOrUpdate(item);
                }

                context.SaveChanges();

                //List<MagPozycjaMagazynowa> magPozycjaMagazynowaList = new List<MagPozycjaMagazynowa>();

                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 1, Nazwa = "ELEMENT £•CZENIOWY TYP.A- 100SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 2, Nazwa = "FIBER 100 G 1,6M", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 3, Nazwa = "FIBER 100G 1/2", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 4, Nazwa = "FIBER 100G/M2 160 CZARNY", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 5, Nazwa = "FIBER SZARY 100GR/1/2", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 6, Nazwa = "FIBERTEX 125 GR 1,6", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 7, Nazwa = "FOLIA PO£R KAW ORYG. 700/0,1", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 8, Nazwa = "FOLIA -P”£ R KAW  REGL 900/01", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 9, Nazwa = "FOLIA P”£R AW ORYG 900/0,1", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 10, Nazwa = "FOLIA P”£R KAW", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 11, Nazwa = "FOLIA P”£R KAW 1300X100XC1", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 12, Nazwa = "FOLIA P”£R KAW 700X100XC1", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 13, Nazwa = "FOLIA P”£R KAW ORYGINA£ 0,07", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 14, Nazwa = "FOLIA P”£R KAW REGL  900/0,01", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 15, Nazwa = "FOLIA P”£R KAW REGL 1000+300/0,1", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 16, Nazwa = "FOLIA R KAW 900X100XC1", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 17, Nazwa = "FOLIA R KAW REGL 900/0,07", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 18, Nazwa = "FORMATKA PIANKA HR 30 1435X825X135", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 19, Nazwa = "FORMATKA PIANKA HR 30 385X333X825", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 20, Nazwa = "FORMATKA PIANKA HR 30 825X600X135", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 21, Nazwa = "FORMATKA PIANKA HR 590X590X105", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 22, Nazwa = "FORMATKA PIANKA T-35 1435X825X135", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 23, Nazwa = "FORMATKA PIANKA T-35 590X590X80", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 24, Nazwa = "FORMATKA PIANKA T-35 825X600X100", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 25, Nazwa = "FORMATKI - MODEL GALAXY", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 26, Nazwa = "FORMATKI NAROØNIK KARTONOWY", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 27, Nazwa = "GUZIK MET.CZ.DOLNA 32 (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 28, Nazwa = "GUZIK MET.CZ.G”RNA 32(100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 29, Nazwa = "GUZIK MET.CZ å∆ DOLNA OTW 36(100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 30, Nazwa = "GUZIK MET.CZ å∆ DOLNA ZAM. 36", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 31, Nazwa = "GUZIK MET.CZ å∆ G”RNA 36(100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 32, Nazwa = "GUZIKI TAPICERSKIE *24 15MM 1000SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 33, Nazwa = "GUZIKI TAPICERSKIE 36-23 MM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 34, Nazwa = "GWOèDZIE DEKOR.NIKIEL 90 (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 35, Nazwa = "GWOèDZIE OZD.100 1/3 BRONCE (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 36, Nazwa = "GWOèDZIE OZD.100 1/3 BRONCE 100SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 37, Nazwa = "GWOèDZIE OZD.1505 VERNICKELT (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 38, Nazwa = "GWOèDZIE OZDOBNE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 39, Nazwa = "GWOèDZIE OZDOBNE 100 1/3 VERNICKELT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 40, Nazwa = "GWOèDZIE TAPICERSKIE FI 9", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 41, Nazwa = "KARTON TAPICERSKI", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 42, Nazwa = "K•TOWNIK I P£ASKOWNIK Z BLACH GR. 4", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 43, Nazwa = "KEDRA", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 44, Nazwa = "KEDRA FILC-PLAST 100 MB", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 45, Nazwa = "KEDRA PIANKA Z WYPUST 12MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 46, Nazwa = "KEDRA PIANKA Z WYPUST 8MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 47, Nazwa = "KEDRA PIANKOWA 12MM(100MB)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 48, Nazwa = "KONFIRMAT 7*50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 49, Nazwa = "K”£KO CHROMOWE STAND.32MM KIELICH", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 50, Nazwa = "K”£KO GUMOWANE Z GWINTEM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 51, Nazwa = "K”£KO MOSI ØNE 32MM-ANTIQUE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 52, Nazwa = "K”£KO OBROTOWE GUMOWANE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 53, Nazwa = "K”£KO OBROTOWE GUMOWANE K-35/27 G", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 54, Nazwa = "K”£KO OBROTOWE GUMOWANE K-35/P£ G", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 55, Nazwa = "K”£KO OBROTOWE Z GWINTEM K-35", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 56, Nazwa = "KULKA SILIKONOWA", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 57, Nazwa = "LISTWA SPR ØYNUJ•CA 650 X 53 X 8", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 58, Nazwa = "LISTWA Z GWOèDZ. 100 1/3 NIKIEL", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 59, Nazwa = "LISTWA+GWOèDZIE 100 BR•Z", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 60, Nazwa = "£•CZNIK KROKODYLEK", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 61, Nazwa = "£•CZNIK MEBLOWY Z BATY METAL.FIX 009", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 62, Nazwa = "MIESZANKA KULKA 20% FRYTKA 80% LATEKSOWA", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 63, Nazwa = "MIESZANKA KULKA 30%+FRYTKA  LATEXOWA 70%", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 64, Nazwa = "MIESZANKA KULKA 30%+FRYTKA 70%", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 65, Nazwa = "MIESZANKA PUCH 10%/FRYTKA KOLOR 90%", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 66, Nazwa = "NAKR TKA K£OWA M6 OC  100SZT.", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 67, Nazwa = "NAKR TKA K£OWA M8  100SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 68, Nazwa = "NAROØNIK 200/200/150", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 69, Nazwa = "NAROØNIK ARTIST", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 70, Nazwa = "NAROØNIK KRATOWNICA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 71, Nazwa = "NAROØNIK SK£ADANY", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 72, Nazwa = "NOGA ALUM CHARLI H-150 L-145*145", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 73, Nazwa = "NOGA ALUM. CHARLI H-150 L-145X145", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 74, Nazwa = "NOGA ARESE PRZ”D", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 75, Nazwa = "NOGA ARESE TY£", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 76, Nazwa = "NOGA ARVIN", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 77, Nazwa = "NOGA BIARITZ", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 78, Nazwa = "NOGA C P£ASKOWNIK 80*6 H-90", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 79, Nazwa = "NOGA CAMBERA 50X130", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 80, Nazwa = "NOGA CHANET 68*68 H-223", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 81, Nazwa = "NOGA CHROM.STOJ•CA FI50H130", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 82, Nazwa = "NOGA CUBANO FI-40 L-180 LEØ•CA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 83, Nazwa = "NOGA DREWNO CHROM TR”JK•T 140X80X40", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 84, Nazwa = "NOGA DWA PROFIKE 20*30 H-130 CHROM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 85, Nazwa = "NOGA DWA PROFILE 20*30 Z BLACH• H-130 CH", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 86, Nazwa = "NOGA ELISABETH PRZ”D", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 87, Nazwa = "NOGA ELISABETH TY£", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 88, Nazwa = "NOGA FI 110 H 135", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 89, Nazwa = "NOGA FI 50 H-130 M8*40", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 90, Nazwa = "NOGA FI 50 H-35", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 91, Nazwa = "NOGA FI 50 L-120", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 92, Nazwa = "NOGA FI 50 L-120 LEØ•CA CH", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 93, Nazwa = "NOGA FI 50H-40", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 94, Nazwa = "NOGA FI 56 H 128 NORTFOLK", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 95, Nazwa = "NOGA FI 90 H143", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 96, Nazwa = "NOGA FI. 50 H-35 NA WKR T CZARNA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 97, Nazwa = "NOGA FI.45 H-15", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 98, Nazwa = "NOGA FI.50 H-100 M8*35 (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 99, Nazwa = "NOGA FI.50 H-130 M8*40PW CHROM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 100, Nazwa = "NOGA FI.50 H-25", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 101, Nazwa = "NOGA FI.50 H-50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 102, Nazwa = "NOGA FI.50 H-90 M8*35 (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 103, Nazwa = "NOGA FI.55 H-70 NA WKR T CZARNA (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 104, Nazwa = "NOGA FI-90 H143 MA£E K”£KO (SUROWE)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 105, Nazwa = "NOGA FI-90 H145", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 106, Nazwa = "NOGA FREZOWANA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 107, Nazwa = "NOGA HARTFORD H-175 FI-80", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 108, Nazwa = "NOGA HELENA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 109, Nazwa = "NOGA INC CHROM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 110, Nazwa = "NOGA K•TOWA KOTWICA H-100 BLACHA CHROM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 111, Nazwa = "NOGA K•TOWA L-130 H-105", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 112, Nazwa = "NOGA K•TOWA U - 4MM H-130 SILVER01", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 113, Nazwa = "NOGA K•TOWA U BLACHA 4MM H-130 SATYNA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 114, Nazwa = "NOGA MANHATAN FI-73 H-200 M", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 115, Nazwa = "NOGA MANHATAN FI-73 H-200 S", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 116, Nazwa = "NOGA MARINA 40/170", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 117, Nazwa = "NOGA NAROØNIKOWA Z SREBRNYM PASKIEM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 118, Nazwa = "NOGA OTTO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 119, Nazwa = "NOGA P£ASKOWNIK 80*8 H-100 CHROM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 120, Nazwa = "NOGA P£ASKOWNIK 80*8 Z WA£KIEM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 121, Nazwa = "NOGA P£OZA L-824 H-108", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 122, Nazwa = "NOGA RENO FI  60MM H 20MM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 123, Nazwa = "NOGA RENO FI 120MM H 50 MM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 124, Nazwa = "NOGA ROFRA H-143 MA£E K”£KO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 125, Nazwa = "NOGA ROFRA H-145 B DUØE K”£KO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 126, Nazwa = "NOGA SAN REMO L", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 127, Nazwa = "NOGA SAN REMO S", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 128, Nazwa = "NOGA SAN REMO XXL", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 129, Nazwa = "NOGA SIXTIES", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 130, Nazwa = "NOGA STOJAK H-150 CHROM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 131, Nazwa = "NOGA STYLOWA 15CM BUK", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 132, Nazwa = "NOGA STYLOWA 20CM BUK", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 133, Nazwa = "NOGA STYLOWA 23 CM 3A", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 134, Nazwa = "NOGA STYLOWA 23CM 2A", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 135, Nazwa = "NOGA STYLOWA 5A 15 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 136, Nazwa = "NOGA STYLOWA DO KRZES£A K2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 137, Nazwa = "NOGA TOCZONA FI 50 H 40", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 138, Nazwa = "NOGA TOCZONA FI 57/29 H220", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 139, Nazwa = "NOGA TOCZONA FI-73 H-200", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 140, Nazwa = "NOGA TOSCANE FI-65 H-113", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 141, Nazwa = "NOGA TR”JK•TNA H-100 POLEROWANA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 142, Nazwa = "NOGA TW-M 160X80 H-HO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 143, Nazwa = "NOGA-BUK: ELISABETH PRZ”D", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 144, Nazwa = "NOGA-BUK: ELISABETH TY£", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 145, Nazwa = "NOGA-OTTO H-190", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 146, Nazwa = "NOGA-OTTO H-190 B", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 147, Nazwa = "NOGHA 70X55 TW 7317", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 148, Nazwa = "N”ZKA TRENTO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 149, Nazwa = "N”èKA SULIVAN", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 150, Nazwa = "N”Ø RZEèNICZY", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 151, Nazwa = "N”ØKA 10 CM OMI 1702C", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 152, Nazwa = "N”ØKA 15 CM OMI 1702C", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 153, Nazwa = "N”ØKA AILEN", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 154, Nazwa = "N”ØKA AMAZON", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 155, Nazwa = "N”ØKA ANNA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 156, Nazwa = "N”ØKA ARESE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 157, Nazwa = "N”ØKA ARVIN", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 158, Nazwa = "N”ØKA BAXTER", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 159, Nazwa = "N”ØKA BELLA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 160, Nazwa = "N”ØKA BONAIRE B", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 161, Nazwa = "N”ØKA CASSABLANCA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 162, Nazwa = "N”ØKA CHROM FI50X130", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 163, Nazwa = "N”ØKA CHROMOWANA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 164, Nazwa = "N”ØKA CLAUDIA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 165, Nazwa = "N”ØKA CLEVELAND", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 166, Nazwa = "N”ØKA CROWLEY", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 167, Nazwa = "N”ØKA DAWSON", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 168, Nazwa = "N”ØKA DAYTON", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 169, Nazwa = "N”ØKA DONCASTER", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 170, Nazwa = "N”ØKA DOVER", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 171, Nazwa = "N”ØKA ELTON", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 172, Nazwa = "N”ØKA ELTON B", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 173, Nazwa = "N”ØKA ERNA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 174, Nazwa = "N”ØKA FABIO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 175, Nazwa = "N”ØKA FABIO 11 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 176, Nazwa = "N”ØKA FIGARO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 177, Nazwa = "N”ØKA FIGARO-B", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 178, Nazwa = "N”ØKA FIRENCE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 179, Nazwa = "N”ØKA FLORIAN", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 180, Nazwa = "N”ØKA HAMILTON", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 181, Nazwa = "N”ØKA HAMILTON B", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 182, Nazwa = "N”ØKA HARDFORD", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 183, Nazwa = "N”ØKA HELENA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 184, Nazwa = "N”ØKA HETTY", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 185, Nazwa = "N”ØKA HOOVER", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 186, Nazwa = "N”ØKA IDAHO B", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 187, Nazwa = "N”ØKA IRIS", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 188, Nazwa = "N”ØKA KRIS", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 189, Nazwa = "N”ØKA LARKIN", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 190, Nazwa = "N”ØKA LENA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 191, Nazwa = "N”ØKA LEO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 192, Nazwa = "N”ØKA LIVERPOOL B", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 193, Nazwa = "N”ØKA LOMBARDO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 194, Nazwa = "N”ØKA METRO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 195, Nazwa = "N”ØKA MONTANA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 196, Nazwa = "N”ØKA NAPELS", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 197, Nazwa = "N”ØKA NELSON B", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 198, Nazwa = "N”ØKA NORTFOLK", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 199, Nazwa = "N”ØKA ORLANDO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 200, Nazwa = "N”ØKA PALERMO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 201, Nazwa = "N”ØKA PALLMORE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 202, Nazwa = "N”ØKA PANAMA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 203, Nazwa = "N”ØKA RICHMOND", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 204, Nazwa = "N”ØKA SAFIRA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 205, Nazwa = "N”ØKA SEATTLE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 206, Nazwa = "N”ØKA SULIVAN", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 207, Nazwa = "N”ØKA SYLVESTER", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 208, Nazwa = "N”ØKA TAVI", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 209, Nazwa = "N”ØKA TINA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 210, Nazwa = "N”ØKA TOAUREG", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 211, Nazwa = "N”ØKA TOSCANE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 212, Nazwa = "N”ØKA TRENTO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 213, Nazwa = "N”ØKA VENETIA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 214, Nazwa = "N”ØKA VERONA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 215, Nazwa = "PAPIER MICROFORATA SOR 60", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 216, Nazwa = "PAPIER TERMA STAR PLOTER 162 CM", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 217, Nazwa = "PAPIER TERMO STAR PLOTER 155CM", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 218, Nazwa = "PAPIER TERMO STAR PLOTER 162 CM", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 219, Nazwa = "PIANKA BLOK  35 /180  1200 D", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 220, Nazwa = "PIANKA BLOK 35/180 1200 D", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 221, Nazwa = "PIANKA BLOK CI TY HR 30 200*1600*80", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 222, Nazwa = "PIANKA BLOK CI TY HR 30 2000*1200*20", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 223, Nazwa = "PIANKA BLOK CI TY T-18", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 224, Nazwa = "PIANKA BLOK CI TY T-18 2000X1200X10", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 225, Nazwa = "PIANKA BLOK CI TY T-1830 2000X1200X10", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 226, Nazwa = "PIANKA BLOK CI TY T-35", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 227, Nazwa = "PIANKA BLOK CI TY T-35 2000X1200X20", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 228, Nazwa = "PIANKA BLOK CI TY T-35 2000X1200X30", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 229, Nazwa = "PIANKA BLOK CI TY T-35 2000X1200X40", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 230, Nazwa = "PIANKA BLOK CI TY T-35 2000X1200X50", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 231, Nazwa = "PIANKA BLOK CI TY T-35 2000X1200X60", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 232, Nazwa = "PIANKA BLOK CI TY T-35 2000X1200X80", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 233, Nazwa = "PIANKA BLOK HR 25/065 1200 D", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 234, Nazwa = "PIANKA BLOK HR 30 2000X1200X1200", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 235, Nazwa = "PIANKA BLOK HR 30/110 1200 D", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 236, Nazwa = "PIANKA BLOK HR 30/110 1610 D", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 237, Nazwa = "PIANKA BLOK HR 35/032 1200 D", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 238, Nazwa = "PIANKA BLOK HR 35/120 1200 D", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 239, Nazwa = "PIANKA BLOK R-30120 2000 1600 1200", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 240, Nazwa = "PIANKA BLOK R-30120 2040*1600", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 241, Nazwa = "PIANKA BLOK R-30120 2040*2400", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 242, Nazwa = "PIANKA BLOK R-30120(160)", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 243, Nazwa = "PIANKA BLOK R-3028 2000*1600", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 244, Nazwa = "PIANKA BLOK R-3028 2000*2400", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 245, Nazwa = "PIANKA BLOK R35120*1200-1200-200", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 246, Nazwa = "PIANKA BLOK R90120 200 1200", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 247, Nazwa = "PIANKA BLOK T-30 2000X1200X1200", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 248, Nazwa = "PIANKA BLOK T-35 2000X1200X1200", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 249, Nazwa = "PIANKA BURTON OT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 250, Nazwa = "PIANKA BURTON OTM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 251, Nazwa = "PIANKA BUSTER", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 252, Nazwa = "PIANKA BYRON 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 253, Nazwa = "PIANKA CALMONT CS 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 254, Nazwa = "PIANKA CALMONT CS 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 255, Nazwa = "PIANKA CALMONT CS 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 256, Nazwa = "PIANKA CALMONT OTM UNIW", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 257, Nazwa = "PIANKA CAPRI  2 S P", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 258, Nazwa = "PIANKA CAPRI 1", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 259, Nazwa = "PIANKA CAPRI 2 F L", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 260, Nazwa = "PIANKA CAPRI 2 L", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 261, Nazwa = "PIANKA CAPRI 2 P", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 262, Nazwa = "PIANKA CAPRI 2 S L", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 263, Nazwa = "PIANKA CAPRI 2/2 S", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 264, Nazwa = "PIANKA CAPRI 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 265, Nazwa = "PIANKA CAPRI 3 F", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 266, Nazwa = "PIANKA CARDIFF 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 267, Nazwa = "PIANKA CARDIFF 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 268, Nazwa = "PIANKA CARDIFF LCH", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 269, Nazwa = "PIANKA CARDIFF UCHO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 270, Nazwa = "PIANKA CLEVELAND 1,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 271, Nazwa = "PIANKA CLEVELAND 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 272, Nazwa = "PIANKA CLEVELAND 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 273, Nazwa = "PIANKA CLEVELAND 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 274, Nazwa = "PIANKA CLEVELAND EDT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 275, Nazwa = "PIANKA CLEVELAND HO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 276, Nazwa = "PIANKA CLEVELAND RE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 277, Nazwa = "PIANKA CLEVELAND UCHO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 278, Nazwa = "PIANKA DAVINA 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 279, Nazwa = "PIANKA DAVINA UCHO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 280, Nazwa = "PIANKA DRYFEEL 200*1330*481", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 281, Nazwa = "PIANKA DRYFEEL 200*1421*480", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 282, Nazwa = "PIANKA DRYFEEL S 2000*1400", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 283, Nazwa = "PIANKA DUMO T-23  /50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 284, Nazwa = "PIANKA DUMO T-35/80", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 285, Nazwa = "PIANKA ELTON 1,5/3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 286, Nazwa = "PIANKA ELTON 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 287, Nazwa = "PIANKA ELTON UCHO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 288, Nazwa = "PIANKA HO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 289, Nazwa = "PIANKA MADISON 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 290, Nazwa = "PIANKA MADISON UCHO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 291, Nazwa = "PIANKA MERLIN 1", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 292, Nazwa = "PIANKA MERLIN 1,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 293, Nazwa = "PIANKA MERLIN 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 294, Nazwa = "PIANKA MERLIN 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 295, Nazwa = "PIANKA MERLIN 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 296, Nazwa = "PIANKA MERLIN E 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 297, Nazwa = "PIANKA MERLIN E 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 298, Nazwa = "PIANKA MERLIN E 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 299, Nazwa = "PIANKA MERLIN E OT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 300, Nazwa = "PIANKA MERLIN E OTM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 301, Nazwa = "PIANKA MERLIN OT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 302, Nazwa = "PIANKA MERLIN OTM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 303, Nazwa = "PIANKA MERLIN OTS", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 304, Nazwa = "PIANKA MERLIN UCHO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 305, Nazwa = "PIANKA NORTFOLK 1", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 306, Nazwa = "PIANKA NORTFOLK 1 L", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 307, Nazwa = "PIANKA NOWY MELRIN LD OTS", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 308, Nazwa = "PIANKA NOWY MERLIN 1", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 309, Nazwa = "PIANKA NOWY MERLIN 1,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 310, Nazwa = "PIANKA NOWY MERLIN 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 311, Nazwa = "PIANKA NOWY MERLIN 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 312, Nazwa = "PIANKA NOWY MERLIN 2,5 XLR", JednostkaMiaryRefId = 3, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 313, Nazwa = "PIANKA NOWY MERLIN 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 314, Nazwa = "PIANKA NOWY MERLIN 3 XLR", JednostkaMiaryRefId = 3, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 315, Nazwa = "PIANKA NOWY MERLIN 80*80", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 316, Nazwa = "PIANKA NOWY MERLIN HO 60*90", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 317, Nazwa = "PIANKA NOWY MERLIN ISL", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 318, Nazwa = "PIANKA NOWY MERLIN LD 1", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 319, Nazwa = "PIANKA NOWY MERLIN LD 1,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 320, Nazwa = "PIANKA NOWY MERLIN LD 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 321, Nazwa = "PIANKA NOWY MERLIN LD 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 322, Nazwa = "PIANKA NOWY MERLIN LD 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 323, Nazwa = "PIANKA NOWY MERLIN LD H", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 324, Nazwa = "PIANKA NOWY MERLIN LD ISL", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 325, Nazwa = "PIANKA NOWY MERLIN LD OT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 326, Nazwa = "PIANKA NOWY MERLIN LD OTM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 327, Nazwa = "PIANKA NOWY MERLIN OT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 328, Nazwa = "PIANKA NOWY MERLIN OTM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 329, Nazwa = "PIANKA NOWY MERLIN OTM UNIWERSALNA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 330, Nazwa = "PIANKA NOWY MERLIN OTS", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 331, Nazwa = "PIANKA NOWY MODEL MERLIN LD 1,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 332, Nazwa = "PIANKA NOWY MODEL MERLIN LD 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 333, Nazwa = "PIANKA PALLMORE CS 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 334, Nazwa = "PIANKA PALLMORE CS 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 335, Nazwa = "PIANKA PLAY 3 FBB", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 336, Nazwa = "PIANKA PLAY E", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 337, Nazwa = "PIANKA PLAY E II", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 338, Nazwa = "PIANKA PLAY E L/P", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 339, Nazwa = "PIANKA PLAY OTM II PC", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 340, Nazwa = "PIANKA PLAY OTMD II P", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 341, Nazwa = "PIANKA PLAY OTMPC", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 342, Nazwa = "PIANKA PLAY TB", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 343, Nazwa = "PIANKA P£ .RF-4040 2 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 344, Nazwa = "PIANKA P£ .RF-4040 4 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 345, Nazwa = "PIANKA P£. R-3028 *12*", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 346, Nazwa = "PIANKA P£. R-3028 *13*", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 347, Nazwa = "PIANKA P£. R-3028 *14*", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 348, Nazwa = "PIANKA P£.R-110 10D", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 349, Nazwa = "PIANKA P£YTA  R-30120 12*", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 350, Nazwa = "PIANKA P£YTA  T-18 *1*", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 351, Nazwa = "PIANKA P£YTA CMHR 50/250 1000", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 352, Nazwa = "PIANKA P£YTA N-1828 -1*", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 353, Nazwa = "PIANKA P£YTA N-2520 8 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 354, Nazwa = "PIANKA P£YTA N-2538 8 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 355, Nazwa = "PIANKA P£YTA POLIUR.T-25/32 *6", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 356, Nazwa = "PIANKA P£YTA POLIUR.T-25/32 *8", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 357, Nazwa = "PIANKA P£YTA POLIUR.VP-35/30 *14", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 358, Nazwa = "PIANKA P£YTA POLIUR.VP-42/050 1200*12 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 359, Nazwa = "PIANKA P£YTA POLIUR.VP-42/050 1200*13 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 360, Nazwa = "PIANKA P£YTA POLIUR.VP-42/050 1200*5 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 361, Nazwa = "PIANKA P£YTA POLIURET. 35/32 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 362, Nazwa = "PIANKA P£YTA POLIURET. 35/38 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 363, Nazwa = "PIANKA P£YTA POLIURET. 42/50 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 364, Nazwa = "PIANKA P£YTA R-2525 6 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 365, Nazwa = "PIANKA P£YTA R4442", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 366, Nazwa = "PIANKA P£YTA REBOND 110 1CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 367, Nazwa = "PIANKA P£YTA REBOND 110 2CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 368, Nazwa = "PIANKA P£YTA T -30/110 *3* HR (1200)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 369, Nazwa = "PIANKA P£YTA T-30/110 *2* HR (1200)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 370, Nazwa = "PIANKA P£YTA T-30/110 *3* HR (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 371, Nazwa = "PIANKA P£YTA T-30/110 *4* HR (1200)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 372, Nazwa = "PIANKA P£YTA T-30/110 *5* HR (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 373, Nazwa = "PIANKA P£YTA T-30/110 *6* HR (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 374, Nazwa = "PIANKA P£YTA T-30/110 *8* HR (1600)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 375, Nazwa = "PIANKA P£YTA T-30/110*12* HR (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 376, Nazwa = "PIANKA P£YTA T-35 *7*(120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 377, Nazwa = "PIANKA P£YTA T-35/180  *8* (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 378, Nazwa = "PIANKA P£YTA T-35/180 *10* (140)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 379, Nazwa = "PIANKA P£YTA T-35/180 *10*(120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 380, Nazwa = "PIANKA P£YTA T-35/180 *12* (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 381, Nazwa = "PIANKA P£YTA T-35/180 *15*(120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 382, Nazwa = "PIANKA P£YTA T-35/180 *2* (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 383, Nazwa = "PIANKA P£YTA T-35/180 *3* (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 384, Nazwa = "PIANKA P£YTA T-35/180 *4*(120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 385, Nazwa = "PIANKA P£YTA T-35/180 *5* (160)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 386, Nazwa = "PIANKA P£YTA T-35/180 *5*(120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 387, Nazwa = "PIANKA P£YTA T-35/180 *5*(160)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 388, Nazwa = "PIANKA P£YTA T-35/180 *6* (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 389, Nazwa = "PIANKA P£YTA T-35/180 *7*", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 390, Nazwa = "PIANKA P£YTA T-35/180 *8* (120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 391, Nazwa = "PIANKA P£YTA T-35/180 *8* (160)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 392, Nazwa = "PIANKA P£YTA T-40/050 *1200*3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 393, Nazwa = "PIANKA P£YTA T-40/050 *1200*5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 394, Nazwa = "PIANKA P£YTA T-40/050 *1200*6", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 395, Nazwa = "PIANKA P£YTA T-40/050 *1200*7", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 396, Nazwa = "PIANKA P£YTA T-40/050 *1200*8", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 397, Nazwa = "PIANKA P£YTA T-40/050 *1600*5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 398, Nazwa = "PIANKA P£YTY 25/23 *5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 399, Nazwa = "PIANKA P£YTY 25/32 *8", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 400, Nazwa = "PIANKA P£YTY 35/030 1600*10", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 401, Nazwa = "PIANKA P£YTY 40/038 CMHR 1200*12", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 402, Nazwa = "PIANKA P£YTY 40/038 CMHR 1200*15", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 403, Nazwa = "PIANKA P£YTY 40/038 CMHR 1200*2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 404, Nazwa = "PIANKA P£YTY CME 25/120 1200*2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 405, Nazwa = "PIANKA P£YTY CME 25/120 1200*3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 406, Nazwa = "PIANKA P£YTY CME 25/120 1200*4", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 407, Nazwa = "PIANKA P£YTY CME 25/120 1200*5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 408, Nazwa = "PIANKA P£YTY CME 25/120 1200*8", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 409, Nazwa = "PIANKA P£YTY HR 30 2000X1200X130", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 410, Nazwa = "PIANKA P£YTY HR 30 2000X1200X20", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 411, Nazwa = "PIANKA P£YTY HR 30 2000X1200X30", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 412, Nazwa = "PIANKA P£YTY HR 30 2000X1200X40", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 413, Nazwa = "PIANKA P£YTY HR 30 2000X1200X50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 414, Nazwa = "PIANKA P£YTY HR 30/010 1200*2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 415, Nazwa = "PIANKA P£YTY HR 30/010 1200*3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 416, Nazwa = "PIANKA P£YTY HR 30/010 1480*3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 417, Nazwa = "PIANKA P£YTY HR 30/010 1600*4", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 418, Nazwa = "PIANKA P£YTY HR 30/110 120 *2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 419, Nazwa = "PIANKA P£YTY HR 30/110 120 *3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 420, Nazwa = "PIANKA P£YTY HR 30/110 120 *4", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 421, Nazwa = "PIANKA P£YTY HR 30/110 1200", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 422, Nazwa = "PIANKA P£YTY HR 30/110 160 *8", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 423, Nazwa = "PIANKA P£YTY HR 35/38 1200 *12CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 424, Nazwa = "PIANKA P£YTY HR 35/38 1200 *15CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 425, Nazwa = "PIANKA P£YTY HR 35/38 1200 *5CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 426, Nazwa = "PIANKA P£YTY HR 42/050 1200*10", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 427, Nazwa = "PIANKA P£YTY HR 42/050 1200*12", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 428, Nazwa = "PIANKA P£YTY REBOND 110 *1", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 429, Nazwa = "PIANKA P£YTY REBOND 110 *3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 430, Nazwa = "PIANKA P£YTY REBOND 110*2*(120)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 431, Nazwa = "PIANKA P£YTY T-18 (NIEPALNA)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 432, Nazwa = "PIANKA P£YTY T-18 2000X1200X10", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 433, Nazwa = "PIANKA P£YTY T-35 2000X1200X20", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 434, Nazwa = "PIANKA P£YTY T-35 2000X1200X30", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 435, Nazwa = "PIANKA P£YTY T-35 2000X1200X40", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 436, Nazwa = "PIANKA P£YTY T-35 2000X1200X50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 437, Nazwa = "PIANKA P£YTY T-35 2000X1200X80", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 438, Nazwa = "PIANKA P£YTY T-35/30 *10* (1530)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 439, Nazwa = "PIANKA P£YTY T-35/30 *12* (1530)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 440, Nazwa = "PIANKA P£YTY VP-35/30", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 441, Nazwa = "PIANKA P£YTY VP-35/30*12", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 442, Nazwa = "PIANKA POLIE. SONG 1,5 MM *1,80 (350MB)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 443, Nazwa = "PIANKA POLIE. SONG 2,0 MM *1,25 (150MB)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 444, Nazwa = "PIANKA POLIE. SONG 2,0 MM *1,50 (180MB)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 445, Nazwa = "PIANKA POLIE. SONG 3,0 MM *1,55 (175MB)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 446, Nazwa = "PIANKA SAN REMO 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 447, Nazwa = "PIANKA SAN REMO 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 448, Nazwa = "PIANKA SAN REMO 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 449, Nazwa = "PIANKA SAN REMO HO 60*90", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 450, Nazwa = "PIANKA SAN REMO HO 80*80", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 451, Nazwa = "PIANKA SAN REMO ISL UNIW", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 452, Nazwa = "PIANKA SAN REMO LD 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 453, Nazwa = "PIANKA SAN REMO LD 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 454, Nazwa = "PIANKA SAN REMO LD 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 455, Nazwa = "PIANKA SAN REMO LD H", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 456, Nazwa = "PIANKA SAN REMO OT UNIW", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 457, Nazwa = "PIANKA SAN REMO OTM UNIW", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 458, Nazwa = "PIANKA SAN REMO OTS UNIW", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 459, Nazwa = "PIANKA SEATTLE 1,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 460, Nazwa = "PIANKA SEATTLE 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 461, Nazwa = "PIANKA SEATTLE 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 462, Nazwa = "PIANKA SEATTLE 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 463, Nazwa = "PIANKA SEATTLE EOT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 464, Nazwa = "PIANKA SEATTLE HO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 465, Nazwa = "PIANKA SEATTLE RE", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 466, Nazwa = "PIANKA SEATTLE UCHO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 467, Nazwa = "PIANKA TRENTO 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 468, Nazwa = "PIANKA TRENTO 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 469, Nazwa = "PIANKA TRENTO 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 470, Nazwa = "PIANKA TRENTO OT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 471, Nazwa = "PIANKA TRENTO UCHO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 472, Nazwa = "PIANKA WL 2,5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 473, Nazwa = "PIANKA WL HO", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 474, Nazwa = "PIANKA WL OTM UNIW", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 475, Nazwa = "PIANKAPLAY 2 SLC/SPC", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 476, Nazwa = "PIANKI P£YTA 40/50 1200 *3 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 477, Nazwa = "PIANKI P£YTA 40/50 1200 *5 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 478, Nazwa = "PIANKI P£YTA 40/50 1200 *6 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 479, Nazwa = "PIANKI P£YTA 40/50 1200 *7 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 480, Nazwa = "PIANKI P£YTA 40/50 1200 *8 CM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 481, Nazwa = "PIANNKA BLOK T-35 2000X1200X1200", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 482, Nazwa = "PIERåCIE— OZDOBNY", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 483, Nazwa = "P£.WI”ROWA ZW.15*2800*2070", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 484, Nazwa = "P£YTA POLIUR. T-18/130 1", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 485, Nazwa = "P£YTA POLIUR. T-30/110 2 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 486, Nazwa = "P£YTA POLIUR. T-30/110 4 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 487, Nazwa = "P£YTA POLIUR. T-30/110 5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 488, Nazwa = "P£YTA POLIUR. T-30/110 6", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 489, Nazwa = "P£YTA POLIUR. T-35/180 12", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 490, Nazwa = "P£YTA POLIUR. T-35/180 15", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 491, Nazwa = "P£YTA POLIUR. T-35/180 2", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 492, Nazwa = "P£YTA POLIUR. T-35/180 3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 493, Nazwa = "P£YTA POLIUR. T-35/180 4", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 494, Nazwa = "P£YTA POLIUR. T-35/180 5", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 495, Nazwa = "P£YTA POLIUR. T-35/180 6", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 496, Nazwa = "P£YTA POLIUR. T-35/180 8", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 497, Nazwa = "P£YTA POLIUR. VP-25/065 2 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 498, Nazwa = "P£YTA POLIUR. VP-25/065 3 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 499, Nazwa = "P£YTA POLIUR. VP-25/065 4 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 500, Nazwa = "P£YTA POLIUR. VP-25/065 5 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 501, Nazwa = "P£YTA POLIUR. VP-35/32  13 HR 1200", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 502, Nazwa = "P£YTA POLIUR. VP-42/050  12 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 503, Nazwa = "P£YTA POLIURET. T-30/110 5 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 504, Nazwa = "P£YTA POLIURETANOWA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 505, Nazwa = "P£YTA POLUR. VP-35/032 16 HR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 506, Nazwa = "P£YTA TWARDA", JednostkaMiaryRefId = 4, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 507, Nazwa = "P£YTA TWARDA  GR.2,5X1620X2720", JednostkaMiaryRefId = 4, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 508, Nazwa = "P£YTA TWARDA GR.2,0X1220MM BARWIONA", JednostkaMiaryRefId = 4, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 509, Nazwa = "P£YTA WI”ROWA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 510, Nazwa = "P£YTA WI”ROWA SUROWA 15/2800/2070", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 511, Nazwa = "P£YTA WI”ROWA SUROWA 15/2840/1830 MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 512, Nazwa = "PODK£ADKA PLASTIKOWA P-50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 513, Nazwa = "PODSTAWA ALUMINIOWA 20-03-0041-60", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 514, Nazwa = "PODSTAWA CHROMOWANA, OBROTOWA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 515, Nazwa = "PROFIL 12 MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 516, Nazwa = "PROFIL METALOWY DO NIEWIDO. MOCOW. MAT.", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 517, Nazwa = "PROFIL PIANKOWY P”£OK•G£Y SZARY 70X35 MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 518, Nazwa = "RZEP U8BRANIOWY 20MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 519, Nazwa = "RZEP UBR.P TLA 40MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 520, Nazwa = "RZEP UBRANIOWY 30 MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 521, Nazwa = "RZEP UBRANIOWY 40 MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 522, Nazwa = "RZEP UBRANIOWY 50 MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 523, Nazwa = "RZEP UBRANIOWY HACZY 40 MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 524, Nazwa = "SKLEJKA 15,0MM 2130*1250 MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 525, Nazwa = "SKLEJKA 4,0MM 1220*2440 MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 526, Nazwa = "SKLEJKA IGLASTA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 527, Nazwa = "SKLEJKA LIåC. 4 1250 2130 SUCHOTRWA£•", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 528, Nazwa = "SKLEJKA LIåCIASTA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 529, Nazwa = "SKLEJKA LIåCIASTA 15 /2440/1220MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 530, Nazwa = "SKLEJKA LIåCIASTA 15/1525/1525MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 531, Nazwa = "SKLEJKA SOSNA 4,00MM*2130X1250MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 532, Nazwa = "SKLEJKA ST LIåCIASTA 4 1250 2130 SUCHOTR", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 533, Nazwa = "SKLEJKA WD", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 534, Nazwa = "SPR ZYNA FALISTA 360/13", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 535, Nazwa = "SPR ØARKA åRUBOWA AIRPRESS BASIC 15", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 536, Nazwa = "SPR ØYNA FALISTA 380", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 537, Nazwa = "SPR ØYNA FALISTA 520", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 538, Nazwa = "SPR ØYNA FALISTA L-310", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 539, Nazwa = "SPR ØYNA FALISTA L-380", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 540, Nazwa = "SPR ØYNA FALISTA L-420", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 541, Nazwa = "SPR ØYNA FALISTA L-450", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 542, Nazwa = "SPR ØYNA FALISTA L-460", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 543, Nazwa = "SPR ØYNA FALISTA L-480", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 544, Nazwa = "SPR ØYNA FALISTA L-520", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 545, Nazwa = "SPR ØYNA FALISTA L-560", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 546, Nazwa = "SPR ØYNA FALISTA L-600 (STO)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 547, Nazwa = "SPR ØYNA FALISTA L-620", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 548, Nazwa = "SPR ØYNA FALISTA L-650  100", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 549, Nazwa = "SPR ØYNA FALISTA L-700 (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 550, Nazwa = "SPR ØYNA FALISTA W/1584/68/480/17", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 551, Nazwa = "SPR ØYNA FALISTA WF 3,8 X 560 100SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 552, Nazwa = "SPR ØYNA FLAISTA 620", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 553, Nazwa = "SRUBY METRYCZNE", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 554, Nazwa = "SUWAK", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 555, Nazwa = "SUWAK 5 (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 556, Nazwa = "SUWAK 500 SZT. *3", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 557, Nazwa = "SUWAK 500SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 558, Nazwa = "SZNUR PLECIONY 3,4,5,6", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 559, Nazwa = "SZNUR TAPICERSKI GR. 4MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 560, Nazwa = "SZNUR TAPICERSKI GR. 6MM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 561, Nazwa = "SZNUR TAPICERSKI ST-05", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 562, Nazwa = "SZNUR WACIANY 4MM (100MB)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 563, Nazwa = "SZNUR WACIANY 5MM 6103-050", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 564, Nazwa = "SZNUR WACIANY 6 MM 6103-060 (100MB)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 565, Nazwa = "SZNUREK *4Z/R BIA£Y (100M)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 566, Nazwa = "SZNUREK *6Z/RDZ R 10 (100M)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 567, Nazwa = "SZNUREK *6Z/RDZ R-10 9100M)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 568, Nazwa = "SZNUREK 4 W", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 569, Nazwa = "SZNUREK NA P TLE 1300MB/ROLKA", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 570, Nazwa = "SZNUREK ROLNICZY  TEX 1400", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 571, Nazwa = "åLIZG OKR. NA WKR. S-44, TR”JK•T", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 572, Nazwa = "åRUBA M 8*60 OC", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 573, Nazwa = "åRUBA M8X860 105B OC", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 574, Nazwa = "åRUBA MASZYNOWA M8*80OC", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 575, Nazwa = "åRUBA ZAMKOWA M6*40 OC", JednostkaMiaryRefId = 2, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 576, Nazwa = "TARCICA BRZ. N/O 50MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 577, Nazwa = "TARCICA BRZ.26 MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 578, Nazwa = "TARCICA BRZ.N/0 50MM KL. MOKRA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 579, Nazwa = "TARCICA BRZ.N/O45MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 580, Nazwa = "TARCICA BRZ.NIO 50 MM KL.3 SUCHA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 581, Nazwa = "TARCICA BRZOZOWA N/O 48MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 582, Nazwa = "TARCICA BRZOZOWA N/O ZPP. 25,50 GR-5", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 583, Nazwa = "TARCICA BUKOWA CABINET 38(36)MM,3,05", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 584, Nazwa = "TARCICA BUKOWA CABINET 52(48,5)MM 2,45M", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 585, Nazwa = "TARCICA BUKOWA COM SHOP-ROT 26(23,8MM)", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 586, Nazwa = "TARCICA BUKOWA POLLMEIER", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 587, Nazwa = "TARCICA BUKOWA RUSTIC 26", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 588, Nazwa = "TARCICA CABINET", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 589, Nazwa = "TARCICA CABINET/COLOUR", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 590, Nazwa = "TARCICA JESIONOWA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 591, Nazwa = "TARCICA LIåCIASTA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 592, Nazwa = "TARCICA OLCHOWA N/O 48MM", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 593, Nazwa = "TARCICA OLCHOWA N/O ZPP. GR.25-50 GR-8", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 594, Nazwa = "TARCICA SO. N/O 25 MM KL. MIX SUCHA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 595, Nazwa = "TARCICA SO. N/O 50 MM KL. MIX. SUCHA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 596, Nazwa = "TARCICA SO. OB. 25 MM KL. MIX. SUCHA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 597, Nazwa = "TARCICA SOSNA 25X50MM SUCHA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 598, Nazwa = "TARCICA SOSNOWA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 599, Nazwa = "TARCICA åWIERKOWA", JednostkaMiaryRefId = 5, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 600, Nazwa = "TASIEMKA", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 601, Nazwa = "TAåMA 20 MM TKANA BIA£A", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 602, Nazwa = "TAåMA OZDOBNA", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 603, Nazwa = "TAåMA SAMOPRZYLEPNA SMART", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 604, Nazwa = "TAåMA SUWAKOWA (200MB)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 605, Nazwa = "TAåMA SUWAKOWA 200MB *3", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 606, Nazwa = "TAåMA SUWAKOWA 5(100M)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 607, Nazwa = "TAåMA ZAMKOWA (200M)", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 608, Nazwa = "TKANINA", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 609, Nazwa = "UCHWYT MEBLOWY UN51-0128 ALUM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 610, Nazwa = "WIGOFIL 13G/160", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 611, Nazwa = "WIGOFIL 15G/M2 160 CM BIA£Y", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 612, Nazwa = "WIGOFIL 40/M2  160 CM", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 613, Nazwa = "WIGOFIL 50G /160 CM BIA£Y", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 614, Nazwa = "WIGOFIL 60G/M2 CZARNY 0,95 M", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 615, Nazwa = "WIGOFIL 60G/M2 CZARNY 1,6", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 616, Nazwa = "WKR T 4*40", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 617, Nazwa = "WKR T 5*50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 618, Nazwa = "WKR T 5*50 K( 100SZT.)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 619, Nazwa = "WKR T 5*70 -100 SZT.", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 620, Nazwa = "WKR T 5*80  100 SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 621, Nazwa = "WKR T 5*80 K (100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 622, Nazwa = "WKR T DO DREWNA 3,0*30 (100)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 623, Nazwa = "WKR T DO DREWNA 4,0*20 9100SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 624, Nazwa = "WKR T DO DREWNA 4,0*30 WKR T HART. KRZYØ", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 625, Nazwa = "WKR T DO DREWNA 5,0*30 (100)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 626, Nazwa = "WKR T DO DREWNA 5,0*60 KILOPAK", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 627, Nazwa = "WKR T DO DREWNA 8*60 KLUCZ", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 628, Nazwa = "WKR T DO DREWNA 8*80 NAKR", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 629, Nazwa = "WKR T DO DREWNA 8*90 KLUCZ", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 630, Nazwa = "WKR T DO DREWNA JD79 5,0X50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 631, Nazwa = "WKR T DO DREWNA JD79 5,0X70", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 632, Nazwa = "WKR T DO DREWNA KILOPAK 5* 70", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 633, Nazwa = "WKR T DO DREWNW KILOPAK 5*50", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 634, Nazwa = "WKR T M 4*25 W 202", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 635, Nazwa = "WKR T M 4*40 S 280", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 636, Nazwa = "WKR T M 6*25S", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 637, Nazwa = "WKR T M DWUGWINT 8*80 (100)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 638, Nazwa = "W£”KNINA TAPICERSKA 150", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 639, Nazwa = "W£”KNINA TAPICERSKA 250", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 640, Nazwa = "W£”KNINA TAPICERSKA 300", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 641, Nazwa = "W£”KNINA TAPICERSKA 500", JednostkaMiaryRefId = 6, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 642, Nazwa = "WYK£ADZINA", JednostkaMiaryRefId = 4, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 643, Nazwa = "ZACZEP K•TOWY KR”TKI TYP A /1000 SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 644, Nazwa = "ZACZEP K•TOWY TYP A /*1000SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 645, Nazwa = "ZACZEP METALOWY A 100SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 646, Nazwa = "ZACZEP PROSTY TYP A /*1000SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 647, Nazwa = "ZACZEP SPR ØYNY", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 648, Nazwa = "ZACZEP SPR ØYNY FALISTEJ BEZ OGRA. S-49", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 649, Nazwa = "ZACZEP SPR ØYNY FALISTEJ Z OGRA. S-26", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 650, Nazwa = "ZACZEP SPR ØYNY Z NOSKIEM", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 651, Nazwa = "ZSZYWKI 14/25 ZP", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 652, Nazwa = "ZSZYWKI 14/30 Z TYS", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 653, Nazwa = "ZSZYWKI 14/35 Z", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 654, Nazwa = "ZSZYWKI 14/38 Ø   -1000 SZT", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 655, Nazwa = "ZSZYWKI 14/45 Z TYS.", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 656, Nazwa = "ZSZYWKI 380/04 (TYS)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 657, Nazwa = "ZSZYWKI 380/06 (1000SZT)", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 658, Nazwa = "ZSZYWKI 380/10", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });
                //magPozycjaMagazynowaList.Add(new MagPozycjaMagazynowa { MagPozycjaMagazynowaId = 659, Nazwa = "ZSZYWKI 380/14- TYS", JednostkaMiaryRefId = 8, GrupaZakladowaRefId = 1, TypTowaru = 2, VatSprzedazyRefId = 1, VatZakupuRefId = 1, MarzaZakladowaRefId = 1 });


                //foreach (var item in magPozycjaMagazynowaList)
                //{
                //    context.MagPozycjaMagazynowa.AddOrUpdate(item);
                //}

                List<MaterialGrupaKontrahent> materialGrupaList = new List<MaterialGrupaKontrahent>();
                materialGrupaList.Add(new MaterialGrupaKontrahent { MaterialGrupaKontrahentId = 1, Nazwa = "Andpol" });
                materialGrupaList.Add(new MaterialGrupaKontrahent { MaterialGrupaKontrahentId = 2, Nazwa = "BOCX" });
                materialGrupaList.Add(new MaterialGrupaKontrahent { MaterialGrupaKontrahentId = 3, Nazwa = "ROFRA" });
                materialGrupaList.Add(new MaterialGrupaKontrahent { MaterialGrupaKontrahentId = 4, Nazwa = "URBAN" });


                foreach (var item in materialGrupaList)
                {
                    context.MaterialGrupaKontrahent.AddOrUpdate(item);
                }

                context.SaveChanges();



                List<Material> matLista = new List<Material>();

                matLista.Add(new Material { MaterialId = 1, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 100" });
                matLista.Add(new Material { MaterialId = 2, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 101" });
                matLista.Add(new Material { MaterialId = 3, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 102" });
                matLista.Add(new Material { MaterialId = 4, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 103" });
                matLista.Add(new Material { MaterialId = 5, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 200" });
                matLista.Add(new Material { MaterialId = 6, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 700" });
                matLista.Add(new Material { MaterialId = 7, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 800" });
                matLista.Add(new Material { MaterialId = 8, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 801" });
                matLista.Add(new Material { MaterialId = 9, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 802" });
                matLista.Add(new Material { MaterialId = 10, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 902" });
                matLista.Add(new Material { MaterialId = 11, MaterialGrupaRefId = 1, Nazwa = "AMARILLO - 904" });
                matLista.Add(new Material { MaterialId = 12, MaterialGrupaRefId = 1, Nazwa = "AMBON - 17" });
                matLista.Add(new Material { MaterialId = 13, MaterialGrupaRefId = 1, Nazwa = "AMBON - 11 CAPPUCINO" });
                matLista.Add(new Material { MaterialId = 14, MaterialGrupaRefId = 1, Nazwa = "AMBON - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 15, MaterialGrupaRefId = 1, Nazwa = "AMBON - 169 ONYX" });
                matLista.Add(new Material { MaterialId = 16, MaterialGrupaRefId = 1, Nazwa = "AMBON - 18 DARKBROWN" });
                matLista.Add(new Material { MaterialId = 17, MaterialGrupaRefId = 1, Nazwa = "AMBON - 35 RED" });
                matLista.Add(new Material { MaterialId = 18, MaterialGrupaRefId = 1, Nazwa = "AMBON - 5 BEIGE" });
                matLista.Add(new Material { MaterialId = 19, MaterialGrupaRefId = 1, Nazwa = "AMBON - 61 BLACK" });
                matLista.Add(new Material { MaterialId = 20, MaterialGrupaRefId = 1, Nazwa = "AMBON - 65 GREY" });
                matLista.Add(new Material { MaterialId = 21, MaterialGrupaRefId = 1, Nazwa = "AMBON - 67 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 22, MaterialGrupaRefId = 1, Nazwa = "ANCONA - 0035 ARCTIC WHITE" });
                matLista.Add(new Material { MaterialId = 23, MaterialGrupaRefId = 1, Nazwa = "ANCONA - 0964 RAW LINEN" });
                matLista.Add(new Material { MaterialId = 24, MaterialGrupaRefId = 1, Nazwa = "ARENA - 100 BLACK" });
                matLista.Add(new Material { MaterialId = 25, MaterialGrupaRefId = 1, Nazwa = "ARENA - 102 DARK GREY" });
                matLista.Add(new Material { MaterialId = 26, MaterialGrupaRefId = 1, Nazwa = "ARENA - 104 GREY" });
                matLista.Add(new Material { MaterialId = 27, MaterialGrupaRefId = 1, Nazwa = "ARENA - 200 ECRU" });
                matLista.Add(new Material { MaterialId = 28, MaterialGrupaRefId = 1, Nazwa = "ARENA - 201 IVORY" });
                matLista.Add(new Material { MaterialId = 29, MaterialGrupaRefId = 1, Nazwa = "ARENA - 217 WHITE" });
                matLista.Add(new Material { MaterialId = 30, MaterialGrupaRefId = 1, Nazwa = "ARENA - 300 RED" });
                matLista.Add(new Material { MaterialId = 31, MaterialGrupaRefId = 1, Nazwa = "BIRMINGHAM - 04 SAND" });
                matLista.Add(new Material { MaterialId = 32, MaterialGrupaRefId = 1, Nazwa = "BIRMINGHAM - 117 GREY-BLACK" });
                matLista.Add(new Material { MaterialId = 33, MaterialGrupaRefId = 1, Nazwa = "BIRMINGHAM - 17 BLACK" });
                matLista.Add(new Material { MaterialId = 34, MaterialGrupaRefId = 1, Nazwa = "BIRMINGHAM - 484 DARK GREY" });
                matLista.Add(new Material { MaterialId = 35, MaterialGrupaRefId = 1, Nazwa = "BIRMINGHAM - 95 LAVENDEL" });
                matLista.Add(new Material { MaterialId = 36, MaterialGrupaRefId = 1, Nazwa = "BOARD - 139" });
                matLista.Add(new Material { MaterialId = 37, MaterialGrupaRefId = 1, Nazwa = "BOARD - 167" });
                matLista.Add(new Material { MaterialId = 38, MaterialGrupaRefId = 1, Nazwa = "BOARD - 169" });
                matLista.Add(new Material { MaterialId = 39, MaterialGrupaRefId = 1, Nazwa = "BOARD - 41" });
                matLista.Add(new Material { MaterialId = 40, MaterialGrupaRefId = 1, Nazwa = "BOARD - 74" });
                matLista.Add(new Material { MaterialId = 41, MaterialGrupaRefId = 1, Nazwa = "BOARD - 84" });
                matLista.Add(new Material { MaterialId = 42, MaterialGrupaRefId = 1, Nazwa = "BOARD - 1 NATUREL" });
                matLista.Add(new Material { MaterialId = 43, MaterialGrupaRefId = 1, Nazwa = "BOARD - 10 LIVER" });
                matLista.Add(new Material { MaterialId = 44, MaterialGrupaRefId = 1, Nazwa = "BOARD - 12 TAUPE" });
                matLista.Add(new Material { MaterialId = 45, MaterialGrupaRefId = 1, Nazwa = "BOARD - 123/17-03-2012" });
                matLista.Add(new Material { MaterialId = 46, MaterialGrupaRefId = 1, Nazwa = "BOARD - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 47, MaterialGrupaRefId = 1, Nazwa = "BOARD - 17 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 48, MaterialGrupaRefId = 1, Nazwa = "BOARD - 18 DARK BROWN" });
                matLista.Add(new Material { MaterialId = 49, MaterialGrupaRefId = 1, Nazwa = "BOARD - 35 RED" });
                matLista.Add(new Material { MaterialId = 50, MaterialGrupaRefId = 1, Nazwa = "BOARD - 49 NAVY" });
                matLista.Add(new Material { MaterialId = 51, MaterialGrupaRefId = 1, Nazwa = "BOARD - 5 BEIGE" });
                matLista.Add(new Material { MaterialId = 52, MaterialGrupaRefId = 1, Nazwa = "BOARD - 50 MINT" });
                matLista.Add(new Material { MaterialId = 53, MaterialGrupaRefId = 1, Nazwa = "BOARD - 56 PETROL" });
                matLista.Add(new Material { MaterialId = 54, MaterialGrupaRefId = 1, Nazwa = "BOARD - 57 LIME" });
                matLista.Add(new Material { MaterialId = 55, MaterialGrupaRefId = 1, Nazwa = "BOARD - 60 LIGHTGREY" });
                matLista.Add(new Material { MaterialId = 56, MaterialGrupaRefId = 1, Nazwa = "BOARD - 65 GREY" });
                matLista.Add(new Material { MaterialId = 57, MaterialGrupaRefId = 1, Nazwa = "BOARD - 66 GRAPHITE" });
                matLista.Add(new Material { MaterialId = 58, MaterialGrupaRefId = 1, Nazwa = "BOARD - 67 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 59, MaterialGrupaRefId = 1, Nazwa = "BOARD - 68 DARK GREY" });
                matLista.Add(new Material { MaterialId = 60, MaterialGrupaRefId = 1, Nazwa = "BOARD - 77 FUCHSIA" });
                matLista.Add(new Material { MaterialId = 61, MaterialGrupaRefId = 1, Nazwa = "BOARD - 78 PURPLE" });
                matLista.Add(new Material { MaterialId = 62, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 3315" });
                matLista.Add(new Material { MaterialId = 63, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 5247" });
                matLista.Add(new Material { MaterialId = 64, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 5250" });
                matLista.Add(new Material { MaterialId = 65, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 5265" });
                matLista.Add(new Material { MaterialId = 66, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 5290" });
                matLista.Add(new Material { MaterialId = 67, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 5291" });
                matLista.Add(new Material { MaterialId = 68, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 9312" });
                matLista.Add(new Material { MaterialId = 69, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 9318" });
                matLista.Add(new Material { MaterialId = 70, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 9430" });
                matLista.Add(new Material { MaterialId = 71, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 9508" });
                matLista.Add(new Material { MaterialId = 72, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 9640" });
                matLista.Add(new Material { MaterialId = 73, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 9664" });
                matLista.Add(new Material { MaterialId = 74, MaterialGrupaRefId = 1, Nazwa = "BOLTON - 9726" });
                matLista.Add(new Material { MaterialId = 75, MaterialGrupaRefId = 1, Nazwa = "BREAK - 01 NATUREL" });
                matLista.Add(new Material { MaterialId = 76, MaterialGrupaRefId = 1, Nazwa = "BREAK - 02 CREAM" });
                matLista.Add(new Material { MaterialId = 77, MaterialGrupaRefId = 1, Nazwa = "BREAK - 05 BEIGE" });
                matLista.Add(new Material { MaterialId = 78, MaterialGrupaRefId = 1, Nazwa = "BREAK - 10 LIVER" });
                matLista.Add(new Material { MaterialId = 79, MaterialGrupaRefId = 1, Nazwa = "BREAK - 12 TAUPE" });
                matLista.Add(new Material { MaterialId = 80, MaterialGrupaRefId = 1, Nazwa = "BREAK - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 81, MaterialGrupaRefId = 1, Nazwa = "BREAK - 169 ONYX" });
                matLista.Add(new Material { MaterialId = 82, MaterialGrupaRefId = 1, Nazwa = "BREAK - 17 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 83, MaterialGrupaRefId = 1, Nazwa = "BREAK - 18 DARKBROWN" });
                matLista.Add(new Material { MaterialId = 84, MaterialGrupaRefId = 1, Nazwa = "BREAK - 25 ORANGE" });
                matLista.Add(new Material { MaterialId = 85, MaterialGrupaRefId = 1, Nazwa = "BREAK - 35 RED" });
                matLista.Add(new Material { MaterialId = 86, MaterialGrupaRefId = 1, Nazwa = "BREAK - 39 WINERED" });
                matLista.Add(new Material { MaterialId = 87, MaterialGrupaRefId = 1, Nazwa = "BREAK - 45 BLUE" });
                matLista.Add(new Material { MaterialId = 88, MaterialGrupaRefId = 1, Nazwa = "BREAK - 53 OLIVE" });
                matLista.Add(new Material { MaterialId = 89, MaterialGrupaRefId = 1, Nazwa = "BREAK - 65 GREY" });
                matLista.Add(new Material { MaterialId = 90, MaterialGrupaRefId = 1, Nazwa = "BREAK - 67 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 91, MaterialGrupaRefId = 1, Nazwa = "BREAK - 74 AUBERGINE" });
                matLista.Add(new Material { MaterialId = 92, MaterialGrupaRefId = 1, Nazwa = "BREAK - 76 PRUNE" });
                matLista.Add(new Material { MaterialId = 93, MaterialGrupaRefId = 1, Nazwa = "BREAK - 77 FUCHSIA" });
                matLista.Add(new Material { MaterialId = 94, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 110" });
                matLista.Add(new Material { MaterialId = 95, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 2222" });
                matLista.Add(new Material { MaterialId = 96, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 2744" });
                matLista.Add(new Material { MaterialId = 97, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 2755" });
                matLista.Add(new Material { MaterialId = 98, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 3470" });
                matLista.Add(new Material { MaterialId = 99, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 4210" });
                matLista.Add(new Material { MaterialId = 100, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 6680" });
                matLista.Add(new Material { MaterialId = 101, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 7718" });
                matLista.Add(new Material { MaterialId = 102, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 8351" });
                matLista.Add(new Material { MaterialId = 103, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 800 WHITE" });
                matLista.Add(new Material { MaterialId = 104, MaterialGrupaRefId = 1, Nazwa = "BRONCO - 8720 IVORY" });
                matLista.Add(new Material { MaterialId = 105, MaterialGrupaRefId = 1, Nazwa = "BRONCO - BRUIN" });
                matLista.Add(new Material { MaterialId = 106, MaterialGrupaRefId = 1, Nazwa = "CASA - 67" });
                matLista.Add(new Material { MaterialId = 107, MaterialGrupaRefId = 1, Nazwa = "CASA - 03 SAND" });
                matLista.Add(new Material { MaterialId = 108, MaterialGrupaRefId = 1, Nazwa = "CASA - 06 MUSTARD" });
                matLista.Add(new Material { MaterialId = 109, MaterialGrupaRefId = 1, Nazwa = "CASA - 12 TAUPE" });
                matLista.Add(new Material { MaterialId = 110, MaterialGrupaRefId = 1, Nazwa = "CASA - 158 NIAGARA" });
                matLista.Add(new Material { MaterialId = 111, MaterialGrupaRefId = 1, Nazwa = "CASA - 180 DOLPHIN" });
                matLista.Add(new Material { MaterialId = 112, MaterialGrupaRefId = 1, Nazwa = "CASA - 65 GREY" });
                matLista.Add(new Material { MaterialId = 113, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 32" });
                matLista.Add(new Material { MaterialId = 114, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 35" });
                matLista.Add(new Material { MaterialId = 115, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 72" });
                matLista.Add(new Material { MaterialId = 116, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 03 IVORY" });
                matLista.Add(new Material { MaterialId = 117, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 05 CAMEL" });
                matLista.Add(new Material { MaterialId = 118, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 06 MACCIATO" });
                matLista.Add(new Material { MaterialId = 119, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 115 SILVER-GREY" });
                matLista.Add(new Material { MaterialId = 120, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 121 SILVER" });
                matLista.Add(new Material { MaterialId = 121, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 15 LIGHT BROWN" });
                matLista.Add(new Material { MaterialId = 122, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 16 DARK BROWN" });
                matLista.Add(new Material { MaterialId = 123, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 17 BLACK" });
                matLista.Add(new Material { MaterialId = 124, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 19 BEIGE-BLACK" });
                matLista.Add(new Material { MaterialId = 125, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 210 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 126, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 23 MAGENTIS OCRE" });
                matLista.Add(new Material { MaterialId = 127, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 250 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 128, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 260 CHOCO-BROWN" });
                matLista.Add(new Material { MaterialId = 129, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 41 PURPLE" });
                matLista.Add(new Material { MaterialId = 130, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 429 GREEN" });
                matLista.Add(new Material { MaterialId = 131, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 45 GREY" });
                matLista.Add(new Material { MaterialId = 132, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 516 CHARCOAL" });
                matLista.Add(new Material { MaterialId = 133, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 517 DEEP BLACK" });
                matLista.Add(new Material { MaterialId = 134, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 709 ARGENT" });
                matLista.Add(new Material { MaterialId = 135, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 754 ANTHRACITE" });
                matLista.Add(new Material { MaterialId = 136, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 8 BROWN" });
                matLista.Add(new Material { MaterialId = 137, MaterialGrupaRefId = 1, Nazwa = "FLORIDA - 845 LOUD RED" });
                matLista.Add(new Material { MaterialId = 138, MaterialGrupaRefId = 1, Nazwa = "JUKE - 12" });
                matLista.Add(new Material { MaterialId = 139, MaterialGrupaRefId = 1, Nazwa = "JUKE - 149" });
                matLista.Add(new Material { MaterialId = 140, MaterialGrupaRefId = 1, Nazwa = "JUKE - 156" });
                matLista.Add(new Material { MaterialId = 141, MaterialGrupaRefId = 1, Nazwa = "JUKE - 51" });
                matLista.Add(new Material { MaterialId = 142, MaterialGrupaRefId = 1, Nazwa = "JUKE - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 143, MaterialGrupaRefId = 1, Nazwa = "JUKE - 160 MAGNOLIA" });
                matLista.Add(new Material { MaterialId = 144, MaterialGrupaRefId = 1, Nazwa = "JUKE - 169 ONYX" });
                matLista.Add(new Material { MaterialId = 145, MaterialGrupaRefId = 1, Nazwa = "JUKE - 2 CREAM" });
                matLista.Add(new Material { MaterialId = 146, MaterialGrupaRefId = 1, Nazwa = "JUKE - 25 ORANGE" });
                matLista.Add(new Material { MaterialId = 147, MaterialGrupaRefId = 1, Nazwa = "JUKE - 37 BORDEUX" });
                matLista.Add(new Material { MaterialId = 148, MaterialGrupaRefId = 1, Nazwa = "JUKE - 65 GREY" });
                matLista.Add(new Material { MaterialId = 149, MaterialGrupaRefId = 1, Nazwa = "JUKE - 67 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 150, MaterialGrupaRefId = 1, Nazwa = "JUKE - 71 LAVENDER" });
                matLista.Add(new Material { MaterialId = 151, MaterialGrupaRefId = 1, Nazwa = "JUKE - 78 PURPLE" });
                matLista.Add(new Material { MaterialId = 152, MaterialGrupaRefId = 1, Nazwa = "JUKE - 79 CHARCOAL" });
                matLista.Add(new Material { MaterialId = 153, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 02 CREAM" });
                matLista.Add(new Material { MaterialId = 154, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 06 NOUGAT" });
                matLista.Add(new Material { MaterialId = 155, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 16 DARK BROWN" });
                matLista.Add(new Material { MaterialId = 156, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 210 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 157, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 235 MOCCA" });
                matLista.Add(new Material { MaterialId = 158, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 3 WHITE" });
                matLista.Add(new Material { MaterialId = 159, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 32 RED" });
                matLista.Add(new Material { MaterialId = 160, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 35 CHERRY" });
                matLista.Add(new Material { MaterialId = 161, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 50 ORANGE" });
                matLista.Add(new Material { MaterialId = 162, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 740 ELEPHANT" });
                matLista.Add(new Material { MaterialId = 163, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 755 DARK -GREY" });
                matLista.Add(new Material { MaterialId = 164, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 780 BLACK" });
                matLista.Add(new Material { MaterialId = 165, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 845 LOUD RED" });
                matLista.Add(new Material { MaterialId = 166, MaterialGrupaRefId = 1, Nazwa = "KAIMAN - 95 NEW BEIGE" });
                matLista.Add(new Material { MaterialId = 167, MaterialGrupaRefId = 1, Nazwa = "KISS - 166" });
                matLista.Add(new Material { MaterialId = 168, MaterialGrupaRefId = 1, Nazwa = "KISS - 14 ARMY" });
                matLista.Add(new Material { MaterialId = 169, MaterialGrupaRefId = 1, Nazwa = "KISS - 181 STONE" });
                matLista.Add(new Material { MaterialId = 170, MaterialGrupaRefId = 1, Nazwa = "KISS - 39 WINERED" });
                matLista.Add(new Material { MaterialId = 171, MaterialGrupaRefId = 1, Nazwa = "KISS - 43 ICEBLUE" });
                matLista.Add(new Material { MaterialId = 172, MaterialGrupaRefId = 1, Nazwa = "KISS - 45 BLUE" });
                matLista.Add(new Material { MaterialId = 173, MaterialGrupaRefId = 1, Nazwa = "KISS - 65 GREY" });
                matLista.Add(new Material { MaterialId = 174, MaterialGrupaRefId = 1, Nazwa = "KISS - 66 GRAPHITE" });
                matLista.Add(new Material { MaterialId = 175, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 102" });
                matLista.Add(new Material { MaterialId = 176, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 113" });
                matLista.Add(new Material { MaterialId = 177, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 104 WHITE" });
                matLista.Add(new Material { MaterialId = 178, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 110 LIVER" });
                matLista.Add(new Material { MaterialId = 179, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 124 SHITAKE" });
                matLista.Add(new Material { MaterialId = 180, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 14K" });
                matLista.Add(new Material { MaterialId = 181, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 168 PLUM" });
                matLista.Add(new Material { MaterialId = 182, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 17K BROWN" });
                matLista.Add(new Material { MaterialId = 183, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 181 STONE" });
                matLista.Add(new Material { MaterialId = 184, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 65 GREY" });
                matLista.Add(new Material { MaterialId = 185, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 82D" });
                matLista.Add(new Material { MaterialId = 186, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 89D OUDROSE" });
                matLista.Add(new Material { MaterialId = 187, MaterialGrupaRefId = 1, Nazwa = "MONFORT - 916 NATUREL" });
                matLista.Add(new Material { MaterialId = 188, MaterialGrupaRefId = 1, Nazwa = "MONFORT - BH2 DONKERBRUIN" });
                matLista.Add(new Material { MaterialId = 189, MaterialGrupaRefId = 1, Nazwa = "MONFORT - BH4 DARKGREY" });
                matLista.Add(new Material { MaterialId = 190, MaterialGrupaRefId = 1, Nazwa = "MOON - 1" });
                matLista.Add(new Material { MaterialId = 191, MaterialGrupaRefId = 1, Nazwa = "MOON - 2" });
                matLista.Add(new Material { MaterialId = 192, MaterialGrupaRefId = 1, Nazwa = "MOON - 5" });
                matLista.Add(new Material { MaterialId = 193, MaterialGrupaRefId = 1, Nazwa = "MOON - 03 SAND" });
                matLista.Add(new Material { MaterialId = 194, MaterialGrupaRefId = 1, Nazwa = "MOON - 102 ECRU" });
                matLista.Add(new Material { MaterialId = 195, MaterialGrupaRefId = 1, Nazwa = "MOON - 104 MOON WHITE" });
                matLista.Add(new Material { MaterialId = 196, MaterialGrupaRefId = 1, Nazwa = "MOON - 115 LIGHTGREY" });
                matLista.Add(new Material { MaterialId = 197, MaterialGrupaRefId = 1, Nazwa = "MOON - 12 TAUPE" });
                matLista.Add(new Material { MaterialId = 198, MaterialGrupaRefId = 1, Nazwa = "MOON - 140 MAUVE" });
                matLista.Add(new Material { MaterialId = 199, MaterialGrupaRefId = 1, Nazwa = "MOON - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 200, MaterialGrupaRefId = 1, Nazwa = "MOON - 169 ONYX" });
                matLista.Add(new Material { MaterialId = 201, MaterialGrupaRefId = 1, Nazwa = "MOON - 35 RED" });
                matLista.Add(new Material { MaterialId = 202, MaterialGrupaRefId = 1, Nazwa = "MOON - 51 KAKI" });
                matLista.Add(new Material { MaterialId = 203, MaterialGrupaRefId = 1, Nazwa = "MOON - 65 MOON GREY" });
                matLista.Add(new Material { MaterialId = 204, MaterialGrupaRefId = 1, Nazwa = "MOON - 67 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 205, MaterialGrupaRefId = 1, Nazwa = "MOON - 78 PURPLE" });
                matLista.Add(new Material { MaterialId = 206, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 10" });
                matLista.Add(new Material { MaterialId = 207, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 100" });
                matLista.Add(new Material { MaterialId = 208, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 143" });
                matLista.Add(new Material { MaterialId = 209, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 170" });
                matLista.Add(new Material { MaterialId = 210, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 210" });
                matLista.Add(new Material { MaterialId = 211, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 32" });
                matLista.Add(new Material { MaterialId = 212, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 35" });
                matLista.Add(new Material { MaterialId = 213, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 371" });
                matLista.Add(new Material { MaterialId = 214, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 4" });
                matLista.Add(new Material { MaterialId = 215, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 601" });
                matLista.Add(new Material { MaterialId = 216, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 9" });
                matLista.Add(new Material { MaterialId = 217, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 03 IVORY" });
                matLista.Add(new Material { MaterialId = 218, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 05 CAMEL" });
                matLista.Add(new Material { MaterialId = 219, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 06 MACCIATO" });
                matLista.Add(new Material { MaterialId = 220, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 08 BROWN" });
                matLista.Add(new Material { MaterialId = 221, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 1 NATURE" });
                matLista.Add(new Material { MaterialId = 222, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 13 SAHARA" });
                matLista.Add(new Material { MaterialId = 223, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 15 LIGHT BROWN" });
                matLista.Add(new Material { MaterialId = 224, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 16 DARK BROWN" });
                matLista.Add(new Material { MaterialId = 225, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 17 BLACK" });
                matLista.Add(new Material { MaterialId = 226, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 1700 BLUE" });
                matLista.Add(new Material { MaterialId = 227, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 430 BAMBUS" });
                matLista.Add(new Material { MaterialId = 228, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 45 GREY" });
                matLista.Add(new Material { MaterialId = 229, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 49 DARK BLUE" });
                matLista.Add(new Material { MaterialId = 230, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 516 CHARCOAL" });
                matLista.Add(new Material { MaterialId = 231, MaterialGrupaRefId = 1, Nazwa = "NOBEL LUX - 845 LOUD RED" });
                matLista.Add(new Material { MaterialId = 232, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 10" });
                matLista.Add(new Material { MaterialId = 233, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 11" });
                matLista.Add(new Material { MaterialId = 234, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 01 NATUREL" });
                matLista.Add(new Material { MaterialId = 235, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 02 CREAM" });
                matLista.Add(new Material { MaterialId = 236, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 03 SAND" });
                matLista.Add(new Material { MaterialId = 237, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 101 IVORY" });
                matLista.Add(new Material { MaterialId = 238, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 102 ECRU" });
                matLista.Add(new Material { MaterialId = 239, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 12 TAUPE" });
                matLista.Add(new Material { MaterialId = 240, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 123 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 241, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 242, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 169 ONYX" });
                matLista.Add(new Material { MaterialId = 243, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 18 DARKBROWN" });
                matLista.Add(new Material { MaterialId = 244, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 181 STONE" });
                matLista.Add(new Material { MaterialId = 245, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 35 RED" });
                matLista.Add(new Material { MaterialId = 246, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 49 NAVY" });
                matLista.Add(new Material { MaterialId = 247, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 65 GREY" });
                matLista.Add(new Material { MaterialId = 248, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 66 GRAPHITE" });
                matLista.Add(new Material { MaterialId = 249, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 67 ANTRACIET" });
                matLista.Add(new Material { MaterialId = 250, MaterialGrupaRefId = 1, Nazwa = "OLBIA - 74 AUBERGINE" });
                matLista.Add(new Material { MaterialId = 251, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0028 OFF WHITE" });
                matLista.Add(new Material { MaterialId = 252, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0089 SAND" });
                matLista.Add(new Material { MaterialId = 253, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0174 MUSHROOM" });
                matLista.Add(new Material { MaterialId = 254, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0483 BLACKBERRY" });
                matLista.Add(new Material { MaterialId = 255, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0485 TAUPE" });
                matLista.Add(new Material { MaterialId = 256, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0555 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 257, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0574 BROWN" });
                matLista.Add(new Material { MaterialId = 258, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0900 SILVERGREY" });
                matLista.Add(new Material { MaterialId = 259, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 0927 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 260, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 096 WHITE" });
                matLista.Add(new Material { MaterialId = 261, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 1000 BLACK" });
                matLista.Add(new Material { MaterialId = 262, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 10-5010 ROYAL" });
                matLista.Add(new Material { MaterialId = 263, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 10-5018 SEA BLUE" });
                matLista.Add(new Material { MaterialId = 264, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 10-6025 SEA GREEN" });
                matLista.Add(new Material { MaterialId = 265, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 13-2001" });
                matLista.Add(new Material { MaterialId = 266, MaterialGrupaRefId = 1, Nazwa = "RIVIERA - 13-6002 SOFT TURQUOISE" });
                matLista.Add(new Material { MaterialId = 267, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 145" });
                matLista.Add(new Material { MaterialId = 268, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 25" });
                matLista.Add(new Material { MaterialId = 269, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 43" });
                matLista.Add(new Material { MaterialId = 270, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 01 NATUREL" });
                matLista.Add(new Material { MaterialId = 271, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 02 CREAM" });
                matLista.Add(new Material { MaterialId = 272, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 04 KIEZEL" });
                matLista.Add(new Material { MaterialId = 273, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 05 BEIGE" });
                matLista.Add(new Material { MaterialId = 274, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 06 MOSTERO" });
                matLista.Add(new Material { MaterialId = 275, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 07 CHOCOLADE" });
                matLista.Add(new Material { MaterialId = 276, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 09 CAMEL" });
                matLista.Add(new Material { MaterialId = 277, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 10 LEVER" });
                matLista.Add(new Material { MaterialId = 278, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 102 ECRU" });
                matLista.Add(new Material { MaterialId = 279, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 104 WIT" });
                matLista.Add(new Material { MaterialId = 280, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 106 PEARL" });
                matLista.Add(new Material { MaterialId = 281, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 11 CAPPUCCINO" });
                matLista.Add(new Material { MaterialId = 282, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 110 LINEN" });
                matLista.Add(new Material { MaterialId = 283, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 111 TABAC" });
                matLista.Add(new Material { MaterialId = 284, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 12 TAUPE" });
                matLista.Add(new Material { MaterialId = 285, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 123 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 286, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 13 MOCCA" });
                matLista.Add(new Material { MaterialId = 287, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 14 ARMY" });
                matLista.Add(new Material { MaterialId = 288, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 154 LIGHTGROEN" });
                matLista.Add(new Material { MaterialId = 289, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 166 BLOSSOM" });
                matLista.Add(new Material { MaterialId = 290, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 18 DONKERBRUIN" });
                matLista.Add(new Material { MaterialId = 291, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 27 BRIQUE" });
                matLista.Add(new Material { MaterialId = 292, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 31 TERRACOTTA" });
                matLista.Add(new Material { MaterialId = 293, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 37 BORDEAUXROOD" });
                matLista.Add(new Material { MaterialId = 294, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 51 KAKI" });
                matLista.Add(new Material { MaterialId = 295, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 60 LIGHTGREY" });
                matLista.Add(new Material { MaterialId = 296, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 65 GREY" });
                matLista.Add(new Material { MaterialId = 297, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 67 ANTRACIET" });
                matLista.Add(new Material { MaterialId = 298, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 68 DARKGREY" });
                matLista.Add(new Material { MaterialId = 299, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 74 AUBERGINE" });
                matLista.Add(new Material { MaterialId = 300, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 76 PRUNE" });
                matLista.Add(new Material { MaterialId = 301, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 77 FUCHSIA" });
                matLista.Add(new Material { MaterialId = 302, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 78 PURPLE" });
                matLista.Add(new Material { MaterialId = 303, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 81 COFFEE" });
                matLista.Add(new Material { MaterialId = 304, MaterialGrupaRefId = 1, Nazwa = "SHADOW - 83 CACAO" });
                matLista.Add(new Material { MaterialId = 305, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 709" });
                matLista.Add(new Material { MaterialId = 306, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 733" });
                matLista.Add(new Material { MaterialId = 307, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 8" });
                matLista.Add(new Material { MaterialId = 308, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 02 WHITE" });
                matLista.Add(new Material { MaterialId = 309, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 06 NOUGAT" });
                matLista.Add(new Material { MaterialId = 310, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 100 BOURGONDE" });
                matLista.Add(new Material { MaterialId = 311, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 13 SAHARA" });
                matLista.Add(new Material { MaterialId = 312, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 235 MOCCA" });
                matLista.Add(new Material { MaterialId = 313, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 45 GREY" });
                matLista.Add(new Material { MaterialId = 314, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 755 FANGO" });
                matLista.Add(new Material { MaterialId = 315, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 770 PLATIN" });
                matLista.Add(new Material { MaterialId = 316, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 780 BLACK" });
                matLista.Add(new Material { MaterialId = 317, MaterialGrupaRefId = 1, Nazwa = "SIXTY - 845 LOUD RED" });
                matLista.Add(new Material { MaterialId = 318, MaterialGrupaRefId = 1, Nazwa = "SOFT - 100 BORDEAUX" });
                matLista.Add(new Material { MaterialId = 319, MaterialGrupaRefId = 1, Nazwa = "SOFT - 20029 BEIGE" });
                matLista.Add(new Material { MaterialId = 320, MaterialGrupaRefId = 1, Nazwa = "SOFT - 210 DARK BROWN" });
                matLista.Add(new Material { MaterialId = 321, MaterialGrupaRefId = 1, Nazwa = "SOFT - 2100 MATT DARK BROWN" });
                matLista.Add(new Material { MaterialId = 322, MaterialGrupaRefId = 1, Nazwa = "SOFT - 215 RED" });
                matLista.Add(new Material { MaterialId = 323, MaterialGrupaRefId = 1, Nazwa = "SOFT - 220 SAVANNAH" });
                matLista.Add(new Material { MaterialId = 324, MaterialGrupaRefId = 1, Nazwa = "SOFT - 225 BROWN" });
                matLista.Add(new Material { MaterialId = 325, MaterialGrupaRefId = 1, Nazwa = "SOFT - 30345 DARK BLUE" });
                matLista.Add(new Material { MaterialId = 326, MaterialGrupaRefId = 1, Nazwa = "SOFT - 335 DARK BLUE" });
                matLista.Add(new Material { MaterialId = 327, MaterialGrupaRefId = 1, Nazwa = "SOFT - 644 IVORY" });
                matLista.Add(new Material { MaterialId = 328, MaterialGrupaRefId = 1, Nazwa = "SOFT - 780 BLACK" });
                matLista.Add(new Material { MaterialId = 329, MaterialGrupaRefId = 1, Nazwa = "SOFT - 792 ORANGE" });
                matLista.Add(new Material { MaterialId = 330, MaterialGrupaRefId = 1, Nazwa = "SOFT - 793 BEIGE" });
                matLista.Add(new Material { MaterialId = 331, MaterialGrupaRefId = 1, Nazwa = "TAPE - 102 ECRU" });
                matLista.Add(new Material { MaterialId = 332, MaterialGrupaRefId = 1, Nazwa = "TAPE - 13 MOCCA" });
                matLista.Add(new Material { MaterialId = 333, MaterialGrupaRefId = 1, Nazwa = "TAPE - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 334, MaterialGrupaRefId = 1, Nazwa = "TAPE - 169 ONYX" });
                matLista.Add(new Material { MaterialId = 335, MaterialGrupaRefId = 1, Nazwa = "TAPE - 17 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 336, MaterialGrupaRefId = 1, Nazwa = "TAPE - 3 SAND" });
                matLista.Add(new Material { MaterialId = 337, MaterialGrupaRefId = 1, Nazwa = "TAPE - 49 NAVY" });
                matLista.Add(new Material { MaterialId = 338, MaterialGrupaRefId = 1, Nazwa = "TAPE - 5 BEIGE" });
                matLista.Add(new Material { MaterialId = 339, MaterialGrupaRefId = 1, Nazwa = "TAPE - 65 GREY" });
                matLista.Add(new Material { MaterialId = 340, MaterialGrupaRefId = 1, Nazwa = "TEMPO - 192" });
                matLista.Add(new Material { MaterialId = 341, MaterialGrupaRefId = 1, Nazwa = "TEMPO - 47" });
                matLista.Add(new Material { MaterialId = 342, MaterialGrupaRefId = 1, Nazwa = "TEMPO - 65" });
                matLista.Add(new Material { MaterialId = 343, MaterialGrupaRefId = 1, Nazwa = "TEMPO - 67" });
                matLista.Add(new Material { MaterialId = 344, MaterialGrupaRefId = 1, Nazwa = "VERDI - 489" });
                matLista.Add(new Material { MaterialId = 345, MaterialGrupaRefId = 1, Nazwa = "VERDI - 595" });
                matLista.Add(new Material { MaterialId = 346, MaterialGrupaRefId = 1, Nazwa = "VERDI - 0022 ECRU" });
                matLista.Add(new Material { MaterialId = 347, MaterialGrupaRefId = 1, Nazwa = "VERDI - 0052 LINNE" });
                matLista.Add(new Material { MaterialId = 348, MaterialGrupaRefId = 1, Nazwa = "VERDI - 0212 GOLD" });
                matLista.Add(new Material { MaterialId = 349, MaterialGrupaRefId = 1, Nazwa = "VERDI - 0570 CACAO" });
                matLista.Add(new Material { MaterialId = 350, MaterialGrupaRefId = 1, Nazwa = "VERDI - 0835 DARK VIOLET" });
                matLista.Add(new Material { MaterialId = 351, MaterialGrupaRefId = 1, Nazwa = "VERDI - 0905 GREY" });
                matLista.Add(new Material { MaterialId = 352, MaterialGrupaRefId = 1, Nazwa = "VERDI - 0987 BLACK" });
                matLista.Add(new Material { MaterialId = 353, MaterialGrupaRefId = 1, Nazwa = "VERDI - 121 CAMEL" });
                matLista.Add(new Material { MaterialId = 354, MaterialGrupaRefId = 1, Nazwa = "VERDI - 780 PINK" });
                matLista.Add(new Material { MaterialId = 355, MaterialGrupaRefId = 2, Nazwa = "APOLLO SILVER - K5035/05" });
                matLista.Add(new Material { MaterialId = 356, MaterialGrupaRefId = 2, Nazwa = "ARTHUR - 440" });
                matLista.Add(new Material { MaterialId = 357, MaterialGrupaRefId = 2, Nazwa = "ARTHUR - 640" });
                matLista.Add(new Material { MaterialId = 358, MaterialGrupaRefId = 2, Nazwa = "ARTHUR - 765" });
                matLista.Add(new Material { MaterialId = 359, MaterialGrupaRefId = 2, Nazwa = "ARTUR - 170" });
                matLista.Add(new Material { MaterialId = 360, MaterialGrupaRefId = 2, Nazwa = "ARTUR - 180" });
                matLista.Add(new Material { MaterialId = 361, MaterialGrupaRefId = 2, Nazwa = "ATLANTIS - HERON WASHABLE V3078/24" });
                matLista.Add(new Material { MaterialId = 362, MaterialGrupaRefId = 2, Nazwa = "AUSKERY - GRAPHITE" });
                matLista.Add(new Material { MaterialId = 363, MaterialGrupaRefId = 2, Nazwa = "AVANT - 75" });
                matLista.Add(new Material { MaterialId = 364, MaterialGrupaRefId = 2, Nazwa = "BEAT - 12" });
                matLista.Add(new Material { MaterialId = 365, MaterialGrupaRefId = 2, Nazwa = "BENATH - CA1170/092" });
                matLista.Add(new Material { MaterialId = 366, MaterialGrupaRefId = 2, Nazwa = "BOARD - 10" });
                matLista.Add(new Material { MaterialId = 367, MaterialGrupaRefId = 2, Nazwa = "BOARD - 102" });
                matLista.Add(new Material { MaterialId = 368, MaterialGrupaRefId = 2, Nazwa = "BOARD - 113" });
                matLista.Add(new Material { MaterialId = 369, MaterialGrupaRefId = 2, Nazwa = "BOARD - 12" });
                matLista.Add(new Material { MaterialId = 370, MaterialGrupaRefId = 2, Nazwa = "BOARD - 123" });
                matLista.Add(new Material { MaterialId = 371, MaterialGrupaRefId = 2, Nazwa = "BOARD - 149" });
                matLista.Add(new Material { MaterialId = 372, MaterialGrupaRefId = 2, Nazwa = "BOARD - 18" });
                matLista.Add(new Material { MaterialId = 373, MaterialGrupaRefId = 2, Nazwa = "BOARD - 35" });
                matLista.Add(new Material { MaterialId = 374, MaterialGrupaRefId = 2, Nazwa = "BOARD - 5" });
                matLista.Add(new Material { MaterialId = 375, MaterialGrupaRefId = 2, Nazwa = "BOARD - 56" });
                matLista.Add(new Material { MaterialId = 376, MaterialGrupaRefId = 2, Nazwa = "BOARD - 65" });
                matLista.Add(new Material { MaterialId = 377, MaterialGrupaRefId = 2, Nazwa = "BOARD - 67" });
                matLista.Add(new Material { MaterialId = 378, MaterialGrupaRefId = 2, Nazwa = "BOARD - 68" });
                matLista.Add(new Material { MaterialId = 379, MaterialGrupaRefId = 2, Nazwa = "BOARD - 84" });
                matLista.Add(new Material { MaterialId = 380, MaterialGrupaRefId = 2, Nazwa = "CASA - 110" });
                matLista.Add(new Material { MaterialId = 381, MaterialGrupaRefId = 2, Nazwa = "CASA - 12" });
                matLista.Add(new Material { MaterialId = 382, MaterialGrupaRefId = 2, Nazwa = "CASA - 3" });
                matLista.Add(new Material { MaterialId = 383, MaterialGrupaRefId = 2, Nazwa = "CASA - 65" });
                matLista.Add(new Material { MaterialId = 384, MaterialGrupaRefId = 2, Nazwa = "CASA - 66" });
                matLista.Add(new Material { MaterialId = 385, MaterialGrupaRefId = 2, Nazwa = "CAST - 15" });
                matLista.Add(new Material { MaterialId = 386, MaterialGrupaRefId = 2, Nazwa = "CAST - 53" });
                matLista.Add(new Material { MaterialId = 387, MaterialGrupaRefId = 2, Nazwa = "CAST - 65" });
                matLista.Add(new Material { MaterialId = 388, MaterialGrupaRefId = 2, Nazwa = "CAST - 67" });
                matLista.Add(new Material { MaterialId = 389, MaterialGrupaRefId = 2, Nazwa = "CAST - 68" });
                matLista.Add(new Material { MaterialId = 390, MaterialGrupaRefId = 2, Nazwa = "CHIVASSO - 1082" });
                matLista.Add(new Material { MaterialId = 391, MaterialGrupaRefId = 2, Nazwa = "COOL - 102" });
                matLista.Add(new Material { MaterialId = 392, MaterialGrupaRefId = 2, Nazwa = "COOL - 60" });
                matLista.Add(new Material { MaterialId = 393, MaterialGrupaRefId = 2, Nazwa = "CROSBY - 1" });
                matLista.Add(new Material { MaterialId = 394, MaterialGrupaRefId = 2, Nazwa = "CROSBY - 2" });
                matLista.Add(new Material { MaterialId = 395, MaterialGrupaRefId = 2, Nazwa = "CRUSH - 12" });
                matLista.Add(new Material { MaterialId = 396, MaterialGrupaRefId = 2, Nazwa = "CRUSH - 2" });
                matLista.Add(new Material { MaterialId = 397, MaterialGrupaRefId = 2, Nazwa = "CRUSH - 51" });
                matLista.Add(new Material { MaterialId = 398, MaterialGrupaRefId = 2, Nazwa = "DAWN - 11" });
                matLista.Add(new Material { MaterialId = 399, MaterialGrupaRefId = 2, Nazwa = "DAWN - 123" });
                matLista.Add(new Material { MaterialId = 400, MaterialGrupaRefId = 2, Nazwa = "DAWN - 124" });
                matLista.Add(new Material { MaterialId = 401, MaterialGrupaRefId = 2, Nazwa = "DAWN - 149" });
                matLista.Add(new Material { MaterialId = 402, MaterialGrupaRefId = 2, Nazwa = "DAWN - 65" });
                matLista.Add(new Material { MaterialId = 403, MaterialGrupaRefId = 2, Nazwa = "DAWN - 91" });
                matLista.Add(new Material { MaterialId = 404, MaterialGrupaRefId = 2, Nazwa = "ESPRIT - ARMY" });
                matLista.Add(new Material { MaterialId = 405, MaterialGrupaRefId = 2, Nazwa = "ESPRIT - CASA MANCE" });
                matLista.Add(new Material { MaterialId = 406, MaterialGrupaRefId = 2, Nazwa = "EXPO - 101" });
                matLista.Add(new Material { MaterialId = 407, MaterialGrupaRefId = 2, Nazwa = "EXPO - 125" });
                matLista.Add(new Material { MaterialId = 408, MaterialGrupaRefId = 2, Nazwa = "EXPO - 167" });
                matLista.Add(new Material { MaterialId = 409, MaterialGrupaRefId = 2, Nazwa = "EXPO - 65" });
                matLista.Add(new Material { MaterialId = 410, MaterialGrupaRefId = 2, Nazwa = "EXPO - 84" });
                matLista.Add(new Material { MaterialId = 411, MaterialGrupaRefId = 2, Nazwa = "FABULOUS - 739906" });
                matLista.Add(new Material { MaterialId = 412, MaterialGrupaRefId = 2, Nazwa = "FABULOUS - 739911" });
                matLista.Add(new Material { MaterialId = 413, MaterialGrupaRefId = 2, Nazwa = "FABULOUS - 739928" });
                matLista.Add(new Material { MaterialId = 414, MaterialGrupaRefId = 2, Nazwa = "FLASH - 60" });
                matLista.Add(new Material { MaterialId = 415, MaterialGrupaRefId = 2, Nazwa = "FONDA - 169" });
                matLista.Add(new Material { MaterialId = 416, MaterialGrupaRefId = 2, Nazwa = "GALA - 18" });
                matLista.Add(new Material { MaterialId = 417, MaterialGrupaRefId = 2, Nazwa = "GALA - 5" });
                matLista.Add(new Material { MaterialId = 418, MaterialGrupaRefId = 2, Nazwa = "GALA - 51" });
                matLista.Add(new Material { MaterialId = 419, MaterialGrupaRefId = 2, Nazwa = "GALA - 65" });
                matLista.Add(new Material { MaterialId = 420, MaterialGrupaRefId = 2, Nazwa = "GALA - 67" });
                matLista.Add(new Material { MaterialId = 421, MaterialGrupaRefId = 2, Nazwa = "GAPP - 102" });
                matLista.Add(new Material { MaterialId = 422, MaterialGrupaRefId = 2, Nazwa = "GAPP - 110" });
                matLista.Add(new Material { MaterialId = 423, MaterialGrupaRefId = 2, Nazwa = "GENUA - 740164" });
                matLista.Add(new Material { MaterialId = 424, MaterialGrupaRefId = 2, Nazwa = "GEORGE - 120" });
                matLista.Add(new Material { MaterialId = 425, MaterialGrupaRefId = 2, Nazwa = "GEORGE - 185" });
                matLista.Add(new Material { MaterialId = 426, MaterialGrupaRefId = 2, Nazwa = "GEORGE - 265" });
                matLista.Add(new Material { MaterialId = 427, MaterialGrupaRefId = 2, Nazwa = "GROUND - 115" });
                matLista.Add(new Material { MaterialId = 428, MaterialGrupaRefId = 2, Nazwa = "GROUND - 45" });
                matLista.Add(new Material { MaterialId = 429, MaterialGrupaRefId = 2, Nazwa = "HERO - 51" });
                matLista.Add(new Material { MaterialId = 430, MaterialGrupaRefId = 2, Nazwa = "HERO - 65" });
                matLista.Add(new Material { MaterialId = 431, MaterialGrupaRefId = 2, Nazwa = "HOPER - 101" });
                matLista.Add(new Material { MaterialId = 432, MaterialGrupaRefId = 2, Nazwa = "HOPER - 51" });
                matLista.Add(new Material { MaterialId = 433, MaterialGrupaRefId = 2, Nazwa = "HOPER - 65" });
                matLista.Add(new Material { MaterialId = 434, MaterialGrupaRefId = 2, Nazwa = "HOPER - 67" });
                matLista.Add(new Material { MaterialId = 435, MaterialGrupaRefId = 2, Nazwa = "HOT MADISON - PART 2" });
                matLista.Add(new Material { MaterialId = 436, MaterialGrupaRefId = 2, Nazwa = "IMAGE - 166" });
                matLista.Add(new Material { MaterialId = 437, MaterialGrupaRefId = 2, Nazwa = "IMAGE - 169" });
                matLista.Add(new Material { MaterialId = 438, MaterialGrupaRefId = 2, Nazwa = "JUKE - 12" });
                matLista.Add(new Material { MaterialId = 439, MaterialGrupaRefId = 2, Nazwa = "JUKE - 123" });
                matLista.Add(new Material { MaterialId = 440, MaterialGrupaRefId = 2, Nazwa = "JUKE - 123" });
                matLista.Add(new Material { MaterialId = 441, MaterialGrupaRefId = 2, Nazwa = "JUKE - 15" });
                matLista.Add(new Material { MaterialId = 442, MaterialGrupaRefId = 2, Nazwa = "JUKE - 162" });
                matLista.Add(new Material { MaterialId = 443, MaterialGrupaRefId = 2, Nazwa = "JUKE - 169" });
                matLista.Add(new Material { MaterialId = 444, MaterialGrupaRefId = 2, Nazwa = "JUKE - 3" });
                matLista.Add(new Material { MaterialId = 445, MaterialGrupaRefId = 2, Nazwa = "JUKE - 37" });
                matLista.Add(new Material { MaterialId = 446, MaterialGrupaRefId = 2, Nazwa = "JUKE - 39" });
                matLista.Add(new Material { MaterialId = 447, MaterialGrupaRefId = 2, Nazwa = "JUKE - 45" });
                matLista.Add(new Material { MaterialId = 448, MaterialGrupaRefId = 2, Nazwa = "JUKE - 51" });
                matLista.Add(new Material { MaterialId = 449, MaterialGrupaRefId = 2, Nazwa = "JUKE - 52" });
                matLista.Add(new Material { MaterialId = 450, MaterialGrupaRefId = 2, Nazwa = "JUKE - 53" });
                matLista.Add(new Material { MaterialId = 451, MaterialGrupaRefId = 2, Nazwa = "JUKE - 65" });
                matLista.Add(new Material { MaterialId = 452, MaterialGrupaRefId = 2, Nazwa = "JUKE - 67" });
                matLista.Add(new Material { MaterialId = 453, MaterialGrupaRefId = 2, Nazwa = "JUKE - 71" });
                matLista.Add(new Material { MaterialId = 454, MaterialGrupaRefId = 2, Nazwa = "JUKE - 73" });
                matLista.Add(new Material { MaterialId = 455, MaterialGrupaRefId = 2, Nazwa = "JUKE - 79" });
                matLista.Add(new Material { MaterialId = 456, MaterialGrupaRefId = 2, Nazwa = "KANE - 5" });
                matLista.Add(new Material { MaterialId = 457, MaterialGrupaRefId = 2, Nazwa = "KANE - 66" });
                matLista.Add(new Material { MaterialId = 458, MaterialGrupaRefId = 2, Nazwa = "KANE - 81" });
                matLista.Add(new Material { MaterialId = 459, MaterialGrupaRefId = 2, Nazwa = "KISS - 1" });
                matLista.Add(new Material { MaterialId = 460, MaterialGrupaRefId = 2, Nazwa = "KISS - 102" });
                matLista.Add(new Material { MaterialId = 461, MaterialGrupaRefId = 2, Nazwa = "KISS - 104" });
                matLista.Add(new Material { MaterialId = 462, MaterialGrupaRefId = 2, Nazwa = "KISS - 14" });
                matLista.Add(new Material { MaterialId = 463, MaterialGrupaRefId = 2, Nazwa = "KISS - 15" });
                matLista.Add(new Material { MaterialId = 464, MaterialGrupaRefId = 2, Nazwa = "KISS - 17" });
                matLista.Add(new Material { MaterialId = 465, MaterialGrupaRefId = 2, Nazwa = "KISS - 180" });
                matLista.Add(new Material { MaterialId = 466, MaterialGrupaRefId = 2, Nazwa = "KISS - 181" });
                matLista.Add(new Material { MaterialId = 467, MaterialGrupaRefId = 2, Nazwa = "KISS - 39" });
                matLista.Add(new Material { MaterialId = 468, MaterialGrupaRefId = 2, Nazwa = "KISS - 43" });
                matLista.Add(new Material { MaterialId = 469, MaterialGrupaRefId = 2, Nazwa = "KISS - 45" });
                matLista.Add(new Material { MaterialId = 470, MaterialGrupaRefId = 2, Nazwa = "KISS - 50" });
                matLista.Add(new Material { MaterialId = 471, MaterialGrupaRefId = 2, Nazwa = "KISS - 60" });
                matLista.Add(new Material { MaterialId = 472, MaterialGrupaRefId = 2, Nazwa = "KISS - 65" });
                matLista.Add(new Material { MaterialId = 473, MaterialGrupaRefId = 2, Nazwa = "KISS - 66" });
                matLista.Add(new Material { MaterialId = 474, MaterialGrupaRefId = 2, Nazwa = "KISS - 78" });
                matLista.Add(new Material { MaterialId = 475, MaterialGrupaRefId = 2, Nazwa = "LORIANO METALIC AURORA - RF7615/04" });
                matLista.Add(new Material { MaterialId = 476, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 1" });
                matLista.Add(new Material { MaterialId = 477, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 109" });
                matLista.Add(new Material { MaterialId = 478, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 115" });
                matLista.Add(new Material { MaterialId = 479, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 126" });
                matLista.Add(new Material { MaterialId = 480, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 128" });
                matLista.Add(new Material { MaterialId = 481, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 129" });
                matLista.Add(new Material { MaterialId = 482, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 130" });
                matLista.Add(new Material { MaterialId = 483, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 134" });
                matLista.Add(new Material { MaterialId = 484, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 138" });
                matLista.Add(new Material { MaterialId = 485, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 139" });
                matLista.Add(new Material { MaterialId = 486, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 140" });
                matLista.Add(new Material { MaterialId = 487, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 141" });
                matLista.Add(new Material { MaterialId = 488, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 144" });
                matLista.Add(new Material { MaterialId = 489, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 145" });
                matLista.Add(new Material { MaterialId = 490, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 146" });
                matLista.Add(new Material { MaterialId = 491, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 147" });
                matLista.Add(new Material { MaterialId = 492, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 148" });
                matLista.Add(new Material { MaterialId = 493, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 149" });
                matLista.Add(new Material { MaterialId = 494, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 152" });
                matLista.Add(new Material { MaterialId = 495, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 158" });
                matLista.Add(new Material { MaterialId = 496, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 17" });
                matLista.Add(new Material { MaterialId = 497, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 21" });
                matLista.Add(new Material { MaterialId = 498, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 34" });
                matLista.Add(new Material { MaterialId = 499, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 39" });
                matLista.Add(new Material { MaterialId = 500, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 49" });
                matLista.Add(new Material { MaterialId = 501, MaterialGrupaRefId = 2, Nazwa = "LOUNGE - 74" });
                matLista.Add(new Material { MaterialId = 502, MaterialGrupaRefId = 2, Nazwa = "LUCIANO - 0" });
                matLista.Add(new Material { MaterialId = 503, MaterialGrupaRefId = 2, Nazwa = "LUCK - 66" });
                matLista.Add(new Material { MaterialId = 504, MaterialGrupaRefId = 2, Nazwa = "LUTTIKHUIS - CH2870/094" });
                matLista.Add(new Material { MaterialId = 505, MaterialGrupaRefId = 2, Nazwa = "MAZARA - 87" });
                matLista.Add(new Material { MaterialId = 506, MaterialGrupaRefId = 2, Nazwa = "MOON - 140" });
                matLista.Add(new Material { MaterialId = 507, MaterialGrupaRefId = 2, Nazwa = "MULTI - 25" });
                matLista.Add(new Material { MaterialId = 508, MaterialGrupaRefId = 2, Nazwa = "OSLO - 100" });
                matLista.Add(new Material { MaterialId = 509, MaterialGrupaRefId = 2, Nazwa = "OSLO - 800" });
                matLista.Add(new Material { MaterialId = 510, MaterialGrupaRefId = 2, Nazwa = "OSLO - 801" });
                matLista.Add(new Material { MaterialId = 511, MaterialGrupaRefId = 2, Nazwa = "OSLO - 802" });
                matLista.Add(new Material { MaterialId = 512, MaterialGrupaRefId = 2, Nazwa = "OSLO - 803" });
                matLista.Add(new Material { MaterialId = 513, MaterialGrupaRefId = 2, Nazwa = "OSLO - 804" });
                matLista.Add(new Material { MaterialId = 514, MaterialGrupaRefId = 2, Nazwa = "OSLO - 805" });
                matLista.Add(new Material { MaterialId = 515, MaterialGrupaRefId = 2, Nazwa = "OSLO - 900" });
                matLista.Add(new Material { MaterialId = 516, MaterialGrupaRefId = 2, Nazwa = "OSLO - 903" });
                matLista.Add(new Material { MaterialId = 517, MaterialGrupaRefId = 2, Nazwa = "OSLO - 905" });
                matLista.Add(new Material { MaterialId = 518, MaterialGrupaRefId = 2, Nazwa = "PANSY - 0" });
                matLista.Add(new Material { MaterialId = 519, MaterialGrupaRefId = 2, Nazwa = "PEREZ - 102" });
                matLista.Add(new Material { MaterialId = 520, MaterialGrupaRefId = 2, Nazwa = "PEREZ - 12" });
                matLista.Add(new Material { MaterialId = 521, MaterialGrupaRefId = 2, Nazwa = "PEREZ - 15" });
                matLista.Add(new Material { MaterialId = 522, MaterialGrupaRefId = 2, Nazwa = "PEREZ - 158" });
                matLista.Add(new Material { MaterialId = 523, MaterialGrupaRefId = 2, Nazwa = "PEREZ - 18" });
                matLista.Add(new Material { MaterialId = 524, MaterialGrupaRefId = 2, Nazwa = "PEREZ - 5" });
                matLista.Add(new Material { MaterialId = 525, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 108" });
                matLista.Add(new Material { MaterialId = 526, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 123" });
                matLista.Add(new Material { MaterialId = 527, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 168" });
                matLista.Add(new Material { MaterialId = 528, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 181" });
                matLista.Add(new Material { MaterialId = 529, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 51" });
                matLista.Add(new Material { MaterialId = 530, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 60" });
                matLista.Add(new Material { MaterialId = 531, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 65" });
                matLista.Add(new Material { MaterialId = 532, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 67" });
                matLista.Add(new Material { MaterialId = 533, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 74" });
                matLista.Add(new Material { MaterialId = 534, MaterialGrupaRefId = 2, Nazwa = "PIQUET - 81" });
                matLista.Add(new Material { MaterialId = 535, MaterialGrupaRefId = 2, Nazwa = "RANCH - 17" });
                matLista.Add(new Material { MaterialId = 536, MaterialGrupaRefId = 2, Nazwa = "RANCH - 180" });
                matLista.Add(new Material { MaterialId = 537, MaterialGrupaRefId = 2, Nazwa = "RANCH - 39" });
                matLista.Add(new Material { MaterialId = 538, MaterialGrupaRefId = 2, Nazwa = "RANCH - 5" });
                matLista.Add(new Material { MaterialId = 539, MaterialGrupaRefId = 2, Nazwa = "RANCH - 65" });
                matLista.Add(new Material { MaterialId = 540, MaterialGrupaRefId = 2, Nazwa = "RANCH - 67" });
                matLista.Add(new Material { MaterialId = 541, MaterialGrupaRefId = 2, Nazwa = "RELAX - 67" });
                matLista.Add(new Material { MaterialId = 542, MaterialGrupaRefId = 2, Nazwa = "REPLAY - 140" });
                matLista.Add(new Material { MaterialId = 543, MaterialGrupaRefId = 2, Nazwa = "REPLAY - 180" });
                matLista.Add(new Material { MaterialId = 544, MaterialGrupaRefId = 2, Nazwa = "REPLAY - 34" });
                matLista.Add(new Material { MaterialId = 545, MaterialGrupaRefId = 2, Nazwa = "RIBCOARD - AQUA 143" });
                matLista.Add(new Material { MaterialId = 546, MaterialGrupaRefId = 2, Nazwa = "SENNA - 14" });
                matLista.Add(new Material { MaterialId = 547, MaterialGrupaRefId = 2, Nazwa = "SENNA - 18" });
                matLista.Add(new Material { MaterialId = 548, MaterialGrupaRefId = 2, Nazwa = "SENNA - 20" });
                matLista.Add(new Material { MaterialId = 549, MaterialGrupaRefId = 2, Nazwa = "SENNA - 8" });
                matLista.Add(new Material { MaterialId = 550, MaterialGrupaRefId = 2, Nazwa = "SEVEN - 59" });
                matLista.Add(new Material { MaterialId = 551, MaterialGrupaRefId = 2, Nazwa = "SEVEN - 65" });
                matLista.Add(new Material { MaterialId = 552, MaterialGrupaRefId = 2, Nazwa = "SEVEN - 67" });
                matLista.Add(new Material { MaterialId = 553, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 1" });
                matLista.Add(new Material { MaterialId = 554, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 10" });
                matLista.Add(new Material { MaterialId = 555, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 102" });
                matLista.Add(new Material { MaterialId = 556, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 104" });
                matLista.Add(new Material { MaterialId = 557, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 106" });
                matLista.Add(new Material { MaterialId = 558, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 11" });
                matLista.Add(new Material { MaterialId = 559, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 110" });
                matLista.Add(new Material { MaterialId = 560, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 111" });
                matLista.Add(new Material { MaterialId = 561, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 12" });
                matLista.Add(new Material { MaterialId = 562, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 123" });
                matLista.Add(new Material { MaterialId = 563, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 14" });
                matLista.Add(new Material { MaterialId = 564, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 142" });
                matLista.Add(new Material { MaterialId = 565, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 145" });
                matLista.Add(new Material { MaterialId = 566, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 151" });
                matLista.Add(new Material { MaterialId = 567, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 27" });
                matLista.Add(new Material { MaterialId = 568, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 31" });
                matLista.Add(new Material { MaterialId = 569, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 4" });
                matLista.Add(new Material { MaterialId = 570, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 43" });
                matLista.Add(new Material { MaterialId = 571, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 5" });
                matLista.Add(new Material { MaterialId = 572, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 60" });
                matLista.Add(new Material { MaterialId = 573, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 65" });
                matLista.Add(new Material { MaterialId = 574, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 67" });
                matLista.Add(new Material { MaterialId = 575, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 68" });
                matLista.Add(new Material { MaterialId = 576, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 74" });
                matLista.Add(new Material { MaterialId = 577, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 78" });
                matLista.Add(new Material { MaterialId = 578, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 81" });
                matLista.Add(new Material { MaterialId = 579, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 83" });
                matLista.Add(new Material { MaterialId = 580, MaterialGrupaRefId = 2, Nazwa = "SHADOW - 88" });
                matLista.Add(new Material { MaterialId = 581, MaterialGrupaRefId = 2, Nazwa = "SHOW - 60" });
                matLista.Add(new Material { MaterialId = 582, MaterialGrupaRefId = 2, Nazwa = "SHOW - 68" });
                matLista.Add(new Material { MaterialId = 583, MaterialGrupaRefId = 2, Nazwa = "SILA - CA1261/080" });
                matLista.Add(new Material { MaterialId = 584, MaterialGrupaRefId = 2, Nazwa = "SILKOR - 140" });
                matLista.Add(new Material { MaterialId = 585, MaterialGrupaRefId = 2, Nazwa = "SILKOR - 04 SLATE" });
                matLista.Add(new Material { MaterialId = 586, MaterialGrupaRefId = 2, Nazwa = "SILVERA - 2633" });
                matLista.Add(new Material { MaterialId = 587, MaterialGrupaRefId = 2, Nazwa = "STERLING - 10" });
                matLista.Add(new Material { MaterialId = 588, MaterialGrupaRefId = 2, Nazwa = "STERLING - 4" });
                matLista.Add(new Material { MaterialId = 589, MaterialGrupaRefId = 2, Nazwa = "STRADA - 10" });
                matLista.Add(new Material { MaterialId = 590, MaterialGrupaRefId = 2, Nazwa = "STRADA - 111" });
                matLista.Add(new Material { MaterialId = 591, MaterialGrupaRefId = 2, Nazwa = "STRADA - 196" });
                matLista.Add(new Material { MaterialId = 592, MaterialGrupaRefId = 2, Nazwa = "STRADA - 65" });
                matLista.Add(new Material { MaterialId = 593, MaterialGrupaRefId = 2, Nazwa = "TAFT - FUCHUSIA 77" });
                matLista.Add(new Material { MaterialId = 594, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 109" });
                matLista.Add(new Material { MaterialId = 595, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 12" });
                matLista.Add(new Material { MaterialId = 596, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 144" });
                matLista.Add(new Material { MaterialId = 597, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 192" });
                matLista.Add(new Material { MaterialId = 598, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 47" });
                matLista.Add(new Material { MaterialId = 599, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 49" });
                matLista.Add(new Material { MaterialId = 600, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 5" });
                matLista.Add(new Material { MaterialId = 601, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 60" });
                matLista.Add(new Material { MaterialId = 602, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 65" });
                matLista.Add(new Material { MaterialId = 603, MaterialGrupaRefId = 2, Nazwa = "TEMPO - 67" });
                matLista.Add(new Material { MaterialId = 604, MaterialGrupaRefId = 2, Nazwa = "TIN - CA1294/062" });
                matLista.Add(new Material { MaterialId = 605, MaterialGrupaRefId = 2, Nazwa = "TRESCA - CA1283/080" });
                matLista.Add(new Material { MaterialId = 606, MaterialGrupaRefId = 2, Nazwa = "TRESCA - CA1283/099" });
                matLista.Add(new Material { MaterialId = 607, MaterialGrupaRefId = 2, Nazwa = "TROY - 15" });
                matLista.Add(new Material { MaterialId = 608, MaterialGrupaRefId = 2, Nazwa = "TROY - 17" });
                matLista.Add(new Material { MaterialId = 609, MaterialGrupaRefId = 2, Nazwa = "TROY - 21" });
                matLista.Add(new Material { MaterialId = 610, MaterialGrupaRefId = 2, Nazwa = "TROY - 3" });
                matLista.Add(new Material { MaterialId = 611, MaterialGrupaRefId = 2, Nazwa = "TROY - 35" });
                matLista.Add(new Material { MaterialId = 612, MaterialGrupaRefId = 2, Nazwa = "TROY - 52" });
                matLista.Add(new Material { MaterialId = 613, MaterialGrupaRefId = 2, Nazwa = "TROY - 69" });
                matLista.Add(new Material { MaterialId = 614, MaterialGrupaRefId = 2, Nazwa = "TROY - 70" });
                matLista.Add(new Material { MaterialId = 615, MaterialGrupaRefId = 2, Nazwa = "VELVET PALLAZO - 1175/050" });
                matLista.Add(new Material { MaterialId = 616, MaterialGrupaRefId = 2, Nazwa = "VELVET PALLAZO - 1175/080" });
                matLista.Add(new Material { MaterialId = 617, MaterialGrupaRefId = 2, Nazwa = "VELVET PALLAZO - 1175/20" });
                matLista.Add(new Material { MaterialId = 618, MaterialGrupaRefId = 2, Nazwa = "VELVET PALLAZO - CITY" });
                matLista.Add(new Material { MaterialId = 619, MaterialGrupaRefId = 2, Nazwa = "VENICE - 16" });
                matLista.Add(new Material { MaterialId = 620, MaterialGrupaRefId = 2, Nazwa = "VENICE - 25" });
                matLista.Add(new Material { MaterialId = 621, MaterialGrupaRefId = 2, Nazwa = "VENICE - 26" });
                matLista.Add(new Material { MaterialId = 622, MaterialGrupaRefId = 2, Nazwa = "VENICE - 74003" });
                matLista.Add(new Material { MaterialId = 623, MaterialGrupaRefId = 2, Nazwa = "VENTO - 153" });
                matLista.Add(new Material { MaterialId = 624, MaterialGrupaRefId = 2, Nazwa = "VENTO - 171" });
                matLista.Add(new Material { MaterialId = 625, MaterialGrupaRefId = 2, Nazwa = "VENTO - 60" });
                matLista.Add(new Material { MaterialId = 626, MaterialGrupaRefId = 2, Nazwa = "VOICE - 11" });
                matLista.Add(new Material { MaterialId = 627, MaterialGrupaRefId = 2, Nazwa = "YACHT - 17" });
                matLista.Add(new Material { MaterialId = 628, MaterialGrupaRefId = 2, Nazwa = "YACHT - 28" });
                matLista.Add(new Material { MaterialId = 629, MaterialGrupaRefId = 2, Nazwa = "YACHT - 81" });
                matLista.Add(new Material { MaterialId = 630, MaterialGrupaRefId = 2, Nazwa = "YP - 10002" });
                matLista.Add(new Material { MaterialId = 631, MaterialGrupaRefId = 3, Nazwa = "AMAROSI - 76" });
                matLista.Add(new Material { MaterialId = 632, MaterialGrupaRefId = 3, Nazwa = "BAROQUE - CACAO" });
                matLista.Add(new Material { MaterialId = 633, MaterialGrupaRefId = 3, Nazwa = "BAROQUE - GREY" });
                matLista.Add(new Material { MaterialId = 634, MaterialGrupaRefId = 3, Nazwa = "BAROQUE - SILVER" });
                matLista.Add(new Material { MaterialId = 635, MaterialGrupaRefId = 3, Nazwa = "BEAT - 10" });
                matLista.Add(new Material { MaterialId = 636, MaterialGrupaRefId = 3, Nazwa = "BEAT - 12" });
                matLista.Add(new Material { MaterialId = 637, MaterialGrupaRefId = 3, Nazwa = "BLINC - 1015" });
                matLista.Add(new Material { MaterialId = 638, MaterialGrupaRefId = 3, Nazwa = "BLINC - 66104" });
                matLista.Add(new Material { MaterialId = 639, MaterialGrupaRefId = 3, Nazwa = "BOARD - 1" });
                matLista.Add(new Material { MaterialId = 640, MaterialGrupaRefId = 3, Nazwa = "BOARD - 10" });
                matLista.Add(new Material { MaterialId = 641, MaterialGrupaRefId = 3, Nazwa = "BOARD - 12" });
                matLista.Add(new Material { MaterialId = 642, MaterialGrupaRefId = 3, Nazwa = "BOARD - 5" });
                matLista.Add(new Material { MaterialId = 643, MaterialGrupaRefId = 3, Nazwa = "BOARD - 60" });
                matLista.Add(new Material { MaterialId = 644, MaterialGrupaRefId = 3, Nazwa = "BOARD - 65" });
                matLista.Add(new Material { MaterialId = 645, MaterialGrupaRefId = 3, Nazwa = "BOARD - 66" });
                matLista.Add(new Material { MaterialId = 646, MaterialGrupaRefId = 3, Nazwa = "BOARD - 67" });
                matLista.Add(new Material { MaterialId = 647, MaterialGrupaRefId = 3, Nazwa = "BOARD - 77" });
                matLista.Add(new Material { MaterialId = 648, MaterialGrupaRefId = 3, Nazwa = "BOND - 65" });
                matLista.Add(new Material { MaterialId = 649, MaterialGrupaRefId = 3, Nazwa = "BRAINZA - 60" });
                matLista.Add(new Material { MaterialId = 650, MaterialGrupaRefId = 3, Nazwa = "BREAK - 1" });
                matLista.Add(new Material { MaterialId = 651, MaterialGrupaRefId = 3, Nazwa = "BREAK - 10" });
                matLista.Add(new Material { MaterialId = 652, MaterialGrupaRefId = 3, Nazwa = "BREAK - 15" });
                matLista.Add(new Material { MaterialId = 653, MaterialGrupaRefId = 3, Nazwa = "BREAK - 23" });
                matLista.Add(new Material { MaterialId = 654, MaterialGrupaRefId = 3, Nazwa = "BREAK - 25" });
                matLista.Add(new Material { MaterialId = 655, MaterialGrupaRefId = 3, Nazwa = "BREAK - 39" });
                matLista.Add(new Material { MaterialId = 656, MaterialGrupaRefId = 3, Nazwa = "BREAK - 5" });
                matLista.Add(new Material { MaterialId = 657, MaterialGrupaRefId = 3, Nazwa = "BREAK - 60" });
                matLista.Add(new Material { MaterialId = 658, MaterialGrupaRefId = 3, Nazwa = "BREAK - 65" });
                matLista.Add(new Material { MaterialId = 659, MaterialGrupaRefId = 3, Nazwa = "BREAK - 76" });
                matLista.Add(new Material { MaterialId = 660, MaterialGrupaRefId = 3, Nazwa = "BUTTERFLY - GREY" });
                matLista.Add(new Material { MaterialId = 661, MaterialGrupaRefId = 3, Nazwa = "CAST - 1" });
                matLista.Add(new Material { MaterialId = 662, MaterialGrupaRefId = 3, Nazwa = "CAST - 10" });
                matLista.Add(new Material { MaterialId = 663, MaterialGrupaRefId = 3, Nazwa = "CAST - 15" });
                matLista.Add(new Material { MaterialId = 664, MaterialGrupaRefId = 3, Nazwa = "CAST - 169" });
                matLista.Add(new Material { MaterialId = 665, MaterialGrupaRefId = 3, Nazwa = "CAST - 18" });
                matLista.Add(new Material { MaterialId = 666, MaterialGrupaRefId = 3, Nazwa = "CAST - 2" });
                matLista.Add(new Material { MaterialId = 667, MaterialGrupaRefId = 3, Nazwa = "CAST - 53" });
                matLista.Add(new Material { MaterialId = 668, MaterialGrupaRefId = 3, Nazwa = "CAST - 60" });
                matLista.Add(new Material { MaterialId = 669, MaterialGrupaRefId = 3, Nazwa = "CAST - 67" });
                matLista.Add(new Material { MaterialId = 670, MaterialGrupaRefId = 3, Nazwa = "CAST - 68" });
                matLista.Add(new Material { MaterialId = 671, MaterialGrupaRefId = 3, Nazwa = "CAST - 9" });
                matLista.Add(new Material { MaterialId = 672, MaterialGrupaRefId = 3, Nazwa = "CERVINO - 56" });
                matLista.Add(new Material { MaterialId = 673, MaterialGrupaRefId = 3, Nazwa = "CERVINO - PETROL 56" });
                matLista.Add(new Material { MaterialId = 674, MaterialGrupaRefId = 3, Nazwa = "CHIC - BEIGE 05" });
                matLista.Add(new Material { MaterialId = 675, MaterialGrupaRefId = 3, Nazwa = "COOL - 12" });
                matLista.Add(new Material { MaterialId = 676, MaterialGrupaRefId = 3, Nazwa = "COOL - 43" });
                matLista.Add(new Material { MaterialId = 677, MaterialGrupaRefId = 3, Nazwa = "COOL - 78" });
                matLista.Add(new Material { MaterialId = 678, MaterialGrupaRefId = 3, Nazwa = "CRAQUELE LEATHER" });
                matLista.Add(new Material { MaterialId = 679, MaterialGrupaRefId = 3, Nazwa = "CRAQUELE ZWART" });
                matLista.Add(new Material { MaterialId = 680, MaterialGrupaRefId = 3, Nazwa = "ECO LEATHER - BISCIUT" });
                matLista.Add(new Material { MaterialId = 681, MaterialGrupaRefId = 3, Nazwa = "ECO LEATHER - BLACK UNI" });
                matLista.Add(new Material { MaterialId = 682, MaterialGrupaRefId = 3, Nazwa = "ECO LEATHER - DARK BROWN" });
                matLista.Add(new Material { MaterialId = 683, MaterialGrupaRefId = 3, Nazwa = "ECO LEATHER - MANILLA" });
                matLista.Add(new Material { MaterialId = 684, MaterialGrupaRefId = 3, Nazwa = "ECO LEATHER - MOCHA" });
                matLista.Add(new Material { MaterialId = 685, MaterialGrupaRefId = 3, Nazwa = "ECO LEATHER - SAND" });
                matLista.Add(new Material { MaterialId = 686, MaterialGrupaRefId = 3, Nazwa = "ECO LEATHER - SUMMER BROWN" });
                matLista.Add(new Material { MaterialId = 687, MaterialGrupaRefId = 3, Nazwa = "ECO LEATHER - VINTAGE" });
                matLista.Add(new Material { MaterialId = 688, MaterialGrupaRefId = 3, Nazwa = "ELDORADO - 603" });
                matLista.Add(new Material { MaterialId = 689, MaterialGrupaRefId = 3, Nazwa = "ELDORADO - 705" });
                matLista.Add(new Material { MaterialId = 690, MaterialGrupaRefId = 3, Nazwa = "ELDORADO - 902" });
                matLista.Add(new Material { MaterialId = 691, MaterialGrupaRefId = 3, Nazwa = "ELDORADO - 903" });
                matLista.Add(new Material { MaterialId = 692, MaterialGrupaRefId = 3, Nazwa = "ELDORADO - 904" });
                matLista.Add(new Material { MaterialId = 693, MaterialGrupaRefId = 3, Nazwa = "ELLE - 10" });
                matLista.Add(new Material { MaterialId = 694, MaterialGrupaRefId = 3, Nazwa = "ELLE - 115" });
                matLista.Add(new Material { MaterialId = 695, MaterialGrupaRefId = 3, Nazwa = "ELLE - 12" });
                matLista.Add(new Material { MaterialId = 696, MaterialGrupaRefId = 3, Nazwa = "ELLE - 18" });
                matLista.Add(new Material { MaterialId = 697, MaterialGrupaRefId = 3, Nazwa = "ELLE - 49" });
                matLista.Add(new Material { MaterialId = 698, MaterialGrupaRefId = 3, Nazwa = "ELLE - 51" });
                matLista.Add(new Material { MaterialId = 699, MaterialGrupaRefId = 3, Nazwa = "ELLE - 67" });
                matLista.Add(new Material { MaterialId = 700, MaterialGrupaRefId = 3, Nazwa = "ELLE - 68" });
                matLista.Add(new Material { MaterialId = 701, MaterialGrupaRefId = 3, Nazwa = "FACET - 1001" });
                matLista.Add(new Material { MaterialId = 702, MaterialGrupaRefId = 3, Nazwa = "FINE - 14" });
                matLista.Add(new Material { MaterialId = 703, MaterialGrupaRefId = 3, Nazwa = "FINE - 3" });
                matLista.Add(new Material { MaterialId = 704, MaterialGrupaRefId = 3, Nazwa = "FINE - 68" });
                matLista.Add(new Material { MaterialId = 705, MaterialGrupaRefId = 3, Nazwa = "FIXX - 14" });
                matLista.Add(new Material { MaterialId = 706, MaterialGrupaRefId = 3, Nazwa = "FIXX - 3" });
                matLista.Add(new Material { MaterialId = 707, MaterialGrupaRefId = 3, Nazwa = "FIXX - 61" });
                matLista.Add(new Material { MaterialId = 708, MaterialGrupaRefId = 3, Nazwa = "FIXX - 68" });
                matLista.Add(new Material { MaterialId = 709, MaterialGrupaRefId = 3, Nazwa = "FLASH - 102" });
                matLista.Add(new Material { MaterialId = 710, MaterialGrupaRefId = 3, Nazwa = "FLASH - 12" });
                matLista.Add(new Material { MaterialId = 711, MaterialGrupaRefId = 3, Nazwa = "FLASH - 13" });
                matLista.Add(new Material { MaterialId = 712, MaterialGrupaRefId = 3, Nazwa = "FLASH - 15" });
                matLista.Add(new Material { MaterialId = 713, MaterialGrupaRefId = 3, Nazwa = "FLASH - 169" });
                matLista.Add(new Material { MaterialId = 714, MaterialGrupaRefId = 3, Nazwa = "FLASH - 3" });
                matLista.Add(new Material { MaterialId = 715, MaterialGrupaRefId = 3, Nazwa = "FLASH - 43" });
                matLista.Add(new Material { MaterialId = 716, MaterialGrupaRefId = 3, Nazwa = "FLASH - 48" });
                matLista.Add(new Material { MaterialId = 717, MaterialGrupaRefId = 3, Nazwa = "FLASH - 67" });
                matLista.Add(new Material { MaterialId = 718, MaterialGrupaRefId = 3, Nazwa = "FLASH - 68" });
                matLista.Add(new Material { MaterialId = 719, MaterialGrupaRefId = 3, Nazwa = "GALA - 5" });
                matLista.Add(new Material { MaterialId = 720, MaterialGrupaRefId = 3, Nazwa = "GALA - 67" });
                matLista.Add(new Material { MaterialId = 721, MaterialGrupaRefId = 3, Nazwa = "GROUND - 115" });
                matLista.Add(new Material { MaterialId = 722, MaterialGrupaRefId = 3, Nazwa = "GROUND - 15" });
                matLista.Add(new Material { MaterialId = 723, MaterialGrupaRefId = 3, Nazwa = "GROUND - 5" });
                matLista.Add(new Material { MaterialId = 724, MaterialGrupaRefId = 3, Nazwa = "GROUND - 66" });
                matLista.Add(new Material { MaterialId = 725, MaterialGrupaRefId = 3, Nazwa = "JAMES - 169" });
                matLista.Add(new Material { MaterialId = 726, MaterialGrupaRefId = 3, Nazwa = "JAMES - 05 BEIGE" });
                matLista.Add(new Material { MaterialId = 727, MaterialGrupaRefId = 3, Nazwa = "JAMES - 101 IVORY" });
                matLista.Add(new Material { MaterialId = 728, MaterialGrupaRefId = 3, Nazwa = "JAMES - 104 WHITE" });
                matLista.Add(new Material { MaterialId = 729, MaterialGrupaRefId = 3, Nazwa = "JAMES - 12 TAUPE" });
                matLista.Add(new Material { MaterialId = 730, MaterialGrupaRefId = 3, Nazwa = "JAMES - 168 PLUM" });
                matLista.Add(new Material { MaterialId = 731, MaterialGrupaRefId = 3, Nazwa = "JAMES - 17 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 732, MaterialGrupaRefId = 3, Nazwa = "JAMES - 40 ASH GREY" });
                matLista.Add(new Material { MaterialId = 733, MaterialGrupaRefId = 3, Nazwa = "JAMES - 65 GREY" });
                matLista.Add(new Material { MaterialId = 734, MaterialGrupaRefId = 3, Nazwa = "JAMES - 67 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 735, MaterialGrupaRefId = 3, Nazwa = "JAZZ - 11" });
                matLista.Add(new Material { MaterialId = 736, MaterialGrupaRefId = 3, Nazwa = "JAZZ - 123" });
                matLista.Add(new Material { MaterialId = 737, MaterialGrupaRefId = 3, Nazwa = "JAZZ - 143" });
                matLista.Add(new Material { MaterialId = 738, MaterialGrupaRefId = 3, Nazwa = "JAZZ - 60" });
                matLista.Add(new Material { MaterialId = 739, MaterialGrupaRefId = 3, Nazwa = "JAZZ - 67" });
                matLista.Add(new Material { MaterialId = 740, MaterialGrupaRefId = 3, Nazwa = "JAZZ - 78" });
                matLista.Add(new Material { MaterialId = 741, MaterialGrupaRefId = 3, Nazwa = "JUKE - 101" });
                matLista.Add(new Material { MaterialId = 742, MaterialGrupaRefId = 3, Nazwa = "JUKE - 12" });
                matLista.Add(new Material { MaterialId = 743, MaterialGrupaRefId = 3, Nazwa = "JUKE - 15" });
                matLista.Add(new Material { MaterialId = 744, MaterialGrupaRefId = 3, Nazwa = "JUKE - 160" });
                matLista.Add(new Material { MaterialId = 745, MaterialGrupaRefId = 3, Nazwa = "JUKE - 169" });
                matLista.Add(new Material { MaterialId = 746, MaterialGrupaRefId = 3, Nazwa = "JUKE - 3" });
                matLista.Add(new Material { MaterialId = 747, MaterialGrupaRefId = 3, Nazwa = "JUKE - 45" });
                matLista.Add(new Material { MaterialId = 748, MaterialGrupaRefId = 3, Nazwa = "JUKE - 51" });
                matLista.Add(new Material { MaterialId = 749, MaterialGrupaRefId = 3, Nazwa = "JUKE - 65" });
                matLista.Add(new Material { MaterialId = 750, MaterialGrupaRefId = 3, Nazwa = "JUKE - 67" });
                matLista.Add(new Material { MaterialId = 751, MaterialGrupaRefId = 3, Nazwa = "JUKE - 71" });
                matLista.Add(new Material { MaterialId = 752, MaterialGrupaRefId = 3, Nazwa = "JUKE - 78" });
                matLista.Add(new Material { MaterialId = 753, MaterialGrupaRefId = 3, Nazwa = "JUKE - 123 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 754, MaterialGrupaRefId = 3, Nazwa = "JUKE - GRASS" });
                matLista.Add(new Material { MaterialId = 755, MaterialGrupaRefId = 3, Nazwa = "JUKE - MUSHROOM" });
                matLista.Add(new Material { MaterialId = 756, MaterialGrupaRefId = 3, Nazwa = "KENIA - LEATHER WALNUT" });
                matLista.Add(new Material { MaterialId = 757, MaterialGrupaRefId = 3, Nazwa = "KENYA - 9" });
                matLista.Add(new Material { MaterialId = 758, MaterialGrupaRefId = 3, Nazwa = "KISS - 181" });
                matLista.Add(new Material { MaterialId = 759, MaterialGrupaRefId = 3, Nazwa = "KISS - 65" });
                matLista.Add(new Material { MaterialId = 760, MaterialGrupaRefId = 3, Nazwa = "KISS - 66" });
                matLista.Add(new Material { MaterialId = 761, MaterialGrupaRefId = 3, Nazwa = "LETTER - 65" });
                matLista.Add(new Material { MaterialId = 762, MaterialGrupaRefId = 3, Nazwa = "LYNX - 1" });
                matLista.Add(new Material { MaterialId = 763, MaterialGrupaRefId = 3, Nazwa = "MEDAILLON - 1" });
                matLista.Add(new Material { MaterialId = 764, MaterialGrupaRefId = 3, Nazwa = "MEDAILLON - 65" });
                matLista.Add(new Material { MaterialId = 765, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 104" });
                matLista.Add(new Material { MaterialId = 766, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 110" });
                matLista.Add(new Material { MaterialId = 767, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 112" });
                matLista.Add(new Material { MaterialId = 768, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 117" });
                matLista.Add(new Material { MaterialId = 769, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 123" });
                matLista.Add(new Material { MaterialId = 770, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 124" });
                matLista.Add(new Material { MaterialId = 771, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 168" });
                matLista.Add(new Material { MaterialId = 772, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 181" });
                matLista.Add(new Material { MaterialId = 773, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 65" });
                matLista.Add(new Material { MaterialId = 774, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 03E" });
                matLista.Add(new Material { MaterialId = 775, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 18K" });
                matLista.Add(new Material { MaterialId = 776, MaterialGrupaRefId = 3, Nazwa = "MONFORT - 89D" });
                matLista.Add(new Material { MaterialId = 777, MaterialGrupaRefId = 3, Nazwa = "MONFORT - BH2" });
                matLista.Add(new Material { MaterialId = 778, MaterialGrupaRefId = 3, Nazwa = "MONFORT - BH4" });
                matLista.Add(new Material { MaterialId = 779, MaterialGrupaRefId = 3, Nazwa = "MOON - 12" });
                matLista.Add(new Material { MaterialId = 780, MaterialGrupaRefId = 3, Nazwa = "MOON - 65" });
                matLista.Add(new Material { MaterialId = 781, MaterialGrupaRefId = 3, Nazwa = "MULTI - 31" });
                matLista.Add(new Material { MaterialId = 782, MaterialGrupaRefId = 3, Nazwa = "MULTI - 65" });
                matLista.Add(new Material { MaterialId = 783, MaterialGrupaRefId = 3, Nazwa = "NATUR - PEARL" });
                matLista.Add(new Material { MaterialId = 784, MaterialGrupaRefId = 3, Nazwa = "NOWE JUKE - MUSCHROOM" });
                matLista.Add(new Material { MaterialId = 785, MaterialGrupaRefId = 3, Nazwa = "NOWE JUKE - SAND" });
                matLista.Add(new Material { MaterialId = 786, MaterialGrupaRefId = 3, Nazwa = "NOWE JUKE - TAUPE" });
                matLista.Add(new Material { MaterialId = 787, MaterialGrupaRefId = 3, Nazwa = "OLBIA - 10" });
                matLista.Add(new Material { MaterialId = 788, MaterialGrupaRefId = 3, Nazwa = "OLBIA - 102" });
                matLista.Add(new Material { MaterialId = 789, MaterialGrupaRefId = 3, Nazwa = "OLBIA - 11" });
                matLista.Add(new Material { MaterialId = 790, MaterialGrupaRefId = 3, Nazwa = "OLBIA - 12" });
                matLista.Add(new Material { MaterialId = 791, MaterialGrupaRefId = 3, Nazwa = "OLBIA - 181" });
                matLista.Add(new Material { MaterialId = 792, MaterialGrupaRefId = 3, Nazwa = "OLBIA - 3" });
                matLista.Add(new Material { MaterialId = 793, MaterialGrupaRefId = 3, Nazwa = "OLBIA - 66" });
                matLista.Add(new Material { MaterialId = 794, MaterialGrupaRefId = 3, Nazwa = "ONES - 101" });
                matLista.Add(new Material { MaterialId = 795, MaterialGrupaRefId = 3, Nazwa = "ONES - 12" });
                matLista.Add(new Material { MaterialId = 796, MaterialGrupaRefId = 3, Nazwa = "ONES - 123" });
                matLista.Add(new Material { MaterialId = 797, MaterialGrupaRefId = 3, Nazwa = "ONES - 169" });
                matLista.Add(new Material { MaterialId = 798, MaterialGrupaRefId = 3, Nazwa = "ONES - 66" });
                matLista.Add(new Material { MaterialId = 799, MaterialGrupaRefId = 3, Nazwa = "PEONY - GREY" });
                matLista.Add(new Material { MaterialId = 800, MaterialGrupaRefId = 3, Nazwa = "PEONY - LIGHT GREY" });
                matLista.Add(new Material { MaterialId = 801, MaterialGrupaRefId = 3, Nazwa = "PEONY - SAND" });
                matLista.Add(new Material { MaterialId = 802, MaterialGrupaRefId = 3, Nazwa = "REINA - 62" });
                matLista.Add(new Material { MaterialId = 803, MaterialGrupaRefId = 3, Nazwa = "RHODOS - 65" });
                matLista.Add(new Material { MaterialId = 804, MaterialGrupaRefId = 3, Nazwa = "ROUGE - 0" });
                matLista.Add(new Material { MaterialId = 805, MaterialGrupaRefId = 3, Nazwa = "ROUGE - 0" });
                matLista.Add(new Material { MaterialId = 806, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 1" });
                matLista.Add(new Material { MaterialId = 807, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 10" });
                matLista.Add(new Material { MaterialId = 808, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 102" });
                matLista.Add(new Material { MaterialId = 809, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 104" });
                matLista.Add(new Material { MaterialId = 810, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 106" });
                matLista.Add(new Material { MaterialId = 811, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 11" });
                matLista.Add(new Material { MaterialId = 812, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 110" });
                matLista.Add(new Material { MaterialId = 813, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 111" });
                matLista.Add(new Material { MaterialId = 814, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 12" });
                matLista.Add(new Material { MaterialId = 815, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 123" });
                matLista.Add(new Material { MaterialId = 816, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 14" });
                matLista.Add(new Material { MaterialId = 817, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 145" });
                matLista.Add(new Material { MaterialId = 818, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 151" });
                matLista.Add(new Material { MaterialId = 819, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 154" });
                matLista.Add(new Material { MaterialId = 820, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 18" });
                matLista.Add(new Material { MaterialId = 821, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 2" });
                matLista.Add(new Material { MaterialId = 822, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 27" });
                matLista.Add(new Material { MaterialId = 823, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 37" });
                matLista.Add(new Material { MaterialId = 824, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 39" });
                matLista.Add(new Material { MaterialId = 825, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 4" });
                matLista.Add(new Material { MaterialId = 826, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 43" });
                matLista.Add(new Material { MaterialId = 827, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 60" });
                matLista.Add(new Material { MaterialId = 828, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 65" });
                matLista.Add(new Material { MaterialId = 829, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 67" });
                matLista.Add(new Material { MaterialId = 830, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 68" });
                matLista.Add(new Material { MaterialId = 831, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 7" });
                matLista.Add(new Material { MaterialId = 832, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 78" });
                matLista.Add(new Material { MaterialId = 833, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 81" });
                matLista.Add(new Material { MaterialId = 834, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 83" });
                matLista.Add(new Material { MaterialId = 835, MaterialGrupaRefId = 3, Nazwa = "SHADOW - 88" });
                matLista.Add(new Material { MaterialId = 836, MaterialGrupaRefId = 3, Nazwa = "SHAKE - 10" });
                matLista.Add(new Material { MaterialId = 837, MaterialGrupaRefId = 3, Nazwa = "SHAKE - 103" });
                matLista.Add(new Material { MaterialId = 838, MaterialGrupaRefId = 3, Nazwa = "SHAKE - 15" });
                matLista.Add(new Material { MaterialId = 839, MaterialGrupaRefId = 3, Nazwa = "SHAKE - 169" });
                matLista.Add(new Material { MaterialId = 840, MaterialGrupaRefId = 3, Nazwa = "SHAKE - 67" });
                matLista.Add(new Material { MaterialId = 841, MaterialGrupaRefId = 3, Nazwa = "SHAKE - 7" });
                matLista.Add(new Material { MaterialId = 842, MaterialGrupaRefId = 3, Nazwa = "SHAKE - 74" });
                matLista.Add(new Material { MaterialId = 843, MaterialGrupaRefId = 3, Nazwa = "SHAKE - 9" });
                matLista.Add(new Material { MaterialId = 844, MaterialGrupaRefId = 3, Nazwa = "SK”RA - PREMIUM COGNAC" });
                matLista.Add(new Material { MaterialId = 845, MaterialGrupaRefId = 3, Nazwa = "SK”RA - PRISMA MARINE" });
                matLista.Add(new Material { MaterialId = 846, MaterialGrupaRefId = 3, Nazwa = "SK”RA - PRISMA OLIVE" });
                matLista.Add(new Material { MaterialId = 847, MaterialGrupaRefId = 3, Nazwa = "STRADA - 10" });
                matLista.Add(new Material { MaterialId = 848, MaterialGrupaRefId = 3, Nazwa = "SUN - 2" });
                matLista.Add(new Material { MaterialId = 849, MaterialGrupaRefId = 3, Nazwa = "TOLEDO - FERRARI" });
                matLista.Add(new Material { MaterialId = 850, MaterialGrupaRefId = 3, Nazwa = "TOLEDO - NERO" });
                matLista.Add(new Material { MaterialId = 851, MaterialGrupaRefId = 3, Nazwa = "URBAN - 10" });
                matLista.Add(new Material { MaterialId = 852, MaterialGrupaRefId = 3, Nazwa = "URBAN - 15" });
                matLista.Add(new Material { MaterialId = 853, MaterialGrupaRefId = 3, Nazwa = "URBAN - 169" });
                matLista.Add(new Material { MaterialId = 854, MaterialGrupaRefId = 3, Nazwa = "URBAN - 17" });
                matLista.Add(new Material { MaterialId = 855, MaterialGrupaRefId = 3, Nazwa = "URBAN - 18" });
                matLista.Add(new Material { MaterialId = 856, MaterialGrupaRefId = 3, Nazwa = "URBAN - 41" });
                matLista.Add(new Material { MaterialId = 857, MaterialGrupaRefId = 3, Nazwa = "URBAN - 49" });
                matLista.Add(new Material { MaterialId = 858, MaterialGrupaRefId = 3, Nazwa = "URBAN - 65" });
                matLista.Add(new Material { MaterialId = 859, MaterialGrupaRefId = 3, Nazwa = "URBAN - 67" });
                matLista.Add(new Material { MaterialId = 860, MaterialGrupaRefId = 3, Nazwa = "ZONE - 9" });
                matLista.Add(new Material { MaterialId = 861, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - LIGHT UMBER-86903" });
                matLista.Add(new Material { MaterialId = 862, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - EMARALD-86910" });
                matLista.Add(new Material { MaterialId = 863, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - PLATINUM-86922" });
                matLista.Add(new Material { MaterialId = 864, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - CAPPUCCINO-87005" });
                matLista.Add(new Material { MaterialId = 865, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - DARK GREY-87017" });
                matLista.Add(new Material { MaterialId = 866, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - AUBERGINE-87018" });
                matLista.Add(new Material { MaterialId = 867, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - GINGER-87020" });
                matLista.Add(new Material { MaterialId = 868, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - BLACK-87025" });
                matLista.Add(new Material { MaterialId = 869, MaterialGrupaRefId = 4, Nazwa = "ANCONA/DJANGO - GREY- 87023" });
                matLista.Add(new Material { MaterialId = 870, MaterialGrupaRefId = 4, Nazwa = "ASHLY/SOUND - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 871, MaterialGrupaRefId = 4, Nazwa = "ASHLY/SOUND - 18 DARKBROWN" });
                matLista.Add(new Material { MaterialId = 872, MaterialGrupaRefId = 4, Nazwa = "ASHLY/SOUND - 35 TERRA" });
                matLista.Add(new Material { MaterialId = 873, MaterialGrupaRefId = 4, Nazwa = "ASHLY/SOUND - 49 NAVY" });
                matLista.Add(new Material { MaterialId = 874, MaterialGrupaRefId = 4, Nazwa = "ASHTON - 13 SAHARA/DESERT" });
                matLista.Add(new Material { MaterialId = 875, MaterialGrupaRefId = 4, Nazwa = "ASHTON - 235 UMBAR" });
                matLista.Add(new Material { MaterialId = 876, MaterialGrupaRefId = 4, Nazwa = "ASHTON - 250 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 877, MaterialGrupaRefId = 4, Nazwa = "ASHTON - 516 CHARCOAL" });
                matLista.Add(new Material { MaterialId = 878, MaterialGrupaRefId = 4, Nazwa = "ASHTON - 770 GREY" });
                matLista.Add(new Material { MaterialId = 879, MaterialGrupaRefId = 4, Nazwa = "BAHAMA - 33" });
                matLista.Add(new Material { MaterialId = 880, MaterialGrupaRefId = 4, Nazwa = "BAHAMA - 34" });
                matLista.Add(new Material { MaterialId = 881, MaterialGrupaRefId = 4, Nazwa = "BAHAMA - 41" });
                matLista.Add(new Material { MaterialId = 882, MaterialGrupaRefId = 4, Nazwa = "BALTIMOR/OSLO ANTRACITE - 801" });
                matLista.Add(new Material { MaterialId = 883, MaterialGrupaRefId = 4, Nazwa = "BALTIMOR/OSLO TAUPE - 802" });
                matLista.Add(new Material { MaterialId = 884, MaterialGrupaRefId = 4, Nazwa = "BALTIMOR/OSLO MOUSE - 804" });
                matLista.Add(new Material { MaterialId = 885, MaterialGrupaRefId = 4, Nazwa = "BALTIMOR/OSLO RAW LINENE - 904" });
                matLista.Add(new Material { MaterialId = 886, MaterialGrupaRefId = 4, Nazwa = "BOSTON LIVER/JUST COTT BROWN - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 887, MaterialGrupaRefId = 4, Nazwa = "BOSTON D. GREY/JUST COTT ANTRAC - 46 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 888, MaterialGrupaRefId = 4, Nazwa = "BOSTON SILVERGREY/JUST COTT L. SILVER - 120 SILVER" });
                matLista.Add(new Material { MaterialId = 889, MaterialGrupaRefId = 4, Nazwa = "BREAK/BRACKSTON - 1NATURAL" });
                matLista.Add(new Material { MaterialId = 890, MaterialGrupaRefId = 4, Nazwa = "BREAK/BRACKSTON - 10 LIVER" });
                matLista.Add(new Material { MaterialId = 891, MaterialGrupaRefId = 4, Nazwa = "BREAK/BRACKSTON - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 892, MaterialGrupaRefId = 4, Nazwa = "BREAK/BRACKSTON - 35 RED" });
                matLista.Add(new Material { MaterialId = 893, MaterialGrupaRefId = 4, Nazwa = "BREAK/BRACKSTON - 65 GREY" });
                matLista.Add(new Material { MaterialId = 894, MaterialGrupaRefId = 4, Nazwa = "BREAK/BRACKSTON - 76 PRUNE" });
                matLista.Add(new Material { MaterialId = 895, MaterialGrupaRefId = 4, Nazwa = "BREAK/BRACKSTON - 169 ONYX" });
                matLista.Add(new Material { MaterialId = 896, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS/BUFFALO WHITE - 03/01 PURE WHITE" });
                matLista.Add(new Material { MaterialId = 897, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS /Buffalo - 08 BROWN" });
                matLista.Add(new Material { MaterialId = 898, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS/Buffalo - 32 red" });
                matLista.Add(new Material { MaterialId = 899, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS /Buffalo - 45 GREY" });
                matLista.Add(new Material { MaterialId = 900, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS /Buffalo - 115 SILVER-GREY" });
                matLista.Add(new Material { MaterialId = 901, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS /Buffalo - 121 SILVER" });
                matLista.Add(new Material { MaterialId = 902, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS /Buffalo D. BROWN - 240 BROWN-BLACK" });
                matLista.Add(new Material { MaterialId = 903, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS/Buffalo ANTRACITE - 516 CHARCOAL" });
                matLista.Add(new Material { MaterialId = 904, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS/Buffalo OKER - 520 MUSTARD" });
                matLista.Add(new Material { MaterialId = 905, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS/Buffalo STONE - 608 LIGHT " });
                matLista.Add(new Material { MaterialId = 906, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS/Buffalo LIVER - 750 OLIVE-GREY" });
                matLista.Add(new Material { MaterialId = 907, MaterialGrupaRefId = 4, Nazwa = "KNIGHTS/Buffalo - 780 BLACK" });
                matLista.Add(new Material { MaterialId = 908, MaterialGrupaRefId = 4, Nazwa = "CATANIA - 501 LIGHT OCHER" });
                matLista.Add(new Material { MaterialId = 909, MaterialGrupaRefId = 4, Nazwa = "CATANIA - 600 TEAL BLUE" });
                matLista.Add(new Material { MaterialId = 910, MaterialGrupaRefId = 4, Nazwa = "CATANIA - 604 EMARALD" });
                matLista.Add(new Material { MaterialId = 911, MaterialGrupaRefId = 4, Nazwa = "CATANIA - 701 LAVENDER" });
                matLista.Add(new Material { MaterialId = 912, MaterialGrupaRefId = 4, Nazwa = "CATANIA - 801-GRAPHITE" });
                matLista.Add(new Material { MaterialId = 913, MaterialGrupaRefId = 4, Nazwa = "CHARTRES KHAKI - F 029" });
                matLista.Add(new Material { MaterialId = 914, MaterialGrupaRefId = 4, Nazwa = "CHARTRES SHALE - F 026" });
                matLista.Add(new Material { MaterialId = 915, MaterialGrupaRefId = 4, Nazwa = "CHARTRES CARBON - F 025" });
                matLista.Add(new Material { MaterialId = 916, MaterialGrupaRefId = 4, Nazwa = "CHECKERS BLACK - 18108" });
                matLista.Add(new Material { MaterialId = 917, MaterialGrupaRefId = 4, Nazwa = "CHECKERS BROWN - 18113" });
                matLista.Add(new Material { MaterialId = 918, MaterialGrupaRefId = 4, Nazwa = "CLARKDALE/LETTER SAND - 01 NATURAL" });
                matLista.Add(new Material { MaterialId = 919, MaterialGrupaRefId = 4, Nazwa = "CLARKDALE/LETTER GREY - 65 GREY" });
                matLista.Add(new Material { MaterialId = 920, MaterialGrupaRefId = 4, Nazwa = "CLARKDALE/LETTER ARMY - 101 IVORY" });
                matLista.Add(new Material { MaterialId = 921, MaterialGrupaRefId = 4, Nazwa = "CORDOBA - 102 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 922, MaterialGrupaRefId = 4, Nazwa = "CORDOBA - 103 MUSHROOM" });
                matLista.Add(new Material { MaterialId = 923, MaterialGrupaRefId = 4, Nazwa = "CORDOBA - 800 STEEL" });
                matLista.Add(new Material { MaterialId = 924, MaterialGrupaRefId = 4, Nazwa = "CORDOBA - 801 TAUPE" });
                matLista.Add(new Material { MaterialId = 925, MaterialGrupaRefId = 4, Nazwa = "CORDOBA - 802 SILVER GREY" });
                matLista.Add(new Material { MaterialId = 926, MaterialGrupaRefId = 4, Nazwa = "CORDOBA - 806 CHARCOAL" });
                matLista.Add(new Material { MaterialId = 927, MaterialGrupaRefId = 4, Nazwa = "CORDUROY 7004 taupe - 21 SAND/1221" });
                matLista.Add(new Material { MaterialId = 928, MaterialGrupaRefId = 4, Nazwa = "CORDUROY 8003 brown - 24 BROWN/1224" });
                matLista.Add(new Material { MaterialId = 929, MaterialGrupaRefId = 4, Nazwa = "CORDUROY 0005 natural - 35 OFF WHITE/1235" });
                matLista.Add(new Material { MaterialId = 930, MaterialGrupaRefId = 4, Nazwa = "CORDUROY 7003 antracite - 68 GREY/1268" });
                matLista.Add(new Material { MaterialId = 931, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - BH4 DARKGREY" });
                matLista.Add(new Material { MaterialId = 932, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 03E ICEBLUE" });
                matLista.Add(new Material { MaterialId = 933, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 14K AUBERGINE" });
                matLista.Add(new Material { MaterialId = 934, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 17K BROWN" });
                matLista.Add(new Material { MaterialId = 935, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 82D CREAM" });
                matLista.Add(new Material { MaterialId = 936, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 89D OUDROSE" });
                matLista.Add(new Material { MaterialId = 937, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 104 WHITE" });
                matLista.Add(new Material { MaterialId = 938, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 110 LIVER" });
                matLista.Add(new Material { MaterialId = 939, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 114 ARMY" });
                matLista.Add(new Material { MaterialId = 940, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 168 PLUM" });
                matLista.Add(new Material { MaterialId = 941, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 181 STONE" });
                matLista.Add(new Material { MaterialId = 942, MaterialGrupaRefId = 4, Nazwa = "COTTONFIELD/MONFORT - 916 NATURAL" });
                matLista.Add(new Material { MaterialId = 943, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON WHITE - 02 WHITE" });
                matLista.Add(new Material { MaterialId = 944, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON BROWN - 04 TOFFEE" });
                matLista.Add(new Material { MaterialId = 945, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON OCEAN - 10 NAVY" });
                matLista.Add(new Material { MaterialId = 946, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON DESERT - 13 SAHARA" });
                matLista.Add(new Material { MaterialId = 947, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON BLACK - 17 BLACK" });
                matLista.Add(new Material { MaterialId = 948, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON RED - 35 CHERRY" });
                matLista.Add(new Material { MaterialId = 949, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON PURPLE - 41 PURPLE" });
                matLista.Add(new Material { MaterialId = 950, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON ANTRACITE - 44 STEEL" });
                matLista.Add(new Material { MaterialId = 951, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON SILVER - 121 SILVER" });
                matLista.Add(new Material { MaterialId = 952, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON SPRING - 434 KIWI" });
                matLista.Add(new Material { MaterialId = 953, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON PINK - 1675 PINK" });
                matLista.Add(new Material { MaterialId = 954, MaterialGrupaRefId = 4, Nazwa = "CRAILO/MAISON GREEN - 751 OLIVE" });
                matLista.Add(new Material { MaterialId = 955, MaterialGrupaRefId = 4, Nazwa = "CUBE - 15 BROWN" });
                matLista.Add(new Material { MaterialId = 956, MaterialGrupaRefId = 4, Nazwa = "CUBE - 17 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 957, MaterialGrupaRefId = 4, Nazwa = "CUBE - 60 LIGHTGREY" });
                matLista.Add(new Material { MaterialId = 958, MaterialGrupaRefId = 4, Nazwa = "CUBE - 65 GREY" });
                matLista.Add(new Material { MaterialId = 959, MaterialGrupaRefId = 4, Nazwa = "CUBE - 68 DARKGREY" });
                matLista.Add(new Material { MaterialId = 960, MaterialGrupaRefId = 4, Nazwa = "CUBE - 78 PURPLE" });
                matLista.Add(new Material { MaterialId = 961, MaterialGrupaRefId = 4, Nazwa = "CUBE - 101 IVORY" });
                matLista.Add(new Material { MaterialId = 962, MaterialGrupaRefId = 4, Nazwa = "CUBE - 113 SESAME" });
                matLista.Add(new Material { MaterialId = 963, MaterialGrupaRefId = 4, Nazwa = "CUBE - 123 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 964, MaterialGrupaRefId = 4, Nazwa = "MICROFIBER/DEXTER GREY - MICROFIBER 45 GREY" });
                matLista.Add(new Material { MaterialId = 965, MaterialGrupaRefId = 4, Nazwa = "MICROFIBER/DEXTER ESPRESSO - MICROFIBER 210 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 966, MaterialGrupaRefId = 4, Nazwa = "MICROFIBER/DEXTER TERRA - MICROFIBER 511" });
                matLista.Add(new Material { MaterialId = 967, MaterialGrupaRefId = 4, Nazwa = "FINE - 61 BLACK" });
                matLista.Add(new Material { MaterialId = 968, MaterialGrupaRefId = 4, Nazwa = "FINE - 68 DARKGREY" });
                matLista.Add(new Material { MaterialId = 969, MaterialGrupaRefId = 4, Nazwa = "FUEL - 61 BLACK" });
                matLista.Add(new Material { MaterialId = 970, MaterialGrupaRefId = 4, Nazwa = "FUEL - 68 DARKGREY" });
                matLista.Add(new Material { MaterialId = 971, MaterialGrupaRefId = 4, Nazwa = "GALARDO LEATHER - BROWN" });
                matLista.Add(new Material { MaterialId = 972, MaterialGrupaRefId = 4, Nazwa = "GALARDO LEATHER - DARK BROWN" });
                matLista.Add(new Material { MaterialId = 973, MaterialGrupaRefId = 4, Nazwa = "GALARDO LEATHER - DEARK GREY" });
                matLista.Add(new Material { MaterialId = 974, MaterialGrupaRefId = 4, Nazwa = "GALARDO LEATHER - BLACK" });
                matLista.Add(new Material { MaterialId = 975, MaterialGrupaRefId = 4, Nazwa = "GALARDO LEATHER - CAPUCCINO" });
                matLista.Add(new Material { MaterialId = 976, MaterialGrupaRefId = 4, Nazwa = "GALARDO LEATHER - PEPPER/ESPRESSO" });
                matLista.Add(new Material { MaterialId = 977, MaterialGrupaRefId = 4, Nazwa = "MISSOURI/GALLARDO LEDER - A03 Grey" });
                matLista.Add(new Material { MaterialId = 978, MaterialGrupaRefId = 4, Nazwa = "MISSOURI/GALLARDO LEDER - A06 Brown" });
                matLista.Add(new Material { MaterialId = 979, MaterialGrupaRefId = 4, Nazwa = "MISSOURI/GALLARDO LEDER - A08 Dark Brown" });
                matLista.Add(new Material { MaterialId = 980, MaterialGrupaRefId = 4, Nazwa = "MISSOURI/GALLARDO LEDER - A19 Espresso" });
                matLista.Add(new Material { MaterialId = 981, MaterialGrupaRefId = 4, Nazwa = "MISSOURI/GALLARDO LEDER - A59 Pepper" });
                matLista.Add(new Material { MaterialId = 982, MaterialGrupaRefId = 4, Nazwa = "MISSOURI/GALLARDO LEDER - A61 Capuccino" });
                matLista.Add(new Material { MaterialId = 983, MaterialGrupaRefId = 4, Nazwa = "MISSOURI/GALLARDO LEDER - A73 Black" });
                matLista.Add(new Material { MaterialId = 984, MaterialGrupaRefId = 4, Nazwa = "GOMERA - 2" });
                matLista.Add(new Material { MaterialId = 985, MaterialGrupaRefId = 4, Nazwa = "GOMERA - 6" });
                matLista.Add(new Material { MaterialId = 986, MaterialGrupaRefId = 4, Nazwa = "GOMERA - 26" });
                matLista.Add(new Material { MaterialId = 987, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB ECRUE - 0004-BEIGE" });
                matLista.Add(new Material { MaterialId = 988, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB - 1002-OKER" });
                matLista.Add(new Material { MaterialId = 989, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB - 2002-ORANGE" });
                matLista.Add(new Material { MaterialId = 990, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB - 4005-AUBERGINE" });
                matLista.Add(new Material { MaterialId = 991, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB - 3003-RED" });
                matLista.Add(new Material { MaterialId = 992, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB - 5003-TEAL" });
                matLista.Add(new Material { MaterialId = 993, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB - 6006-GREEN" });
                matLista.Add(new Material { MaterialId = 994, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB d. brown - 7001-ANTRACITE" });
                matLista.Add(new Material { MaterialId = 995, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB - 8001-BROWN" });
                matLista.Add(new Material { MaterialId = 996, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB LIGHT GREY - 7002-SILVER" });
                matLista.Add(new Material { MaterialId = 997, MaterialGrupaRefId = 4, Nazwa = "HEYWOOD RIB CHARACOLA - 9000-BLACK" });
                matLista.Add(new Material { MaterialId = 998, MaterialGrupaRefId = 4, Nazwa = "JUKE - 15" });
                matLista.Add(new Material { MaterialId = 999, MaterialGrupaRefId = 4, Nazwa = "JUKE - 123" });
                matLista.Add(new Material { MaterialId = 1000, MaterialGrupaRefId = 4, Nazwa = "KINLY ANTRACITE - 18101" });
                matLista.Add(new Material { MaterialId = 1001, MaterialGrupaRefId = 4, Nazwa = "KINLY BROWN - 18709" });
                matLista.Add(new Material { MaterialId = 1002, MaterialGrupaRefId = 4, Nazwa = "NEVADA D. BROWN - 100" });
                matLista.Add(new Material { MaterialId = 1003, MaterialGrupaRefId = 4, Nazwa = "NEVADA COGNAC - 104" });
                matLista.Add(new Material { MaterialId = 1004, MaterialGrupaRefId = 4, Nazwa = "MICRO SUEDE - 128 DARK BROWN" });
                matLista.Add(new Material { MaterialId = 1005, MaterialGrupaRefId = 4, Nazwa = "MICRO SUEDE BROWN - 126 BROWN" });
                matLista.Add(new Material { MaterialId = 1006, MaterialGrupaRefId = 4, Nazwa = "MICRO SUEDE DARK GREY - 819 DARK GREY" });
                matLista.Add(new Material { MaterialId = 1007, MaterialGrupaRefId = 4, Nazwa = "MICRO SUEDE LIVER - 814" });
                matLista.Add(new Material { MaterialId = 1008, MaterialGrupaRefId = 4, Nazwa = "NATTE GREY CHINE - 10022" });
                matLista.Add(new Material { MaterialId = 1009, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT - 44 STEEL" });
                matLista.Add(new Material { MaterialId = 1010, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT - 45 GREY" });
                matLista.Add(new Material { MaterialId = 1011, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT - 92 LAVENDER" });
                matLista.Add(new Material { MaterialId = 1012, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT - 50 BRICK" });
                matLista.Add(new Material { MaterialId = 1013, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT - 250 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 1014, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT DARK GREY - 516 CHARCOAL" });
                matLista.Add(new Material { MaterialId = 1015, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT - 520 OKER" });
                matLista.Add(new Material { MaterialId = 1016, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT - 706 OCEAN" });
                matLista.Add(new Material { MaterialId = 1017, MaterialGrupaRefId = 4, Nazwa = "CULTURE/OXFORT - 751 OLIVE" });
                matLista.Add(new Material { MaterialId = 1018, MaterialGrupaRefId = 4, Nazwa = "PINETOP/MEDAILLON SAND - 01 NATURAL" });
                matLista.Add(new Material { MaterialId = 1019, MaterialGrupaRefId = 4, Nazwa = "PINETOP/MEDAILLON - 65 GREY" });
                matLista.Add(new Material { MaterialId = 1020, MaterialGrupaRefId = 4, Nazwa = "PINETOP/MEDAILLON ARMY - 101 IVORY" });
                matLista.Add(new Material { MaterialId = 1021, MaterialGrupaRefId = 4, Nazwa = "FUDGE BROWN - 15" });
                matLista.Add(new Material { MaterialId = 1022, MaterialGrupaRefId = 4, Nazwa = "RICO - 2" });
                matLista.Add(new Material { MaterialId = 1023, MaterialGrupaRefId = 4, Nazwa = "RICO - 3" });
                matLista.Add(new Material { MaterialId = 1024, MaterialGrupaRefId = 4, Nazwa = "RICO - 12" });
                matLista.Add(new Material { MaterialId = 1025, MaterialGrupaRefId = 4, Nazwa = "RICO - 14" });
                matLista.Add(new Material { MaterialId = 1026, MaterialGrupaRefId = 4, Nazwa = "RIMINI - 102 TAUPE" });
                matLista.Add(new Material { MaterialId = 1027, MaterialGrupaRefId = 4, Nazwa = "RIMINI - 103 LIVER" });
                matLista.Add(new Material { MaterialId = 1028, MaterialGrupaRefId = 4, Nazwa = "RIMINI - 802 DARK GREY" });
                matLista.Add(new Material { MaterialId = 1029, MaterialGrupaRefId = 4, Nazwa = "RIMINI - 903 SAND" });
                matLista.Add(new Material { MaterialId = 1030, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0028 OFF WHITE" });
                matLista.Add(new Material { MaterialId = 1031, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0174 MUSHROOM" });
                matLista.Add(new Material { MaterialId = 1032, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0089 SAND" });
                matLista.Add(new Material { MaterialId = 1033, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0483 BLACKBERRY" });
                matLista.Add(new Material { MaterialId = 1034, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0485 TAUPE" });
                matLista.Add(new Material { MaterialId = 1035, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0555 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 1036, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0574 BROWN" });
                matLista.Add(new Material { MaterialId = 1037, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0900 SILVERGREY" });
                matLista.Add(new Material { MaterialId = 1038, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 0927 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 1039, MaterialGrupaRefId = 4, Nazwa = "RIVIERA - 1000 BLACK" });
                matLista.Add(new Material { MaterialId = 1040, MaterialGrupaRefId = 4, Nazwa = "SCOTCH FLANELE - F024" });
                matLista.Add(new Material { MaterialId = 1041, MaterialGrupaRefId = 4, Nazwa = "SOLID/BROOKLIN DARK GREY - 46" });
                matLista.Add(new Material { MaterialId = 1042, MaterialGrupaRefId = 4, Nazwa = "SOLID/BROOKLIN GREY - 121" });
                matLista.Add(new Material { MaterialId = 1043, MaterialGrupaRefId = 4, Nazwa = "SOLID/BROOKLIN SILVERGREY - 710" });
                matLista.Add(new Material { MaterialId = 1044, MaterialGrupaRefId = 4, Nazwa = "SOLO - 575 TAUPE" });
                matLista.Add(new Material { MaterialId = 1045, MaterialGrupaRefId = 4, Nazwa = "SOLO - 607 KIWI" });
                matLista.Add(new Material { MaterialId = 1046, MaterialGrupaRefId = 4, Nazwa = "SOLO - 855 AUBERGINE" });
                matLista.Add(new Material { MaterialId = 1047, MaterialGrupaRefId = 4, Nazwa = "SOLO - 947 MOUSE" });
                matLista.Add(new Material { MaterialId = 1048, MaterialGrupaRefId = 4, Nazwa = "SOLO - 964 ROW LINEN" });
                matLista.Add(new Material { MaterialId = 1049, MaterialGrupaRefId = 4, Nazwa = "SOLO - 978 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 1050, MaterialGrupaRefId = 4, Nazwa = "SOLO - 982 BLACK" });
                matLista.Add(new Material { MaterialId = 1051, MaterialGrupaRefId = 4, Nazwa = "SOLO - 0421 REAL RED " });
                matLista.Add(new Material { MaterialId = 1052, MaterialGrupaRefId = 4, Nazwa = "STANFIELD/RANCH SAND - 05 BEIGE" });
                matLista.Add(new Material { MaterialId = 1053, MaterialGrupaRefId = 4, Nazwa = "STANFIELD/RANCH BROWN - 17 CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 1054, MaterialGrupaRefId = 4, Nazwa = "STANFIELD/RANCH GREY - 66 GRAPHITE" });
                matLista.Add(new Material { MaterialId = 1055, MaterialGrupaRefId = 4, Nazwa = "STANFIELD/RANCH STONE - 109 DESERT" });
                matLista.Add(new Material { MaterialId = 1056, MaterialGrupaRefId = 4, Nazwa = "STANFIELD/RANCH ARMY - 156 HUNTER" });
                matLista.Add(new Material { MaterialId = 1057, MaterialGrupaRefId = 4, Nazwa = "STANFIELD/RANCH LIGHT GREY - 180 DOLPHIN" });
                matLista.Add(new Material { MaterialId = 1058, MaterialGrupaRefId = 4, Nazwa = "STILO - 0005 SAND" });
                matLista.Add(new Material { MaterialId = 1059, MaterialGrupaRefId = 4, Nazwa = "STILO - 1003 MAIZE" });
                matLista.Add(new Material { MaterialId = 1060, MaterialGrupaRefId = 4, Nazwa = "STILO - 3011 BRICK" });
                matLista.Add(new Material { MaterialId = 1061, MaterialGrupaRefId = 4, Nazwa = "STILO - 4003 PURPLE" });
                matLista.Add(new Material { MaterialId = 1062, MaterialGrupaRefId = 4, Nazwa = "STILO - 5002 DENIM" });
                matLista.Add(new Material { MaterialId = 1063, MaterialGrupaRefId = 4, Nazwa = "STILO - 7006 IRON" });
                matLista.Add(new Material { MaterialId = 1064, MaterialGrupaRefId = 4, Nazwa = "STILO - 8005 SEAL BROWN" });
                matLista.Add(new Material { MaterialId = 1065, MaterialGrupaRefId = 4, Nazwa = "STILO - 8006 TAUPE" });
                matLista.Add(new Material { MaterialId = 1066, MaterialGrupaRefId = 4, Nazwa = "STILO - 9001 GRAPHITE" });
                matLista.Add(new Material { MaterialId = 1067, MaterialGrupaRefId = 4, Nazwa = "STRONGBOW BLACK - A03" });
                matLista.Add(new Material { MaterialId = 1068, MaterialGrupaRefId = 4, Nazwa = "STRONGBOW BROWN - A08" });
                matLista.Add(new Material { MaterialId = 1069, MaterialGrupaRefId = 4, Nazwa = "JAROME/TARENTE - SLATE-06002" });
                matLista.Add(new Material { MaterialId = 1070, MaterialGrupaRefId = 4, Nazwa = "JAROME/TARENTE - GREY-06015" });
                matLista.Add(new Material { MaterialId = 1071, MaterialGrupaRefId = 4, Nazwa = "JAROME/TARENTE - RAW UMBER-08003" });
                matLista.Add(new Material { MaterialId = 1072, MaterialGrupaRefId = 4, Nazwa = "JAROME/TARENTE - STONE-08007" });
                matLista.Add(new Material { MaterialId = 1073, MaterialGrupaRefId = 4, Nazwa = "JAROME/TARENTE - MAGNESIUM 09011" });
                matLista.Add(new Material { MaterialId = 1074, MaterialGrupaRefId = 4, Nazwa = "TRAPANI/CUBE - 104 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 1075, MaterialGrupaRefId = 4, Nazwa = "TRAPANI/CUBE - 602 DARK LAVENDER" });
                matLista.Add(new Material { MaterialId = 1076, MaterialGrupaRefId = 4, Nazwa = "TRAPANI/CUBE - 801 DARKGREY" });
                matLista.Add(new Material { MaterialId = 1077, MaterialGrupaRefId = 4, Nazwa = "TRAPANI/CUBE - 802 GREY" });
                matLista.Add(new Material { MaterialId = 1078, MaterialGrupaRefId = 4, Nazwa = "TRAPANI/CUBE - 804 SILVER GREY" });
                matLista.Add(new Material { MaterialId = 1079, MaterialGrupaRefId = 4, Nazwa = "TRAPANI/CUBE - 902 SAND" });
                matLista.Add(new Material { MaterialId = 1080, MaterialGrupaRefId = 4, Nazwa = "VALRHONA - 100 BLACK" });
                matLista.Add(new Material { MaterialId = 1081, MaterialGrupaRefId = 4, Nazwa = "VALRHONA - 101 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 1082, MaterialGrupaRefId = 4, Nazwa = "VALRHONA - 104 GREY" });
                matLista.Add(new Material { MaterialId = 1083, MaterialGrupaRefId = 4, Nazwa = "VALRHONA - 203 SAND" });
                matLista.Add(new Material { MaterialId = 1084, MaterialGrupaRefId = 4, Nazwa = "VALRHONA - 800 BROWN" });
                matLista.Add(new Material { MaterialId = 1085, MaterialGrupaRefId = 4, Nazwa = "VALRHONA - 801 MOCCA" });
                matLista.Add(new Material { MaterialId = 1086, MaterialGrupaRefId = 4, Nazwa = "VALRHONA - 808 TAUPE" });
                matLista.Add(new Material { MaterialId = 1087, MaterialGrupaRefId = 4, Nazwa = "VALRHONA - 605" });
                matLista.Add(new Material { MaterialId = 1088, MaterialGrupaRefId = 4, Nazwa = "VELVET/ZERO BOND - 01 NATURE" });
                matLista.Add(new Material { MaterialId = 1089, MaterialGrupaRefId = 4, Nazwa = "VELVET/ZERO BOND -VELVET - 17 BLACK" });
                matLista.Add(new Material { MaterialId = 1090, MaterialGrupaRefId = 4, Nazwa = "VELVET/ZERO BOND - 45 GREY" });
                matLista.Add(new Material { MaterialId = 1091, MaterialGrupaRefId = 4, Nazwa = "VELVET/ZERO BOND - 90 CLOVE" });
                matLista.Add(new Material { MaterialId = 1092, MaterialGrupaRefId = 4, Nazwa = "VELVET/ZERO BOND - 95 LAVENDEL" });
                matLista.Add(new Material { MaterialId = 1093, MaterialGrupaRefId = 4, Nazwa = "VELVET/ZERO BOND - 210 ESPRESSO" });
                matLista.Add(new Material { MaterialId = 1094, MaterialGrupaRefId = 4, Nazwa = "VELVET/ZERO BOND - 709 ARGENT" });
                matLista.Add(new Material { MaterialId = 1095, MaterialGrupaRefId = 4, Nazwa = "VINTAGE - 100 BLACK" });
                matLista.Add(new Material { MaterialId = 1096, MaterialGrupaRefId = 4, Nazwa = "VINTAGE - 101 ANTRACITE" });
                matLista.Add(new Material { MaterialId = 1097, MaterialGrupaRefId = 4, Nazwa = "VINTAGE - 104 GREY" });
                matLista.Add(new Material { MaterialId = 1098, MaterialGrupaRefId = 4, Nazwa = "VINTAGE - 118 SILVER" });
                matLista.Add(new Material { MaterialId = 1099, MaterialGrupaRefId = 4, Nazwa = "VINTAGE - 800 BROWN" });
                matLista.Add(new Material { MaterialId = 1100, MaterialGrupaRefId = 4, Nazwa = "VINTAGE - 812 DARK CHOCOLATE" });
                matLista.Add(new Material { MaterialId = 1101, MaterialGrupaRefId = 4, Nazwa = "WOOLWICH/JULY GREY - 46 ANTHRACITE" });
                matLista.Add(new Material { MaterialId = 1102, MaterialGrupaRefId = 4, Nazwa = "WOOLWICH/JULY OLIVE - 430 BAMBUS" });
                matLista.Add(new Material { MaterialId = 1103, MaterialGrupaRefId = 4, Nazwa = "WOOLWICH/JULY - 50 ORANGE" });
                matLista.Add(new Material { MaterialId = 1104, MaterialGrupaRefId = 4, Nazwa = "WOOLWICH/JULY - 1700 TURQUOISE" });
                matLista.Add(new Material { MaterialId = 1105, MaterialGrupaRefId = 4, Nazwa = "YANNIS 140 - 19306 BLACK" });
                matLista.Add(new Material { MaterialId = 1106, MaterialGrupaRefId = 4, Nazwa = "YANNIS 140 - 193127 ECRU" });
                matLista.Add(new Material { MaterialId = 1107, MaterialGrupaRefId = 4, Nazwa = "YANNIS 140 - 19324 BROWN" });
                matLista.Add(new Material { MaterialId = 1108, MaterialGrupaRefId = 4, Nazwa = "YANNIS 140 - 19330 RED" });
                matLista.Add(new Material { MaterialId = 1109, MaterialGrupaRefId = 4, Nazwa = "YANNIS 140 - 19338 BRIGHT PINK" });
                matLista.Add(new Material { MaterialId = 1110, MaterialGrupaRefId = 4, Nazwa = "YANNIS 140 - 19380 SILVER GREY" });
                matLista.Add(new Material { MaterialId = 1111, MaterialGrupaRefId = 4, Nazwa = "ZWIERZAKI/VELVET - COW [krowa]" });
                matLista.Add(new Material { MaterialId = 1112, MaterialGrupaRefId = 4, Nazwa = "ZWIERZAKI/VELVET - LAMPART" });
                matLista.Add(new Material { MaterialId = 1113, MaterialGrupaRefId = 4, Nazwa = "ZWIERZAKI/VELVET - ZEBRA BLACK/WHITE" });
                matLista.Add(new Material { MaterialId = 1114, MaterialGrupaRefId = 4, Nazwa = "ZWIERZAKI/VELVET - 7985 BLACK/WHITE" });



                foreach (var item in matLista)
                {
                    context.Material.AddOrUpdate(item);

                }

                List<JednRozchodMagRodzaj> rozchodMagList = new List<JednRozchodMagRodzaj>();
                rozchodMagList.Add(new JednRozchodMagRodzaj { JednRozchodMagRodzajId = 1, Nazwa = "produkcja bieøaca", CzyUwagi = true });
                rozchodMagList.Add(new JednRozchodMagRodzaj { JednRozchodMagRodzajId = 2, Nazwa = "sprzedaø", CzyUwagi = true });
                rozchodMagList.Add(new JednRozchodMagRodzaj { JednRozchodMagRodzajId = 3, Nazwa = "reklamacja", CzyUwagi = true });
                rozchodMagList.Add(new JednRozchodMagRodzaj { JednRozchodMagRodzajId = 4, Nazwa = "wymiana", CzyUwagi = true });
                rozchodMagList.Add(new JednRozchodMagRodzaj { JednRozchodMagRodzajId = 5, Nazwa = "inne", CzyUwagi = true });

                foreach (var item in rozchodMagList)
                {
                    context.JednRozchodMagRodzaj.AddOrUpdate(item);
                }




                List<Norma> normaLista = new List<Norma>();
                normaLista.Add(new Norma { Id = 1, Nazwa = "Aberdeen" });
                normaLista.Add(new Norma { Id = 2, Nazwa = "Ailean" });
                normaLista.Add(new Norma { Id = 3, Nazwa = "Alaska" });
                normaLista.Add(new Norma { Id = 4, Nazwa = "Amazon" });
                normaLista.Add(new Norma { Id = 5, Nazwa = "Amsterdam" });
                normaLista.Add(new Norma { Id = 6, Nazwa = "Anne" });
                normaLista.Add(new Norma { Id = 7, Nazwa = "Arese" });
                normaLista.Add(new Norma { Id = 8, Nazwa = "Arizona" });
                normaLista.Add(new Norma { Id = 9, Nazwa = "Arles" });
                normaLista.Add(new Norma { Id = 10, Nazwa = "Arvin" });
                normaLista.Add(new Norma { Id = 11, Nazwa = "Aspen" });
                normaLista.Add(new Norma { Id = 12, Nazwa = "Atos" });
                normaLista.Add(new Norma { Id = 13, Nazwa = "Bari" });
                normaLista.Add(new Norma { Id = 14, Nazwa = "Baxter" });
                normaLista.Add(new Norma { Id = 15, Nazwa = "Bella" });
                normaLista.Add(new Norma { Id = 16, Nazwa = "Bellano" });
                normaLista.Add(new Norma { Id = 17, Nazwa = "Benidor" });
                normaLista.Add(new Norma { Id = 18, Nazwa = "Bergamo" });
                normaLista.Add(new Norma { Id = 19, Nazwa = "Berlin" });
                normaLista.Add(new Norma { Id = 20, Nazwa = "Bianco- Bellagio" });
                normaLista.Add(new Norma { Id = 21, Nazwa = "Birmingham" });
                normaLista.Add(new Norma { Id = 22, Nazwa = "Bjorn" });
                normaLista.Add(new Norma { Id = 23, Nazwa = "Boby" });
                normaLista.Add(new Norma { Id = 24, Nazwa = "Bonaire - Bermuda" });
                normaLista.Add(new Norma { Id = 25, Nazwa = "Bora" });
                normaLista.Add(new Norma { Id = 26, Nazwa = "Bordeaux" });
                normaLista.Add(new Norma { Id = 27, Nazwa = "Bradford" });
                normaLista.Add(new Norma { Id = 28, Nazwa = "Bradley" });
                normaLista.Add(new Norma { Id = 29, Nazwa = "Brian" });
                normaLista.Add(new Norma { Id = 30, Nazwa = "Brighton" });
                normaLista.Add(new Norma { Id = 31, Nazwa = "Brugge" });
                normaLista.Add(new Norma { Id = 32, Nazwa = "Burton" });
                normaLista.Add(new Norma { Id = 33, Nazwa = "Buster" });
                normaLista.Add(new Norma { Id = 34, Nazwa = "Byron" });
                normaLista.Add(new Norma { Id = 35, Nazwa = "Calgary" });
                normaLista.Add(new Norma { Id = 36, Nazwa = "California" });
                normaLista.Add(new Norma { Id = 37, Nazwa = "Calmont" });
                normaLista.Add(new Norma { Id = 38, Nazwa = "Calvados" });
                normaLista.Add(new Norma { Id = 39, Nazwa = "Cannes" });
                normaLista.Add(new Norma { Id = 40, Nazwa = "Canton" });
                normaLista.Add(new Norma { Id = 41, Nazwa = "Capri" });
                normaLista.Add(new Norma { Id = 42, Nazwa = "Caravella" });
                normaLista.Add(new Norma { Id = 43, Nazwa = "Cardiff" });
                normaLista.Add(new Norma { Id = 44, Nazwa = "Cesar" });
                normaLista.Add(new Norma { Id = 45, Nazwa = "Chanet" });
                normaLista.Add(new Norma { Id = 46, Nazwa = "Charisma" });
                normaLista.Add(new Norma { Id = 47, Nazwa = "Chic" });
                normaLista.Add(new Norma { Id = 48, Nazwa = "Chief-Grandpere" });
                normaLista.Add(new Norma { Id = 49, Nazwa = "Cleveland" });
                normaLista.Add(new Norma { Id = 50, Nazwa = "Club" });
                normaLista.Add(new Norma { Id = 51, Nazwa = "Cornwal" });
                normaLista.Add(new Norma { Id = 52, Nazwa = "Corvette" });
                normaLista.Add(new Norma { Id = 53, Nazwa = "Costes" });
                normaLista.Add(new Norma { Id = 54, Nazwa = "Cotton Club" });
                normaLista.Add(new Norma { Id = 55, Nazwa = "Crowley" });
                normaLista.Add(new Norma { Id = 56, Nazwa = "Dacota" });
                normaLista.Add(new Norma { Id = 57, Nazwa = "Dante" });
                normaLista.Add(new Norma { Id = 58, Nazwa = "Davina" });
                normaLista.Add(new Norma { Id = 59, Nazwa = "Dawson" });
                normaLista.Add(new Norma { Id = 60, Nazwa = "Daytona" });
                normaLista.Add(new Norma { Id = 61, Nazwa = "De Lux" });
                normaLista.Add(new Norma { Id = 62, Nazwa = "Denver" });
                normaLista.Add(new Norma { Id = 63, Nazwa = "Dickens" });
                normaLista.Add(new Norma { Id = 64, Nazwa = "Dinterloo" });
                normaLista.Add(new Norma { Id = 65, Nazwa = "Doncaster" });
                normaLista.Add(new Norma { Id = 66, Nazwa = "Dover" });
                normaLista.Add(new Norma { Id = 67, Nazwa = "Dublin" });
                normaLista.Add(new Norma { Id = 68, Nazwa = "Eden" });
                normaLista.Add(new Norma { Id = 69, Nazwa = "Elisabeth" });
                normaLista.Add(new Norma { Id = 70, Nazwa = "Elton" });
                normaLista.Add(new Norma { Id = 71, Nazwa = "Enduro - Enrico" });
                normaLista.Add(new Norma { Id = 72, Nazwa = "Erna" });
                normaLista.Add(new Norma { Id = 73, Nazwa = "Ernst" });
                normaLista.Add(new Norma { Id = 74, Nazwa = "Essex" });
                normaLista.Add(new Norma { Id = 75, Nazwa = "Evi" });
                normaLista.Add(new Norma { Id = 76, Nazwa = "Fabio" });
                normaLista.Add(new Norma { Id = 77, Nazwa = "Figaro" });
                normaLista.Add(new Norma { Id = 78, Nazwa = "Finly" });
                normaLista.Add(new Norma { Id = 79, Nazwa = "Firenca" });
                normaLista.Add(new Norma { Id = 80, Nazwa = "Florenc" });
                normaLista.Add(new Norma { Id = 81, Nazwa = "Florian" });
                normaLista.Add(new Norma { Id = 82, Nazwa = "Forest" });
                normaLista.Add(new Norma { Id = 83, Nazwa = "Forks" });
                normaLista.Add(new Norma { Id = 84, Nazwa = "Fresno" });
                normaLista.Add(new Norma { Id = 85, Nazwa = "Garlton" });
                normaLista.Add(new Norma { Id = 86, Nazwa = "Genewa" });
                normaLista.Add(new Norma { Id = 87, Nazwa = "George" });
                normaLista.Add(new Norma { Id = 88, Nazwa = "Giorno" });
                normaLista.Add(new Norma { Id = 89, Nazwa = "Grand Forks" });
                normaLista.Add(new Norma { Id = 90, Nazwa = "Grand Island" });
                normaLista.Add(new Norma { Id = 91, Nazwa = "Hamilton" });
                normaLista.Add(new Norma { Id = 92, Nazwa = "Hartford" });
                normaLista.Add(new Norma { Id = 93, Nazwa = "Helena" });
                normaLista.Add(new Norma { Id = 94, Nazwa = "Helsinki" });
                normaLista.Add(new Norma { Id = 95, Nazwa = "Hetty" });
                normaLista.Add(new Norma { Id = 96, Nazwa = "Hilton" });
                normaLista.Add(new Norma { Id = 97, Nazwa = "HO Hamond" });
                normaLista.Add(new Norma { Id = 98, Nazwa = "HO Ruoms" });
                normaLista.Add(new Norma { Id = 99, Nazwa = "Holland" });
                normaLista.Add(new Norma { Id = 100, Nazwa = "Hugo" });
                normaLista.Add(new Norma { Id = 101, Nazwa = "Huyton" });
                normaLista.Add(new Norma { Id = 102, Nazwa = "Ibiza" });
                normaLista.Add(new Norma { Id = 103, Nazwa = "Idaho" });
                normaLista.Add(new Norma { Id = 104, Nazwa = "Iris" });
                normaLista.Add(new Norma { Id = 105, Nazwa = "Jahoo" });
                normaLista.Add(new Norma { Id = 106, Nazwa = "Jamie" });
                normaLista.Add(new Norma { Id = 107, Nazwa = "Kansas" });
                normaLista.Add(new Norma { Id = 108, Nazwa = "Karin" });
                normaLista.Add(new Norma { Id = 109, Nazwa = "Karolina" });
                normaLista.Add(new Norma { Id = 110, Nazwa = "Kim" });
                normaLista.Add(new Norma { Id = 111, Nazwa = "Kingston" });
                normaLista.Add(new Norma { Id = 112, Nazwa = "Kris" });
                normaLista.Add(new Norma { Id = 113, Nazwa = "Kyoto" });
                normaLista.Add(new Norma { Id = 114, Nazwa = "Lancaster" });
                normaLista.Add(new Norma { Id = 115, Nazwa = "Larkin" });
                normaLista.Add(new Norma { Id = 116, Nazwa = "Las Vegas" });
                normaLista.Add(new Norma { Id = 117, Nazwa = "Lavende" });
                normaLista.Add(new Norma { Id = 118, Nazwa = "Leeds" });
                normaLista.Add(new Norma { Id = 119, Nazwa = "Leo" });
                normaLista.Add(new Norma { Id = 120, Nazwa = "Logo-Picasso" });
                normaLista.Add(new Norma { Id = 121, Nazwa = "Lombardo" });
                normaLista.Add(new Norma { Id = 122, Nazwa = "Leyland" });
                normaLista.Add(new Norma { Id = 123, Nazwa = "Lisa" });
                normaLista.Add(new Norma { Id = 124, Nazwa = "Lobbylin" });
                normaLista.Add(new Norma { Id = 125, Nazwa = "Lorenzo" });
                normaLista.Add(new Norma { Id = 126, Nazwa = "Lyon" });
                normaLista.Add(new Norma { Id = 127, Nazwa = "Maddison DayBed" });
                normaLista.Add(new Norma { Id = 128, Nazwa = "Manchester" });
                normaLista.Add(new Norma { Id = 129, Nazwa = "Manhattan Funkcja" });
                normaLista.Add(new Norma { Id = 130, Nazwa = "Manon" });
                normaLista.Add(new Norma { Id = 131, Nazwa = "Marabella" });
                normaLista.Add(new Norma { Id = 132, Nazwa = "Maranello" });
                normaLista.Add(new Norma { Id = 133, Nazwa = "Marco" });
                normaLista.Add(new Norma { Id = 134, Nazwa = "Merlin" });
                normaLista.Add(new Norma { Id = 135, Nazwa = "Merlot" });
                normaLista.Add(new Norma { Id = 136, Nazwa = "Metro" });
                normaLista.Add(new Norma { Id = 137, Nazwa = "Midland" });
                normaLista.Add(new Norma { Id = 138, Nazwa = "Milaan" });
                normaLista.Add(new Norma { Id = 139, Nazwa = "Missisipi" });
                normaLista.Add(new Norma { Id = 140, Nazwa = "Monaco - Boris" });
                normaLista.Add(new Norma { Id = 141, Nazwa = "Montana" });
                normaLista.Add(new Norma { Id = 142, Nazwa = "Monti" });
                normaLista.Add(new Norma { Id = 143, Nazwa = "Montreal" });
                normaLista.Add(new Norma { Id = 144, Nazwa = "MS Rome" });
                normaLista.Add(new Norma { Id = 145, Nazwa = "Napels" });
                normaLista.Add(new Norma { Id = 146, Nazwa = "Nelson" });
                normaLista.Add(new Norma { Id = 147, Nazwa = "Nevada" });
                normaLista.Add(new Norma { Id = 148, Nazwa = "Nevada naroønik" });
                normaLista.Add(new Norma { Id = 149, Nazwa = "New Jersey" });
                normaLista.Add(new Norma { Id = 150, Nazwa = "New York" });
                normaLista.Add(new Norma { Id = 151, Nazwa = "Nortfolk" });
                normaLista.Add(new Norma { Id = 152, Nazwa = "Olaf (Kris tapicerowany)" });
                normaLista.Add(new Norma { Id = 153, Nazwa = "Orange" });
                normaLista.Add(new Norma { Id = 154, Nazwa = "Orlando" });
                normaLista.Add(new Norma { Id = 155, Nazwa = "Oslo" });
                normaLista.Add(new Norma { Id = 156, Nazwa = "Oxford" });
                normaLista.Add(new Norma { Id = 157, Nazwa = "Palermo" });
                normaLista.Add(new Norma { Id = 158, Nazwa = "Pallmore" });
                normaLista.Add(new Norma { Id = 159, Nazwa = "Panama" });
                normaLista.Add(new Norma { Id = 160, Nazwa = "Paris - Jacob" });
                normaLista.Add(new Norma { Id = 161, Nazwa = "Passat" });
                normaLista.Add(new Norma { Id = 162, Nazwa = "Porto" });
                normaLista.Add(new Norma { Id = 163, Nazwa = "PortoXL" });
                normaLista.Add(new Norma { Id = 164, Nazwa = "Provence" });
                normaLista.Add(new Norma { Id = 165, Nazwa = "Providence" });
                normaLista.Add(new Norma { Id = 166, Nazwa = "Ravenna" });
                normaLista.Add(new Norma { Id = 167, Nazwa = "Reno" });
                normaLista.Add(new Norma { Id = 168, Nazwa = "Rich" });
                normaLista.Add(new Norma { Id = 169, Nazwa = "Richard" });
                normaLista.Add(new Norma { Id = 170, Nazwa = "Richmond" });
                normaLista.Add(new Norma { Id = 171, Nazwa = "Rimini" });
                normaLista.Add(new Norma { Id = 172, Nazwa = "Rio" });
                normaLista.Add(new Norma { Id = 173, Nazwa = "Ritz" });
                normaLista.Add(new Norma { Id = 174, Nazwa = "Riva" });
                normaLista.Add(new Norma { Id = 175, Nazwa = "Rolf" });
                normaLista.Add(new Norma { Id = 176, Nazwa = "Salt Lake" });
                normaLista.Add(new Norma { Id = 177, Nazwa = "San Remo - Casia" });
                normaLista.Add(new Norma { Id = 178, Nazwa = "San Remo - Vintage" });
                normaLista.Add(new Norma { Id = 179, Nazwa = "Sara" });
                normaLista.Add(new Norma { Id = 180, Nazwa = "Scarlet" });
                normaLista.Add(new Norma { Id = 181, Nazwa = "Seattle" });
                normaLista.Add(new Norma { Id = 182, Nazwa = "Shadow" });
                normaLista.Add(new Norma { Id = 183, Nazwa = "Sheffield" });
                normaLista.Add(new Norma { Id = 184, Nazwa = "Silverstone" });
                normaLista.Add(new Norma { Id = 185, Nazwa = "Sixties" });
                normaLista.Add(new Norma { Id = 186, Nazwa = "Soho" });
                normaLista.Add(new Norma { Id = 187, Nazwa = "Sophie" });
                normaLista.Add(new Norma { Id = 188, Nazwa = "Stockholm" });
                normaLista.Add(new Norma { Id = 189, Nazwa = "Sullivan" });
                normaLista.Add(new Norma { Id = 190, Nazwa = "Sylvester" });
                normaLista.Add(new Norma { Id = 191, Nazwa = "Tacuma" });
                normaLista.Add(new Norma { Id = 192, Nazwa = "Tahoma - Casablanca" });
                normaLista.Add(new Norma { Id = 193, Nazwa = "Taurus" });
                normaLista.Add(new Norma { Id = 194, Nazwa = "Tavi" });
                normaLista.Add(new Norma { Id = 195, Nazwa = "Toby" });
                normaLista.Add(new Norma { Id = 196, Nazwa = "Tom" });
                normaLista.Add(new Norma { Id = 197, Nazwa = "Torronto" });
                normaLista.Add(new Norma { Id = 198, Nazwa = "Toscane" });
                normaLista.Add(new Norma { Id = 199, Nazwa = "Touareg" });
                normaLista.Add(new Norma { Id = 200, Nazwa = "Toulouse" });
                normaLista.Add(new Norma { Id = 201, Nazwa = "Trento" });
                normaLista.Add(new Norma { Id = 202, Nazwa = "Vancouver" });
                normaLista.Add(new Norma { Id = 203, Nazwa = "Venetia" });
                normaLista.Add(new Norma { Id = 204, Nazwa = "Venice" });
                normaLista.Add(new Norma { Id = 205, Nazwa = "Vera" });
                normaLista.Add(new Norma { Id = 206, Nazwa = "Verona" });
                normaLista.Add(new Norma { Id = 207, Nazwa = "Vinci" });
                normaLista.Add(new Norma { Id = 208, Nazwa = "Virage" });
                normaLista.Add(new Norma { Id = 209, Nazwa = "Vogue" });
                normaLista.Add(new Norma { Id = 210, Nazwa = "Wall sofa" });
                normaLista.Add(new Norma { Id = 211, Nazwa = "Wallis" });
                normaLista.Add(new Norma { Id = 212, Nazwa = "HO John" });
                normaLista.Add(new Norma { Id = 213, Nazwa = "HO Harry" });
                normaLista.Add(new Norma { Id = 214, Nazwa = "WL 1" });
                normaLista.Add(new Norma { Id = 215, Nazwa = "WL 2" });
                normaLista.Add(new Norma { Id = 216, Nazwa = "WL 3" });


                foreach (var item in normaLista)
                {
                    context.Normy.AddOrUpdate(item);
                }















                context.SaveChanges();

            // KONIEC IF UPDATE DATABASE INIT DATA
            }





            //    List<Obszycie> ObszycieLista = new List<Obszycie>();
            //    ObszycieLista.Add (new Obszycie() { Id = 1, Nazwa = "keder" });
            //    ObszycieLista.Add (new Obszycie() { Id = 2, Nazwa = "guziki" });
            //    ObszycieLista.Add (new Obszycie() { Id = 3, Nazwa = "korpus" });
            //    ObszycieLista.Add (new Obszycie() { Id = 4, Nazwa = "oparcie" });

            //    foreach (var item in ObszycieLista)
            //    {
            //        context.Obszycie.AddOrUpdate(item);
            //    }
            //    context.SaveChanges();


            //    List<EtapyProdukcyjne> epList = new List<EtapyProdukcyjne>();
            //    epList.Add(new EtapyProdukcyjne { Nazwa = "Stolarnia", Id=1});
            //    epList.Add(new EtapyProdukcyjne { Nazwa = "Zbijanie szkieletÛw", Id=2});
            //    epList.Add(new EtapyProdukcyjne { Nazwa = "Nabia≥",Id=3 });
            //    epList.Add(new EtapyProdukcyjne { Nazwa = "Krojownia", Id=4 });
            //    epList.Add(new EtapyProdukcyjne { Nazwa = "Szwalnia", Id=5 });
            //    epList.Add(new EtapyProdukcyjne { Nazwa = "Tapicernia", Id=6 });
            //    epList.Add(new EtapyProdukcyjne { Nazwa = "Kontrola jakoúci", Id=7});

            //    foreach (var ep in epList)
            //    {
            //        context.EtapyProdukcyjne.AddOrUpdate(ep);
            //    }

            //    context.SaveChanges();

            //    Kontrahent k1 = new Kontrahent
            //    {
            //        Email = "urban@urban.nl",
            //        KontoBankowe = "NL123142314215854000012365",
            //        Nazwa = "Urban Sofa",
            //        NIP = "1551566879",
            //        Skrot = "Urban",
            //        Tel = "34126123342",
            //        WWW = "http://www.urban.nl",

            //    };
            //    Platnosc p1 = new Platnosc
            //    {
            //        IleDni = 30,
            //        Kontrahent = k1,
            //        StawkaTransport = 200,
            //        TransportWCenie = false,
            //        TypPlatnosciRefId = 4,
            //    };

            //    Adres k1a1 = new Adres
            //    {
            //        Kod = "48025",
            //        KodKraju="B",
            //        Kontrahent=k1,
            //        Miejscowosc="Bovenkarspel",
            //        Nazwa="BASIC DESIGN",
            //        Nr="12",
            //        Ulica="Neeevae"
            //    };

            //    Adres k1a2 = new Adres
            //    {
            //        Kod = "45225",
            //        KodKraju = "B",
            //        Kontrahent = k1,
            //        Miejscowosc = "Beverwijk",
            //        Nazwa = "BASIQ MEUBEL",
            //        Nr = "1",
            //        Ulica = "Oewss"
            //    };

            //    Adres k1a3 = new Adres
            //    {
            //        Kod = "42525",
            //        KodKraju = "B",
            //        Kontrahent = k1,
            //        Miejscowosc = "Valkenswaard",
            //        Nazwa = "BETIM",
            //        Nr = "43",
            //        Ulica = "Trews"
            //    };

            //    Adres k1a4 = new Adres
            //    {
            //        Kod = "41525",
            //        KodKraju = "B",
            //        Kontrahent = k1,
            //        Miejscowosc = "Heiligerlee",
            //        Nazwa = "BOEDELFABRIEK",
            //        Nr = "3",
            //        Ulica = "Weees"
            //    };


            //    Kontrahent k2 = new Kontrahent{
            //    Email="bocx@bocx.nl",
            //    KontoBankowe="NL162142314215854000012365",
            //    Nazwa="Bocx",
            //    NIP="999412587",
            //    Skrot="Bocx",
            //    Tel="32687126389",
            //    WWW="http://wwww.bocx.nl"
            //    };

            //    Platnosc p2 = new Platnosc
            //    {
            //        IleDni = 30,
            //        Kontrahent = k2,
            //        TransportWCenie = true,
            //        TypPlatnosciRefId = 4,
            //    };

            //    Adres k2a1 = new Adres
            //    {
            //        Kod = "56321",
            //        KodKraju = "NL",
            //        Kontrahent = k2,
            //        Miejscowosc = "BARNEVELD",
            //        Nazwa = "1246",
            //        Nr = "62",
            //        Ulica = "Twewee"
            //    };

            //    Adres k2a2 = new Adres
            //    {
            //        Kod = "16-89",
            //        KodKraju = "NL",
            //        Kontrahent = k2,
            //        Miejscowosc = "ENSCHEDE",
            //        Nazwa = "1200",
            //        Nr = "2",
            //        Ulica = "Wasdf"
            //    };

            //    Adres k2a3 = new Adres
            //    {
            //        Kod = "576-89",
            //        KodKraju = "NL",
            //        Kontrahent = k2,
            //        Miejscowosc = "GRONINGEN",
            //        Nazwa = "1253",
            //        Nr = "98",
            //        Ulica = "Uewe"
            //    };

            //    Adres k2a4 = new Adres
            //    {
            //        Kod = "87-892",
            //        KodKraju = "NL",
            //        Kontrahent = k2,
            //        Miejscowosc = "KLAZINAVEEN",
            //        Nazwa = "1304",
            //        Nr = "8b",
            //        Ulica = "Gaewe"
            //    };

            //    Adres k2a5 = new Adres
            //    {
            //        Kod = "87-892",
            //        KodKraju = "NL",
            //        Kontrahent = k2,
            //        Miejscowosc = "RENKUM",
            //        Nazwa = "1226",
            //        Nr = "6a",
            //        Ulica = "Ewtwww"
            //    };

            //    Kontrahent k3 = new Kontrahent
            //    {
            //        Email = "rofra@rofra.be",
            //        KontoBankowe = "BE124142314215854000012365",
            //        Nazwa = "Rofra",
            //        NIP = "999412587",
            //        Skrot = "Rofra",
            //        Tel = "32164126389",
            //        WWW = "http://wwww.rofra.be"
            //    };

            //    Platnosc p3 = new Platnosc
            //    {
            //        Kontrahent = k3,
            //        TransportWCenie = true,
            //        TypPlatnosciRefId = 5,
            //        Uwagi="Jakieú inne ustalenia dotyczπce transportu"
            //    };

            //    Adres k3a1 = new Adres
            //    {
            //        Kod = "17-892",
            //        KodKraju = "BE",
            //        Kontrahent = k3,
            //        Miejscowosc = "VAASSEN",
            //        Nr = "52",
            //        Ulica = "ALewee Dwea"
            //    };


            //    List<ZamowienieStatusNazwa> zsLista = new List<ZamowienieStatusNazwa>();
            //    zsLista.Add(new ZamowienieStatusNazwa{Nazwa="Planning", Id=1});
            //    zsLista.Add(new ZamowienieStatusNazwa{Nazwa="Pakowanie", Id=2});
            //    zsLista.Add(new ZamowienieStatusNazwa{Nazwa="Magazyn/Auto", Id=3});
            //    zsLista.Add(new ZamowienieStatusNazwa{Nazwa="Transport", Id=4});
            //    zsLista.Add(new ZamowienieStatusNazwa{Nazwa="Wys≥ane", Id=5});


            //    foreach (var zs in zsLista)
            //    {
            //      context.ZamowienieStatusNazwa.AddOrUpdate(zs);
            //    };

            //    context.Kontrahent.AddOrUpdate(k1);
            //    context.Platnosc.AddOrUpdate(p1);
            //    context.Adres.AddOrUpdate(k1a1);
            //    context.Adres.AddOrUpdate(k1a2);
            //    context.Adres.AddOrUpdate(k1a3);
            //    context.Adres.AddOrUpdate(k1a4);

            //    context.Kontrahent.AddOrUpdate(k2);
            //    context.Platnosc.AddOrUpdate(p2);
            //    context.Adres.AddOrUpdate(k2a1);
            //    context.Adres.AddOrUpdate(k2a2);
            //    context.Adres.AddOrUpdate(k2a3);
            //    context.Adres.AddOrUpdate(k2a4);
            //    context.Adres.AddOrUpdate(k2a5);


            //    context.Kontrahent.AddOrUpdate(k3);
            //    context.Platnosc.AddOrUpdate(p3);
            //    context.Adres.AddOrUpdate(k3a1);


            //    context.SaveChanges();

            //    context.Platnosc.AddOrUpdate(p1);
            //    context.Platnosc.AddOrUpdate(p2);
            //    context.Platnosc.AddOrUpdate(p3);






            //    //context.Normy.AddOrUpdate(new Norma
            //    //{
            //    //    Id = 1,
            //    //    Nazwa = "San Remo Casia",
            //    //    Uwagi = "brak",
            //    //    Kombinacje = { 
            //    //    new Kombinacja {Id=1, Wartosc=1200, Glebokosc = 50, NazwaKombinacjiRefId = 3, Szerokosc = 300, Wysokosc = 100, Waga=25,
            //    //        KombinacjeWykonczenieBoczka={new KombinacjeWykonczenieBoczka() {WykonczenieBoczkaRefId=2}, new KombinacjeWykonczenieBoczka(){WykonczenieBoczkaRefId=1} },
            //    //        KombinacjeWykonczenieDeski={new KombinacjeWykonczenieDeski() {WykonczenieDeskiRefId=1}},
            //    //        KombinacjeWykonczenieNozki={new KombinacjeWykonczenieNozki(){WykonczenieNozkiRefId=3}, new KombinacjeWykonczenieNozki(){WykonczenieNozkiRefId=3}},
            //    //        KombinacjeObszycie={new KombinacjeObszycie(){ObszycieRefId=1, Wartosc=1.2}, new KombinacjeObszycie(){ObszycieRefId=3, Wartosc=0.3}, new KombinacjeObszycie(){ObszycieRefId=4,Wartosc=1.8}},
            //    //        EtapyProdukcyjneWartosc={new KombinacjeEtapyProdukcyjne(){EtapyProdukcyjneRefId=1,KombinacjaRefId=1}, new KombinacjeEtapyProdukcyjne(){EtapyProdukcyjneRefId=2,KombinacjaRefId=1}}
            //    //    },
            //    //    }

            //    //});



            //    context.SaveChanges();


            //    Norma n1 = new Norma();
            //    n1.Id = 1;
            //    n1.Nazwa="San Remo Presto";
            //    n1.Uwagi = "g≥adka i smuk≥a";


            //    Kombinacja kombi1 = new Kombinacja();
            //    kombi1.Id = 1;
            //    kombi1.NazwaKombinacjiRefId = 3;
            //    kombi1.NormaRefId = 1;
            //    kombi1.Szerokosc = 80;
            //    kombi1.Waga = 80;
            //    kombi1.Wartosc = 1200;
            //    kombi1.Wysokosc = 120;
            //    kombi1.Glebokosc = 70;



            //    KombinacjeEtapyProdukcyjne kep1 = new KombinacjeEtapyProdukcyjne() {Id = 1, EtapyProdukcyjneRefId = 1, KombinacjaRefId = kombi1.Id };
            //    KombinacjeEtapyProdukcyjne kep2 = new KombinacjeEtapyProdukcyjne() {Id = 2, EtapyProdukcyjneRefId = 2, KombinacjaRefId = kombi1.Id };
            //    KombinacjeEtapyProdukcyjne kep3 = new KombinacjeEtapyProdukcyjne() {Id = 3, EtapyProdukcyjneRefId = 3, KombinacjaRefId = kombi1.Id };

            //    KombinacjeObszycie ko1 = new KombinacjeObszycie() { Id = 1, KombinacjaRefId = kombi1.Id, ObszycieRefId = 1, Wartosc = 1.2 };
            //    KombinacjeObszycie ko2 = new KombinacjeObszycie() { Id = 2, KombinacjaRefId = kombi1.Id, ObszycieRefId = 2, Wartosc = 0.2 };
            //    KombinacjeObszycie ko3 = new KombinacjeObszycie() { Id = 3, KombinacjaRefId = kombi1.Id, ObszycieRefId = 3, Wartosc = 1.6 };
            //    KombinacjeObszycie ko4 = new KombinacjeObszycie() { Id = 4, KombinacjaRefId = kombi1.Id, ObszycieRefId = 4, Wartosc = 1 };

            //    KombinacjeWykonczenieBoczka kwb1 = new KombinacjeWykonczenieBoczka() { Id = 1, KombinacjaRefId = 1, WykonczenieBoczkaRefId = 1 };
            //    KombinacjeWykonczenieBoczka kwb2 = new KombinacjeWykonczenieBoczka() { Id = 2, KombinacjaRefId = kombi1.Id, WykonczenieBoczkaRefId = 2 };

            //    KombinacjeWykonczenieDeski kwd1 = new KombinacjeWykonczenieDeski() { Id = 1, KombinacjaRefId = kombi1.Id, WykonczenieDeskiRefId = 1 };

            //    KombinacjeWykonczenieNozki kwn1 = new KombinacjeWykonczenieNozki() { Id = 1, KombinacjaRefId = kombi1.Id, WykonczenieNozkiRefId = 1 };
            //    KombinacjeWykonczenieNozki kwn2 = new KombinacjeWykonczenieNozki() { Id = 2, KombinacjaRefId = kombi1.Id, WykonczenieNozkiRefId = 2 };
            //    KombinacjeWykonczenieNozki kwn3 = new KombinacjeWykonczenieNozki() { Id = 3, KombinacjaRefId = kombi1.Id, WykonczenieNozkiRefId = 4 };



            //    Kombinacja kombi2 = new Kombinacja();
            //    kombi2.Id = 2;
            //    kombi2.NazwaKombinacjiRefId = 4;
            //    kombi2.NormaRefId = 1;
            //    kombi2.Szerokosc = 40;
            //    kombi2.Waga = 50;
            //    kombi2.Wartosc = 800;
            //    kombi2.Wysokosc = 100;
            //    kombi2.Glebokosc = 60;


            //    KombinacjeEtapyProdukcyjne kep4 = new KombinacjeEtapyProdukcyjne() { Id = 4, EtapyProdukcyjneRefId = 4, KombinacjaRefId = kombi2.Id };
            //    KombinacjeEtapyProdukcyjne kep5 = new KombinacjeEtapyProdukcyjne() { Id = 5, EtapyProdukcyjneRefId = 5, KombinacjaRefId = kombi2.Id };
            //    KombinacjeEtapyProdukcyjne kep6 = new KombinacjeEtapyProdukcyjne() { Id = 6, EtapyProdukcyjneRefId = 6, KombinacjaRefId = kombi2.Id };

            //    KombinacjeObszycie ko5 = new KombinacjeObszycie() { Id = 5, KombinacjaRefId = kombi2.Id, ObszycieRefId = 1, Wartosc = 1.2 };
            //    KombinacjeObszycie ko6 = new KombinacjeObszycie() { Id = 6, KombinacjaRefId = kombi2.Id, ObszycieRefId = 2, Wartosc = 0.2 };
            //    KombinacjeObszycie ko7 = new KombinacjeObszycie() { Id = 7, KombinacjaRefId = kombi2.Id, ObszycieRefId = 3, Wartosc = 1.6 };
            //    KombinacjeObszycie ko8 = new KombinacjeObszycie() { Id = 8, KombinacjaRefId = kombi2.Id, ObszycieRefId = 4, Wartosc = 1 };

            //    KombinacjeWykonczenieBoczka kwb3 = new KombinacjeWykonczenieBoczka() { Id = 3, KombinacjaRefId = kombi2.Id, WykonczenieBoczkaRefId = 1 };
            //    KombinacjeWykonczenieBoczka kwb4 = new KombinacjeWykonczenieBoczka() { Id = 4, KombinacjaRefId = kombi2.Id, WykonczenieBoczkaRefId = 2 };

            //    KombinacjeWykonczenieDeski kwd2 = new KombinacjeWykonczenieDeski() { Id = 2, KombinacjaRefId = kombi2.Id, WykonczenieDeskiRefId = 1 };

            //    KombinacjeWykonczenieNozki kwn4 = new KombinacjeWykonczenieNozki() { Id = 4, KombinacjaRefId = kombi2.Id, WykonczenieNozkiRefId = 1 };
            //    KombinacjeWykonczenieNozki kwn5 = new KombinacjeWykonczenieNozki() { Id = 5, KombinacjaRefId = kombi2.Id, WykonczenieNozkiRefId = 2 };
            //    KombinacjeWykonczenieNozki kwn6 = new KombinacjeWykonczenieNozki() { Id = 6, KombinacjaRefId = kombi2.Id, WykonczenieNozkiRefId = 4 };





            //    Norma n2 = new Norma();
            //    n2.Id = 2;
            //    n2.Nazwa = "San Remo Vintage";
            //    n2.Uwagi = "git";




            //    context.Normy.AddOrUpdate(n1,n2);

            //    context.Kombinacje.AddOrUpdate(kombi1, kombi2);


            //    context.KombinacjeEtapyProdukcyjne.AddOrUpdate(kep1, kep2, kep3, kep4, kep5, kep6);
            //    context.KombinacjeObszycie.AddOrUpdate(ko1, ko2, ko3, ko4, ko5, ko6, ko7, ko8);
            //    context.KombinacjeWykonczenieBoczka.AddOrUpdate(kwb1, kwb2, kwb3, kwb4);
            //    context.KombinacjeWykonczenieDeski.AddOrUpdate(kwd1, kwd2);
            //    context.KombinacjeWykonczenieNozki.AddOrUpdate(kwn1, kwn2, kwn3, kwn4, kwn5, kwn6);

            //    context.SaveChanges();

            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 1, Ilosc = 1, Uwagi = null, Commission = "LEYMAN", Reference = "U2015-04166", DataZamowienia = new DateTime(2015, 09, 16), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 5, Created = new DateTime(2015, 09, 16, 16, 31, 51) });
            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 2, Ilosc = 1, Uwagi = null, Commission = "LEIJEN", Reference = "U2015-04236", DataZamowienia = new DateTime(2015, 09, 13), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 1, Created = new DateTime(2015, 09, 14, 14, 16, 33) });
            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 3, Ilosc = 1, Uwagi = null, Commission = "KOPPER", Reference = "U2015-04360", DataZamowienia = new DateTime(2015, 09, 9), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 2, Created = new DateTime(2015, 09, 14, 15, 31, 53) });
            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 4, Ilosc = 1, Uwagi = null, Commission = "SHOWROOM", Reference = "U2015-03785", DataZamowienia = new DateTime(2015, 09, 13), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 2, Created = new DateTime(2015, 09, 14, 20, 5, 19) });
            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 5, Ilosc = 1, Uwagi = null, Commission = "BRUINISSE", Reference = "U2015-03788", DataZamowienia = new DateTime(2015, 09, 17), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 1, Created = new DateTime(2015, 09, 14, 20, 48, 8) });
            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 6, Ilosc = 1, Uwagi = null, Commission = "VET", Reference = "U2015-04047", DataZamowienia = new DateTime(2015, 09, 14), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 3, Created = new DateTime(2015, 09, 15, 15, 26, 24) });
            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 7, Ilosc = 1, Uwagi = null, Commission = "BEURDEN", Reference = "U2015-04048", DataZamowienia = new DateTime(2015, 09, 14), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 4, Created = new DateTime(2015, 09, 15, 16, 55, 53) });
            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 8, Ilosc = 1, Uwagi = null, Commission = "VIGHT", Reference = "U2015-03959", DataZamowienia = new DateTime(2015, 09, 14), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 2, Created = new DateTime(2015, 09, 15, 17, 0, 14) });
            //    context.Zamowienie.AddOrUpdate(new Zamowienie() { Id = 9, Ilosc = 1, Uwagi = null, Commission = "BULCKE", Reference = "U2015-04313", DataZamowienia = new DateTime(2015, 09, 15), RequireDeliver = false, DataRealizacji = null, NormaRefId = 1, AdresRefId = 5, Created = new DateTime(2015, 09, 16, 16, 15, 12) });

            //    context.SaveChanges();

        }


    }
}
