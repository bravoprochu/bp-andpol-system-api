using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class PlanningDzienRoboczyZamowienieKombi
    {
        public int PlanningDzienRoboczyZamowienieKombiId { get; set; }

        public bool IsDone { get; set; }
        public string BrygadzistaNazwa { get; set; }
        public int PlanningDzienRoboczyRefId { get; set; }
        [ForeignKey("PlanningDzienRoboczyRefId")]
        public virtual PlanningDzienRoboczy PlanningDzienRoboczy { get; set; }

        public int ZamowienieKombiRefId { get; set; }
        [ForeignKey("ZamowienieKombiRefId")]
        public virtual ZamowienieKombi ZamowienieKombi { get; set; }
        


    }
}