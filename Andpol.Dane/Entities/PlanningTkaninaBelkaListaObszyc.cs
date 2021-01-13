using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class PlanningTkaninaBelkaListaObszyc
    {
        public int PlanningTkaninaBelkaListaObszycId { get; set; }
        public bool IsDone { get; set; }
        public int PlanningTkaninaBelkaRefId { get; set; }
        [ForeignKey("PlanningTkaninaBelkaRefId")]
        public virtual PlanningTkaninaBelka PlanningTkaninaBelka { get; set; }
        public int ZamowienieKombiObszycieRefId { get; set; }
        [ForeignKey("ZamowienieKombiObszycieRefId")]
        public virtual ZamowienieKombiObszycie ZamowienieKombiObszycie { get; set; }
    }
}