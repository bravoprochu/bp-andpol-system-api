using Andpol.Dane.Pomocne.FakturaSprzedazy.Entity;
using Andpol.Dane.Pomocne.MagWZ;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class Kontrahent
    {
        public Kontrahent()
        {
            this.KontrahentDealerzy = new HashSet<KontrahentDealer>();
            this.PlatnoscPrzypomnienie = new HashSet<FinPlatnoscPrzypomnienie>();
            this.FakturaZakupu = new HashSet<FinFakturaZakupu>();
            this.FakturaSprzedazyNabywca = new HashSet<FinFakturaSprzedazy>();
            this.FakturaSprzedazySprzedawca = new HashSet<FinFakturaSprzedazy>();
            this.PolitykaCenowa = new HashSet<FinPolitykaCenowaRegula>();
        }

        [Key]
        public int KontrahentId { get; set; }

        public bool CzyDealerzy { get; set; }
        public bool CzyDostawca { get; set; }
        public bool CzyOdbiorca { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Fax { get; set; }

        [StringLength(30)]
        public string Imie { get; set; }

        [StringLength(2)]
        public string KodKraju { get; set; }
        [StringLength(8)]
        public string KodPocztowy { get; set; }

        [StringLength(28)]
        public string KontoBankowe { get; set; }
        [StringLength(11)]
        public string KontoBankoweSwift { get; set; }

        [StringLength(28)]
        public string KontoBankowe2 { get; set; }

        [StringLength(11)]
        public string KontoBankowe2Swift { get; set; }

        public int? KontrahentPlatnoscRefId { get; set; }
        [ForeignKey("KontrahentPlatnoscRefId")]
        public virtual KontrahentPlatnosc KontrahentPlatnosc { get; set; }

        public virtual MaterialGrupaKontrahent MaterialGrupa { get; set; }

        [StringLength(50)]
        public string Miejscowosc { get; set; }

        [StringLength(100)]
        public string Nazwa { get; set; }

        [StringLength(50)]
        public string Nazwisko { get; set; }

        [StringLength(12)]
        public string NIP { get; set; }

        [StringLength(11)]
        public string Pesel { get; set; }

        [StringLength(30)]
        public string Skrot { get; set; }

        [StringLength(15)]
        public string Tel { get; set; }
        
        [StringLength(15)]
        public string Tel2 { get; set; }

        public int TypKontrahentaRefId { get; set; }

        [StringLength(50)]
        public string Ulica { get; set; }
        [StringLength(30)]
        public string UlicaNr { get; set; }

        [DataType(DataType.Url)]
        public string WWW { get; set; }


        [JsonIgnore]
        public virtual ICollection<KontrahentDealer> KontrahentDealerzy { get; set; }
        [JsonIgnore]
        public virtual ICollection<FinPlatnoscPrzypomnienie> PlatnoscPrzypomnienie { get; set; }
        [JsonIgnore]
        public virtual ICollection<FinFakturaZakupu> FakturaZakupu { get; set; }
        [InverseProperty("Nabywca")]
        public virtual ICollection<FinFakturaSprzedazy> FakturaSprzedazyNabywca { get; set; }
        [InverseProperty("Sprzedawca")]
        public virtual ICollection<FinFakturaSprzedazy> FakturaSprzedazySprzedawca { get; set; }
        public virtual ICollection<FinPolitykaCenowaRegula> PolitykaCenowa { get; set; }


    }
}
