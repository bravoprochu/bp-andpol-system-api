using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class MaterialBelkaPzTkaniny
    {
        public MaterialBelkaPzTkaniny()
        {
            this.MaterialBelka = new HashSet<MaterialBelka>();
        }

        public int MaterialBelkaPzTkaninyId { get; set; }
        public string CreatedBy { get; set; }
        public bool CzyZaksiegowana { get; set; }
        public bool CzyPowierzona { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string DokumentZrodlowyNr { get; set; }
        public int? FakturaZakupuRefId { get; set; }
        [ForeignKey("FakturaZakupuRefId")]
        public virtual FinFakturaZakupu FakturaZakupu { get; set; }
        public string Uwagi { get; set; }
        public virtual ICollection<MaterialBelka> MaterialBelka { get; set; }

    }
}