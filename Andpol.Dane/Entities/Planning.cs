using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class Planning
    {

        public Planning()
        {
            PlanningDzienRoboczy =new HashSet<PlanningDzienRoboczy>();
            PlanningTkaninaBelka = new HashSet<PlanningTkaninaBelka>();
            PlanningPozycjaMagazynowa = new HashSet<PlanningPozycjaMagazynowa>();
        }

        public int PlanningId { get; set; }
        public virtual ICollection<PlanningDzienRoboczy> PlanningDzienRoboczy { get; set; }
        public virtual ICollection<PlanningTkaninaBelka> PlanningTkaninaBelka { get; set; }
        public virtual ICollection<PlanningPozycjaMagazynowa> PlanningPozycjaMagazynowa { get; set; }
    }
}