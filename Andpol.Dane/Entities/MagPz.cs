using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class MagPz
    {
        public MagPz()
        {
            this.MagPzKorekta = new HashSet<MagPzKorekta>();
            this.MagPzPozycja = new HashSet<MagPzPozycja>();
        }
        public int MagPzId { get; set; }

        public string CreatedBy { get; set; }
        public bool CzyZaksiegowana { get; set; }
        public bool CzyKorekta { get; set; }

        public DateTime DataWplywu { get; set; }
        public DateTime DataWystawienia { get; set; }

        public string DokumentZrodlowyNr { get; set; }

        public int? FakturaZakupuRefId { get; set; }
        [ForeignKey("FakturaZakupuRefId")]
        public virtual FinFakturaZakupu FakturaZakupu { get; set; }

        public int DokumentZrodlowyRefId { get; set; }

        [ForeignKey("DokumentZrodlowyRefId")]
        public virtual JednDokumentTyp JednDokumentTyp { get; set; }

        public int KontrahentRefId { get; set; }
        [ForeignKey("KontrahentRefId")]
        public virtual Kontrahent Kontrahent { get; set; }

        [MaxLength(150)]
        public string Uwagi { get; set; }

        [JsonIgnore]
        public virtual ICollection<MagPzPozycja> MagPzPozycja { get; set; }

        [JsonIgnore]
        public virtual ICollection<MagPzKorekta> MagPzKorekta { get; set; }



    }
}