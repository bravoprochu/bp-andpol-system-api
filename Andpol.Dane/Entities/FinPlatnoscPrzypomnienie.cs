using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class FinPlatnoscPrzypomnienie
    {

        public int FinPlatnoscPrzypomnienieId { get; set; }

        public bool CzyEuro { get; set; }

        public DateTime? DataZaplaty { get; set; }

        public DateTime? DoneDateTime { get; set; }
        public string DoneBy { get; set; }

        [Required, StringLength(100)]
        public string FakturaNr { get; set; }

        public virtual FinFakturaZakupu FakturaZakupu { get; set; }

        public bool IsDone { get; set; }

        public int KontrahentRefId { get; set; }

        [ForeignKey("KontrahentRefId")]
        public virtual Kontrahent Kontrahent { get; set; }


        [Required]
        public double Kwota { get; set; }

        [Required]
        public DateTime TerminPlatnosci { get; set; }


        public string Uwagi { get; set; }

        public int WalutaRefId { get; set; }
        [ForeignKey("WalutaRefId")]
        public virtual FinWaluta Waluta { get; set; }





    }
}