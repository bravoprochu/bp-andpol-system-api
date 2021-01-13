using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class PlanningTkaninaBelka
    {
        public PlanningTkaninaBelka()
        {
            PlanningTkaninaBelkaListaObszyc = new HashSet<PlanningTkaninaBelkaListaObszyc>();
        }


        public int PlanningTkaninaBelkaId { get; set; }
        public bool CzyWydane { get; set; }
        public int MaterialBelkaRefId { get; set; }
        [ForeignKey("MaterialBelkaRefId")]
        public virtual MaterialBelka MaterialBelka { get; set; }
        public int PlanningRefId { get; set; }
        [ForeignKey("PlanningRefId")]
        public virtual Planning Planning { get; set; }

        public string Uwagi { get; set; }

        public double Wartosc { get; set; }

        public virtual ICollection<PlanningTkaninaBelkaListaObszyc> PlanningTkaninaBelkaListaObszyc { get; set; }
    }
}