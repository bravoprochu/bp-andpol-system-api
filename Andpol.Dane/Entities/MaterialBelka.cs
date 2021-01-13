using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class MaterialBelka
    {
        public MaterialBelka() {
            this.MaterialBelkaRozchodObszycie = new HashSet<MaterialBelkaRozchodObszycie>();
            this.MaterialBelkaRozchodInne = new HashSet<MaterialBelkaRozchodInne>();
            this.PlanningTkaninaBelka = new HashSet<PlanningTkaninaBelka>();
        }


        public int MaterialBelkaId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public bool CzyAktywna { get; set; }
        public bool CzyPotwierdzona {get; set; }
        public bool CzyPowierzona { get; set; }

        public DateTime DataPrzyjecia { get; set; }

        public string FakturaNr { get; set; }
        public string DokumentZrodlowyNr { get; set; }

        public int MaterialRefId { get; set; }
        [ForeignKey("MaterialRefId")]
        public virtual Material Material { get; set; }

        public int? MaterialBelkaPzTkaninyRefId { get; set; }
        [ForeignKey("MaterialBelkaPzTkaninyRefId")]
        public virtual MaterialBelkaPzTkaniny MaterialBelkaPzTkaniny { get; set; }

        public string OznaczenieWewnetrzne { get; set; }

        public double StanAktualny { get; set; }
        public double StanPoczatkowy { get; set; }
        public double StanRzeczywisty { get; set; }

        public string Uwagi { get; set; }


        [JsonIgnore]
        public virtual ICollection<MaterialBelkaRozchodInne> MaterialBelkaRozchodInne { get; set; }
        [JsonIgnore]
        public virtual ICollection<MaterialBelkaRozchodObszycie> MaterialBelkaRozchodObszycie { get; set; }
        [JsonIgnore]
        public virtual ICollection<PlanningTkaninaBelka> PlanningTkaninaBelka { get; set; }

    }
}