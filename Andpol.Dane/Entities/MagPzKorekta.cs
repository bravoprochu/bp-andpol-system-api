using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class MagPzKorekta
    {
        public string CreatedBy { get; set; }

        public int MagPzKorektaId { get; set; }

        public DateTime DataWplywu { get; set; }
        public DateTime DataWystawienia { get; set; }

        public string DokumentZrodlowyNr { get; set; }
        public int DokumentZrodlowyRefId { get; set; }

        [ForeignKey("DokumentZrodlowyRefId")]
        public virtual JednDokumentTyp JednDokumentTyp { get; set; }

        public int KontrahentRefId { get; set; }
        [ForeignKey("KontrahentRefId")]
        public virtual Kontrahent Kontrahent { get; set; }

        public int MagPzRefId { get; set; }
        [ForeignKey("MagPzRefId")]
        public virtual MagPz MagPz { get; set; }
        
        [MaxLength(150)]
        public string Uwagi { get; set; }

        [JsonIgnore]
        public virtual ICollection<MagPzPozycja> MagPzPozycja { get; set; }

    }
}