using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class PlanningDzienRoboczy
    {
        public PlanningDzienRoboczy()
        {
            PlanningDzienRoboczyZamowienieKombi = new HashSet<PlanningDzienRoboczyZamowienieKombi>();
        }

        public int PlanningDzienRoboczyId { get; set; }

        public int PlanningRefId { get; set; }

        [ForeignKey("PlanningRefId")]
        public virtual Planning Planning { get; set; }

        public int KalendarzDniRoboczychDzialProdRefId { get; set; }

        [ForeignKey("KalendarzDniRoboczychDzialProdRefId")]
        public virtual KalendarzDniRoboczychDzialProd KalendarzDniRoboczychDzialProd { get; set; }
        public virtual ICollection<PlanningDzienRoboczyZamowienieKombi> PlanningDzienRoboczyZamowienieKombi { get; set; }

    }
}