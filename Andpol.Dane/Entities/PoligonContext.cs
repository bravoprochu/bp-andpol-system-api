using Andpol.Dane.Pomocne.FakturaSprzedazy.Entity;
using Andpol.Dane.Pomocne.MagWZ;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Andpol.Dane.Entities
{
    public class PoligonContext:DbContext
    {
        public PoligonContext() :base("AndpolDb-Dane")
        {
            // this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false; 
          
        }

        public DbSet<ChangeLog> ChangeLog { get; set; }


        public DbSet<EtapyProdukcyjne> EtapyProdukcyjne {get; set; }

        public DbSet<FinFakturaSprzedazy> FinFakturaSprzedazy { get; set; }
        public DbSet<FinFakturaSprzedazyDodatkoweInfo> FinFakturaSprzedazyDodatkoweInfo { get; set; }
        public DbSet<FinFakturaSprzedazyPlatnosc> FinFakruraSprzedazyPlatnosc { get; set; }
        public DbSet<FinFakturaSprzedazyPozycja> FinFakturaSprzedazyPozycja { get; set; }

        public DbSet<FinFakturaPodsumowanieWartosci> FinFakturaPodsumowanieWartosci { get; set; }
        public DbSet<FinFakturaPozycje> FinFakturaPozycje { get; set; }
        public DbSet<FinFakturaPozycjeTkaniny> FinFakturaPozycjeTkaniny { get; set; }
        public DbSet<FinFakturaZakupu> FinFakturaZakupu { get; set; }
        public DbSet<FinPolitykaCenowa> FinPolitykaCenowa { get; set; }
        public DbSet<FinPolitykaCenowaRegula> FinPolitykaCenowaRegula { get; set; }
        public DbSet<FinWaluta> FinWaluta { get; set; }

        public DbSet<JednDokumentTyp> JednDokumentTyp { get; set; }
        public DbSet<JednGrupaZakladowa> JednGrupaZakladowa { get; set; }
        public DbSet<JednJednostkaMiary> JednJednostkaMiary { get; set; }
        public DbSet<JednMarzaZakladowa> JednMarzaZakladowa { get; set; }

        public DbSet<JednPlatnoscRodzaj> JednPlatnoscRodzaj { get; set; }
        public DbSet<JednPodatekStawka> JednPodatekStawka { get; set; }
        public DbSet<JednRozchodMagRodzaj> JednRozchodMagRodzaj { get; set; }

        public DbSet<KalendarzDniRoboczych> KalendarzDniRoboczych { get; set; }
        public DbSet<KalendarzDniRoboczychDzialProd> KalendarzDniRoboczychDzialProd { get; set; }
        public DbSet<KalendarzDniRoboczychDzialProdGrupaRoboczaSklad> KalendarzDniRoboczychDzialProdGrupaRoboczaSklad { get; set; }

        public DbSet<KalendarzDniRoboczychSzablon> KalendarzDniRoboczychSzablon { get; set; }
        public DbSet<KalendarzDniRoboczychZakres> KalendarzDniRoboczychZakres { get; set; }

        public DbSet<Kombinacja> Kombinacja { get; set; }

        public DbSet<KombinacjaEtapyProdukcyjne> KombinacjaEtapyProdukcyjne { get; set; }
        public DbSet<KombinacjaObszycie> KombinacjaObszycie { get; set; }
        public DbSet<KombinacjaPozycjaMagazynowa> KombinacjaPozycjaMagazynowa { get; set; }
        public DbSet<KombinacjaWykonczenie> KombinacjaWykonczenie { get; set; }
        public DbSet<KombinacjaRobocizna> KombinacjaRobocizna { get; set; }
        public DbSet<KombinacjaRobociznaGrupaRobocza> KombinacjaRobociznaGrupaRobocza { get; set;}

        public DbSet<Kontrahent> Kontrahent{ get; set; }
        public DbSet<KontrahentDealer> KontrahentDealerzy { get; set; }
        public DbSet<KontrahentPlatnosc> KontrahentPlatnosc { get; set; }

        public DbSet<LogsDelete> LogsDelete { get; set; }

        public DbSet<MagPozycjaMagazynowa> MagPozycjaMagazynowa { get; set; }
        public DbSet<MagPozycjaMagazynowaRozchodInne> MagPozycjaMagazynowaRozchodInne { get; set; }
        public DbSet<MagPz> MagPz { get; set; }
        public DbSet<MagPzPozycja> MagPzPozycja { get; set; }
        public DbSet<MagPzKorekta> MagPzKorekta { get; set; }

        public DbSet<MagWz> MagWz { get; set; }
        public DbSet<MagWzPozycjaPozMag> MagWzPozycjaPozMag { get; set; }
        public DbSet<MagWzPozycjaZamowienie> MagWzPozycjaZamowienie { get; set; }

        public DbSet<Material> Material { get; set; }
        public DbSet<MaterialBelka> MaterialBelka { get; set; }
        public DbSet<MaterialGrupaKontrahent> MaterialGrupaKontrahent { get; set; }
        public DbSet<MaterialBelkaPzTkaniny> MaterialBelkaPzTkaniny { get; set; }
        public DbSet<MaterialBelkaRozchodInne> MaterialBelkaRozchodInne { get; set; }
        public DbSet<MaterialBelkaRozchodObszycie> MaterialBelkaRozchodObszycie { get; set; }

        public DbSet<NazwaKombinacji> NazwaKombinacji { get; set; }
        public DbSet<Norma> Normy { get; set; }
        public DbSet<Obszycie> Obszycie { get; set; }

        public DbSet<Planning> Planning { get; set; }
        public DbSet<PlanningDzienRoboczy> PlanningDzienRoboczy { get; set; }
        public DbSet<PlanningPozycjaMagazynowa> PlanningPozycjaMagazynowa { get; set; }
        public DbSet<PlanningTkaninaBelka> PlanningTkaninaBelka { get; set; }
        public DbSet<PlanningDzienRoboczyZamowienieKombi> PlanningDzienRoboczyZamowienieKombi { get; set; }
        public DbSet<PlanningTkaninaBelkaListaObszyc> PlanningTkaninaBelkaListaObszyc { get; set; }




        public DbSet<ProdukcjaDzial> ProdukcjaDzial { get; set; }
        public DbSet<ProdukcjaBrygadzista> ProdukcjaBrygadzista { get; set; }



        public DbSet<FinPlatnoscPrzypomnienie> FinPlatnoscPrzypomnienie { get; set; }
        public DbSet<QrCodeBasket> QrCodeBasket { get; set; }
        public DbSet<Robocizna> Robocizna { get; set; }


        public DbSet<Sprawki> Sprawki { get; set; }

        public DbSet<Wykonczenie> Wykonczenie { get; set; }
        public DbSet<WykonczenieGrupa> WykonczenieGrupa { get; set; }

        public DbSet<Zamowienie> Zamowienie { get; set; }
        public DbSet<ZamowienieKombi> ZamowienieKombi { get; set; }
        public DbSet<ZamowienieKombiWykonczenie> ZamowienieKombiWykonczenie { get; set; }
        public DbSet<ZamowienieKombiObszycie> ZamowienieKombiObszycie { get; set; }
        public DbSet<ZamowienieStatusWartosc> ZamowienieStatusWartosc { get; set; }
        public DbSet<ZamowienieStatusNazwa> ZamowienieStatusNazwa { get; set; }
        
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<MagPozycjaMagazynowa>()
                .HasRequired(r => r.VatSprzedazy)
                .WithMany(m => m.VatSprzedazyColl)
                .HasForeignKey(k => k.VatSprzedazyRefId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MagPozycjaMagazynowa>()
                .HasRequired(r => r.VatZakupu)
                .WithMany(m => m.VatZakupuColl)
                .HasForeignKey(f => f.VatZakupuRefId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MagPzPozycja>()
                .HasOptional(pk => pk.MagPzKorekta)
                .WithMany(pk => pk.MagPzPozycja)
                .HasForeignKey(p => p.MagPzKorektaRefId);

            modelBuilder.Entity<MagPzPozycja>()
                .HasOptional(pz => pz.MagPz)
                .WithMany(pp => pp.MagPzPozycja)
                .HasForeignKey(pz => pz.MagPzRefId);

            modelBuilder.Entity<MagPzKorekta>()
                .HasRequired(pz => pz.MagPz)
                .WithMany(pk => pk.MagPzKorekta)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<FinFakturaSprzedazy>()
                .HasRequired(rn => rn.Nabywca)
                .WithMany(mn => mn.FakturaSprzedazyNabywca)
                .HasForeignKey(f => f.NabywcaRefId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FinFakturaSprzedazy>()
                .HasRequired(rs => rs.Sprzedawca)
                .WithMany(m => m.FakturaSprzedazySprzedawca)
                .HasForeignKey(f => f.SprzedawcaRefId)
                .WillCascadeOnDelete(false);




            modelBuilder.Entity<FinFakturaZakupu>()
                .HasOptional(p => p.PlatnoscPrzypomnienie)
                .WithOptionalPrincipal(f => f.FakturaZakupu);

            modelBuilder.Entity<Kontrahent>()
                .HasOptional(mg => mg.MaterialGrupa)
                .WithOptionalPrincipal(k => k.Kontrahent);

            modelBuilder.Entity<Zamowienie>()
                .HasRequired(d => d.Dealer)
                .WithMany(z => z.ZamDealer)
                .HasForeignKey(d => d.KontrahentDealerRefId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Zamowienie>()
                .HasRequired(dd => dd.DealerDostawa)
                .WithMany(z => z.ZamDealerDostawa)
                .HasForeignKey(dd => dd.KontrahentDealerDostawaRefId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ZamowienieKombiWykonczenie>()
                .HasRequired(zk=>zk.ZamowienieKombi)
                .WithMany(zkw => zkw.ZamowienieKombiWykonczenie)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<KalendarzDniRoboczychSzablon>()
                .HasKey(k => k.KalendarzDniRoboczychDzialProdId)
                .HasRequired(r => r.KalendarzDniRoboczychDzialProd)
                .WithOptional(o => o.KalendarzDniRoboczychSzablon)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<KalendarzDniRoboczych>()
                .HasMany(m => m.KalendarzDniRoboczychDzialProd)
                .WithOptional(o => o.KalendarzDniRoboczych)
                .HasForeignKey(f => f.KalendarzDniRoboczychRefId)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<ZamowienieKombiObszycie>()
                .HasRequired(zk => zk.ZamowienieKombi)
                .WithMany(zk => zk.ZamowienieObszycie)
                .HasForeignKey(zk => zk.ZamowienieKombiRefId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ZamowienieKombiObszycie>()
                .HasRequired(zk => zk.KombinacjeObszycie)
                .WithMany(zk => zk.ZamowienieObszycie)
                .HasForeignKey(zk => zk.KombinacjeObszycieRefId)
                .WillCascadeOnDelete(false);




            modelBuilder.Entity<ZamowienieKombi>()
                .HasRequired(k => k.Kombinacja)
                .WithMany(k => k.ZamowienieKombi)
                .HasForeignKey(k => k.KombinacjaRefId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<MaterialBelka>()
                .HasRequired(m => m.Material)
                .WithMany(m => m.MaterialBelka)
                .HasForeignKey(m => m.MaterialRefId)
                .WillCascadeOnDelete(false);

            
            modelBuilder.Entity<KombinacjaRobociznaGrupaRobocza>()
                .HasRequired<Robocizna>(o => o.Robocizna)
                .WithMany(m=>m.KombinacjaRobociznaGrupaRobocza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KalendarzDniRoboczychDzialProdGrupaRoboczaSklad>()
                .HasRequired(r => r.Robocizna)
                .WithMany(m => m.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad)
                .HasForeignKey(f => f.RobociznaRefId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<FinFakturaSprzedazyDodatkoweInfo>()
                .HasKey(k => k.FinFakturaSprzedazyId);


            modelBuilder.Entity<FinFakturaSprzedazy>()
                .HasOptional(op => op.DodatkoweInfo)
                .WithRequired(r => r.FakturaSprzedazy);

        }

 
    }


    
    
}