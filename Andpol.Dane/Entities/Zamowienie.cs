using Andpol.Dane.Pomocne.MagWZ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class Zamowienie
    {
        public Zamowienie() {
            this.MagWzPozycjaZamowienie = new HashSet<MagWzPozycjaZamowienie>();
            this.ZamowienieKombi = new HashSet<ZamowienieKombi>();
            this.ZamowienieStatusWartosc = new HashSet<ZamowienieStatusWartosc>();
        }

        [Key]
        public int Id { get; set; }

        public string Commission { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public bool CzyZaplanowane { get; set; }

        [Required(ErrorMessage = "Zamówienie, pole DATA ZAMÓWIENIA jest wymagane")]
        public DateTime DataZamowienia { get; set; }
        public DateTime? DataRealizacji { get; set; }

        [Required(ErrorMessage = "Zamówienie, pole ILOŚĆ jest wymagane")]
        public int Ilosc { get; set; }

        public int KontrahentDealerRefId { get; set; }
        [ForeignKey("KontrahentDealerRefId")]
        public virtual KontrahentDealer Dealer { get; set; }

        public int KontrahentDealerDostawaRefId { get; set; }
        [ForeignKey("KontrahentDealerDostawaRefId")]
        public virtual KontrahentDealer DealerDostawa { get; set; }


        public int NormaRefId { get; set; }
        [ForeignKey("NormaRefId")]
        public virtual Norma Norma { get; set; }
        public string Reference { get; set; }
        public bool RequireDeliver { get; set; }
        public string Uwagi { get; set; }
        public string ZamowienieNr { get; set; }
        public Byte ZamowienieStatus { get; set; }

        public virtual ICollection<MagWzPozycjaZamowienie> MagWzPozycjaZamowienie { get; set; }
        public virtual ICollection<ZamowienieKombi> ZamowienieKombi { get; set; }
        public virtual ICollection<ZamowienieStatusWartosc> ZamowienieStatusWartosc { get; set; }
    }
}