using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class ZamowienieKombiObszycie
    {
        public ZamowienieKombiObszycie()
        {
            PlanningTkaninaBelkaListaObszyc = new HashSet<PlanningTkaninaBelkaListaObszyc>();
        }
        public int ZamowienieKombiObszycieId { get; set; }

        public bool CzyWykonane { get; set; }

        public int KombinacjeObszycieRefId { get; set; }
        [ForeignKey("KombinacjeObszycieRefId")]
        public virtual KombinacjaObszycie KombinacjeObszycie { get; set; }
        public int MaterialRefId { get; set; }
        
        [ForeignKey("MaterialRefId")]
        public virtual Material Material { get; set; }

        public string Uwagi { get; set; }
        public int ZamowienieKombiRefId { get; set; }
        [ForeignKey("ZamowienieKombiRefId")]
        public virtual ZamowienieKombi ZamowienieKombi { get; set; }

        public virtual ICollection<PlanningTkaninaBelkaListaObszyc> PlanningTkaninaBelkaListaObszyc { get; set; }

    }
}
