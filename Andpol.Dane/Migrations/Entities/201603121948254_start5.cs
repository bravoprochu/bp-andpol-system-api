namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeLog",
                c => new
                    {
                        ChangeLogId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Grupa = c.String(),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.ChangeLogId);
            
            CreateTable(
                "dbo.EtapyProdukcyjne",
                c => new
                    {
                        EtapyProdukcyjneId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.EtapyProdukcyjneId);
            
            CreateTable(
                "dbo.KombinacjaEtapyProdukcyjne",
                c => new
                    {
                        KombinacjaEtapyProdukcyjneId = c.Int(nullable: false, identity: true),
                        KombinacjaRefId = c.Int(nullable: false),
                        EtapyProdukcyjneRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KombinacjaEtapyProdukcyjneId)
                .ForeignKey("dbo.EtapyProdukcyjne", t => t.EtapyProdukcyjneRefId, cascadeDelete: true)
                .ForeignKey("dbo.Kombinacja", t => t.KombinacjaRefId, cascadeDelete: true)
                .Index(t => t.KombinacjaRefId)
                .Index(t => t.EtapyProdukcyjneRefId);
            
            CreateTable(
                "dbo.Kombinacja",
                c => new
                    {
                        KombinacjaId = c.Int(nullable: false, identity: true),
                        Glebokosc = c.Int(),
                        IloscPoduszekOparciowych = c.Int(),
                        IloscPoduszekSiedzeniowych = c.Int(),
                        Kubatura = c.Double(),
                        NazwaKombinacjiRefId = c.Int(nullable: false),
                        NormaRefId = c.Int(nullable: false),
                        Wartosc = c.Double(),
                        Szerokosc = c.Int(),
                        Waga = c.Double(),
                        Wysokosc = c.Int(),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.KombinacjaId)
                .ForeignKey("dbo.Norma", t => t.NormaRefId, cascadeDelete: true)
                .ForeignKey("dbo.NazwaKombinacji", t => t.NazwaKombinacjiRefId, cascadeDelete: true)
                .Index(t => t.NazwaKombinacjiRefId)
                .Index(t => t.NormaRefId);
            
            CreateTable(
                "dbo.KombinacjaPozycjaMagazynowa",
                c => new
                    {
                        KombinacjaPozycjaMagazynowaId = c.Int(nullable: false, identity: true),
                        Wartosc = c.Double(nullable: false),
                        MagPozycjaMagazynowaRefId = c.Int(nullable: false),
                        KombinacjaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KombinacjaPozycjaMagazynowaId)
                .ForeignKey("dbo.Kombinacja", t => t.KombinacjaRefId, cascadeDelete: true)
                .ForeignKey("dbo.MagPozycjaMagazynowa", t => t.MagPozycjaMagazynowaRefId, cascadeDelete: true)
                .Index(t => t.MagPozycjaMagazynowaRefId)
                .Index(t => t.KombinacjaRefId);
            
            CreateTable(
                "dbo.MagPozycjaMagazynowa",
                c => new
                    {
                        MagPozycjaMagazynowaId = c.Int(nullable: false, identity: true),
                        czyPotwierdzone = c.Boolean(nullable: false),
                        GrupaZakladowaRefId = c.Int(nullable: false),
                        JednostkaMiaryRefId = c.Int(nullable: false),
                        KodKreskowy = c.String(maxLength: 48),
                        MarzaZakladowaRefId = c.Int(nullable: false),
                        Nazwa = c.String(nullable: false),
                        StanMinAlarm = c.Double(),
                        StanAktualny = c.Double(),
                        StanRzeczywisty = c.Double(),
                        TypTowaru = c.Int(nullable: false),
                        VatSprzedazyRefId = c.Int(nullable: false),
                        VatZakupuRefId = c.Int(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.MagPozycjaMagazynowaId)
                .ForeignKey("dbo.JednPodatekStawka", t => t.VatSprzedazyRefId)
                .ForeignKey("dbo.JednPodatekStawka", t => t.VatZakupuRefId)
                .ForeignKey("dbo.JednGrupaZakladowa", t => t.GrupaZakladowaRefId, cascadeDelete: true)
                .ForeignKey("dbo.JednJednostkaMiary", t => t.JednostkaMiaryRefId, cascadeDelete: true)
                .ForeignKey("dbo.JednMarzaZakladowa", t => t.MarzaZakladowaRefId, cascadeDelete: true)
                .Index(t => t.GrupaZakladowaRefId)
                .Index(t => t.JednostkaMiaryRefId)
                .Index(t => t.MarzaZakladowaRefId)
                .Index(t => t.VatSprzedazyRefId)
                .Index(t => t.VatZakupuRefId);
            
            CreateTable(
                "dbo.FinFakturaPozycje",
                c => new
                    {
                        FinFakturaPozycjeId = c.Int(nullable: false, identity: true),
                        Cena = c.Double(nullable: false),
                        Ilosc = c.Double(nullable: false),
                        PozycjaMagazynowaRefId = c.Int(nullable: false),
                        FakturaZakupuRefId = c.Int(nullable: false),
                        Wartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FinFakturaPozycjeId)
                .ForeignKey("dbo.FinFakturaZakupu", t => t.FakturaZakupuRefId, cascadeDelete: true)
                .ForeignKey("dbo.MagPozycjaMagazynowa", t => t.PozycjaMagazynowaRefId, cascadeDelete: true)
                .Index(t => t.PozycjaMagazynowaRefId)
                .Index(t => t.FakturaZakupuRefId);
            
            CreateTable(
                "dbo.FinFakturaZakupu",
                c => new
                    {
                        FinFakturaZakupuId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CzyEuro = c.Boolean(nullable: false),
                        CzyPrzypomnieniePlatnosc = c.Boolean(nullable: false),
                        DataSprzedazy = c.DateTime(nullable: false),
                        DataWplywu = c.DateTime(nullable: false),
                        DataWystawienia = c.DateTime(nullable: false),
                        FakturaNr = c.String(),
                        KontrahentRefId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.String(),
                        PlatnoscRodzajRefId = c.Int(nullable: false),
                        PlatnoscRodzajIleDni = c.Int(),
                        PlatnoscRodzajUwagi = c.String(),
                        RazemBrutto = c.Double(nullable: false),
                        RazemNetto = c.Double(nullable: false),
                        RazemVat = c.Double(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.FinFakturaZakupuId)
                .ForeignKey("dbo.Kontrahent", t => t.KontrahentRefId, cascadeDelete: true)
                .ForeignKey("dbo.JednPlatnoscRodzaj", t => t.PlatnoscRodzajRefId, cascadeDelete: true)
                .Index(t => t.KontrahentRefId)
                .Index(t => t.PlatnoscRodzajRefId);
            
            CreateTable(
                "dbo.FinFakturaPodsumowanieWartosci",
                c => new
                    {
                        FinFakturaPodsumowanieWartosciId = c.Int(nullable: false, identity: true),
                        FakturaZakupuRefId = c.Int(nullable: false),
                        PodatekStawkaRefId = c.Int(nullable: false),
                        WartoscBrutto = c.Double(),
                        WartoscNetto = c.Double(),
                        WartoscVat = c.Double(),
                    })
                .PrimaryKey(t => t.FinFakturaPodsumowanieWartosciId)
                .ForeignKey("dbo.FinFakturaZakupu", t => t.FakturaZakupuRefId, cascadeDelete: true)
                .ForeignKey("dbo.JednPodatekStawka", t => t.PodatekStawkaRefId, cascadeDelete: true)
                .Index(t => t.FakturaZakupuRefId)
                .Index(t => t.PodatekStawkaRefId);
            
            CreateTable(
                "dbo.JednPodatekStawka",
                c => new
                    {
                        JednPodatekStawkaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 50),
                        Wartosc = c.Double(nullable: false),
                        Uwagi = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.JednPodatekStawkaId);
            
            CreateTable(
                "dbo.Kontrahent",
                c => new
                    {
                        KontrahentId = c.Int(nullable: false, identity: true),
                        CzyDealerzy = c.Boolean(nullable: false),
                        CzyDostawca = c.Boolean(nullable: false),
                        CzyOdbiorca = c.Boolean(nullable: false),
                        Email = c.String(),
                        Fax = c.String(maxLength: 15),
                        Imie = c.String(maxLength: 30),
                        KodKraju = c.String(maxLength: 2),
                        KodPocztowy = c.String(maxLength: 8),
                        KontoBankowe = c.String(maxLength: 28),
                        KontoBankowe2 = c.String(maxLength: 28),
                        KontrahentPlatnoscRefId = c.Int(),
                        Miejscowosc = c.String(maxLength: 50),
                        Nazwa = c.String(maxLength: 100),
                        Nazwisko = c.String(maxLength: 50),
                        NIP = c.String(maxLength: 12),
                        Pesel = c.String(maxLength: 11),
                        Skrot = c.String(maxLength: 30),
                        Tel = c.String(maxLength: 15),
                        Tel2 = c.String(maxLength: 15),
                        TypKontrahentaRefId = c.Int(nullable: false),
                        Ulica = c.String(maxLength: 50),
                        UlicaNr = c.String(maxLength: 30),
                        WWW = c.String(),
                    })
                .PrimaryKey(t => t.KontrahentId)
                .ForeignKey("dbo.KontrahentPlatnosc", t => t.KontrahentPlatnoscRefId)
                .Index(t => t.KontrahentPlatnoscRefId);
            
            CreateTable(
                "dbo.KontrahentDealer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CzyAdresDostawy = c.Boolean(nullable: false),
                        CzyWjedziePrzyczepa = c.Boolean(nullable: false),
                        Kod = c.String(),
                        KodKraju = c.String(maxLength: 2),
                        KontrahentRefId = c.Int(nullable: false),
                        Miejscowosc = c.String(),
                        Nazwa = c.String(),
                        Nr = c.String(),
                        Ulica = c.String(),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kontrahent", t => t.KontrahentRefId, cascadeDelete: true)
                .Index(t => t.KontrahentRefId);
            
            CreateTable(
                "dbo.Zamowienie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Commission = c.String(),
                        CreatedBy = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CzyZaplanowane = c.Boolean(nullable: false),
                        DataZamowienia = c.DateTime(nullable: false),
                        DataRealizacji = c.DateTime(),
                        Ilosc = c.Int(nullable: false),
                        KontrahentDealerRefId = c.Int(nullable: false),
                        KontrahentDealerDostawaRefId = c.Int(nullable: false),
                        NormaRefId = c.Int(nullable: false),
                        PlanningRefId = c.Int(),
                        Reference = c.String(),
                        RequireDeliver = c.Boolean(nullable: false),
                        Uwagi = c.String(),
                        ZamowienieNr = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Norma", t => t.NormaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Planning", t => t.PlanningRefId)
                .ForeignKey("dbo.KontrahentDealer", t => t.KontrahentDealerRefId)
                .ForeignKey("dbo.KontrahentDealer", t => t.KontrahentDealerDostawaRefId)
                .Index(t => t.KontrahentDealerRefId)
                .Index(t => t.KontrahentDealerDostawaRefId)
                .Index(t => t.NormaRefId)
                .Index(t => t.PlanningRefId);
            
            CreateTable(
                "dbo.Norma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Planning",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRealizacji = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialBelkaRozchodObszycie",
                c => new
                    {
                        MaterialBelkaRozchodObszycieId = c.Int(nullable: false, identity: true),
                        ZamowienieObszycieRefId = c.Int(nullable: false),
                        MaterialBelkaRefId = c.Int(nullable: false),
                        PlanningRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialBelkaRozchodObszycieId)
                .ForeignKey("dbo.MaterialBelka", t => t.MaterialBelkaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Planning", t => t.PlanningRefId, cascadeDelete: true)
                .ForeignKey("dbo.ZamowienieKombiObszycie", t => t.ZamowienieObszycieRefId, cascadeDelete: true)
                .Index(t => t.ZamowienieObszycieRefId)
                .Index(t => t.MaterialBelkaRefId)
                .Index(t => t.PlanningRefId);
            
            CreateTable(
                "dbo.MaterialBelka",
                c => new
                    {
                        MaterialBelkaId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        DataPrzyjecia = c.DateTime(nullable: false),
                        Dostepny = c.Boolean(nullable: false),
                        FakturaNr = c.String(),
                        MaterialRefId = c.Int(nullable: false),
                        OznaczenieWewnetrzne = c.String(),
                        StanAktualny = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StanPoczatkowy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.MaterialBelkaId)
                .ForeignKey("dbo.Material", t => t.MaterialRefId)
                .Index(t => t.MaterialRefId);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        CzyUtrudnienie = c.Boolean(nullable: false),
                        MaterialGrupaRefId = c.Int(nullable: false),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.MaterialGrupaKontrahent", t => t.MaterialGrupaRefId, cascadeDelete: true)
                .Index(t => t.MaterialGrupaRefId);
            
            CreateTable(
                "dbo.KombinacjaObszycie",
                c => new
                    {
                        KombinacjaObszycieId = c.Int(nullable: false, identity: true),
                        Wartosc = c.Double(nullable: false),
                        ObszycieRefId = c.Int(nullable: false),
                        KombinacjaRefId = c.Int(nullable: false),
                        Material_MaterialId = c.Int(),
                    })
                .PrimaryKey(t => t.KombinacjaObszycieId)
                .ForeignKey("dbo.Kombinacja", t => t.KombinacjaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Obszycie", t => t.ObszycieRefId, cascadeDelete: true)
                .ForeignKey("dbo.Material", t => t.Material_MaterialId)
                .Index(t => t.ObszycieRefId)
                .Index(t => t.KombinacjaRefId)
                .Index(t => t.Material_MaterialId);
            
            CreateTable(
                "dbo.Obszycie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ZamowienieKombiObszycie",
                c => new
                    {
                        ZamowienieKombiObszycieId = c.Int(nullable: false, identity: true),
                        CzyWykonane = c.Boolean(nullable: false),
                        KombinacjeObszycieRefId = c.Int(nullable: false),
                        MaterialRefId = c.Int(nullable: false),
                        Uwagi = c.String(),
                        ZamowienieKombiRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZamowienieKombiObszycieId)
                .ForeignKey("dbo.KombinacjaObszycie", t => t.KombinacjeObszycieRefId)
                .ForeignKey("dbo.Material", t => t.MaterialRefId, cascadeDelete: true)
                .ForeignKey("dbo.ZamowienieKombi", t => t.ZamowienieKombiRefId)
                .Index(t => t.KombinacjeObszycieRefId)
                .Index(t => t.MaterialRefId)
                .Index(t => t.ZamowienieKombiRefId);
            
            CreateTable(
                "dbo.ZamowienieKombi",
                c => new
                    {
                        ZamowienieKombiId = c.Int(nullable: false, identity: true),
                        KombinacjaRefId = c.Int(nullable: false),
                        WypychRefId = c.Int(),
                        ZamowienieRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZamowienieKombiId)
                .ForeignKey("dbo.Kombinacja", t => t.KombinacjaRefId)
                .ForeignKey("dbo.Wypych", t => t.WypychRefId)
                .ForeignKey("dbo.Zamowienie", t => t.ZamowienieRefId, cascadeDelete: true)
                .Index(t => t.KombinacjaRefId)
                .Index(t => t.WypychRefId)
                .Index(t => t.ZamowienieRefId);
            
            CreateTable(
                "dbo.Wypych",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialGrupaKontrahent",
                c => new
                    {
                        MaterialGrupaKontrahentId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                        Kontrahent_KontrahentId = c.Int(),
                    })
                .PrimaryKey(t => t.MaterialGrupaKontrahentId)
                .ForeignKey("dbo.Kontrahent", t => t.Kontrahent_KontrahentId)
                .Index(t => t.Kontrahent_KontrahentId);
            
            CreateTable(
                "dbo.MaterialBelkaRozchodInne",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        DataRozchodu = c.DateTime(nullable: false),
                        MaterialBelkaRefId = c.Int(nullable: false),
                        RozchodMagRodzajRefId = c.Int(nullable: false),
                        Uwagi = c.String(),
                        Wartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialBelka", t => t.MaterialBelkaRefId, cascadeDelete: true)
                .ForeignKey("dbo.JednRozchodMagRodzaj", t => t.RozchodMagRodzajRefId, cascadeDelete: true)
                .Index(t => t.MaterialBelkaRefId)
                .Index(t => t.RozchodMagRodzajRefId);
            
            CreateTable(
                "dbo.JednRozchodMagRodzaj",
                c => new
                    {
                        JednRozchodMagRodzajId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        CzyUwagi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JednRozchodMagRodzajId);
            
            CreateTable(
                "dbo.MagPozycjaMagazynowaRozchodInne",
                c => new
                    {
                        MagPozycjaMagazynowaRozchodInneId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        DataRozchodu = c.DateTime(nullable: false),
                        RozchodMagRodzajRefId = c.Int(nullable: false),
                        PozycjaMagazynowaRefId = c.Int(nullable: false),
                        Uwagi = c.String(),
                        Wartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MagPozycjaMagazynowaRozchodInneId)
                .ForeignKey("dbo.MagPozycjaMagazynowa", t => t.PozycjaMagazynowaRefId, cascadeDelete: true)
                .ForeignKey("dbo.JednRozchodMagRodzaj", t => t.RozchodMagRodzajRefId, cascadeDelete: true)
                .Index(t => t.RozchodMagRodzajRefId)
                .Index(t => t.PozycjaMagazynowaRefId);
            
            CreateTable(
                "dbo.ZamowienieStatusWartosc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gotowe = c.Boolean(nullable: false),
                        Uwagi = c.String(),
                        DataUtworzenia = c.DateTime(nullable: false),
                        ZamowienieStatusNazwaRefId = c.Int(nullable: false),
                        ZamowienieRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zamowienie", t => t.ZamowienieRefId, cascadeDelete: true)
                .ForeignKey("dbo.ZamowienieStatusNazwa", t => t.ZamowienieStatusNazwaRefId, cascadeDelete: true)
                .Index(t => t.ZamowienieStatusNazwaRefId)
                .Index(t => t.ZamowienieRefId);
            
            CreateTable(
                "dbo.ZamowienieStatusNazwa",
                c => new
                    {
                        ZamowienieStatusNazwaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.ZamowienieStatusNazwaId);
            
            CreateTable(
                "dbo.KontrahentPlatnosc",
                c => new
                    {
                        KontrahentPlatnoscId = c.Int(nullable: false, identity: true),
                        IleDni = c.Int(),
                        Uwagi = c.String(),
                        TransportWcenie = c.Boolean(nullable: false),
                        TransportStawka = c.Double(),
                        PlatnoscRodzajRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KontrahentPlatnoscId)
                .ForeignKey("dbo.JednPlatnoscRodzaj", t => t.PlatnoscRodzajRefId, cascadeDelete: true)
                .Index(t => t.PlatnoscRodzajRefId);
            
            CreateTable(
                "dbo.JednPlatnoscRodzaj",
                c => new
                    {
                        JednPlatnoscRodzajId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        CzyDni = c.Boolean(nullable: false),
                        CzyUwagi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JednPlatnoscRodzajId);
            
            CreateTable(
                "dbo.FinPlatnoscPrzypomnienie",
                c => new
                    {
                        FinPlatnoscPrzypomnienieId = c.Int(nullable: false, identity: true),
                        CzyEuro = c.Boolean(nullable: false),
                        DataZaplaty = c.DateTime(),
                        DoneDateTime = c.DateTime(),
                        DoneBy = c.String(),
                        FakturaNr = c.String(nullable: false, maxLength: 100),
                        IsDone = c.Boolean(nullable: false),
                        KontrahentRefId = c.Int(nullable: false),
                        Kwota = c.Double(nullable: false),
                        TerminPlatnosci = c.DateTime(nullable: false),
                        Uwagi = c.String(),
                        FakturaZakupu_FinFakturaZakupuId = c.Int(),
                    })
                .PrimaryKey(t => t.FinPlatnoscPrzypomnienieId)
                .ForeignKey("dbo.Kontrahent", t => t.KontrahentRefId, cascadeDelete: true)
                .ForeignKey("dbo.FinFakturaZakupu", t => t.FakturaZakupu_FinFakturaZakupuId)
                .Index(t => t.KontrahentRefId)
                .Index(t => t.FakturaZakupu_FinFakturaZakupuId);
            
            CreateTable(
                "dbo.FinPolitykaCenowaRegula",
                c => new
                    {
                        FinPolitykaCenowaRegulaId = c.Int(nullable: false, identity: true),
                        CzyAktywna = c.Boolean(nullable: false),
                        KontrahentRefId = c.Int(nullable: false),
                        PolitykaCenowaRefId = c.Int(nullable: false),
                        TypRozliczenia = c.Int(nullable: false),
                        Wartosc = c.Double(nullable: false),
                        PolitykaCenowa_FinPolitykaCenowaId = c.Int(),
                    })
                .PrimaryKey(t => t.FinPolitykaCenowaRegulaId)
                .ForeignKey("dbo.Kontrahent", t => t.KontrahentRefId, cascadeDelete: true)
                .ForeignKey("dbo.FinPolitykaCenowa", t => t.PolitykaCenowa_FinPolitykaCenowaId)
                .Index(t => t.KontrahentRefId)
                .Index(t => t.PolitykaCenowa_FinPolitykaCenowaId);
            
            CreateTable(
                "dbo.FinPolitykaCenowa",
                c => new
                    {
                        FinPolitykaCenowaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.FinPolitykaCenowaId);
            
            CreateTable(
                "dbo.MagPz",
                c => new
                    {
                        MagPzId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CzyZaksiegowana = c.Boolean(nullable: false),
                        CzyKorekta = c.Boolean(nullable: false),
                        DataWplywu = c.DateTime(nullable: false),
                        DataWystawienia = c.DateTime(nullable: false),
                        DokumentZrodlowyNr = c.String(),
                        FakturaZakupuRefId = c.Int(),
                        DokumentZrodlowyRefId = c.Int(nullable: false),
                        KontrahentRefId = c.Int(nullable: false),
                        Uwagi = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.MagPzId)
                .ForeignKey("dbo.FinFakturaZakupu", t => t.FakturaZakupuRefId)
                .ForeignKey("dbo.JednDokumentTyp", t => t.DokumentZrodlowyRefId, cascadeDelete: true)
                .ForeignKey("dbo.Kontrahent", t => t.KontrahentRefId, cascadeDelete: true)
                .Index(t => t.FakturaZakupuRefId)
                .Index(t => t.DokumentZrodlowyRefId)
                .Index(t => t.KontrahentRefId);
            
            CreateTable(
                "dbo.JednDokumentTyp",
                c => new
                    {
                        JednDokumentTypId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.JednDokumentTypId);
            
            CreateTable(
                "dbo.MagPzKorekta",
                c => new
                    {
                        MagPzKorektaId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        DataWplywu = c.DateTime(nullable: false),
                        DataWystawienia = c.DateTime(nullable: false),
                        DokumentZrodlowyNr = c.String(),
                        DokumentZrodlowyRefId = c.Int(nullable: false),
                        KontrahentRefId = c.Int(nullable: false),
                        MagPzRefId = c.Int(nullable: false),
                        Uwagi = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.MagPzKorektaId)
                .ForeignKey("dbo.JednDokumentTyp", t => t.DokumentZrodlowyRefId, cascadeDelete: true)
                .ForeignKey("dbo.Kontrahent", t => t.KontrahentRefId, cascadeDelete: true)
                .ForeignKey("dbo.MagPz", t => t.MagPzRefId)
                .Index(t => t.DokumentZrodlowyRefId)
                .Index(t => t.KontrahentRefId)
                .Index(t => t.MagPzRefId);
            
            CreateTable(
                "dbo.MagPzPozycja",
                c => new
                    {
                        MagPzPozycjaId = c.Int(nullable: false, identity: true),
                        Ilosc = c.Double(nullable: false),
                        MagPzRefId = c.Int(),
                        MagPzKorektaRefId = c.Int(),
                        PozycjaMagazynowaRefId = c.Int(nullable: false),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MagPzPozycjaId)
                .ForeignKey("dbo.MagPz", t => t.MagPzRefId)
                .ForeignKey("dbo.MagPzKorekta", t => t.MagPzKorektaRefId)
                .ForeignKey("dbo.MagPozycjaMagazynowa", t => t.PozycjaMagazynowaRefId, cascadeDelete: true)
                .Index(t => t.MagPzRefId)
                .Index(t => t.MagPzKorektaRefId)
                .Index(t => t.PozycjaMagazynowaRefId);
            
            CreateTable(
                "dbo.JednGrupaZakladowa",
                c => new
                    {
                        JednGrupaZakladowaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 50),
                        Uwagi = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.JednGrupaZakladowaId);
            
            CreateTable(
                "dbo.JednJednostkaMiary",
                c => new
                    {
                        JednJednostkaMiaryId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 50),
                        Uwagi = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.JednJednostkaMiaryId);
            
            CreateTable(
                "dbo.JednMarzaZakladowa",
                c => new
                    {
                        JednMarzaZakladowaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 50),
                        Wartosc = c.Double(nullable: false),
                        Uwagi = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.JednMarzaZakladowaId);
            
            CreateTable(
                "dbo.KombinacjaRobocizna",
                c => new
                    {
                        KombinacjaRobociznaId = c.Int(nullable: false, identity: true),
                        Wartosc = c.Int(nullable: false),
                        RobociznaRefId = c.Int(nullable: false),
                        KombinacjaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KombinacjaRobociznaId)
                .ForeignKey("dbo.Kombinacja", t => t.KombinacjaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Robocizna", t => t.RobociznaRefId, cascadeDelete: true)
                .Index(t => t.RobociznaRefId)
                .Index(t => t.KombinacjaRefId);
            
            CreateTable(
                "dbo.Robocizna",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KombinacjaWykonczenie",
                c => new
                    {
                        KombinacjaWykonczenieId = c.Int(nullable: false, identity: true),
                        KombinacjaRefId = c.Int(nullable: false),
                        WykonczenieRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KombinacjaWykonczenieId)
                .ForeignKey("dbo.Kombinacja", t => t.KombinacjaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Wykonczenie", t => t.WykonczenieRefId, cascadeDelete: true)
                .Index(t => t.KombinacjaRefId)
                .Index(t => t.WykonczenieRefId);
            
            CreateTable(
                "dbo.Wykonczenie",
                c => new
                    {
                        WykonczenieId = c.Int(nullable: false, identity: true),
                        CzyPolitykaCenowa = c.Boolean(nullable: false),
                        Nazwa = c.String(nullable: false),
                        PolitykaCenowaAktywnaId = c.Int(),
                        WykonczenieGrupaRefId = c.Int(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.WykonczenieId)
                .ForeignKey("dbo.WykonczenieGrupa", t => t.WykonczenieGrupaRefId, cascadeDelete: true)
                .Index(t => t.WykonczenieGrupaRefId);
            
            CreateTable(
                "dbo.WykonczenieGrupa",
                c => new
                    {
                        WykonczenieGrupaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.WykonczenieGrupaId);
            
            CreateTable(
                "dbo.NazwaKombinacji",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QrCodeBasket",
                c => new
                    {
                        QrCodeBasketId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Grupa = c.String(nullable: false),
                        Uwagi = c.String(nullable: false),
                        Link = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.QrCodeBasketId);
            
            CreateTable(
                "dbo.Sprawki",
                c => new
                    {
                        SprawkiId = c.Int(nullable: false, identity: true),
                        Tytul = c.String(nullable: false),
                        Grupa = c.String(nullable: false),
                        Priorytet = c.Int(nullable: false),
                        Opis = c.String(),
                        Respond = c.String(),
                        Zglaszajacy = c.String(),
                        DataZgloszenia = c.DateTime(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SprawkiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kombinacja", "NazwaKombinacjiRefId", "dbo.NazwaKombinacji");
            DropForeignKey("dbo.KombinacjaEtapyProdukcyjne", "KombinacjaRefId", "dbo.Kombinacja");
            DropForeignKey("dbo.KombinacjaWykonczenie", "WykonczenieRefId", "dbo.Wykonczenie");
            DropForeignKey("dbo.Wykonczenie", "WykonczenieGrupaRefId", "dbo.WykonczenieGrupa");
            DropForeignKey("dbo.KombinacjaWykonczenie", "KombinacjaRefId", "dbo.Kombinacja");
            DropForeignKey("dbo.KombinacjaRobocizna", "RobociznaRefId", "dbo.Robocizna");
            DropForeignKey("dbo.KombinacjaRobocizna", "KombinacjaRefId", "dbo.Kombinacja");
            DropForeignKey("dbo.MagPozycjaMagazynowa", "MarzaZakladowaRefId", "dbo.JednMarzaZakladowa");
            DropForeignKey("dbo.MagPzPozycja", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.KombinacjaPozycjaMagazynowa", "MagPozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.MagPozycjaMagazynowa", "JednostkaMiaryRefId", "dbo.JednJednostkaMiary");
            DropForeignKey("dbo.MagPozycjaMagazynowa", "GrupaZakladowaRefId", "dbo.JednGrupaZakladowa");
            DropForeignKey("dbo.FinFakturaPozycje", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.MagPz", "KontrahentRefId", "dbo.Kontrahent");
            DropForeignKey("dbo.MagPzPozycja", "MagPzKorektaRefId", "dbo.MagPzKorekta");
            DropForeignKey("dbo.MagPzPozycja", "MagPzRefId", "dbo.MagPz");
            DropForeignKey("dbo.MagPzKorekta", "MagPzRefId", "dbo.MagPz");
            DropForeignKey("dbo.MagPzKorekta", "KontrahentRefId", "dbo.Kontrahent");
            DropForeignKey("dbo.MagPzKorekta", "DokumentZrodlowyRefId", "dbo.JednDokumentTyp");
            DropForeignKey("dbo.MagPz", "DokumentZrodlowyRefId", "dbo.JednDokumentTyp");
            DropForeignKey("dbo.MagPz", "FakturaZakupuRefId", "dbo.FinFakturaZakupu");
            DropForeignKey("dbo.FinPlatnoscPrzypomnienie", "FakturaZakupu_FinFakturaZakupuId", "dbo.FinFakturaZakupu");
            DropForeignKey("dbo.FinPolitykaCenowaRegula", "PolitykaCenowa_FinPolitykaCenowaId", "dbo.FinPolitykaCenowa");
            DropForeignKey("dbo.FinPolitykaCenowaRegula", "KontrahentRefId", "dbo.Kontrahent");
            DropForeignKey("dbo.FinPlatnoscPrzypomnienie", "KontrahentRefId", "dbo.Kontrahent");
            DropForeignKey("dbo.MaterialGrupaKontrahent", "Kontrahent_KontrahentId", "dbo.Kontrahent");
            DropForeignKey("dbo.KontrahentPlatnosc", "PlatnoscRodzajRefId", "dbo.JednPlatnoscRodzaj");
            DropForeignKey("dbo.FinFakturaZakupu", "PlatnoscRodzajRefId", "dbo.JednPlatnoscRodzaj");
            DropForeignKey("dbo.Kontrahent", "KontrahentPlatnoscRefId", "dbo.KontrahentPlatnosc");
            DropForeignKey("dbo.Zamowienie", "KontrahentDealerDostawaRefId", "dbo.KontrahentDealer");
            DropForeignKey("dbo.Zamowienie", "KontrahentDealerRefId", "dbo.KontrahentDealer");
            DropForeignKey("dbo.ZamowienieStatusWartosc", "ZamowienieStatusNazwaRefId", "dbo.ZamowienieStatusNazwa");
            DropForeignKey("dbo.ZamowienieStatusWartosc", "ZamowienieRefId", "dbo.Zamowienie");
            DropForeignKey("dbo.Zamowienie", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.MaterialBelkaRozchodObszycie", "ZamowienieObszycieRefId", "dbo.ZamowienieKombiObszycie");
            DropForeignKey("dbo.MaterialBelkaRozchodObszycie", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.MaterialBelkaRozchodObszycie", "MaterialBelkaRefId", "dbo.MaterialBelka");
            DropForeignKey("dbo.MagPozycjaMagazynowaRozchodInne", "RozchodMagRodzajRefId", "dbo.JednRozchodMagRodzaj");
            DropForeignKey("dbo.MagPozycjaMagazynowaRozchodInne", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.MaterialBelkaRozchodInne", "RozchodMagRodzajRefId", "dbo.JednRozchodMagRodzaj");
            DropForeignKey("dbo.MaterialBelkaRozchodInne", "MaterialBelkaRefId", "dbo.MaterialBelka");
            DropForeignKey("dbo.MaterialBelka", "MaterialRefId", "dbo.Material");
            DropForeignKey("dbo.Material", "MaterialGrupaRefId", "dbo.MaterialGrupaKontrahent");
            DropForeignKey("dbo.KombinacjaObszycie", "Material_MaterialId", "dbo.Material");
            DropForeignKey("dbo.ZamowienieKombiObszycie", "ZamowienieKombiRefId", "dbo.ZamowienieKombi");
            DropForeignKey("dbo.ZamowienieKombi", "ZamowienieRefId", "dbo.Zamowienie");
            DropForeignKey("dbo.ZamowienieKombi", "WypychRefId", "dbo.Wypych");
            DropForeignKey("dbo.ZamowienieKombi", "KombinacjaRefId", "dbo.Kombinacja");
            DropForeignKey("dbo.ZamowienieKombiObszycie", "MaterialRefId", "dbo.Material");
            DropForeignKey("dbo.ZamowienieKombiObszycie", "KombinacjeObszycieRefId", "dbo.KombinacjaObszycie");
            DropForeignKey("dbo.KombinacjaObszycie", "ObszycieRefId", "dbo.Obszycie");
            DropForeignKey("dbo.KombinacjaObszycie", "KombinacjaRefId", "dbo.Kombinacja");
            DropForeignKey("dbo.Zamowienie", "NormaRefId", "dbo.Norma");
            DropForeignKey("dbo.Kombinacja", "NormaRefId", "dbo.Norma");
            DropForeignKey("dbo.KontrahentDealer", "KontrahentRefId", "dbo.Kontrahent");
            DropForeignKey("dbo.FinFakturaZakupu", "KontrahentRefId", "dbo.Kontrahent");
            DropForeignKey("dbo.FinFakturaPozycje", "FakturaZakupuRefId", "dbo.FinFakturaZakupu");
            DropForeignKey("dbo.MagPozycjaMagazynowa", "VatZakupuRefId", "dbo.JednPodatekStawka");
            DropForeignKey("dbo.MagPozycjaMagazynowa", "VatSprzedazyRefId", "dbo.JednPodatekStawka");
            DropForeignKey("dbo.FinFakturaPodsumowanieWartosci", "PodatekStawkaRefId", "dbo.JednPodatekStawka");
            DropForeignKey("dbo.FinFakturaPodsumowanieWartosci", "FakturaZakupuRefId", "dbo.FinFakturaZakupu");
            DropForeignKey("dbo.KombinacjaPozycjaMagazynowa", "KombinacjaRefId", "dbo.Kombinacja");
            DropForeignKey("dbo.KombinacjaEtapyProdukcyjne", "EtapyProdukcyjneRefId", "dbo.EtapyProdukcyjne");
            DropIndex("dbo.Wykonczenie", new[] { "WykonczenieGrupaRefId" });
            DropIndex("dbo.KombinacjaWykonczenie", new[] { "WykonczenieRefId" });
            DropIndex("dbo.KombinacjaWykonczenie", new[] { "KombinacjaRefId" });
            DropIndex("dbo.KombinacjaRobocizna", new[] { "KombinacjaRefId" });
            DropIndex("dbo.KombinacjaRobocizna", new[] { "RobociznaRefId" });
            DropIndex("dbo.MagPzPozycja", new[] { "PozycjaMagazynowaRefId" });
            DropIndex("dbo.MagPzPozycja", new[] { "MagPzKorektaRefId" });
            DropIndex("dbo.MagPzPozycja", new[] { "MagPzRefId" });
            DropIndex("dbo.MagPzKorekta", new[] { "MagPzRefId" });
            DropIndex("dbo.MagPzKorekta", new[] { "KontrahentRefId" });
            DropIndex("dbo.MagPzKorekta", new[] { "DokumentZrodlowyRefId" });
            DropIndex("dbo.MagPz", new[] { "KontrahentRefId" });
            DropIndex("dbo.MagPz", new[] { "DokumentZrodlowyRefId" });
            DropIndex("dbo.MagPz", new[] { "FakturaZakupuRefId" });
            DropIndex("dbo.FinPolitykaCenowaRegula", new[] { "PolitykaCenowa_FinPolitykaCenowaId" });
            DropIndex("dbo.FinPolitykaCenowaRegula", new[] { "KontrahentRefId" });
            DropIndex("dbo.FinPlatnoscPrzypomnienie", new[] { "FakturaZakupu_FinFakturaZakupuId" });
            DropIndex("dbo.FinPlatnoscPrzypomnienie", new[] { "KontrahentRefId" });
            DropIndex("dbo.KontrahentPlatnosc", new[] { "PlatnoscRodzajRefId" });
            DropIndex("dbo.ZamowienieStatusWartosc", new[] { "ZamowienieRefId" });
            DropIndex("dbo.ZamowienieStatusWartosc", new[] { "ZamowienieStatusNazwaRefId" });
            DropIndex("dbo.MagPozycjaMagazynowaRozchodInne", new[] { "PozycjaMagazynowaRefId" });
            DropIndex("dbo.MagPozycjaMagazynowaRozchodInne", new[] { "RozchodMagRodzajRefId" });
            DropIndex("dbo.MaterialBelkaRozchodInne", new[] { "RozchodMagRodzajRefId" });
            DropIndex("dbo.MaterialBelkaRozchodInne", new[] { "MaterialBelkaRefId" });
            DropIndex("dbo.MaterialGrupaKontrahent", new[] { "Kontrahent_KontrahentId" });
            DropIndex("dbo.ZamowienieKombi", new[] { "ZamowienieRefId" });
            DropIndex("dbo.ZamowienieKombi", new[] { "WypychRefId" });
            DropIndex("dbo.ZamowienieKombi", new[] { "KombinacjaRefId" });
            DropIndex("dbo.ZamowienieKombiObszycie", new[] { "ZamowienieKombiRefId" });
            DropIndex("dbo.ZamowienieKombiObszycie", new[] { "MaterialRefId" });
            DropIndex("dbo.ZamowienieKombiObszycie", new[] { "KombinacjeObszycieRefId" });
            DropIndex("dbo.KombinacjaObszycie", new[] { "Material_MaterialId" });
            DropIndex("dbo.KombinacjaObszycie", new[] { "KombinacjaRefId" });
            DropIndex("dbo.KombinacjaObszycie", new[] { "ObszycieRefId" });
            DropIndex("dbo.Material", new[] { "MaterialGrupaRefId" });
            DropIndex("dbo.MaterialBelka", new[] { "MaterialRefId" });
            DropIndex("dbo.MaterialBelkaRozchodObszycie", new[] { "PlanningRefId" });
            DropIndex("dbo.MaterialBelkaRozchodObszycie", new[] { "MaterialBelkaRefId" });
            DropIndex("dbo.MaterialBelkaRozchodObszycie", new[] { "ZamowienieObszycieRefId" });
            DropIndex("dbo.Zamowienie", new[] { "PlanningRefId" });
            DropIndex("dbo.Zamowienie", new[] { "NormaRefId" });
            DropIndex("dbo.Zamowienie", new[] { "KontrahentDealerDostawaRefId" });
            DropIndex("dbo.Zamowienie", new[] { "KontrahentDealerRefId" });
            DropIndex("dbo.KontrahentDealer", new[] { "KontrahentRefId" });
            DropIndex("dbo.Kontrahent", new[] { "KontrahentPlatnoscRefId" });
            DropIndex("dbo.FinFakturaPodsumowanieWartosci", new[] { "PodatekStawkaRefId" });
            DropIndex("dbo.FinFakturaPodsumowanieWartosci", new[] { "FakturaZakupuRefId" });
            DropIndex("dbo.FinFakturaZakupu", new[] { "PlatnoscRodzajRefId" });
            DropIndex("dbo.FinFakturaZakupu", new[] { "KontrahentRefId" });
            DropIndex("dbo.FinFakturaPozycje", new[] { "FakturaZakupuRefId" });
            DropIndex("dbo.FinFakturaPozycje", new[] { "PozycjaMagazynowaRefId" });
            DropIndex("dbo.MagPozycjaMagazynowa", new[] { "VatZakupuRefId" });
            DropIndex("dbo.MagPozycjaMagazynowa", new[] { "VatSprzedazyRefId" });
            DropIndex("dbo.MagPozycjaMagazynowa", new[] { "MarzaZakladowaRefId" });
            DropIndex("dbo.MagPozycjaMagazynowa", new[] { "JednostkaMiaryRefId" });
            DropIndex("dbo.MagPozycjaMagazynowa", new[] { "GrupaZakladowaRefId" });
            DropIndex("dbo.KombinacjaPozycjaMagazynowa", new[] { "KombinacjaRefId" });
            DropIndex("dbo.KombinacjaPozycjaMagazynowa", new[] { "MagPozycjaMagazynowaRefId" });
            DropIndex("dbo.Kombinacja", new[] { "NormaRefId" });
            DropIndex("dbo.Kombinacja", new[] { "NazwaKombinacjiRefId" });
            DropIndex("dbo.KombinacjaEtapyProdukcyjne", new[] { "EtapyProdukcyjneRefId" });
            DropIndex("dbo.KombinacjaEtapyProdukcyjne", new[] { "KombinacjaRefId" });
            DropTable("dbo.Sprawki");
            DropTable("dbo.QrCodeBasket");
            DropTable("dbo.NazwaKombinacji");
            DropTable("dbo.WykonczenieGrupa");
            DropTable("dbo.Wykonczenie");
            DropTable("dbo.KombinacjaWykonczenie");
            DropTable("dbo.Robocizna");
            DropTable("dbo.KombinacjaRobocizna");
            DropTable("dbo.JednMarzaZakladowa");
            DropTable("dbo.JednJednostkaMiary");
            DropTable("dbo.JednGrupaZakladowa");
            DropTable("dbo.MagPzPozycja");
            DropTable("dbo.MagPzKorekta");
            DropTable("dbo.JednDokumentTyp");
            DropTable("dbo.MagPz");
            DropTable("dbo.FinPolitykaCenowa");
            DropTable("dbo.FinPolitykaCenowaRegula");
            DropTable("dbo.FinPlatnoscPrzypomnienie");
            DropTable("dbo.JednPlatnoscRodzaj");
            DropTable("dbo.KontrahentPlatnosc");
            DropTable("dbo.ZamowienieStatusNazwa");
            DropTable("dbo.ZamowienieStatusWartosc");
            DropTable("dbo.MagPozycjaMagazynowaRozchodInne");
            DropTable("dbo.JednRozchodMagRodzaj");
            DropTable("dbo.MaterialBelkaRozchodInne");
            DropTable("dbo.MaterialGrupaKontrahent");
            DropTable("dbo.Wypych");
            DropTable("dbo.ZamowienieKombi");
            DropTable("dbo.ZamowienieKombiObszycie");
            DropTable("dbo.Obszycie");
            DropTable("dbo.KombinacjaObszycie");
            DropTable("dbo.Material");
            DropTable("dbo.MaterialBelka");
            DropTable("dbo.MaterialBelkaRozchodObszycie");
            DropTable("dbo.Planning");
            DropTable("dbo.Norma");
            DropTable("dbo.Zamowienie");
            DropTable("dbo.KontrahentDealer");
            DropTable("dbo.Kontrahent");
            DropTable("dbo.JednPodatekStawka");
            DropTable("dbo.FinFakturaPodsumowanieWartosci");
            DropTable("dbo.FinFakturaZakupu");
            DropTable("dbo.FinFakturaPozycje");
            DropTable("dbo.MagPozycjaMagazynowa");
            DropTable("dbo.KombinacjaPozycjaMagazynowa");
            DropTable("dbo.Kombinacja");
            DropTable("dbo.KombinacjaEtapyProdukcyjne");
            DropTable("dbo.EtapyProdukcyjne");
            DropTable("dbo.ChangeLog");
        }
    }
}
